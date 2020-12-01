using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GACNew_VCU_Writer
{
    public class DefineFlower
    {
        #region ID

        private int id = 0;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        #endregion

        #region Flowname

        private string flowName = string.Empty;

        public string FlowName
        {
            get { return flowName; }
            set { flowName = value; }
        }

        #endregion

        #region SendCmd

        private string sendCmd = string.Empty;

        public string SendCmd
        {
            get { return sendCmd; }
            set { sendCmd = value; }
        }

        #endregion

        #region WaitTIme

        private int waitTime = 0;

        public int WaitTime
        {
            get { return waitTime; }
            set { waitTime = value; }
        }

        #endregion

        #region ReceiveCmd

        private string receiveCmd = string.Empty;

        public string ReceiveCmd
        {
            get { return receiveCmd; }
            set { receiveCmd = value; }
        }

        #endregion

        #region ReceiveCmdFromVCI

        private List<string> lstVCICmd = new List<string>();


        #endregion

        #region Enabled

        private Boolean enabled = false;

        public Boolean Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        #endregion

        #region SendAddress

        private uint sendAddress = 0;

        public uint SendAddress
        {
            get { return sendAddress; }
            set { sendAddress = value; }
        }

        #endregion

        #region CANIND

        private uint canind = 0;
        /// <summary>
        /// CAN通道
        /// </summary>
        public uint CANIND
        {
            get { return canind; }
            set { canind = value; }
        }

        #endregion

        #region SleepTime

        private int sleepTime = 0;

        public int SleepTime
        {
            get { return sleepTime; }
            set { sleepTime = value; }
        }

        #endregion

        #region ReceiveNum

        private int receiveNum = 0;

        public int ReceiveNum
        {
            get { return receiveNum; }
            set { receiveNum = value; }
        }

        #endregion

        #region ReceiveMsg

        private string receiveMsg = string.Empty;

        public string ReceiveMsg
        {
            get { return receiveMsg; }
            set { receiveMsg = value; }
        }

        #endregion

        #region 构造函数

        public DefineFlower()
        {

        }

        public DefineFlower(int id, string flowName, string sendCmd, int waitTime, string receiveCmd, Boolean enabled, string carType)
        {
            this.id = id;
            this.flowName = flowName;
            this.sendCmd = sendCmd;
            this.waitTime = waitTime;
            this.receiveCmd = receiveCmd;
            this.enabled = enabled;
            //this.sendAddress = carType;
        }

        #endregion
    }
}
