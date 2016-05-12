using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QMVertify
{
    /// <summary>
    /// 创建数学计算验证码
    /// </summary>
    public class MathVertify : QMVertify.AbstractVertify
    {

        private int   time = -1  // 第几次调用GetChar方法，以便生成不同的值
                    , para1 = 0  // 第一个值
                    , para2 = 0 ;// 第二个值
        private string method = null; //加法、减法
        private Num num;

        /// <summary>
        /// 创建数学计算验证码
        /// </summary>
        /// <param name="num"></param>
        public MathVertify(QMVertify.Num num)
        {
            this.num = num;
        }

        /// <summary>
        /// 重载 获取验证码结果的方法
        /// </summary>
        public override string result
        {
            get { return GetResult().ToString(); }
        }

        /// <summary>
        /// 重载 获取单个字符的方法
        /// </summary>
        /// <returns></returns>
        public override string GetChar()
        {
            time++;
            switch (time)
            {
                case 0:
                    para1 = (R.Next((int)num));
                    return para1.ToString();
                case 2:
                    para2 = (R.Next((int)num));
                    return para2.ToString();
                case 1:
                    method = GetOperator();
                    return method;
                default: return "";
            }
        }
        private string GetOperator()
        {
            if (R.Next(2) == 1)
            {
                return "加";
            }
            else
            {
                return "减";
            }
        }

        private int GetResult()
        {
            if (method == "加")
            {
                return para1 + para2;
            }
            else
            {
                return para1 - para2;
            }
        }
    }
}
