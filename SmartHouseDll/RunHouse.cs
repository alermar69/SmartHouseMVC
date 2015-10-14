using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHouseDll
{
    public class RunHouse
    {
        public House Home { get; set; }
        public RunHouse(House house, RemoteControl remote)
        {
            Home = house;          
            Home.Remote = remote;
        }        

        private  void RunSensors(object climatControl)
        {
            ClimatControl climat = climatControl as ClimatControl;
            if (climat != null)
            {
                Random random = new Random();
                while (true)
                {                   
                    climat.SensorTemperat.CurrentTemperature =
                        random.Next(climat.Temperature - 3, climat.Temperature + 3);
                    climat.SensorHumid.CurrentHumidity =
                        random.Next(climat.Humidity - 3, climat.Humidity + 3);
                    Thread.Sleep(10000);
                }
            }
        }

        private ClimatControl GetClimatContol(string room)
        {
            var x = from c in Home.Rooms where c.Key == room.ToLower() select c.Value.Devices.Values;

            if (x.Any())
            {
                var climat = from w in x.First() where w is ClimatControl select w;
                if (climat.Any())
                    return climat.First() as ClimatControl;
            }
            return null;       
        }

        public void Run()
        {
            if (Home.Remote != null)
            {
                ClimatControl climat = GetClimatContol("hall");
                if (climat != null)
                {
                    climat.State = StateOnOff.On;
                    Task.Factory.StartNew(RunSensors, climat);
                }
                    
                do
                {
                    Home.Remote.Write();
                    Home.Remote.ReadCommand();
                    Home.Remote.PushButton();
                    Home.Remote.Write();
                    Home.Remote.ClearDataCommand();
                    SerDesHouse.Save(Home);
                } while (true);
            }
        }
    }
}