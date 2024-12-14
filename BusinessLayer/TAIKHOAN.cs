using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public class TAIKHOAN
    {
        QLCBEntities db = new QLCBEntities();
        public List<tb_TAIKHOAN> getList()
        {
            return db.tb_TAIKHOAN.ToList();
        }
        //Mã hoá mật khẩu thành SHA256
        private string MaHoa(string matkhau)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert mật khẩu từ string sang byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(matkhau));

                // Convert byte array sang string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public string KiemTraTaiKhoan(string taikhoan, string pass)
        {
            string id = "";
            try
            {
                using (var db = new QLCBEntities())
                {
                    // Mã hóa mật khẩu bằng SHA256
                    string maHoa = MaHoa(pass);

                    var user = db.tb_TAIKHOAN.FirstOrDefault(u => u.taikhoan == taikhoan && u.matkhau == maHoa);

                    if (user != null)
                    {
                        id = user.id.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
            return id;
        }

        
        // Hàm để thêm một tài khoản mới
        public bool ThemTaiKhoan(string taikhoan, string matkhau)
        {
            try
            {
                using (var db = new QLCBEntities())
                {
                    // Kiểm tra xem tài khoản đã tồn tại chưa
                    var kiemTra = db.tb_TAIKHOAN.FirstOrDefault(u => u.taikhoan == taikhoan);

                    if (kiemTra == null)
                    {
                        // Mã hóa mật khẩu
                        string maHoa = MaHoa(matkhau);
                        // Tạo một đối tượng mới cho tài khoản
                        var taoTK = new tb_TAIKHOAN
                        {
                            taikhoan = taikhoan,
                            matkhau = maHoa // Không cần mã hóa ở đây vì chúng ta đã mã hóa trước khi gọi hàm này
                        };

                        // Thêm tài khoản mới vào DbContext và lưu thay đổi
                        db.tb_TAIKHOAN.Add(taoTK);
                        db.SaveChanges();

                        return true;
                    }
                    else
                    {
                        // Tài khoản đã tồn tại
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ nếu cần
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        // Hàm để thay đổi mật khẩu của người dùng
        public bool DoiMatKhau(string taikhoan, string matkhaucu, string matkhaumoi)
        {
            try
            {
                using (var db = new QLCBEntities())
                {
                    // Tìm kiếm tài khoản cần sửa trong cơ sở dữ liệu
                    var user = db.tb_TAIKHOAN.FirstOrDefault(u => u.taikhoan == taikhoan);

                    if (user != null)
                    {
                        // Mã hóa mật khẩu cũ
                        string maHoa = MaHoa(matkhaucu);

                        // Kiểm tra mật khẩu cũ
                        if (user.matkhau == maHoa)
                        {
                            // Mã hóa mật khẩu mới
                            string maHoa1 = MaHoa(matkhaumoi);

                            // Cập nhật mật khẩu mới
                            user.matkhau = maHoa1;
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            // Mật khẩu cũ không đúng
                            return false;
                        }
                    }
                    else
                    {
                        // Không tìm thấy tài khoản
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ nếu cần
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

    
    public bool XoaTaiKhoan(string taikhoan)
        {
            try
            {
                using (var db = new QLCBEntities())
                {
                    // Tìm kiếm tài khoản cần xoá trong cơ sở dữ liệu
                    var user = db.tb_TAIKHOAN.FirstOrDefault(u => u.taikhoan == taikhoan);

                    if (user != null)
                    {
                        // Xoá tài khoản
                        db.tb_TAIKHOAN.Remove(user);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        // Không tìm thấy tài khoản
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ nếu cần
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

    }

}

