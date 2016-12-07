﻿/*
Author      : 张智
Date        : 2011-9-23
Description : 提供文件存储的功能抽象
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Shu.Utility
{
    /// <summary>
    /// 文件存储器抽象
    /// </summary>
    public interface IFileStorage
    {
        /// <summary>
        /// 将文件流存储到指定的文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="stream">文件流</param>
        void Save(Stream stream, string fileName);

        /// <summary>
        /// 以给定的文件扩展名 制造一个完整的文件名称
        /// </summary>
        /// <param name="ext">文件扩展名</param>
        /// <returns></returns>
        string MakeFileName(string ext);
    }
}
