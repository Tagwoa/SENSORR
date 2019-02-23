using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorrService.Model
{
    public class Repository
    {
        private List<Device> MyDevice = new List<Device>
        {
            new Device
            {
                Id = 1,
                Name = " Ludlum",
                Date = DateTime.Now,
                Temperature = 10,
                BatteryVoltage = 10,
                HighVoltage = 2
            }
        };
        public List<Device> Get()
        {
            return MyDevice;
        }   
        public void Add(Device newDevice)
        {
            MyDevice.Add(newDevice);
        }
    }
}
