using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Core.Contract {
    public interface ITechnobabble {
        IList<SampleItem> GetCollection();
        SampleItem Create(SampleItem instance);
        SampleItem Get(int id);
        SampleItem Update(int id, SampleItem instance);
        void Delete(int id);
    }
}
