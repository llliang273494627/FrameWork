using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GACNew_VCU_Writer;
using GACNew_VCU_Writer_BLL;
using System.Configuration;
using Common.Logging;
using FrameWork.Model.Models;

namespace GACNew_VCU_Writer
{
    public partial class AddConfig : Form
    {
        private VCUconfig VCUItem;
        private T_VCUConfig t_VCUConfig;

        /// <summary>
        /// 日志对象
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(FrmMain));

        public AddConfig()
        {
            InitializeComponent();
            t_VCUConfig = null;
        }

        public AddConfig(VCUconfig VCUItem)
        {
            InitializeComponent();

            this.VCUItem = VCUItem;
        }

        public AddConfig(T_VCUConfig VCUItem)
        {
            InitializeComponent();

            this.t_VCUConfig = VCUItem;
        }

        private void AddConfig_Load(object sender, EventArgs e)
        {
            //if (VCUItem != null)
            //{
            //    this.tbMTOC.Text = VCUItem.MTOC;
            //    this.tbHardwareCode.Text = VCUItem.HardWareCode;
            //    this.tbsoftwareVersion.Text = VCUItem.SoftWareVersion;
            //    this.tbHW.Text = VCUItem.HW;
            //    this.tbElementCode.Text = VCUItem.ElementNum;
            //    this.tbSW.Text = VCUItem.SW;
            //    this.tbSign.Text = VCUItem.Sign;
            //}
            if (t_VCUConfig != null)
            {
                this.tbMTOC.Text = t_VCUConfig.mtoc;
                this.tbHardwareCode.Text = t_VCUConfig.hardwarecode;
                this.tbsoftwareVersion.Text = t_VCUConfig.softwareversion;
                this.tbHW.Text = t_VCUConfig.HW;
                this.tbElementCode.Text = t_VCUConfig.elementNum; ;
                this.tbSW.Text = t_VCUConfig.SW;
                this.tbSign.Text = t_VCUConfig.sign;
            }
        }

        /// <summary>
        /// 导入驱动文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_upfile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = " bin files(*.bin)|*.bin";
                dlg.CheckFileExists = false;
                dlg.CheckPathExists = false;
                dlg.FilterIndex = 0;
                dlg.RestoreDirectory = true;
                dlg.Title = "将driver文件数据导入到系统";
                
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.tbDriver.Text = dlg.SafeFileName;

                    string path = "";
                    if (!string.IsNullOrEmpty(this.tbDriver.Text.Trim()))
                    {
                        path = System.Configuration.ConfigurationManager.AppSettings["driverPos"] + this.tbDriver.Text;
                        //path = System.Configuration.ConfigurationSettings.AppSettings["driver"] + textBox3.Text;
                    }
                    //else
                    //{
                    //    MessageBox.Show("请填写driver名称", "提示");
                    //    return;
                    //}

                    if (this.tbDriver.Text.Trim() == this.tbWrite.Text.Trim())
                    {
                        MessageBox.Show("driver名称和din文件名称不能相同", "提示");
                        return;
                    }

                    string upPath = dlg.FileName.Trim();

                    //if (!File.Exists(path))
                    //{
                    //    MessageBox.Show("该driver文件名已存在，请重新命名", "提示");
                    //    return;
                    //}

                    File.Copy(upPath, path, true);
                    

                    //byte[] binchar = new byte[] { };
                    //FileStream Myfile = new FileStream(upPath, FileMode.Open, FileAccess.Read); 
                    //BinaryReader binreader = new BinaryReader(Myfile);

                    //int file_len = (int)Myfile.Length;//获取bin文件长度 
                    //binchar = binreader.ReadBytes(file_len);

                    //Myfile.Dispose();

                    //using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                    //{
                    //    fsWrite.Write(binchar, 0, binchar.Length);
                    //}

                    this.btDriver.Text = "已导入";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("存放文件夹不在，导入失败");
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
            
        }

        /// <summary>
        /// 导入写入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_upbin_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = " bin files(*.bin)|*.bin";
                dlg.CheckFileExists = false;
                dlg.CheckPathExists = false;
                dlg.FilterIndex = 0;
                dlg.RestoreDirectory = true;
                dlg.Title = "将bin文件数据导入到系统";


                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.tbWrite.Text = dlg.SafeFileName;

                    string path = "";
                    if (!string.IsNullOrEmpty(this.tbWrite.Text.Trim()))
                    {
                        path = System.Configuration.ConfigurationManager.AppSettings["writePos"] + this.tbWrite.Text;
                        // path = System.Configuration.ConfigurationSettings.AppSettings["bin"] + textBox4.Text;
                    }
                    else
                    {
                        MessageBox.Show("请填写应用文件名称", "提示");
                        return;
                    }

                    if (this.tbDriver.Text.Trim() == this.tbWrite.Text.Trim())
                    {
                        MessageBox.Show("driver名称和din文件名称不能相同", "提示");
                        return;
                    }

                    //if (File.Exists(path))
                    //{
                    //    MessageBox.Show("该应用文件名已存在，请重新命名", "提示");
                    //    return;
                    //}

                    string upPath = dlg.FileName.Trim();

                    File.Copy(upPath, path, true);

                    //byte[] binchar = new byte[] { };
                    //FileStream Myfile = new FileStream(upPath, FileMode.Open, FileAccess.Read);
                    //BinaryReader binreader = new BinaryReader(Myfile);
                    //int file_len = (int)Myfile.Length;//获取bin文件长度 
                    //binchar = binreader.ReadBytes(file_len);

                    //Myfile.Dispose();

                    //using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                    //{
                    //    fsWrite.Write(binchar, 0, binchar.Length);
                    //}

                    this.btWrite.Text = "已导入";
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("存放文件夹不在，导入失败");
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }            
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.tbMTOC.Text.Trim()) 
                    || string.IsNullOrEmpty(this.tbHardwareCode.Text.Trim()) 
                    || string.IsNullOrEmpty(this.tbsoftwareVersion.Text.Trim()) 
                    || string.IsNullOrEmpty(this.tbHW.Text.Trim()) 
                    || string.IsNullOrEmpty(this.tbElementCode.Text.Trim()) 
                    || string.IsNullOrEmpty(this.tbSW.Text.Trim()) 
                    || string.IsNullOrEmpty(this.tbDriver.Text.Trim()) 
                    || string.IsNullOrEmpty(this.tbWrite.Text.Trim()) 
                    || string.IsNullOrEmpty(this.tbCal.Text.Trim()))
                {
                    MessageBox.Show("请填写全部信息", "提示");
                    return;
                }

                string localConnectionString = ConfigurationManager.ConnectionStrings["localCnnStr"] + "";
                Configer Conbll = new Configer(localConnectionString);
                if (t_VCUConfig == null)
                {
                    if (this.btDriver.Text != "已导入" || this.btWrite.Text != "已导入" || this.btCal.Text != "已导入")
                    {
                        MessageBox.Show("请导入文件", "提示");
                        return;
                    }

                    // VCUconfig item = new VCUconfig();
                    // item.MTOC = this.tbMTOC.Text.ToUpper();
                    // item.HardWareCode = this.tbHardwareCode.Text.ToUpper();
                    // item.HW = this.tbHW.Text;
                    // item.SoftWareVersion = this.tbsoftwareVersion.Text;
                    // item.SW = this.tbSW.Text; ;
                    // item.ElementNum = this.tbElementCode.Text;
                    // item.Sign = this.tbSign.Text;

                    // item.DriverName = this.tbDriver.Text;
                    // item.BinName = this.tbWrite.Text;
                    // item.CalName = this.tbCal.Text;
                    // item.DriverPath = System.Configuration.ConfigurationManager.AppSettings["driverPos"];
                    // //item.DriverPath = System.Configuration.ConfigurationSettings.AppSettings["driver"];
                    // item.BinPath = System.Configuration.ConfigurationManager.AppSettings["writePos"];
                    //// item.BinPath = System.Configuration.ConfigurationSettings.AppSettings["bin"];
                    // item.CalPath = System.Configuration.ConfigurationManager.AppSettings["calPos"];

                    //int isRep = Conbll.RepeatVCUconfig(item);
                    // if (isRep > 0)
                    // {
                    //     MessageBox.Show("已经拥有该车型的数据了，请重新命名", "提示");
                    //     return;
                    // }
                    // else
                    // {
                    //     Conbll.SaveVCUconfig(item);
                    //     MessageBox.Show("新增成功");
                    // }  
                    T_VCUConfig item = new T_VCUConfig();
                    item.mtoc = this.tbMTOC.Text.ToUpper();
                    item.hardwarecode = this.tbHardwareCode.Text.ToUpper();
                    item.HW = this.tbHW.Text;
                    item.softwareversion = this.tbsoftwareVersion.Text;
                    item.SW = this.tbSW.Text; ;
                    item.elementNum = this.tbElementCode.Text;
                    item.sign = this.tbSign.Text;
                    item.drivername = this.tbDriver.Text;
                    item.binname = this.tbWrite.Text;
                    item.calname = this.tbCal.Text;
                    item.driverpath = System.Configuration.ConfigurationManager.AppSettings["driverPos"];
                    item.binpath = System.Configuration.ConfigurationManager.AppSettings["writePos"];
                    item.calpath = System.Configuration.ConfigurationManager.AppSettings["calPos"];
                    int tmpK = Comm.SqlComm.RepeatVCUconfig(item);
                    if (tmpK > 0)
                    {
                        MessageBox.Show("已经拥有该车型的数据了，请重新命名", "提示");
                        return;
                    }
                    int tmpAddCount =await Comm.SqlComm.SaveVCUconfig(item);
                    string msg = tmpAddCount > 0 ? "新增成功" : "新增失败";
                    MessageBox.Show(msg);
                }
                else
                {
                    //VCUconfig item = new VCUconfig();
                    //item.Id = VCUItem.Id;
                    //item.MTOC = this.tbMTOC.Text.ToUpper();
                    //item.HardWareCode = this.tbHardwareCode.Text.ToUpper();
                    //item.HW = this.tbHW.Text;
                    //item.SoftWareVersion = this.tbsoftwareVersion.Text;
                    //item.SW = this.tbSW.Text; ;
                    //item.ElementNum = this.tbElementCode.Text;
                    //item.Sign = this.tbSign.Text;

                    //item.DriverName = this.tbDriver.Text;
                    //item.BinName = this.tbWrite.Text;
                    //item.CalName = this.tbCal.Text;
                    //item.DriverPath = System.Configuration.ConfigurationManager.AppSettings["driverPos"];
                    ////item.DriverPath = System.Configuration.ConfigurationSettings.AppSettings["driver"];
                    //item.BinPath = System.Configuration.ConfigurationManager.AppSettings["writePos"];
                    //// item.BinPath = System.Configuration.ConfigurationSettings.AppSettings["bin"];
                    //item.CalPath = System.Configuration.ConfigurationManager.AppSettings["calPos"];
                    //Conbll.UpdateVCUconfig(item);
                    //MessageBox.Show("修改成功");

                    t_VCUConfig.mtoc= this.tbMTOC.Text.ToUpper();
                    t_VCUConfig.hardwarecode= this.tbHardwareCode.Text.ToUpper();
                    t_VCUConfig.HW = this.tbHW.Text;
                    t_VCUConfig.softwareversion = this.tbsoftwareVersion.Text;
                    t_VCUConfig.SW = this.tbSW.Text; ;
                    t_VCUConfig.elementNum = this.tbElementCode.Text;
                    t_VCUConfig.sign = this.tbSign.Text;
                    t_VCUConfig.drivername = this.tbDriver.Text;
                    t_VCUConfig.binname = this.tbWrite.Text;
                    t_VCUConfig.calname = this.tbCal.Text;
                    t_VCUConfig.driverpath = System.Configuration.ConfigurationManager.AppSettings["driverPos"];
                    t_VCUConfig.binpath = System.Configuration.ConfigurationManager.AppSettings["writePos"];
                    t_VCUConfig.calpath = System.Configuration.ConfigurationManager.AppSettings["calPos"];

                    int tmpK =await Comm.SqlComm.UpdateVCUconfig(t_VCUConfig);
                    string msg = tmpK > 0 ? "修改成功" : "修改失败";
                    MessageBox.Show(msg);
                }
                
                this.Dispose();
                this.Close();
               
            }
            catch (Exception)
            {
                
                throw;
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 导入标定文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_upcal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = " bin files(*.bin)|*.bin";
                dlg.CheckFileExists = false;
                dlg.CheckPathExists = false;
                dlg.FilterIndex = 0;
                dlg.RestoreDirectory = true;
                dlg.Title = "将标定文件数据导入到系统";


                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.tbCal.Text = dlg.SafeFileName;

                    string path = "";
                    if (!string.IsNullOrEmpty(this.tbCal.Text.Trim()))
                    {
                        path = System.Configuration.ConfigurationManager.AppSettings["calPos"] + this.tbCal.Text;
                        // path = System.Configuration.ConfigurationSettings.AppSettings["bin"] + textBox4.Text;
                    }
                    else
                    {
                        MessageBox.Show("请填写应用文件名称", "提示");
                        return;
                    }

                    if (this.tbWrite.Text.Trim() == this.tbCal.Text.Trim())
                    {
                        MessageBox.Show("driver名称和din文件名称不能相同", "提示");
                        return;
                    }

                    //if (File.Exists(path))
                    //{
                    //    MessageBox.Show("该应用文件名已存在，请重新命名", "提示");
                    //    return;
                    //}

                    string upPath = dlg.FileName.Trim();

                    File.Copy(upPath, path, true);

                    //byte[] binchar = new byte[] { };
                    //FileStream Myfile = new FileStream(upPath, FileMode.Open, FileAccess.Read);
                    //BinaryReader binreader = new BinaryReader(Myfile);
                    //int file_len = (int)Myfile.Length;//获取bin文件长度 
                    //binchar = binreader.ReadBytes(file_len);

                    //Myfile.Dispose();

                    //using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                    //{
                    //    fsWrite.Write(binchar, 0, binchar.Length);
                    //}

                    this.btCal.Text = "已导入";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("存放文件夹不在，导入失败");
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }            
        }
  
    }
}
