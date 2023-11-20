namespace c_dies_Examen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UPRAV upppp = new UPRAV();
            upppp.AAAD(new User(111, "Boris", "bbb@upravdom.ru"));
            upppp.AAAD(new User(222, "Maya", "mmm@upravdom.ru"));
            upppp.AAAD(new User(333, "Kseniya", "kkk@upravdom.ru"));
            upppp.AAAD(new User(444, "Evgeniy", "eee@upravdom.ru"));
            upppp.MENU2();
        }
    }
}