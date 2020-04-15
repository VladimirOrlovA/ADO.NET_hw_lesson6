using System.Data;
using System.Windows.Controls;

namespace ADO.NET_hw_lesson6.Pages
{
    /// <summary>
    /// Interaction logic for PageModel.xaml
    /// </summary>
    public partial class PageModel : Page
    {
        public PageModel(DataSet dataSet)
        {
            InitializeComponent();
            dgTable.ItemsSource = dataSet.Tables[0].DefaultView;
            gboxTableName.Header = dataSet.Tables[0].TableName;
        }
    }
}
