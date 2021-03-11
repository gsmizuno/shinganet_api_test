using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;

namespace SHINGA_API_TEST
{
    public class GET_STU : HttpTaskAsyncHandler
    {
        HttpContext _context;

        /// <summary>
        /// ハンドラーを使用するには、Web の Web.config ファイルでこの 
        /// ハンドラーを設定し、IIS に登録する必要があります。詳細については、
        /// 次のリンクをご覧ください: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        
        public bool IsReusable
        {
            // マネージド ハンドラーが別の要求に再利用できない場合は、false を返します。
            // 要求ごとに保存された状態情報がある場合、通常、これは false になります。
            get { return true; }
        }

        public override async Task ProcessRequestAsync(HttpContext context)
        {
            _context = context;

            await ApiCennect();
        }

        public async Task ApiCennect()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    request_data req = new request_data();
                    req.class_room_id = null;
                    req.id = new List<int>();
                    req.id.Add(403473);
                    req.id.Add(403472);
                    req.id.Add(403445);
                    req.sei = "未";
                    req.mei = string.Empty;
                    req.sei_kana = string.Empty;
                    req.mei_kana = string.Empty;
                    req.limit = 20;
                    req.offset = 0;

                    string json = string.Empty;
                    using (var stream = new MemoryStream())
                    {
                        var serializer = new DataContractJsonSerializer(typeof(request_data));
                        serializer.WriteObject(stream, req);

                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        string val = Encoding.UTF8.GetString(stream.ToArray());

                        json = val;

                        Console.WriteLine(json);
                    }


                    //string json = @"{\""class_room_id\"":11,\""id\"":[1111,2222,3333],\""sei\"":\""\"",\""mei\"":\""\"",\""sei_kana\"":\""\"",\""mei_kana\"":\""\"" }";
                    var accept = new MediaTypeWithQualityHeaderValue("application/json");
                    httpClient.DefaultRequestHeaders.Accept.Add(accept);

                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "http://163.43.244.22/api/get_children"))
                    {
                        request.Headers.Add("ContentType", "application/json");
                        request.Headers.TryAddWithoutValidation("Authorization", string.Format("Bearer {0}" ,"i89u-gTV+q50MaCFSHrZy1O/EQPPinZl"));

                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await httpClient.SendAsync(request);

                        string responseString = await response.Content.ReadAsStringAsync();

                        if (responseString.Contains("error"))
                        {


                            responseProccess(_context);
                        }

                        string result = responseString;

                        try
                        {
                            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(result)))
                            {
                                //var serializer = new DataContractJsonSerializer(typeof(data_billing));
                                //resultJson = (data_billing)serializer.ReadObject(ms);

                            }
                        }
                        catch (Exception ex)
                        {

                            responseProccess(_context);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                //Common.WriteLog(ex.Message);
            }
        }

        private void responseProccess(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //JSONデータを書き込むためのMemoryStreamを作成
            using (MemoryStream stream = new MemoryStream())
            {

            }
        }
    }
}