using System;
namespace vd.fundamentals.Ratios
{
    /// <summary>
    /// Price to Book Value Ratio
    /// ====================================
    /// 
    /// This ratio compares the price of a stock with its book value. 
    /// The book values is the net value of the company's total assets minus its liabilities. 
    /// In other words, it is what shareholders will be left with if the company goes bankrupt.
    /// </summary>
    public class PBVRatio
    {
        public double CaliculatePBV(double stockprice, double bookvaluepershare)
        {
            if (bookvaluepershare == 0) throw new DivideByZeroException();
            return stockprice / bookvaluepershare;
        }
    }
}