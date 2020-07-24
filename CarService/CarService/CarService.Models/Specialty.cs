using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models {

    // Специальность
    public class Specialty {

        public int Id { get; set; }

        public string Profession { get; set; } // наименование профессии

        // коллекция работников, принадлежащих данной профессии 
        public virtual ICollection<Worker> Workers { get; set; }

        // коллекция компетентных услуг специальности 
        public virtual ICollection<Service> Services { get; set; }

        public Specialty() {

            Workers = new HashSet<Worker>();
            Services = new HashSet<Service>();

        }

    }//Specialty

}
