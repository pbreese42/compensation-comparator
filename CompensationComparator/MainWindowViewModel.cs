using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CompensationComparator
{
    class MainWindowViewModel
    {
        public ICommand TogglePaletteCommand { get; } = new Command(o => TogglePalette((bool)o));

        private static void TogglePalette(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
        }
    }
}
