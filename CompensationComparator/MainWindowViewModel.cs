using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CompensationComparator
{
    public class MainWindowViewModel
    {
        public ICommand TogglePaletteCommand { get; } = new Command(o => TogglePalette((bool)o));

        private static void TogglePalette(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
        }

        public IEnumerable<CompensationPiece> TotalCompensation { get; set; }

        public MainWindowViewModel()
        {
            TotalCompensation = new List<CompensationPiece>
            {
                new Salary() { BaseSalary = 100000, Bonus=10000 },
                new Benefits(),
                new Expenses()
            };
        }
    }

    public class DataType
    {
        public object Data { get; set; }
        public string Name { get; set; }

    }

    public class CompensationPiece
    {
        public virtual string Name { get; }
        public virtual Dictionary<string, double> Pieces { get; set; }

        public CompensationPiece()
        { }

        public override string ToString()
        {
            return Name;
        }

    }

    class Salary : CompensationPiece
    {
        [DisplayName("Base Salary")]
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

    class Expenses : CompensationPiece
    {
        public double Parking { get; set; }
        public double Gas { get; set; }
        public override string Name => "Expenses";
    }

    class Benefits : CompensationPiece
    {
        public double HealthInsurance { get; set; }
        public double DentalInsurance { get; set; }
        public override string Name => "Benefits";
    }
}
