using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using MyEntitiesDLL.Entities;

namespace MyBusinessDLL.Managing
{
    public class ManagingCar
    {
        private readonly InformationAzure azureInfo;

        public ManagingCar(InformationAzure azureInfo)
        {
            this.azureInfo = azureInfo;
        }

        public async Task SendPosition(Vehicule vehicle)
        {

            int i = 0;

            while (true)
            {
                await using (var producerClient = new EventHubProducerClient(azureInfo.connectionString, azureInfo.eventHubName))
                {
                    using (EventDataBatch eventBatch = await producerClient.CreateBatchAsync())
                    {
                        eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Position :" + i + "P" + i)));
                        i++;
                        await producerClient.SendAsync(eventBatch);
                    }
                }

                Console.WriteLine($"Sending position for Vehicle {vehicle.matricule}: Position {i}");
                await Task.Delay(1000);
            }
        }
    }
}