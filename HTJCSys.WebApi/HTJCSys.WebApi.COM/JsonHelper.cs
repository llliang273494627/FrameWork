using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
namespace COM
{
    public class JsonHelper
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,//忽略Json序列化循环
            NullValueHandling = NullValueHandling.Include,//
        };
        /// <summary>
        /// JSON序列化 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string JsonSerializer(object obj)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(obj);
        }

        /// <summary>
        /// JSON反序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static object JsonDeSerializer(string json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.DeserializeObject(json);
        }

        #region 泛型序列化和反序列化
        /// <summary>
        /// 泛型序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string JsonSerializer<T>(T t)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(t);
        }

        /// <summary>
        /// 泛型反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T JsonDeSerializer<T>(string strJson)
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //return js.Deserialize<T>(strJson);
            return (T)JsonConvert.DeserializeObject(strJson, typeof(T),settings);
        } 
        #endregion

        /// <summary>
        /// 泛型序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string JsonSerializerObj<T>(T t)
        {
            string str = JsonConvert.SerializeObject(t, typeof(T),settings);
            return str;
        }

        /// <summary>
        /// 泛型序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string JsonSerializerObj(object t)
        {
            string str = JsonConvert.SerializeObject(t, settings);
            return str;
        }

        /// <summary>
        /// 泛型反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T JsonDeSerializerObj<T>(string strJson)
        {
            T t = JsonConvert.DeserializeObject<T>(strJson,settings);
            return t;
        }
        
    }
}
