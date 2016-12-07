using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;

namespace Shu.Utility
{
    public class EKXmlControl
    {
        protected string strXmlFile;
        protected XmlDocument objXmlDoc = new XmlDocument();

        public EKXmlControl(string XmlFile)
        {
            // 
            // TODO: 在这里加入建构函式的程序代码 
            // 
            try
            {
                //检查文件是否存在，不存在则创建
                if (!(File.Exists(XmlFile)))
                {
                    objXmlDoc.AppendChild(objXmlDoc.CreateXmlDeclaration("1.0", "gb2312", null));
                    objXmlDoc.AppendChild(objXmlDoc.CreateElement("", "Root", ""));
                    objXmlDoc.Save(XmlFile);
                }

                objXmlDoc.Load(XmlFile);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            strXmlFile = XmlFile;
        }

        public EKXmlControl(string XmlFile, Boolean bOverWrite, string sRoot)
        {
            try
            {
                //如果覆盖模式，则强行创建一个xml文档
                if (bOverWrite)
                {
                    objXmlDoc.AppendChild(objXmlDoc.CreateXmlDeclaration("1.0", "gb2312", null));//设置xml的版本，格式信息
                    objXmlDoc.AppendChild(objXmlDoc.CreateElement("", sRoot, ""));//创建根元素
                    objXmlDoc.Save(XmlFile);//保存
                }
                else //否则，检查文件是否存在，不存在则创建
                {
                    if (!(File.Exists(XmlFile)))
                    {
                        objXmlDoc.AppendChild(objXmlDoc.CreateXmlDeclaration("1.0", "gb2312", null));
                        objXmlDoc.AppendChild(objXmlDoc.CreateElement("", sRoot, ""));
                        objXmlDoc.Save(XmlFile);
                    }
                }
                objXmlDoc.Load(XmlFile);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            strXmlFile = XmlFile;
        }

        public DataTable GetData(string XmlPathNode)
        {
            //查找数据。返回一个DataTable 
            DataSet ds = new DataSet();
            StringReader read = new StringReader(objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds.Tables[0];
        }

        public void UpdateNode(string XmlPathNode, string Content)
        {
            //更新节点内容。 
            objXmlDoc.SelectSingleNode(XmlPathNode).InnerText = Content;
        }

        public void DeleteNode(string Node)
        {
            //删除一个节点。 
            string mainNode = Node.Substring(0, Node.LastIndexOf("/"));
            objXmlDoc.SelectSingleNode(mainNode).RemoveChild(objXmlDoc.SelectSingleNode(Node));
        }

        public void InsertNode(string MainNode, string ChildNode, string Element, string Content)
        {
            //插入一节点和此节点的一子节点。 
            XmlNode objRootNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objChildNode = objXmlDoc.CreateElement(ChildNode);
            objRootNode.AppendChild(objChildNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objChildNode.AppendChild(objElement);
        }

        public void InsertElement(string MainNode, string Element, string Attrib, string AttribContent, string Content)
        {
            //插入一个节点，带一属性。 
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.SetAttribute(Attrib, AttribContent);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
        }

        public void InsertElement(string MainNode, string Element, string Content)
        {
            //插入一个节点，不带属性。 
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
        }

        public void Save()
        {
            //保存文档。 
            try
            {
                objXmlDoc.Save(strXmlFile);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            objXmlDoc = null;
        }


        //实例应用： 

        //string strXmlFile = Server.MapPath("TestXml.xml"); 
        //XmlControl xmlTool = new XmlControl(strXmlFile); 

        // 数据显视 
        // dgList.DataSource = xmlTool.GetData("Book/Authors[ISBN=\"0002\"]"); 
        // dgList.DataBind(); 

        // 更新元素内容 
        // xmlTool.UpdateNode("Book/Authors[ISBN=\"0002\"]/Content","ppppppp"); 
        // xmlTool.Save(); 

        // 添加一个新节点 
        // xmlTool.InsertNode("Book","Author","ISBN","0004"); 
        // xmlTool.InsertElement("Book/Author[ISBN=\"0004\"]","Content","aaaaaaaaa"); 
        // xmlTool.InsertElement("Book/Author[ISBN=\"0004\"]","Title","Sex","man","iiiiiiii"); 
        // xmlTool.Save(); 

        // 删除一个指定节点的所有内容和属性 
        // xmlTool.DeleteNode("Book/Author[ISBN=\"0004\"]"); 
        // xmlTool.Save(); 

        // 删除一个指定节点的子节点 
        // xmlTool.DeleteNode("Book/Authors[ISBN=\"0003\"]"); 
        // xmlTool.Save();



    }
}
