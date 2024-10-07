using Lab1.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


public class Student
{
    public int Id { get; set; } // Mã sinh viên

    [Required(ErrorMessage = "Họ tên là bắt buộc.")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải từ 4 đến 100 ký tự.")]
    [Display(Name = "Họ tên")]
    public string? Name { get; set; } // Họ tên

    [Required(ErrorMessage = "Email bắt buộc phải được nhập.")]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi gmail.com.")]
    [Display(Name = "Email")]
    public string? Email { get; set; } // Email

    [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt.")]
    [Display(Name = "Mật khẩu")]
    public string? Password { get; set; } // Mật khẩu

    [Required(ErrorMessage = "Ngành học là bắt buộc.")]
    [Display(Name = "Ngành học")]
    public Branch? Branch { get; set; } // Ngành học

    [Required(ErrorMessage = "Giới tính là bắt buộc.")]
    [Display(Name = "Giới tính")]
    public Gender? Gender { get; set; } // Giới tính

    [Display(Name = "Hệ chính quy")]
    public bool IsRegular { get; set; } // Hệ: true-chính quy, false-phi chính quy

    [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Địa chỉ")]
    public string? Address { get; set; } // Địa chỉ


    [Required(ErrorMessage = "Ngày sinh là bắt buộc.")]
    [Range(typeof(DateTime), "1/1/1963", "31/12/2025", ErrorMessage = "Ngày sinh phải trong khoảng từ 01/01/1963 đến 31/12/2005.")]
    [DataType(DataType.Date)]
    [Display(Name = "Ngày sinh")]
    public DateTime DateOfBirth { get; set; } // Ngày sinh

    [Required(ErrorMessage = "Điểm là bắt buộc.")]
    [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0.")]
    [Display(Name = "Điểm")]
    public double Mark { get; set; } // Điểm
}