using System.Data;
using System.Windows.Controls;

namespace ADO.NET_hw_lesson6.Pages
{
    /// <summary>
    /// Interaction logic for PageGroup.xaml
    /// </summary>
    public partial class PageGroup : Page
    {
        public PageGroup(DataSet dataSet)
        {
            InitializeComponent();
            dgTable.ItemsSource = dataSet.Tables[0].DefaultView;
        }
    }
}
