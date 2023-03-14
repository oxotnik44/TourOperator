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
using System.Windows.Shapes;

namespace TourOperator.Model.Window
{
    /// <summary>
    /// Логика взаимодействия для TourAdd.xaml
    /// </summary>
    public partial class TourAdd
    {
        private readonly Action _updateInfo;

        public TourAdd(Action updateInfo)
        {
            InitializeComponent();
            _updateInfo = updateInfo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(destinationTextBox.Text) || string.IsNullOrWhiteSpace(culturalProgramTextBox.Text) || string.IsNullOrWhiteSpace(businessProgramTextBox.Text) || string.IsNullOrWhiteSpace(statusComboBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (startDatePicker.SelectedDate.HasValue && endDatePicker.SelectedDate.HasValue && startDatePicker.SelectedDate.Value > endDatePicker.SelectedDate.Value)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TourOperatorEntities db = new TourOperatorEntities();
            int lastTourId = db.Tours.Max(t => t.TourID);
            int lastGuidesId = db.Guides.Max(t => t.GuideID);
            int lastAccountantId = db.Accountant.Max(t => t.AccountantID);
            Tours newTour = new Tours
            {
                TourID = lastTourId + 1,
                GuideID = lastGuidesId,
                AccountantID = lastAccountantId,
                Destination = destinationTextBox.Text,
                CulturalProgram = culturalProgramTextBox.Text,
                BusinessProgram = businessProgramTextBox.Text,
                StartDate = startDatePicker.SelectedDate.Value,
                EndDate = endDatePicker.SelectedDate.Value,
                Status = statusComboBox.Text
            };
            db.Tours.Add(newTour);
            db.SaveChanges();

            _updateInfo();
            Close();
        }
    }
}
