using _20._101_Zibereva_V3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace _20._101_Zibereva_V3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            var dbContext = new Entities();//подключение базы
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "ID";
            textColumn.Binding = new Binding("IdDiscipline");
            LoadData.Columns.Add(textColumn);
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "Name";
            textColumn1.Binding = new Binding("Title");
            LoadData.Columns.Add(textColumn1);
            var discipline = dbContext.Discipline.Where(p => p.IdDiscipline == 2).ToList();//условия вывода по id
            try
            {
                if (discipline.Count != 0)
                {
                    LoadData.ItemsSource = discipline;
                }
            }
            catch
            {
                MessageBox.Show("По вашему запросу ничего не найдено.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);//вывод сообщения
            }
        }
    }
}
