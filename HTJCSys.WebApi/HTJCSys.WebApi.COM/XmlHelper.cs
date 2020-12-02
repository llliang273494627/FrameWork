using System;
using System.Collections.Generic;
using System.Xml;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace COM
{
    public class XmlHelper
    {
        #region 私有变量
        //建立xml文档
        XmlDocument xmlDoc;
        //XML文件路径
        string path;
        #endregion

        #region 构造函数
        public XmlHelper()
        {
            this.xmlDoc = new XmlDocument();
            this.path = "";
            this.xmlDoc.Load(this.path);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName">本地的xml文件路径</param>
        public XmlHelper(String filePath)
        {
            this.xmlDoc = new XmlDocument();
            this.path = filePath;
            this.xmlDoc.Load(this.path);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Path">本地的xml文件路径</param>
        /// <param name="fileName">xml文件名</param>
        public XmlHelper(String Path,string fileName)
        {
            this.xmlDoc = new XmlDocument();
            if (string.IsNullOrEmpty(Path))
            {
                this.path = "" + fileName;
            }
            else
            {
                this.path = Path+fileName;
            }
            this.xmlDoc.Load(this.path);
        }
        #endregion

        #region 插入节点
        /// <summary>
        /// 插入节点
        /// </summary>
        /// <param name="nodePath">结点路径</param>
        /// <param name="node">新建的结点名称</param>
        /// <param name="hashTable">属性名称值对</param>
        public void Insert(string nodePath, string node, Hashtable hashTable)
        {
            XmlNode xn = this.xmlDoc.SelectSingleNode(nodePath);
            XmlElement newNode = this.xmlDoc.CreateElement(node);

            foreach (string item in hashTable.Keys)
            {
                newNode.SetAttribute(item, hashTable[item] + "");
            }

            xn.AppendChild(newNode);
            this.xmlDoc.Save(this.path);
        }
        #endregion

        #region 修改节点
        /// <summary>
        /// 修改节点值
        /// </summary>
        /// <param name="nodePath"></param>
        /// <param name="value"></param>
        public void UpdateInnerText(string nodePath, string value)
        {
            XmlNode node = this.xmlDoc.SelectSingleNode(nodePath);
            node.InnerText = value;

            this.xmlDoc.Save(this.path);//保存。
        }

        /// <summary>
        /// 修改属性值
        /// </summary>
        /// <param name="nodePath">节点</param>
        /// <param name="attribute">属性名</param>
        /// <param name="value">修改的值</param>
        public void UpdateAttribute(string nodePath, string attribute, string value)
        {
            XmlElement xe = (XmlElement)this.xmlDoc.SelectSingleNode(nodePath);
            if (xe.Attributes != null || xe.Attributes.Count != 0)
            {
                xe.SetAttribute(attribute, value);
            }
            this.xmlDoc.Save(this.path);
        }

        /// <summary>
        /// 根据key修改value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void UpdateValueByKey(string key, string value)
        {
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/configuration/appSettings/add");

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value == key)
                {
                    xmlNode.Attributes["value"].InnerText = value;
                    this.xmlDoc.Save(this.path);//保存。
                    break;
                }
            }
        }

        /// <summary>
        /// 根据key修改value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void UpdateValueByKey(string nodePath,string key, string value)
        {
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes(nodePath);

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value == key)
                {
                    xmlNode.Attributes["value"].InnerText = value;
                    this.xmlDoc.Save(this.path);//保存。
                    break;
                }
            }
        }
        #endregion

        #region 查询节点
        /// <summary>
        /// 根据节点查值
        /// </summary>
        /// <param name="nodePath"></param>
        /// <returns></returns>
        public string SelectValue(string nodePath)
        {
            string url = string.Empty;
            XmlNode node = this.xmlDoc.SelectSingleNode(nodePath);
            url = node.InnerText;
            return url;
        }

        /// <summary>
        /// 查询孩子结点
        /// </summary>
        /// <param name="nodePath">父结点的路径</param>
        /// <returns>孩子结点集合</returns>
        public XmlNodeList SelectChildNodes(string nodePath)
        {
            string value = String.Empty;
            XmlNode node = this.xmlDoc.SelectSingleNode(nodePath);
            XmlNodeList lstNode = node.ChildNodes;
            return lstNode;
        }

        /// <summary>
        /// 根据属性查询结点
        /// </summary>
        /// <param name="atrribute"></param>
        /// <returns></returns>
        public List<XmlNode> SelectNodeByAttribute(string parentsNodePath, string attributeName, string attributeValue)
        {
            XmlNodeList xmlNodeList = this.SelectChildNodes(parentsNodePath);

            List<XmlNode> lstXmlNode = new List<XmlNode>();
            foreach (XmlNode item in xmlNodeList)
            {
                if (item.Attributes[attributeName].Value == attributeValue)
                {
                    lstXmlNode.Add(item);
                }
            }

            return lstXmlNode;
        }

        /// <summary>
        /// 根据key查询value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string SelectValueByKey(string key)
        {
            string value = String.Empty;
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/configuration/appSettings/add");

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value == key)
                {
                    value = xmlNode.Attributes["value"].Value + "";
                    break;
                }
            }

            return value;
        }

        /// <summary>
        /// xml配置文件，根据key查询value
        /// </summary>
        /// <param name="nodePath">xml配置文件节点</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string SelectValueByKey(string nodePath, string key)
        {
            string value = String.Empty;
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes(nodePath);

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value == key)
                {
                    value = xmlNode.Attributes["value"].Value + "";
                    break;
                }
            }

            return value;
        }

        /// <summary>
        /// 检查键值对是否存在
        /// </summary>
        /// <param name="nodePath"></param>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public bool CheckExist(string nodePath, string innerText)
        {
            bool isExist = false;

            XmlNodeList xmlNodeList = this.SelectChildNodes(nodePath);

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.InnerText == innerText)
                {
                    isExist = true;
                    break;
                }
            }

            return isExist;
        }
        #endregion

        #region 删除节点
        public void DeleteAllNode(string nodePath)
        {
            XmlNode xn = this.xmlDoc.SelectSingleNode(nodePath);
            //XmlElement xe = (XmlElement)xn;
            for (int i = xn.ChildNodes.Count - 1; i >= 0; i--)
            {
                xn.RemoveChild(xn.ChildNodes[i]);
            }

            this.xmlDoc.Save(this.path);
        }
        #endregion

        /*************************************************************************/

        #region 序列化到文件
        /// <summary>
        /// 序列化到文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sourceObj"></param>
        /// <param name="type"></param>
        /// <param name="xmlRootName"></param>
        public void SaveToXml(string filePath, object sourceObj, Type type, string xmlRootName)
        {
            if (!string.IsNullOrEmpty(filePath) && sourceObj != null)
            {
                type = type ?? sourceObj.GetType();

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer xmlSerializer = string.IsNullOrEmpty(xmlRootName) ? new XmlSerializer(type) : new XmlSerializer(type, new XmlRootAttribute(xmlRootName));
                    xmlSerializer.Serialize(writer, sourceObj);
                }
            }
        }
        #endregion

        #region 从文件反序列化
        /// <summary>
        /// 从文件反序列化
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object LoadFromXml(string filePath, Type type)
        {
            object result = null;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(type);
                    result = xmlSerializer.Deserialize(reader);
                }
            }

            return result;
        }
        #endregion

    }
}
