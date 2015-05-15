using System.IO;
using Newtonsoft.Json;
 
namespace QuotationApp.Web.Extensions
{
    public static class ObjectExtensions
    {
        //https://lostechies.com/erichexter/2012/11/29/loading-knockout-view-models-from-asp-net-mvc/
        public static string ToJson(this object obj)
        {
            JsonSerializer js = JsonSerializer.Create(new JsonSerializerSettings());
            var jw = new StringWriter();
            js.Serialize(jw, obj);            
            return jw.ToString();
        }
         
    }
}