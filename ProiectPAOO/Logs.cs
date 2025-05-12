using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProiectPAOO.Repositories;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WinForms; // for the WinForms control
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Defaults;




namespace ProiectPAOO
{
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            ReadLogs();
            DisplaySalesPieChart();
            tabPage1.Text = "Data";
            tabPage2.Text = "Charts";
            DisplayMonthlySalesBarChart();
        }

        private void ReadLogs()
        {
            DataTable logsDataTable = new DataTable();

            logsDataTable.Columns.Add("ID");
            logsDataTable.Columns.Add("User ID");
            logsDataTable.Columns.Add("Instrument ID");
            logsDataTable.Columns.Add("Quantity");
            logsDataTable.Columns.Add("Purchase Date");
            logsDataTable.Columns.Add("Total Price");
            logsDataTable.Columns.Add("Status");
            logsDataTable.Columns.Add("Address");

            var repo = new LogRepository();
            var logs = repo.GetLogs();

            foreach (var log in logs)
            {
                var row = logsDataTable.NewRow();
                row["ID"] = log.Id;
                row["User ID"] = log.UserId;
                row["Instrument ID"] = log.InstrumentId;
                row["Quantity"] = log.Quantity;
                row["Purchase Date"] = log.PurchaseDate;
                row["Total Price"] = log.TotalPrice;
                row["Status"] = log.OrderStatus;
                row["Address"] = log.ShippingAddress;

                logsDataTable.Rows.Add(row);
            }
            dataGridView1.DataSource = logsDataTable;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string newStatus = comboBox1.SelectedItem.ToString();
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

                dataGridView1.CurrentRow.Cells["Status"].Value = newStatus;
                var repo = new LogRepository();
                repo.UpdateStatus(id, newStatus);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string status = dataGridView1.CurrentRow.Cells["status"].Value?.ToString();
                if (!string.IsNullOrEmpty(status))
                    comboBox1.SelectedItem = status;
                else comboBox1.SelectedItem = -1;
            }
        }

        private void DisplaySalesPieChart()
        {
            var salesData = new LogRepository().GetSalesChartByCategory();
            var pieSeries = salesData.Select(kvp => new PieSeries<ObservableValue>
            {
                Name = kvp.Key,
                Values = new[] { new ObservableValue(kvp.Value) },
                DataLabelsSize = 16,

                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle
            }).ToList<ISeries>();
            pieChart1.Series = pieSeries;
            pieChart1.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
        }

        private void DisplayMonthlySalesBarChart()
        {
            var salesData = new LogRepository().GetMonthlySalesForYear(DateTime.Now.Year);

            var labels = salesData.Keys.ToArray();
            var values = salesData.Values.Select(v => (double)v).ToArray();

            var barSeries = new ColumnSeries<double>
            {
                Name = "Instruments Sold",
                Values = values
            };

            cartesianChart1.Series = new ISeries[] { barSeries };

            cartesianChart1.XAxes = new[]
            {
        new Axis
        {
            Labels = labels,
            LabelsRotation = 15,
            Name = "Month"
        }
    };

            cartesianChart1.YAxes = new[]
            {
        new Axis
        {
            Name = "Units Sold"
        }
    };
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Save Sales Report"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                new LogRepository().ExportSalesByCategoryToCsv(saveDialog.FileName);
                MessageBox.Show("CSV report exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
