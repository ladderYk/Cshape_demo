using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainVM Base = new MainVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Base;
        }
        public static object _lock = new object();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            runTask();
            runTask(false);
        }
        private void runTask(bool isAdd = true)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    lock (_lock)
                    {
                        if (isAdd) Base.ID += 3;
                        else Base.ID -= 3;
                    }
                }
            });
        }
    }
}