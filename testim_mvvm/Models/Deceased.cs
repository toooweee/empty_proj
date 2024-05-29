using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testim_mvvm.Models
{
    public class Deceased
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string CauseOfDeath { get; set; }
    }
}
