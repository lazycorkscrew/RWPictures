using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.Entities
{
    public class User
    {
        public int Id {get; set;}
        public string Login {get; set;}
        public string Password {get; set;}
        public string Fname {get; set;}
        public string Lname {get; set;}
        public string Patronymic {get; set;}
        public string Description {get; set;}
        public int Rights  {get; set;}
    }
}
