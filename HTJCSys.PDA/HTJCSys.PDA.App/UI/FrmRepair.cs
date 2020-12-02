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
using XY.DataCollect.Intermec;
using Intermec.DataCollection;

namespace HTJCSys.PDA
{
    public partial class FrmRepair: Form
    {
        #region 变量信息
        /// <summary>
        /// 实例化ProductBomInfoDAL类
        /// </summary>
        ProductBomInfoDAL bomDAL = new ProductBomInfoDAL();
        /// <summary>
        /// 定义BOM实体变量
        /// </summary>
        //DataTable bomTable = null;//当前产品的BOM列表
        /// <summary>
        /// 实例化BatchNoDAL类
        /// </summary>
        BatchNoDAL batchDAL = new BatchNoDAL();
        /// <summary>
        /// 实例化本地LBrakepumpResultDAL类
        /// </summary>
        LBrakepumpResultDAL lBrakeResultDAL = new LBrakepumpResultDAL();
        /// <summary>
        /// 实例化本地LPedalResultDAL类
        /// </summary>
        LPedalResultDAL lPedalResultDAL = new LPedalResultDAL();
        /// <summary>
        /// 实例化MaterialFieldDAL类
        /// </summary>
        MaterialFieldDAL materialFieldDAL = new MaterialFieldDAL();
        /// <summary>
        /// 实例化LProductInfoDAL类
        /// </summary>
        LProductInfoDAL lProductDAL = new LProductInfoDAL();
        /// <summary>
        /// 定义当前选择产品实体类
        /// </summary>
        ProductInfoMDL productModel = null;
        /// <summary>
        /// 当前产品的扫描追溯集合
        /// </summary>
        //DataRow[] ScanRows = null;
        /// <summary>
        /// 当前产品的批次追溯集合
        /// </summary>
        //DataRow[] BatchRows = null;

        /// <summary>
        /// 当前产品编码
        /// </summary>
        string ProductCode = string.Empty;
        /// <summary>
        /// 选中记录材料编码
        /// </summary>
        string materialCode = string.Empty;
        /// <summary>
        /// 扫描类型
        /// </summary>
        ScanType scantype = ScanType.MATERIALCODE;//默认为材料编码
        /// <summary>
        /// 定义区别扫描合件还是材料的标示
        /// </summary>
        bool IsHjScan = true;//区别扫描的是合件还是材料，true为合件，false为材料
        /// <summary>
        /// 当前的材料编码对应ListView索引
        /// </summary>
        int listViewItemIndex = -1; 
        
        public FrmMain frmMain = null;

        public delegate void DeleteFrmRepairLoad();

        /******************20150319 http******************/
        /// <summary>
        /// Request请求追溯信息数据字典集合：RequestParam
        /// </summary>
        Dictionary<string, string> RequestParam = new Dictionary<string, string>();

        /******************end******************/

        #endregion

        #region 窗体初始化
        public FrmRepair()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体加载
        private void FrmBatch_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridLines(lvMaterial);
                Scanner.Instance().OnScanedEvent += new Action<object, BarcodeReadEventArgs>(scanner_OnScannerReaderEvent);//注册扫描事件
                Scanner.IsSound = BaseVariable.ScanIsSound;
                Scanner.IsShake = BaseVariable.ScanIsShake;
                Scanner.IsLED = BaseVariable.ScanIsLED;
                Scanner.IsContinue = false;
                Scanner.Enable();
                //画网格线
                SetGridLines(this.lvMaterial);
                this.Clear();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 扫描事件
        /// <summary>
        /// 扫描事件
        /// </summary>
        /// <param name="obj"></param>
        void scanner_OnScannerReaderEvent(object obj,BarcodeReadEventArgs args)//扫描事件响应函数，返回扫描到条码相关信息
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
                    this.lblTip.Text = "";
                    if (Opt.FeatureCodeList == null || Opt.FeatureCodeList.Count < 1)
                    {
                        this.lblTip.Text = "加载数据失败";
                        Audio.SoundTip(0);//错误提示音
                        return;
                    }
                    string barcode = "";
                    if (string.IsNullOrEmpty(args.strDataBuffer) || args.strDataBuffer.Length == 0)
                    {
                        this.lblTip.Text = "请重新扫描";
                        Audio.SoundTip(0);//错误提示音
                        return;
                    }

                    barcode = args.strDataBuffer;

                    if (IsHjScan)
                    {
                        //合件扫描
                        this.ValidateHj(barcode);
                    }
                    else
                    {
                        //零件扫描
                        SymbologyOptions.SymbologyType t = (SymbologyOptions.SymbologyType)args.SymbologyDetail;
                        ScanValidate(barcode, t);
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #region //验证合件
        private void ValidateHj(string barcode)
        {
            this.lblHJCode.Text = barcode;

            bool isNew = false;//新产品标识

            #region 判断合件条码长度
            bool CheckBitRST = Opt.HJValidate(barcode);
            //校验位判断
            if (!CheckBitRST)
            {
                this.lblTip.Text = "合件条码长度不符合!";
                Audio.SoundTip(0);//错误提示音
                return;
            }
            #endregion

            #region 判断校验位
            //判断校验位
            string CheckCode = barcode.Substring(0, 13);//校验合件条码
            string CheckBitOrigin = barcode.Substring(13, 1);//校验位
            string CheckBit = Opt.CheckBit(CheckCode);//获取校验位
            if (!CheckBit.ToLower().Equals(CheckBitOrigin.ToLower()))
            {
                this.lblTip.Text = "合件条码校验位错误!";
                Audio.SoundTip(0);//错误提示音
                return;
            }
            #endregion

            #region //判断特征码
            string fc = barcode.Substring(0, 6);
            //前一个特征码与现在扫描相同
            if (this.productModel != null && this.productModel.FeatureCode == fc)
            {
                //清除前一次信息
                foreach (ListViewItem item in lvMaterial.Items)
                {
                    item.SubItems[2].Text = "";//初始化状态为空
                    item.ForeColor = Color.Black;//初始化字体颜色为黑色
                }
            }
            else
            {
                isNew = this.productModel == null;
                if (Opt.FeatureCodeList.ContainsKey(fc))
                {
                    //扫描合件的特征码存在
                    this.productModel = Opt.FeatureCodeList[fc];
                    isNew = true;
                }
                else
                {
                    //扫描合件的特征码不存在
                    IsHjScan = true;
                    this.lblTip.Text = "合件条码不符,请重新扫描合件";
                    Audio.SoundTip(0);//错误提示音
                    return;
                }
            }
            #endregion

            #region 加载ListView数据
            if (isNew)
            {
                InitListView();
            } 
            #endregion

            Audio.SoundTip(1);//扫描提示音
            RecordScanInfo();//记录扫描信息
            IsHjScan = false;
            this.lblTip.Text = "请扫描零件条码或批次条码";
        } 
        #endregion

        #region 扫描验证---改造
        /// <summary>
        /// 扫描验证
        /// </summary>
        /// <param name="barcode"></param>
        private void ScanValidate(string barcode,SymbologyOptions.SymbologyType t)
        {
            try
            {
                barcode = barcode.Replace("<cr><lf>", "").Replace("\r\n", "").Replace("]C1", "");//获取条码/二维码,过滤回车换行
                bool IsExist = false;//标记是否存在
                foreach (ListViewItem item in this.lvMaterial.Items)
                {
                    string tmpBarcode = barcode;
                    string ItemCode = item.Text.ToString();//当前的零件编码
                    string FeatureCode = item.SubItems[3].Text;//特征码
                    string FeatureIndex = item.SubItems[4].Text;//特征位
                    string TraceType = item.SubItems[4].Text;//追溯类型
                    bool flag = false;

                    if (FeatureCode == null || FeatureCode.Trim() == "")
                    {
                        if (tmpBarcode.Length < ItemCode.Length)
                        {
                            continue;
                        }
                        string tmpCode = "";

                        if ((t == SymbologyOptions.SymbologyType.QR_Code
                            || t == SymbologyOptions.SymbologyType.DataMatrix
                            || t == SymbologyOptions.SymbologyType.Maxicode
                            || t == SymbologyOptions.SymbologyType.PDF417
                            || t == SymbologyOptions.SymbologyType.Aztec)
                            && barcode.Trim().Length >= 38)
                        //if (t == SymbologyOptions.SymbologyType.QR_Code && barcode.Trim().Length >= 38) //if (tmpBarcode.Length >= 38)
                        {
                            tmpCode = tmpBarcode.Substring(0, 10);
                            string supplier = tmpBarcode.Substring(15, 10);//供应商代码
                            string bno = tmpBarcode.Substring(25, 13);//批次号
                            tmpBarcode = bno + ";" + supplier;
                        }
                        //else
                        //{
                        //    tmpCode = tmpBarcode.Substring(0, ItemCode.Length);
                        //}

                        //flag = tmpCode == ItemCode;//判断特征码
                    }
                    else
                    {
                        if (tmpBarcode.Length < FeatureCode.Length)
                        {
                            continue;
                        }
                        flag = Opt.ValidateFeatureCode(tmpBarcode, FeatureIndex, FeatureCode);//判断特征码
                    }

                    if (flag)
                    {
                        materialCode = ItemCode;
                        item.ForeColor = Color.Green;//当防错正常时字体为绿色
                        item.SubItems[2].Text = tmpBarcode;//扫描条码
                        this.lblMaterialCode.Text = ItemCode;
                        this.lblBarCode.Text = tmpBarcode;
                        item.Selected = true;
                        RecordScanInfo();//记录扫描信息
                        this.lblTip.Text = "扫描零件条码或零件批次条码";
                        Audio.SoundTip(1);//扫描提示音
                        IsExist = true;
                        break;
                    }
                    else
                    {
                        string code = tmpBarcode.Substring(1);
                        bool IsOk = false;
                        switch (scantype)
                        {
                            case ScanType.MATERIALCODE:
                                if (ItemCode.Equals(code))
                                {
                                    this.lblMaterialCode.Text = code;//扫描的条码
                                    this.lblBarCode.Text = "";
                                    materialCode = ItemCode;
                                    item.Selected = true;//选中扫描的材料
                                    listViewItemIndex = item.Index;
                                    Audio.SoundTip(1);//扫描提示音
                                    scantype = ScanType.BARCODE;//修改扫描类型为批次条码
                                    this.lblTip.Text = "扫描零件批次条码";
                                    IsExist = true;
                                    IsOk = true;
                                }
                                break;
                            case ScanType.BARCODE:
                                this.lblBarCode.Text = tmpBarcode;//扫描的条码
                                this.lvMaterial.Items[listViewItemIndex].ForeColor = Color.Green;//当防错正常时字体为绿色
                                this.lvMaterial.Items[listViewItemIndex].SubItems[2].Text = tmpBarcode;//扫描条码
                                scantype = ScanType.MATERIALCODE;
                                RecordScanInfo();//记录扫描信息
                                this.lblTip.Text = "扫描零件条码或零件批次条码";
                                Audio.SoundTip(1);//扫描提示音
                                IsExist = true;
                                IsOk = true;
                                break;
                            default:
                                break;
                        }

                        if (IsOk)
                        {
                            break;
                        }
                    }
                }
                if (!IsExist && scantype != ScanType.BARCODE)//不存在的情况
                {                    
                    this.lblTip.Text = "扫描零件编码不在此产品之列";
                    Audio.SoundTip(0);//错误提示音
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 加载 ListView 数据
        /// <summary>
        /// 加载 ListView 数据
        /// </summary>
        public void InitListView()
        {
            try
            {
                this.lvMaterial.Items.Clear();
                this.lblProductCode.Text = this.productModel.ProductCode;
                this.lblTitle.Text = "返修-" + this.productModel.ProductName;
                this.scantype = ScanType.MATERIALCODE;
                //获取BOM表的信息
                /**
                 * 一次获取当前产品所有BOM信息
                 * 2014.11.30 By xudy
                 */
                string sql = string.Format("SELECT p.*,m.fieldname FROM `productbominfo` p INNER JOIN materialfield m ON p.materialcode=m.materialcode WHERE producttype='{0}' AND productcode='{1}' AND tracetype IN({2})", BaseVariable.DeviceEntity.ProductType, this.productModel.ProductCode, "'扫描追溯','批次追溯'");
                DataTable table = LocalDbDAL.GetDataTable(sql);
                if (table != null && table.Rows.Count > 0)
                {
                    int index = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["materialcode"].ToString());//材料条码:0
                        item.SubItems.Add(row["materialname"].ToString());//:1
                        item.SubItems.Add("");//:2
                        item.SubItems.Add(row["featurecode"].ToString());//特征码:3
                        item.SubItems.Add(row["featureindex"].ToString());//特征位:4
                        item.SubItems.Add(row["fieldname"].ToString());//字段民称:5
                        item.SubItems.Add(row["tracetype"].ToString());//追溯类型:6
                        if (index % 2 == 0)
                        {
                            item.BackColor = Color.Gainsboro;//偶数背景色淡灰色
                        }
                        else
                        {
                            item.BackColor = Color.Silver;//奇数背景色为银色
                        }
                        item.ForeColor = Color.Black;//字体颜色为黑色
                        this.lvMaterial.Items.Add(item);
                        index++;
                    }
                }
                else
                {
                    this.lblTip.Text="当前型号没有追溯零件";
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 为ListView画网格线
        private const int LVM_GETEXTENDEDLISTVIEWSTYLE = 0x1037;
        private const int LVM_SETEXTENDEDLISTVIEWSTYLE = 0x1036;
        private const int LVS_EX_GRIDLINES = 0x1;
        public const int SET_BACKGROUND_COLOR = 0x1007;//4103

        [System.Runtime.InteropServices.DllImport("coredll.dll")]
        private static extern int SendMessageW(int hWnd, int wMsg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("coredll.dll")]
        private static extern int GetFocus();

        /// <summary>
        /// 为ListView画网格线
        /// </summary>
        /// <param name="lvw"></param>
        public static void SetGridLines(System.Windows.Forms.ListView lvw)
        {
            lvw.Focus();
            int hWnd = GetFocus();
            int extendedStyle = SendMessageW(hWnd, LVM_GETEXTENDEDLISTVIEWSTYLE, 0, 0);
            extendedStyle |= LVS_EX_GRIDLINES;
            SendMessageW(hWnd, LVM_SETEXTENDEDLISTVIEWSTYLE, 0, extendedStyle);
            //SendMessageW(hWnd, SET_BACKGROUND_COLOR, 0, (str)RGB(255, 0, 0));
        }
        #endregion

        #region 应用更新---改造
        /// <summary>
        /// 应用更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                int rst = 0;
                if (Opt.GlobalNetStatus())//网络状态良好的情况下
                {
                    rst = ResultDAL.Update(BaseVariable.ResultTableName, this.lblHJCode.Text, this.lblProductCode.Text, "", "", "", RequestParam);
                    rst = ResultDAL.Update(BaseVariable.ResultTableName, this.lblHJCode.Text, this.lblProductCode.Text, BaseVariable.DeviceEntity.ProductType, BaseVariable.UserEntity.UserID, BaseVariable.DeviceEntity.StationID, RequestParam);
                }
                if (rst==1)
                {
                    //重新加载数据
                    foreach (ListViewItem item in this.lvMaterial.Items)
                    {
                        item.SubItems[2].Text = "";//扫描条码
                        item.ForeColor = Color.Black;
                    }
                    this.lblTip.Text = "更新成功！请扫描合件条码";
                    Audio.SoundTip(2);//正确提示音
                    this.lblHJCode.Text = "";
                    this.lblMaterialCode.Text = "";
                    this.lblBarCode.Text = "";
                    scantype = ScanType.MATERIALCODE;
                    IsHjScan = true;
                    RequestParam.Clear();
                }
                else if (rst==201)
                {
                    this.lblTip.Text = "合件不存在！";
                    Audio.SoundTip(0);//失败提示音
                }
                else
                {
                    this.lblTip.Text = "更新失败！";
                    Audio.SoundTip(0);//失败提示音
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 记录扫描信息---改造
        /// <summary>
        /// 记录扫描信息
        /// </summary>
        private void RecordScanInfo()
        {
            try
            {
                if (IsHjScan)//合件扫描记录
                {
                    RequestParam.Clear();//清除数据
                }
                else//材料扫描记录
                {
                    //添加扫描追溯的信息
                    //子零件编码和条码信息
                    if (RequestParam.ContainsKey(materialCode))
                    {
                        RequestParam.Remove(materialCode);
                    }
                    RequestParam.Add(materialCode, this.lblBarCode.Text);
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #region 返回按钮---改造
        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (RequestParam!=null && RequestParam.Count>0)
                {
                    if (MessageBox.Show("当前返修未完成,确定返回吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        HTJCSys.PDA.FrmMain.DeleteFrmMainLoad FrmMainLoad = new FrmMain.DeleteFrmMainLoad(frmMain.LoadForm);
                        FrmMainLoad.Invoke();
                        this.Close();

                    }
                }
                else
                {
                    HTJCSys.PDA.FrmMain.DeleteFrmMainLoad FrmMainLoad = new FrmMain.DeleteFrmMainLoad(frmMain.LoadForm);
                    FrmMainLoad.Invoke();
                    this.Close();
                }
                Scanner.Disable();//禁用扫描
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 复位按钮---改造
        /// <summary>
        /// 复位按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblHJCode.Text = "";
                this.lblMaterialCode.Text="";
                this.lblBarCode.Text = "";
                this.lblTip.Text="请扫描合件条码";
                this.IsHjScan = true;
                scantype = ScanType.MATERIALCODE;
                RequestParam.Clear();
                foreach (ListViewItem item in this.lvMaterial.Items)
                {
                    item.SubItems[2].Text = "";
                    item.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 窗体激活与未激活
        private void FrmRepair_Activated(object sender, EventArgs e)
        {
            try
            {
                //Scanner.Instance().OnScanedEvent += new Action<object, BarcodeReadEventArgs>(scanner_OnScannerReaderEvent);//注册扫描事件
                //Scanner.IsSound = BaseVariable.ScanIsSound;
                //Scanner.IsShake = BaseVariable.ScanIsShake;
                //Scanner.IsLED = BaseVariable.ScanIsLED;
                //Scanner.Enable();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.StackTrace);
            }
        }

        private void FrmRepair_Deactivate(object sender, EventArgs e)
        {
            try
            {
                //Scanner.Instance().OnScanedEvent -= new Action<object, BarcodeReadEventArgs>(scanner_OnScannerReaderEvent);//当活动窗体变为非活动窗体时发生的事件响应函数
                //Scanner.Disable();//禁用扫描
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.StackTrace);
            }
        } 
        #endregion

        #region 清除方法
        /// <summary>
        /// 清除方法
        /// </summary>
        public void Clear()
        {
            this.productModel = null;
            this.lblHJCode.Text = null;
            this.lblProductCode.Text = null;
            this.lblMaterialCode.Text = null;
            this.lblBarCode.Text = null;
            this.lblTip.Text = "请扫描合件条码";
            this.IsHjScan = true;
            this.lvMaterial.Items.Clear();
        }
        #endregion
    }
}