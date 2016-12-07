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
            // TODO: ��������뽨����ʽ�ĳ������ 
            // 
            try
            {
                //����ļ��Ƿ���ڣ��������򴴽�
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
                //�������ģʽ����ǿ�д���һ��xml�ĵ�
                if (bOverWrite)
                {
                    objXmlDoc.AppendChild(objXmlDoc.CreateXmlDeclaration("1.0", "gb2312", null));//����xml�İ汾����ʽ��Ϣ
                    objXmlDoc.AppendChild(objXmlDoc.CreateElement("", sRoot, ""));//������Ԫ��
                    objXmlDoc.Save(XmlFile);//����
                }
                else //���򣬼���ļ��Ƿ���ڣ��������򴴽�
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
            //�������ݡ�����һ��DataTable 
            DataSet ds = new DataSet();
            StringReader read = new StringReader(objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds.Tables[0];
        }

        public void UpdateNode(string XmlPathNode, string Content)
        {
            //���½ڵ����ݡ� 
            objXmlDoc.SelectSingleNode(XmlPathNode).InnerText = Content;
        }

        public void DeleteNode(string Node)
        {
            //ɾ��һ���ڵ㡣 
            string mainNode = Node.Substring(0, Node.LastIndexOf("/"));
            objXmlDoc.SelectSingleNode(mainNode).RemoveChild(objXmlDoc.SelectSingleNode(Node));
        }

        public void InsertNode(string MainNode, string ChildNode, string Element, string Content)
        {
            //����һ�ڵ�ʹ˽ڵ��һ�ӽڵ㡣 
            XmlNode objRootNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objChildNode = objXmlDoc.CreateElement(ChildNode);
            objRootNode.AppendChild(objChildNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objChildNode.AppendChild(objElement);
        }

        public void InsertElement(string MainNode, string Element, string Attrib, string AttribContent, string Content)
        {
            //����һ���ڵ㣬��һ���ԡ� 
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.SetAttribute(Attrib, AttribContent);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
        }

        public void InsertElement(string MainNode, string Element, string Content)
        {
            //����һ���ڵ㣬�������ԡ� 
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
        }

        public void Save()
        {
            //�����ĵ��� 
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


        //ʵ��Ӧ�ã� 

        //string strXmlFile = Server.MapPath("TestXml.xml"); 
        //XmlControl xmlTool = new XmlControl(strXmlFile); 

        // �������� 
        // dgList.DataSource = xmlTool.GetData("Book/Authors[ISBN=\"0002\"]"); 
        // dgList.DataBind(); 

        // ����Ԫ������ 
        // xmlTool.UpdateNode("Book/Authors[ISBN=\"0002\"]/Content","ppppppp"); 
        // xmlTool.Save(); 

        // ���һ���½ڵ� 
        // xmlTool.InsertNode("Book","Author","ISBN","0004"); 
        // xmlTool.InsertElement("Book/Author[ISBN=\"0004\"]","Content","aaaaaaaaa"); 
        // xmlTool.InsertElement("Book/Author[ISBN=\"0004\"]","Title","Sex","man","iiiiiiii"); 
        // xmlTool.Save(); 

        // ɾ��һ��ָ���ڵ���������ݺ����� 
        // xmlTool.DeleteNode("Book/Author[ISBN=\"0004\"]"); 
        // xmlTool.Save(); 

        // ɾ��һ��ָ���ڵ���ӽڵ� 
        // xmlTool.DeleteNode("Book/Authors[ISBN=\"0003\"]"); 
        // xmlTool.Save();



    }
}
