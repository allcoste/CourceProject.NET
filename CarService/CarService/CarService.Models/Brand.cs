using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models
{

    // Марка автомобиля
    public class Brand {

        public int Id { get; set; }

        public string Name { get; set; } // название бренда

        // коллекция авто принадлежащих данному бренду
        public virtual ICollection<Car> Cars { get; set; }  

        public Brand() {

            Cars = new HashSet<Car>();

        }

    }//Brand
}
