using System;
using Windows.Devices.Gpio;

namespace sunrise_alarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Sunrise!");

            var gpio = GpioController.GetDefault();

            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                pin = null;
                GpioStatus.Text = "There is no GPIO controller on this device.";
                return;
            }
            var red = 14;
            var blue = 15;
            var green = 18;
            pin = gpio.OpenPin(14);
            pin.SetDriveMode(GpioPinDriveMode.Output);
            pinValue = GpioPinValue.High;
            pin.Write(pinValue);

            Console.ReadLine();
            pinValue = GpioPinValue.Low;
            pin.Write();
        }
    }
}
