using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperApi.DbContextx;
using SuperApi.Models;

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
        
        [HttpPost]
        public async Task<Opis> Post(Opis opis)
        {
            if (opis != null && !string.IsNullOrWhiteSpace(opis.Name))
            {
                await dbCon.Opisy.AddAsync(opis);
                await dbCon.SaveChangesAsync();
                return opis;
            }

            throw new Exception("NIE DA SIEE E E E E E");
        }

        [HttpDelete]
        public async Task<bool> Delete(Opis opis)
        {
            if (opis != null && !string.IsNullOrWhiteSpace(opis.Name))
            {
                dbCon.Opisy.Remove(opis);
                await dbCon.SaveChangesAsync();
                return true;
            }

            return false;
        }

        [HttpPut]
        public async Task<Opis> UpdateSuperOpis(Opis opis)
        {
            if (opis != null && !string.IsNullOrWhiteSpace(opis.Name))
            {
                dbCon.Opisy.Update(opis);
                await dbCon.SaveChangesAsync();
                return opis;
            }

            throw new Exception("NIE DA SIEE E E E E E");
        }
    }
}
