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
        private MainVM Base = new();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Base;
        }
        public static object _lock = new();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RunTask();
            RunTask(false);
        }
        private void RunTask(bool isAdd = true)
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