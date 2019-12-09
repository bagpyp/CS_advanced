using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class NorthAmericanCurrency
    {
        public NorthAmericanCurrency()
        {
            pesosPerUSD = 19.23f;
            canadianPerUSD = 1.32f;
        }
        public float pesosPerUSD;
        public float canadianPerUSD;

        public float USDtoPeso(float x)
        {
            return x * pesosPerUSD;
        }
        public float USDtoCanadian(float x)
        {
            return x * canadianPerUSD;
        }
        public float CanadianToPeso(float x)
        {
            return x * pesosPerUSD / canadianPerUSD;
        }
        public float CanadianToUSD(float x)
        {
            return x / canadianPerUSD;
        }
        public float PesoToUSD(float x)
        {
            return x / pesosPerUSD;
        }
        public float PesoToCanadian(float x)
        {
            return x / pesosPerUSD * canadianPerUSD;
        }
    }
}
