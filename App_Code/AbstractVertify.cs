using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace QMVertify
{
    /// <summary>
    /// 字符集枚举
    /// </summary>
    public enum CharSet
    {
        /// <summary>
        /// 阿拉伯数字和字母集合
        /// </summary>
         Alphas  = 0
        ,
        /// <summary>
        /// 汉字集合
        /// </summary>
        Chinese = 1
    }

    /// <summary>
    /// 使用数学计算验证码时，使用几位数字
    /// </summary>
    public enum Num
    {
        /// <summary>
        /// 一位数字
        /// </summary>
        Single = 10
       ,
        /// <summary>
        /// 两位数字
        /// </summary>
        Double = 100
    }

    /// <summary>
    /// 创建验证码抽象类
    /// </summary>
    public abstract class AbstractVertify
    {
        // 定义验证码的长度
        private const int length = 4;
        protected Random R = new Random();


        /// <summary>
        /// 创建随机背景的验证码
        /// </summary>
        /// <returns></returns>
        public virtual MemoryStream Draw()
        {
            return Draw(Color.FromArgb(R.Next(255), R.Next(255), R.Next(255)));
        }

        /// <summary>
        /// 创建自定义背景颜色的验证码
        /// </summary>
        /// <param name="BackColor">背景颜色</param>
        /// <returns>GIF格式的内存流</returns>
        public virtual MemoryStream Draw(Color BackColor)
        {
            Bitmap image = new Bitmap(120, 40);
            Graphics g = Graphics.FromImage(image); 
            g.Clear(BackColor);                      
            
            //进行填充        
            AddChars(image, g);
            AddCurve(g);
            AddPixel(image);

            //返回GIF内存流
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms;
        }


        /// <summary>
        /// 给验证码添加文字
        /// </summary>
        /// <param name="image"></param>
        /// <param name="g"></param>
        private void AddChars(Bitmap image, Graphics g)
        {
            // 定义字体和笔刷 
            Font font = new Font("Arial", 18, FontStyle.Bold);   
            LinearGradientBrush brush = new LinearGradientBrush(
                                            new Rectangle(0, 0, image.Width, image.Height)
                                            , Color.Blue
                                            , Color.Yellow
                                            , 1.2f
                                            , true);

            // 定义矩阵，用于进行文字旋转
            Matrix mx = new Matrix();

            // 定义文本起始坐标(startX,startY)、每个文字间隔为divide，字体旋转角度degree
            int startX = 0
                , startY = 8
                , divide = 30
                , degree = 0;
            for (int i = 0; i < length; i++)
            {
                brush.LinearColors = new Color[] { Color.FromArgb(R.Next(255), R.Next(255), R.Next(255)), Color.FromArgb(R.Next(255), R.Next(255), R.Next(255)) };

                degree = R.Next(8);
                mx.Rotate(degree);
                g.Transform = mx;

                g.DrawString(GetChar(), font, brush, new Point(startX, startY));

                mx.Rotate(-degree);
                startX += divide;
            }

        }

        /// <summary>
        /// 添加曲线
        /// </summary>
        /// <param name="g"></param>
        private void AddCurve(Graphics g)
        {
            Pen pen = new Pen(Color.FromArgb(R.Next()), 3);

            Point p1 = new Point(1, R.Next(40));
            Point p2 = new Point(20, R.Next(40));
            Point p3 = new Point(60, R.Next(40));
            Point p4 = new Point(70, R.Next(40));
            Point p5 = new Point(120, R.Next(40));
            Point[] curvePoints = { p1, p2, p3, p4, p5 };
            // 张力
            float tension = 1.2f; 
            g.DrawCurve(pen, curvePoints, tension);
        }

        /// <summary>
        /// 添加前景像素点
        /// </summary>
        /// <param name="image"></param>
        private void AddPixel(Bitmap image)
        {

            for (int i = 0; i <= 60; i++)
            {
                int xPoint = R.Next(image.Width);
                int yPoint = R.Next(image.Height);

                image.SetPixel(xPoint, yPoint, Color.FromArgb(R.Next(200),R.Next(200),R.Next(200)));
            }
        }

        /// <summary>
        /// 获取验证码的结果
        /// </summary>
        public abstract string result { get; }

        /// <summary>
        /// 生成验证码时，获取单个字符的方法，需要在子类进行重写
        /// </summary>
        /// <returns></returns>
        public abstract string GetChar();
        

    }
}