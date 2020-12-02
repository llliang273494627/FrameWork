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
    /// 制动泵扫描追溯
    /// </summary>
    public partial class FrmScanBrakepupump : Form
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
            /// 实例化BrakepumpResultDAL类
            /// </summary>
            BrakepumpResultDAL resultDAL = new BrakepumpResultDAL();
            /// <summary>
            /// 实例化本地LBrakepumpResultDAL类
            /// </summary>
            LBrakepumpResultDAL lResultDAL = new LBrakepumpResultDAL();
            /// <summary>
            /// 定义扫描的BrakepumpResultMDL类
            /// </summary>
            BrakepumpResultMDL resultModel = null;
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
            string materialName = string.Empty;
            /// <summary>
            /// 是否可以扫描
            /// </summary>
            bool IsAbleScan = false;
            /// <summary>
            /// 本地材料列表
            /// </summary>
            Hashtable LocalMaterialHT = new Hashtable();
            /// <summary>
            /// 远程服务器材料列表
            /// </summary>
            Hashtable RemoteMaterialHT = new Hashtable();
            public FrmMain frmMain = null;
            #endregion

            #region 窗体初始化
            public FrmScanBrakepupump()
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
                                    MessageBox.Show("合件不在此产品之列");
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
                        frmSelect = new FrmSelect(SelectType.ScanBrakepupump,this);
                    }
                    else if (!this.frmSelect.IsDisposed)
                    {
                        frmSelect.Dispose();
                        frmSelect = new FrmSelect(SelectType.ScanBrakepupump,this);
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
                    if (!BaseVariable.NetworkStatus || !BaseVariable.ServerStatus)
                    {
                        bomTable = lBomDAL.GetList(string.Format("ProductType='{0}' AND ProductCode = '{1}'  AND TraceType='{2}' AND FeatureCode  IS NOT NULL AND FeatureCode !=''", BaseVariable.DeviceEntity.ProductType, BaseVariable.ProductInfo.ProductCode, "扫描追溯")).Tables[0];
                    }
                    else
                    {
                        bomTable = bomDAL.GetList(string.Format("ProductType='{0}' AND ProductCode = '{1}' AND TraceType='{2}' AND FeatureCode  IS NOT NULL AND FeatureCode !=''", BaseVariable.DeviceEntity.ProductType, BaseVariable.ProductInfo.ProductCode, "扫描追溯")).Tables[0];
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
                    string MaterialList = "";
                    if (RemoteMaterialHT.Count > 0)
                    {
                        RemoteMaterialHT.Clear();
                    }
                    DataTable table = bomDAL.GetList(string.Format("ProductType='{0}' AND ProductCode = '{1}' AND TraceType='{2}'", BaseVariable.DeviceEntity.ProductType, this.txtProductCode.Text,"批次追溯")).Tables[0];
                    if (table != null)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            ProductBomInfoMDL model = new ProductBomInfoMDL()
                            {
                                MaterialCode = row["MaterialCode"].ToString(),
                                MaterialName = row["MaterialName"].ToString(),
                                MaterialNum = int.Parse(row["MaterialNum"].ToString())
                            };
                            RemoteMaterialHT.Add(row["MaterialCode"].ToString(), model);
                            MaterialList += "'" + row["MaterialCode"].ToString() + "',";
                        }
                        MaterialList = MaterialList.Substring(0, MaterialList.LastIndexOf(','));
                        //从数据库获取当前批次材料信息
                        batchTable = batchDAL.GetList(string.Format("MaterialCode IN({0})", MaterialList)).Tables[0];
                        if (batchTable.Rows.Count != table.Rows.Count)
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
                }
                catch (Exception ex)
                {
                    CLog.WriteErrLog("[FrmScan.GetmaterialInfo]" + ex.Message);
                }
            }
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
                        #region 封装Model
                        resultModel = new BrakepumpResultMDL();
                        resultModel.barcode = this.txtHJCode.Text;
                        resultModel.productcode = this.txtProductCode.Text;
                        resultModel.userid = BaseVariable.UserEntity.UserID;
                        resultModel.stationid = BaseVariable.DeviceEntity.StationID;
                        //resultModel.CreateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        #endregion
                    }
                    else//材料扫描记录
                    {
                        //字段表
                        if (!BaseVariable.NetworkStatus || !BaseVariable.ServerStatus)
                        {
                            materialFieldModel = lMaterialFieldDAL.GetModel(string.Format("materialcode='{0}' and materialname='{1}'", materialCode, materialName)); 
                        }
                        else
	                    {
                            materialFieldModel = materialFieldDAL.GetModel(string.Format("materialcode='{0}' and materialname='{1}'", materialCode, materialName)); 
	                    }

                        //更改相关信息
                        #region 对应更新字段
                        switch (materialFieldModel.FieldName)
                        {
                            //制动泵编码
                            case "brakepumpcode":
                                resultModel.brakepumpcode = this.lblCurrentMaterialCode.Text;
                                break;
                            //密封垫批次号
                            case "gasketbatchno":
                                resultModel.gasketbatchno = this.lblCurrentMaterialCode.Text;
                                break;
                            //六角(法兰面)螺母
                            case "hexagonalnutbatchno":
                                resultModel.hexagonalnutbatchno = this.lblCurrentMaterialCode.Text;
                                break;
                            //压力传感器批次号
                            case "pressuresensorbatchno":
                                resultModel.pressuresensorbatchno = this.lblCurrentMaterialCode.Text;
                                break;
                            //消音器(制动泵隔音垫)
                            case "silencerbatchno":
                                resultModel.silencerbatchno = this.lblCurrentMaterialCode.Text;
                                break;
                            //结合管(制动连接管)
                            case "connectingpipe":
                                resultModel.connectingpipe = this.lblCurrentMaterialCode.Text;
                                break;
                            //助力器制动泵支架
                            case "boosterbrakepumpbracket":
                                resultModel.boosterbrakepumpbracket = this.lblCurrentMaterialCode.Text;
                                break;
                        }
                        #endregion
                    }
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
                        foreach (DataRow row in bomTable.Rows)
                        {
                            bool rs = ValidateFeatureCode(code, row["FeatureIndex"].ToString(), row["FeatureCode"].ToString());//判断特征码
                            if (rs)
                            {
                                string materialNo = row["MaterialCode"].ToString();//材料编码
                                //标记为√
                                foreach (ListViewItem item in this.lvMaterial.Items)
                                {
                                    if (item.Text.Equals(materialNo))
                                    {
                                        materialCode = materialNo;//为全局材料编码赋值
                                        materialName = item.SubItems[4].Text;//为全局材料名称赋值
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
                            #region 封装Model
                            resultModel = new BrakepumpResultMDL();
                            resultModel.barcode = this.txtHJCode.Text;
                            resultModel.productcode = this.txtProductCode.Text;
                            resultModel.userid = BaseVariable.UserEntity.UserID;
                            resultModel.stationid = BaseVariable.DeviceEntity.StationID;
                            resultModel.createtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            bool rst = resultDAL.Add(resultModel);//添加到远程服务器数据库
                            if (!rst)
                            {
                                bool rs = lResultDAL.Add(resultModel);//添加到本地数据库
                            }
                            #endregion
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
                    try
                    {
                        if (resultModel != null)
                        {
                            bool rst = false;
                            if (!BaseVariable.NetworkStatus || !BaseVariable.ServerStatus)//离线状态
                            {
                                resultModel.createtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                BrakepumpResultMDL IsExistLocal = lResultDAL.GetModel(string.Format("barcode='{0}' and productcode='{1}'", this.txtHJCode.Text, this.txtProductCode.Text));
                                if (IsExistLocal != null && !IsExistLocal.tid.ToString().Equals("0"))
                                {
                                    resultModel.tid = IsExistLocal.tid;
                                    string sql = DataExistToDb(false);
                                    rst = LocalDbDAL.ExecuteSql(sql);//存到本地数据库
                                }
                                else
                                {
                                    rst = lResultDAL.Add(resultModel);//添加到本地数据库
                                }
                            }
                            else//在线状态
                            {
                                //添加批量追溯信息
                                GetBatchInfoToModel();

                                //同步到数据库：在没有同步到远程数据库时记录到本地数据库
                                #region 同步到数据库
                                resultModel.createtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                rst = false;//更新到远程服务器数据库是否成功
                                BrakepumpResultMDL IsExistRomote = resultDAL.GetModel(string.Format("barcode='{0}' and productcode='{1}'", this.txtHJCode.Text, this.txtProductCode.Text));
                                //更新到远程服务器数据库
                                if (IsExistRomote != null && !IsExistRomote.tid.ToString().Equals("0"))
                                {
                                    resultModel.tid = IsExistRomote.tid;
                                    resultModel.createtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    //封装更新字段
                                    string sql = DataExistToDb(true);
                                    //sql += string.Format("CreateTime='{0}',", resultModel.CreateTime);
                                    rst = CommonDAL.ExecuteSql(sql, null);//存到远程服务器数据库
                                }
                                else
                                {
                                    rst = resultDAL.Add(resultModel);//添加到远程服务器数据库
                                }
                                //更新到本地数据库
                                //rst = false;
                                if (!rst)
                                {
                                    BrakepumpResultMDL IsExistLocal = lResultDAL.GetModel(string.Format("barcode='{0}' and productcode='{1}'", this.txtHJCode.Text, this.txtProductCode.Text));
                                    if (IsExistLocal != null && !IsExistLocal.tid.ToString().Equals("0"))
                                    {
                                        resultModel.tid = IsExistLocal.tid;
                                        string sql = DataExistToDb(false);
                                        rst = LocalDbDAL.ExecuteSql(sql);//存到本地数据库
                                    }
                                    else
                                    {
                                        rst = lResultDAL.Add(resultModel);//添加到本地数据库
                                    }
                                }
                                //批次材料数量更新
                                foreach (DictionaryEntry item in RemoteMaterialHT)// 遍历哈希表
                                {
                                    string code = item.Key.ToString();
                                    ProductBomInfoMDL obj = item.Value as ProductBomInfoMDL;
                                    //var obj = item.Value;
                                    BatchNoMDL model = LocalMaterialHT[code] as BatchNoMDL;
                                    model.StockNum -= obj.MaterialNum;
                                    batchDAL.Update(model);//更新数据
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
                    }
                    catch (Exception ex)
                    {
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
                    if (RemoteMaterialHT != null && RemoteMaterialHT.Count > 0)
                    {
                        LocalMaterialHT.Clear();
                        foreach (DictionaryEntry item in RemoteMaterialHT)// 遍历哈希表
                        {
                            //从数据库获取当前批次材料信息
                            BatchNoMDL model = batchDAL.GetModel(string.Format("MaterialCode='{0}'", item.Key.ToString()));
                            LocalMaterialHT.Add(item.Key.ToString(), model);
                            //获取更新的字段
                            materialFieldModel = materialFieldDAL.GetModel(string.Format("materialcode='{0}'", item.Key.ToString()));
                            //更新对应字段
                            #region 更新对应字段
                            if (materialFieldModel != null)
                            {
                                switch (materialFieldModel.FieldName)
                                {
                                    //制动泵编码
                                    case "brakepumpcode":
                                        resultModel.brakepumpcode = model.BatchNo;
                                        break;
                                    //密封垫批次号
                                    case "gasketbatchno":
                                        resultModel.gasketbatchno = model.BatchNo;
                                        break;
                                    //六角(法兰面)螺母
                                    case "hexagonalnutbatchno":
                                        resultModel.hexagonalnutbatchno = model.BatchNo;
                                        break;
                                    //压力传感器批次号
                                    case "pressuresensorbatchno":
                                        resultModel.pressuresensorbatchno = model.BatchNo;
                                        break;
                                    //消音器(制动泵隔音垫)
                                    case "silencerbatchno":
                                        resultModel.silencerbatchno = model.BatchNo;
                                        break;
                                    //结合管(制动连接管)
                                    case "connectingpipe":
                                        resultModel.connectingpipe = model.BatchNo;
                                        break;
                                    //助力器制动泵支架
                                    case "boosterbrakepumpbracket":
                                        resultModel.boosterbrakepumpbracket = model.BatchNo;
                                        break;
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion
                }
                #endregion

                #region 封装更新字段
                /// <summary>
                /// 封装更新字段
                /// </summary>
                /// <param name="IsRemote"></param>
                /// <returns></returns>
                private string DataExistToDb(bool IsRemote)
                {
                    string sql = string.Format("SELECT * FROM materialfield WHERE materialcode in(SELECT materialcode FROM productbominfo WHERE producttype='{0}' AND productcode='{1}')", BaseVariable.DeviceEntity.ProductType, resultModel.productcode);
                    DataTable fieldTable = null;
                    if (IsRemote)
                    {
                        fieldTable = CommonDAL.GetDataTable(sql);//远程获取
                    }
                    else
                    {
                        fieldTable = LocalDbDAL.GetDataTable(sql);//本地获取
                    }
                    sql = "";
                    #region 对应更新字段
                    if (fieldTable != null && fieldTable.Rows.Count > 0)
                    {
                        foreach (DataRow fieldRow in fieldTable.Rows)
                        {
                            string filed = fieldRow["FieldName"].ToString();
                            #region 对应更新字段
                            switch (filed)
                            {
                                //制动泵编码
                                case "brakepumpcode":
                                    sql += string.Format("brakepumpcode='{0}',", resultModel.brakepumpcode);
                                    break;
                                //密封垫批次号
                                case "gasketbatchno":
                                    sql += string.Format("gasketbatchno='{0}',", resultModel.gasketbatchno);
                                    break;
                                //六角(法兰面)螺母
                                case "hexagonalnutbatchno":
                                    sql += string.Format("hexagonalnutbatchno='{0}',", resultModel.hexagonalnutbatchno);
                                    break;
                                //压力传感器批次号
                                case "pressuresensorbatchno":
                                    sql += string.Format("pressuresensorbatchno='{0}',", resultModel.pressuresensorbatchno);
                                    break;
                                //消音器(制动泵隔音垫)
                                case "silencerbatchno":
                                    sql += string.Format("silencerbatchno='{0}',", resultModel.silencerbatchno);
                                    break;
                                //结合管(制动连接管)
                                case "connectingpipe":
                                    sql += string.Format("connectingpipe='{0}',", resultModel.connectingpipe);
                                    break;
                                //助力器制动泵支架
                                case "boosterbrakepumpbracket":
                                    sql += string.Format("boosterbrakepumpbracket='{0}',", resultModel.boosterbrakepumpbracket);
                                    break;
                            }
                            #endregion
                        }
                    }
                    #endregion
                    sql = sql.Substring(0, sql.LastIndexOf(','));
                    sql += string.Format(" where tid={0}", resultModel.tid);
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
                        string sql = string.Format("SELECT * FROM batchno WHERE materialcode in(SELECT materialcode FROM productbominfo WHERE producttype='{0}' AND productcode='{1}' AND TraceType='{2}')", BaseVariable.DeviceEntity.ProductType,this.txtProductCode.Text, "批次追溯");
                        DataTable batchTable = CommonDAL.GetDataTable(sql);
                        DataRow[] rows = batchTable.Select("stocknum<1");
                        if (rows.Length>0)
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
                    resultModel = null;
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