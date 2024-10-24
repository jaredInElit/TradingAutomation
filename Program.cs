using System;
using TradingAutomation.OrderManagement;
using TradingAutomation.Strategy;
using TradingAutomation.Reports;
using TradingAutomation.Logs;

namespace TradingAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Trading Automation System...");

            Logger.Initialize();

            var strategy = new StrategyExecution();
            bool tradeSignal = strategy.EvaluateTrade();

            if (tradeSignal)
            {
                Console.WriteLine("Executing trade based on strategy.");
                Logger.Log("Trade executed based on strategy signal.");
            }
            else
            {
                Console.WriteLine("No trade executed");
            }

            var emailReport = new EmailReports();
            emailReport.SendDailyReport("Performance: Win Rate - X%, Profit Factor - Y");

            Console.WriteLine("System Run Completed.");
        }
    }
}