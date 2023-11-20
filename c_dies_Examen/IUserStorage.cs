using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace c_dies_Examen
{
    [XmlInclude(typeof(UserStorage))]
    public interface IUserStorage
    {
        public void AddUser();
        public void AddUser(User UZ);
        public User Cercare();
        public void GetUser();
        public void UpdateUser();
        public void DeleteUser();
    }
}
