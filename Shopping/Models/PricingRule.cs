using System;
using Shopping.Rules;

namespace Shopping.Models
{
    public class PricingRule 
    {
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public string Rule { get; set; }
        public int QuailfyingQty { get; private set; }
        public Func<decimal, decimal> DiscountRule { get; private set; }

        public PricingRule(string sku, decimal price, string rule, int totalQualify)
        {
            Sku = sku;
            Price = price;
            Rule = rule;
            QuailfyingQty = totalQualify;
            ParseRule();
        }

        public bool HasSpecialRuleForSku()
        {
            return string.IsNullOrEmpty(Rule) == false;
        }

        private void ParseRule()
        {
            if (!HasSpecialRuleForSku())
            {
                return;
            }

            SetDiscountRule();
        }

        private void SetDiscountRule()
        {
            var tokens = Rule.Split(':');

            if (tokens.Length == 1)
            {
                DiscountRule = RuleFactory.CreateRule(Rule);
                return;
            }
            DiscountRule = RuleFactory.CreateRule(tokens[0], Decimal.Parse(tokens[1]));
        }


    }
}