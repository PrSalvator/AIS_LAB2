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
using ClientWPF.Models;
namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModels.ViewModel VM = new ViewModels.ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = VM;
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            VM.DeleteCar();
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            VM.AddCar();
        }

        private void CarsDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if(VM.SelectedCar.Id != 0)
            {
                e.Cancel = true;
            }
        }
    }
}
