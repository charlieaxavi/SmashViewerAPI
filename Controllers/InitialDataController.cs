using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary;
using DocumentFormat.OpenXml.Wordprocessing;
using EntitiesLibrary.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmashViewerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        private readonly DBContextSV _context;
        public InitialDataController(DBContextSV context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public ActionResult InputFiles(List<Articulo> articulos)
        {
            try
            {
                _context.Articulos.AddRange(articulos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            return Ok();
        }
    }
}
