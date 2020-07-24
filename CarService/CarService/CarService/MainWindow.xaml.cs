using CarService.DataAccess;
using CarService.Models;
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

namespace CarService {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            using (CarServiceDbContext db = new CarServiceDbContext()) {

                List<Specialty> specialties = db.Specialties.ToList();

                specialties.ForEach(sp => txb.Text += $"{sp.Profession}\n");

                //db.Specialties.Add(new Specialty { Profession = "Шиномонтажник" });
                //db.SaveChanges();
            }
        }
    }
}
