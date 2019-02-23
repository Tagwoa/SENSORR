using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorrService.Model
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Temperature { get; set; }
        public int HighVoltage { get; set; }
        public int BatteryVoltage { get; set; }
    }
}
