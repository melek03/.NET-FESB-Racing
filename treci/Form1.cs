using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Windows.Forms;


namespace excel_reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Excel files| *.xls; *.xlsx",
                Title = "Select an excel file",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog.FileName;
                string filepath = openFileDialog.FileName;
                LoadExcelData(filepath);
            }
        }

        private void LoadExcelData(string filepath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filepath);
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1]; 

            int rCount = xlWorksheet.UsedRange.Rows.Count;
            int cCount = xlWorksheet.UsedRange.Columns.Count;

            DataTable dt = new DataTable();

            for (int col = 1; col <= cCount; col++)
            {
                dt.Columns.Add($"Column {col}");
            }

            for (int row = 1; row <= rCount; row++)
            {
                DataRow dataRow = dt.NewRow();
                for (int col = 1; col <= cCount; col++)
                {
                    dataRow[col - 1] = xlWorksheet.Cells[row, col].Value;
                }

                dt.Rows.Add(dataRow);
            }

            xlWorkbook.Close();
            xlApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            data_Grid.DataSource = dt;

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            data_Grid.DataSource = null;
            textBox.Text = string.Empty;
        }
    }
}
