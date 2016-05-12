using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Data;
using System.Data.SqlClient;

namespace QMVertify
{
    /// <summary>
    /// 多图选择验证码
    /// </summary>
    public class ImagesVertify : QMVertify.AbstractVertify
    {
        private string _result = "";

        //从DB中读取数据
        private DataTable GetTagPath(string randomName)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT vcTag,vcPath FROM ( SELECT TOP (4) id, vcTag, vcPath FROM [12306] AS A WHERE (vcTag <> @name) ORDER BY NEWID() UNION ALL SELECT TOP (2) id,vcTag,vcPath FROM [12306] AS B WHERE (vcTag =@name) ORDER BY NEWID() )  as temp";

            cmd.Parameters.AddWithValue("@name", randomName);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // 获取随机标签
        private string GetRandomName()
        {

            Random R = new Random();
            switch (R.Next(3))
            {
                case 0:  return "篮球";
                case 1:  return "橘子";
                case 2:
                default: return "手机";
            }
        }

        /// <summary>
        /// 画出随机背景颜色的图片
        /// </summary>
        /// <returns></returns>
        public override MemoryStream Draw()
        {
            return  Draw(Color.FromArgb(R.Next(255), R.Next(255), R.Next(255)));
        }

        /// <summary>
        /// 画出指定背景颜色的图片
        /// </summary>
        /// <param name="BackColor"></param>
        /// <returns></returns>
        public override MemoryStream Draw(System.Drawing.Color BackColor)
        {
            string randomName = GetRandomName();
            DataTable dt = GetTagPath(randomName);

            Bitmap image = new Bitmap(300, 200);
            Graphics g = Graphics.FromImage(image);
            g.Clear(BackColor);

            Font font = new Font("Arial", 10, FontStyle.Bold);

            SolidBrush solidBrush = new SolidBrush(Color.Gray);

            LinearGradientBrush brush = new LinearGradientBrush(
                                            new Rectangle(0, 0, image.Width, image.Height)
                                            , Color.Blue
                                            , Color.Yellow
                                            , 1.2f
                                            , true);
            Pen p = new Pen(brush);
            g.DrawString("请点击下图中所有的  " + randomName, font, solidBrush, 10, 10);
            g.DrawLine(p, new Point(10, 30), new Point(290, 30));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == randomName)
                {
                    _result += i + 1;
                }

                if (i < 3)
                {
                    g.DrawImage(Image.FromFile(dt.Rows[i][1].ToString()), 10 + 95 * i, 35, 90, 80);
                }
                else
                {
                    g.DrawImage(Image.FromFile(dt.Rows[i][1].ToString()), 10 + 95 * (i - 3), 120, 90, 80);
                }
            }
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            return ms;
        }
        /// <summary>
        /// 获取验证码的结果
        /// </summary>
        public override string result
        {
            get { return _result; }
        }

        /// <summary>
        /// 生成验证码时获取单个字符的方法
        /// </summary>
        /// <returns></returns>
        public override string GetChar()
        {            
            return "";
        }
    }
}