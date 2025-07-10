using Microsoft.AspNetCore.Mvc;
using WebQLSV.Models;

namespace WebQLSV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LopHocController : ControllerBase
    {
        private static List<LopHoc> _lopHocs = new List<LopHoc>();

        [HttpGet]
        public IActionResult GetAll() => Ok(_lopHocs);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var lh = _lopHocs.FirstOrDefault(x => x.Id == id);
            if (lh == null) return NotFound();
            return Ok(lh);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LopHoc lh)
        {
            lh.Id = _lopHocs.Count > 0 ? _lopHocs.Max(x => x.Id) + 1 : 1;
            _lopHocs.Add(lh);
            return CreatedAtAction(nameof(GetById), new { id = lh.Id }, lh);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LopHoc lh)
        {
            var existing = _lopHocs.FirstOrDefault(x => x.Id == id);
            if (existing == null) return NotFound();
            existing.TenLop = lh.TenLop;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var lh = _lopHocs.FirstOrDefault(x => x.Id == id);
            if (lh == null) return NotFound();
            _lopHocs.Remove(lh);
            return NoContent();
        }
    }
} 