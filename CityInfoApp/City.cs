using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityInfoApp
{
  public  class City
    {
        private string name;
        private string about;
        private string country;


        public string Name
        {
            get { return name; }
            set{ name = value; }
        }

        public string About
        {
            get { return about; }
            set { about = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
    }
}
