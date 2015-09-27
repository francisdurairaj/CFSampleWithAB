using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Xml;
using System.Xml.Linq;


namespace WebApiSample.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/



        public string AddXml(string MakeName, string ModelName, string NoofViews)
        {
            string filepath = Server.MapPath("~/wwwroot/data/Test.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNode root = doc.DocumentElement;
            //Create a new node.
            XmlElement Make = doc.CreateElement("Make");
            XmlElement Model = doc.CreateElement("Model");
            Model.InnerText = MakeName;
            XmlElement Views = doc.CreateElement("Views");
            root.AppendChild(Make);
            Views.InnerText = ModelName;
            Make.AppendChild(Model);
            Make.AppendChild(Views);
            doc.Save(filepath);
            return "good";
        }

        [HttpPost]
        //public string AddXmltoTest(List lst)
        public string AddXmltoTest()
        {

            string filepath2 = Server.MapPath("~/wwwroot/data/Test.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath2);
            XmlNode root = doc.DocumentElement;
            //Create a new node.
            XmlElement userEle = doc.CreateElement("List");
            XmlElement firstnameEle = doc.CreateElement("Make");
            firstnameEle.InnerText = "Apple";
            XmlElement lastnameEle = doc.CreateElement("Model");
            lastnameEle.InnerText = "I Phone";
            XmlElement emailEle = doc.CreateElement("Views");
            emailEle.InnerText = "5";
            userEle.AppendChild(firstnameEle);
            userEle.AppendChild(lastnameEle);
            userEle.AppendChild(emailEle);
            //   root.AppendChild(userEle);
            // doc.Save(filepath2);


            //XDocument doc1 = XDocument.Parse(filepath2);
            // or if you have related file simply use 
            XDocument doc1 = XDocument.Load(filepath2);
            var element =
                  doc1.Descendants("Library").Elements("List")
                  .Where(x => x.Element("Make") != null
                        && x.Element("Make").Value == "Apple").SingleOrDefault();
            if (element != null)
            {
                var attr = element.Element("Views");
                attr.Value = Convert.ToString( Convert.ToInt32(attr.Value) + 1);
            }

            doc1.Save(filepath2);

            return "good";
        }

    }
}
