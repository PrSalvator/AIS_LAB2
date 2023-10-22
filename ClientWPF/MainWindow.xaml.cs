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
        private bool access = false;
        private int index = -1;
        ViewModels.ViewModel VM = new ViewModels.ViewModel();
        public MainWindow()
        {
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(OnErrorEvent));
            InitializeComponent();
            DataContext = VM;
        }

        private void OnErrorEvent(object sender, RoutedEventArgs e)
        {
            var validationEventArgs = e as ValidationErrorEventArgs;
            if (validationEventArgs == null)
                throw new Exception("Unexpected event args");
            switch (validationEventArgs.Action)
            {
                case ValidationErrorEventAction.Added:
                    {
                        break;
                    }
                case ValidationErrorEventAction.Removed:
                    {
                        break;
                    }
                default:
                    {
                        throw new Exception("Unknown action");
                    }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
