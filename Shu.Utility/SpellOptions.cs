/*
* SunriseSpell - A Chinese pinyin library
*
* Copyright (C) 2004 mic <mic4free@hotmail.com>
*
* This program is free software; you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation; either version 2 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program; if not, write to the Free Software
* Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*
* In case your copy of SunriseSpell does not include a copy of the license, you may find it online at 
* http://www.gnu.org/copyleft/gpl.html
*/

/*
Author      : ����
Date        : 2011-4-14
Description : ��¼������ת��Ϊ����ƴ�� ��������ת��ѡ���ö��ֵ
*/


using System;

namespace Shu.Utility
{
    /// <summary>
    /// �ṩ��������ת��ѡ���ö��ֵ��
    /// </summary>
    /// <value>
    /// <code>FirstLetterOnly</code>
    /// ֻת��ƴ������ĸ��Ĭ��ת��ȫ��
    /// </value>
    /// <value>
    /// <code>TranslateUnknowWordToInterrogation</code>
    /// ת��δ֪����Ϊ�ʺţ�Ĭ�ϲ�ת��
    /// </value>
    /// <value>
    /// <code>EnableUnicodeLetter</code>
    /// ��������ĸ���������ַ���Ĭ�ϲ�����
    /// </value>
    [System.FlagsAttribute]
    public enum SpellOptions
    {
        /// <summary>
        ///  ֻת��ƴ������ĸ��Ĭ��ת��ȫ��
        /// </summary>
        FirstLetterOnly = 1,
        /// <summary>
        /// ת��δ֪����Ϊ�ʺţ�Ĭ�ϲ�ת��
        /// </summary>
        TranslateUnknowWordToInterrogation = 1 << 1,
        /// <summary>
        /// ��������ĸ���������ַ���Ĭ�ϲ�����
        /// </summary>
        EnableUnicodeLetter = 1 << 2,
    }

}
