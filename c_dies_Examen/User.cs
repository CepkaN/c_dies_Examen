using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_dies_Examen
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public User() { }
        public User(int ddd,string us,string em)
        {
            ID = ddd;UserName = us;Email = em;
        }
        public void Mostra()
        {
            Console.WriteLine("\n ID : " + ID + "\n Имя : " + UserName + "\n Email : " + Email);
        }
    }
}
