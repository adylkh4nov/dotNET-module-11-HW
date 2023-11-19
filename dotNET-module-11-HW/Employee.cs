using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_module_11_HW
{
    struct Employee : IEmployee
    {
        public string FullName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Position { get; set; }
        public char Gender { get; set; }
        public decimal Salary { get; set; }


        override public string ToString()
        {
            return $"Full Name: {FullName}\nPosition: {Position}\nEmployment Date: {EmploymentDate}\nGender: {Gender}\nSalary: {Salary}\n\n";
        }

    }
}
