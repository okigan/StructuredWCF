using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Contract;

namespace Core.Service {
    public class Service1 : IService1 {
        static string[] babble = new string[] {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            ,"Integer at ligula sed sapien gravida vehicula."
            ,"Sed at nulla et risus viverra mattis."
            ,"Nam pulvinar tincidunt metus, et ullamcorper arcu tincidunt sed."
            ,"Vestibulum eget mi massa, sed feugiat mauris."
            ,"Nulla vel metus massa, vitae pharetra ante."
            ,"Praesent accumsan pellentesque elit, sit amet iaculis lacus placerat at."
            ,"Donec sed purus accumsan nulla molestie commodo in non eros."
            ,"Nunc tincidunt condimentum sapien, vel vestibulum purus fermentum ac."
            ,"Nam in metus et mi convallis convallis consequat sed mauris."
            ,"Fusce et nisl sit amet risus rutrum egestas in ornare nibh."
            ,"Nulla sollicitudin velit non nisi sodales at dictum tellus faucibus."
            ,"Quisque malesuada tempor mi, et iaculis odio molestie eu."
            ,"Morbi in velit vitae risus malesuada euismod consequat vel risus."
            ,"Phasellus consequat sagittis elit, id porttitor sapien ultricies eu."
            ,"Aliquam quis augue eget diam tempus dignissim."
            ,"Sed vel odio vel mi condimentum pulvinar nec sed erat."
            ,"Nullam ac neque lorem, in placerat turpis."
            ,"Morbi sit amet erat sed neque feugiat accumsan sit amet sit amet purus."
            ,"Phasellus sodales egestas arcu, vitae consectetur metus elementum at."
            ,"Sed suscipit pellentesque mi, vitae lacinia tortor iaculis quis."
            ,"Maecenas quis massa non lectus aliquam elementum."
            ,"Phasellus aliquam elit eget dui pretium fermentum."
            ,"Nullam ut diam non magna egestas molestie."
            ,"Proin molestie augue eu felis mattis volutpat."
            ,"In blandit cursus orci, ac ultrices nunc aliquam sit amet."
            ,"Fusce semper ligula id purus pharetra a blandit justo hendrerit."
            ,"Etiam sed sem et mauris dictum mollis."
            ,"Proin tincidunt est id leo venenatis adipiscing."
            ,"In malesuada mi sit amet arcu lobortis ornare."
            ,"Vestibulum mollis ante leo, in gravida arcu."
            ,"Integer in urna diam, vestibulum ornare justo."
            ,"Mauris tincidunt eros quis purus sagittis interdum."
            ,"Curabitur non velit at ligula varius aliquam."
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
