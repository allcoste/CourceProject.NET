using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models {

    // Запасная часть
    public class SparePart {

        public int Id { get; set; }

        public string Name { get; set; } // наименование запчасти
        public float Cost { get; set; } // стоимость 

        // коллекция сервисных листов, в которых использовалась данная запчасть
        public virtual ICollection<ServiceSheet> ServiceSheets { get; set; }

        public SparePart() {

            ServiceSheets = new HashSet<ServiceSheet>();

        }

    }//SpareParts

}
