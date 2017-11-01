using System;
using Demo.Common;
using Newtonsoft.Json;

namespace Demo.Model
{
    public class SqliteRecord
    {
        
        public string RecordId { get; set; }

        [JsonIgnore]
        public string CloudData { get; set; }

        [JsonIgnore]
        public RecordType RecordType { get; set; }

        
        public DateTime CreateTime { get; set; }

        public virtual void Hydrate()
        {
            if (!string.IsNullOrEmpty(this.CloudData))
            {
                JsonConvert.PopulateObject(this.CloudData, this);
                this.CloudData = string.Empty;
            }
        }

        /// <summary>
        /// Takes the data from the object and stores it in the CloudData parameter as a string
        /// </summary>
        public virtual void Dehydrate()
        {
            this.CloudData = JsonConvert.SerializeObject(this);
        }
    }
}
