using DSG_Group.DGComm;
using DSG_Group.SqlServers;
using FrameWork.Model.DFPV_DSG101;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSG_Group
{
    public partial class frmOption : Form
    {
        public frmOption()
        {
            InitializeComponent();
        }

        #region 方法
        /// <summary>
        /// 表格样式
        /// </summary>
        /// <param name="dataGridView"></param>
        private void GridViewStyle(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = false;
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
        }

        /// <summary>
        /// 重置运动参数修改值
        /// </summary>
        private void runParamClear()
        {
            txtGroup.Text = string.Empty;
            txtDis.Text = string.Empty;
            txtKey.Text = string.Empty;
            txtValue.Text = string.Empty;
        }

        /// <summary>
        /// 重置控制参数修改值
        /// </summary>
        private void ctrlParamClear()
        {
            txtCtrlGroup.Text = string.Empty;
            txtCtrlDis.Text = string.Empty;
            txtCtrlKey.Text = string.Empty;
            txtCtrlValue.Text = string.Empty;
        }

        #endregion

        /// <summary>
        /// 首次加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void frmOption_Load(object sender, EventArgs e)
        {
            // 设置表格
            GridViewStyle(datagridRunParam);
            datagridRunParam.DataSource = await Service_T_RunParam.GetRunParams();

            GridViewStyle(dgCtrlView);
            dgCtrlView.DataSource = await Service_T_CtrlParam.GetCtrlParams();
            if (dgCtrlView.Columns.Contains("编号"))
                dgCtrlView.Columns["编号"].Visible = false;

            GridViewStyle(dgCarView);
            dgCarView.DataSource = await Service_cartype_tpms.GetCarTypes();

            GridViewStyle(dgProView);
            dgProView.DataSource = await Service_cartype_prono.Queryable();

            List<string> groups = await Service_T_RunParam.GetGroups();
            combRunGroup.Items.AddRange(groups.ToArray());
            
            groups = await Service_T_CtrlParam.GetGroups();
            combCtrlGroup.Items.AddRange(groups.ToArray());
        }

        /// <summary>
        /// 下拉框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comb = sender as ComboBox;
            if (comb == null)
                return;

            var value = comb.Text.Trim();
            switch (comb.Name)
            {
                case "combRunGroup":
                    var tab = await Service_T_RunParam.GetRunParams(value);
                    datagridRunParam.DataSource = tab;
                    runParamClear();
                    break;
                case "combCtrlGroup":
                     tab = await Service_T_CtrlParam.GetCtrlParams(value);
                    dgCtrlView.DataSource = tab;
                    ctrlParamClear();
                    break;
            }
        }

        /// <summary>
        /// 点击表格单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datagridRunParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGroup.Text = string.Empty;
            txtDis.Text = string.Empty;
            txtKey.Text = string.Empty;
            txtValue.Text = string.Empty;
            try
            {
                DataGridView dataGrid = sender as DataGridView;
                if (e.RowIndex < 0 || e.ColumnIndex < 0 || dataGrid == null || e.RowIndex >= dataGrid.Rows.Count)
                    return;

                var rowView = dataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView;
                var tab = rowView.Row;

                var data = new T_RunParam();
                if (tab.Table.Columns.Contains("编号"))
                {
                    int.TryParse(tab["编号"].ToString(), out int id);
                    data.ID = id;
                }
                if (tab.Table.Columns.Contains("组"))
                    data.Group = tab["组"].ToString();
                if (tab.Table.Columns.Contains("描述"))
                    data.Description = tab["描述"].ToString();
                if (tab.Table.Columns.Contains("关键字"))
                    data.Key = tab["关键字"].ToString();
                if (tab.Table.Columns.Contains("值"))
                    data.Value = tab["值"].ToString();

                txtGroup.Text = data.Group;
                txtDis.Text = data.Description;
                txtKey.Text = data.Key;
                txtValue.Text = data.Value;
                groupUpdata.Tag = data;
            }
            catch (Exception ex)
            {
                HelperLog.Error<frmOption>(ex.Message, ex);
            }
        }

        /// <summary>
        /// 运动参数界面按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void bntRunParam_Click(object sender, EventArgs e)
        {
            Button bnt = sender as Button;
            if (bnt == null)
                return;

            try
            {
                switch (bnt.Name)
                {
                    case "bntUpdata":
                        var updata = groupUpdata.Tag as T_RunParam;
                        updata.Group = txtGroup.Text.Trim();
                        updata.Description = txtDis.Text.Trim();
                        updata.Key = txtKey.Text.Trim();
                        updata.Value = txtValue.Text.Trim();

                        int k = await Service_T_RunParam.Updata(updata);
                        if (k > 0)
                        {
                            var group = combRunGroup.Text.Trim();
                            var tab = await Service_T_RunParam.GetRunParams(group);
                            if (string.IsNullOrEmpty(group))
                                tab = await Service_T_RunParam.GetRunParams();
                            datagridRunParam.DataSource = tab;
                            runParamClear();
                        }
                        else
                        {
                            MessageBox.Show("修改参数失败！");
                        }
                        break;
                    case "bntRunClear":
                        runParamClear();
                        break;
                }
            }
            catch (Exception ex)
            {
                HelperLog.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// 控制参数表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgCtrlView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCtrlGroup.Text = string.Empty;
            txtCtrlDis.Text = string.Empty;
            txtCtrlKey.Text = string.Empty;
            txtCtrlValue.Text = string.Empty;

            try
            {
                DataGridView dataGrid = sender as DataGridView;
                if (e.RowIndex < 0 || e.ColumnIndex < 0 || dataGrid == null || e.RowIndex >= dataGrid.Rows.Count)
                    return;

                var rowView = dataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView;
                var tab = rowView.Row;

                var data = new T_CtrlParam();
                if (tab.Table.Columns.Contains("编号"))
                {
                    int.TryParse(tab["编号"].ToString(), out int id);
                    data.ID = id;
                }
                if (tab.Table.Columns.Contains("组"))
                    data.Group = tab["组"].ToString();
                if (tab.Table.Columns.Contains("描述"))
                    data.Description = tab["描述"].ToString();
                if (tab.Table.Columns.Contains("关键字"))
                    data.Key = tab["关键字"].ToString();
                if (tab.Table.Columns.Contains("值"))
                    data.Value = tab["值"].ToString();

                txtCtrlGroup.Text = data.Group;
                txtCtrlDis.Text = data.Description;
                txtCtrlKey.Text = data.Key;
                txtCtrlValue.Text = data.Value;
                groupUpCtrl.Tag = data;
            }
            catch (Exception ex)
            {
                HelperLog.Error<frmOption>(ex.Message, ex);
            }

        }

        /// <summary>
        /// 控制参数修改，取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void bntCtrl_Click(object sender, EventArgs e)
        {
            if (!(sender is Button bnt))
                return;

            try
            {
                switch (bnt.Name)
                {
                    case "bntUpCtrl":
                        var updata = groupUpCtrl.Tag as T_CtrlParam;
                        if (updata == null)
                            return;

                        updata.Group = txtCtrlGroup.Text.Trim();
                        updata.Description = txtCtrlDis.Text.Trim();
                        updata.Key = txtCtrlKey.Text.Trim();
                        updata.Value = txtCtrlValue.Text.Trim();

                        int k = await Service_T_CtrlParam.Updata(updata);
                        if (k > 0)
                        {
                            var group = combCtrlGroup.Text.Trim();
                            var tab = await Service_T_CtrlParam.GetCtrlParams(group);
                            if (string.IsNullOrEmpty(group))
                                tab = await Service_T_CtrlParam.GetCtrlParams();
                            dgCtrlView.DataSource = tab;
                            ctrlParamClear();
                        }
                        else
                        {
                            MessageBox.Show("修改参数失败！");
                        }
                        break;
                    case "bntClearCtrl":
                        ctrlParamClear();
                        break;
                }
            }
            catch (Exception ex)
            {
                HelperLog.Error<frmOption>(ex.Message, ex);
            }

        }

        private void dgCarView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = string.Empty;
            txtStartPoint.Text = string.Empty;
            txtLength.Text = string.Empty;
            txtMat.Text = string.Empty;
            txtCarType.Text = string.Empty;

            try
            {
                DataGridView dataGrid = sender as DataGridView;
                if (e.RowIndex < 0 || e.ColumnIndex < 0 || dataGrid == null || e.RowIndex >= dataGrid.Rows.Count)
                    return;

                var rowView = dataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView;
                var tab = rowView.Row;

                var data = new cartype_tpms();
                if (tab.Table.Columns.Contains("编号"))
                {
                    int.TryParse(tab["编号"].ToString(), out int id);
                    data.ID = id;
                }
                if (tab.Table.Columns.Contains("匹配的字母"))
                    data.MatchLetter = tab["匹配的字母"].ToString();
                if (tab.Table.Columns.Contains("起始位置")&&int.TryParse(tab["起始位置"].ToString(),out int CodeStartIndex))
                    data.CodeStartIndex = CodeStartIndex;
                if (tab.Table.Columns.Contains("长度") && int.TryParse(tab["长度"].ToString(), out int CodeLen))
                    data.CodeLen = CodeLen;
                if (tab.Table.Columns.Contains("车型"))
                    data.CarType = tab["车型"].ToString();
                if (tab.Table.Columns.Contains("是否带胎压"))
                {
                    int.TryParse(tab["是否带胎压"].ToString(), out int istpms);
                    data.ifTPMS = Convert.ToBoolean(istpms);
                }

                txtID.Text = data.ID.ToString();
                txtStartPoint.Text = data.CodeStartIndex.ToString();
                txtLength.Text = data.CodeLen.ToString();
                txtMat.Text = data.MatchLetter;
                txtCarType.Text = data.CarType;
                chcCarTPMS.Checked = data.ifTPMS;
            }
            catch (Exception ex)
            {
                HelperLog.Error<frmOption>(ex.Message, ex);
            }
        }

        private void bntCarClear_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtStartPoint.Text = string.Empty;
            txtLength.Text = string.Empty;
            txtMat.Text = string.Empty;
            txtCarType.Text = string.Empty;
        }

        private async void bntCarUp_Click(object sender, EventArgs e)
        {
            var data = new cartype_tpms()
            {
                MatchLetter = txtMat.Text.Trim(),
                CarType = txtCarType.Text.Trim(),
                ifTPMS = chcCarTPMS.Checked,
            };
            int.TryParse(txtID.Text.Trim(), out int id);
            data.ID = id;
            int.TryParse(txtStartPoint.Text.Trim(), out int CodeStartIndex);
            data.CodeStartIndex = CodeStartIndex;
            int.TryParse(txtLength.Text.Trim(), out int CodeLen);
            data.CodeLen = CodeLen;

            int k = await Service_cartype_tpms.Updateable(data);
            if (k > 0)
            {
                dgCarView.DataSource = await Service_cartype_tpms.GetCarTypes();
                txtID.Text = string.Empty;
                txtStartPoint.Text = string.Empty;
                txtLength.Text = string.Empty;
                txtMat.Text = string.Empty;
                txtCarType.Text = string.Empty;
            }
            else {
                MessageBox.Show("更新数据失败！");
            }
        }

        private async void bntCarAdd_Click(object sender, EventArgs e)
        {
            var data = new cartype_tpms()
            {
                MatchLetter = txtMat.Text.Trim(),
                CarType = txtCarType.Text.Trim(),
                ifTPMS = chcCarTPMS.Checked,
            };
            int.TryParse(txtStartPoint.Text.Trim(), out int CodeStartIndex);
            data.CodeStartIndex = CodeStartIndex;
            int.TryParse(txtLength.Text.Trim(), out int CodeLen);
            data.CodeLen = CodeLen;

            var tmp = await Service_cartype_tpms.Queryable(data.CarType);
            if (tmp != null)
            {
                MessageBox.Show("车型已经匹配");
                return;
            }

            int k = await Service_cartype_tpms.Insertable(data);
            if (k > 0)
            {
                dgCarView.DataSource = await Service_cartype_tpms.GetCarTypes();
                txtID.Text = string.Empty;
                txtStartPoint.Text = string.Empty;
                txtLength.Text = string.Empty;
                txtMat.Text = string.Empty;
                txtCarType.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("添加数据失败！");
            }
        }

        private async void bntCarDel_Click(object sender, EventArgs e)
        {
            int.TryParse(txtID.Text.Trim(), out int id);
            int k = await Service_cartype_tpms.Deleteable(id);
            if (k > 0)
            {
                dgCarView.DataSource = await Service_cartype_tpms.GetCarTypes();
                txtID.Text = string.Empty;
                txtStartPoint.Text = string.Empty;
                txtLength.Text = string.Empty;
                txtMat.Text = string.Empty;
                txtCarType.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("删除数据失败！");
            }
        }

        private async void bntSavePwd_Click(object sender, EventArgs e)
        {
            string pwd = txtNewPwd.Text.Trim();
            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("请输入新密码！");
                return;
            }
            if (pwd != txtAgreeNewPwd.Text.Trim())
            {
                MessageBox.Show("两次密码不一致！请重新输入");
                return;
            }

            int k = await Service_T_Psw.Updateable(pwd);
            if (k > 0)
                MessageBox.Show("密码修改成功！");
            else
                MessageBox.Show("密码修改失败！");
        }

        private async void bntPaSave_Click(object sender, EventArgs e)
        {
            string preMin = txtPreMin.Text.Trim();
            string preMain = txtPreMain.Text.Trim();

            if (string.IsNullOrEmpty(preMin) || !int.TryParse(preMin, out int min)
                || string.IsNullOrEmpty(preMain) || !int.TryParse(preMain, out int main)
                || min > main)
                MessageBox.Show("压力值不可为空,且最小值不能大于最大值");

            int minK = await Service_T_RunParam.Updata("StandardValue", "PreMinValue", preMin);
            int mainK = await Service_T_RunParam.Updata("StandardValue", "PreMaxValue", preMain);
            if (minK < 1)
                MessageBox.Show("最小值保存失败！");
            if (mainK < 1)
                MessageBox.Show("最大值保存失败！");
            if (minK > 0 && mainK > 0)
                MessageBox.Show("保存成功！");
        }

        private void dgProView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProID.Text = string.Empty;
            txtProType.Text = string.Empty;
            txtProNo.Text = string.Empty;

            try
            {
                DataGridView dataGrid = sender as DataGridView;
                if (e.RowIndex < 0 || e.ColumnIndex < 0 || dataGrid == null || e.RowIndex >= dataGrid.Rows.Count)
                    return;

                var rowView = dataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView;
                var tab = rowView.Row;

                var data = new cartype_prono();
                if (tab.Table.Columns.Contains("编号"))
                {
                    int.TryParse(tab["编号"].ToString(), out int id);
                    data.ID = id;
                }
                if (tab.Table.Columns.Contains("车型"))
                    data.CarType = tab["车型"].ToString();
                if (tab.Table.Columns.Contains("程序号"))
                    data.ProNum = tab["程序号"].ToString();

                txtProID.Text = data.ID.ToString();
                txtProType.Text = data.CarType;
                txtProNo.Text = data.ProNum;
            }
            catch (Exception ex)
            {
                HelperLog.Error<frmOption>(ex.Message, ex);
            }
        }

        private void bntProClear_Click(object sender, EventArgs e)
        {
            txtProID.Text = string.Empty;
            txtProType.Text = string.Empty;
            txtProNo.Text = string.Empty;
        }

        private async void bntProAdd_Click(object sender, EventArgs e)
        {
            var data = new cartype_prono
            {
                CarType = txtProType.Text.Trim(),
                ProNum = txtProNo.Text.Trim(),
            };

            var tmp = await Service_cartype_prono.Queryable(data.CarType);
            if (tmp != null)
            {
                MessageBox.Show("车型已经匹配");
                return;
            }

            int k = await Service_cartype_prono.Insertable(data);
            if (k > 0)
            {
                dgProView.DataSource = await Service_cartype_prono.Queryable();
                txtProID.Text = string.Empty;
                txtProType.Text = string.Empty;
                txtProNo.Text = string.Empty;
            }
            else
                MessageBox.Show("添加数据失败！");
        }

        private async void bntProUp_Click(object sender, EventArgs e)
        {
            var data = new cartype_prono
            {
                CarType = txtProType.Text.Trim(),
                ProNum = txtProNo.Text.Trim(),
            };
            int.TryParse(txtProID.Text.Trim(), out int id);
            data.ID = id;

            int k = await Service_cartype_prono.Updateable(data);
            if (k > 0)
            {
                dgProView.DataSource = await Service_cartype_prono.Queryable();
                txtProID.Text = string.Empty;
                txtProType.Text = string.Empty;
                txtProNo.Text = string.Empty;
            }
            else
                MessageBox.Show("修改数据失败！");
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void bntProDel_Click(object sender, EventArgs e)
        {
            int.TryParse(txtProID.Text.Trim(), out int id);

            int k = await Service_cartype_prono.Deleteable(id);
            if (k > 0)
            {
                dgProView.DataSource = await Service_cartype_prono.Queryable();
                txtProID.Text = string.Empty;
                txtProType.Text = string.Empty;
                txtProNo.Text = string.Empty;
            }
            else
                MessageBox.Show("修改数据失败！");
        }
    }
}
