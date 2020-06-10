using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models {

    // Акт выполненных работ
    public class ActOfExecutedWorks {

        public int Id { get; set; }

        public virtual Car Car { get; set; } // ремонтируемый автомобиль
        public virtual Client Client { get; set; } // клиент, загнавший авто в сервис
        public DateTime RepairAcceptanceDate { get; set; } // дата приема в ремонт
        public DateTime RepairCompletionDate { get; set; } // дата завершения ремонта
        public float RepairCost { get; set; } // стоимость ремонта(сумма оказанных услуг)
        public float CostOfSpareParts { get; set; } // суммарная стоимость запчастей

        // коллекция сервисных листов данного ремонта
        public virtual ICollection<ServiceSheet> ServiceSheets { get; set; }

        public ActOfExecutedWorks() {

            ServiceSheets = new HashSet<ServiceSheet>();

        }

    }//ActOfExecutedWorks
}
