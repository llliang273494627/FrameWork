using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Intermec.DeviceManagement.SmartSystem;
using System.IO;

namespace HTJCSys.PDA
{
    #region //Models SystemIdentity
    [Serializable]
    [XmlRootAttribute("Subsystem")]
    public class SystemIdentity
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlIgnore]
        [XmlAttribute("Error")]
        public string Error { get; set; }

        [XmlElement("Group")]
        public Group Group { get; set; }

        /// <summary>
        /// 获取设备型号
        /// </summary>
        /// <returns>大写的型号</returns>
        public string GetDeviceModel()
        {
            return GetDeviceModel(true);
        }

        /// <summary>
        /// 获取设备型号
        /// </summary>
        /// <param name="isUpper">是否大写</param>
        /// <returns>型号</returns>
        public string GetDeviceModel(bool isUpper)
        {
            return GetDeviceModel(this,isUpper);
        }

        /// <summary>
        /// 获取设备型号
        /// </summary>
        /// <param name="info">设备对象</param>
        /// <param name="isUpper">是否大写</param>
        /// <returns>型号</returns>
        public static string GetDeviceModel(SystemIdentity info,bool isUpper)
        {
            string m = null;
            if (info != null && info.Group != null && info.Group.Fields != null)
            {
                List<Field> list = info.Group.Fields;
                foreach (Field item in list)
                {
                    m += item.Value.Trim();
                }
            }
            return isUpper ? m.ToUpper() : m;
        }

        /// <summary>
        /// 获取设备型号
        /// </summary>
        /// <param name="info">设备对象</param>
        /// <returns>大写的型号</returns>
        public static string GetDeviceModel(SystemIdentity info)
        {
            return GetDeviceModel(info,true);
        }

        public static SystemIdentity GetFromFile(string xmlPath)
        {
            string systeminfo = null;
            using (StreamReader sr = new StreamReader(xmlPath))
            {
                if (sr != null)
                {
                    systeminfo = sr.ReadToEnd();
                }
            }
            return GetFromText(systeminfo);
        }


        public static SystemIdentity GetFromText(string xmlConfText)
        {
            SystemIdentity info = null;
            string systeminfo = xmlConfText;
            if (string.IsNullOrEmpty(systeminfo))
            {
                return null;
            }

            ITCSSApi ss = new ITCSSApi();
            int size = 4096;
            StringBuilder builder = new StringBuilder(size);
            uint ret = ss.Get(systeminfo, builder, ref size, 10);
            if (ret == ITCSSErrors.E_SS_SUCCESS)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(builder.ToString().Trim());
                    writer.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    StreamReader reader = new StreamReader(stream);

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SystemIdentity));
                    info = (SystemIdentity)xmlSerializer.Deserialize(reader);

                    reader.Close();
                    reader.Close();

                    writer.Close();
                    writer.Dispose();
                }
            }
            return info;
        }
    }
    #endregion

    #region //Models Group
    [Serializable]
    [XmlType("Group")]
    public class Group
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlIgnore]
        [XmlAttribute("Error")]
        public string Error { get; set; }

        [XmlElement("Field")]
        public List<Field> Fields { get; set; }
    }
    #endregion

    #region //Models Field
    [Serializable]
    [XmlType("Field")]
    public class Field
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlIgnore]
        [XmlAttribute("Error")]
        public string Error { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
    #endregion
}
