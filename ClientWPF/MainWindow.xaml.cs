using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Thread.Sleep(500);
            InitializeComponent();
            ViewModels.ViewModel VM = new ViewModels.ViewModel();
            DataContext = VM;
        }

        private void CarsDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            DataGrid s = sender as DataGrid;
            AIS_LAB2.Models.Car car = e.Row.Item as AIS_LAB2.Models.Car;
            if(!(car.Id is null))
            {
                e.Cancel = true;
                s.CancelEdit();
            }
        }
    }
}
