using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeRisk.Service.Interfaces
{
    interface IBase<T> where T : class
    {
        void Add(T Entity);
        void Update(T Entity);
        void Delete(int Id);
        T Get(int Id);
        List<T> List();
    }
}
