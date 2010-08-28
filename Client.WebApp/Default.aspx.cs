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

                var factory = new ChannelFactory<Contract.Web.IService1>("restendpointname");
                var proxy = factory.CreateChannel();
                var response = proxy.GetCollection();
                ((IDisposable)proxy).Dispose();
                GridView1.DataSource = response;

                GridView1.DataBind();
            }
        }
    }
}
