
using Microsoft.AspNetCore.Mvc;


namespace UStart.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/grupo-produto")]



    public class GrupoProdutoController: ControllerBase
    {
        
        public GrupoProdutoController()
        {
        }

            [HttpGet]
            public IActionResult getGrupos(){
                return Ok("ok");
            }

    }
}