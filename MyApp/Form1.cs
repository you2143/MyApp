using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyApp.Application.Employees;
using MyApp.Application.Output;
using MyApp.Application.Users;
using MyApp.Common;
using MyApp.Infrastructure;
using MyApp.Infrastructure.Employees;

namespace MyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // DataGridにボタンを表示するのはフォームのプロパティで設定している
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // DataSourceにデータを追加したときに列が追加されないようにする
            // https://tmg0525.hatenadiary.jp/entry/2017/11/24/163727
            dataGridView1.AutoGenerateColumns = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var test = new UserApplicationService().GetAllUserData();

            // クラスのデータとDataGridの紐づけはフォーム内のDataGrid内で行っている
            // 以下のURLを参照
            // https://tmg0525.hatenadiary.jp/entry/2017/11/24/163727
            dataGridView1.DataSource = test.ToList();
            //var excelCreator = new ExcelCreator();
            //excelCreator.Create();
            //MessageBox.Show("完了");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ボタン列でイベントを処理する場合は以下のURLを参考に
            // https://stackoverflow.com/questions/3577297/how-to-handle-click-event-in-button-column-in-datagridview/13687844
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = ConnectionInstance.Connection;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NLogService.PrintInfoLog("Hello World");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var app = new EmployeeApplication(new EmployeeRepository());
            app.CreateEmployee(TxtEmployeeId.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var app = new EmployeeApplication(new EmployeeRepository());
            // var data = app.GetEmployee(TxtEmployeeId.Text);
            var data = app.GetAllEmployee();
            dataGridView1.DataSource = data.ToList();
        }
    }
}
