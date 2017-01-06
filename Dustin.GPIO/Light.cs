using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Dustin.GPIO
{
    public class Light
    {
        private const int lightPinNumber = 5;

        public void TurnOn()
        {
            var Gpio = new Gpio();
            Gpio.SetPinValue(lightPinNumber, GpioPinValue.Low);
        }

        public void TurnOff()
        {
            var Gpio = new Gpio();
            Gpio.SetPinValue(lightPinNumber, GpioPinValue.High);
        }
    }
}
