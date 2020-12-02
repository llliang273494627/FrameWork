using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using COM;
using DAL;
using MDL;
using Intermec.DataCollection;
using XY.DataCollect.Intermec;
using XY.Util;
using System.Diagnostics;

namespace HTJCSys.PDA
{
    // 合件:7AJCM0F703528
    /// <summary>
    /// T9摇篮线扫描追溯
    /// </summary>
    public partial class FrmScan : Form
    {
        //初始化
        #region 初始化
        #region 定义的变量
        /// 实例化LProductBomInfoDAL类
        /// </summary>
        LProductBomInfoDAL lBomDAL = new LProductBomInfoDAL();
        /// <summary>
        /// 定义当前选择产品实体类
        /// </summary>
        ProductInfoMDL productModel = null;
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
        //MaterialFieldMDL materialFieldModel = null;
        /// <summary>
        /// 实例化LStockInfoDAL类
        /// </summary>
        LStockInfoDAL LStockDAL = new LStockInfoDAL();
        /// <summary>
        /// 定义当前合件批次追溯材料数据表
        /// </summary>
        //DataTable batchTable = null;

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

        public FrmMain frmMain = null;
        /// <summary>
        /// 当前完成的个数
        /// </summary>
        int CurrentCount = 0;
        /// <summary>
        /// 是否验证扫描的条码
        /// </summary>
        bool IsValidateBarcode = true;
        /// <summary>
        /// 开始操作时间
        /// </summary>
        //DateTime BeginTime = new DateTime();
        /// <summary>
        /// 时间间隔
        /// </summary>
        //TimeSpan timeSpan = new TimeSpan();
        string ProductType = string.Empty;

        /******************20150319 http******************/
        /// <summary>
        /// Request请求追溯信息数据字典集合：RequestParam
        /// </summary>
        Dictionary<string, string> RequestParam = new Dictionary<string, string>();

        /******************end******************/

        /// <summary>
        /// 扫描时间
        /// </summary>
        private DateTime ScannerTime = DateTime.Now;

        Stopwatch watch = new Stopwatch();

        /// <summary>
        /// The currnet scan type
        /// 0:normal;1:in
        /// </summary>
        int CurrnetScanType = 0;
        #endregion

        #region 窗体初始化
        public FrmScan()
        {
            InitializeComponent();
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
                this.lblTitle.Text = "扫描追溯--" + BaseVariable.DeviceEntity.ProductType;
                XmlHelper xml = new XmlHelper();
                IsValidateBarcode = xml.SelectValue("/Root/Sys/ValidateBarcode") == "1" ? true : false;
                CurrentCount = int.Parse(xml.SelectValue("/Root/User/CurrnetCount"));
                CurrnetScanType = int.Parse(xml.SelectValue("/Root/User/CurrnetScanType"));
                SetCurrnetScanType(CurrnetScanType);
                this.lblCurrentCount.Text = CurrentCount.ToString();
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

        #region 窗体关闭
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmScan_Closed(object sender, EventArgs e)
        {
            Scanner.Disable();
        }
        #endregion

        #region 扫描事件
        /// <summary>
        /// 扫描事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        void scanner_OnScannerReaderEvent(object obj, BarcodeReadEventArgs args)
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
                    if (Opt.FeatureCodeList == null || Opt.FeatureCodeList.Count < 1)
                    {
                        this.Tip("加载数据失败");
                        Audio.SoundTip(0);//错误提示音
                        return;
                    }
                    if (string.IsNullOrEmpty(args.strDataBuffer) || args.strDataBuffer.Length == 0)
                    {
                        this.Tip("扫描的条码错误");
                        Audio.SoundTip(0);//错误提示音
                        return;
                    }
                    if (this.IsOK && this.IsHjScan)
                    {
                        watch.Reset();
                        watch.Start();
                    }
                    doCommonScan(args.strDataBuffer);
                }
            }
            catch (Exception ex)
            {
                this.Tip("扫描失败");//提示
                CLog.WriteErrLog("[FrmScan.ScanEvent]" + ex.Message);
            }
        }
        #endregion

        #region 按钮事件-复位操作
        /// <summary>
        /// 按钮事件-复位操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                watch.Reset();
                watch.Stop();
                IsHjScan = true;//合件扫描
                IsOK = true;
                this.Tip("扫描合件条码");
                this.lblHJCode.Text = "";
                this.lblOK.Text = "";
                this.lblScanCode.Text = "";
                RequestParam.Clear();
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

        #region 按钮事件-计数
        /// <summary>
        /// 按钮事件-计数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCount_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblCurrentCount.Text = "0";//计数清零
                CurrentCount = 0;
                XmlHelper xml = new XmlHelper();
                xml.UpdateInnerText("/Root/User/CurrnetCount", "0");
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.btnReset]" + ex.Message);
            }
        }
        #endregion

        #region 按钮事件-退出
        /// <summary>
        /// 按钮事件-退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                watch.Stop();
                XmlHelper xml = new XmlHelper();
                xml.UpdateInnerText("/Root/User/CurrnetCount", CurrentCount.ToString());
                xml.UpdateInnerText("/Root/User/CurrnetScanType", CurrnetScanType.ToString());
                Scanner.Disable();
                this.Close();
                //HTJCSys.PDA.FrmMain.DeleteFrmMainLoad FrmMainLoad = new FrmMain.DeleteFrmMainLoad(frmMain.LoadForm);
                //FrmMainLoad.Invoke();
                HTJCSys.PDA.FrmMain.DeleteDataUpload DataUpload = new FrmMain.DeleteDataUpload(frmMain.TipDataUpload);
                DataUpload.Invoke();            
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

        #region 通用扫描方法
        /// <summary>
        /// 通用扫描方法
        /// </summary>
        /// <param name="obj"></param>
        private void doCommonScan(string barcode)
        {
            try
            {
                this.lblScanCode.Text = "";//清空提示信息
                this.lblScanCode.ForeColor = Color.Navy;

                //判断是合件条码还是材料条码
                if (IsHjScan)//当为合件时
                {
                    RequestParam.Clear();//清除数据

                    this.lblScanCode.Text = barcode;
                    #region 合件

                    bool isNew = false;//新产品标识

                    #region 判断合件条码长度
                    bool CheckBitRST = Opt.HJValidate(barcode);
                    //校验位判断
                    if (!CheckBitRST)
                    {
                        this.Tip("合件条码长度不符合!");
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
                        this.Tip("合件条码校验位错误!");
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
                            item.SubItems[1].Text = "";//初始化状态为空
                            item.SubItems[3].Text = "0";//初始化状态为空
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

                            this.lblTitle.Text = "扫描-" + this.productModel.ProductName;
                            this.lblProductCode.Text = this.productModel.ProductCode;
                        }
                        else
                        {
                            //扫描合件的特征码不存在
                            IsHjScan = true;
                            this.Tip("合件条码不符,请重新扫描合件");
                            Audio.SoundTip(0);//错误提示音
                            return;
                        }
                    }
                    #endregion

                    #region //判断合件是否存在
                    if (IsValidateBarcode)//if (IsValidateBarcode && CurrnetScanType==1)
                    {
                        if (ValidateScanIsExist(1, barcode, ""))
                        {
                            Tip("当前合件已存在");
                            Audio.SoundTip(0);//错误提示音
                            return;
                        }
                    }
                    #endregion

                    this.lblHJCode.Text = barcode;
                    this.lblOK.Text = "";

                    #region //判断是否有子零件
                    if (CurrnetScanType==0)
                    {
                        #region //判断是否为新的产品
                        if (isNew || this.lvMaterial.Items == null || this.lvMaterial.Items.Count == 0)
                        {
                            InitListView();//加载子零件编码列表
                        }
                        #endregion
                    }
                    else
                    {
                        IsOK = true;
                        IsHjScan = true;
                        //更新到数据库
                        bool ret = ScanResultToDb();
                        if (ret)
                        {
                            Audio.SoundTip(2);
                        }
                        else
                        {
                            Audio.SoundTip(0);//错误提示音
                        }
                        return;
                    }
                    #endregion

                    if (!this.productModel.HaveSub)
                    {
                        IsOK = true;
                        IsHjScan = true;
                        Audio.SoundTip(0);//错误提示音
                        this.Tip("当前合件没有子零件");
                        return;
                    }

                    //记录扫描信息
                    RecordScanInfo();
                    IsOK = false;
                    IsHjScan = false;
                    this.Tip("请扫描子零件条码");
                    #endregion

                    //BatchTip();//批次信息提醒
                }
                else
                {
                    //当为子零件时
                    barcode = barcode.Replace("<cr><lf>", "").Replace("\r", "").Replace("\n", "").Replace("]C1", "");//获取条码/二维码,过滤回车换行
                    this.lblScanCode.Text = barcode;
                    ValidateMaterialInfo(barcode);//材料防错，对比特征码
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("扫描条码," + ex.Message);
            }
        }
        #endregion

        #region 获取扫描追溯BOM表的信息
        /// <summary>
        /// 获取扫描追溯BOM表的信息
        /// </summary>
        private void InitListView()
        {
            this.lvMaterial.Items.Clear();

            string sql = string.Format("SELECT p.*,m.fieldname FROM `productbominfo` p INNER JOIN materialfield m ON p.materialcode=m.materialcode WHERE producttype='{0}' AND productcode='{1}' AND tracetype IN({2})", BaseVariable.DeviceEntity.ProductType, this.productModel.ProductCode, "'扫描追溯'");
            DataTable table = LocalDbDAL.GetDataTable(sql);
            if (table!=null && table.Rows.Count>0)
            {
                int index = 0;
                foreach (DataRow row in table.Rows)
                {
                    ListViewItem item = new ListViewItem(row["materialcode"].ToString());//材料条码
                    item.SubItems.Add("");
                    item.SubItems.Add(row["materialnum"].ToString());
                    item.SubItems.Add("0");
                    item.SubItems.Add(row["materialname"].ToString());
                    item.SubItems.Add(row["featurecode"].ToString());//特征码
                    item.SubItems.Add(row["featureindex"].ToString());//特征位
                    item.SubItems.Add(row["fieldname"].ToString());//字段民称
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
                IsHjScan = true;//扫描合件标示为true
            }
            else
            {
                this.Tip("当前型号没有扫描追溯零件");
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
                    RequestParam.Add(materialCode, this.lblScanCode.Text);
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.RecordScanInfo]" + ex.Message);
            }
        }
        #endregion

        #region 材料防错验证-有特征码
        /// <summary>
        /// 材料防错验证-有特征码
        /// </summary>
        /// <param name="code"></param>
        private void ValidateMaterialInfo(string code)
        {
            Stopwatch validateWatch = new Stopwatch();
            try
            {
                if (!IsOK)
                {
                    validateWatch.Start();

                    bool IsExist = false;//标记是否存在
                    //标记为√
                    foreach (ListViewItem item in this.lvMaterial.Items)
                    {
                        bool meterialError = true;
                        materialCode = item.Text.ToString();//当前的零件编码
                        string FeatureCode = item.SubItems[5].Text;//特征码
                        string FeatureIndex = item.SubItems[6].Text;//特征位
                        bool flag = false;

                        if (FeatureCode == null || FeatureCode.Trim() == "")
                        {
                            if (code.Length < materialCode.Length)
                            {
                                meterialError = true;
                                continue;
                            }
                            string tmpCode = code.Substring(0, materialCode.Length);
                            flag = tmpCode == materialCode;//判断特征码
                        }
                        else
                        {

                            if (code.Length < FeatureCode.Length)
                            {
                                meterialError = true;
                                continue;
                            }

                            flag = Opt.ValidateFeatureCode(code, FeatureIndex, FeatureCode);//判断特征码
                        }
                        if (flag)
                        {
                            //判断零件是否存在
                            #region 判断合件是否存在
                            if (IsValidateBarcode)
                            {
                                string FieldName = item.SubItems[7].Text;
                                if (ValidateScanIsExist(2, code, FieldName))
                                {
                                    Tip("当前零件已使用过");
                                    Audio.SoundTip(0);//错误提示音
                                    return;
                                }
                            }
                            #endregion
                            int num = int.Parse(item.SubItems[2].Text);//产品数量
                            int scan = int.Parse(item.SubItems[3].Text);//扫描数量 

                            if ((scan + 1) == num)
                            {
                                item.SubItems[3].Text = (scan + 1).ToString();
                                item.ForeColor = Color.Green;//当防错正常时字体为绿色
                                item.SubItems[1].Text = "OK";//扫描次数刚好和产品数量相等时
                                meterialError = false;
                                Audio.SoundTip(1);//正确提示音
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
                                Audio.SoundTip(0);//错误提示音
                            }
                            //记录扫描信息
                            if (!meterialError)
                            {
                                //记录扫描信息
                                RecordScanInfo();
                            }
                            IsExist = true;//标记存在为true
                            break;
                        }
                    }

                    if (!IsExist)
                    {
                        this.Tip("合件不存在该条码的零件");//提示不存在
                        Audio.SoundTip(0);//错误提示音
                        return;
                    }

                    this.WirteTimeSpanLog(new TimeSpan(0, 0, 0, 0, (int)validateWatch.ElapsedMilliseconds), LogType.SC);
                    validateWatch.Stop();

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
                        bool ret = ScanResultToDb();
                        if (ret)
                        {
                            Audio.SoundTip(2);
                        }
                        else
                        {
                            Audio.SoundTip(0);//错误提示音
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.ValidateMaterialInfo]" + ex.Message);
            }
        }
        #endregion

        #region 获取当前条码是否存在---改造
        /// <summary>
        /// 获取当前条码是否存在
        /// 1.合件号；2.零件号(是一一追溯的零件)
        /// </summary>
        /// <param name="type">1：合件，2：零件</param>
        /// <param name="barcode">要验证的条码</param>
        /// <param name="materialfiled">字段名</param>
        public bool ValidateScanIsExist(int Type, string BarCode, string Filed)
        {
            Stopwatch existWatch = new Stopwatch();
            try
            {
                /*
                 * 人物：xudy
                 * 时间：2015-01-18
                 * 内容：修改了条件，讲userid、barcode换为tid
                 */
                if (Opt.GlobalNetStatus())//从服务器获取数据
                {
                    existWatch.Start();
                    //string requestUrl = BaseVariable.RequestURL + "Result.ashx";
                    //Dictionary<string, object> dict = new Dictionary<string, object>();
                    //dict.Add("do", "validate");
                    //dict.Add("Type", Type);
                    //dict.Add("TableName", BaseVariable.ResultTableName);
                    //dict.Add("BarCode", BarCode);
                    //dict.Add("ProductCode", this.productModel.ProductCode);
                    //dict.Add("Filed", Filed);

                    //string str = Http.POST(requestUrl, dict);
                    //var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
                    //ReturnInfo ReturnData = (ReturnInfo)obj;
                    //if (ReturnData != null && ReturnData.Code == "1")
                    //{
                    //    return true;
                    //}

                    return ResultDAL.Validate(BaseVariable.ResultTableName, BarCode, this.productModel.ProductCode, Type, Filed);
                }
                else//从本地获取数据
                {
                    string sql = "";
                    switch (Type)
                    {
                        case 1://合件
                            sql = string.Format("select tid from {0} where barcode='{1}' and productcode='{2}'", BaseVariable.ResultTableName, BarCode, this.productModel.ProductCode);
                            break;
                        case 2://子件
                            sql = string.Format("select tid from {0} where {2}='{1}'", BaseVariable.ResultTableName, BarCode, Filed);
                            break;
                    }
                    object obj = LocalDbDAL.ExecuteScaler(sql);
                    if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return false;
            }
            finally
            {
                LogType ty = LogType.Y1;
                switch (Type)
                    {
                        case 1://合件
                            ty = LogType.Y1;
                            break;
                        case 2://子件
                            ty = LogType.Y2;
                            break;
                    }
                this.WirteTimeSpanLog(new TimeSpan(0, 0, 0, 0, (int)existWatch.ElapsedMilliseconds), ty);
                existWatch.Stop();
            }
        } 
        #endregion

        #region 扫描数据结果处理
        #region 防错追溯
        #region 防错追溯---改造
        /// <summary>
        /// 防错追溯，将信息添加到数据库
        /// </summary>
        private bool ScanResultToDb()
        {
            try
            {
                if (CurrnetScanType == 1 || (productModel.HaveSub && RequestParam.Count > 0))
                {
                    //获取批次信息
                    //GetBatchInfoToParam();
                    bool flag = false;//结果标识
                    if (Opt.GlobalNetStatus())//网络状态良好的情况下
                    {
                        DateTime time = DateTime.Now;
                        flag = ResultDAL.Insert(BaseVariable.ResultTableName, this.lblHJCode.Text, this.lblProductCode.Text, this.productModel.ProductType, BaseVariable.UserEntity.UserID, BaseVariable.DeviceEntity.StationID, CurrnetScanType, RequestParam);
                        this.WirteTimeSpanLog(DateTime.Now - time, LogType.RD);
                    }
                    else
                    {
                        flag = SaveToLocal();//存储到本地数据库中
                    }
                    if (!flag)
                    {
                        flag = SaveToLocal();//存储到本地数据库中
                    }
                    if (flag)
                    {
                        this.lblOK.Text = "OK";
                        this.Tip("扫描合件条码");
                        this.lblOK.ForeColor = Color.Green;
                        CurrentCount++;
                        this.lblCurrentCount.Text = CurrentCount.ToString();
                        return true;
                    }
                }
                this.lblOK.Text = "NG";
                this.Tip("请重新操作");
                this.lblOK.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                bool rst = SaveToLocal();//存储到本地数据库中
                if (rst)
                {
                    this.lblOK.Text = "OK";
                    this.Tip("扫描合件条码");
                    this.lblOK.ForeColor = Color.Green;
                    CurrentCount++;
                    this.lblCurrentCount.Text = CurrentCount.ToString();
                    return true;
                }
                else
                {
                    this.lblOK.Text = "NG";
                    this.Tip("请重新操作");
                    this.lblOK.ForeColor = Color.Red;
                }
                CLog.WriteErrLog("[FrmScan.ScanResultToDB]" + ex.Message);
            }
            finally
            {
                this.WirteTimeSpanLog(new TimeSpan(0, 0, 0, 0, (int)watch.ElapsedMilliseconds), LogType.V1);
                watch.Reset();
                //BatchTip();//批次信息提醒
            }

            return false;
        }
        #endregion

        #region 保存数据到本地---新增
        /// <summary>
        /// 保存数据到本地
        /// </summary>
        /// <returns></returns>
        private bool SaveToLocal()
        {
            string sql = "";
            try
            {
                //1.整合追溯信息
                Hashtable HTResult = GetHashtable();
                if (HTResult==null && HTResult.Count<1)
                {
                    return false;
                }
                //2.组装SQL语句
                sql = AssembleSqlCode(HTResult);
                bool flag = LocalDbDAL.ExecuteSql(sql);
                return flag;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                CLog.WriteStationLog("DataErr",sql);
                return false;
            }
        } 
        #endregion

        #region 添加批量追溯信息---改造
        /// <summary>
        /// 添加批量追溯信息
        /// </summary>
        private void GetBatchInfoToParam()
        {
            #region 添加批量追溯信息
            if (BaseVariable.DeviceEntity.ProductType != "前桥" || BaseVariable.DeviceEntity.ProductType != "后桥")
            {
                string sql = string.Format("SELECT tid,producttype,productcode,materialcode,materialname,materialnum,tracetype,fieldname,batchno FROM (SELECT t.*,n.batchno batchno FROM (SELECT b.*, m.tablename, m.fieldname FROM productinfo p, productbominfo b, materialfield m WHERE p.productcode = b.productcode AND p.producttype = b.producttype AND b.materialcode = m.materialcode AND m.tablename='{0}') t LEFT JOIN batchno n ON t.materialcode = n.materialcode) t WHERE  productcode='{1}' AND producttype='{2}' AND tracetype in({3});", BaseVariable.ResultTableName, this.productModel.ProductCode, BaseVariable.DeviceEntity.ProductType, "'批次追溯'");
                DataTable table = LocalDbDAL.GetDataTable(sql);
                if (table!=null && table.Rows.Count>0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (row["batchno"] != null && row["batchno"].ToString()!="")
                        {
                            RequestParam.Add(row["materialcode"].ToString(), row["batchno"].ToString()); 
                        }
                    }
                }
            }
            #endregion
        }
        #endregion

        #region 整合追溯信息为Hashtable---新增
        /// <summary>
        /// 整合追溯信息为Hashtable
        /// </summary>
        /// <returns></returns>
        private Hashtable GetHashtable()
        {
            try
            {
                string sql = string.Format("SELECT * FROM (SELECT t.* FROM (SELECT b.*, m.tablename, m.fieldname FROM productinfo p, productbominfo b, materialfield m WHERE p.productcode = b.productcode AND p.producttype = b.producttype AND b.materialcode = m.materialcode AND m.tablename='{0}') t LEFT JOIN batchno n ON t.materialcode = n.materialcode) t WHERE  productcode='{1}' AND producttype='{2}' AND tracetype in({3});", BaseVariable.ResultTableName, this.productModel.ProductCode, BaseVariable.DeviceEntity.ProductType, "'扫描追溯'");
                DataTable table = LocalDbDAL.GetDataTable(sql);
                if (table!=null && table.Rows.Count>0)
                {
                    Hashtable HTSelect = MaterialBomDAL.GetList(table);
                    Hashtable HTResult = new Hashtable();
                    foreach (var item in RequestParam)
                    {
                        if (HTSelect.ContainsKey(item.Key))
                        {
                            MaterialBomMDL model = HTSelect[item.Key] as MaterialBomMDL;
                            model.BatchBarCode = item.Value;
                            HTResult.Add(item.Key, model);
                        }
                    }
                    return HTResult;
                }
                return null;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return null;
            }
        } 
        #endregion

        #region 组装SQL语句---改造
        /// <summary>
        /// 组装SQL语句
        /// </summary>
        /// <param name="IsExit"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        private string AssembleSqlCode(Hashtable ParamHTList)
        {
            //查询合件是否存在
            object obj = LocalDbDAL.ExecuteScaler(string.Format("SELECT tid FROM {0} WHERE barcode ='{1}';", BaseVariable.ResultTableName, this.lblHJCode.Text));
            long TID = obj != null && obj.ToString() != "0" ? long.Parse(obj.ToString()) : 0;
            string sql = "";
            if (TID != 0)
            {
                sql += string.Format("update {0} set ", BaseVariable.ResultTableName);
                #region 对应更新字段
                if (ParamHTList != null && ParamHTList.Count > 0)
                {
                    foreach (DictionaryEntry Entry in ParamHTList)
                    {
                        MaterialBomMDL model = Entry.Value as MaterialBomMDL;
                        if (!string.IsNullOrEmpty(model.BatchBarCode))
                        {
                            sql += string.Format("{0}='{1}',", model.FieldName, model.BatchBarCode);
                        }
                    }
                }
                #endregion
                sql += string.Format("userid='{0}',stationid='{1}',scantype='{2}'", BaseVariable.UserEntity.UserID, BaseVariable.DeviceEntity.StationID, CurrnetScanType);
                sql += string.Format(" where tid={0}", TID);
            }
            else
            {
                string field = "";
                string values = "";
                #region 对应更新字段
                if (ParamHTList != null && ParamHTList.Count > 0)
                {
                    foreach (DictionaryEntry Entry in ParamHTList)
                    {
                        MaterialBomMDL model = Entry.Value as MaterialBomMDL;
                        if (!string.IsNullOrEmpty(model.BatchBarCode))
                        {
                            field += model.FieldName + ",";
                            values += string.Format("'{0}',", model.BatchBarCode);
                        }
                    }
                }
                #endregion
                field += "barcode,productcode,userid,stationid,scantype";
                values += string.Format("'{0}','{1}','{2}','{3}','{4}'", this.lblHJCode.Text, this.productModel.ProductCode, BaseVariable.UserEntity.UserID, BaseVariable.DeviceEntity.StationID, CurrnetScanType);
                sql += string.Format("insert into {0}({1}) values({2});", BaseVariable.ResultTableName, field, values);
            }
            return sql;
        }
        #endregion
        #endregion

        #region 批次信息提醒
        /// <summary>
        /// 批次信息提醒
        /// </summary>
        private void BatchTip()
        {
            if (BaseVariable.DeviceEntity.ProductType != "踏板" && BaseVariable.DeviceEntity.ProductType != "制动泵" && Opt.GlobalNetStatus())
            {
                bool flag = Opt.CheckBatchStatus(this.productModel.ProductCode);
                if (flag)
                {
                    Tip("有批次零件需要更新");
                }
            }
        } 
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
            //this.lblCurrentCount.Text = null;
            this.lblOK.Text = null;
            this.lblScanCode.Text = null;
            this.lblTip.Text = "请扫描合件条码";
            this.IsOK = true;
            this.IsHjScan = true;
            this.lvMaterial.Items.Clear();
        }
        #endregion

        #region 根据时间按写日志
        /// <summary>
        /// 根据时间按写日志
        /// </summary>
        /// <param name="span"></param>
        /// <param name="msg"></param>
        private void WirteTimeSpanLog(TimeSpan span, LogType type)
        {
            try
            {
                if (span.TotalSeconds > 1)
                {
                    string msg = "";
                    switch (type)
                    {
                        case LogType.SP://合件
                            msg = "扫描合件";
                            break;
                        case LogType.SC://子件
                            msg = "扫描子件";
                            break;
                        case LogType.Y1://验证合件
                            msg = "验证合件";
                            break;
                        case LogType.Y2://验证子件
                            msg = "验证子件";
                            break;
                        case LogType.V0://声音Error
                            msg = "错误提示音";
                            break;
                        case LogType.V1://合件完成
                            msg = "合件完成";
                            break;
                        case LogType.V2://声音OK
                            msg = "正确提示音";
                            break;
                        case LogType.RD://插入到数据库
                            msg = "更新到数据库";
                            break;
                    }
                    CLog.WriteStationLog("scan", msg + ":" + span);
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.WirteTimeSpanLog]" + ex.Message);
            }
        }
        #endregion

        #region 扫描类型判断-20170904
        private void SetCurrnetScanType(int type)
        {
            if (type == 0)
            {
                this.rbtnNormalScan.Checked = true;
                this.rbtnInScan.Checked = false;
            }
            else
            {
                this.rbtnNormalScan.Checked = false;
                this.rbtnInScan.Checked = true;
            }
        }

        #endregion

        private void rbtnNormalScan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNormalScan.Checked)
            {
                CurrnetScanType = 0;
                SetCurrnetScanType(CurrnetScanType);
            }
        }

        private void rbtnInScan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnInScan.Checked)
            {
                CurrnetScanType = 1;
                SetCurrnetScanType(CurrnetScanType);
                this.lvMaterial.Items.Clear();
            }
        } 
        #endregion
    }
    #region 结果表结构体
    /// <summary>
    /// 结果表结构体
    /// </summary>
    public enum ResultTableName
    {
        /// <summary>
        /// 摇篮
        /// </summary>
        cradleresult,
        /// <summary>
        /// 踏板
        /// </summary>
        pedalresult,
        /// <summary>
        /// 制动泵
        /// </summary>
        brakepupumpresult,
        /// <summary>
        /// 散热器
        /// </summary>
        radiatorresult
    }
    #endregion
}