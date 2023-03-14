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
using TourOperator.Model;
using TourOperator.Model.Window;
using TourOperator.Window;

namespace TourOperator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        private Tours selectedTour;
        public MainWindow()
        {
            InitializeComponent();
            UpdateInfo();
            dataGridView1.SelectionMode = DataGridSelectionMode.Single;//выбор только одной строки
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;//при выборе новой строки перезаписывается selectedTour

        }
        public void UpdateInfo()
        {
            var dbContext = new TourOperatorEntities();
            var tours = dbContext.Tours.ToList();
            dataGridView1.ItemsSource = tours;
        }
        private void BtnAddTour_Click(object sender, RoutedEventArgs e)
        {
            TourAdd tourAdd = new TourAdd(UpdateInfo);
            tourAdd.Show();
        }

        private void BtnEditTour_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTour == null)
            {
                MessageBox.Show("Выберите тур для редактирования.");
                return;
            }

            // Создание нового окна
            TourEdit tourEdit = new TourEdit(selectedTour, UpdateInfo);

            tourEdit.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTour = dataGridView1.SelectedItem as Tours;//выбираем поле из таблицы таблицы
        }

        private void BtnDeleteTour_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTour == null)
            {
                MessageBox.Show("Выберите тур для удаления.");
                return;
            }

            // Подтверждение удаления тура
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранный тур?", "Удаление тура", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var dbContext = new TourOperatorEntities();
                var tourToDelete = dbContext.Tours.FirstOrDefault(t => t.TourID == selectedTour.TourID);

                if (tourToDelete != null)
                {
                    dbContext.Tours.Remove(tourToDelete);
                    dbContext.SaveChanges();

                    // Обновление информации на форме
                    UpdateInfo();
                    MessageBox.Show("Тур успешно удален из базы данных.");
                }
                else
                {
                    MessageBox.Show("Выбранный тур не найден в базе данных.");
                }
            }
        }


    }
}
