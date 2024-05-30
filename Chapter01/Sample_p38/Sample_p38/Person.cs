using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_p38 {
    public class Person {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int GetAge() {
            DateTime tody = DateTime.Today;
            int age = tody.Year - Birthday.Year;
            if (tody < Birthday.AddYears(age))
                age--;
            return age;
        }
    }
}
