using Microsoft.AspNetCore.Mvc;
using TranTuanAnh_Buoi2.Models;

namespace TranTuanAnh_Buoi2.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ListBook()
        {
            //Tiến hành viết code
            //Khai báo mảng sách mà chứa Lớp Book
            var books = new List<Book>();

            //Tiến hành tạo các quyển sách và đưa vào mảng books
            //tạo ra 1 quyển sách
            Book b = new Book();
            b.id = 1;
            b.title = "Tất cả các loài củ chuối";
            b.author = "Không biết";
            //đưa quyển sách này vào danh sách books
            books.Add(b);

            //Tiến hành tạo các quyển sách và đưa vào mảng books
            //tạo ra 1 quyển sách
            Book b1 = new Book();
            b1.id = 2;
            b1.title = "Sự tích con chim";
            b1.author = "Không biết";
            //đưa quyển sách này vào danh sách books
            books.Add(b1);

            //Tiến hành tạo các quyển sách và đưa vào mảng books
            //tạo ra 1 quyển sách
            Book b2 = new Book();
            b2.id = 3;
            b2.title = "GCS";
            b2.author = "Không biết";
            //đưa quyển sách này vào danh sách books
            books.Add(b);

            //Tiến hành tạo các quyển sách và đưa vào mảng books
            //tạo ra 1 quyển sách
            Book b3 = new Book();
            b3.id = 4;
            b3.title = "AAA";
            b3.author = "Không biết";
            //đưa quyển sách này vào danh sách books
            books.Add(b);

            //Tiến hành tạo các quyển sách và đưa vào mảng books
            //tạo ra 1 quyển sách
            Book b4 = new Book();
            b4.id = 5;
            b4.title = "TTA";
            b4.author = "Không biết";
            //đưa quyển sách này vào danh sách books
            books.Add(b);

            //Đưa mảng này vào ViewBag
            //để qua bên HTML sử dụng được
            ViewBag.dsSach = books;

            return View();
        }
    }
}
