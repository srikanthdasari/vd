using System;
namespace vd.fundamentals.Ratios
{
    /// <summary>
    /// Price to Sales Ratio
    /// ===========================
    /// 
    /// This ratio compares the price of a stock to the revenue earned per share.
    /// The revenue for the past four quarters is used this caliculation
    /// </summary>
    public class PSRatio
    {
        public double CaliculatePS(double stockprice, double revenuepershare)
        {
            if (revenuepershare == 0) throw new DivideByZeroException();
            return stockprice / revenuepershare;
        }

    }
}