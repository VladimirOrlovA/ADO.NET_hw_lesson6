using ADO.NET_hw_lesson6.Pages;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ADO.NET_hw_lesson6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Frame _MainFrame;
        static string connStr = ConfigurationManager.ConnectionStrings["SqlClient"].ConnectionString;
        static SqlConnection connection = new SqlConnection(connStr);
        static SqlDataAdapter dataAdapter;
        static DataSet dataSet;
        DataTableMapping tableMapping;
        static string query;

        public MainWindow()
        {
            InitializeComponent();
            _MainFrame = fMainFrame;
            query = "SELECT * FROM ";
        }

        DataSet GetDataSet(string query, string tableName)
        {
            dataAdapter = new SqlDataAdapter(query, connection);
            dataSet = new DataSet();
            tableMapping = new DataTableMapping("Table", $"Таблица {tableName}");
            dataAdapter.TableMappings.Add(tableMapping);
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        void PageViewSettings()
        {
            _MainFrame.Visibility = Visibility.Visible;
            spAddOptions.Visibility = Visibility.Hidden;
        }

        private void miGroup_Click(object sender, RoutedEventArgs e)
        {
            _MainFrame.Visibility = Visibility.Hidden;
            spAddOptions.Visibility = Visibility.Visible;
        }

        private void miStatus_Click(object sender, RoutedEventArgs e)
        {
            GetDataSet(query + "dic_Status", "Статус");
            _MainFrame.Navigate(new PageStatus(dataSet));
            PageViewSettings();
        }

        private void miPavilion_Click(object sender, RoutedEventArgs e)
        {
            GetDataSet(query + "dic_Pavilion", "Павильон");
            _MainFrame.Navigate(new PagePavilion(dataSet));
            PageViewSettings();
        }

        private void miModel_Click(object sender, RoutedEventArgs e)
        {
            dataAdapter = new SqlDataAdapter(query + "dic_Model", connection);
            DataTableMapping tableMapping = new DataTableMapping("Table", "Таблица Модель");
            tableMapping.ColumnMappings.Add(new DataColumnMapping("ModelId", "Идентификатор модели"));
            tableMapping.ColumnMappings.Add(new DataColumnMapping("Code", "Код"));
            tableMapping.ColumnMappings.Add(new DataColumnMapping("Name", "Название"));
            tableMapping.ColumnMappings.Add(new DataColumnMapping("SeriesId", "Идентификатор серии"));

            dataSet = new DataSet();
            dataAdapter.TableMappings.Add(tableMapping);
            dataAdapter.Fill(dataSet);
            dataAdapter.Dispose();

            _MainFrame.Navigate(new PageModel(dataSet));
        }

        private void rbtnCtor_Click(object sender, RoutedEventArgs e)
        {
            spAddOptions.Visibility = Visibility.Hidden;

            GetDataSet(query + "dic_Group", "Группа");
            _MainFrame.Navigate(new PageGroup(dataSet));
            _MainFrame.Visibility = Visibility.Visible;
        }

        private void rbtnSqlComm_Click(object sender, RoutedEventArgs e)
        {
            spAddOptions.Visibility = Visibility.Hidden;

            SqlCommand command = new SqlCommand();
            command.CommandText = query + "dic_Group";
            command.Connection = connection;
            dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            dataAdapter.TableMappings.Add(new DataTableMapping("Table", "Таблица Группа"));
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            _MainFrame.Navigate(new PageGroup(dataSet));
            _MainFrame.Visibility = Visibility.Visible;
        }
    }
}
