using System;
namespace vd.fundamentals.Ratios
{
   /// <summary>
    /// ASSET TURNOVER RATIO
    /// ================================
    /// The Ratio Measures the sales generated for every penny worth of assets. 
    /// It shows a firm's efficency in using its assets to generate revenue.
    /// 
    /// </summary>
    public class ATORatio
    {
        public double CaliculateATORatio(double revenue, double totalAssets)
        {
            if (totalAssets == 0) throw new DivideByZeroException();

            return revenue / totalAssets;
        }
       
    }
}