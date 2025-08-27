using Master.Web.Persistance;
using Microsoft.AspNetCore.Mvc;


namespace Master.Web.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase {
        public RegistrationController(RegistrationDbContext context) {
            _context = context;
        }
        private readonly RegistrationDbContext _context;

        [HttpGet(Name = "GetNewRegistrationNumber")]
        public ActionResult<bool> Register(Guid Id, String MachineName, String IpAddress, String MacAddess) {
            try {
                _context.Workers.Add(new Persistance.Models.Worker() { Id = Id, RegistrationDate = DateTime.UtcNow });

                _context.SaveChanges();
                return Ok(true);
            }
            catch(Exception) {
                throw;
            }
            return BadRequest(false);
        }
    }
}
