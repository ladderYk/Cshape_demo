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
        public static object _lock1 = new();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Base.ID = 0;
            RunTask();
            RunTask(true, false);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Base.ID = 0;
            RunTask(false);
            RunTask(false, false);
        }
        private void RunTask(bool isLock = true, bool isAdd = true)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    if (isLock)
                    {
                        lock (_lock)
                        {
                            if (isAdd) Base.ID += 3;
                            else Base.ID -= 3;
                        }
                    }
                    else
                    {
                        if (isAdd) Base.ID += 3;
                        else Base.ID -= 3;
                    }
                }
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Base.ID1 = 1000;
            for (int i = 0; i < 10; i++)
            {
                RunTask1(10);
            }
        }
        private void RunTask1(int num, bool isLock = true)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < (1000 / num); i++)
                {
                    if (isLock)
                    {
                        lock (_lock1)
                        {
                            Base.ID1--;
                        }
                    }
                    else
                    {
                        Base.ID1--;
                    }
                }
            });
        }



        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Base.ID1 = 1000;
            for (int i = 0; i < 10; i++)
            {
                RunTask1(10, false);
            }
        }
    }
}