using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Shu.Utility
{
    public static class EKTypeParse
    {
        #region 基本方法

        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(string expression, bool defValue)
        {
            if (expression != null)
            {
                if (string.Compare(expression, "true", true) == 0)
                {
                    return true;
                }
                else if (string.Compare(expression, "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }
        
        /// <summary>
        /// string类型转换为int类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(object strValue, int defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToInt(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string类型转换为int类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string strValue, int defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            int dec = defValue;
            if (int.TryParse(strValue, out dec))
            {
                return dec;
            }
            return defValue;
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的float类型结果</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的float类型结果</returns>
        public static float StrToFloat(string strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            float dec = defValue;
            if (float.TryParse(strValue.ToString(), out dec))
            {
                return dec;
            }
            return defValue;
        }

        /// <summary>
        /// string类型转decimal类型
        /// </summary>
        /// <param name="strValue">转换值</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal StrToDecimal(string strValue, decimal defValue)
        {
            if (strValue == "")
            {
                return defValue;
            }
            decimal dec =defValue;
            if (decimal.TryParse(strValue, out dec))
            {
                return dec;
            }
            return defValue;
        }

        /// <summary>
        /// object类型转decimal类型
        /// </summary>
        /// <param name="strValue">转换对象</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal StrToDecimal(object strValue, decimal defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToDecimal(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string类型转Long类型
        /// </summary>
        /// <param name="strValue">转换值</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换后的long类型结果</returns>
        public static long StrToLong(string strValue, long defValue)
        {
            if (strValue == "")
            {
                return defValue;
            }
            long dec = defValue;
            if (long.TryParse(strValue, out dec))
            {
                return dec;
            }
            return defValue;
        }

        /// <summary>
        /// object类型转Long类型
        /// </summary>
        /// <param name="strValue">转移对象</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换后的long类型结果</returns>
        public static long StrToLong(object strValue, long defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToLong(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string转DateTime型
        /// </summary>
        /// <param name="strValue">转换值</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换后的DateTime类型结果</returns>
        public static DateTime StrToDateTime(string strValue, DateTime defValue)
        {
            DateTime dt = defValue;
            if (DateTime.TryParse(strValue, out dt))
            {
                return dt;
            }
            return defValue;
        }

        /// <summary>
        /// string转DateTime型
        /// </summary>
        /// <param name="strValue">转换值</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换后的DateTime类型结果</returns>
        public static DateTime StrToDateTime(object strValue, DateTime defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToDateTime(strValue.ToString(), defValue);
        }
        
        #endregion





        #region ----------扩展基本方法----------


        #region 转换bool

        /// <summary>
        /// string类型转换为bool类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool ToBool(this string strValue, bool defValue)
        {
            if (strValue != null)
            {
                if (string.Compare(strValue, "true", true) == 0)
                {
                    return true;
                }
                else if (string.Compare(strValue, "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }

        /// <summary>
        /// object类型转换为bool类型
        /// </summary>
        /// <param name="strValue">要转换的对象</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool ToBool(this object strValue, bool defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToBool(defValue);
        }

        /// <summary>
        /// string类型转换为bool类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool ToBool(this string strValue)
        {
            return strValue.ToBool(false);
        }

        /// <summary>
        /// object类型转换为bool类型
        /// </summary>
        /// <param name="strValue">要转换的对象</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool ToBool(this object strValue)
        {
            return strValue.ToBool(false);
        }

        #endregion




        #region 转换int

        /// <summary>
        /// string类型转换为int类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ToInt(this string strValue, int defValue)
        {
            if (strValue == "")
            {
                return defValue;
            }
            int dec = defValue;
            if (int.TryParse(strValue, out dec))
            {
                return dec;
            }
            return defValue;
        }

        /// <summary>
        /// object转换为int类类型
        /// </summary>
        /// <param name="str">要转换的对象</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ToInt(this object strValue, int defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToInt(defValue);
        }

        /// <summary>
        /// string类型转换为int类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ToInt(this string strValue)
        {
            return strValue.ToInt(0);
        }

        /// <summary>
        /// object转换为int类类型
        /// </summary>
        /// <param name="str">要转换的对象</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ToInt(this object strValue)
        {
            return strValue.ToInt(0);
        }

        #endregion




        #region 转换float
        
        /// <summary>
        /// object类型转换为float类型
        /// </summary>
        /// <param name="strValue">要转换的对象</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的float类型结果</returns>
        public static float ToFloat(this object strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToFloat(defValue);
        }

        /// <summary>
        /// string类型转换为float类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的float类型结果</returns>
        public static float ToFloat(this string strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            float dec = defValue;
            if (float.TryParse(strValue, out dec))
            {
                return dec;
            }
            return defValue;
        }

        /// <summary>
        /// object类型转换为float类型
        /// </summary>
        /// <param name="strValue">要转换的对象</param>
        /// <returns>转换后的float类型结果</returns>
        public static float ToFloat(this object strValue)
        {
            return strValue.ToFloat(0);
        }

        /// <summary>
        /// string类型转换为float类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的float类型结果</returns>
        public static float ToFloat(this string strValue)
        {
            return strValue.ToFloat(0);
        }

        #endregion




        #region 转换decimal

        /// <summary>
        /// string类型转换为decimal类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal ToDecimal(this string strValue, decimal defValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return defValue;
            }
            decimal dec = defValue;
            if (decimal.TryParse(strValue, out dec))
            {
                return dec;
            }
            return defValue;
        }

        /// <summary>
        /// string类型转换decimal类型
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal ToDecimal(this object strValue, decimal defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToDecimal(0);
        }

        /// <summary>
        /// string类型转换为decimal类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal ToDecimal(this string strValue)
        {
            return strValue.ToDecimal(0);
        }

        /// <summary>
        /// string类型转换decimal类型
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal ToDecimal(this object strValue)
        {
            return strValue.ToDecimal(0);
        }

        #endregion


        

        #region 转换long
        
        /// <summary>
        /// string类型转换Long类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的long类型结果</returns>
        public static long ToLong(this string strValue, long defValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return defValue;
            }
            long dec = defValue;
            if (long.TryParse(strValue, out dec))
            {
                return dec;
            }
            return defValue;
        }

        /// <summary>
        /// object类型转Long类型
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的long类型结果</returns>
        public static long ToLong(this object strValue, long defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToLong(defValue);
        }

        /// <summary>
        /// string类型转换Long类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的long类型结果</returns>
        public static long ToLong(this string strValue)
        {
            return strValue.ToLong(0);
        }

        /// <summary>
        /// object类型转Long类型
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <returns>转换后的long类型结果</returns>
        public static long ToLong(this object strValue)
        {
            return strValue.ToLong(0);
        }
        
        #endregion




        #region 转换string

        /// <summary>
        /// 对象转string类型
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>转换后的string类型结果</returns>
        public static string ToString(this object obj)
        {
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }

        /// <summary>
        /// 对象转string类型
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换后的string类型结果</returns>
        public static string ToString(this object obj, string defValue)
        {
            if (obj == null)
            {
                return defValue;
            }
            return obj.ToString();
        }

        #endregion




        #region 转换DateTime

        /// <summary>
        /// string类型转DateTime类型
        /// </summary>
        /// <param name="strValue">转换对象</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换后的DateTime类型结果</returns>
        public static DateTime ToDateTime(this string strValue, DateTime defValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return defValue;
            }
            DateTime dt = defValue;
            if (DateTime.TryParse(strValue, out dt))
            {
                return dt;
            }
            return defValue;
        }

        /// <summary>
        /// Object类型转DateTime类型
        /// </summary>
        /// <param name="strValue">转换对象</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换后的DateTime类型结果</returns>
        public static DateTime ToDateTime(this object strValue, DateTime defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToDateTime(defValue);
        }

        /// <summary>
        /// string类型转DateTime类型
        /// </summary>
        /// <param name="strValue">转换对象</param>
        /// <returns>转换后的DateTime类型结果</returns>
        public static DateTime ToDateTime(this string strValue)
        {
            return strValue.ToDateTime(DateTime.Now);
        }

        /// <summary>
        /// Object类型转DateTime类型
        /// </summary>
        /// <param name="strValue">转换对象</param>
        /// <returns>转换后的DateTime类型结果</returns>
        public static DateTime ToDateTime(this object strValue)
        {
            return strValue.ToDateTime(DateTime.Now);
        }

        #endregion



        #endregion

    }
}
