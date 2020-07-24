using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models {

    // Персона
    public class Person {

        public int Id { get; set; }

        // ФИО
        public string Surname { get; set; } 
        public string Name { get; set; } 
        public string Patronymic { get; set; } 

        public string Passport { get; set; } // серия/номер паспорта
        public DateTime DateOfBirth { get; set; } // дата рождения 
        public string Registration { get; set; } // место регистрации

        public virtual Client Client { get; set; }
        public virtual Worker Worker { get; set; }

        // Коллекция автомобилей, владельцем которых является данная персона
        public virtual ICollection<Car> Cars { get; set; }

        public Person() {

            Cars = new HashSet<Car>();

        }

    }//Person
}
