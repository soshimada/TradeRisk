using System.Collections.Generic;
using TradeRisk.Domain.Model;

namespace TradeRisk.Service.Interfaces
{
    public interface ITrader 
    {
        List<string> GetRisk(List<Trader> list);


    }
}
