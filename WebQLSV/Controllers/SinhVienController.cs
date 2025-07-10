using Microsoft.AspNetCore.Mvc;
using WebQLSV.Models;

namespace WebQLSV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SinhVienController : ControllerBase
    {
        private static List<SinhVien> _sinhViens = new List<SinhVien>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_sinhViens);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var sv = _sinhViens.FirstOrDefault(x => x.Id == id);
            if (sv == null) return NotFound();
            return Ok(sv);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SinhVien sv)
        {
            sv.Id = _sinhViens.Count > 0 ? _sinhViens.Max(x => x.Id) + 1 : 1;
            _sinhViens.Add(sv);
            return CreatedAtAction(nameof(GetById), new { id = sv.Id }, sv);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SinhVien sv)
        {
            var existing = _sinhViens.FirstOrDefault(x => x.Id == id);
            if (existing == null) return NotFound();
            existing.HoTen = sv.HoTen;
            existing.NgaySinh = sv.NgaySinh;
            existing.Lop = sv.Lop;
            existing.Email = sv.Email;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sv = _sinhViens.FirstOrDefault(x => x.Id == id);
            if (sv == null) return NotFound();
            _sinhViens.Remove(sv);
            return NoContent();
        }
    }
} 