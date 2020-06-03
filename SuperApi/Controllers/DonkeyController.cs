using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SuperApi.DbContextx;

namespace SuperApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonkeyController : ControllerBase
    {
        private readonly DbContext2 dbCon;

        public DonkeyController()
        {
            this.dbCon = new DbContext2();
        }
        
        [HttpGet]
        public string Get()
        {
            try
            {
                var queryResult = dbCon.Opisy.ToList();
                var result = "";

                queryResult.ForEach(opis =>
                {
                    result += $"{opis.Name}###{opis.Tresc}";
                });

                return result;
            }
            catch (Exception)
            {
                return "nie dziala";
            }
        }        
    }
}
