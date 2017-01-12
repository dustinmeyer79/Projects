using AdafruitClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace Dustin.GPIO
{
    public class Stepper
    {        
        static MotorHat _motorHat;
        static MotorHat.Stepper _stepper;        

        private Stepper()
        {
                        
        }

        public static async Task<Stepper> Create()
        {
            if (_motorHat == null)
            {
                _motorHat = new MotorHat();
                await _motorHat.InitAsync(1600).ConfigureAwait(false);
            }
                      
            return new Stepper();
        }

        public void RotateOneStep(int index)
        {
            try
            {
                _stepper = _motorHat.GetStepper(200, index);
                _stepper.step(33, MotorHat.Stepper.Command.FORWARD, MotorHat.Stepper.Style.DOUBLE);
                _stepper.Release();
            }
            catch (Exception ex)
            {
                throw;
            }            
        }       
    }
}
