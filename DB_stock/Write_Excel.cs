using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;

namespace DB_stock
{
    class Write_Excel
    {
        List<List<string>> datas;
        public Write_Excel(List<List<string>> datas)
        {
            this.datas = datas;
        }

        public void PrintExcel()
        {
            object miss = Type.Missing;
            MessageBox.Show(datas[0].Count().ToString());
            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;
            try
            {
                excelApp = new Excel.Application();
                //excelApp.Visible = false;
                string ExcelPath = AppDomain.CurrentDomain.BaseDirectory + "data.xlsx";
                if (System.IO.File.Exists(ExcelPath))
                {
                    //wb = excelApp.Workbooks.Add(miss);
                    wb = excelApp.Workbooks.Open(Filename:ExcelPath);
                    int sheet_cnt = wb.Worksheets.Count;
                    ws = wb.Worksheets.Add(After:wb.Sheets["Sheet"+sheet_cnt.ToString()]);
                    sheet_cnt = wb.Worksheets.Count;
                    ws = (Excel.Worksheet)wb.Sheets["Sheet" + sheet_cnt.ToString()];
                }
                else
                {
                    wb = excelApp.Workbooks.Add(miss);
                    ws = (Excel.Worksheet)wb.Sheets["Sheet1"];
                }
                WriteCell(ws, datas);
                wb.SaveAs(ExcelPath, miss, miss, miss, miss, miss,
                    Excel.XlSaveAsAccessMode.xlExclusive, Excel.XlSaveConflictResolution.xlLocalSessionChanges,
                    miss, miss, miss, miss);
                MessageBox.Show("Make Success");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                wb.Close();
                excelApp.Quit();
            }
        }
        static void WriteCell(Excel.Worksheet ws, List<List <string>> datas)
        {
            if(datas.Count == 7)
            {
                ws.Cells[1, 1] = "날짜";
                ws.Cells[1, 2] = "종가";
                ws.Cells[1, 3] = "전일비";
                ws.Cells[1, 4] = "시가";
                ws.Cells[1, 5] = "고가";
                ws.Cells[1, 6] = "저가";
                ws.Cells[1, 7] = "거래량";
                for(int i = 0; i < datas.Count; i++)
                {
                    for(int j = 0; j < datas[i].Count; j++)
                    {
                        ws.Cells[j + 2, i + 1] = datas[i][j];
                    }
                }

            }
            else if(datas.Count == 6)
            {
                ws.Cells[1, 1] = "날짜";
                ws.Cells[1, 2] = "체결가";
                ws.Cells[1, 3] = "전일비";
                ws.Cells[1, 4] = "등락률";
                ws.Cells[1, 5] = "거래량";
                ws.Cells[1, 6] = "거래대금";
                for(int i = 0; i < datas.Count; i++)
                {
                    for(int j = 0; j < datas[i].Count; j++)
                    {
                        ws.Cells[j + 2, i + 1] = datas[i][j];
                    }
                }
            }
        }
    }
}
