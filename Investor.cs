using System;
using System.Collections.Generic;

namespace tpmodul13_103022300082
{
    public interface IInvestor
    {
        // Metode untuk memperbarui pengamat
        void Update(IStock stock);
    }

    public class InvestorA : IInvestor
    {
        private readonly string _name;

        public InvestorA(string name)
        {
            _name = name;
        }

        public void Update(IStock stock)
        {
            /* 
             * Menggunakan 'as' untuk melakukan casting,
             * Berasal dari 'Stock tipeStock = stock as Stock;'
             * dan memeriksa null, 
             * yang berasal dari 'íf(tipeStock != null)' 
             */
            if (stock is not Stock tipeStock)
            {
                Console.WriteLine($"{_name} error: Invalid stock type received.");
                return;
            }

            // Menggunakan 'is not' untuk memeriksa tipe dan nilai
            if (tipeStock.Price >= 105.50m) // Setara dengan 'if (stock.State >= 105.50m)'
            {
                Console.WriteLine($"{_name} received update: {tipeStock.Symbol} price is now {tipeStock.Price:C}");
            }
            else
            {
                Console.WriteLine($"{_name} ignored update!");
            }
        }
    }

    public class InvestorB : IInvestor
    {
        private readonly string _name;

        public InvestorB(string name)
        {
            _name = name;
        }
        public void Update(IStock stock)
        {
            /* 
             * Menggunakan 'as' untuk melakukan casting,
             * Berasal dari 'Stock tipeStock = stock as Stock;'
             * dan memeriksa null, 
             * yang berasal dari 'íf(tipeStock != null)' 
             */
            if (stock is not Stock tipeStock)
            {
                Console.WriteLine($"{_name} error: Invalid stock type received.");
                return;
            }

            // Menggunakan 'is not' dan 'or' untuk memeriksa tipe dan nilai
            if (tipeStock.Price is not 0 or >= 10000) // Setara dengan 'if (stock.State != 0 || stock.State >= 10000)'
            {
                Console.WriteLine($"{_name} received update: {tipeStock.Symbol} price is now {tipeStock.Price:C}");
            }
            else
            {
                Console.WriteLine($"{_name} ignored update!");
            }
        }
    }
}