using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel;

namespace Web.Contract {
    [ServiceContract]
    public interface IService1 {
        // TODO: Implement the collection resource that will contain the SampleItem instances

        [WebGet(UriTemplate = "")]
        IList<SampleItem> GetCollection();

        [WebInvoke(UriTemplate = "", Method = "POST")]
        SampleItem Create(SampleItem instance);

        [WebGet(UriTemplate = "{id}")]
        SampleItem Get(int id);

        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        SampleItem Update(int id, SampleItem instance);

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void Delete(int id);
    }
}
