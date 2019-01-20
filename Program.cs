using System;
using System.Device.Gpio;
using System.Threading;

namespace sunrise_alarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Sunrise!");

            var red = 14;
            var blue = 15;
            var green = 18;
            var lightTimeInMilliseconds = 1000;

            using (GpioController controller = new GpioController(PinNumberingScheme.Logical))
            {
                Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs eventArgs) =>
                {
                    controller.Dispose();
                    Console.WriteLine("Pin cleanup complete!");
                };

                controller.OpenPin(red, PinMode.Output);
                controller.OpenPin(green, PinMode.Output);
                controller.OpenPin(blue, PinMode.Output);

                for (int i = 0; i < 5; i++)
                {
                    controller.Write(red, PinValue.High);
                    controller.Write(green, PinValue.High);
                    controller.Write(blue, PinValue.High);
                    Console.WriteLine("High");

                    Thread.Sleep(lightTimeInMilliseconds);

                    controller.Write(red, PinValue.Low);
                    controller.Write(green, PinValue.Low);
                    controller.Write(blue, PinValue.Low);
                    Console.WriteLine("Low");

                    Thread.Sleep(lightTimeInMilliseconds);

                }
            }
            
            Console.WriteLine("Done");
        }
    }
}
