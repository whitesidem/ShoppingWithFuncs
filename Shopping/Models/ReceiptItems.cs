using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Models
{
    public class ReceiptItems
    {
        private readonly List<ReceiptItem> _receiptItems = new List<ReceiptItem>();

        public decimal TotalPrice
        {
            get
            { 
                return _receiptItems.Sum(r => r.Price);
            }
        }

        public IEnumerable<ReceiptItem> ItemEnumerator
        {
            get {
                return _receiptItems.Select(receiptItem => new ReceiptItem(receiptItem.Sku, receiptItem.Price, receiptItem.Desc));
            }
        }

        public void AddReceiptItem(string sku, decimal price)
        {
            _receiptItems.Add(new ReceiptItem(sku, price));
        }

        public void AddReceiptDiscount(string sku, Func<decimal, decimal> discountRule, decimal price, string description)
        {
            var discount = discountRule.Invoke(price) * -1;

            _receiptItems.Add(new ReceiptItem(sku, discount, description));
        }

    }
}
