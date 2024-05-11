using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntitiesDLL.Entities
{
    public class InformationAzure
    {
        //public  string connectionString = "Endpoint=sb://trackingevent.servicebus.windows.net/;SharedAccessKeyName=iothubroutes_trackinghub;SharedAccessKey=2yG2/yVlwkZigcfX0Y19m4S+ryYpQP9c3+AEhNJVpAQ=;EntityPath=trackingeventhub";
        //public string eventHubName = "trackingeventhub";
        public  string blobStorageConnection;
        public string blobContainerName;

        public InformationAzure(string connectionString, string eventHubName)
        {
            this.connectionString = connectionString;
            this.eventHubName = eventHubName;
        }
    }
}
