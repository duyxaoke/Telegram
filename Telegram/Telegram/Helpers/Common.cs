using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Telegram.Helpers
{
    public static class Common
    {
        public static List<Symbol> GetSymbols()
        {
            var LstSymbol = new List<Symbol>();
            LstSymbol.Add(new Symbol { Code = "AUD/CAD", Name = "ACAD" });
            LstSymbol.Add(new Symbol { Code = "AUD/JPY", Name = "AJ" });
            LstSymbol.Add(new Symbol { Code = "AUD/USD", Name = "AU" });
            LstSymbol.Add(new Symbol { Code = "AUD/CHF", Name = "ACHF" });
            LstSymbol.Add(new Symbol { Code = "AUD/NZD", Name = "AN" });
            LstSymbol.Add(new Symbol { Code = "EUR/USD", Name = "EU" });
            LstSymbol.Add(new Symbol { Code = "GBP/USD", Name = "GU" });
            LstSymbol.Add(new Symbol { Code = "USD/CHF", Name = "UCHF" });
            LstSymbol.Add(new Symbol { Code = "USD/JPY", Name = "UJ" });
            LstSymbol.Add(new Symbol { Code = "EUR/GBP", Name = "EG" });
            LstSymbol.Add(new Symbol { Code = "EUR/JPY", Name = "EJ" });
            LstSymbol.Add(new Symbol { Code = "GBP/AUD", Name = "GA" });
            LstSymbol.Add(new Symbol { Code = "GPB/JPY", Name = "GJ" });
            LstSymbol.Add(new Symbol { Code = "NZD/USD", Name = "NU" });
            LstSymbol.Add(new Symbol { Code = "USD/CAD", Name = "UCAD" });
            LstSymbol.Add(new Symbol { Code = "EUR/AUD", Name = "EA" });
            LstSymbol.Add(new Symbol { Code = "EUR/CHF", Name = "ECHF" });
            LstSymbol.Add(new Symbol { Code = "EUR/NZD", Name = "EN" });
            LstSymbol.Add(new Symbol { Code = "EUR/CAD", Name = "ECAD" });
            LstSymbol.Add(new Symbol { Code = "GBP/CHF", Name = "GCHF" });
            LstSymbol.Add(new Symbol { Code = "CAD/CHF", Name = "CCHF" });
            LstSymbol.Add(new Symbol { Code = "GPB/CAD", Name = "GCAD" });
            LstSymbol.Add(new Symbol { Code = "GBP/NZD", Name = "GN" });
            LstSymbol.Add(new Symbol { Code = "NZD/CAD", Name = "NCAD" });
            return LstSymbol;
        }
    }

    public class Symbol
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }

}