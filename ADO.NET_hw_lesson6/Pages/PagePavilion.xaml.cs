using System.Data;
using System.Windows.Controls;

namespace ADO.NET_hw_lesson6.Pages
{
    /// <summary>
    /// Interaction logic for PagePavilion.xaml
    /// </summary>
    public partial class PagePavilion : Page
    {
        public PagePavilion(DataSet dataSet)
        {
            InitializeComponent();
            dgTable.ItemsSource = dataSet.Tables[0].DefaultView;
            gboxTableName.Header = dataSet.Tables[0].TableName;
        }
    }
}
