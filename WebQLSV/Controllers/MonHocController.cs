using Microsoft.AspNetCore.Mvc;
using WebQLSV.Models;

namespace WebQLSV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonHocController : ControllerBase
    {
        private static List<MonHoc> _monHocs = new List<MonHoc>();

        [HttpGet]
        public IActionResult GetAll() => Ok(_monHocs);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var mh = _monHocs.FirstOrDefault(x => x.Id == id);
            if (mh == null) return NotFound();
            return Ok(mh);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MonHoc mh)
        {
            mh.Id = _monHocs.Count > 0 ? _monHocs.Max(x => x.Id) + 1 : 1;
            _monHocs.Add(mh);
            return CreatedAtAction(nameof(GetById), new { id = mh.Id }, mh);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MonHoc mh)
        {
            var existing = _monHocs.FirstOrDefault(x => x.Id == id);
            if (existing == null) return NotFound();
            existing.TenMon = mh.TenMon;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mh = _monHocs.FirstOrDefault(x => x.Id == id);
            if (mh == null) return NotFound();
            _monHocs.Remove(mh);
            return NoContent();
        }
    }
} 