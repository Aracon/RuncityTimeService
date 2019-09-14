using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace BGTimeService
{
    [DataContract]
    class TimeServiceState
    {
        [DataMember]
        public string CurrentTimeText { get; set; }
        [DataMember]
        public int? CurrentStartingTeam { get; set; }
        [DataMember]
        public bool IsServiceActive { get; set; }
        [DataMember]
        public bool IsStartingNow { get; set; }
        [DataMember]
        public int SecondsToStart { get; set; }

        public string ToJson()
        {
            var stream = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(TimeServiceState));

            ser.WriteObject(stream, this);

            stream.Position = 0;
            var sr = new StreamReader(stream);
            string result = sr.ReadToEnd();

            return result;
        }
    }
}
