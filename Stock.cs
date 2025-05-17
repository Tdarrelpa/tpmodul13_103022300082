using System;
using System.Collections.Generic;

namespace tpmodul13_103022300082
{
    public interface IStock
    {
        // Hubungkan pengamat dengan subjek
        void AttachInvestor(IInvestor observer);
        
        // Lepaskan pengamat dari subjek
        void DetachInvestor(IInvestor observer);
        
        // Pemberitahuan kepada pengamat
        void NotifyInvestor();
    }

    public class Stock : IStock
    {
        public string Symbol { get; }
        public decimal Price { get; set; }

        private readonly List<IInvestor> _investor = []; // Setara dengan 'new List<IInvestor>();'

        public Stock(string symbol, decimal initialPrice)
        {
            Symbol = symbol;
            Price = initialPrice;
        }

        /*
         * public string Symbol
         * {
         *    get { return _symbol; }
         * }
         */

        /*
         * public decimal Price
         * {
         *    get { return _price; }
         *    set
         *    {
         *      if (_price != value)
         *      {
         *          _price = value;
         *          NotifyInvestor();
         *      }
         *    }
         * }
         */

        // Metode manajemen pengamat
        public void AttachInvestor(IInvestor observer)
        {
            Console.WriteLine("Stock: Attached an investor.");
            _investor.Add(observer);
        }

        public void DetachInvestor(IInvestor observer)
        {
            _investor.Remove(observer);
            Console.WriteLine("Stock: Detached an investor.");
        }

        // Jalankan pembaharuan pada semua pengamat
        public void NotifyInvestor()
        {
            Console.WriteLine("Stock: Notifying investor of the new change...");

            foreach (var investor in _investor)
            {
                investor.Update(this);
            }
        }

        // Biasanya berisi logika bisnis yang memicu pembaharuan
        public void ChangePrice(decimal newPrice)
        {
            Price = newPrice;
            NotifyInvestor();
        }
    }
}