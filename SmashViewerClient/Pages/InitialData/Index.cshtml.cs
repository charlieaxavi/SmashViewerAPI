using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntitiesLibrary.Entities;
using EntitiesLibrary.ExcelcConverter.ExcelModel;
using EntitiesLibrary.ExcelcConverter.Methods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OfficeOpenXml;
using SmashViewerClient.Models.Configuration;
using SmashViewerClient.Models.InitialData;

namespace SmashViewerClient.Pages.InitialData
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public DataFileInformation dataFile { get; set; }

        ConfigurationAPI configurationAPI = new ConfigurationAPI();

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostFileFirst()
        {
            if (!ModelState.IsValid || dataFile.Files == null || dataFile.Files.Count() == 0)
            {
                return RedirectToPage("Index");
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<ArticuloExcel> FileArticulo = new List<ArticuloExcel>();
            List<ArticuloExcel> FileArtuculoSend = new List<ArticuloExcel>();

            foreach (var a in dataFile.Files)
            {
                if (a.FileName.Contains("Catalogo articulos"))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await a.CopyToAsync(memoryStream).ConfigureAwait(false);

                        using (var package = new ExcelPackage(memoryStream))
                        {
                            var worksheet = package.Workbook.Worksheets[0];
                            FileArticulo = new ArticuloExcelInput().GetArticuloExcelData(package, worksheet, dataFile.DocumentDate);
                            //using (var client = new HttpClient())
                            //{
                            //    client.BaseAddress = new Uri(configurationAPI.apiURL);
                            //    client.Timeout = configurationAPI.waitingAnswers;


                            //    var responseTask = client.GetAsync("InitialData/DeleteAPFeedData?Date=" + worksheet.Cells[2, 66].Value?.ToString() ?? "1989-01-01");
                            //    responseTask.Wait();

                            //    var result = responseTask.Result;
                            //    if (!result.IsSuccessStatusCode)
                            //    {
                            //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                            //    }
                            //    else
                            //    {
                            //        FileArticulo = new ArticuloExcelInput().GetArticuloExcelData(package, worksheet, dataFile.DocumentDate);
                            //    }
                            //}
                        }
                    }

                    foreach (ArticuloExcel itrm in FileArticulo)
                    {
                        FileArtuculoSend.Add(itrm);
                        if (FileArtuculoSend.Count() == 10000)
                        {
                            using (var client = new HttpClient())
                            {
                                client.BaseAddress = new Uri(configurationAPI.apiURL);
                                client.Timeout = configurationAPI.waitingAnswers;

                                var responseTask = client.PostAsync("InitialData/InputFiles", new StringContent(JsonConvert.SerializeObject(FileArtuculoSend),Encoding.UTF8, "application/json"));
                                responseTask.Wait();

                                var result = responseTask.Result;
                                if (!result.IsSuccessStatusCode)
                                {
                                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                                }
                            }
                            FileArtuculoSend = new List<ArticuloExcel>();
                        }
                    }
                    if (FileArtuculoSend.Count() > 0 && FileArtuculoSend.Count() < 10000)
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(configurationAPI.apiURL);
                            client.Timeout = configurationAPI.waitingAnswers;

                            var responseTask = client.PostAsync("InitialData/InputFiles", new StringContent(JsonConvert.SerializeObject(FileArtuculoSend), Encoding.UTF8, "application/json"));
                            responseTask.Wait();

                            var result = responseTask.Result;
                            if (!result.IsSuccessStatusCode)
                            {
                                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                            }
                            else
                            {
                                dataFile.CompletationMessage = "Files(s) has been upload";
                            }
                        }
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostFileSecond()
        {
            if (ModelState.IsValid)
            {
                var datadd = dataFile;
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
