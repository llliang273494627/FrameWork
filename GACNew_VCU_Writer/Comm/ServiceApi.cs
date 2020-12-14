using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACNew_VCU_Writer.Comm
{
    public class ServiceApi
    {
        public static async Task<Bitmap> GetQRCodeBitmap(string code)
        {
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("Value", code);
                var res = await HelperHttp.ApiPost<MessageModel<string>>("http://192.168.0.100:8099/api/V2/Apb/GetQRCodeBase64Str", dic);
                if (res.Success)
                {
                    var bys = Convert.FromBase64String(res.Response);
                    MemoryStream memory = new MemoryStream(bys);
                    Bitmap bitmap = new Bitmap(memory);
                    return bitmap;
                }
                else
                {
                    Log.Error($"请求接口失败！code={code}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Base64转Bitmap失败！", ex);
                return null;
            }
        }
    }
}
