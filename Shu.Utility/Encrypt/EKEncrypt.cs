using System;
using System.Security.Cryptography;  
using System.Text;
using System.IO;
namespace Shu.Utility
{
    public class EKEncrypt
    {
        public EKEncrypt()
        { }

        #region RC2

        /// <summary> 
        /// 进行RC2加密。 
        /// </summary> 
        /// <param name="pToEncrypt">要加密的字符串。</param> 
        /// <param name="sKey">初始化向量</param> 
        /// <param name="IV">密钥，且必须为8位。</param> 
        /// <returns>以Base64格式返回的加密字符串。</returns> 
        public static string EncryptRC2(string pToEncrypt, byte[] key, byte[] IV)
        {
            //创建UTF-16 编码，用来在byte[]和string之间转换 
            System.Text.UnicodeEncoding textConverter = new UnicodeEncoding();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
            using (RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider())
            {
                System.Security.Cryptography.ICryptoTransform Encryptor = rc2CSP.CreateEncryptor(key, IV);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, Encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /// <summary> 
        /// 进行RC2解密。 
        /// </summary> 
        /// <param name="pToDecrypt">要解密的以Base64</param> 
        /// <param name="sKey">初始化向量</param> 
        /// <param name="IV">密钥，且必须为8位。</param> 
        /// <returns>已解密的字符串。</returns> 
        public static string DecryptRC2(string pToDecrypt, byte[] key, byte[] IV)
        {
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider())
            {
                System.Security.Cryptography.ICryptoTransform Encryptor = rc2CSP.CreateDecryptor(key, IV);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, Encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        #endregion


        #region RSA

        /// <summary> 
        /// RSA加密 
        /// </summary> 
        /// <param name="DataToEncrypt"></param> 
        /// <param name="DoOAEPPadding"></param> 
        /// <returns></returns> 
        static public byte[] EncryptRSA(byte[] DataToEncrypt, bool DoOAEPPadding)
        {
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                StreamReader reader = new StreamReader(@"d:\PublicKey.xml");
                string PKey = reader.ReadToEnd();
                RSA.FromXmlString(PKey);
                reader.Close();

                return RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        /// <summary> 
        /// RSA解密 
        /// </summary> 
        /// <param name="DataToDecrypt"></param> 
        /// <param name="DoOAEPPadding"></param> 
        /// <returns></returns> 
        static public byte[] DecryptRSA(byte[] DataToDecrypt, bool DoOAEPPadding)
        {
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                StreamReader reader = new StreamReader(@"d:\PublicAndPrivateKey.xml");
                string PPKey = reader.ReadToEnd();
                RSA.FromXmlString(PPKey);
                reader.Close();

                return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }

        #endregion


        #region MD5

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="length">密码长度</param>
        public static string EncryptMD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="length">密码长度</param>
        /// <param name="str">需加密的字符串</param>
        public static string EncryptMD5(string str, int length)
        {
            if (length > 0 && length < 32)
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(0, length);
            }
            else//32位加密 
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="length">密码长度</param>
        /// <param name="str">需加密的字符串</param>
        public static string EncryptMD5(string str, int startIndex, int length)
        {
            if (length > 0 && length < 32)
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(startIndex, length);
            }
            else//32位加密 
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }
        }

        #endregion


        #region RC4

        /// <summary> 
        /// 加密或解密（对称） 
        /// </summary> 
        /// <param name="data">明文或密文</param> 
        /// <param name="pass">密钥</param> 
        /// <returns>密文或明文</returns> 
        public Byte[] EncryptRC4(Byte[] data, String pass)
        {
            if (data == null || pass == null) return null;
            Byte[] output = new Byte[data.Length];
            Int64 i = 0;
            Int64 j = 0;
            Byte[] mBox = GetKey(Encoding.UTF8.GetBytes(pass), 256);

            // 加密 
            for (Int64 offset = 0; offset < data.Length; offset++)
            {
                i = (i + 1) % mBox.Length;
                j = (j + mBox[i]) % mBox.Length;
                Byte temp = mBox[i];
                mBox[i] = mBox[j];
                mBox[j] = temp;
                Byte a = data[offset];
                //Byte b = mBox[(mBox[i] + mBox[j] % mBox.Length) % mBox.Length]; 
                // mBox[j] 一定比 mBox.Length 小，不需要在取模 
                Byte b = mBox[(mBox[i] + mBox[j]) % mBox.Length];
                output[offset] = (Byte)((Int32)a ^ (Int32)b);
            }

            return output;
        }

        /// <summary> 
        /// 解密 
        /// </summary> 
        /// <param name="data"></param> 
        /// <param name="pass"></param> 
        /// <returns></returns> 
        public Byte[] DecryptRC4(Byte[] data, String pass)
        {
            return DecryptRC4(data, pass);
        }

        /// <summary> 
        /// 打乱密码 
        /// </summary> 
        /// <param name="pass">密码</param> 
        /// <param name="kLen">密码箱长度</param> 
        /// <returns>打乱后的密码</returns> 
        static private Byte[] GetKey(Byte[] pass, Int32 kLen)
        {
            Byte[] mBox = new Byte[kLen];

            for (Int64 i = 0; i < kLen; i++)
            {
                mBox[i] = (Byte)i;
            }
            Int64 j = 0;
            for (Int64 i = 0; i < kLen; i++)
            {
                j = (j + mBox[i] + pass[i % pass.Length]) % kLen;
                Byte temp = mBox[i];
                mBox[i] = mBox[j];
                mBox[j] = temp;
            }
            return mBox;
        }

        #endregion


        #region AES

        /// <summary>
        /// AES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为32位</param>
        /// <returns>加密成功返回加密后的字符串,失败返回源串</returns>
        public static string EncryptAES(string encryptString, string encryptKey)
        {
            encryptKey = EKGetString.SubString(encryptKey, 32, "");
            encryptKey = encryptKey.PadRight(32, ' ');

            RijndaelManaged rijndaelProvider = new RijndaelManaged();
            rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
            rijndaelProvider.IV = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);
        }

        /// <summary>
        /// AES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为32位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串,失败返源串</returns>
        public static string DecryptAES(string decryptString, string decryptKey)
        {
            try
            {
                decryptKey = EKGetString.SubString(decryptKey, 32, "");
                decryptKey = decryptKey.PadRight(32, ' ');

                RijndaelManaged rijndaelProvider = new RijndaelManaged();
                rijndaelProvider.Key = Encoding.UTF8.GetBytes(decryptKey);
                rijndaelProvider.IV = Encoding.UTF8.GetBytes(decryptKey);
                ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                byte[] inputData = Convert.FromBase64String(decryptString);
                byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch
            {
                return decryptString;
            }

        }

        #endregion


        #region DES

        /// <summary> 
        /// 进行DES加密。
        /// </summary> 
        /// <param name="pToEncrypt">要加密的字符串。</param> 
        /// <param name="sKey">密钥，且必须为8位。</param> 
        /// <returns>以Base64格式返回的加密字符串。</returns> 
        public static string EncryptDES(string pToEncrypt, string sKey)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                if (sKey.Length < 8)
                {
                    sKey = sKey.PadRight(8);
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /// <summary> 
        /// 进行DES解密。
        /// </summary> 
        /// <param name="pToDecrypt">要解密的以Base64</param> 
        /// <param name="sKey">密钥，且必须为8位。</param> 
        /// <returns>已解密的字符串。</returns> 
        public static string DecryptDES(string pToDecrypt, string sKey)
        {
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                if (sKey.Length < 8)
                {
                    sKey = sKey.PadRight(8);
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                }
                catch
                {
                    return "";
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        #endregion

        #region MD5加密
        /// <summary>
        ///  MD5加密
        /// </summary>
        public static string MD5Encrypt(string Text)
        {
            return MD5Encrypt(Text, "litianping");
        }

        /// <summary> 
        ///  MD5加密 
        /// </summary> 
        public static string MD5Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }
        #endregion

        #region MD5解密
        /// <summary>
        ///  MD5解密
        /// </summary>
        public static string MD5Decrypt(string Text)
        {
            return MD5Decrypt(Text, "litianping");
        }

        /// <summary> 
        ///  MD5解密
        /// </summary>  
        public static string MD5Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }
        #endregion

        #region TripleDES加密
        /// <summary>
        /// TripleDES加密
        /// </summary>
        public static string TripleDESEncrypting(string strSource)
        {
            try
            {
                byte[] bytIn = Encoding.Default.GetBytes(strSource);
                byte[] key = { 42, 16, 93, 156, 78, 4, 218, 32, 15, 167, 44, 80, 26, 20, 155, 112, 2, 94, 11, 204, 119, 35, 184, 197 }; //定义密钥
                byte[] IV = { 55, 103, 246, 79, 36, 99, 167, 3 };  //定义偏移量
                TripleDESCryptoServiceProvider TripleDES = new TripleDESCryptoServiceProvider();
                TripleDES.IV = IV;
                TripleDES.Key = key;
                ICryptoTransform encrypto = TripleDES.CreateEncryptor();
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
                cs.Write(bytIn, 0, bytIn.Length);
                cs.FlushFinalBlock();
                byte[] bytOut = ms.ToArray();
                return System.Convert.ToBase64String(bytOut);
            }
            catch (Exception ex)
            {
                throw new Exception("加密时候出现错误!错误提示:\n" + ex.Message);
            }
        }
        #endregion

        #region TripleDES解密
        /// <summary>
        /// TripleDES解密
        /// </summary>
        public static string TripleDESDecrypting(string Source)
        {
            try
            {
                byte[] bytIn = System.Convert.FromBase64String(Source);
                byte[] key = { 42, 16, 93, 156, 78, 4, 218, 32, 15, 167, 44, 80, 26, 20, 155, 112, 2, 94, 11, 204, 119, 35, 184, 197 }; //定义密钥
                byte[] IV = { 55, 103, 246, 79, 36, 99, 167, 3 };   //定义偏移量
                TripleDESCryptoServiceProvider TripleDES = new TripleDESCryptoServiceProvider();
                TripleDES.IV = IV;
                TripleDES.Key = key;
                ICryptoTransform encrypto = TripleDES.CreateDecryptor();
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                StreamReader strd = new StreamReader(cs, Encoding.Default);
                return strd.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception("解密时候出现错误!错误提示:\n" + ex.Message);
            }
        }
        #endregion

        #region 创建字符串的MD5哈希值
        
        /// <summary>
        /// 创建字符串的MD5哈希值
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>字符串MD5哈希值的十六进制字符串</returns>
        public static string StringToMD5Hash(string inputString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString();
        }

        #endregion
    }
}