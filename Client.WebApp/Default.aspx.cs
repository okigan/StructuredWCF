using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;

namespace Client.WebApp {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                //ClientProxy.ServiceReference1.Service1Client client =
                //    new ClientProxy.ServiceReference1.Service1Client("restendpointname");
                //GridView1.DataSource = client.GetCollection();

                //var factory = new ChannelFactory<Web.Contract.IService1>("restendpointname");
                //var proxy = factory.CreateChannel();
                //var response = proxy.GetCollection();
                //((IDisposable)proxy).Dispose();
                //GridView1.DataSource = response;

                //GridView1.DataBind();
            }
        }
    }

    public class x {
        Web.Contract.IService1 proxy = null;

        public x() {
            var factory = new ChannelFactory<Web.Contract.IService1>("restendpointname");
            proxy = factory.CreateChannel();
        }

        public IList<Web.Contract.SampleItem> GetCollection() {
            var collection = proxy.GetCollection();
            return collection;
        }

        public Web.Contract.SampleItem Create(Web.Contract.SampleItem instance) {
            return proxy.Create(instance);
        }

        public Web.Contract.SampleItem Get(string id) {
            return proxy.Get(id);
        }

        public void Update(Web.Contract.SampleItem instance) {
            var updatedItem = proxy.Update(instance.Id.ToString(), instance);
        }

        public void Delete(Web.Contract.SampleItem instance) {
            proxy.Delete(instance.Id.ToString());
        }
    }
}
