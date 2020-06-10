using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models {

    // Сервисный лист
    public class ServiceSheet {

        public int Id { get; set; }

        // акт, к которому принадлежит сервисный лист
        public virtual ActOfExecutedWorks Act { get; set; } 
        public virtual Service Service { get; set; } // услуга
        public virtual Worker Worker { get; set; } // работник устраняющий неисправность
        public int EliminationTime { get; set; } // время устранения в часах
        public bool Performed { get; set; } // статус готовности

        // список запчастей, установленных при устранении неисправности
        public virtual ICollection<SparePart> SpareParts { get; set; }

        public ServiceSheet() {

            SpareParts = new HashSet<SparePart>();

        }

    }//ServiceSheet

}
