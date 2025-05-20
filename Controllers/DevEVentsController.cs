using AwesomeDevEventsAPI.Entities;
using AwesomeDevEventsAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDevEventsAPI.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEVentsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;

        public DevEVentsController(DevEventsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEvents.Where(d=>!d.IsDeleted).ToList();
            return Ok(devEvents);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(d=>d.Id == id);
            if (devEvents == null) 
            {
                return NotFound();
             }
             return Ok(devEvents);
        }

        [HttpPost]

        public IActionResult Post(DevEvent devEvent)
        {
            _context.DevEvents.Add(devEvent);
            return CreatedAtAction(nameof(GetById), new {id=devEvent.Id},devEvent);
        }
        // api dev-events
        [HttpPut("{id}")]

        public IActionResult Update(Guid id, DevEvent input)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(devEvent => devEvent.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Update(input.Title, input.Description, input.StartedDate, input.EndDate);

            return NoContent(); // ou return Ok(devEvent); se quiser retornar algo
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
       
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Delete();
            return NoContent();

        }



    }
}

