using CompensationComparator.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Job> Jobs { get; set; }

        public MainWindowViewModel()
        {
            Jobs = new ObservableCollection<Job>()
            {
                new Job()
                {
                    Name = "Job1",
                    TotalCompensation = new ObservableCollection<Compensation>() {
                        new Salary() { BaseSalary = 10000, Bonus = 10000 },
                        new Expenses(),
                        new Benefits()
                    }
                }
            };
        }
    }

    public class DataType
    {
        public object Data { get; set; }
        public string Name { get; set; }

    }

}
