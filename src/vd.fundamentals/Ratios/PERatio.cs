using System;
namespace vd.fundamentals.Ratios
{
    /// <summary>
    /// Price to Earnings Ratio
    /// ==============================
    /// The most commonly used ratio. It compares the proce of a stock to the company's earning per ratio.
    /// The EPS can be either for the past four quarters (historical or trailing PE) or for the comng four quarters (forward PE).
    /// 
    /// PE=StockPrice/EPS
    /// 
    /// </summary>
    public class PERatio
    {

        public double CaliculatePE(double stockPrice, double eps)
        {
            if (eps == 0) throw new DivideByZeroException();
            return stockPrice / eps;
        }
    }
}