using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Dustin.GPIO
{
    public class Gpio
    {
        private GpioController gpioController;

        public Gpio()
        {
            if (gpioController == null)
            {
                gpioController = GpioController.GetDefault();
            }            
        }
        
        public async void SetPinValue(int pinNumber, GpioPinValue pinValue)
        {
            if (gpioController == null)
            {
                //TODO: Throw an error
                return;
            }
            
            using (GpioPin pin = gpioController.OpenPin(pinNumber))
            {                
                pin.Write(pinValue);                
                pin.SetDriveMode(GpioPinDriveMode.Output);
                await Task.Delay(20000);
            }                         
        }
    }
}
