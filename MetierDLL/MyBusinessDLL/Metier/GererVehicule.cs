using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEntitiesDLL.Entities;
using System.Threading.Tasks;
using MyBusinessDLL.Managing;
using Newtonsoft.Json;


namespace MyBusinessDLL.Metier
{
    public class GererVehicule
    {
        private Dictionary<string, Thread> vehicleThreads;
        private readonly InformationAzure azureInfo;

        public GererVehicule(InformationAzure info)
        {
            azureInfo = info ?? throw new ArgumentNullException(nameof(info));
            vehicleThreads = new Dictionary<string, Thread>(); // Ensure vehicleThreads is initialized
        }


        public void DemarrerVehicule(Vehicule vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            var managingCar = new ManagingCar(azureInfo);
            Thread thread = new Thread(() => managingCar.SendPosition(vehicle));

            vehicleThreads[vehicle.matricule] = thread;
            thread.Start();
        }

        public void SuivreVehicule()
        {

        }
        public void SeConnecterIOTHub(InformationAzure info)
        {

        }



    }
}