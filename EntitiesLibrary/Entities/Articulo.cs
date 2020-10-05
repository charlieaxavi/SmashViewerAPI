using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLibrary.Entities
{
    public class Articulo
    {
        public int ID { get; set; }
        public string ConsumerID { get; set; }
        public string FinancialRptCode { get; set; }
        public string DeptCategoryDescription { get; set; }
        public string AcctDeptNbr { get; set; }
        public string UPC { get; set; }
        public DateTime CreateDate { get; set; }
        public string ItemNbr { get; set; }
        public string SigningDesc { get; set; }
        public string CurrTraitedStoreItemComb { get; set; }
        public string CurrValidStoreItemComb { get; set; }
        public string BrandDesc { get; set; }
        public string StoreNbr { get; set; }
        public string StoreName { get; set; }
        public string VendorStkNbr { get; set; }
        public string ItemStatus { get; set; }
        public string ItemType { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal StoreSpecificCost { get; set; }
        public decimal StoreSpecificCostUSDollars { get; set; }
        public int VNPKQty { get; set; }
        public int WHPKQty { get; set; }
        public decimal StoreSpecificRetail { get; set; }
        public decimal StoreSpecificRetailUSDollars { get; set; }
        public string CountryCode { get; set; }
        public DateTime ObsoleteDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime StatusChgDate { get; set; }
        public string SizeDesc { get; set; }
        public DateTime LastChangeDate { get; set; }
        public DateTime ExchangeRateDate { get; set; }
        public decimal ExchangeRateUsed { get; set; }
    }
}
