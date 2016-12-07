﻿/*
Author      : 张智
Date        : 2011-6-15
Description : 反射器缓存
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Shu.Utility
{
    /// <summary>
    /// 反射器缓存
    /// </summary>
    public static class ReflectorCache
    {
        static IReflectorFactory _refFactory = new ILReflectorFactory();
        static Dictionary<PropertyInfo, IMemberAccessor> _propertyCache = new Dictionary<PropertyInfo, IMemberAccessor>();
        static Dictionary<FieldInfo, IMemberAccessor> _fieldCache = new Dictionary<FieldInfo, IMemberAccessor>();
        static Dictionary<MethodBase, IMethodInvoker> _methodCache = new Dictionary<MethodBase, IMethodInvoker>();

        /// <summary>
        /// 通过字段信息获得成员连接器
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static IMemberAccessor GetAccessor(FieldInfo field)
        {
            if (field == null)
                throw new ArgumentNullException("field");
            
            IMemberAccessor accessor;
            if (_fieldCache.TryGetValue(field, out accessor))
            {
                return accessor;
            }

            lock (_fieldCache)
            {
                if (!_fieldCache.TryGetValue(field, out accessor))
                {
                    accessor = _refFactory.GetFieldAccessor(field);
                    _fieldCache[field] = accessor;
                }
            }

            return accessor;
        }

        /// <summary>
        /// 通过属性信息获得成员连接器
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static IMemberAccessor GetAccessor(PropertyInfo property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            IMemberAccessor accessor;
            if (_propertyCache.TryGetValue(property, out accessor))
            {
                return accessor;
            }

            lock (_propertyCache)
            {
                if (!_propertyCache.TryGetValue(property, out accessor))
                {
                    accessor = _refFactory.GetPropertyAccessor(property);
                    _propertyCache[property] = accessor;
                }
            }

            return accessor;
        }

        public static IMethodInvoker GetMethodInvoker(MethodBase method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            IMethodInvoker invoker;
            if (_methodCache.TryGetValue(method, out invoker))
            {
                return invoker;
            }

            lock (_methodCache)
            {
                if (!_methodCache.TryGetValue(method, out invoker))
                {
                    invoker = _refFactory.GetMethodInvoker(method);
                    _methodCache[method] = invoker;
                }
            }

            return invoker;
        }

    }
}
