using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_stock
{
    class KosParser
    {
        private string url;
        private List<string> Dates;    //날짜
        private List<string> TradePrices;   //체결가
        private List<string> AgoPrices;    //전일비
        private List<string> Fluctuations;  //등락률
        private List<string> Volumes;       //거래량
        private List<string> Payments;     //거래대금

        public KosParser(string url)
        {
            this.url = url;
        }

        void InitList()
        {
            Dates = new List<string>();
            TradePrices = new List<string>();
            AgoPrices = new List<string>();
            Fluctuations = new List<string>();
            Volumes = new List<string>();
            Payments = new List<string>();
        }

        public List<List<string>> Parse()
        {
            List<List<string>> res = new List<List<string>>();
            const string page = "&page=";
            InitList();
            for(int cnt = 1; cnt <= 20; cnt++)
            {
                string cur_page = page + cnt.ToString();
                string cur_url = url + cur_page;
                var web = new HtmlWeb();
                web.OverrideEncoding = Encoding.Default;
                web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36";
                var htmlDoc = web.Load(cur_url);
                for (int i = 3; i <= 12; i++)
                {
                    string RootNode = "/html/body/div/table[1]/tr[" + i.ToString() + "]";
                    if (i == 6 || i == 7 || i == 8 || i == 9)
                        continue;
                    List<string> datas = ParserFunction.ReturnDatas(htmlDoc, RootNode, len: 6);
                    Dates.Add(datas[0]);
                    TradePrices.Add(datas[1]);
                    AgoPrices.Add(datas[2] + datas[3]);
                    Fluctuations.Add(datas[4].Replace("\n", "").Replace("\t", ""));
                    Volumes.Add(datas[5]);
                    Payments.Add(datas[6]);
                }
            }
            res.Add(Dates);
            res.Add(TradePrices);
            res.Add(AgoPrices);
            res.Add(Fluctuations);
            res.Add(Volumes);
            res.Add(Payments);
            return res;
        }
    }
}
