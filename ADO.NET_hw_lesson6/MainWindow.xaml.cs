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
        static string query;

        public MainWindow()
        {
            InitializeComponent();
            _MainFrame = fMainFrame;
            query = "SELECT * FROM ";
        }

        DataSet GetDataSet(string query)
        {
            dataAdapter = new SqlDataAdapter(query, connection);
            dataSet = new DataSet();
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
            GetDataSet(query + "dic_Status");
            _MainFrame.Navigate(new PageStatus(dataSet));
            PageViewSettings();
        }

        private void miPavilion_Click(object sender, RoutedEventArgs e)
        {
            GetDataSet(query + "dic_Pavilion");
            _MainFrame.Navigate(new PagePavilion(dataSet));
            PageViewSettings();
        }

        private void miModel_Click(object sender, RoutedEventArgs e)
        {
            //DataTableMapping mappingTable = new DataTableMapping("dic_Model", "Модель");
            //mappingTable.ColumnMappings.Add(new DataColumnMapping("ModelId", "Идентификатор модели"));
            //mappingTable.ColumnMappings.Add(new DataColumnMapping("Code", "Код"));
            //mappingTable.ColumnMappings.Add(new DataColumnMapping("Name", "Название"));
            //mappingTable.ColumnMappings.Add(new DataColumnMapping("SeriesId", "Идентификатор серии"));


            DataTableMapping mappingTable = new DataTableMapping("dic_Model", "Model");
            mappingTable.ColumnMappings.Add(new DataColumnMapping("ModelId", "Id"));
            mappingTable.ColumnMappings.Add(new DataColumnMapping("Code", "Codeeeee"));
            mappingTable.ColumnMappings.Add(new DataColumnMapping("Name", "Nameeeee"));
            mappingTable.ColumnMappings.Add(new DataColumnMapping("SeriesId", "Serrrr"));

            dataAdapter = new SqlDataAdapter(query+ "dic_Model", connection);
            dataAdapter.TableMappings.Add(mappingTable);

            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            _MainFrame.Navigate(new PageModel(dataSet));
        }

        private void rbtnCtor_Click(object sender, RoutedEventArgs e) 
        {
            GetDataSet(query + "dic_Group");
            _MainFrame.Navigate(new PageGroup(dataSet));
            _MainFrame.Visibility = Visibility.Visible;
        }

        private void rbtnSqlComm_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = query + "dic_Group";
            command.Connection = connection;
            dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            _MainFrame.Navigate(new PageGroup(dataSet));
            _MainFrame.Visibility = Visibility.Visible;
        }
    }
}
