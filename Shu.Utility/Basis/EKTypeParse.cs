using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Shu.Utility
{
    public static class EKTypeParse
    {
        #region ��������

        /// <summary>
        /// string��ת��Ϊbool��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����bool���ͽ��</returns>
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
        /// string����ת��Ϊint����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int StrToInt(object strValue, int defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToInt(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string����ת��Ϊint����
        /// </summary>
        /// <param name="str">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
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
        /// string��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����float���ͽ��</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����float���ͽ��</returns>
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
        /// string����תdecimal����
        /// </summary>
        /// <param name="strValue">ת��ֵ</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת�����decimal���ͽ��</returns>
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
        /// object����תdecimal����
        /// </summary>
        /// <param name="strValue">ת������</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת�����decimal���ͽ��</returns>
        public static decimal StrToDecimal(object strValue, decimal defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToDecimal(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string����תLong����
        /// </summary>
        /// <param name="strValue">ת��ֵ</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת�����long���ͽ��</returns>
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
        /// object����תLong����
        /// </summary>
        /// <param name="strValue">ת�ƶ���</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת�����long���ͽ��</returns>
        public static long StrToLong(object strValue, long defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToLong(strValue.ToString(), defValue);
        }

        /// <summary>
        /// stringתDateTime��
        /// </summary>
        /// <param name="strValue">ת��ֵ</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת�����DateTime���ͽ��</returns>
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
        /// stringתDateTime��
        /// </summary>
        /// <param name="strValue">ת��ֵ</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת�����DateTime���ͽ��</returns>
        public static DateTime StrToDateTime(object strValue, DateTime defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToDateTime(strValue.ToString(), defValue);
        }
        
        #endregion





        #region ----------��չ��������----------


        #region ת��bool

        /// <summary>
        /// string����ת��Ϊbool����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����bool���ͽ��</returns>
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
        /// object����ת��Ϊbool����
        /// </summary>
        /// <param name="strValue">Ҫת���Ķ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����bool���ͽ��</returns>
        public static bool ToBool(this object strValue, bool defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToBool(defValue);
        }

        /// <summary>
        /// string����ת��Ϊbool����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����bool���ͽ��</returns>
        public static bool ToBool(this string strValue)
        {
            return strValue.ToBool(false);
        }

        /// <summary>
        /// object����ת��Ϊbool����
        /// </summary>
        /// <param name="strValue">Ҫת���Ķ���</param>
        /// <returns>ת�����bool���ͽ��</returns>
        public static bool ToBool(this object strValue)
        {
            return strValue.ToBool(false);
        }

        #endregion




        #region ת��int

        /// <summary>
        /// string����ת��Ϊint����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
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
        /// objectת��Ϊint������
        /// </summary>
        /// <param name="str">Ҫת���Ķ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int ToInt(this object strValue, int defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToInt(defValue);
        }

        /// <summary>
        /// string����ת��Ϊint����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int ToInt(this string strValue)
        {
            return strValue.ToInt(0);
        }

        /// <summary>
        /// objectת��Ϊint������
        /// </summary>
        /// <param name="str">Ҫת���Ķ���</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int ToInt(this object strValue)
        {
            return strValue.ToInt(0);
        }

        #endregion




        #region ת��float
        
        /// <summary>
        /// object����ת��Ϊfloat����
        /// </summary>
        /// <param name="strValue">Ҫת���Ķ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����float���ͽ��</returns>
        public static float ToFloat(this object strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToFloat(defValue);
        }

        /// <summary>
        /// string����ת��Ϊfloat����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����float���ͽ��</returns>
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
        /// object����ת��Ϊfloat����
        /// </summary>
        /// <param name="strValue">Ҫת���Ķ���</param>
        /// <returns>ת�����float���ͽ��</returns>
        public static float ToFloat(this object strValue)
        {
            return strValue.ToFloat(0);
        }

        /// <summary>
        /// string����ת��Ϊfloat����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����float���ͽ��</returns>
        public static float ToFloat(this string strValue)
        {
            return strValue.ToFloat(0);
        }

        #endregion




        #region ת��decimal

        /// <summary>
        /// string����ת��Ϊdecimal����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����decimal���ͽ��</returns>
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
        /// string����ת��decimal����
        /// </summary>
        /// <param name="obj">Ҫת���Ķ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����decimal���ͽ��</returns>
        public static decimal ToDecimal(this object strValue, decimal defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToDecimal(0);
        }

        /// <summary>
        /// string����ת��Ϊdecimal����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����decimal���ͽ��</returns>
        public static decimal ToDecimal(this string strValue)
        {
            return strValue.ToDecimal(0);
        }

        /// <summary>
        /// string����ת��decimal����
        /// </summary>
        /// <param name="obj">Ҫת���Ķ���</param>
        /// <returns>ת�����decimal���ͽ��</returns>
        public static decimal ToDecimal(this object strValue)
        {
            return strValue.ToDecimal(0);
        }

        #endregion


        

        #region ת��long
        
        /// <summary>
        /// string����ת��Long����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����long���ͽ��</returns>
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
        /// object����תLong����
        /// </summary>
        /// <param name="obj">Ҫת���Ķ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����long���ͽ��</returns>
        public static long ToLong(this object strValue, long defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToLong(defValue);
        }

        /// <summary>
        /// string����ת��Long����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����long���ͽ��</returns>
        public static long ToLong(this string strValue)
        {
            return strValue.ToLong(0);
        }

        /// <summary>
        /// object����תLong����
        /// </summary>
        /// <param name="obj">Ҫת���Ķ���</param>
        /// <returns>ת�����long���ͽ��</returns>
        public static long ToLong(this object strValue)
        {
            return strValue.ToLong(0);
        }
        
        #endregion




        #region ת��string

        /// <summary>
        /// ����תstring����
        /// </summary>
        /// <param name="obj">����</param>
        /// <returns>ת�����string���ͽ��</returns>
        public static string ToString(this object obj)
        {
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }

        /// <summary>
        /// ����תstring����
        /// </summary>
        /// <param name="obj">����</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת�����string���ͽ��</returns>
        public static string ToString(this object obj, string defValue)
        {
            if (obj == null)
            {
                return defValue;
            }
            return obj.ToString();
        }

        #endregion




        #region ת��DateTime

        /// <summary>
        /// string����תDateTime����
        /// </summary>
        /// <param name="strValue">ת������</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת�����DateTime���ͽ��</returns>
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
        /// Object����תDateTime����
        /// </summary>
        /// <param name="strValue">ת������</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת�����DateTime���ͽ��</returns>
        public static DateTime ToDateTime(this object strValue, DateTime defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return strValue.ToString().ToDateTime(defValue);
        }

        /// <summary>
        /// string����תDateTime����
        /// </summary>
        /// <param name="strValue">ת������</param>
        /// <returns>ת�����DateTime���ͽ��</returns>
        public static DateTime ToDateTime(this string strValue)
        {
            return strValue.ToDateTime(DateTime.Now);
        }

        /// <summary>
        /// Object����תDateTime����
        /// </summary>
        /// <param name="strValue">ת������</param>
        /// <returns>ת�����DateTime���ͽ��</returns>
        public static DateTime ToDateTime(this object strValue)
        {
            return strValue.ToDateTime(DateTime.Now);
        }

        #endregion



        #endregion

    }
}
