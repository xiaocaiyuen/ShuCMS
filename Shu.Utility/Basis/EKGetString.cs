using System;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace Shu.Utility
{
    public class EKGetString
    {
        public EKGetString()
        {
        }

        #region  截取普通字符串

        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns>字符长度</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        /// <summary>
        /// 获取指定长字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="str">原字符串</param>
        /// <returns></returns>
        public static string SubString(string str, int length)
        {
            return SubString(str, 0, length, "...");
        }

        /// <summary>
        /// 获取指定长字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="str">原字符串</param>
        /// <param name="strLast">截取后追加字段串</param>
        /// <returns></returns>
        public static string SubString(string str, int length, string strLast)
        {
            return SubString(str, 0, length, strLast);
        }

        /// <summary>
        /// 获取指定长字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="length">长度</param>
        /// <param name="isadd">是否有省略号</param>
        /// <returns></returns>
        public static string SubString(string str, int length, bool isadd)
        {
            if (isadd)
            {
                return SubString(str, 0, length, "...");
            }
            else
            {
                return SubString(str, 0, length, "");
            }
        }

        #endregion

        #region  截取带HTML标签的字符串

        /// <summary>
        /// 获取指定长字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubHTMLString(string str, int length)
        {
            return SubHTMLString(true, str, length);
        }

        /// <summary>
        /// 获取指定长字符串
        /// </summary>
        /// <param name="isClear">是否清除空白，换行</param>
        /// <param name="length">长度</param>
        /// <param name="str">原字符串</param>
        /// <returns></returns>
        public static string SubHTMLString(bool isClear, string str, int length)
        {
            str = Regex.Replace(str, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //过去HTML标签
            //str = System.Text.RegularExpressions.Regex.Replace(str, "<[^>]+>", "");
            str = System.Text.RegularExpressions.Regex.Replace(str, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            //清除多余空白。换行。
            if (isClear)
            {
                str = ReplaceCode(str);
            }
            return SubString(str, 0, length, "...");
        }

        /// <summary>
        /// 获取指定长字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="str">原字符串</param>
        /// <param name="strLast">截取后追加字段串</param>
        /// <returns></returns>
        public static string SubHTMLString(string str, int length, string strLast)
        {
            str = Regex.Replace(str, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            str = System.Text.RegularExpressions.Regex.Replace(str, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            str = ReplaceCode(str);

            return SubString(str, 0, length, strLast);
        }

        /// <summary>
        /// 获取指定长字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="length">长度</param>
        /// <param name="isadd">是否有省略号</param>
        /// <returns></returns>
        public static string SubHTMLString(string str, int length, bool isadd)
        {
            if (isadd)
            {
                return SubString(str, 0, length, "...");
            }
            else
            {
                return SubString(str, 0, length, "");
            }
        }

        public static string ReplaceCode(string str)
        {
            str = str.Replace("&nbsp;", "");
            //str = str.Replace(" ", "");
            str = str.Replace("\r\n", "");
            return str;
        }

        public static string HtmlToCode(string str)
        {
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("&", "&amp;");
            str = str.Replace("×", "&times;");
            str = str.Replace("÷", "&divide;");
            return str;
        }

        public static string CodeToHtml(string str)
        {
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&amp;", "&");
            str = str.Replace("&times;", "×");
            str = str.Replace("&divide;", "÷");
            return str;
        }

        /// <summary>
        /// 取指定长度的字符串
        /// </summary>
        /// <param name="str">要检查的字符串</param>
        /// <param name="startIndex">起始位置</param>
        /// <param name="len">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string SubString(string str, int startIndex, int len, string p_TailString)
        {
            if (str == null)
            {
                return "";
            }
            string result = string.Empty;// 最终返回的结果
            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度
            int charLen = str.Length;// 把字符平等对待时的字符串长度
            int byteCount = 0;// 记录读取进度
            int pos = 0;// 记录截取位置
            char[] ary_ch = str.ToCharArray();

            if (byteLen > len)
            {
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(ary_ch[i]) > 255)// 按中文字符计算加2
                        byteCount += 2;
                    else// 按英文字符计算加1
                        byteCount += 1;
                    if (byteCount > len)// 超出时只记下上一个有效位置
                    {
                        pos = i;
                        break;
                    }
                    else if (byteCount == len)// 记下当前位置
                    {
                        pos = i + 1;
                        break;
                    }
                }

                if (pos >= 0)
                {
                    result = str.Substring(startIndex, pos) + p_TailString;
                }
            }
            else
            {
                result = str;
            }

            return result;
        }

        #endregion

        #region  JSON数据

        /// <summary>
        /// 字符串中是否存在相同字符，格式1,2,3,4,5,6....
        /// </summary>
        /// <param name="str">字符串 格式1,2,3,4,5,6....</param>
        /// <param name="split">分割符号</param>
        /// <param name="letter">检查存在字符</param>
        /// <returns></returns>
        public static bool IsExist(string str, char separator, string letter)
        {
            string[] ary = str.Split(separator);
            bool isExist = false;
            for (int i = 0; i < ary.Length; i++)
            {
                if (ary[i].ToLower() == letter.ToLower())
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }

        /// <summary>
        /// 删除字符串后几位字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="count">删除数量</param>
        /// <returns></returns>
        public static string RemoveEnd(string str, int count)
        {
            if (str.Length >= count)
            {
                str = str.Remove(str.Length - count);
            }
            return str;
        }

        /// <summary>
        /// 删除字符串后几位字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="count">删除数量</param>
        /// <returns></returns>
        public static string RemoveEnd(string str, string mark)
        {
            if (str.Contains(mark))
            {
                str = str.Remove(str.LastIndexOf(mark), mark.Length);
            }
            return str;
        }

        /// <summary>
        /// 删除字符串前端几位字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="count">删除数量</param>
        /// <returns></returns>
        public static string RemoveStart(string str, int count)
        {
            if (str.Length >= count)
            {
                str = str.Remove(0, count);
            }
            return str;
        }

        /// <summary>
        /// 删除字符串前端几位字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="count">删除数量</param>
        /// <returns></returns>
        public static string RemoveStart(string str, string mark)
        {
            if (str.Contains(mark))
            {
                str = str.Remove(str.IndexOf(mark), mark.Length);
            }
            return str;
        }

        #endregion

        #region 删除数组

        /// <summary>
        /// 删除数组
        /// </summary>
        /// <param name="item">字符串</param>
        /// <param name="arr">原数组</param>
        /// <returns></returns>
        public static string[] DeleteArray(string item, string[] ary)
        {
            List<string> ary_list = new List<string>();
            foreach (string i in ary)
            {
                ary_list.Add(i);//把数组的每一个元素保存到一个集合中
            }
            ary_list.Remove(item);//根据集合删除指定下标的元素
            ary = new string[ary_list.Count];//重新new一个数组
            //for (int j = 0; j < list.Count; j++)
            //{
            //    arr[j] = list[j];//把删除后的集合每一个保存到该数组
            //}
            ary = ary_list.ToArray();
            return ary;//返回该数组
        }

        /// <summary>
        /// 删除数组
        /// </summary>
        /// <param name="index">下标</param>
        /// <param name="ary">原数组</param>
        /// <returns></returns>
        public static string[] DeleteArray(int index, string[] ary)
        {
            List<string> ary_list = new List<string>();
            foreach (string i in ary)
            {
                ary_list.Add(i);//把数组的每一个元素保存到一个集合中
            }
            ary_list.RemoveAt(index);//根据集合删除指定下标的元素
            ary = new string[ary_list.Count];//重新new一个数组
            //for (int j = 0; j < list.Count; j++)
            //{
            //    arr[j] = list[j];//把删除后的集合每一个保存到该数组
            //}
            ary = ary_list.ToArray();
            return ary;//返回该数组
        }

        /// <summary>
        /// 删除数组
        /// </summary>
        /// <param name="item"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static T[] DeleteArray<T>(T item, T[] arr)
        {
            List<T> list = new List<T>();
            foreach (T i in arr)
            {
                list.Add(i);//把数组的每一个元素保存到一个集合中
            }
            list.Remove(item);//根据集合删除指定下标的元素
            arr = new T[list.Count];//重新new一个数组
            //for (int j = 0; j < list.Count; j++)
            //{
            //    arr[j] = list[j];//把删除后的集合每一个保存到该数组
            //}
            arr = list.ToArray();
            return arr;//返回该数组
        }

        /// <summary>
        /// 删除数组
        /// </summary>
        /// <param name="index"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static T[] DeleteArray<T>(int index, T[] arr)
        {
            List<T> list = new List<T>();
            foreach (T i in arr)
            {
                list.Add(i);//把数组的每一个元素保存到一个集合中
            }
            list.RemoveAt(index);//根据集合删除指定下标的元素
            arr = new T[list.Count];//重新new一个数组
            //for (int j = 0; j < list.Count; j++)
            //{
            //    arr[j] = list[j];//把删除后的集合每一个保存到该数组
            //}
            arr = list.ToArray();
            return arr;//返回该数组
        }

        #endregion

        #region 其他字符串操作

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns></returns>
        public static string FirstToUpper(string str)
        {
            return str[0].ToString().ToUpper() + str.Remove(0, 1);
        }

        /// <summary>
        /// UBB转换成HTML显示。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UbbToHtml(string str)
        {
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            return str;
        }


        /// <summary>
        /// 字符串中删除字符串。
        /// </summary>
        /// <param name="str1">原始字符串 1,2,3,4,6</param>
        /// <param name="str2">删除的字符串 2,4</param>
        /// <param name="split">分格字符串如 ,</param>
        /// <returns></returns>
        public static string StringRemoveString(string str1, string str2, string split)
        {
            string[] ary = str2.Split(new string[] { split }, StringSplitOptions.None);

            for (int i = 0; i < ary.Length; i++)
            {
                //1000,1001,1002,1003  >  1000,,1002 > 1000,1002
                str1 = str1.Replace(ary[i], "").Replace(split + split, split);
            }
            //去头多余
            if (str1.IndexOf(split) == 0)
            {
                str1 = EKGetString.RemoveStart(str1, split);
            }
            //去尾多余
            if (str1.LastIndexOf(split) + split.Length == str1.Length)
            {
                str1 = EKGetString.RemoveEnd(str1, split);
            }

            return str1;
        }

        #endregion

        #region 汉字转拼音

        private static int[] pyValue = new int[]
                {
                -20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,
                -20032,-20026,-20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,
                -19756,-19751,-19746,-19741,-19739,-19728,-19725,-19715,-19540,-19531,-19525,-19515,
                -19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,-19261,-19249,
                -19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,
                -19003,-18996,-18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,
                -18731,-18722,-18710,-18697,-18696,-18526,-18518,-18501,-18490,-18478,-18463,-18448,
                -18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183, -18181,-18012,
                -17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,
                -17733,-17730,-17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,
                -17468,-17454,-17433,-17427,-17417,-17202,-17185,-16983,-16970,-16942,-16915,-16733,
                -16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,-16452,-16448,
                -16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,
                -16212,-16205,-16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,
                -15933,-15920,-15915,-15903,-15889,-15878,-15707,-15701,-15681,-15667,-15661,-15659,
                -15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,-15408,-15394,
                -15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,
                -15149,-15144,-15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,
                -14941,-14937,-14933,-14930,-14929,-14928,-14926,-14922,-14921,-14914,-14908,-14902,
                -14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,-14663,-14654,
                -14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,
                -14170,-14159,-14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,
                -14109,-14099,-14097,-14094,-14092,-14090,-14087,-14083,-13917,-13914,-13910,-13907,
                -13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,-13611,-13601,
                -13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,
                -13340,-13329,-13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,
                -13068,-13063,-13060,-12888,-12875,-12871,-12860,-12858,-12852,-12849,-12838,-12831,
                -12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,-12320,-12300,
                -12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,
                -11781,-11604,-11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,
                -11055,-11052,-11045,-11041,-11038,-11024,-11020,-11019,-11018,-11014,-10838,-10832,
                -10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,-10329,-10328,
                -10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254
                };

        private static string[] pyName = new string[]
                {
                "A","Ai","An","Ang","Ao","Ba","Bai","Ban","Bang","Bao","Bei","Ben",
                "Beng","Bi","Bian","Biao","Bie","Bin","Bing","Bo","Bu","Ba","Cai","Can",
                "Cang","Cao","Ce","Ceng","Cha","Chai","Chan","Chang","Chao","Che","Chen","Cheng",
                "Chi","Chong","Chou","Chu","Chuai","Chuan","Chuang","Chui","Chun","Chuo","Ci","Cong",
                "Cou","Cu","Cuan","Cui","Cun","Cuo","Da","Dai","Dan","Dang","Dao","De",
                "Deng","Di","Dian","Diao","Die","Ding","Diu","Dong","Dou","Du","Duan","Dui",
                "Dun","Duo","E","En","Er","Fa","Fan","Fang","Fei","Fen","Feng","Fo",
                "Fou","Fu","Ga","Gai","Gan","Gang","Gao","Ge","Gei","Gen","Geng","Gong",
                "Gou","Gu","Gua","Guai","Guan","Guang","Gui","Gun","Guo","Ha","Hai","Han",
                "Hang","Hao","He","Hei","Hen","Heng","Hong","Hou","Hu","Hua","Huai","Huan",
                "Huang","Hui","Hun","Huo","Ji","Jia","Jian","Jiang","Jiao","Jie","Jin","Jing",
                "Jiong","Jiu","Ju","Juan","Jue","Jun","Ka","Kai","Kan","Kang","Kao","Ke",
                "Ken","Keng","Kong","Kou","Ku","Kua","Kuai","Kuan","Kuang","Kui","Kun","Kuo",
                "La","Lai","Lan","Lang","Lao","Le","Lei","Leng","Li","Lia","Lian","Liang",
                "Liao","Lie","Lin","Ling","Liu","Long","Lou","Lu","Lv","Luan","Lue","Lun",
                "Luo","Ma","Mai","Man","Mang","Mao","Me","Mei","Men","Meng","Mi","Mian",
                "Miao","Mie","Min","Ming","Miu","Mo","Mou","Mu","Na","Nai","Nan","Nang",
                "Nao","Ne","Nei","Nen","Neng","Ni","Nian","Niang","Niao","Nie","Nin","Ning",
                "Niu","Nong","Nu","Nv","Nuan","Nue","Nuo","O","Ou","Pa","Pai","Pan",
                "Pang","Pao","Pei","Pen","Peng","Pi","Pian","Piao","Pie","Pin","Ping","Po",
                "Pu","Qi","Qia","Qian","Qiang","Qiao","Qie","Qin","Qing","Qiong","Qiu","Qu",
                "Quan","Que","Qun","Ran","Rang","Rao","Re","Ren","Reng","Ri","Rong","Rou",
                "Ru","Ruan","Rui","Run","Ruo","Sa","Sai","San","Sang","Sao","Se","Sen",
                "Seng","Sha","Shai","Shan","Shang","Shao","She","Shen","Sheng","Shi","Shou","Shu",
                "Shua","Shuai","Shuan","Shuang","Shui","Shun","Shuo","Si","Song","Sou","Su","Suan",
                "Sui","Sun","Suo","Ta","Tai","Tan","Tang","Tao","Te","Teng","Ti","Tian",
                "Tiao","Tie","Ting","Tong","Tou","Tu","Tuan","Tui","Tun","Tuo","Wa","Wai",
                "Wan","Wang","Wei","Wen","Weng","Wo","Wu","Xi","Xia","Xian","Xiang","Xiao",
                "Xie","Xin","Xing","Xiong","Xiu","Xu","Xuan","Xue","Xun","Ya","Yan","Yang",
                "Yao","Ye","Yi","Yin","Ying","Yo","Yong","You","Yu","Yuan","Yue","Yun",
                "Za", "Zai","Zan","Zang","Zao","Ze","Zei","Zen","Zeng","Zha","Zhai","Zhan",
                "Zhang","Zhao","Zhe","Zhen","Zheng","Zhi","Zhong","Zhou","Zhu","Zhua","Zhuai","Zhuan",
                "Zhuang","Zhui","Zhun","Zhuo","Zi","Zong","Zou","Zu","Zuan","Zui","Zun","Zuo"
                };

        /// <summary>
        /// 把汉字转换成拼音(全拼)
        /// </summary>
        /// <param name="hzString">汉字字符串</param>
        /// <returns>转换后的拼音(全拼)字符串</returns>
        public static string ConvertPinyin(string hzString)
        {
            // 匹配中文字符
            Regex regex = new Regex("^[\u4e00-\u9fa5]$");
            byte[] array = new byte[2];
            string pyString = "";
            int chrAsc = 0;
            int i1 = 0;
            int i2 = 0;
            char[] noWChar = hzString.ToCharArray();

            for (int j = 0; j < noWChar.Length; j++)
            {
                // 中文字符
                if (regex.IsMatch(noWChar[j].ToString()))
                {
                    array = System.Text.Encoding.Default.GetBytes(noWChar[j].ToString());
                    i1 = (short)(array[0]);
                    i2 = (short)(array[1]);
                    chrAsc = i1 * 256 + i2 - 65536;
                    if (chrAsc > 0 && chrAsc < 160)
                    {
                        pyString += noWChar[j];
                    }
                    else
                    {
                        // 修正部分文字
                        if (chrAsc == -9254)  // 修正“圳”字
                            pyString += "Zhen";
                        else
                        {
                            for (int i = (pyValue.Length - 1); i >= 0; i--)
                            {
                                if (pyValue[i] <= chrAsc)
                                {
                                    pyString += pyName[i];
                                    break;
                                }
                            }
                        }
                    }
                }
                // 非中文字符
                else
                {
                    pyString += noWChar[j].ToString();
                }
            }
            return pyString;
        }

        ///   <summary> 
        ///   得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 
        ///   </summary> 
        ///   <param   name="CnChar">单个汉字</param> 
        ///   <returns>单个大写字母</returns> 
        public static string ConvertPinyinFirst(string CnChar)
        {
            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

            //如果是字母，则直接返回 
            if (ZW.Length == 1)
            {
                return CnChar.ToUpper();
            }
            else
            {
                //   get   the     array   of   byte   from   the   single   char    
                int i1 = (short)(ZW[0]);
                int i2 = (short)(ZW[1]);
                iCnChar = i1 * 256 + i2;
            }
            #region table   of   the   constant   list
            //expresstion 
            //table   of   the   constant   list 
            // 'A';           //45217..45252 
            // 'B';           //45253..45760 
            // 'C';           //45761..46317 
            // 'D';           //46318..46825 
            // 'E';           //46826..47009 
            // 'F';           //47010..47296 
            // 'G';           //47297..47613 

            // 'H';           //47614..48118 
            // 'J';           //48119..49061 
            // 'K';           //49062..49323 
            // 'L';           //49324..49895 
            // 'M';           //49896..50370 
            // 'N';           //50371..50613 
            // 'O';           //50614..50621 
            // 'P';           //50622..50905 
            // 'Q';           //50906..51386 

            // 'R';           //51387..51445 
            // 'S';           //51446..52217 
            // 'T';           //52218..52697 
            //没有U,V 
            // 'W';           //52698..52979 
            // 'X';           //52980..53640 
            // 'Y';           //53689..54480 
            // 'Z';           //54481..55289 
            #endregion
            //   iCnChar match     the   constant 
            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }

            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= .51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else return ("?");
        }



        #endregion
        
        #region 字符串数组

        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else
                {
                    if (strSearch == stringArray[i])
                    {
                        return i;
                    }
                }

            }
            return -1;
        }

        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>		
        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">字符串数组</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }

        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <param name="maxElementLength">字符串数组中单个元素的最大长度</param>
        /// <returns></returns>
        public static string[] DistinctStringArray(string[] strArray, int maxElementLength)
        {
            Hashtable h = new Hashtable();

            foreach (string s in strArray)
            {
                string k = s;
                if (maxElementLength > 0 && k.Length > maxElementLength)
                {
                    k = k.Substring(0, maxElementLength);
                }
                h[k.Trim()] = s;
            }

            string[] result = new string[h.Count];

            h.Keys.CopyTo(result, 0);

            return result;
        }

        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <returns></returns>
        public static string[] DistinctStringArray(string[] strArray)
        {
            return DistinctStringArray(strArray, 0);
        }

        /// <summary>
        /// 过滤字符串数组中每个元素为合适的大小
        /// 当长度小于minLength时，忽略掉,-1为不限制最小长度
        /// 当长度大于maxLength时，取其前maxLength位
        /// 如果数组中有null元素，会被忽略掉
        /// </summary>
        /// <param name="minLength">单个元素最小长度</param>
        /// <param name="maxLength">单个元素最大长度</param>
        /// <returns></returns>
        public static string[] PadStringArray(string[] strArray, int minLength, int maxLength)
        {
            if (minLength > maxLength)
            {
                int t = maxLength;
                maxLength = minLength;
                minLength = t;
            }

            int iMiniStringCount = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (minLength > -1 && strArray[i].Length < minLength)
                {
                    strArray[i] = null;
                    continue;
                }
                if (strArray[i].Length > maxLength)
                {
                    strArray[i] = strArray[i].Substring(0, maxLength);
                }
                iMiniStringCount++;
            }

            string[] result = new string[iMiniStringCount];
            for (int i = 0, j = 0; i < strArray.Length && j < result.Length; i++)
            {
                if (strArray[i] != null && strArray[i] != string.Empty)
                {
                    result[j] = strArray[i];
                    j++;
                }
            }

            return result;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <param name="maxElementLength">单个元素最大长度</param>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            return ignoreRepeatItem ? DistinctStringArray(result, maxElementLength) : result;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <param name="minElementLength">单个元素最小长度</param>
        /// <param name="maxElementLength">单个元素最大长度</param>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int minElementLength, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            if (ignoreRepeatItem)
            {
                result = DistinctStringArray(result);
            }
            return PadStringArray(result, minElementLength, maxElementLength);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem)
        {
            return SplitString(strContent, strSplit, ignoreRepeatItem, 0);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (!string.IsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                {
                    string[] tmp = { strContent };
                    return tmp;
                }
                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
            {
                return new string[0] { };
            }
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] result = new string[count];

            string[] splited = SplitString(strContent, strSplit);

            for (int i = 0; i < count; i++)
            {
                if (i < splited.Length)
                    result[i] = splited[i];
                else
                    result[i] = string.Empty;
            }

            return result;
        }

        #endregion

        #region 转换 HTML

        /// <summary>
        /// 转换成 HTML code
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string Encode(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            return str;
        }

        /// <summary>
        ///解析html成 普通文本
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string Decode(string str)
        {
            str = str.Replace("<br>", "\n");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            return str;
        }

        #endregion

    }
}
