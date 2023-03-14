using System;
using System.Linq;
using System.Windows;
using TourOperator.Model;

namespace TourOperator.Window
{
    /// <summary>
    /// Логика взаимодействия для TourEdit.xaml
    /// </summary>
    public partial class TourEdit
    {
        private readonly int tourID;
        private Tours Tour;
        private readonly Action _updateInfo;

        public TourEdit(Tours tour, Action updateInfo)
        {
            InitializeComponent();
            _updateInfo = updateInfo;
            this.tourID = tour.TourID;
            LoadTour();
        }

        private void LoadTour()
        {
            // Загрузка данных тура из БД
            var dbContext = new TourOperatorEntities();
            Tour = dbContext.Tours.Find(tourID);

            // Заполнение полей формы значениями из БД
            txtDestination.Text = Tour.Destination;
            txtStatus.Text = Tour.Status;
            datePickerStart.SelectedDate = Tour.StartDate;
            datePickerEnd.SelectedDate = Tour.EndDate;
            txtCulturalProgram.Text = Tour.CulturalProgram;
            txtBusinessProgram.Text = Tour.BusinessProgram;
        }

        // Обработчик нажатия на кнопку сохранения изменений
        private void BtnSave_Click_1(object sender, RoutedEventArgs e)
        {
            if (datePickerStart.SelectedDate > datePickerEnd.SelectedDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDestination.Text) ||
                string.IsNullOrEmpty(txtStatus.Text) ||
                !datePickerStart.SelectedDate.HasValue ||
                !datePickerEnd.SelectedDate.HasValue ||
                string.IsNullOrEmpty(txtCulturalProgram.Text) ||
                string.IsNullOrEmpty(txtBusinessProgram.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var dbContext = new TourOperatorEntities();
            Tour = dbContext.Tours.Find(tourID);

            // Обновление данных в выбранном туре
            Tour.Destination = txtDestination.Text;
            Tour.Status = txtStatus.Text;
            Tour.StartDate = (DateTime)datePickerStart.SelectedDate;
            Tour.EndDate = (DateTime)datePickerEnd.SelectedDate;
            Tour.CulturalProgram = txtCulturalProgram.Text;
            Tour.BusinessProgram = txtBusinessProgram.Text;
            Tour.GuideID = Tour.GuideID;
            Tour.AccountantID = Tour.AccountantID;

            dbContext.SaveChanges(); // Сохранение изменений в БД
            _updateInfo();
            MessageBox.Show("Данные успешно сохранены", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

            // Закрытие окна
            Close();
        }
    }
}
