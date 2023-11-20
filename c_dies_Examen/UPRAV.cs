using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_dies_Examen
{
    public class UPRAV
    {
        public UserStorage USERstor { get; set; }
        public FileManager FM { get; set; }
        static public string str1 = "C:\\Users\\Ж - 6\\Documents\\Чеп\\c_dies_Examen\\c_dies_Examen\\txtrrr.txt";
        static public string str2 = "C:\\Users\\Ж - 6\\Documents\\Чеп\\c_dies_Examen\\c_dies_Examen\\jsonrrr.json";
        static public string str3 = "C:\\Users\\Ж - 6\\Documents\\Чеп\\c_dies_Examen\\c_dies_Examen\\xmlrrr.xml";

        public UPRAV()
        {
            USERstor= new UserStorage();FM=new FileManager();
        }
        public void AAAD(User UUU)
        {
            USERstor.AddUser(UUU);
        }
        public void MENU2()
        {
            FM.LoadFromFile(str1, "txt", USERstor.USER);
            FM.LoadFromFile(str2, "json", USERstor.USER);
            FM.LoadFromFile(str3, "xml", USERstor.USER);

            MENU();
            FM.SaveToFile(str1, "txt", USERstor.USER);
            FM.SaveToFile(str2, "json", USERstor.USER);
            FM.SaveToFile(str3, "xml", USERstor.USER);

        }
        public void MENU()
        {
            Console.WriteLine("\t Меню : " +
                "\n 1. Просмотр пользователей " +
                "\n 2. Добавление пользователя " +
                "\n 3. Удаление пользователя " +
                "\n 4. Изменение пользователя " +
                "\n 5. Поиск пользователя " +
                "\n 6. Выход.");
            int D=Convert.ToInt32(Console.ReadLine());
            switch (D)
            {
                case 1:USERstor.MOO();MENU() ;break;
                case 2:USERstor.AddUser();MENU() ;break;
                case 3:USERstor.DeleteUser();MENU() ;break;
                case 4:USERstor.UpdateUser();MENU() ;break;
                case 5:USERstor.GetUser();MENU();break;
                case 6:return;
                default:MENU();break;
            }
        }
    }
}
