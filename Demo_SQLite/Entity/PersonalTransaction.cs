using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SQLite.Entity
{
   public class PersonalTransaction
    {
        
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public double Money { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Category  { get; set; }
        

        public override string ToString()
        {
            return String.Format($"{Name} - {Detail} - {Description} - {Money} - {CreatedDate.ToString("yyyy-MM-dd")} - {Category}");
        }
    }
}
