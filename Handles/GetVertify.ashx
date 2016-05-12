<%@ WebHandler Language="C#" Class="GetVertify" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Threading;
public class GetVertify : IHttpHandler,IRequiresSessionState
{
    public void ProcessRequest (HttpContext context) {


        switch (context.Request["ver"].ToString())
        {   // 字符验证码
            case "alphasVertify":
                QMVertify.AbstractVertify vertify1 = new QMVertify.CharsVertify(QMVertify.CharSet.Alphas);
                System.IO.MemoryStream ms1 = vertify1.Draw();
                context.Session["alphasVertify"] = vertify1.result;
                ReturnBinary(context, ms1);
                break;
            // 汉字验证码
            case "chineseVertify":
                QMVertify.AbstractVertify vertify2 = new QMVertify.CharsVertify(QMVertify.CharSet.Chinese);
                System.IO.MemoryStream ms2 = vertify2.Draw();
                context.Session["chineseVertify"] = vertify2.result;
                ReturnBinary(context, ms2);
                break;
            // 数学计算验证码
            case "mathVertify":
                QMVertify.AbstractVertify vertify3 = new QMVertify.MathVertify(QMVertify.Num.Single);
                System.IO.MemoryStream ms3 = vertify3.Draw();
                context.Session["mathVertify"] = vertify3.result;
                ReturnBinary(context, ms3);
                break;
            // 多图选择验证码
            case "imagesVertify":
                QMVertify.AbstractVertify vertify4 = new QMVertify.ImagesVertify();
                System.IO.MemoryStream ms4 = vertify4.Draw(System.Drawing.Color.White);
                context.Session["imagesVertify"] = vertify4.result;
                ReturnBinary(context, ms4);
                break;
            // Gif 动画图像验证码
            case "gifVertify":
                QMVertify.AbstractVertify vertify5= new QMVertify.GifVertify(context.Request);
                System.IO.MemoryStream ms5 = new System.IO.MemoryStream();
                context.Session["gifVertify"] = vertify5.result;
                ReturnBinary(context, ms5);
                break;


        }

     
          
       
    }

    private static void ReturnBinary(HttpContext context, System.IO.MemoryStream ms)
    {
        if (ms.Length != 0)
        {
            context.Response.ContentType = "Image/Png";
            context.Response.BinaryWrite(ms.ToArray());
        }
    }
    

    public bool IsReusable {
        get {
            return false;
        }
    }

}