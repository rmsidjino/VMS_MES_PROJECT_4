using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESDTO
{
    public class UserVO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public string Confirmpwd { get; set; }
        public Nullable<bool> Is_Deleted { get; set; }

        public string Gender { get; set; }
        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string SecurityAnwser { get; set; }
        public string IsAdmin { get; set; }


    }
}
