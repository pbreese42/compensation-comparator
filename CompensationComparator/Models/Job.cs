using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompensationComparator.Models
{
    public class Job
    {
        public string Name { get; set; }
        public ObservableCollection<Compensation> TotalCompensation { get; set; }
    }
}
