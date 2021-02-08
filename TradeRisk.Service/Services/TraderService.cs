using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeRisk.Domain.Model;
using TradeRisk.Infra.Repository;
using TradeRisk.Service.Interfaces;

namespace TradeRisk.Service.Services
{
    public class TraderService : ITrader
    {
        CategoryRepository rep = new CategoryRepository();
        public List<string> GetRisk(List<Trader> list)
        {
            //List<Trader> lista = new List<Trader>();
            //lista.Add(new Trader { Sector = "Private", Value = 2000000 });
            //lista.Add(new Trader { Sector = "Public", Value = 400000 });
            //lista.Add(new Trader { Sector = "Public", Value = 500000 });
            //lista.Add(new Trader { Sector = "Public", Value = 3000000 });
    
            List<string> tradeCategories = new List<string>();

            foreach (var item in list)
            {
                tradeCategories.Add(VerifyRisk(item));
            }
            return tradeCategories;
        }

        private string VerifyRisk(Trader trader)
        {
            //List<Category> cat = rep.GetAll();

            List<Category> cat = new List<Category>();
            cat.Add(new Category { Operator = ">", Sector = "Public", Risk = "Medium", Value = 1000000 });
            cat.Add(new Category { Operator = "<", Sector = "Public", Risk = "Lower", Value = 1000000 });
            cat.Add(new Category { Operator = ">", Sector = "Private", Risk = "Higher", Value = 1000000 });
            var risk = "NoRules";

            foreach (var item in cat)
            {
                if ("<".Equals(item.Operator) && item.Sector == trader.Sector)
                {
                     risk = Convert.ToDouble(trader.Value) < item.Value ? item.Risk : risk;
                }
                else if (">".Equals(item.Operator) && item.Sector == trader.Sector)
                {
                     risk = Convert.ToDouble(trader.Value) > item.Value ? item.Risk : risk;
                }
            }
            return risk;
        }


    }
}
