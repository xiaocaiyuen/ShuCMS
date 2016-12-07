using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shu.Utility
{
    public class EKTypeProperty
    {
        /// <summary>
        /// 获取数据特性的值
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="item">包含属性值的对象</param>
        /// <param name="name">属性名</param>
        /// <returns></returns>
        public static string GetValue<T>(T item, string name)
        {
            if (item == null || item.GetType().GetProperty(name) == null)
            {
                return null;
            }
            object obj_val = item.GetType().GetProperty(name).GetValue(item, null);
            if (obj_val == null)
            {
                return null;
            }
            return obj_val.ToString();
        }
    }
}