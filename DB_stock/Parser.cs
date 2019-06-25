using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace DB_stock
{
    class Parser
    {
        private string url;
        private string company_name;

        public Parser(string url)
        {
            this.url = url;
        }
        public Parser(string url, string company_name)
        {
            this.url = url;
            this.company_name = company_name;
        }
        public void test()
        {
            if (company_name != "")
            {
                MessageBox.Show(url + "\n" + company_name);
            }
            else
            {
                MessageBox.Show(url);
            }
        }
        public void Parse()
        {
            var web = new HtmlWeb();
            web.OverrideEncoding = Encoding.Default;
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36";
            var htmlDoc = web.Load(url);
            ///html/body/table[1]/tbody/tr[*]
            //MessageBox.Show(trs.OuterHtml);
            List<string> Dates = new List<string>();    //날짜
            List<string> ClosingsPrices = new List<string>();   //종가
            List<string> AgoPrices = new List<string>();    //전일비
            for (int i = 3; i <= 15; i++)
            {
                string strnode = "/html/body/table[1]/tr[" + i.ToString() + "]";
                if (i == 8 || i == 9 || i == 10)
                    continue;
                var date = htmlDoc.DocumentNode
                    .SelectNodes(strnode + "/td[1]/span")
                    .First().InnerText;
                var closings_price = htmlDoc.DocumentNode
                    .SelectNodes(strnode + "/td[2]/span")
                    .First().InnerText;
                var agoprice1 = htmlDoc.DocumentNode
                    .SelectNodes("")
                    .First().InnerText;
                var agoprice2 = htmlDoc.DocumentNode
                    .SelectNodes("")
                    .First().InnerText;
                Dates.Add(date);
                ClosingsPrices.Add(closings_price);
            }
            for(int i = 0; i < Dates.Count(); i++)
            {
                MessageBox.Show("date : " + Dates[i] +"\nclosings : " + ClosingsPrices[i]);
            }
        }
    }
}
