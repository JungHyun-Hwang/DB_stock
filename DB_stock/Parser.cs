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
        private List<string> Dates;    //날짜
        private List<string> ClosingsPrices;   //종가
        private List<string> AgoPrices;    //전일비
        private List<string> MarketValues;  //시가
        private List<string> HighValues;    //고가
        private List<string> LowValues;     //저가
        private List<string> Volumes;       //거래량

        public Parser(string url)
        {
            this.url = url;
        }
        public Parser(string url, string company_name)
        {
            this.url = url;
            this.company_name = company_name;
        }

        public void InitList()
        {
            Dates = new List<string>();
            ClosingsPrices = new List<string>();
            AgoPrices = new List<string>();
            MarketValues = new List<string>();
            HighValues = new List<string>();
            LowValues = new List<string>();
            Volumes = new List<string>();
        }
        public void Parse()
        {
            InitList();
            var web = new HtmlWeb();
            web.OverrideEncoding = Encoding.Default;
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36";
            var htmlDoc = web.Load(url);
            ///html/body/table[1]/tbody/tr[*]
            //MessageBox.Show(trs.OuterHtml);
            
            for (int i = 3; i <= 15; i++)
            {
                string RootNode = "/html/body/table[1]/tr[" + i.ToString() + "]";
                if (i == 8 || i == 9 || i == 10)
                    continue;
                List<string> datas = ReturnDatas(htmlDoc, i);
                Dates.Add(datas[0]);
                ClosingsPrices.Add(datas[1]);
                AgoPrices.Add(datas[2] + datas[3]);
                MarketValues.Add(datas[4]);
                HighValues.Add(datas[5]);
                LowValues.Add(datas[6]);
                Volumes.Add(datas[7]);
            }
            for(int i = 0; i < Dates.Count(); i++)
            {
                MessageBox.Show("date : " + Dates[i] + ","
                    + "\nclosings : "  + ClosingsPrices[i] + ","
                    + "\nAgoPrices : " + AgoPrices[i] + ","
                    + "\nMarketValues : " + MarketValues[i] + ","
                    + "\nHighValues : " + HighValues[i] + ","
                    + "\nLowValues : " + LowValues[i] + ","
                    + "\nVolumes : " + Volumes[i] + ","
                    , (i+1).ToString());
            }
        }

        static List<string> ReturnDatas(HtmlAgilityPack.HtmlDocument htmlDoc, int tr_num)
        {
            List<string> datas = new List<string>();
            string RootNode = "/html/body/table[1]/tr[" + tr_num.ToString() + "]";
            //0 - date
            datas.Add(htmlDoc.DocumentNode
                    .SelectNodes(RootNode + "/td[1]/span")
                    .First().InnerText);

            //1 - losings_price
            datas.Add(htmlDoc.DocumentNode
                .SelectNodes(RootNode + "/td[2]/span")
                .First().InnerText.Replace("," ,""));

            //2 - "+", "-", ""
            datas.Add(Getagoprice1(htmlDoc, RootNode));

            //3 - agoprice_value
            datas.Add(htmlDoc.DocumentNode
                    .SelectNodes(RootNode + "/td[3]/span")
                    .First().InnerText
                    .Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace(",",""));
            //4 - MarketValue
            datas.Add(htmlDoc.DocumentNode
                    .SelectNodes(RootNode + "/td[4]/span")
                    .First().InnerText.Replace(",", ""));

            //5 - HighValue
            datas.Add(htmlDoc.DocumentNode
                    .SelectNodes(RootNode + "/td[5]/span")
                    .First().InnerText.Replace(",", ""));

            //6 - LowValue
            datas.Add(htmlDoc.DocumentNode
                    .SelectNodes(RootNode + "/td[6]/span")
                    .First().InnerText.Replace(",", ""));

            //7 - Volume
            datas.Add(htmlDoc.DocumentNode
                    .SelectNodes(RootNode + "/td[7]/span")
                    .First().InnerText.Replace(",", ""));
            return datas;
        }
        static string Getagoprice1(HtmlAgilityPack.HtmlDocument htmlDoc, string RootNode)
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
    }
}
