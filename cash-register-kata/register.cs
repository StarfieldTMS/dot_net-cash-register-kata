using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cash_register_kata
{
    class register
    {
        Dictionary<String, double> items = new Dictionary<String, double>();
        public Dictionary<String, double> cart = new Dictionary<String, double>();
        public DateTime date = new DateTime();

        void Main()
        {

        }

        public void addItems()
        {
            items.Add("Frozen Pizza", 5);
            items.Add("Corn", 0.5);
            items.Add("Ground Beef", 4.99);
            items.Add("Vanilla Mayfield Ice Cream", 5.99);
            items.Add("Chocolate Mayfield Ice Cream", 5.99);
            items.Add("Mango", 1);
        }

        public double checkOut()
        {
            double total = 0;

            foreach(KeyValuePair<String, double> Item in cart)
            {
                var item = Item.Key;
                var quantity = Item.Value;
                switch(item)
                {
                    case "Frozen Pizza":
                        {
                            total += items[item] * quantity;
                            break;
                        }
                    case "Corn":
                        {
                            if(quantity < 5)
                            {
                                total += quantity * items[item];
                            }
                            else
                            {
                                var bundles = Math.Floor(quantity / 5);
                                var singles = quantity % 5;
                                total += (bundles * 2) + (singles * items[item]);
                            }
                            break;
                        }
                    case "Ground Beef":
                        {
                            total += Math.Round((quantity * items[item]), 2);
                            break;
                        }
                    case "Vanilla Mayfield Ice Cream":
                        {
                            total += Math.Round((quantity * items[item]), 2);
                            break;
                        }
                    case "Chocolate Mayfield Ice Cream":
                        {
                            if(date.DayOfWeek == DayOfWeek.Wednesday)
                            {
                                total += Math.Round(Math.Ceiling(quantity / 2) * items[item], 2);
                            }
                            else
                            {
                                total += Math.Round((quantity * items[item]), 2);
                            }
                            break;
                        }
                    case "Mango":
                        {
                            if (date.DayOfWeek == DayOfWeek.Monday)
                            {
                                total += quantity * (items[item] / 2);
                            }
                            else
                            {
                                total += quantity * items[item];
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            return total;
        }

    }
}
