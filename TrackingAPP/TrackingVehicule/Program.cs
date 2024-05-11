using System;
using System.Threading.Tasks;
using MyBusinessDLL.Metier;
using MyEntitiesDLL.Entities;

namespace TrackingVehicule
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Endpoint=sb://trackingevent.servicebus.windows.net/;SharedAccessKeyName=iothubroutes_trackinghub;SharedAccessKey=2yG2/yVlwkZigcfX0Y19m4S+ryYpQP9c3+AEhNJVpAQ=;EntityPath=trackingeventhub";
            string eventHubName = "trackingeventhub";

            var azureInfo = new InformationAzure(connectionString, eventHubName);

            var gererVehicule = new GererVehicule(azureInfo);

            bool continueTracking = true;

            while (continueTracking)
            {
                Console.WriteLine("Enter the matricule of the car to track:");
                string matricule = Console.ReadLine();

                var vehicle = new Vehicule(matricule);

                gererVehicule.DemarrerVehicule(vehicle);

                Console.WriteLine($"Tracking started for Vehicle {matricule}. Press 'N' to stop or V to add another vehicle...");

                var userInputTask = Task.Run(() =>
                {
                    var key = Console.ReadKey(intercept: true);
                    return key.Key == ConsoleKey.V ? key.KeyChar : default(char?);
                });

                var delayTask = Task.Delay(5000);

                var completedTask = await Task.WhenAny(userInputTask, delayTask);

                if (completedTask == userInputTask && userInputTask.Result == 'N')
                {
                    continueTracking = false;
                }
                else
                {
                    Console.Clear(); 
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
