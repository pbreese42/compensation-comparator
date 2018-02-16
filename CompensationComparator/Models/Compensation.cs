using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompensationComparator.Models
{
    public class Compensation
    {
        public virtual string Name { get; }
        public virtual Dictionary<string, double> Pieces { get; set; }

        public Compensation()
        { }

        public override string ToString()
        {
            return Name;
        }

    }

    public class Salary : Compensation
    {
        public double BaseSalary { get; set; }
        public double Bonus { get; set; }

        public override string Name => "Salary";

        public Salary()
        {
            Pieces = new Dictionary<string, double>()
            {
                { "Base Salary", BaseSalary },
                { "Bonus", Bonus }
            };
        }
    }

    public class Expenses : Compensation
    {
        public double Parking { get; set; }
        public double Gas { get; set; }
        public override string Name => "Expenses";
    }

    public class Benefits : Compensation
    {
        public double HealthInsurance { get; set; }
        public double DentalInsurance { get; set; }
        public override string Name => "Benefits";
    }
}
