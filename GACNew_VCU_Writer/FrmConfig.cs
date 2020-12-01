using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GACNew_VCU_Writer_BLL;
using System.IO.Ports;
using GACNew_VCU_Writer;
using Common.Logging;

namespace GACNew_VCU_Writer
{
    public partial class FrmConfig : Form
    {
        #region 私有变量

        /// <summary>
        /// 日志对象
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(FrmHistory));

        private static Configer configer = new Configer();

        private VCUconfig VCUItem;

        #endregion

        #region 属性

        private string localConnectionString = string.Empty;

        public string LocalConnectionString
        {
            get { return localConnectionString; }
            set { localConnectionString = value; }
        }

        #endregion

        #region 构造函数

        public FrmConfig()
        {
            InitializeComponent();
        }

        public FrmConfig(string localConnectionString)
        {
            this.localConnectionString = localConnectionString;
            configer = new Configer(this.localConnectionString);
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmConfig_Load(object sender, EventArgs e)
        {
            //填充参数表
            this.FillRunParam();
            //填充特制码表
            this.FillVCUCode();
            //填充流程表
            this.FillDefineFlow();
            //填充VCU配置表
            this.FillStandard();
            //填充MTOC表
            this.FillMTOC();

            //tabControl1.TabPages.Remove(tabPage1);
            //tabControl1.TabPages.Remove(tabPage2);
            //tabControl1.TabPages.Remove(tabPage3);

            dgvStandard.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dgv"></param>
        private void FillData(string sql, DataGridView dgv)
        {
            try
            {
                DataTable dtSource = configer.GetDataSource(sql);
                dgv.DataSource = dtSource;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }


        #region RunParam

        /// <summary>
        /// 填充参数表
        /// </summary>
        private void FillRunParam()
        {
            string runParaSQL = string.Format("SELECT ID as 序号, Groups as 组, Descriptions as 描述, Keys as 键, keyValue as 值 FROM \"GAC_New_VCU\".\"T_RunParam\" order by ID;");
            FillData(runParaSQL, this.dgvRunParam);
        }
        /// <summary>
        /// 参数表单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRunParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.txtTPMSID.Text = this.dgvRunParam.Rows[e.RowIndex].Cells[0].Value + "";
                    this.txtGroup.Text = this.dgvRunParam.Rows[e.RowIndex].Cells[1].Value + "";
                    this.txtDescription.Text = this.dgvRunParam.Rows[e.RowIndex].Cells[2].Value + "";
                    this.txtKey.Text = this.dgvRunParam.Rows[e.RowIndex].Cells[3].Value + "";
                    this.txtValue.Text = this.dgvRunParam.Rows[e.RowIndex].Cells[4].Value + "";
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTPMSID.Text == string.Empty || this.txtValue.Text == string.Empty) return;

                int result = configer.UpdateRunParam(this.txtTPMSID.Text.Trim(), this.txtValue.Text.Trim());

                if (result >= 1)
                {
                    MessageBox.Show("更新成功");
                    this.FillRunParam();
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunParamCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region VCUCode

        /// <summary>
        /// 填充TCU特制码表
        /// </summary>
        private void FillVCUCode()
        {
            string tpmsCodeSQL = string.Format("SELECT ID as 序号, Baud as 波特率, SendAddress as 接收地址, ResponseAddress as 响应地址 FROM \"GAC_New_VCU\".\"T_VCUCodeList\" order by ID;");
            FillData(tpmsCodeSQL, this.dgvTPMSCode);
        }
        /// <summary>
        /// 单击TCU特制码表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTPMSCode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.txtTPMSCodeID.Text = this.dgvTPMSCode.Rows[e.RowIndex].Cells[0].Value + "";
                    this.txtCarType.Text = this.dgvTPMSCode.Rows[e.RowIndex].Cells[1].Value + "";
                    this.txtCANIND.Text = this.dgvTPMSCode.Rows[e.RowIndex].Cells[2].Value + "";
                    this.txtBaud.Text = this.dgvTPMSCode.Rows[e.RowIndex].Cells[3].Value + "";
                    this.txtSendAddress.Text = this.dgvTPMSCode.Rows[e.RowIndex].Cells[4].Value + "";
                    this.txtResponseAddress.Text = this.dgvTPMSCode.Rows[e.RowIndex].Cells[5].Value + "";
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 插入TCU特码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTPMSCodeInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTPMSCodeID.Text != string.Empty &&
                    this.txtCarType.Text != string.Empty &&
                    this.txtCANIND.Text != string.Empty &&
                    this.txtBaud.Text != string.Empty &&
                    this.txtSendAddress.Text != string.Empty &&
                    this.txtResponseAddress.Text != string.Empty)
                {
                    int exist = configer.ExistTPMSCode(this.txtCarType.Text);

                    if (exist == 0)
                    {
                        int result = configer.InsertTPMSCode(this.txtCarType.Text, this.txtCANIND.Text, this.txtBaud.Text, this.txtSendAddress.Text, this.txtResponseAddress.Text);

                        if (result == 1)
                        {
                            //填充数据
                            //FillTPMSCode();
                            MessageBox.Show("新增车型成功！");
                        }
                        else
                        {
                            MessageBox.Show("新增车型失败");
                        }
                    }
                    else
                    {
                        MessageBox.Show("当前TPMS特特制码已存在！");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 更新TCUCode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTPMSCodeUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTPMSCodeID.Text != string.Empty &&
                    this.txtCarType.Text != string.Empty &&
                    this.txtCANIND.Text != string.Empty &&
                    this.txtBaud.Text != string.Empty &&
                    this.txtSendAddress.Text != string.Empty &&
                    this.txtResponseAddress.Text != string.Empty)
                {
                    int result = configer.UpdateTPMSCode(this.txtTPMSCodeID.Text, this.txtCarType.Text, this.txtCANIND.Text, this.txtBaud.Text, this.txtSendAddress.Text, this.txtResponseAddress.Text);

                    if (result == 1)
                    {
                        //填充数据
                        //FillTPMSCode();
                        MessageBox.Show("修改TPMS特制码成功！");
                    }
                    else
                    {
                        MessageBox.Show("修改TPMS特制码失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTPMSCodeDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTPMSCodeID.Text != string.Empty &&
                    this.txtCarType.Text != string.Empty &&
                    this.txtCANIND.Text != string.Empty &&
                    this.txtBaud.Text != string.Empty &&
                    this.txtSendAddress.Text != string.Empty &&
                    this.txtResponseAddress.Text != string.Empty)
                {
                    int result = configer.DeleteTPMSCode(this.txtTPMSCodeID.Text);

                    if (result == 1)
                    {
                        //填充数据
                        //FillTPMSCode();
                        MessageBox.Show("删除TPMS特制码成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除TPMS特制码成功！");
                    }

                    this.txtTPMSCodeID.Text = string.Empty;
                    this.txtCarType.Text = string.Empty;
                    this.txtCANIND.Text = string.Empty;
                    this.txtBaud.Text = string.Empty;
                    this.txtSendAddress.Text = string.Empty;
                    this.txtResponseAddress.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTPMSCodeCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region DefineFlow

        /// <summary>
        /// 填充流程表
        /// </summary>
        private void FillDefineFlow()
        {
            string defineFlowSQL = string.Format("SELECT ID as 序号, Flowname as 流程名称, SendCmd as 发送指令, ReceiveCmd as 接收指令, Enabled as 启用, SleepTime as 时间间隔, ReceiveNum as 接收帧数 FROM \"GAC_New_VCU\".\"T_DefineFlow\" order by ID;");
            FillData(defineFlowSQL, this.dgvDefineFlow);
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefineFlowCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFlow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.txtDefineFlowID.Text = this.dgvDefineFlow.Rows[e.RowIndex].Cells[0].Value + "";
                    this.txtDefineFlowName.Text = this.dgvDefineFlow.Rows[e.RowIndex].Cells[1].Value + "";
                    this.txtSendCmd.Text = this.dgvDefineFlow.Rows[e.RowIndex].Cells[2].Value + "";
                    this.txtReceiveCmd.Text = this.dgvDefineFlow.Rows[e.RowIndex].Cells[3].Value + "";
                    this.cbDefineFlowEnable.Checked = (this.dgvDefineFlow.Rows[e.RowIndex].Cells[4].Value + "" == "1") ? true : false;
                    this.txtDefineFlowCarType.Text = this.dgvDefineFlow.Rows[e.RowIndex].Cells[5].Value + "";
                    this.txtDefineFlowSleepTime.Text = this.dgvDefineFlow.Rows[e.RowIndex].Cells[6].Value + "";
                    //this.txtDefineFlowReceiveNum.Text = this.dgvDefineFlow.Rows[e.RowIndex].Cells[7].Value + "";
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 更新流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefineFlowUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtDefineFlowID.Text != string.Empty &&
                    this.txtDefineFlowName.Text != string.Empty &&
                    this.txtSendCmd.Text != string.Empty &&
                    this.txtReceiveCmd.Text != string.Empty &&
                    this.txtDefineFlowCarType.Text != string.Empty &&
                    this.txtDefineFlowSleepTime.Text != string.Empty)
                //this.txtDefineFlowReceiveNum.Text != string.Empty)
                {
                    int result = configer.UpdateDefineFlow(this.txtDefineFlowName.Text, this.txtSendCmd.Text, this.txtReceiveCmd.Text, this.cbDefineFlowEnable.Checked + "", this.txtDefineFlowCarType.Text, this.txtDefineFlowSleepTime.Text, this.txtDefineFlowID.Text);

                    if (result == 1)
                    {
                        FillDefineFlow();
                        MessageBox.Show("更新流程成功！");
                    }
                    else
                    {
                        MessageBox.Show("更新流程失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        #endregion

        #region  Standard

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            AddConfig form = new AddConfig(null);
            form.ShowDialog();

            this.FillStandard();
        }

        /// <summary>
        /// 填充VCU配置表
        /// </summary>
        private void FillStandard()
        {
            string StandardSQL = string.Format("SELECT id as 序号, mtoc as MTOC码, drivername as 驱动文件名,driverpath as 驱动文件路径,binname as 写入文件名, binpath as 写入文件路径 , calname as 标定文件名,calpath as 标定文件路径,softwareversion as 软件版本号 ,\"elementNum\" as 零件号 ,\"hardwarecode\" as 硬件简码,\"HW\" as 硬件号,\"SW\" as 软件号,\"sign\" as 记号 FROM " + " " + "\"" + "GAC_New_VCU" + "\"" + "." + "\"T_VCUConfig\"" + " order by id;");
            FillData(StandardSQL, this.dgvStandard);
        }

        /// <summary>
        /// 填充VIN对应MTOC表
        /// </summary>
        private void FillMTOC()
        {
            string StandardSQL = string.Format("SELECT id as 序号, vin as VIN码,mtoc as MTOC码, state as 检测状态,element as 零件编码,\"updateTime\" as 同步时间 FROM " + " " + "\"" + "GAC_New_VCU" + "\"" + "." + "\"T_MTOC\"" + " order by id;");
            FillData(StandardSQL, this.dgvDL);
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStandard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (VCUItem != null)
                {
                    AddConfig form = new AddConfig(VCUItem);
                    form.ShowDialog();
                    this.FillStandard();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 单机表格显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStandard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    VCUItem = new VCUconfig();
                    VCUItem.Id = int.Parse(this.dgvStandard.Rows[e.RowIndex].Cells[0].Value + "");
                    VCUItem.MTOC = this.dgvStandard.Rows[e.RowIndex].Cells[1].Value + "";
                    VCUItem.DriverName = this.dgvStandard.Rows[e.RowIndex].Cells[2].Value + "";
                    VCUItem.DriverPath = this.dgvStandard.Rows[e.RowIndex].Cells[3].Value + "";
                    VCUItem.BinName = this.dgvStandard.Rows[e.RowIndex].Cells[4].Value + "";
                    VCUItem.BinPath = this.dgvStandard.Rows[e.RowIndex].Cells[5].Value + "";
                    VCUItem.CalName = this.dgvStandard.Rows[e.RowIndex].Cells[6].Value + "";
                    VCUItem.CalPath = this.dgvStandard.Rows[e.RowIndex].Cells[7].Value + "";
                    VCUItem.SoftWareVersion = this.dgvStandard.Rows[e.RowIndex].Cells[8].Value + "";
                    VCUItem.ElementNum = this.dgvStandard.Rows[e.RowIndex].Cells[9].Value + "";
                    VCUItem.HardWareCode = this.dgvStandard.Rows[e.RowIndex].Cells[10].Value + "";
                    VCUItem.HW = this.dgvStandard.Rows[e.RowIndex].Cells[11].Value + "";
                    VCUItem.SW = this.dgvStandard.Rows[e.RowIndex].Cells[12].Value + "";
                    VCUItem.Sign = this.dgvStandard.Rows[e.RowIndex].Cells[13].Value + "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("删除后不可恢复，确定要删除该数据吗", "删除", messButton);

                if (VCUItem != null)
                {
                    if (dr == DialogResult.OK)
                    {
                        configer.DeleteVCUconfig(VCUItem);
                        this.FillStandard();
                    }
                }
                else
                {
                    MessageBox.Show("请选择一行数据");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        private void dgvDL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.txtID.Text = this.dgvDL.Rows[e.RowIndex].Cells[0].Value + "";
                    this.txtVIN.Text = this.dgvDL.Rows[e.RowIndex].Cells[1].Value + "";
                    this.txtMTOC.Text = this.dgvDL.Rows[e.RowIndex].Cells[2].Value + "";
                    this.txtState.Text = this.dgvDL.Rows[e.RowIndex].Cells[3].Value + "";
                    this.txtElement.Text = this.dgvDL.Rows[e.RowIndex].Cells[4].Value + "";
                    this.txtUpdateTime.Text = this.dgvDL.Rows[e.RowIndex].Cells[5].Value + "";
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
    }
}
