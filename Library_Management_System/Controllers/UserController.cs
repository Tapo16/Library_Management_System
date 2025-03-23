using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ProjectModel;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Library_Management_System.Controllers
{

    public class UserController : Controller
    {

        ProjectContext _db;

        public UserController(ProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Login(User obj)
        {
            try
            {
                var email = await _db.tbluser.Where(a => a.Email == obj.Email && a.Password == obj.Password).FirstOrDefaultAsync();
                if(email == null)
                {
                    ViewBag.Message = "Invalid Login";
                    return View(obj);
                }
                else
                {
                    HttpContext.Session.SetString("UserEmail",obj.Email);
                    return RedirectToAction("Book");
                }
            }
            catch
            {
                TempData["Message"] = "Login failed";
                return View(obj);
            }
        }

        [HttpGet]
        public IActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Reg(User obj)
        {
            try
            {
                var emailexist = await _db.tbluser.Where(a => a.Email == obj.Email).FirstOrDefaultAsync();

                if(emailexist == null)
                {
                  await _db.tbluser.AddAsync(obj);
                  await _db.SaveChangesAsync();
                  TempData["Message"] = "Reg success";
                }
                else
                {
                    TempData["Message"] = "This email exists";
                }
            }
            catch
            {
                TempData["Message"] = "Registration failed";
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> ForgetPwd(User obj)
        {
            try
            {
                var email = await _db.tbluser.Where(a => a.Email == obj.Email).FirstOrDefaultAsync();
                if (email == null)
                {
                    ViewBag.Message = "Email is null";
                    return View(obj);
                }
                else
                {
                    if(email.SecurityQuestion == obj.SecurityQuestion && email.SecurityAns == obj.SecurityAns)
                    {
                        email.Password = obj.Password;
                        await _db.SaveChangesAsync();
                        TempData["Message"] = "Password Reset Success";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid sucurity question & answer";
                        return View(obj);
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(obj);
            }
        }

        public async Task<IActionResult> Book(string searchText)
        {
            string email = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = "Please login first";
                return RedirectToAction("Login");
            }
            else
            {
                var blist = await _db.tblbook.Join(_db.tblcat, a => a.Cid, b => b.CategoryId, (a, b) => new { a, b }).Select(m => new Book
                {
                    BookId = m.a.BookId,
                    BookName = m.a.BookName,
                    AuthorName = m.a.AuthorName,
                    PublisherName = m.a.PublisherName,
                    Dop = m.a.Dop,
                    Stock = m.a.Stock,
                    Availability = m.a.Availability,
                    Cid = m.a.Cid,
                    CategoryName = m.b.CatName,
                    BookFile = m.a.BookFile,
                    BookFilePath = m.a.BookFilePath,
                }).ToListAsync();

                if (searchText != null)
                {
                    blist = await _db.tblbook.Join(_db.tblcat, a => a.Cid, b => b.CategoryId, (a, b) => new { a, b }).Where(n => n.a.AuthorName.Contains(searchText) || n.b.CatName.Contains(searchText) || n.a.BookName.Contains(searchText)).Select(
                    m => new Book
                    {
                        BookId = m.a.BookId,
                        BookName = m.a.BookName,
                        AuthorName = m.a.AuthorName,
                        PublisherName = m.a.PublisherName,
                        Dop = m.a.Dop,
                        Stock = m.a.Stock,
                        Availability = m.a.Availability,
                        Cid = m.a.Cid,
                        CategoryName = m.b.CatName,
                        BookFile = m.a.BookFile,
                        BookFilePath = m.a.BookFilePath,
                    }).ToListAsync();
                    ViewBag.Message = searchText;
                }
                if (blist.Count() == 0)
                {
                    ViewBag.Message = "No data found";
                }
                return View(blist);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Borrow(int id)
        {
            string userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                TempData["Message"] = "Please log in first";
                return RedirectToAction("Login");
            }

            // check user is deactivated or not 


            var user = await _db.tbluser.Where(a => a.Email == userEmail).FirstOrDefaultAsync();
            if(user != null && user.isDeactivated == true)
            {
                TempData["Message"] = "Your account is deactivated , you can't borrow book";
                return RedirectToAction("Book");
            }


            var book = await _db.tblbook.Where(a => a.BookId == id).FirstOrDefaultAsync();
            if (book == null || book.Availability <= 0)
            {
                TempData["Message"] = "Book not availabe";
                return RedirectToAction("Book");
            }

            BorrowedBooks obj = new BorrowedBooks();

            obj.BookId = book.BookId;
            obj.UserEmail = userEmail;
            obj.BorrowDate = System.DateTime.Now;
            obj.ReturnDate = System.DateTime.Now.AddDays(7);
            obj.BookName = book.BookName;

            book.Availability -= 1;

            await _db.tblBorrwedBook.AddAsync(obj);
            await _db.SaveChangesAsync();

            TempData["Message"] = "Borrowed Book Successful";
            return RedirectToAction("Book");
        }

        


    }
}