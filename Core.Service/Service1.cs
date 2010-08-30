using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Contract;

namespace Core.Service {
    public class Service1 : IService1 {
        static string[] babble = new string[] {
            "REST ipsum dolor sit amet, consectetur adipiscing elit."
            ,"Integer at ligula sed sapien gravida REST."
            ,"Sed at nulla et risus REST mattis."
            ,"Nam pulvinar tincidunt REST, et ullamcorper arcu tincidunt sed."
            ,"Vestibulum eget mi massa, sed REST mauris."
            ,"Nulla vel metus massa, REST pharetra ante."
            ,"Praesent REST pellentesque elit, sit amet iaculis lacus placerat at."
            ,"Donec sed purus accumsan REST molestie commodo in non eros."
            ,"Nunc tincidunt condimentum REST, vel vestibulum purus fermentum ac."
            ,"Nam in metus et mi REST convallis consequat sed mauris."
            ,"Fusce et nisl sit amet REST rutrum egestas in ornare nibh."
            ,"Nulla sollicitudin velit non nisi REST at dictum tellus faucibus."
            ,"Quisque malesuada tempor mi, et REST odio molestie eu."
            ,"Morbi in velit vitae risus REST euismod consequat vel risus."
            ,"Phasellus consequat REST  elit, id porttitor sapien ultricies eu."
            ,"Aliquam quis REST  eget diam tempus dignissim."
            ,"Sed vel odio vel mi condimentum REST nec sed erat."
            ,"Nullam ac neque lorem, in placerat REST."
            ,"Morbi sit amet erat sed neque feugiat REST sit amet sit amet purus."
            ,"Phasellus sodales egestas arcu, vitae REST metus elementum at."
            ,"Sed suscipit pellentesque mi, vitae REST tortor iaculis quis."
            ,"Maecenas quis massa non lectus REST elementum."
            ,"Phasellus aliquam elit eget dui pretium REST."
            ,"Nullam ut diam non magna REST molestie."
            ,"Proin molestie augue eu felis REST volutpat."
            ,"In blandit cursus orci, ac ultrices nunc REST sit amet."
            ,"Fusce semper ligula id purus REST a blandit justo hendrerit."
            ,"Etiam sed sem et mauris dictum REST."
            ,"Proin tincidunt est id leo REST adipiscing."
            ,"In malesuada mi sit amet arcu REST ornare."
            ,"Vestibulum REST ante leo, in gravida arcu."
            ,"Integer in urna diam, REST ornare justo."
            ,"Mauris REST eros quis purus sagittis interdum."
            ,"Curabitur non velit at REST varius aliquam."
        };

        Dictionary<int, string> data = new Dictionary<int,string>();

        public Service1() {
            for(int id = 0; id < babble.Length; id++) {
                data.Add(id, babble[id]);
            }
        }

        #region IService1 methods
        IList<SampleItem> IService1.GetCollection() {
            IList<SampleItem> list = new List<SampleItem>();
            foreach(var b in data){
                list.Add(new SampleItem() { Id = b.Key, StringValue = b.Value });
            }
            return list;
        }

        SampleItem IService1.Create(SampleItem instance) {
            data.Add(instance.Id, instance.StringValue);

            return instance;
        }

        SampleItem IService1.Get(int id) {
            SampleItem item = new SampleItem() { Id = id, StringValue = data[id] };
            return item;
        }

        SampleItem IService1.Update(int id, SampleItem instance) {
            if(!data.ContainsKey(id)){
                throw new KeyNotFoundException();
            }
            
            data[id] = instance.StringValue;
            instance.Id = id;

            return instance;
        }

        void IService1.Delete(int id) {
            if(!data.ContainsKey(id)) {
                throw new KeyNotFoundException();
            }

            data.Remove(id);
        }
        #endregion
    }
}
