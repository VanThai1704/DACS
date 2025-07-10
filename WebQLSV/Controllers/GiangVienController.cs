using Microsoft.AspNetCore.Mvc;
using WebQLSV.Models;

namespace WebQLSV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiangVienController : ControllerBase
    {
        private static List<GiangVien> _giangViens = new List<GiangVien>();

        [HttpGet]
        public IActionResult GetAll() => Ok(_giangViens);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var gv = _giangViens.FirstOrDefault(x => x.Id == id);
            if (gv == null) return NotFound();
            return Ok(gv);
        }

        [HttpPost]
        public IActionResult Create([FromBody] GiangVien gv)
        {
            gv.Id = _giangViens.Count > 0 ? _giangViens.Max(x => x.Id) + 1 : 1;
            _giangViens.Add(gv);
            return CreatedAtAction(nameof(GetById), new { id = gv.Id }, gv);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GiangVien gv)
        {
            var existing = _giangViens.FirstOrDefault(x => x.Id == id);
            if (existing == null) return NotFound();
            existing.MaGV = gv.MaGV;
            existing.HoTen = gv.HoTen;
            existing.BoMon = gv.BoMon;
            existing.Email = gv.Email;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var gv = _giangViens.FirstOrDefault(x => x.Id == id);
            if (gv == null) return NotFound();
            _giangViens.Remove(gv);
            return NoContent();
        }
    }
} 