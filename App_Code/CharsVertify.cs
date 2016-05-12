using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace QMVertify
{
    /// <summary>
    /// 字符组成的验证码
    /// </summary>
    public class CharsVertify : AbstractVertify
    {
        // 定义字符集数组、验证结果字符串
        private char[] charSet;
        private StringBuilder _result = new StringBuilder();

        /// <summary>
        /// 创建阿拉伯字符组成的验证码 
        /// </summary>
        /// <param name="set"></param>
        public CharsVertify(CharSet set)
        {
            if (set == CharSet.Alphas)
            {
                charSet = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            }
            else
            {
                charSet = new char[] { '\u4f55', '\u5415', '\u65bd', '\u5f20', '\u5b54', '\u66f9', '\u4e25', '\u534e', '\u91d1', '\u9b4f', '\u9676', '\u59dc', '\u8c22', '\u7684', '\u4e00', '\u662f', '\u4e86', '\u6211', '\u4e0d', '\u4eba', '\u5728', '\u4ed6', '\u6709', '\u8fd9', '\u4e2a', '\u4e0a', '\u4eec', '\u6765', '\u5230', '\u65f6', '\u8d75', '\u94b1', '\u5b59', '\u674e', '\u5468', '\u5434', '\u90d1', '\u738b', '\u51af', '\u9648', '\u6c88', '\u97e9', '\u6768', '\u6731', '\u79e6', '\u5c24', '\u8bb8', '\u5927', '\u5730', '\u4e3a', '\u5b50', '\u4e2d', '\u4f60', '\u8bf4', '\u751f', '\u56fd', '\u5e74', '\u7740', '\u5c31', '\u90a3', '\u548c', '\u8981', '\u5979', '\u51fa', '\u4e5f', '\u5f97', '\u91cc', '\u540e', '\u81ea', '\u4ee5', '\u4f1a', '\u5bb6', '\u53ef', '\u4e0b', '\u800c', '\u8fc7', '\u5929', '\u53bb', '\u80fd', '\u5bf9', '\u5c0f', '\u591a', '\u7136', '\u4e8e', '\u5fc3', '\u5b66', '\u4e48', '\u4e4b', '\u90fd', '\u597d', '\u770b', '\u8d77', '\u53d1', '\u5f53', '\u6ca1', '\u6210', '\u53ea', '\u5982', '\u4e8b', '\u628a', '\u8fd8', '\u7528', '\u7b2c', '\u6837', '\u9053', '\u60f3', '\u4f5c', '\u79cd', '\u5f00', '\u7f8e', '\u603b', '\u4ece', '\u65e0', '\u60c5', '\u5df1', '\u9762', '\u6700', '\u5973', '\u4f46', '\u73b0', '\u524d', '\u4e9b', '\u6240', '\u540c', '\u65e5', '\u624b', '\u53c8', '\u884c', '\u610f', '\u52a8', '\u65b9', '\u671f', '\u5b83', '\u5934', '\u7ecf', '\u957f', '\u513f', '\u56de', '\u4f4d', '\u5206', '\u7231', '\u8001', '\u56e0', '\u5f88', '\u7ed9', '\u540d', '\u6cd5', '\u95f4', '\u65af', '\u77e5', '\u4e16', '\u4ec0', '\u4e24', '\u6b21', '\u4f7f', '\u8eab', '\u8005', '\u88ab', '\u9ad8', '\u5df2', '\u4eb2', '\u5176', '\u8fdb', '\u6b64', '\u8bdd', '\u5e38', '\u4e0e', '\u6d3b', '\u6b63', '\u611f', '\u89c1', '\u660e', '\u95ee', '\u529b', '\u7406', '\u5c14', '\u70b9', '\u6587', '\u51e0', '\u5b9a', '\u672c', '\u516c', '\u7279', '\u505a', '\u5916', '\u5b69', '\u76f8', '\u897f', '\u679c', '\u8d70', '\u5c06', '\u6708', '\u5341', '\u5b9e', '\u5411', '\u58f0', '\u8f66', '\u5168', '\u4fe1', '\u91cd', '\u4e09', '\u673a', '\u5de5', '\u7269', '\u6c14', '\u6bcf', '\u5e76', '\u522b', '\u771f', '\u6253', '\u592a', '\u65b0', '\u6bd4', '\u624d', '\u4fbf', '\u592b', '\u518d', '\u4e66', '\u90e8', '\u6c34', '\u50cf', '\u773c', '\u7b49', '\u4f53', '\u5374', '\u52a0', '\u7535', '\u4e3b', '\u754c', '\u95e8', '\u5229' };
            }
        }
        /// <summary>
        /// 获取验证码的结果
        /// </summary>
        public override string result
        {
            get { return _result.ToString(); }
        }

        /// <summary>
        /// 生成验证码时获取单个字符的方法
        /// </summary>
        /// <returns></returns>
        public override string GetChar()
        {
            string temp = (charSet[R.Next(charSet.Length)]).ToString();
            _result.Append(temp);
            return temp;

        }
    }
}