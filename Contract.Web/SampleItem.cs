using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Contract.Web {
    [DataContract]
    public class SampleItem {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string StringValue { get; set; }
    }
}
