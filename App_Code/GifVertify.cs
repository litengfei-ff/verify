using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using Gif.Components;

namespace QMVertify
{

    /// <summary>
    /// Gif动画验证码
    /// </summary>
    public class GifVertify :QMVertify.AbstractVertify
    {
        string _result = "";
        public GifVertify(HttpRequest request) 
        {
            string currentPath = request.PhysicalApplicationPath;
            string[] mFrames = new string[] { currentPath + @"Images\other\1.jpg", currentPath + @"Images\other\3.jpg", currentPath + @"Images\other\2.jpg" };

            string verPath = currentPath + @"Images\index\ver.gif";

            FileInfo file = new FileInfo(verPath);

            if (file.Exists)
            {
                file.Delete();
            }

            AnimatedGifEncoder mEncoder = new AnimatedGifEncoder();
            mEncoder.Start(verPath);
            mEncoder.SetDelay(300);
            mEncoder.SetRepeat(0);

            for (int i = 0; i < mFrames.Length; i++)
            {
                mEncoder.AddFrame(Image.FromFile(mFrames[i]));
            }

            mEncoder.Finish();
            _result = mFrames.Length.ToString();
                  
        }
        /// <summary>
        /// 获取验证结果
        /// </summary>
        public override string result
        {
            get { return _result; }
        }
        /// <summary>
        /// 重写添加字符的方法
        /// </summary>
        /// <returns></returns>
        public override string GetChar()
        {
            return "";
        }
    }

}