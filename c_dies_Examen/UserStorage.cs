using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_dies_Examen
{
    public delegate void UserChangedDelegate(User U);
    public class UserStorage:IUserStorage
    {
        public event UserChangedDelegate UserAdded;
        public event UserChangedDelegate UserDeleted;
        public List<User> USER { get; set; }
        public UserStorage() { USER= new List<User>(); }
        public void AddUser()
        {
            Console.WriteLine(" Введите ID : ");
            int a1=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" Введите имя пользователя : ");
            string ?a2=Convert.ToString(Console.ReadLine());
            Console.WriteLine(" Введите email : ");
            string?a3=Convert.ToString(Console.ReadLine());
            User UUU=new User(a1,a2,a3);
            AddUser(UUU);
        }
        public void AddUser(User UZ)
        {
            USER.Add(UZ);
            UserAdded?.Invoke(UZ);
            Console.WriteLine(" Пользователь добавлен.");
        }
        public User Cercare()
        {
            Console.WriteLine(" Введите ID пользователя : ");
            int b=Convert.ToInt32(Console.ReadLine());
            var BB = USER.FirstOrDefault(x => x.ID == b);
            return BB;
        }
        public void GetUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Поиск пользователя ");
            var U = Cercare();
            Console.WriteLine(" Ваш пользователь : ");
            U.Mostra();
            Console.ResetColor();
        }
        public void UpdateUser()
        {
            Console.WriteLine(" Выберите пользователя, которого Вы хотите изменить : ");
            MOO();
            var ZZZ=Cercare();
            Console.WriteLine(" Выберите параметр для изменения : ");
            Console.WriteLine(" 1. ID \n 2. Имя пользователя\n 3. Email\n 4. Выход");
            int H=Convert.ToInt32(Console.ReadLine());
            switch (H)
            {
                case 1:Console.WriteLine(" Введите новый ID : ");int b1 = Convert.ToInt32(Console.ReadLine()); USER.FirstOrDefault(x=>x==ZZZ).ID = b1 ; break;
                case 2:Console.WriteLine(" Введите новое имя пользователя : "); string ?b2 = Convert.ToString(Console.ReadLine()); USER.FirstOrDefault(x => x == ZZZ).UserName = b2; break;
                case 3:Console.WriteLine(" Введите новый email : ");string?b3 = Convert.ToString(Console.ReadLine()); USER.FirstOrDefault(x => x == ZZZ).Email = b3;break;
                case 4:return;
                default:break;
            }
        }
        public void DeleteUser()
        {
            MOO();
            Console.ForegroundColor = ConsoleColor.Red;
            var BB=Cercare();
            DeleteUser(BB);
            Console.ResetColor();
        }
        public void DeleteUser(User U)
        {
            USER.Remove(U);
            UserDeleted?.Invoke(U);
            Console.WriteLine(" Пользователь удалён. ");
        }
        public void MOO()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (var V in USER)
            {
                V.Mostra();
            }
            Console.ResetColor();
        }
    }
}
