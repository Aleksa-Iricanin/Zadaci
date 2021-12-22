using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessMenu
    {
        private readonly MenuRepository menuRepository;

        public BusinessMenu()
        {
            this.menuRepository = new MenuRepository();
        }

        public List<MenuItem> GetA()
        {
            return this.menuRepository.GetAll();
        }
        public bool Insert(MenuItem mi)
        {
            if (this.menuRepository.InsertOneMenu(mi) > 0)
                return true;
            return false;
        }
        public List<MenuItem> GT(decimal min,decimal max)
        {
            return this.menuRepository.GetAll().FindAll(mi => mi.price < max && mi.price > min);
        }
    }
}
