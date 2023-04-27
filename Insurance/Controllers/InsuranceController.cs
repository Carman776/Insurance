using Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly MongoDbContext _context;

        public InsuranceController(MongoDbContext context)
        {
            _context = context;
        }       

        
        [HttpPost("FindRegister")]
        public List<InsuranceRegister> FindRegister(InsuranceRegister registerQuery)
        {

            var data = _context.GetCollection<InsuranceRegister>("Insurance");
            var result = data.Find(x => x.PlacaVehiculo == registerQuery.PlacaVehiculo || x.NumeroPoliza == registerQuery.NumeroPoliza).ToList();

            return result;
        }

        [HttpPost("Validation")]

        public InsuranceValidation GetPolicyValidation(InsuranceValidation registerValidation) {

            var data = _context.GetCollection<InsuranceValidation>("InsuranceValidation");
            var result = data.Find(x => x.NumeroPoliza == registerValidation.NumeroPoliza).ToList().FirstOrDefault();

            return result;
                

        }
        
        [HttpPost("Register")]
        public string RegisterNewPolicy([FromBody] InsuranceRegister registerData)
        {
            var data = _context.GetCollection<InsuranceRegister>("Insurance");
            var dataValidation = _context.GetCollection<InsuranceValidation>("InsuranceValidation");
            try
            {

                data.InsertOne(registerData);

                InsuranceValidation validation = new InsuranceValidation()
                {
                    NumeroPoliza = registerData.NumeroPoliza,
                    FechaInicioVigencia = registerData.FechaDeTomaPoliza,
                    FechaFinVigencia = registerData?.FechaDeTomaPoliza == null ? DateTime.Now.AddYears(1) : registerData?.FechaDeTomaPoliza.GetValueOrDefault().AddYears(1),

                };

                dataValidation.InsertOne(validation);


                return "Registro Creado Correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }            
            
        }
        
    }
}
