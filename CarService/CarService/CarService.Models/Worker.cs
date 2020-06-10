using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models {

    // Работник
    public class Worker {

        public int Id { get; set; }

        public virtual Person Person {get; set;} // паспортные данные
        public virtual Specialty Specialty { get; set; } // специальность

        // флаг занятости работника(true - занят, false - свободен)
        public bool Busy { get; set; } 
        public int Discharge { get; set; } // разряд
        public int WorkExperience { get; set; } // стаж работы в годах
        public bool Salaried { get; set; } // состояние работает/уволен 

        // коллекция сервисных листов, ремонтом которых занимался данный сотрудник
        public virtual ICollection<ServiceSheet> ServiceSheets { get; set; }

        public Worker() {

            ServiceSheets = new HashSet<ServiceSheet>();

        }

    }//Worker
}
