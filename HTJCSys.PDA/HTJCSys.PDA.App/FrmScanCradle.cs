using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SCAN.Scanner2D;
using System.Collections;
using D300.System;
using COM;
using DAL;
using MDL;

namespace HTJCSysPDA
{
    /// <summary>
    /// T9摇篮线扫描追溯
    /// </summary>
    public partial class FrmScanCradle : Form
    {
        //初始化
        #region 初始化
        #region 定义的变量
        /// <summary>
        /// 实例化ProductBomInfoDAL类
        /// </summary>
        ProductBomInfoDAL bomDAL = new ProductBomInfoDAL();
        /// 实例化LProductBomInfoDAL类
        /// </summary>
        LProductBomInfoDAL lBomDAL = new LProductBomInfoDAL();
        /// <summary>
        /// 定义BOM实体变量
        /// </summary>
        DataTable bomTable = null;//当前产品的BOM列表
        /// <summary>
        /// 实例化ProductInfoDAL类
        /// </summary>
        ProductInfoDAL productDAL = new ProductInfoDAL();
        /// <summary>
        /// 定义当前选择产品实体类
        /// </summary>
        ProductInfoMDL productModel = null;
        /// <summary>
        /// 实例化CradleResultDAL类
        /// </summary>
        CradleResultDAL resultDAL = new CradleResultDAL();
        /// <summary>
        /// 实例化本地CradleResultDAL类
        /// </summary>
        LCradleResultDAL lResultDAL = new LCradleResultDAL();
        /// <summary>
        /// 定义扫描的CradleResultMDL类
        /// </summary>
        //CradleResultMDL resultModel = null;
        /// <summary>
        /// 实例化MaterialFieldDAL类
        /// </summary>
        MaterialFieldDAL materialFieldDAL = new MaterialFieldDAL();
        /// <summary>
        /// 实例化LMaterialFieldDAL类
        /// </summary>
        LMaterialFieldDAL lMaterialFieldDAL = new LMaterialFieldDAL();
        /// <summary>
        /// 定义扫描修改字段MaterialFieldMDL类
        /// </summary>
        MaterialFieldMDL materialFieldModel = null;
        /// <summary>
        /// 实例化LStockInfoDAL类
        /// </summary>
        LStockInfoDAL LStockDAL = new LStockInfoDAL();
        /// <summary>
        /// 定义当前合件批次追溯材料数据表
        /// </summary>
        DataTable batchTable = null;

        BatchNoDAL batchDAL = new BatchNoDAL();

        /// <summary>
        /// 定义加载产品列表的委托事件
        /// </summary>
        /// <param name="productCode"></param>
        public delegate void listProductCode();//加载产品列表的委托

        /// <summary>
        /// 定义检查材料条码的委托事件
        /// </summary>
        /// <param name="productCode"></param>
        public delegate void CheckMaterialList();//检查材料条码的委托 

        /// <summary>
        /// 定义FrmSelect属性
        /// </summary>
        public FrmSelect frmSelect = null;

        /// <summary>
        /// 定义区别扫描合件还是材料的标示
        /// </summary>
        bool IsHjScan = true;//区别扫描的是合件还是材料，true为合件，false为材料
        /// <summary>
        /// 产品特征码
        /// </summary>
        string featureCode = string.Empty;
        /// <summary>
        /// 当前合件检查是否OK
        /// </summary>
        bool IsOK = false;
        /// <summary>
        /// 当前材料编码
        /// </summary>
        string materialCode = string.Empty;
        /// <summary>
        /// 当前材料名称
        /// </summary>
        //string materialName = string.Empty;
        /// <summary>
        /// 是否可以扫描
        /// </summary>
        bool IsAbleScan = false;
        /// <summary>
        /// 本地材料列表
        /// </summary>
        //Hashtable LocalMaterialHT = new Hashtable();
        /// <summary>
        /// 远程服务器材料列表
        /// </summary>
        //Hashtable RemoteMaterialHT = new Hashtable();
        public FrmMain frmMain = null;
        /// <summary>
        /// 材料信息HT表
        /// </summary>
        public static Hashtable HTMaterialTable = new Hashtable();
        /// <summary>
        /// 当前材料信息HT表
        /// </summary>
        public static Hashtable MaterialList = new Hashtable();
        #endregion

        #region 窗体初始化
        public FrmScanCradle()
        {
            InitializeComponent();
            LoadProductInfo();
        }
        #endregion
        #endregion

        //事件
        #region 事件
        #region 窗体加载事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmScan_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridLines(this.lvMaterial);//画网格线
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
        void scanner_OnScannerReaderEvent(Scanner.CodeInfo obj)//扫描事件响应函数，返回扫描到条码相关信息
        {
            try
            {
                if (string.IsNullOrEmpty(obj.barcode) || obj.len == 0)
                {
                    this.Tip("请重新扫描");
                    return;
                }
                if (this.InvokeRequired)
                {
                    Action<Scanner.CodeInfo> delegateFun = new Action<Scanner.CodeInfo>(scanner_OnScannerReaderEvent);
                    this.Invoke(delegateFun, obj);
                }
                else
                {
                    if (IsAbleScan)
                    {
                        this.lblCurrentMaterialCode.Text = "";//清空提示信息
                        this.lblCurrentMaterialCode.ForeColor = Color.Navy;
                        //判断是合件条码还是材料条码
                        if (IsHjScan)//当为合件时
                        {
                            if (obj.len < 14)
                            {
                                this.Tip("请重新扫描");
                                return;
                            }
                            //D300SysUI.PlaySound(BaseVariable.ScanSound);
                            IsOK = false;
                            this.lblOK.Text = "";
                            this.txtHJCode.Text = "";//清空合件条码
                            this.txtHJCode.Text = obj.barcode;
                            if (ValidateFeatureCode(obj.barcode, productModel.FeatureIndex, featureCode))
                            {
                                foreach (ListViewItem item in lvMaterial.Items)
                                {
                                    item.SubItems[1].Text = "";//初始化状态为空
                                    item.SubItems[3].Text = "0";//初始化状态为空
                                    item.ForeColor = Color.Black;//初始化字体颜色为黑色
                                }
                                //记录扫描信息
                                RecordScanInfo();
                                IsHjScan = false;
                                this.Tip("请扫描零件条码");
                            }
                            else
                            {
                                IsHjScan = true;
                                this.Tip("合件不在此产品之列");
                            }
                        }
                        else//当为材料时
                        {
                            if (obj.len < 10)
                            {
                                this.Tip("请重新扫描");
                                return;
                            }
                            //D300SysUI.PlaySound(BaseVariable.ScanSound);
                            this.lblCurrentMaterialCode.Text = obj.barcode;
                            ValidateMaterialInfo(obj.barcode);//材料防错，对比特征码
                        }
                    }
                    else
                    {
                        this.Tip("材料条码信息不全");//提示
                    }
                }
            }
            catch (Exception ex)
            {
                this.Tip("扫描失败");//提示
                CLog.WriteErrLog("[FrmScan.ScanEvent]" + ex.Message);
            }
        }
        #endregion

        #region 选择产品事件
        /// <summary>
        /// 选择产品事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.frmSelect == null || this.frmSelect.IsDisposed)
                {
                    frmSelect = new FrmSelect(SelectType.ScanCradle, this);
                }
                else if (!this.frmSelect.IsDisposed)
                {
                    frmSelect.Dispose();
                    frmSelect = new FrmSelect(SelectType.ScanCradle, this);
                }
                Scanner.Disable();//禁用扫描
                frmSelect.ShowDialog();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.Select]" + ex.Message);
            }
        }
        #endregion

        #region 退出
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                HTJCSysPDA.FrmMain.DeleteFrmMainLoad FrmMainLoad = new FrmMain.DeleteFrmMainLoad(frmMain.LoadForm);
                FrmMainLoad.Invoke();
                this.Close();
                Scanner.Disable();
                this.Dispose();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.btnExit]" + ex.Message);
                this.Dispose();
            }
        }
        #endregion
        #endregion

        //方法
        #region 方法
        #region 加载产品信息
        /// <summary>
        /// 加载产品信息
        /// </summary>
        /// <param name="productCode"></param>
        public void LoadProductInfo(string productCode)
        {
            try
            {
                this.lvMaterial.Items.Clear();
                this.txtProductCode.Text = productCode;
                this.txtHJCode.Text = "";//清空合件条码
                this.lblCurrentMaterialCode.Text = "";//清空当前零件条码
                this.lblTip.Text = "";
                //获取当前产品信息表
                productModel = BaseVariable.ProductInfo;
                //获取产品的特征码
                featureCode = productModel.FeatureCode;
                //获取BOM表的信息
                if (!BaseVariable.NetworkStatus || !BaseVariable.ServerStatus)
                {
                    bomTable = lBomDAL.GetList(string.Format("ProductType='{0}' AND ProductCode = '{1}'  AND TraceType='{2}' AND FeatureCode  IS NOT NULL AND FeatureCode !=''", BaseVariable.DeviceEntity.ProductType, productCode, "扫描追溯")).Tables[0];
                }
                else
                {
                    bomTable = bomDAL.GetList(string.Format("ProductType='{0}' AND ProductCode = '{1}' AND TraceType='{2}' AND FeatureCode  IS NOT NULL AND FeatureCode !=''", BaseVariable.DeviceEntity.ProductType, productCode, "扫描追溯")).Tables[0];
                }
                //添加到ListView中
                if (bomTable != null && bomTable.Rows.Count > 0)
                {
                    int count = bomTable.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DataRow row = bomTable.Rows[i];
                        ListViewItem item = new ListViewItem(row["MaterialCode"].ToString());//材料条码
                        item.SubItems.Add("");
                        item.SubItems.Add(row["MaterialNum"].ToString());
                        item.SubItems.Add("0");
                        item.SubItems.Add(row["MaterialName"].ToString());
                        item.Tag = row["TID"].ToString();
                        if (i % 2 == 0)
                        {
                            item.BackColor = Color.Gainsboro;//偶数背景色淡灰色
                        }
                        else
                        {
                            item.BackColor = Color.Silver;//奇数背景色为银色
                        }
                        item.ForeColor = Color.Black;//字体颜色为黑色
                        this.lvMaterial.Items.Add(item);
                    }
                }
                IsHjScan = true;//扫描合件标示为true
                if (BaseVariable.NetworkStatus && BaseVariable.ServerStatus)
                {
                    GetMaterialInfo();//获取材料信息 
                }
                else
                {
                    IsAbleScan = true;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.loadProduct]" + ex.Message);
            }
        }
        #endregion

        #region 加载产品信息
        /// <summary>
        /// 加载产品信息
        /// </summary>
        /// <param name="productCode"></param>
        public void LoadProductInfo()
        {
            try
            {
                this.lvMaterial.Items.Clear();
                this.txtProductCode.Text = BaseVariable.ProductInfo.ProductCode;
                this.txtHJCode.Text = "";//清空合件条码
                this.lblCurrentMaterialCode.Text = "";//清空当前零件条码
                this.lblTip.Text = "";
                this.lblOK.Text = "";
                //获取当前产品信息表
                productModel = BaseVariable.ProductInfo;
                //获取产品的特征码
                featureCode = productModel.FeatureCode;
                //获取BOM表的信息
                /**
                 * 一次获取当前产品所有BOM信息
                 * 2014.11.30 By xudy
                 */
                string sql = string.Format("SELECT * FROM (SELECT b.*, m.tablename, m.fieldname FROM productinfo p, productbominfo b, materialfield m WHERE p.productcode = b.productcode AND p.producttype = b.producttype AND b.materialcode = m.materialcode ) t WHERE  productcode='{0}' AND tracetype in('扫描追溯','批次追溯');", BaseVariable.ProductInfo.ProductCode);
                DataTable table = null;
                if (!BaseVariable.NetworkStatus || !BaseVariable.ServerStatus)
                {
                    table = LocalDbDAL.GetDataTable(sql);
                }
                else
                {
                    table = CommonDAL.GetDataTable(sql);
                }
                HTMaterialTable = MaterialBomDAL.GetList(table);

                //添加到ListView中
                if (HTMaterialTable != null && HTMaterialTable.Count > 0)
                {
                    int index = 0;
                    foreach (DictionaryEntry ht in HTMaterialTable)
                    {
                        MaterialBomMDL bom = ht.Value as MaterialBomMDL;
                        if (bom.TraceType.ToString() == "扫描追溯")
                        {
                            ListViewItem item = new ListViewItem(bom.MaterialCode);//材料条码
                            item.SubItems.Add("");
                            item.SubItems.Add(bom.MaterialNum.ToString());
                            item.SubItems.Add("0");
                            item.SubItems.Add(bom.MaterialName.ToString());
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
                    IsHjScan = true;//扫描合件标示为true
                    if (BaseVariable.NetworkStatus && BaseVariable.ServerStatus)
                    {
                        GetMaterialInfo();//获取材料信息 
                    }
                    else
                    {
                        IsAbleScan = true;
                    }
                }
                else
                {
                    this.Tip("当前型号没有扫描追溯零件");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts."))
                {
                    this.Tip("服务器连接失败");
                }
                CLog.WriteErrLog("[FrmScan.loadProduct]" + ex.Message);
            }
        }
        #endregion

        #region 获取材料信息
        /// <summary>
        /// 获取材料信息
        /// </summary>
        public void GetMaterialInfo()
        {
            try
            {
                int MaterialCount = 0;
                if (HTMaterialTable.Count > 0)
                {
                    batchTable = GetMaterialBatchTable(ref MaterialCount);
                    if (batchTable.Rows.Count != MaterialCount)
                    {
                        this.Tip("材料条码信息不全");//提示
                        IsAbleScan = false;
                        return;
                    }
                    else
                    {
                        if (!IsAbleScan)
                        {
                            IsAbleScan = true;
                            this.Tip("材料条码信息通过");//提示 
                        }
                    }
                    BatchChangeTip();
                }

                #region 旧代码
                //string MaterialList = "";
                //if (RemoteMaterialHT.Count > 0)
                //{
                //    RemoteMaterialHT.Clear();
                //}
                //DataTable table = bomDAL.GetList(string.Format("ProductType='{0}' AND ProductCode = '{1}' AND TraceType='{2}'", BaseVariable.DeviceEntity.ProductType, this.txtProductCode.Text, "批次追溯")).Tables[0];
                //if (table != null)
                //{
                //    foreach (DataRow row in table.Rows)
                //    {
                //        ProductBomInfoMDL model = new ProductBomInfoMDL()
                //        {
                //            MaterialCode = row["MaterialCode"].ToString(),
                //            MaterialName = row["MaterialName"].ToString(),
                //            MaterialNum = int.Parse(row["MaterialNum"].ToString())
                //        };
                //        RemoteMaterialHT.Add(row["MaterialCode"].ToString(), model);
                //        MaterialList += "'" + row["MaterialCode"].ToString() + "',";
                //    }
                //    MaterialList = MaterialList.Substring(0, MaterialList.LastIndexOf(','));
                //    //从数据库获取当前批次材料信息
                //    batchTable = batchDAL.GetList(string.Format("MaterialCode IN({0})", MaterialList)).Tables[0];
                //    if (batchTable.Rows.Count != table.Rows.Count)
                //    {
                //        this.Tip("材料条码信息不全");//提示
                //        IsAbleScan = false;
                //        return;
                //    }
                //    else
                //    {
                //        if (!IsAbleScan)
                //        {
                //            IsAbleScan = true;
                //            this.Tip("材料条码信息通过");//提示 
                //        }
                //    }
                //    BatchChangeTip();
                //}
                #endregion
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.GetmaterialInfo]" + ex.Message);
            }
        }

        #region 获取批次信息
        /// <summary>
        /// 获取批次信息
        /// </summary>
        /// <param name="MaterialCount"></param>
        /// <returns></returns>
        private DataTable GetMaterialBatchTable(ref int MaterialCount)
        {
            string MaterialCodeList = "";
            foreach (DictionaryEntry Entry in HTMaterialTable)
            {
                MaterialBomMDL model = Entry.Value as MaterialBomMDL;
                if (model.TraceType == "批次追溯")
                {
                    MaterialCodeList += "'" + model.MaterialCode + "',";
                    MaterialCount++;
                }
            }
            MaterialCodeList = MaterialCodeList.Substring(0, MaterialCodeList.LastIndexOf(','));
            //从数据库获取当前批次材料信息
            DataTable table = batchDAL.GetList(string.Format("MaterialCode IN({0})", MaterialCodeList)).Tables[0];
            return table;
        } 
        #endregion
        #endregion

        #region 记录扫描信息
        /// <summary>
        /// 记录扫描信息
        /// </summary>
        private void RecordScanInfo()
        {
            try
            {
                if (IsHjScan)//合件扫描记录
                {
                    MaterialList = null;
                    MaterialList = HTMaterialTable;
                }
                else//材料扫描记录
                {
                    if (MaterialList.ContainsKey(materialCode))
                    {
                        MaterialBomMDL model = MaterialList[materialCode] as MaterialBomMDL;
                        model.BatchBarCode = this.lblCurrentMaterialCode.Text;
                        MaterialList.Remove(materialCode);
                        MaterialList.Add(materialCode, model);
                        model = null;
                    }
                }

                #region 旧代码
                //if (IsHjScan)//合件扫描记录
                //{
                //    #region 封装Model
                //    resultModel = new CradleResultMDL();
                //    resultModel.BarCode = this.txtHJCode.Text;
                //    resultModel.ProductCode = this.txtProductCode.Text;
                //    resultModel.UserID = BaseVariable.UserEntity.UserID;
                //    resultModel.StationID = BaseVariable.DeviceEntity.StationID;
                //    //resultModel.CreateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //    #endregion
                //}
                //else//材料扫描记录
                //{
                //    //字段表
                //    if (!BaseVariable.NetworkStatus || !BaseVariable.ServerStatus)
                //    {
                //        materialFieldModel = lMaterialFieldDAL.GetModel(string.Format("materialcode='{0}' and materialname='{1}'", materialCode, materialName));
                //    }
                //    else
                //    {
                //        materialFieldModel = materialFieldDAL.GetModel(string.Format("materialcode='{0}' and materialname='{1}'", materialCode, materialName));
                //    }

                //    //更改相关信息
                //    #region 对应更新字段
                //    switch (materialFieldModel.FieldName)
                //    {
                //        //前托架批次号
                //        case "frontbracketbatchno":
                //            resultModel.FrontBracketBatchNO = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //左前固定支撑架流水号
                //        case "leftfrontbracketbatchno":
                //            resultModel.LeftFrontBracketBatchNO = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //右前固定支撑架流水号
                //        case "rightfrontbracketbatchno":
                //            resultModel.RightFrontBracketBatchNO = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //稳定杆总成批次号
                //        case "stabilizerbarbatchno":
                //            resultModel.StabilizerbarBatchNO = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //稳定杆总成支撑座(9802839080)批次号
                //        case "stabilizerbarbracketbatchno":
                //            resultModel.StabilizerbarBracketBatchNO = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //螺栓（9676004780）批次号
                //        case "boltbatchno1":
                //            resultModel.BoltBatchNO1 = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //螺栓（9676013280）批次号
                //        case "boltbatchno2":
                //            resultModel.BoltBatchNO2 = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //螺钉（9672883880）批次号
                //        case "screwbatchno1":
                //            resultModel.ScrewBatchNo1 = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //螺母（9800621880）批次号
                //        case "nutbatchno1":
                //            resultModel.NutBatchNO1 = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //螺母（9809271180）批次号
                //        case "nutbatchno2":
                //            resultModel.NutBatchNO2 = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //左三角臂条码号
                //        case "lefttriangulararmcode":
                //            resultModel.LeftTriangularArmCode = this.lblCurrentMaterialCode.Text;
                //            break;
                //        //右三角臂条码号
                //        case "righttriangulararmcode":
                //            resultModel.RightTriangularArmCode = this.lblCurrentMaterialCode.Text;
                //            break;
                //    }
                //    #endregion
                //} 
                #endregion
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.RecordScanInfo]" + ex.Message);
            }
        }
        #endregion

        #region 比较特征码
        /// <summary>
        /// 比较特征码
        /// </summary>
        /// <param name="Str">待比较的字符串</param>
        /// <param name="featureIndex">校验位</param>
        /// <param name="featureCode">目标特征码</param>
        /// <returns></returns>
        private bool ValidateFeatureCode(string Str, string featureIndex, string featureCode)
        {
            //获取特征码
            string FCode = "";
            string[] code = featureIndex.Split(',');
            for (int i = 0; i < code.Length; i++)
            {
                int start = int.Parse(code[i].ToString()) - 1;
                FCode += Str.Substring(start, 1);
            }
            if (featureCode == FCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 材料防错验证
        /// <summary>
        /// 材料防错验证
        /// </summary>
        /// <param name="materialCode"></param>
        private void ValidateMaterialInfo(string code)
        {
            try
            {
                if (!IsOK)
                {
                    bool IsExist = false;//标记是否存在

                    foreach (DictionaryEntry Entry in MaterialList)
                    {
                        MaterialBomMDL model = Entry.Value as MaterialBomMDL;
                        bool rs = ValidateFeatureCode(code, model.FeatureIndex.ToString(), model.FeatureCode.ToString());//判断特征码
                        if (rs && model.TraceType.Equals("扫描追溯"))
                        {
                            materialCode = model.MaterialCode.ToString();//材料编码
                            //标记为√
                            foreach (ListViewItem item in this.lvMaterial.Items)
                            {
                                if (item.Text.Equals(materialCode))
                                {
                                    //materialCode = materialNo;//为全局材料编码赋值
                                    //materialName = item.SubItems[4].Text;//为全局材料名称赋值
                                    int num = int.Parse(item.SubItems[2].Text);//产品数量
                                    int scan = int.Parse(item.SubItems[3].Text);//扫描数量                                    
                                    bool meterialError = true;
                                    if ((scan + 1) == num)
                                    {
                                        item.SubItems[3].Text = (scan + 1).ToString();
                                        item.ForeColor = Color.Green;//当防错正常时字体为绿色
                                        item.SubItems[1].Text = "OK";//扫描次数刚好和产品数量相等时
                                        meterialError = false;
                                    }
                                    else if ((scan + 1) < num)
                                    {
                                        item.SubItems[3].Text = (scan + 1).ToString();
                                        item.ForeColor = Color.CornflowerBlue;//当防错正常时字体为浅蓝色
                                        item.SubItems[1].Text = "√";//扫描次数比产品数量小时
                                        meterialError = false;
                                    }
                                    else if ((scan + 1) > num)
                                    {
                                        meterialError = true;
                                        this.Tip("该条码扫描次数超出");//提示
                                    }
                                    //记录扫描信息
                                    if (!meterialError)
                                    {
                                        //记录扫描信息
                                        RecordScanInfo();
                                    }
                                    break;
                                }
                            }
                            IsExist = true;//标记存在为true
                            break;
                        }
                    }

                    #region 旧代码
                    //foreach (DataRow row in bomTable.Rows)
                    //{
                    //    bool rs = ValidateFeatureCode(code, row["FeatureIndex"].ToString(), row["FeatureCode"].ToString());//判断特征码
                    //    if (rs)
                    //    {
                    //        string materialNo = row["MaterialCode"].ToString();//材料编码
                    //        //标记为√
                    //        foreach (ListViewItem item in this.lvMaterial.Items)
                    //        {
                    //            if (item.Text.Equals(materialNo))
                    //            {
                    //                materialCode = materialNo;//为全局材料编码赋值
                    //                materialName = item.SubItems[4].Text;//为全局材料名称赋值
                    //                int num = int.Parse(item.SubItems[2].Text);//产品数量
                    //                int scan = int.Parse(item.SubItems[3].Text);//扫描数量                                    
                    //                bool meterialError = true;
                    //                if ((scan + 1) == num)
                    //                {
                    //                    item.SubItems[3].Text = (scan + 1).ToString();
                    //                    item.ForeColor = Color.Green;//当防错正常时字体为绿色
                    //                    item.SubItems[1].Text = "OK";//扫描次数刚好和产品数量相等时
                    //                    meterialError = false;
                    //                }
                    //                else if ((scan + 1) < num)
                    //                {
                    //                    item.SubItems[3].Text = (scan + 1).ToString();
                    //                    item.ForeColor = Color.CornflowerBlue;//当防错正常时字体为浅蓝色
                    //                    item.SubItems[1].Text = "√";//扫描次数比产品数量小时
                    //                    meterialError = false;
                    //                }
                    //                else if ((scan + 1) > num)
                    //                {
                    //                    meterialError = true;
                    //                    this.Tip("该条码扫描次数超出");//提示
                    //                }
                    //                //记录扫描信息
                    //                if (!meterialError)
                    //                {
                    //                    //记录扫描信息
                    //                    RecordScanInfo();
                    //                }
                    //                break;
                    //            }
                    //        }
                    //        IsExist = true;//标记存在为true
                    //        break;
                    //    }
                    //} 
                    #endregion
                    if (!IsExist)
                    {
                        this.Tip("合件不存在该材料");//提示不存在
                    }
                    int error = 0;
                    foreach (ListViewItem item in this.lvMaterial.Items)
                    {
                        if (item.SubItems[1].Text != "OK")
                        {
                            error++;
                        }
                    }
                    if (error == 0)
                    {
                        IsOK = true;
                        IsHjScan = true;
                        //更新到数据库
                        ScanResultToDb();
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.ValidateMaterialInfo]" + ex.Message);
            }
        }
        #endregion

        #region 扫描数据结果处理
        #region 扫描追溯
        private void ScanRecordToDb()
        {
            try
            {
                if (IsHjScan)//合件扫描记录
                {
                }
                else//材料扫描记录
                {

                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #region 防错追溯
        #region 防错追溯
        /// <summary>
        /// 防错追溯，将信息添加到数据库
        /// </summary>
        private void ScanResultToDb()
        {
            bool IsSave = false;
            try
            {
                if (MaterialList != null && MaterialList.Count > 0)
                {
                    bool rst = false;
                    if (!BaseVariable.NetworkStatus || !BaseVariable.ServerStatus)//离线状态
                    {
                        object IsExistLocal = LocalDbDAL.ExecuteScaler(string.Format("select tid from {0} where barcode='{1}' and productcode='{2}'", "cradleresult", this.txtHJCode.Text, this.txtProductCode.Text));
                        if (IsExistLocal != null && !IsExistLocal.ToString().Equals("0"))
                        {
                            long TID = long.Parse(IsExistLocal.ToString());
                            string sql = AssembleSqlCode(true, TID);
                            rst = LocalDbDAL.ExecuteSql(sql);//更新到本地数据库
                        }
                        else
                        {
                            string sql = AssembleSqlCode(false, null);
                            rst = LocalDbDAL.ExecuteSql(sql);//添加到本地数据库
                        }
                    }
                    else//在线状态
                    {
                        //添加批量追溯信息
                        GetBatchInfoToModel();

                        //同步到数据库：在没有同步到远程数据库时记录到本地数据库
                        #region 同步到数据库
                        rst = false;//更新到远程服务器数据库是否成功
                        object IsExistRemote = CommonDAL.ExecuteScaler(string.Format("select tid from {0} where barcode='{1}' and productcode='{2}'", "cradleresult", this.txtHJCode.Text, this.txtProductCode.Text));
                        if (IsExistRemote != null && !IsExistRemote.ToString().Equals("0"))
                        {
                            long TID = long.Parse(IsExistRemote.ToString());
                            string sql = AssembleSqlCode(true, TID);
                            rst = CommonDAL.ExecuteSql(sql);//更新到远程数据库
                        }
                        else
                        {
                            string sql = AssembleSqlCode(false, null);
                            rst = CommonDAL.ExecuteSql(sql);//添加到远程数据库
                        }
                        IsSave = rst;
                        //更新到本地数据库
                        //rst = false;
                        if (!rst)
                        {
                            object IsExistLocal = LocalDbDAL.ExecuteScaler(string.Format("select tid from {0} where barcode='{1}' and productcode='{2}'", "cradleresult", this.txtHJCode.Text, this.txtProductCode.Text));
                            if (IsExistLocal != null && !IsExistLocal.ToString().Equals("0"))
                            {
                                long TID = long.Parse(IsExistLocal.ToString());
                                string sql = AssembleSqlCode(true, TID);
                                rst = LocalDbDAL.ExecuteSql(sql);//更新到本地数据库
                            }
                            else
                            {
                                string sql = AssembleSqlCode(false, null);
                                rst = LocalDbDAL.ExecuteSql(sql);//添加到本地数据库
                            }
                            IsSave = rst;
                        }
                        //批次材料数量更新
                        foreach (DictionaryEntry item in MaterialList)// 遍历哈希表
                        {
                            MaterialBomMDL model = item.Value as MaterialBomMDL;
                            if (model.TraceType == "批次追溯")
                            {
                                string sql = string.Format("update batchno set stocknum=stocknum-{0} where materialcode='{1}'", model.MaterialNum, model.MaterialCode);
                                CommonDAL.ExecuteSql(sql);//更新数据 
                            }
                        }
                        #endregion
                        if (rst)
                        {
                            this.lblOK.Text = "OK";
                            this.lblOK.ForeColor = Color.Green;
                        }
                        else
                        {
                            this.lblOK.Text = "NG";
                            this.lblOK.ForeColor = Color.Red;
                        }
                        BatchChangeTip();//批次数量提示
                    }

                }
                else
                {
                    this.Tip("记录错误");
                }

                #region 旧代码
                //if (resultModel != null)
                //{
                //    bool rst = false;
                //    if (!BaseVariable.NetworkStatus || !BaseVariable.ServerStatus)//离线状态
                //    {
                //        resultModel.CreateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //        object IsExistLocal = lResultDAL.Exists(string.Format("barcode='{0}' and productcode='{1}'", this.txtHJCode.Text, this.txtProductCode.Text));
                //        if (IsExistLocal != null && !IsExistLocal.ToString().Equals("0"))
                //        {
                //            resultModel.TID = long.Parse(IsExistLocal.ToString());
                //            string sql = DataExistToDb(false);
                //            rst = lResultDAL.Update(sql, null);//存到本地数据库
                //        }
                //        else
                //        {
                //            rst = lResultDAL.Add(resultModel);//添加到本地数据库
                //        }
                //    }
                //    else//在线状态
                //    {
                //        //添加批量追溯信息
                //        GetBatchInfoToModel();

                //        //同步到数据库：在没有同步到远程数据库时记录到本地数据库
                //        #region 同步到数据库
                //        resultModel.CreateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //        rst = false;//更新到远程服务器数据库是否成功
                //        object IsExistRomote = resultDAL.Exists(string.Format("barcode='{0}' and productcode='{1}'", this.txtHJCode.Text, this.txtProductCode.Text));
                //        //更新到远程服务器数据库
                //        if (IsExistRomote != null && !IsExistRomote.ToString().Equals("0"))
                //        {
                //            resultModel.TID = long.Parse(IsExistRomote.ToString());
                //            resultModel.CreateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //            //封装更新字段
                //            string sql = DataExistToDb(true);
                //            //sql += string.Format("CreateTime='{0}',", resultModel.CreateTime);
                //            rst = resultDAL.Update(sql, null);//存到远程服务器数据库
                //        }
                //        else
                //        {
                //            rst = resultDAL.Add(resultModel);//添加到远程服务器数据库
                //        }
                //        //更新到本地数据库
                //        //rst = false;
                //        if (!rst)
                //        {
                //            object IsExistLocal = lResultDAL.Exists(string.Format("barcode='{0}' and productcode='{1}'", this.txtHJCode.Text, this.txtProductCode.Text));
                //            if (IsExistLocal != null && !IsExistLocal.ToString().Equals("0"))
                //            {
                //                resultModel.TID = long.Parse(IsExistLocal.ToString());
                //                string sql = DataExistToDb(true);
                //                rst = lResultDAL.Update(sql, null);//存到本地数据库
                //            }
                //            else
                //            {
                //                rst = lResultDAL.Add(resultModel);//添加到本地数据库
                //            }
                //        }
                //        //批次材料数量更新
                //        foreach (DictionaryEntry item in RemoteMaterialHT)// 遍历哈希表
                //        {
                //            string code = item.Key.ToString();
                //            ProductBomInfoMDL obj = item.Value as ProductBomInfoMDL;
                //            //var obj = item.Value;
                //            BatchNoMDL model = LocalMaterialHT[code] as BatchNoMDL;
                //            model.StockNum -= obj.MaterialNum;
                //            batchDAL.Update(model);//更新数据
                //        }
                //        #endregion
                //        if (rst)
                //        {
                //            this.lblOK.Text = "OK";
                //            this.lblOK.ForeColor = Color.Green;
                //        }
                //        else
                //        {
                //            this.lblOK.Text = "NG";
                //            this.lblOK.ForeColor = Color.Red;
                //        }
                //        BatchChangeTip();//批次数量提示
                //    }

                //} 
                #endregion
            }
            catch (Exception ex)
            {
                if (!IsSave)
                {
                    bool rst = false;
                    object IsExistLocal = LocalDbDAL.ExecuteScaler(string.Format("select tid from {0} where barcode='{1}' and productcode='{2}'", "cradleresult", this.txtHJCode.Text, this.txtProductCode.Text));
                    if (IsExistLocal != null && !IsExistLocal.ToString().Equals("0"))
                    {
                        long TID = long.Parse(IsExistLocal.ToString());
                        string sql = AssembleSqlCode(true, TID);
                        rst = LocalDbDAL.ExecuteSql(sql);//更新到本地数据库
                    }
                    else
                    {
                        string sql = AssembleSqlCode(false, null);
                        rst = LocalDbDAL.ExecuteSql(sql);//添加到本地数据库
                    }
                    if (rst)
                    {
                        this.lblOK.Text = "OK";
                        this.lblOK.ForeColor = Color.Green;
                    }
                    else
                    {
                        this.lblOK.Text = "NG";
                        this.lblOK.ForeColor = Color.Red;
                    }
                }
                CLog.WriteErrLog("[FrmScan.ScanResultToDB]" + ex.Message);
            }
        }
        #endregion

        #region 添加批量追溯信息
        /// <summary>
        /// 添加批量追溯信息
        /// </summary>
        private void GetBatchInfoToModel()
        {
            #region 添加批量追溯信息
            if (MaterialList != null && MaterialList.Count > 0)
            {
                int count = 0;
                batchTable = GetMaterialBatchTable(ref count);
                BatchNoMDL batchModel = null;
                MaterialBomMDL bomModel = null;
                foreach (DataRow row in batchTable.Rows)
                {
                    bomModel = null;
                    batchModel = batchDAL.DataRowToModel(row) as BatchNoMDL;
                    if (HTMaterialTable.Contains(batchModel.MaterialCode))
                    {
                        bomModel = MaterialList[batchModel.MaterialCode] as MaterialBomMDL;
                        bomModel.BatchBarCode = batchModel.BatchNo;
                        MaterialList.Remove(batchModel.MaterialCode);
                        MaterialList.Add(batchModel.MaterialCode, bomModel);
                    }
                    batchModel = null;
                }
            }
            #endregion

            #region 旧代码-添加批量追溯信息
            //if (RemoteMaterialHT != null && RemoteMaterialHT.Count > 0)
            //{
            //    LocalMaterialHT.Clear();
            //    foreach (DictionaryEntry item in RemoteMaterialHT)// 遍历哈希表
            //    {
            //        //从数据库获取当前批次材料信息
            //        BatchNoMDL model = batchDAL.GetModel(string.Format("MaterialCode='{0}'", item.Key.ToString()));
            //        LocalMaterialHT.Add(item.Key.ToString(), model);
            //        //获取更新的字段
            //        materialFieldModel = materialFieldDAL.GetModel(string.Format("materialcode='{0}'", item.Key.ToString()));
            //        //更新对应字段
            //        #region 更新对应字段
            //        if (materialFieldModel != null)
            //        {
            //            switch (materialFieldModel.FieldName)
            //            {
            //                //前托架批次号
            //                case "frontbracketbatchno":
            //                    resultModel.FrontBracketBatchNO = model.BatchNo;
            //                    break;
            //                //左前固定支撑架流水号
            //                case "leftfrontbracketbatchno":
            //                    resultModel.LeftFrontBracketBatchNO = model.BatchNo;
            //                    break;
            //                //右前固定支撑架流水号
            //                case "rightfrontbracketbatchno":
            //                    resultModel.RightFrontBracketBatchNO = model.BatchNo;
            //                    break;
            //                //稳定杆总成批次号
            //                case "stabilizerbarbatchno":
            //                    resultModel.StabilizerbarBatchNO = model.BatchNo;
            //                    break;
            //                //稳定杆总成支撑座(9802839080)批次号
            //                case "stabilizerbarbracketbatchno":
            //                    resultModel.StabilizerbarBracketBatchNO = model.BatchNo;
            //                    break;
            //                //螺栓（9676004780）批次号
            //                case "boltbatchno1":
            //                    resultModel.BoltBatchNO1 = model.BatchNo;
            //                    break;
            //                //螺栓（9676013280）批次号
            //                case "boltbatchno2":
            //                    resultModel.BoltBatchNO2 = model.BatchNo;
            //                    break;
            //                //螺钉（9672883880）批次号
            //                case "screwbatchno1":
            //                    resultModel.ScrewBatchNo1 = model.BatchNo;
            //                    break;
            //                //螺母（9800621880）批次号
            //                case "nutbatchno1":
            //                    resultModel.NutBatchNO1 = model.BatchNo;
            //                    break;
            //                //螺母（9809271180）批次号
            //                case "nutbatchno2":
            //                    resultModel.NutBatchNO2 = model.BatchNo;
            //                    break;
            //                //左三角臂条码号
            //                case "lefttriangulararmcode":
            //                    resultModel.LeftTriangularArmCode = model.BatchNo;
            //                    break;
            //                //右三角臂条码号
            //                case "righttriangulararmcode":
            //                    resultModel.RightTriangularArmCode = model.BatchNo;
            //                    break;
            //            }
            //        }
            //        #endregion
            //    }
            //}
            #endregion
        }
        #endregion

        #region 组装SQL语句
        /// <summary>
        /// 组装SQL语句
        /// </summary>
        /// <param name="IsExit"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        private string AssembleSqlCode(bool IsExit, long? tid)
        {
            string sql = "";
            if (IsExit)
            {
                sql += string.Format("update {0} set ", "cradleresult");
                #region 对应更新字段
                if (MaterialList != null && MaterialList.Count > 0)
                {
                    foreach (DictionaryEntry Entry in MaterialList)
                    {
                        MaterialBomMDL model = Entry.Value as MaterialBomMDL; 
                        if (!string.IsNullOrEmpty(model.BatchBarCode))
                        {
                            sql += string.Format("{0}='{1}',", model.FieldName, model.BatchBarCode); 
                        }
                    }
                }
                sql = sql.Substring(0, sql.LastIndexOf(','));
                sql += string.Format(" where tid={0}", tid);
            }
            else
            {
                string field = "";
                string values = "";
                #region 对应更新字段
                if (MaterialList != null && MaterialList.Count > 0)
                {
                    foreach (DictionaryEntry Entry in MaterialList)
                    {
                        MaterialBomMDL model = Entry.Value as MaterialBomMDL;
                        if (!string.IsNullOrEmpty(model.BatchBarCode))
                        {
                            field += model.FieldName + ",";
                            values += string.Format("'{0}',", model.BatchBarCode); 
                        }
                    }
                }
                field += "barcode,productcode,userid,stationid,createtime";
                values += string.Format("'{0}','{1}','{2}','{3}','{4}'", this.txtHJCode.Text, this.txtProductCode.Text, BaseVariable.UserEntity.UserID, BaseVariable.DeviceEntity.StationID, DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString()));
                sql += string.Format("insert into {0}({1}) values({2});", "cradleresult", field, values);
            }

            #region 旧代码
            //string sql = string.Format("SELECT * FROM materialfield WHERE materialcode in(SELECT materialcode FROM productbominfo WHERE producttype='{0}' AND productcode='{1}')", BaseVariable.DeviceEntity.ProductType, resultModel.ProductCode);
            //DataTable fieldTable = null;
            //if (IsRemote)
            //{
            //    fieldTable = CommonDAL.GetDataTable(sql);//远程获取
            //}
            //else
            //{
            //    fieldTable = LocalDbDAL.GetDataTable(sql);//本地获取
            //}
            //sql = "";
            //#region 对应更新字段
            //if (fieldTable != null && fieldTable.Rows.Count > 0)
            //{
            //    foreach (DataRow fieldRow in fieldTable.Rows)
            //    {
            //        string filed = fieldRow["FieldName"].ToString();
            //        #region 对应更新字段
            //        switch (filed)
            //        {
            //            //前托架批次号
            //            case "frontbracketbatchno":
            //                sql += string.Format("FrontBracketBatchNO='{0}',", resultModel.FrontBracketBatchNO);
            //                break;
            //            //左前固定支撑架流水号
            //            case "leftfrontbracketbatchno":
            //                sql += string.Format("LeftFrontBracketBatchNO='{0}',", resultModel.LeftFrontBracketBatchNO);
            //                break;
            //            //右前固定支撑架流水号
            //            case "rightfrontbracketbatchno":
            //                sql += string.Format("RightFrontBracketBatchNO='{0}',", resultModel.RightFrontBracketBatchNO);
            //                break;
            //            //稳定杆总成批次号
            //            case "stabilizerbarbatchno":
            //                sql += string.Format("StabilizerbarBatchNO='{0}',", resultModel.StabilizerbarBatchNO);
            //                break;
            //            //稳定杆总成支撑座(9802839080)批次号
            //            case "stabilizerbarbracketbatchno":
            //                sql += string.Format("StabilizerbarBracketBatchNO='{0}',", resultModel.StabilizerbarBracketBatchNO);
            //                break;
            //            //螺栓（9676004780）批次号
            //            case "boltbatchno1":
            //                sql += string.Format("BoltBatchNO1='{0}',", resultModel.BoltBatchNO1);
            //                break;
            //            //螺栓（9676013280）批次号
            //            case "boltbatchno2":
            //                sql += string.Format("BoltBatchNO2='{0}',", resultModel.BoltBatchNO2);
            //                break;
            //            //螺钉（9672883880）批次号
            //            case "screwbatchno1":
            //                sql += string.Format("ScrewBatchNo1='{0}',", resultModel.ScrewBatchNo1);
            //                break;
            //            //螺母（9800621880）批次号
            //            case "nutbatchno1":
            //                sql += string.Format("NutBatchNO1='{0}',", resultModel.NutBatchNO1);
            //                break;
            //            //螺母（9809271180）批次号
            //            case "nutbatchno2":
            //                sql += string.Format("NutBatchNO2='{0}',", resultModel.NutBatchNO2);
            //                break;
            //            //左三角臂条码号
            //            case "lefttriangulararmcode":
            //                sql += string.Format("LeftTriangularArmCode='{0}',", resultModel.LeftTriangularArmCode);
            //                break;
            //            //右三角臂条码号
            //            case "righttriangulararmcode":
            //                sql += string.Format("RightTriangularArmCode='{0}',", resultModel.RightTriangularArmCode);
            //                break;
            //        }
            //        #endregion
            //    }
            //} 
            #endregion
            return sql;
        }
                #endregion

        #region 批次更换提示
        /// <summary>
        /// 批次更换提示
        /// </summary>
        private void BatchChangeTip()
        {
            try
            {
                string sql = string.Format("SELECT * FROM batchno WHERE materialcode in(SELECT materialcode FROM productbominfo WHERE producttype='{0}' AND productcode='{1}' AND TraceType='{2}')", BaseVariable.DeviceEntity.ProductType, this.txtProductCode.Text, "批次追溯");
                DataTable batchTable = CommonDAL.GetDataTable(sql);
                DataRow[] rows = batchTable.Select("stocknum<1");
                if (rows.Length > 0)
                {
                    this.Tip("有零件已使用完,请更换");
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.BatchChangeTip]" + ex.Message);
            }
        }
        #endregion
        #endregion
        #endregion
        #endregion

        #region 错误提示信息
        /// <summary>
        /// 错误提示信息
        /// </summary>
        /// <param name="str"></param>
        private void Tip(string str)
        {
            this.lblTip.Text = str;//提示
            //this.lblCurrentMaterialCode.ForeColor = Color.Red;
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

        #region 复位操作
        /// <summary>
        /// 复位操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                IsHjScan = true;//合件扫描
                IsOK = false;
                this.Tip("扫描合件号");
                this.txtHJCode.Text = "";
                this.lblCurrentMaterialCode.Text = "";
                MaterialList = null;
                foreach (ListViewItem item in lvMaterial.Items)
                {
                    item.SubItems[1].Text = "";//初始化状态为空
                    item.SubItems[3].Text = "0";//初始化状态为空
                    item.ForeColor = Color.Black;//初始化字体颜色为黑色
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.btnReset]" + ex.Message);
            }
        }
        #endregion
        #endregion
        #endregion

        #region 窗体激活与未激活
        private void FrmScan_Activated(object sender, EventArgs e)
        {
            try
            {
                Scanner.Instance().OnScanedEvent += new Action<Scanner.CodeInfo>(scanner_OnScannerReaderEvent);//注册扫描事件
                Scanner.IsSound = BaseVariable.ScanIsSound;
                Scanner.IsShake = BaseVariable.ScanIsShake;
                Scanner.IsLED = BaseVariable.ScanIsLED;
                Scanner.Enable();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.StackTrace);
            }
        }
        private void FrmScan_Deactivate(object sender, EventArgs e)
        {
            try
            {
                Scanner.Instance().OnScanedEvent -= new Action<Scanner.CodeInfo>(scanner_OnScannerReaderEvent);//当活动窗体变为非活动窗体时发生的事件响应函数
                Scanner.Disable();//禁用扫描
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.StackTrace);
            }
        }
        #endregion
    }
}