using CakesApi.Business;
using CakesApi.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowCorsPolicy")]
    public class CakesController : ControllerBase
    {
        private readonly ICakesService _cakesService;

        public CakesController(ICakesService cakesService)
        {
            _cakesService = cakesService;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(this._cakesService.Get(id));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(this._cakesService.GetAll());
        }

        [HttpPost]
        public ActionResult Create(Cake cake)
        {
            if (this._cakesService.Get(cake.Name) != null)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Cake already exists",
                    Instance = HttpContext?.Request.Path,
                    Detail = "Cake already exists"
                };
                
                return BadRequest(problemDetails);
            }
            
            return Ok(this._cakesService.Create(cake));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._cakesService.Delete(id);
        }

    }
}
