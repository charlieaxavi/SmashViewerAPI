using EntitiesLibrary.ExcelcConverter.ExcelModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLibrary.ExcelcConverter.Methods
{
    public class ArticuloExcelInput
    {
        public List<ArticuloExcel>GetArticuloExcelData(ExcelPackage package, ExcelWorksheet excelWorksheet, DateTime batchDate)
        {
            try
            {
                var rowCount = excelWorksheet.Dimension?.Rows;
                var colCount = excelWorksheet.Dimension?.Columns;

                List<ArticuloExcel> modelReturn = new List<ArticuloExcel>();
                ArticuloExcel line = new ArticuloExcel();
                DateTime dateValue;
                if (!rowCount.HasValue || !colCount.HasValue)
                {
                    return null;
                }

                if (colCount >= 5)
                {
                    for (int row = 2; row <= rowCount.Value; row++)
                    {
                        line = new ArticuloExcel();
                        for (int col = 0; col <= 12; col++)
                        {
                            if (row > 1)
                            {
                                var itemfound = excelWorksheet.Cells[row, 2].Value?.ToString() ?? "";
                                if (itemfound.Trim().Length > 0)
                                {
                                    switch (col)
                                    {
                                        case 1:
                                            line.ConsumerID = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 2:
                                            line.FinancialRptCode = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 3:
                                            line.DeptCategoryDescription = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 4:
                                            line.AcctDeptNbr = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 5:
                                            line.UPC = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 6:
                                            if (DateTime.TryParse(excelWorksheet.Cells[row, col].Value.ToString(), out dateValue))
                                                line.CreateDate = DateTime.Parse(excelWorksheet.Cells[row, col].Value.ToString());
                                            else
                                                line.CreateDate = DateTime.FromOADate(Double.Parse(excelWorksheet.Cells[row, col].Value.ToString()));
                                            break;
                                        case 7:
                                            line.ItemNbr = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 8:
                                            line.SigningDesc = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 9:
                                            line.CurrTraitedStoreItemComb = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 10:
                                            line.CurrValidStoreItemComb = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 11:
                                                line.BrandDesc = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 12:
                                                line.StoreNbr = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 13:
                                                line.StoreName = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 14:
                                                line.VendorStkNbr = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 15:
                                                line.ItemStatus = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 16:
                                            line.EffectiveDate = Convert.ToDateTime(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 17:
                                            line.StoreSpecificCost = Convert.ToDecimal(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 18:
                                            line.StoreSpecificCostUSDollars = Convert.ToDecimal(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 19:
                                            line.VNPKQty = Convert.ToInt32(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 20:
                                            line.WHPKQty = Convert.ToInt32(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 21:
                                            line.StoreSpecificRetail = Convert.ToDecimal(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 22:
                                            line.StoreSpecificRetailUSDollars = Convert.ToDecimal(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 23:
                                            line.CountryCode = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 24:
                                            line.ObsoleteDate = Convert.ToDateTime(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 25:
                                            line.ExpirationDate = Convert.ToDateTime(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 26:
                                            line.StatusChgDate = Convert.ToDateTime(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 27:
                                            line.SizeDesc = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 28:
                                            line.LastChangeDate = Convert.ToDateTime(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 29:
                                            line.ExchangeRateDate = Convert.ToDateTime(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 30:
                                            line.ExchangeRateUsed = Convert.ToDecimal(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                    }
                                }
                            }
                        }
                        if (line != null)
                        {
                            line.DateInserted = batchDate;
                            modelReturn.Add(line);
                        }
                    }

                }

                return modelReturn;

            }
            catch (Exception ex)
            {
                string xs = ex.ToString();
                return null;
            }
        }
    }
}
