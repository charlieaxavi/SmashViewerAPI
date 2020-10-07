using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmashViewerClient.Models.InitialData
{
    public class DataFileInformation
    {
        [Required]
        public DateTime DocumentDate { get; set; }
        public string CompletationMessage { get; set; }
        [Required]
        public List<IFormFile> Files { get; set; }
    }
}
