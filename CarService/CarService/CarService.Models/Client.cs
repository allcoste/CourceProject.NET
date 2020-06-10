using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models {

    // Клиент
    public class Client {

        public int Id { get; set; }

        public virtual Person Person { get; set; } // паспортные данные
        public string PhoneNumber { get; set; } // номер телефона

        // акты обращений клиента на станцию
        public virtual ICollection<ActOfExecutedWorks> Acts { get; set; }

        public Client() {

            Acts = new HashSet<ActOfExecutedWorks>();

        }

    }//Client

}
