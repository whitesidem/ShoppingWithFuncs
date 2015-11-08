using System;

namespace Shopping.Rules
{
    public static class RuleFactory
    {

        public static Func<decimal, decimal> CreateRule(string ruleType, decimal discount = 0)
        {
            Func<decimal, decimal> rule;
            switch (ruleType)
            {
                case "BOGOF":
                {
                    rule = (price) =>
                    {
                        return price;
                    };
                    break;
                }
                case "HALF":
                {
                    rule = (price) =>
                    {
                        return price / 2;
                    };
                    break;
                }
                case "DISCOUNT":
                {
                    rule = (x) =>
                    {
                        return discount;
                    };
                    break;
                }
                default:
                {
                    rule = (price) =>
                    {
                        return 0;
                    };
                    break;
                }
            }    

            return rule;
        }

    }
}
