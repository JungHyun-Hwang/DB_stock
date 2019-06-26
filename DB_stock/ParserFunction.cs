using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_stock
{
    class ParserFunction
    {
        public static List<string> ReturnDatas(HtmlAgilityPack.HtmlDocument htmlDoc, string RootNode, int len)
        {
            List<string> datas = new List<string>();
            
            for (int i = 1; i <= len; i++)
            {
                if (i == 3)
                {
                    datas.Add(Getagoprice1(htmlDoc, RootNode));
                    datas.Add(GetNode(htmlDoc, RootNode, i).Replace("\n", "").Replace("\t", ""));
                }
                else
                {
                    datas.Add(GetNode(htmlDoc, RootNode, i));
                }
            }
            return datas;
        }
        public static string Getagoprice1(HtmlAgilityPack.HtmlDocument htmlDoc, string RootNode)
        {
            string agoprice1 = "";
            try
            {
                agoprice1 = htmlDoc.DocumentNode
                    .SelectNodes(RootNode + "/td[3]/img")
                    .First().Attributes["alt"].Value;
            }
            catch (ArgumentNullException)
            {
                agoprice1 = "n/a";
            }
            if (agoprice1.Equals("상승"))
            {
                agoprice1 = "+";
            }
            else if (agoprice1.Equals("하락"))
            {
                agoprice1 = "-";
            }
            else if (agoprice1.Equals("n/a"))
            {
                agoprice1 = "";
            }
            return agoprice1;
        }
        static string GetNode(HtmlAgilityPack.HtmlDocument htmlDoc, string RootNode, int num)
        {
            return htmlDoc.DocumentNode
                    .SelectNodes(RootNode + "/td[" + num.ToString() + "]")
                    .First().InnerText.Replace(",", "");
        }
    }
}
