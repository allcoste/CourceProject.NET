using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models {

    // Автомобиль
    public class Car {

        public int Id { get; set; }

        public virtual Person Owner { get; set; } // владелец
        public virtual Brand Brand { get; set; } // марка
        public string Model { get; set; } // модель
        public string Color { get; set; } // цвет
        public int Year { get; set; } // год выпуска
        public string RegNumber { get; set; } // регистрационный номер

        // акты проделанных над автомобилем ремонтов 
        public virtual ICollection<ActOfExecutedWorks> Acts { get; set; }

        public Car() {

            Acts = new HashSet<ActOfExecutedWorks>();

        }

    }//Car
}
