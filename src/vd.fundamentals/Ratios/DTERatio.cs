using System;
namespace vd.fundamentals.Ratios
{
    /// <summary>
    /// DEBT - TO - EQUITY Ratio
    /// ===================================
    /// It measures a comapnay's leverage by comparing its debt with its equity base.
    /// The ratio indicates the proporation of the company's assests that are being financed through debt.
    /// </summary>
    public class DTERatio
    {
        public double CaliculateDTE(double totallongtermdebt, double shareholderequity)
        {
            if (shareholderequity == 0) throw new DivideByZeroException();
            return totallongtermdebt / shareholderequity;
        }
    }
}