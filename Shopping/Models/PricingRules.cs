using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Models
{
    public class PricingRules 
    {
        readonly IList<PricingRule> _rules = new List<PricingRule>();

        public void AddRule(string sku, Decimal price, string rule, int totalQualify)
        {
            _rules.Add(new PricingRule(sku, price, rule, totalQualify));
        }

        public Decimal GetPriceForSku(string sku)
        {
            return GetRuleBySku(sku).Price;
        }

        public PricingRule GetRuleBySku(string sku)
        {
            return _rules.Single(r => r.Sku == sku);
        }


    }
}
