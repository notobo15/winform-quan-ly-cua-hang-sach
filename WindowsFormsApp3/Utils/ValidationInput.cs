using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Utils
{
    public class ValidationInput
    {
        public static string INVALID_EMAIL = "Không đúng định đang Email. Vui lòng nhập lại.";
        public static string INVALID_NAME = "Họ và Tên không được chứ số. Vui lòng nhập lại.";
        public static string INVALID_BIRTHDAY = "Ngày sinh không hợp lệ. Vui lòng nhập lại.";
        public static string INVALID_ADDRESS = "Họ và Tên không được chứ số. Vui lòng nhập lại.";
        public static string INVALID_PHONE = "Sdt không hợp lệ vì chỉ chứa 10 ki tự số (Ví dụ: 0987654321). Vui lòng nhập lại.";
        public static string SUCCESS = "Thành Công.";
        public static string FAILED = "Thất bại.";

        public static string TITLE = "Thông Báo.";

        public static string COMFIRM_EXIT = "Bạn có chắc chắn muốn thoát";
        public static string COMFIRM_DELETE = "Bạn có chắc chắn muốn xoá.";
        public static string MISS_DATA_EDIT = "Bạn phải chọn mẫu tin cập nhật";


        public static string SUCCESS_ADD = "Thêm mới thành công.";
        public static string SUCCESS_EDIT = "Chỉnh sửa thành công.";


        public static string INVALID_NOTEMPTY(string name)
        {
            return $"{name} không được bỏ trống. Vui lòng nhập lại.";
        }
        public static bool IsNamePersonValid(string input)
        {
            var isvalid = !string.IsNullOrEmpty(input) && !input.Any(char.IsDigit);
            if (isvalid)
            {
                return true;
            }
            else
            { return false; }
        }
        public static bool IsBirthDayValid(DateTime ngaysinh)
        {

            // Xác định khoảng thời gian hợp lệ
            DateTime minDateOfBirth = new DateTime(1900, 1, 1);
            DateTime maxDateOfBirth = DateTime.Today;

            // Kiểm tra xem ngày sinh nằm trong khoảng thời gian hợp lệ
            if (ngaysinh < minDateOfBirth || ngaysinh > maxDateOfBirth)
            {
                return false;
            }

            return true;
        }

        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            // Kiểm tra xem chuỗi có đúng 10 ký tự số và không chứa ký tự khác không
            if (phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
        public static bool IsValidEmail(string email)
        {
            // Biểu thức chính quy để kiểm tra địa chỉ email
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Sử dụng Regex.IsMatch để kiểm tra
            return Regex.IsMatch(email, pattern);
        }
    }
}
