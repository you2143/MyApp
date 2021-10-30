using ClosedXML.Excel;
using MyApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Output
{
    // 公式サイト
    // https://closedxml.readthedocs.io/en/latest/index.html
    // 参考にしたサイト
    // https://elleneast.com/?p=11853
    public class ExcelCreator        
    {
        public ExcelCreator() { }

        public void Create()
        {
            // WorkBookオブジェクト作成
            var workbook = new XLWorkbook();

            // WorkBookにWorkSheetを追加
            // これをせずにBookの保存も可能だが、開くときにエラーになる
            var worksheet = workbook.AddWorksheet("Sheet1");

            var data = new List<User>();
            var user = new User("1", "", -1);
            data.Add(user);

            for (var i = 0; i < 10000; i++)
            {
                var tmp = new User(i.ToString(), "あああ" + i, i);
                data.Add(tmp);
            }

            // セルの結合
            var header = worksheet.Range("A1:C1").Merge();
            header.Value = "列";
            // セルの背景に色を付ける
            header.Style.Fill.BackgroundColor = XLColor.Green;
            // セルの文字に色を付ける
            header.Style.Font.FontColor = XLColor.White;

            // データの登録
            // 開始セルを設定して、IEnumerableのオブジェクトを渡せば順番にセルに設定される
            // 返り値としてインサートした後のxlRangeオブジェクトが返ってくる
            var xlRange = worksheet.Cell(2, 1).InsertData(data);

            // テーブルに罫線を適用
            // Outsideは範囲の外枠
            // Insiddeは範囲の内側
            xlRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            xlRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // フォーマットの変更
            // フォーマットの内容についてはExcelの機能なので、どういう設定を行えばいいかはExcelの書式設定を調べること
            // なお、日本語でフォーマット設定は出来ないっぽいので、適宜英語にした時のフォーマット設定を適用すること
            // #,##0;[赤]-#,##0　←　これはClosedXMLでは登録不可
            // RangeであればRangeの列ごとにフォーマット可能
            xlRange.Column(3).Style.NumberFormat.Format = "#,##0;[red]-#,##0";

            // コンテンツに合わせて列幅を調整
            // 操作するオブジェクトはワークシートである点に注意
            // 1.全部の列を調整する
            worksheet.Columns().AdjustToContents();
            // 2.指定した列を調整する
            worksheet.Columns(1,1).AdjustToContents();            

            // Excelの保存
            // 強制的に上書き保存する。オプション無し。
            // 上書き先のExcelを開いているとSystem.IO.IOExceptionが発生する点に注意
            workbook.SaveAs("C:\\Users\\your0\\OneDrive\\デスクトップ\\test.xlsx");
        }
        
    }
}
