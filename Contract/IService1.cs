using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;

namespace Contract {
    interface IService1 {
        // TODO: Implement the collection resource that will contain the SampleItem instances

        [WebGet(UriTemplate = "")]
        List<SampleItem> GetCollection();

        [WebInvoke(UriTemplate = "", Method = "POST")]
        SampleItem Create(SampleItem instance);

        [WebGet(UriTemplate = "{id}")]
        SampleItem Get(string id);

        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        SampleItem Update(string id, SampleItem instance);

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void Delete(string id);
    }
}
