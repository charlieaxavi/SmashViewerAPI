using EntitiesLibrary.ExcelcConverter.ExcelModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

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

                if (colCount >= 30)
                {
                    for (int row = 7; row <= rowCount.Value; row++)
                    {
                        line = new ArticuloExcel();
                        string[] dateSplit = null;
                        for (int col = 0; col <= 31; col++)
                        {
                            if (row > 6)
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
                                            dateSplit = excelWorksheet.Cells[row, col].Value.ToString().Split("/");
                                            line.CreateDate = Convert.ToDateTime(string.Concat(dateSplit[2], "-", dateSplit[0], "-", dateSplit[1]));
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
                                            line.ItemType = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 17:
                                            dateSplit = excelWorksheet.Cells[row, col].Value.ToString().Split("/");
                                            line.EffectiveDate = Convert.ToDateTime(string.Concat(dateSplit[2], "-", dateSplit[0], "-", dateSplit[1]));
                                            break;
                                        case 18:
                                            line.StoreSpecificCost = Convert.ToDecimal(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 19:
                                            line.StoreSpecificCostUSDollars = Convert.ToDecimal(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 20:
                                            line.VNPKQty = Convert.ToInt32(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 21:
                                            line.WHPKQty = Convert.ToInt32(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 22:
                                            line.StoreSpecificRetail = Convert.ToDecimal(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 23:
                                            line.StoreSpecificRetailUSDollars = Convert.ToDecimal(excelWorksheet.Cells[row, col].Value?.ToString());
                                            break;
                                        case 24:
                                            line.CountryCode = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 25:
                                            dateSplit = excelWorksheet.Cells[row, col].Value.ToString().Split("/");
                                            line.ObsoleteDate = Convert.ToDateTime(string.Concat(dateSplit[2], "-", dateSplit[0], "-", dateSplit[1]));
                                            break;
                                        case 26:
                                            dateSplit = excelWorksheet.Cells[row, col].Value.ToString().Split("/");
                                            line.ExpirationDate = Convert.ToDateTime(string.Concat(dateSplit[2], "-", dateSplit[0], "-", dateSplit[1]));
                                            break;
                                        case 27:
                                            dateSplit = excelWorksheet.Cells[row, col].Value.ToString().Split("/");
                                            line.StatusChgDate = Convert.ToDateTime(string.Concat(dateSplit[2], "-", dateSplit[0], "-", dateSplit[1]));
                                            break;
                                        case 28:
                                            line.SizeDesc = excelWorksheet.Cells[row, col].Value?.ToString() ?? "";
                                            break;
                                        case 29:
                                            dateSplit = excelWorksheet.Cells[row, col].Value.ToString().Split("/");
                                            line.LastChangeDate = Convert.ToDateTime(string.Concat(dateSplit[2], "-", dateSplit[0], "-", dateSplit[1]));
                                            break;
                                        case 30:
                                            dateSplit = excelWorksheet.Cells[row, col].Value.ToString().Split("/");
                                            line.ExchangeRateDate = Convert.ToDateTime(string.Concat(dateSplit[2], "-", dateSplit[0], "-", dateSplit[1]));
                                            break;
                                        case 31:
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
