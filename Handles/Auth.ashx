<%@ WebHandler Language="C#" Class="Auth" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Linq;

public class Auth : IHttpHandler,IReadOnlySessionState
{
    
    public void ProcessRequest (HttpContext context) {

        string requestVertifyData = null;
        string sessionVertify=null;
        
        // 阿拉伯字符验证
        if (context.Request["alphasVertify"] != null)
        {
            requestVertifyData = context.Request["alphasVertify"];
            sessionVertify = context.Session["alphasVertify"].ToString();
            Compare(context, requestVertifyData, sessionVertify);
            return;
        }

        // 汉字验证
        if (context.Request["chineseVertify"] != null)
        {
            requestVertifyData = context.Request["chineseVertify"];
            sessionVertify = context.Session["chineseVertify"].ToString();
            Compare(context, requestVertifyData, sessionVertify);
            return;
        }
        
        // 数学计算验证
        if (context.Request["mathVertify"] != null)
        {
            requestVertifyData = context.Request["mathVertify"];
            sessionVertify = context.Session["mathVertify"].ToString();
            Compare(context, requestVertifyData, sessionVertify);
            return;
        }
        // 多图片选择验证
        if (context.Request["imagesVertify"] != null)
        {
            requestVertifyData = context.Request["imagesVertify"].ToString();
            sessionVertify = context.Session["imagesVertify"].ToString();
            if (requestVertifyData == sessionVertify)
            {
                context.Response.Write("OK");
                return;
            }

            char[] arr = requestVertifyData.ToCharArray();
            var result = (from a in arr
                          orderby a ascending
                          select a
                         ).Distinct();
            string str = "";
            foreach (char item in result)
            {
                str += item.ToString();
            }

            if (str == sessionVertify)
            {
                context.Response.Write("OK");
            }
            else
            {
                context.Response.Write("NO");
            }
        }

        // Gif动画验证
        if (context.Request["gifVertify"] != null)
        {
            requestVertifyData = context.Request["gifVertify"].ToString();
            sessionVertify = context.Session["gifVertify"].ToString();
            Compare(context, requestVertifyData, sessionVertify);
            return;
        }
        
    }

    private static void Compare(HttpContext context, string requestVertifyData, string sessionVertify)
    {
        if (requestVertifyData.ToUpper() == sessionVertify.ToUpper())
        {
            context.Response.Write("OK");
        }
        else
        {
            context.Response.Write("NO");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}


