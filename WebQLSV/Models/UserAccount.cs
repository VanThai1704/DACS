namespace WebQLSV.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; } // "SinhVien" hoặc "GiangVien"
    }
} 