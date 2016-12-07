using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace Shu.BLL
{
    /// <summary>
    /// 数据操作类
    /// </summary>
    public static class EKFineUIDataControl
    {
        #region 控件启用

        /// <summary>
        /// 禁用FineUI.DropDownList控件指定ID值选项．其他选项启用．
        /// </summary>
        /// <param name="ddl">控件</param>
        /// <param name="strvDisabledID">ID格式字符串 例:1,2,3,4,5</param>
        public static void DropDownListDisabledSelect(FineUI.DropDownList ddl, string strDisabledID)
        {
            strDisabledID = "," + strDisabledID + ",";
            bool isEx = false;
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                isEx = strDisabledID.Contains("," + ddl.Items[i].Value + ",");
                if (isEx)
                {
                    //禁用
                    ddl.Items[i].EnableSelect = false;
                }
                else
                {
                    //启用
                    ddl.Items[i].EnableSelect = true;
                }
            }
        }

        #endregion

    }

}





