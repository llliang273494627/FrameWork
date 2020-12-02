using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using COM;
using DAL;
using MDL;
using System.Collections;
using Intermec.DataCollection;
using XY.DataCollect.Intermec;

namespace HTJCSys.PDA
{
    public partial class FrmBatch : Form
    {
        #region 变量信息
        BatchNoDAL batchDAL = new BatchNoDAL();
        LBatchNoDAL lBatchDAL = new LBatchNoDAL();

        /// <summary>
        /// 实例化ProductBomInfoDAL类
        /// </summary>
        ProductBomInfoDAL bomDAL = new ProductBomInfoDAL();
        /// <summary>
        /// 实例化LProductBomInfoDAL类
        /// </summary>
        LProductBomInfoDAL lBomDAL = new LProductBomInfoDAL();

        /// <summary>
        /// 扫描类型
        /// </summary>
        ScanType scantype = ScanType.MATERIALCODE;//默认为材料编码
        public delegate void DelegateBatchLoad();
        public FrmMain frmMain = null;

        /// <summary>
        /// false：扫描，true：手动
        /// </summary>
        bool IsEdit = false;

        /// <summary>
        /// false：未完成，true：完成
        /// </summary>
        bool IsOK = false;

        //当前批次零件的集合信息
        Hashtable MaterialInfoList = new Hashtable();
        #endregion

        #region 窗体初始化
        public FrmBatch()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBatch_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbMaterialCode.Items.Clear();
                this.lblTitle.Text = "批次追溯";
                this.Reset();
                if (!Opt.InitFeatureCode())
                {
                    MessageBox.Show("获取特征码列表失败,请重试","系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                this.LoadData();//加载数据
                if (MaterialInfoList == null)
                {
                    this.lblTip.Text = "该产品类型无批次追溯零件";
                }
                Scanner.Instance().OnScanedEvent += new Action<object, BarcodeReadEventArgs>(scanner_OnScannerReaderEvent);//注册扫描事件
                Scanner.IsSound = BaseVariable.ScanIsSound;
                Scanner.IsShake = BaseVariable.ScanIsShake;
                Scanner.IsLED = BaseVariable.ScanIsLED;
                Scanner.IsContinue = false;
                Scanner.Enable();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message+ex.StackTrace);
            }
        } 
        #endregion

        #region 扫描事件
        /// <summary>
        /// 扫描事件
        /// </summary>
        /// <param name="obj"></param>
        void scanner_OnScannerReaderEvent(object obj, BarcodeReadEventArgs args)//扫描事件响应函数，返回扫描到条码相关信息
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Action<object, BarcodeReadEventArgs> fun = new Action<object, BarcodeReadEventArgs>(scanner_OnScannerReaderEvent);
                    this.Invoke(fun, new object[] { obj, args });
                }
                else
                {
                    if (string.IsNullOrEmpty(args.strDataBuffer) || args.strDataBuffer.Length == 0)
                    {
                        this.lblTip.Text = "扫描的条码错误";
                        Audio.SoundTip(0);//错误提示音
                        return;
                    } 
                    
                    SymbologyOptions.SymbologyType t = (SymbologyOptions.SymbologyType)args.SymbologyDetail;
                    ScanOptFun(args.strDataBuffer,t);//扫描的执行方法
                }
            }
            catch (Exception ex)
            {
                this.lblTip.Text = "扫描失败";
                CLog.WriteErrLog("[Frmbatch.ScanEvent]" + ex.Message);
            }
        }
        #endregion

        #region 扫描执行操作的方法
        /// <summary>
        /// 扫描执行操作的方法
        /// </summary>
        /// <param name="obj"></param>
        private void ScanOptFun(string barcode,SymbologyOptions.SymbologyType t)
        {
            try
            {
                if (!IsEdit)
                {
                    #region 扫描录入
                    this.lblTip.Text = "";

                    switch (scantype)
                    {
                        case ScanType.MATERIALCODE://材料编码扫描
                            {
                                #region //材料编码扫描
                                this.cmbMaterialCode.SelectedIndex = -1;
                                this.lblMaterialName.Text = "";
                                this.tbMaterialBatchNum.Text = "";
                                this.tbMaterialBatchNo.Text = "";
                                this.tbSupplier.Text = "";
                                this.tbBarCode.Text = "";
                                string pcode = "";

                                //判断是否为二维码
                                #region // 二维码
                                if ((t == SymbologyOptions.SymbologyType.QR_Code
                                    || t == SymbologyOptions.SymbologyType.DataMatrix
                                    || t == SymbologyOptions.SymbologyType.Maxicode
                                    || t == SymbologyOptions.SymbologyType.PDF417
                                    || t == SymbologyOptions.SymbologyType.Aztec) 
                                    && barcode.Trim().Length >= 38)
                                {
                                    pcode = barcode.Substring(0, 10);
                                    if (MaterialInfoList.ContainsKey(pcode))
                                    {
                                        //能够匹配
                                        Audio.SoundTip(1);//扫描提示音
                                        string bnumstr = barcode.Substring(10, 5);//包装量
                                        string supplier = barcode.Substring(15, 10);//供应商代码
                                        string bno = barcode.Substring(25, 13);//批次号

                                        BatchNoMDL model = MaterialInfoList[pcode] as BatchNoMDL;

                                        int batchnum = model.BatchNum;
                                        try
                                        {
                                            int bnum = int.Parse(bnumstr);
                                            batchnum = bnum;
                                        }
                                        catch (Exception)
                                        {
                                        }

                                        this.cmbMaterialCode.Text = model.MaterialCode;
                                        this.lblMaterialName.Text = model.MaterialName;
                                        this.tbMaterialBatchNum.Text = batchnum.ToString();
                                        this.tbSupplier.Text = supplier;
                                        this.tbMaterialBatchNo.Text = bno;
                                        IsOK = false;
                                        scantype = ScanType.HJBARCODE;

                                        this.tbBarCode.Focus();
                                        this.lblTip.Text = "请扫描合件条码";
                                    }
                                    else
                                    {
                                        //不能够匹配
                                        Audio.SoundTip(0);//错误提示音
                                        scantype = ScanType.MATERIALCODE;
                                        this.lblTip.Text = "扫描的条码的零件不符当前产品";
                                        this.tbMaterialBatchNo.Text = barcode;
                                        IsOK = true;
                                    }
                                    return;
                                } 
                                #endregion

                                string code = barcode.Substring(1);
                                this.cmbMaterialCode.Text = code;//扫描的条码
                                if (MaterialInfoList.ContainsKey(code))
                                {
                                    Audio.SoundTip(1);//扫描提示音
                                    scantype = ScanType.PacketNumber;//修改扫描类型为供应商条码
                                    BatchNoMDL model = MaterialInfoList[code] as BatchNoMDL;
                                    this.cmbMaterialCode.Text = model.MaterialCode;
                                    this.lblMaterialName.Text = model.MaterialName;
                                    //this.tbMaterialBatchNum.Text = model.BatchNum.ToString();

                                    this.tbMaterialBatchNum.Focus();

                                    this.lblTip.Text = "请扫描包装数量";
                                    //this.lblTip.Text = "请扫描供应商编码";
                                }
                                else
                                {
                                    Audio.SoundTip(0);//错误提示音
                                    scantype = ScanType.MATERIALCODE;
                                    this.lblTip.Text = "扫描的条码的零件不符当前产品";
                                } 
                                #endregion
                            }
                            break;
                        case ScanType.Supplier://供应商编码
                            {
                                Audio.SoundTip(1);//扫描提示音
                                this.tbSupplier.Text = barcode;
                                scantype = ScanType.PacketNumber;
                                this.tbMaterialBatchNum.Focus();

                                this.lblTip.Text = "请扫描包装数量";
                            }
                            break;
                        case ScanType.PacketNumber://包装数量
                            {
                                this.tbMaterialBatchNum.Text = barcode.ToUpper().Replace("Q","");
                                int num = 0;
                                try
                                {
                                    num = int.Parse(this.tbMaterialBatchNum.Text);
                                }
                                catch (Exception)
                                {
                                    num = 0;
                                    scantype = ScanType.PacketNumber;
                                }

                                if (num == 0)
                                {
                                    this.lblTip.Text = "扫描包装数量不是数字或=0";
                                    return;
                                }

                                scantype = ScanType.BARCODE;
                                this.tbMaterialBatchNo.Focus();

                                this.lblTip.Text = "请扫描批次条码";
                            }
                            break;
                        case ScanType.BARCODE://批次条码
                            {
                                string code = barcode.Substring(1);
                                if (barcode.Substring(0, 1).Equals("P") && code == this.cmbMaterialCode.Text)
                                {
                                    Audio.SoundTip(0);//错误提示音
                                    this.lblTip.Text = "重复扫描零件条码";
                                    scantype = ScanType.BARCODE;
                                }
                                else
                                {
                                    Audio.SoundTip(1);//扫描提示音
                                    this.tbMaterialBatchNo.Text = barcode;//扫描的条码
                                    this.lblTip.Text = "请扫描合件条码";
                                    scantype = ScanType.HJBARCODE;
                                    this.tbBarCode.Focus();
                                }
                            }
                            break;
                        case ScanType.HJBARCODE://合件条码扫描
                            {
                                this.tbBarCode.Text = barcode;

                                #region //添加合件验证
                                if (Opt.ValidatePartCode(this.cmbMaterialCode.Text, barcode))
                                {
                                    Audio.SoundTip(1);
                                    scantype = ScanType.MATERIALCODE;
                                    this.lblTip.Text = "更新信息或者是重新录入";
                                    return;
                                }
                                #endregion

                                Audio.SoundTip(0);
                                scantype = ScanType.HJBARCODE;
                                this.lblTip.Text = "扫描的合件不匹配,请重新录入";
                            }
                            break;
                    }
                    #endregion
                }
                else
                {
                    #region 手动录入
                    if (this.MaterialInfoList != null && this.cmbMaterialCode.SelectedIndex > 0)
                    {
                        //判断是否为二维码
                        if (barcode.Trim().Length >= 38)
                        {
                            var pcode = barcode.Substring(0, 10);
                            if (MaterialInfoList.ContainsKey(pcode))
                            {
                                //能够匹配
                                Audio.SoundTip(1);//扫描提示音
                                SetQrCode(barcode);
                            }
                            return;
                        }

                        if (this.tbBarCode.Focused)
                        {
                            this.tbBarCode.Text = barcode;
                            Audio.SoundTip(1);
                        }
                        else if (this.tbSupplier.Focused)
                        {
                            this.tbSupplier.Text = barcode;
                            Audio.SoundTip(1);
                            this.tbMaterialBatchNum.Focus();
                        }
                        else if (this.tbMaterialBatchNum.Focused)
                        {
                            this.tbMaterialBatchNum.Text = barcode.ToUpper().Replace("Q", "");
                            int num = 0;
                            try
                            {
                                num = int.Parse(this.tbMaterialBatchNum.Text);
                            }
                            catch (Exception)
                            {
                                num = 0;
                            }

                            if (num == 0)
                            {
                                this.lblTip.Text = "扫描包装数量不是数字或=0";
                                Audio.SoundTip(0);
                                return;
                            }

                            Audio.SoundTip(1);
                            this.tbMaterialBatchNo.Focus();
                        }
                        else if (this.tbMaterialBatchNo.Focused)
                        {
                            this.tbMaterialBatchNo.Text = barcode;
                            Audio.SoundTip(1);
                            this.tbBarCode.Focus();
                        }
                        else
                        {
                            return;
                        }

                        int ret = 0;

                        if (string.IsNullOrEmpty(this.tbBarCode.Text))
                        {
                            ret += 1;
                            this.lblTip.Text = "请录入合件条码";
                            this.tbBarCode.Focus();
                        }
                        if (string.IsNullOrEmpty(this.tbMaterialBatchNo.Text))
                        {
                            ret += 1;
                            this.lblTip.Text = "请录入批次流水号";
                            this.tbMaterialBatchNo.Focus();
                        }
                        if (string.IsNullOrEmpty(this.tbMaterialBatchNum.Text))
                        {
                            ret += 1;
                            this.lblTip.Text = "请录入包装数量";
                            this.tbMaterialBatchNum.Focus();
                        }
                        //if (string.IsNullOrEmpty(this.tbSupplier.Text))
                        //{
                        //    ret += 1;
                        //    this.lblTip.Text = "请录入供应商编码";
                        //    this.tbSupplier.Focus();
                        //}

                        if (ret==0)
                        {
                            this.lblTip.Text = "更新信息或者是重新录入";
                        }
                    }
                    else
                    {
                        Audio.SoundTip(0);//错误提示音
                        this.lblTip.Text = "请选择零件编码";
                        this.cmbMaterialCode.Focus();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }

        private void SetQrCode(string code)
        {
            string pcode = code.Substring(0, 10);
            string bnumstr = code.Substring(10, 5);//包装量
            string supplier = code.Substring(15, 10);//供应商代码
            string bno = code.Substring(25, 13);//批次号

            BatchNoMDL model = MaterialInfoList[pcode] as BatchNoMDL;

            int batchnum = model.BatchNum;
            try
            {
                int bnum = int.Parse(bnumstr);
                batchnum = bnum;
            }
            catch (Exception)
            {
            }

            this.cmbMaterialCode.Text = model.MaterialCode;
            this.lblMaterialName.Text = model.MaterialName;
            this.tbMaterialBatchNum.Text = batchnum.ToString();
            this.tbSupplier.Text = supplier;
            this.tbMaterialBatchNo.Text = bno;

            this.lblTip.Text = "请录入合件条码";
            this.tbBarCode.Focus();
        }
        #endregion

        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadData()
        {
            try
            {
                string sql = string.Format("SELECT DISTINCT(materialcode),materialname,CASE WHEN batchnum > 0 then batchnum ELSE 0 END batchnum FROM ProductBomInfo WHERE TraceType='{0}' AND ProductType = '{1}' ORDER BY materialcode ASC", "批次追溯", BaseVariable.DeviceEntity.ProductType);
                DataTable table = LocalDbDAL.GetDataTable(sql);

                if (table == null || table.Rows.Count < 1)
                {
                    MaterialInfoList = null;
                    return;
                }
                this.cmbMaterialCode.Items.Add("--- 请选择 ---");
                foreach (DataRow row in table.Rows)
                {
                    BatchNoMDL model = new BatchNoMDL()
                    {
                        MaterialCode = row["MaterialCode"].ToString(),
                        MaterialName = row["MaterialName"].ToString(),
                        BatchNum = int.Parse(row["BatchNum"].ToString())
                    };
                    if (!MaterialInfoList.ContainsKey(model.MaterialCode))
                    {
                        this.cmbMaterialCode.Items.Add(model.MaterialCode);
                        MaterialInfoList.Add(model.MaterialCode, model);
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[Frmbatch.LoadInfo]" + ex.Message);
            }
        }
        #endregion

        #region 重置方法
        /// <summary>
        /// 重置方法
        /// </summary>
        public void Reset()
        {
            this.lblTip.Text = "请扫描零件条码";
            this.cmbMaterialCode.Enabled = false;
            this.cmbMaterialCode.SelectedIndex = -1;
            this.lblMaterialName.Text = "";
            this.tbSupplier.ReadOnly = true;
            this.tbSupplier.Text = "";
            this.tbBarCode.ReadOnly = true;
            this.tbBarCode.Text = "";
            this.tbMaterialBatchNo.ReadOnly = true;
            this.tbMaterialBatchNo.Text = "";
            this.tbMaterialBatchNum.ReadOnly = true;
            this.tbMaterialBatchNum.Text = "";
            this.IsEdit = false;
            this.scantype = ScanType.MATERIALCODE;
            IsOK = false;
        } 
        #endregion

        #region 应用更新
        /// <summary>
        /// 应用更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsOK)
                {
                    this.lblTip.Text = "未录入数据!!!";
                    Audio.SoundTip(0);//失败提示音
                    return;
                }
                if (!string.IsNullOrEmpty(this.cmbMaterialCode.Text) &&
                    this.cmbMaterialCode.Text.Trim() != "" &&
                    !string.IsNullOrEmpty(this.tbMaterialBatchNo.Text) &&
                    this.tbMaterialBatchNo.Text.Trim() != "" &&
                    !string.IsNullOrEmpty(this.tbMaterialBatchNum.Text) &&
                    this.tbMaterialBatchNum.Text.Trim() != "" &&
                    !string.IsNullOrEmpty(this.tbBarCode.Text) &&
                    this.tbBarCode.Text.Trim() != "")
                {
                    if (IsEdit)
                    {
                        #region //添加合件验证
                        if (!Opt.ValidatePartCode(this.cmbMaterialCode.Text, this.tbBarCode.Text.Trim()))
                        {
                            Audio.SoundTip(0);
                            this.lblTip.Text = "扫描的合件不匹配,请重新录入";
                            return;
                        }
                        if (string.IsNullOrEmpty(this.tbBarCode.Text))
                        {
                            Audio.SoundTip(0);
                            this.lblTip.Text = "请录入合件条码";
                            return;
                        }
                        if (string.IsNullOrEmpty(this.tbMaterialBatchNo.Text))
                        {
                            Audio.SoundTip(0);
                            this.lblTip.Text = "请录入批次流水号";
                            return;
                        }
                        if (string.IsNullOrEmpty(this.tbMaterialBatchNum.Text))
                        {
                            Audio.SoundTip(0);
                            this.lblTip.Text = "请录入包装数量";
                            return;
                        }
                        else
                        {
                            int num = 0;
                            try
                            {
                                num = int.Parse(this.tbMaterialBatchNum.Text);
                            }
                            catch (Exception)
                            {
                                num = 0;
                                scantype = ScanType.PacketNumber;
                            }

                            if (num == 0)
                            {
                                this.lblTip.Text = "扫描包装数量不是数字或=0";
                                return;
                            }
                        }
                        //if (string.IsNullOrEmpty(this.tbSupplier.Text))
                        //{
                        //    Audio.SoundTip(0);
                        //    this.lblTip.Text = "请录入供应商编码";
                        //    return;
                        //}
                        #endregion
                    }

                    BatchNoMDL model = MaterialInfoList[this.cmbMaterialCode.Text.Trim()] as BatchNoMDL;
                    if (model==null)
                    {
                        return;
                    }

                    string barcode = this.tbBarCode.Text.Trim();
                    string batchno = this.tbMaterialBatchNo.Text.Trim();
                    string supplier = this.tbSupplier.Text.Trim();
                    int batchnum = model.BatchNum;
                    if (!string.IsNullOrEmpty(this.tbMaterialBatchNum.Text.Trim()))
                    {
                        try
                        {
                            int num = int.Parse(this.tbMaterialBatchNum.Text.Trim());
                            batchnum = num;
                        }
                        catch (Exception)
                        {
                        }
                    }

                    model.BarCode = barcode;
                    model.BatchNo = batchno;
                    model.Supplier = supplier;
                    model.BatchNum = batchnum;
                    model.ProductType = BaseVariable.DeviceEntity.ProductType;

                    bool flag = false;//结果标识
                    if (Opt.GlobalNetStatus())//存储到服务器
                    {
                        flag = batchDAL.Insert(model);
                    }
                    else//存储到服务器
                    {
                        flag = lBatchDAL.Add(model);
                    }

                    if (flag)
                    {
                        IsOK = true;
                        scantype = ScanType.MATERIALCODE;
                        this.lblTip.Text = "更新成功,请扫描批次条码";
                        Audio.SoundTip(2);//正确提示音
                    }
                    else
                    {
                        this.lblTip.Text = "更新失败,请重试";
                        Audio.SoundTip(0);//失败提示音
                    }
                }
                else
                {
                    this.lblTip.Text = "批次相关信息不能为空";
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[Frmbatch.Apply]" + ex.Message);
            }
        }

        #endregion

        #region 返回按钮
        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Scanner.Disable();//禁用扫描
                this.Close();
                HTJCSys.PDA.FrmMain.DeleteDataUpload DataUpload = new FrmMain.DeleteDataUpload(frmMain.TipDataUpload);
                DataUpload.Invoke();
                this.Dispose();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion        

        #region 重置
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblTip.Text = "请扫描零件条码";
                this.cmbMaterialCode.SelectedIndex = -1;
                this.lblMaterialName.Text = "";
                this.tbSupplier.Text = "";
                this.tbMaterialBatchNum.Text = "";
                this.tbMaterialBatchNo.Text = "";
                this.tbBarCode.Text = "";
                this.scantype = ScanType.MATERIALCODE;
                this.IsOK = false;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.StackTrace);
            }
        } 
        #endregion

        #region 手动
        /// <summary>
        /// 手动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnEdit.Text == "手动")
                {
                    this.cmbMaterialCode.SelectedIndex = 0;
                    IsEdit = true;
                    this.cmbMaterialCode.Enabled = true;
                    this.tbMaterialBatchNo.ReadOnly = false;
                    this.tbSupplier.ReadOnly = false;
                    this.tbMaterialBatchNum.ReadOnly = false;
                    this.tbBarCode.ReadOnly = false;
                    this.btnEdit.Text = "扫描";
                }
                else
                {
                    Reset();
                    this.btnEdit.Text = "手动";
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.StackTrace);
            }
        } 
        #endregion

        #region 产品编码下拉框选择事件
        /// <summary>
        /// 产品编码下拉框选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbMaterialCode.Items!=null && this.cmbMaterialCode.SelectedIndex > 0)
                {
                    string code = this.cmbMaterialCode.Text;
                    if (MaterialInfoList.ContainsKey(code))
                    {
                        BatchNoMDL model = MaterialInfoList[code] as BatchNoMDL;
                        this.cmbMaterialCode.Text = model.MaterialCode;
                        this.lblMaterialName.Text = model.MaterialName;
                        this.tbMaterialBatchNum.Text = model.BatchNum.ToString();
                        this.scantype = ScanType.MATERIALCODE;
                        this.IsOK = false;
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.StackTrace);
            }
        } 
        #endregion
    }

    #region 扫描的类型
    /// <summary>
    /// 扫描的类型
    /// </summary>
    public enum ScanType
    {
        /// <summary>
        /// 材料编码
        /// </summary>
        MATERIALCODE,
        /// <summary>
        /// 合件
        /// </summary>
        HJBARCODE,
        /// <summary>
        /// 扫描流水号条码
        /// </summary>
        BARCODE,
        /// <summary>
        /// 包装数量
        /// </summary>
        PacketNumber,
        /// <summary>
        /// 供应商编码
        /// </summary>
        Supplier
    } 
    #endregion
}