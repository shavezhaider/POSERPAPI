using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Entities.Entity
{
    public class ProcessingStatusEntity
    {
        public int StatusCode { get; set; }
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public List<ErrorEntity> Errors { get; set; }
    }
}
