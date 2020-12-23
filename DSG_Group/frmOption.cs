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

        /// <summary>
        /// 首次加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void frmOption_Load(object sender, EventArgs e)
        {
            datagridRunParam.AllowUserToAddRows = false;
            datagridRunParam.AllowUserToDeleteRows = false;
            datagridRunParam.AllowUserToOrderColumns = false;
            datagridRunParam.ReadOnly = true;

            List<string> groups =await ServiceT_RunParam.GetGroups();
            combRunGroup.Items.AddRange(groups.ToArray());
        }

        /// <summary>
        /// 选择下拉框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void combRunGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            var group = combRunGroup.Text.Trim();
            var tab = await ServiceT_RunParam.GetRunParams(group);
            datagridRunParam.DataSource = tab;
        }

        private void datagridRunParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
            }
            catch (Exception ex)
            {
                HelperLog.Error<frmOption>(ex.Message, ex);
            }
            
        }

    }
}
