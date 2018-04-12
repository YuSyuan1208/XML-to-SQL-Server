using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = XElement.Load(@"W:\高三下\多媒體系統\xml解析\35_1.xml");
            List<OpenData> NodeList = new List<OpenData>();
            var nodes = reader.Elements();
            NodeList = nodes
                .Where(x => !x.IsEmpty).ToList()
                .Select(node =>
                {
                    var item = new OpenData();
                    item.機構名稱 = node.Element("機構名稱")?.Value.Trim();
                    item.機構狀態 = node.Element("機構狀態")?.Value.Trim();
                    item.地址 = node.Element("地址縣市別")?.Value.Trim() +
                    node.Element("地址鄉鎮市區")?.Value.Trim() +
                    node.Element("地址街道巷弄號")?.Value.Trim();
                    item.電話 = node.Element("電話")?.Value.Trim();
                    return item;
                }).ToList();
            NodeList.ForEach(group =>
            {
             /* Console.WriteLine(group.機構名稱);
                Console.WriteLine(group.機構狀態);
                Console.WriteLine(group.地址);
                Console.WriteLine(group.電話);
                Console.WriteLine();*/
                Broker SqlData;
                SqlData = new Broker();
                SqlData.insert(group);
            });
            
            Console.ReadKey();
        }
    }
}
