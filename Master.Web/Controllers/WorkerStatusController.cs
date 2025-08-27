using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Master.Web.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerStatusController : ControllerBase {


        [HttpPost(Name = "UpdateStatus")]
        public ActionResult<string> Register(Guid Id, int StatusCode) {
            try {
                return Ok("Status Updated");
            }
            catch(Exception) {
            
            }
            return BadRequest("Error Updating Status" );
        }

    }
}
