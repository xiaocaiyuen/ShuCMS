using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

using System.Linq;
using System.Linq.Expressions;

namespace Shu.Utility
{
    /// <summary>
    /// 数据操作类
    /// </summary>
    public static class EKDataControl
    {
        #region 显示有效性

        /// <summary>
        /// 显示是否有效
        /// </summary>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public static string ShowEnabled(int isEnabled)
        {
            if (isEnabled == 1)
            {
                return "<font color=#009900>√</font>";
            }
            else
            {
                return "<font color=#ff0000>×</font>";
            }
        }

        /// <summary>
        /// 显示是否有效
        /// </summary>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public static string ShowEnabled(bool isEnabled)
        {
            if (isEnabled)
            {
                return "<font color=#009900>√</font>";
            }
            else
            {
                return "<font color=#ff0000>×</font>";
            }
        }

        /// <summary>
        /// 显示是否有效
        /// </summary>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public static string ShowEnabled(object isEnabled)
        {
            if (isEnabled.ToString() == "1")
            {
                return "<font color=#009900>√</font>";
            }
            else
            {
                return "<font color=#ff0000>×</font>";
            }
        }

        /// <summary>
        /// 显示是否有效
        /// </summary>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public static string ShowEnabledText(object isEnabled)
        {
            if (isEnabled.ToString() == "1")
            {
                return "<font color=#009900>可用</font>";
            }
            else
            {
                return "<font color=#ff0000>禁用</font>";
            }
        }

        /// <summary>
        /// 显示是否置顶
        /// </summary>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public static string ShowTopText(object IsTop)
        {
            if (IsTop.ToString() == "1")
            {
                return "<font color=#ff0000>取消置顶</font>";
            }
            else
            {
                return "置顶";
            }
        }

        /// <summary>
        /// 显示是否置顶
        /// </summary>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public static string ShowRecommendText(object IsRecommend)
        {
            if (IsRecommend.ToString() == "1")
            {
                return "<font color=#ff0000>取消推荐</font>";
            }
            else
            {
                return "推荐";
            }
        }

        #endregion 显示有效性

        #region 绑定无限级下拉框

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="ddlst">下拉控件</param>
        /// <param name="dt">数据表</param>
        /// <param name="id">值ID</param>
        /// <param name="name">文本</param>
        public static void CreateDropDown(System.Web.UI.WebControls.DropDownList ddlst, DataTable dt, string id, string name)
        {
            System.Web.UI.WebControls.ListItem newItem;
            foreach (DataRow row in dt.Rows)
            {
                newItem = new System.Web.UI.WebControls.ListItem(row[name].ToString(), row[id].ToString());
                ddlst.Items.Add(newItem);
            }
        }

        /// <summary>
        /// 绑定无限级下拉框
        /// </summary>
        /// <param name="ddlst">下拉控件</param>
        /// <param name="dt">数据表</param>
        /// <param name="id">值ID</param>
        /// <param name="parentid">父节点ID</param>
        /// <param name="name">文本</param>
        public static void CreateLevelDropDown(System.Web.UI.WebControls.DropDownList ddlst, DataTable dt, string id, string parentid, string name)
        {
            System.Collections.ArrayList allItems = new System.Collections.ArrayList();
            DataRow[] rows = dt.Select(parentid + "=" + 0);
            foreach (DataRow row in rows)
            {
                CreateLevelDropDownAssistant(dt, ref allItems, row, string.Empty, id, parentid, name);
            }

            System.Web.UI.WebControls.ListItem[] items = new System.Web.UI.WebControls.ListItem[allItems.Count];
            allItems.CopyTo(items);
            ddlst.Items.AddRange(items);
        }

        /// <summary>
        /// 绑定无限级下拉框
        /// </summary>
        /// <param name="ddlst">下拉控件</param>
        /// <param name="dt">数据表</param>
        /// <param name="id">值ID</param>
        /// <param name="parentid">父节点ID</param>
        /// <param name="name">文本</param>
        public static void CreateLevelDropDown(System.Web.UI.WebControls.ListBox lib, DataTable dt, string id, string parentid, string name)
        {
            System.Collections.ArrayList allItems = new System.Collections.ArrayList();
            DataRow[] rows = dt.Select(parentid + "=" + 0);
            foreach (DataRow row in rows)
            {
                CreateLevelDropDownAssistant(dt, ref allItems, row, string.Empty, id, parentid, name);
            }

            System.Web.UI.WebControls.ListItem[] items = new System.Web.UI.WebControls.ListItem[allItems.Count];
            allItems.CopyTo(items);
            lib.Items.AddRange(items);
        }

        /// <summary>
        /// 绑定无限级下拉框
        /// </summary>
        /// <param name="ddlst">下拉控件</param>
        /// <param name="dt">数据表</param>
        /// <param name="id">值ID</param>
        /// <param name="parentid">父节点ID</param>
        /// <param name="name">文本</param>
        public static void CreateLevelDropDown(System.Web.UI.WebControls.DropDownList ddlst, DataTable dt, string id, string parentid, string name, string pVal)
        {
            System.Collections.ArrayList allItems = new System.Collections.ArrayList();
            DataRow[] rows = dt.Select(parentid + "=" + pVal);
            foreach (DataRow row in rows)
            {
                CreateLevelDropDownAssistant(dt, ref allItems, row, string.Empty, id, parentid, name);
            }

            System.Web.UI.WebControls.ListItem[] items = new System.Web.UI.WebControls.ListItem[allItems.Count];
            allItems.CopyTo(items);
            ddlst.Items.AddRange(items);
        }

        /// <summary>
        /// 绑定无限级下拉框
        /// </summary>
        /// <param name="ddlst">下拉控件</param>
        /// <param name="dt">数据表</param>
        /// <param name="id">值ID</param>
        /// <param name="parentid">父节点ID</param>
        /// <param name="name">文本</param>
        public static void CreateLevelDropDown(System.Web.UI.WebControls.ListBox lib, DataTable dt, string id, string parentid, string name, string pVal)
        {
            System.Collections.ArrayList allItems = new System.Collections.ArrayList();
            DataRow[] rows = dt.Select(parentid + "=" + pVal);
            foreach (DataRow row in rows)
            {
                CreateLevelDropDownAssistant(dt, ref allItems, row, string.Empty, id, parentid, name);
            }

            System.Web.UI.WebControls.ListItem[] items = new System.Web.UI.WebControls.ListItem[allItems.Count];
            allItems.CopyTo(items);
            lib.Items.AddRange(items);
        }


        /// <summary>
        /// 绑定无限级下拉框
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="items"></param>
        /// <param name="parentRow"></param>
        /// <param name="curHeader"></param>
        /// <param name="id"></param>
        /// <param name="parentid"></param>
        /// <param name="name"></param>
        private static void CreateLevelDropDownAssistant(DataTable dt, ref System.Collections.ArrayList items, DataRow parentRow, string curHeader, string id, string parentid, string name)
        {
            System.Web.UI.WebControls.ListItem newItem = new System.Web.UI.WebControls.ListItem(curHeader + parentRow[name].ToString(), parentRow[id].ToString());
            items.Add(newItem);
            parentRow.Delete();

            DataRow[] rows = dt.Select(parentid + "='" + newItem.Value + "'");
            for (int i = 0; i < rows.Length - 1; i++)
            {
                CreateLevelDropDownAssistant(dt, ref items, rows[i], curHeader.Replace("┣", "┃").Replace("┗", "　") + "┣", id, parentid, name);
            }

            if (rows.Length > 0)
            {
                CreateLevelDropDownAssistant(dt, ref items, rows[rows.Length - 1], curHeader.Replace("┣", "┃").Replace("┗", "　") + "┗", id, parentid, name);
            }
            //├ │└
        }
        #endregion

        #region 数据表操作

        /// <summary>
        /// 数据表序列化转字符串
        /// </summary>
        /// <param name="dt">DataTable 数据表</param>
        /// <returns></returns>
        public static string DataTableSerialize(DataTable dt)
        {
            IFormatter fm = new BinaryFormatter();
            Stream sm = new MemoryStream();
            fm.Serialize(sm, dt);
            sm.Seek(0, SeekOrigin.Begin);
            byte[] newbyte = new byte[sm.Length];
            sm.Read(newbyte, 0, newbyte.Length);
            string strNew = Convert.ToBase64String(newbyte);

            return strNew;
        }

        /// <summary>
        /// 字符串反序列化为数据表
        /// </summary>
        /// <param name="strNew">字符串</param>
        /// <returns></returns>
        public static DataTable DataTableDeserialize(string strNew)
        {
            if (strNew == "" || strNew == null)
            {
                return new DataTable();
            }
            byte[] bt = Convert.FromBase64String(strNew);
            Stream smNew = new MemoryStream(bt);
            IFormatter fmNew = new BinaryFormatter();
            DataTable dt = (DataTable)fmNew.Deserialize(smNew);
            return dt;
        }

        /// <summary>
        /// 获取内容列表，截取第几行至最后数据
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="startIndex">开始行数,从1开始</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static DataTable GetSubTable(DataTable dt, int startIndex, int length)
        {
            DataTable ddt = dt.Copy();
            int endIndex = startIndex + length - 1;
            int Count = ddt.Rows.Count;
            for (int i = 0; i < Count; i++)
            {
                if (i < (startIndex - 1) || i > (endIndex - 1))
                {
                    ddt.Rows.RemoveAt(i);
                    Count--;
                    i--;
                    startIndex--;
                    endIndex--;
                }
            }

            return ddt;
        }

        /// <summary>
        /// List转DataTable
        /// </summary>
        /// <typeparam name="TResult">泛型</typeparam>
        /// <param name="ListValue">泛型IEnumerable对象</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<TResult>(this IEnumerable<TResult> ListValue)
        //where TResult : class, new()
        {
            //建立一個回傳用的 DataTable
            DataTable dt = new DataTable();
            //取得映射型別
            Type type = typeof(TResult);
            //宣告一個 PropertyInfo 陣列，來接取 Type 所有的共用屬性
            PropertyInfo[] PI_List = null;
            foreach (var item in ListValue)
            {
                //判斷 DataTable 是否已經定義欄位名稱與型態
                if (dt.Columns.Count == 0)
                {
                    //取得 Type 所有的共用屬性
                    PI_List = item.GetType().GetProperties();
                    //將 List 中的 名稱 與 型別，定義 DataTable 中的欄位 名稱 與 型別
                    foreach (var item1 in PI_List)
                    {
                        Type colType = item1.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dt.Columns.Add(item1.Name, colType);
                    }
                }

                //在 DataTable 中建立一個新的列
                DataRow dr = dt.NewRow();
                //將資料足筆新增到 DataTable 中
                foreach (var item2 in PI_List)
                {
                    dr[item2.Name] = item2.GetValue(item, null) == null ? DBNull.Value : item2.GetValue(item, null);
                }
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }

        /// <summary>
        /// DataTable转List
        /// </summary>
        /// <typeparam name="TResult">泛型</typeparam>
        /// <param name="DataTableValue">数据表</param>
        /// <returns></returns>
        public static List<TResult> DataTableToList<TResult>(this DataTable DataTableValue) where TResult : class, new()
        {
            //建立一個回傳用的 List<TResult>
            List<TResult> Result_List = new List<TResult>();
            //取得映射型別
            Type type = typeof(TResult);
            //儲存 DataTable 的欄位名稱
            List<PropertyInfo> pr_List = new List<PropertyInfo>();
            foreach (PropertyInfo item in type.GetProperties())
            {
                if (DataTableValue.Columns.IndexOf(item.Name) != -1)
                    pr_List.Add(item);
            }
            //足筆將 DataTable 的值新增到 List<TResult> 中
            foreach (DataRow item in DataTableValue.Rows)
            {
                TResult tr = new TResult();
                foreach (PropertyInfo item1 in pr_List)
                {
                    if (item[item1.Name] != DBNull.Value)
                        item1.SetValue(tr, item[item1.Name], null);
                }
                Result_List.Add(tr);
            }
            return Result_List;
        }

        /// <summary>
        /// DataRow转Model
        /// </summary>
        /// <typeparam name="TResult">泛型</typeparam>
        /// <param name="DataRowValue">数据表一行数据</param>
        /// <returns></returns>
        public static TResult DataRowToModel<TResult>(this DataRow DataRowValue) where TResult : class, new()
        {
            //建立一個回傳用的 TResult
            TResult Result = new TResult();
            //取得映射型別
            Type type = typeof(TResult);
            //儲存 DataTable 的欄位名稱
            List<PropertyInfo> pr_List = new List<PropertyInfo>();
            foreach (PropertyInfo item in type.GetProperties())
            {
                //if (DataRowValue.Columns.IndexOf(item.Name) != -1)
                pr_List.Add(item);
            }
            //足筆將 DataTable 的值新增到 List<TResult> 中

            TResult tr = new TResult();
            foreach (PropertyInfo item1 in pr_List)
            {
                if (DataRowValue[item1.Name] != DBNull.Value)
                    item1.SetValue(tr, DataRowValue[item1.Name], null);
            }


            return tr;
        }

        #endregion

        #region 获取控件值

        /// <summary>
        /// 多选控件选中值
        /// </summary>
        /// <param name="cbl">多选控件</param>
        /// <param name="defaultVal">默认值</param>
        /// <returns></returns>
        public static string GetValueCheckBoxList(System.Web.UI.WebControls.CheckBoxList cbl, string defaultVal)
        {
            string valStr = "";
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                if (cbl.Items[i].Value == "" || !cbl.Items[i].Selected)
                {
                    continue;
                }
                valStr += cbl.Items[i].Value + ",";
            }
            valStr = EKGetString.RemoveEnd(valStr, ",");
            if (valStr == "")
            {
                return defaultVal;
            }
            return valStr;
        }

        #endregion

        #region 其他

        /// <summary>
        /// 二个对象交换位置
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="i">对象1</param>
        /// <param name="j">对象2</param>
        public static void Swap<T>(ref T i, ref T j)
        {
            T t;
            t = i;
            i = j;
            j = t;
        }

        #endregion
    }

    /// <summary>
    /// LinqExpressions扩展
    /// 注意static形态类型
    /// 2013-3-22
    /// 王健龙
    /// </summary>
    public static class EKDynamicLinqExpressions
    {

        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        /// <summary>
        /// 条件表达式OR
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="expr1">条件表达式1</param>
        /// <param name="expr2">条件表达式2</param>
        /// <returns>新的条件表达式</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>
            (Expression.Or(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// 条件表达式AND
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="expr1">条件表达式1</param>
        /// <param name="expr2">条件表达式2</param>
        /// <returns>新的条件表达式</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>
            (Expression.And(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }

}





