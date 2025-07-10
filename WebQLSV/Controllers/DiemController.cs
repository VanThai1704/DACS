using Microsoft.AspNetCore.Mvc;
using WebQLSV.Models;

namespace WebQLSV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiemController : ControllerBase
    {
        private static List<Diem> _diems = new List<Diem>();

        [HttpGet]
        public IActionResult GetAll() => Ok(_diems);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var d = _diems.FirstOrDefault(x => x.Id == id);
            if (d == null) return NotFound();
            return Ok(d);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Diem d)
        {
            d.Id = _diems.Count > 0 ? _diems.Max(x => x.Id) + 1 : 1;
            _diems.Add(d);
            return CreatedAtAction(nameof(GetById), new { id = d.Id }, d);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Diem d)
        {
            var existing = _diems.FirstOrDefault(x => x.Id == id);
            if (existing == null) return NotFound();
            existing.SinhVienId = d.SinhVienId;
            existing.MonHocId = d.MonHocId;
            existing.DiemChuyenCan = d.DiemChuyenCan;
            existing.DiemGiuaKy = d.DiemGiuaKy;
            existing.DiemCuoiKy = d.DiemCuoiKy;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var d = _diems.FirstOrDefault(x => x.Id == id);
            if (d == null) return NotFound();
            _diems.Remove(d);
            return NoContent();
        }
    }
} 