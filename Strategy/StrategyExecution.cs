using System;
using System.Collections.Generic;
using System.Linq;
using Skender.Stock.Indicators;
using TradingAutomation.Data;

namespace TradingAutomation.Strategy
{
    public class StrategyExecution
    {
        private readonly DataRetrieval dataRetrieval;
        private readonly List<Quote> marketData;

        public StrategyExecution()
        {
            dataRetrieval = new DataRetrieval();
            marketData = dataRetrieval.GetMarketData();
        }

        public bool EvaluateTrade()
        {
            // Calculate Bollinger Bands
            var bollingerBands = Indicators.CalculateBollingerBands(marketData);
            // Calculate ATR
            var atr = Indicators.CalculateATR(marketData);

            // Get the latest results
            var latestBollinger = bollingerBands.LastOrDefault();
            var latestAtr = atr.LastOrDefault();

            if (latestBollinger != null && latestAtr != null)
            {
                // Check for valid Bollinger and ATR values
                if (latestBollinger.LowerBand.HasValue && latestAtr.Atr.HasValue)
                {
                    decimal lowerBand = (decimal)latestBollinger.LowerBand.Value;
                    decimal atrValue = (decimal)latestAtr.Atr.Value;

                    // Comparison with the latest market data close
                    if (marketData[^1].Close < lowerBand && atrValue > 2.0M)
                    {
                        Console.WriteLine("Buy signal based on Bollinger Bands and ATR!");
                        return true; // Buy signal
                    }
                    else if (marketData[^1].Close > (decimal)latestBollinger.UpperBand.Value && atrValue > 2.0M)
                    {
                        Console.WriteLine("Sell signal based on Bollinger Bands and ATR!");
                        return false; // Sell signal
                    }
                }
            }

            Console.WriteLine("No trading signal.");
            return false; // No trade
        }
    }
}
