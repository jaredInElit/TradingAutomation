using System;
using System.Collections.Generic;
using Skender.Stock.Indicators;

namespace TradingAutomation.Strategy
{
    public class Indicators
    {
        // Method to calculate Bollinger Bands
        public static IEnumerable<BollingerBandsResult> CalculateBollingerBands(List<Quote> quotes, int period = 20, double multiplier = 2.0)
        {
            return quotes.GetBollingerBands(period, multiplier);
        }

        // Method to calculate Average True Range (ATR)
        public static IEnumerable<AtrResult> CalculateATR(List<Quote> quotes, int period = 14)
        {
            return quotes.GetAtr(period);
        }
    }
}