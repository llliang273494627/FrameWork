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
using System.Threading;

namespace HTJCSys.PDA
{
    public partial class FrmDataSync : Form
    {
        #region 变量
        /// <summary>
        /// 实例化UserInfoDAL类
        /// </summary>
        UserInfoDAL userDAL = new UserInfoDAL();
        /// <summary>
        /// 实例化LUserInfoDAL类
        /// </summary>
        LUserInfoDAL lUserDAL = new LUserInfoDAL();
        /// <summary>
        /// 实例化DeviceInfoDAL类
        /// </summary>
        DeviceInfoDAL deviceDAL = new DeviceInfoDAL();
        /// <summary>
        /// 实例化LDeviceInfoDAL类
        /// </summary>
        LDeviceInfoDAL lDeviceDAL = new LDeviceInfoDAL();
        /// <summary>
        /// 实例化ProductInfoDAL类
        /// </summary>
        ProductInfoDAL productDAL = new ProductInfoDAL();
        /// <summary>
        /// 实例化LProductInfoDAL类
        /// </summary>
        LProductInfoDAL lProductDAL = new LProductInfoDAL();
        /// <summary>
        /// 实例化ProductBomInfoDAL类
        /// </summary>
        ProductBomInfoDAL productBomDAL = new ProductBomInfoDAL();
        /// <summary>
        /// 实例化LProductBomInfoDAL类
        /// </summary>
        LProductBomInfoDAL lProductBomDAL = new LProductBomInfoDAL();
        /// <summary>
        /// 实例化MaterialFieldDAL类
        /// </summary>
        MaterialFieldDAL filedDAL = new MaterialFieldDAL();
        /// <summary>
        /// 实例化LMaterialFieldDAL类
        /// </summary>
        LMaterialFieldDAL lFieldDAL = new LMaterialFieldDAL();

        /// <summary>
        ///  实例化BrakepumpResultDAL类
        /// </summary>
        //BrakepumpResultDAL brakeResultDAL = new BrakepumpResultDAL();
        /// <summary>
        ///  实例化本地LBrakepumpResultDAL类
        /// </summary>
        LPedalResultDAL lPedalResultDAL = new LPedalResultDAL();
        /// <summary>
        ///  实例化本地LBrakepumpResultDAL类
        /// </summary>
        LBrakepumpResultDAL lBrakeResultDAL = new LBrakepumpResultDAL();
        /// <summary>
        ///  实例化RadiatorResultDAL类
        /// </summary>
        //RadiatorResultDAL radiatorResultDAL = new RadiatorResultDAL();
        /// <summary>
        ///  实例化本地LRadiatorResultDAL类
        /// </summary>
        LRadiatorResultDAL lRadiatorResultDAL = new LRadiatorResultDAL();
        /// <summary>
        ///  实例化FrontAxleResultDAL类
        /// </summary>result
        //FrontAxleResultDAL frontAxleResultDAL = new FrontAxleResultDAL();
        /// <summary>
        ///  实例化本地LFrontAxleResultDAL类
        /// </summary>
        LFrontAxleResultDAL lFrontAxleResultDAL = new LFrontAxleResultDAL();
        /// <summary>
        ///  实例化RearAxleResultDAL类
        /// </summary>result
        //RearAxleResultDAL rearAxleResultDAL = new RearAxleResultDAL();
        /// <summary>
        ///  实例化本地LRearAxleResultDAL类
        /// </summary>
        LRearAxleResultDAL lRearAxleResultDAL = new LRearAxleResultDAL();
        /// <summary>
        ///  实例化LBatchNoDAL类
        /// </summary>
        LBatchNoDAL lBatchDAL = new LBatchNoDAL();
        /// <summary>
        ///  实例化BatchNoDAL类
        /// </summary>
        BatchNoDAL BatchDAL = new BatchNoDAL();
        /// <summary>
        ///  实例化本地LAuxiliaryFasiaResultDAL类
        /// </summary>
        LAuxiliaryFasiaResultDAL lAuxiliaryFasiaResultDAL = new LAuxiliaryFasiaResultDAL();

        /// <summary>
        /// 同步类型
        /// </summary>
        SyncType Sync;
        /// <summary>
        /// 制动泵更新数据数量
        /// </summary>
        int BrakeResultCount = 0;
        /// <summary>
        /// 踏板更新数据数量
        /// </summary>
        int PedalResultCount = 0;
        /// <summary>
        /// 散热器更新数据数量
        /// </summary>
        int RadiatorResultCount = 0;
        /// <summary>
        /// 批次更新数据数量
        /// </summary>
        int BatchCount = 0;
        /// <summary>
        /// 前桥更新数据数量
        /// </summary>
        int FrontAxleResultCount = 0;
        /// <summary>
        /// 后桥更新数据数量
        /// </summary>
        int RearAxleResultCount = 0;
        /// <summary>
        /// 后桥更新数据数量
        /// </summary>
        int AuxiliaryFasiaResultCount = 0;
        /// <summary>
        /// 上传更新的数量
        /// </summary>
        int uploadnum = 0;
        #endregion

        #region 初始化
        public FrmDataSync()
        {
            InitializeComponent();
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);//居中显示
        }

        public FrmDataSync(SyncType type)
            : this()
        {
            this.Sync = type;
        } 
        #endregion

        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDataSync_Load(object sender, EventArgs e)
        {
            //this.lblPercent.Text = "0%";
            this.progressBar.Value = 0;
            if (Sync == SyncType.Download)
            {
                this.timerSync.Enabled = true;
                TitleTip("正在下载数据……");//标题信息
            }
            if (Sync == SyncType.Upload)
            {
                BatchCount = lBatchDAL.GetRecordCount("");
                BrakeResultCount = lBrakeResultDAL.GetRecordCount("");
                PedalResultCount = lPedalResultDAL.GetRecordCount("");
                RadiatorResultCount = lRadiatorResultDAL.GetRecordCount("");

                //添加前桥和后桥
                FrontAxleResultCount = lFrontAxleResultDAL.GetRecordCount("");
                RearAxleResultCount = lRearAxleResultDAL.GetRecordCount("");
                //添加副仪表板
                AuxiliaryFasiaResultCount = lAuxiliaryFasiaResultDAL.GetRecordCount("");

                this.timerSync.Enabled = true;
                TitleTip(string.Format("正在上传{0}条数据……", BrakeResultCount + PedalResultCount + RadiatorResultCount + BatchCount + RearAxleResultCount + FrontAxleResultCount + AuxiliaryFasiaResultCount));//标题信息
            }
        } 
        #endregion

        #region 下载数据
        /// <summary>
        /// 下载数据
        /// </summary>
        private void Download()
        {
            try
            {
                //0.清空表
                StringBuilder StrSql = new StringBuilder();
                StrSql.AppendLine("DELETE FROM userinfo;");
                StrSql.AppendLine("DELETE FROM deviceinfo;");
                StrSql.AppendLine("DELETE FROM productinfo;");
                StrSql.AppendLine("DELETE FROM productbominfo;");
                StrSql.AppendLine("DELETE FROM materialfield;");
                bool rst = LocalDbDAL.ExecuteSqlTran(StrSql.ToString());

                //1.用户表
                TitleTip("下载用户表……");
                DownloadUser();
                //2.设备表
                TitleTip("下载设备表……");
                DownloadDevice();
                //3.产品表
                TitleTip("下载产品表……");
                DownloadProduct();
                //4.bom表
                TitleTip("下载BOM表……");
                DownloadBOM();
                //5.材料字段表
                TitleTip("下载材料字段……");
                DownloadMaterialField();
                TitleTip("下载数据完毕");
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
            finally
            {
                CloseForm();
            }
        }

        //1.用户表
        #region 下载用户表
        private void DownloadUser()
        {
            try
            {
                DataTable table = userDAL.GetAll();
                if (table!=null && table.Rows.Count>0)
                {
                    int count = table.Rows.Count;
                    this.progressBar.Maximum = count;
                    this.progressBar.Value = 0;
                    for (int i = 0; i < count; i++)
                    {
                        DataRow row = table.Rows[i];
                        UserInfoMDL model = userDAL.DataRowToModel(row);
                        bool rst = lUserDAL.Add(model);
                        this.progressBar.Value = i;
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion
        //2.设备表
        #region 下载设备表
        private void DownloadDevice()
        {
            try
            {
                DataTable table =deviceDAL.GetAll();
                if (table != null && table.Rows.Count > 0)
                {
                    int count = table.Rows.Count;
                    this.progressBar.Maximum = count;
                    this.progressBar.Value = 0;
                    for (int i = 0; i < count; i++)
                    {
                        DataRow row = table.Rows[i];
                        DeviceInfoMDL model = deviceDAL.DataRowToModel(row);
                        bool rst = lDeviceDAL.Add(model);
                        this.progressBar.Value = i;
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion
        //3.产品表
        #region 下载产品表
        private void DownloadProduct()
        {
            try
            {
                DataTable table = productDAL.GetDataTable(BaseVariable.DeviceEntity.ProductType);
                if (table != null && table.Rows.Count > 0)
                {
                    int count = table.Rows.Count;
                    this.progressBar.Maximum = count;
                    this.progressBar.Value = 0;
                    for (int i = 0; i < count; i++)
                    {
                        DataRow row = table.Rows[i];
                        ProductInfoMDL model = productDAL.DataRowToModel(row);
                        bool rst = lProductDAL.Add(model);
                        this.progressBar.Value = i;
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion
        //4.bom表
        #region 下载BOM表
        private void DownloadBOM()
        {
            try
            {
                DataTable table =productBomDAL.GetDataTable(BaseVariable.DeviceEntity.ProductType,"","","0");
                if (table != null && table.Rows.Count > 0)
                {
                    int count = table.Rows.Count;
                    this.progressBar.Maximum = count;
                    this.progressBar.Value = 0;
                    for (int i = 0; i < count; i++)
                    {
                        DataRow row = table.Rows[i];
                        ProductBomInfoMDL model = productBomDAL.DataRowToModel(row);
                        bool rst = lProductBomDAL.Add(model);
                        this.progressBar.Value = i;
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion
        //5.材料字段表
        #region 下载字段表
        private void DownloadMaterialField()
        {
            try
            {
                DataTable table = filedDAL.GetDataTable("");
                if (table != null && table.Rows.Count > 0)
                {
                    int count = table.Rows.Count;
                    this.progressBar.Maximum = count;
                    this.progressBar.Value = 0;
                    for (int i = 0; i < count; i++)
                    {
                        DataRow row = table.Rows[i];
                        MaterialFieldMDL model = filedDAL.DataRowToModel(row);                        
                        bool rst = lFieldDAL.Add(model);
                        this.progressBar.Value = i;
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #endregion

        #region 上传数据
        /// <summary>
        /// 上传数据
        /// </summary>
        private void Upload()
        {
            try
            {
                //1.上传批次表
                if (BatchCount>0)
                {
                    UploadBatchTable(); 
                }
                int total = BrakeResultCount + PedalResultCount + RadiatorResultCount + RearAxleResultCount + FrontAxleResultCount + AuxiliaryFasiaResultCount;
                if (total>0)
                {
                    UploadTable();
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
            finally 
            {
                if (uploadnum>0)
                {
                    MessageBox.Show("成功上传" + uploadnum + "条数据");
                }
                CloseForm();
            }
        }

        #region 上传批次记录
        /// <summary>
        /// 上传批次记录
        /// </summary>
        private void UploadBatchTable()
        {
            this.Invoke((EventHandler)delegate
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    progressBar.Value = 0;
                    progressBar.Maximum = 1;
                    //上传本地批次历史信息
                    #region 上传本地批次历史信息
                    //获取本地批次历史信息
                    DataTable table = lBatchDAL.GetList("").Tables[0];

                    string IDs = BatchDAL.Upload(table);

                    if (!string.IsNullOrEmpty(IDs))
                    {
                        lBatchDAL.DeleteList(IDs);//上传后删除本地数据
                        string[] str = IDs.Split(',');
                        uploadnum += str.Length;
                    }
                    ProgressTip(1);//更新进度
                    Cursor.Current = Cursors.Default;
                    #endregion
                }
                catch (Exception ex)
                {
                    CLog.WriteErrLog(ex.Message);
                }
            });
        } 
        #endregion

        #region 上传零件记录
        /// <summary>
        /// 上传零件记录
        /// </summary>
        private void UploadTable()
        {
            this.Invoke((EventHandler)delegate
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    progressBar.Value = 0;
                    progressBar.Maximum = 1;
                    string sql = string.Format("SELECT * FROM {0}", BaseVariable.ResultTableName);
                    //获取当前产品的数据表
                    DataTable table = LocalDbDAL.GetDataTable(sql);
                    if (table==null||table.Rows.Count<1)
                    {
                        return;
                    }
                    //向服务器发送请求，数据上传并返回上传成功的数据TID
                    string IDs = ResultDAL.Upload(BaseVariable.DeviceEntity.ProductType, BaseVariable.ResultTableName, table);
                    if (!string.IsNullOrEmpty(IDs))
                    {
                        sql = string.Format("DELETE FROM {0} WHERE tid IN ({1});", BaseVariable.ResultTableName,IDs);
                        LocalDbDAL.ExecuteSql(sql);//上传后删除本地数据
                        string [] str = IDs.Split(',');
                        uploadnum += str.Length;
                    }
                    ProgressTip(1);//更新进度
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    CLog.WriteErrLog(ex.Message);
                }
            });
        } 
        #endregion
        #endregion

        #region 提示消息
        #region 标题提示信息
        /// <summary>
        /// 标题提示信息
        /// </summary>
        /// <param name="msg"></param>
        private void TitleTip(string msg)
        {
            this.Invoke((EventHandler)delegate
            {
                this.lblTitle.Text = msg;
            });
        }
        #endregion

        #region 进度条提示信息
        /// <summary>
        /// 进度条提示信息
        /// </summary>
        /// <param name="value"></param>
        /// <param name="percent"></param>
        private void ProgressTip(int value)
        {
            this.Invoke((EventHandler)delegate
            {
                this.progressBar.Value = value;//更新进度条
                //this.lblPercent.Text = percent + "%";
            });
        } 
        #endregion 
        #endregion

        #region 关闭的方法
        /// <summary>
        /// 关闭的方法
        /// </summary>
        private void CloseForm()
        {
            try
            {
                //threadSync.Abort();                
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
            finally 
            {
                this.Close();
            }
        } 
        #endregion  

        #region 触发器
        private void timerSync_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerSync.Enabled = false;
                if (Sync == SyncType.Download)
                {
                    //执行下载方法
                    //threadSync = new Thread(new ThreadStart(Download));//实例化上传数据线程
                    //threadSync.IsBackground = true;
                    //threadSync.Start();//启动线程
                    Download();
                }
                if (Sync == SyncType.Upload)
                {
                    //执行上传方法
                    //threadSync = new Thread(new ThreadStart(Upload));//实例化上传数据线程
                    //threadSync.IsBackground = true;
                    //threadSync.Start();//启动线程
                    Upload();
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion
    }

    #region 数据同步类型
    /// <summary>
    /// 数据同步类型
    /// </summary>
    public enum SyncType
    {
        Download,
        Upload
    }
    #endregion
}