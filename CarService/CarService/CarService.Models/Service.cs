using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models {

    // Услуга
    public class Service {

        public int Id { get; set; }

        public string Name { get; set; } // описание услуги
        public float Cost { get; set; } // стоимость услуги

        // коллекция сервисных листов, в которых оказывалась данная услуга
        public virtual ICollection<ServiceSheet> ServiceSheets { get; set; }

        public Service() {

            ServiceSheets = new HashSet<ServiceSheet>();

        }

    } // Service

}
