using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace GACNew_VCU_Writer
{
    public class Parameter
    {
        #region 属性

        private string driver;
        /// <summary>
        /// 驱动文件名
        /// </summary>
        public string Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        private string write;
        /// <summary>
        /// 应用文件
        /// </summary>
        public string Write
        {
            get { return write; }
            set { write = value; }
        }

        private string cal;
        /// <summary>
        /// 标定文件
        /// </summary>
        public string Cal
        {
            get { return cal; }
            set { cal = value; }
        }

        private int num;
        /// <summary>
        /// 设备号
        /// </summary>
        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        private Label label = new Label();
        /// <summary>
        /// 标签属性
        /// </summary>
        public Label Label_Attribute
        {
            get { return label; }
            set { label = value; }
        }

        private Label lbResult = new Label();
        /// <summary>
        /// 结果属性
        /// </summary>
        public Label LbResult_Attribute
        {
            get { return lbResult; }
            set { lbResult = value; }
        }

        private ProgressBar progressBar = new ProgressBar();
        /// <summary>
        /// 进度条属性
        /// </summary>
        public ProgressBar ProgressBar_Attribute
        {
            get { return progressBar; }
            set { progressBar = value; }
        }

        private Button button = new Button();
        /// <summary>
        /// 按钮属性
        /// </summary>
        public Button Button_Attribute
        {
            get { return button; }
            set { button = value; }
        }

        private int output = 0;
        /// <summary>
        /// 输出
        /// </summary>
        public int Output
        {
            get { return output; }
            set { output = value; }
        }

        private int input = 0;
        /// <summary>
        /// 输入
        /// </summary>
        public int Input
        {
            get { return input; }
            set { input = value; }
        }

        private bool canUse = true;
        /// <summary>
        /// 多次执行的退出标识，类似互斥锁
        /// </summary>
        public bool CanUse
        {
            get { return canUse; }
            set { canUse = value; }
        }

        private object olock = new object();
        /// <summary>
        /// 锁住执行方法的对象
        /// </summary>
        public object Olock
        {
            get { return olock; }
            set { olock = value; }
        }

        private ButtonClickDelegate buttonClickDelegate = null;
        /// <summary>
        /// 按钮点击委托
        /// </summary>
        public ButtonClickDelegate ButtonClickDelegate_Prop
        {
            get { return buttonClickDelegate; }
            set { buttonClickDelegate = value; }
        }

        private Queue queReceiveMsg = new Queue();
        /// <summary>
        /// 接收返回消息的队列
        /// </summary>
        public Queue QueReceiveMsg
        {
            get { return queReceiveMsg; }
            set { queReceiveMsg = value; }
        }

        private List<string> receiveList = new List<string>();
        /// <summary>
        /// 接收返回消息的队列
        /// </summary>
        public List<string> ReceiveList
        {
            get { return receiveList; }
            set { receiveList = value; }
        }

        private string vin;
        /// <summary>
        /// VIN
        /// </summary>
        public string VIN
        {
            get { return vin; }
            set { vin = value; }
        }

        private string element;
        /// <summary>
        /// 零件条码信息
        /// </summary>
        public string Element
        {
            get { return element; }
            set { element = value; }
        }

        private string cRC1;

        public string CRC1
        {
            get { return cRC1; }
            set { cRC1 = value; }
        }

        private string cRC2;

        public string CRC2
        {
            get { return cRC2; }
            set { cRC2 = value; }
        }

        private string cRC3;

        public string CRC3
        {
            get { return cRC3; }
            set { cRC3 = value; }
        }


        #endregion

        #region 构造函数

        public Parameter()
        {

        }

        public Parameter(int output, int input)
        {
            this.output = output;
            this.input = input;
        }

        public Parameter(string driver, string write, string cal, int num, Label label, ProgressBar progressBar, Button button,string element)
        {
            this.driver = driver;
            this.write = write;
            this.cal = cal;
            this.label = label;
            this.progressBar = progressBar;
            this.button = button;
            this.num = num;
            this.element = element;
        }

        public Parameter(string driver, string write, string cal, int num, Label label,Label result, ProgressBar progressBar, Button button, string vin, string element)
        {
            this.driver = driver;
            this.write = write;
            this.cal = cal;
            this.label = label;
            this.lbResult = result;
            this.progressBar = progressBar;
            this.button = button;
            this.num = num;
            this.vin = vin;
            this.element = element;
        }

        #endregion
    }
}
