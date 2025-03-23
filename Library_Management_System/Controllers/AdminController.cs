using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library_Management_System.Controllers
{

    public class AdminController : Controller
    {

        ProjectContext _db;
        IWebHostEnvironment _env;

        public AdminController(ProjectContext db , IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Login(Admin obj)
        {
            try
            {
                var row = await _db.tblad.Where(a => a.Email == obj.Email && a.Password == obj.Password).FirstOrDefaultAsync();
                if(row == null)
                {
                    ViewBag.Message = "Invalid Mail";
                    return View(obj);
                }
                else
                {
                HttpContext.Session.SetString("AdminMail", obj.Email);
                   return RedirectToAction("Book");
                }
            }
            catch
            {
                ViewBag.Message = "Login Failed";
                return View(obj);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Book(string? searchText)
        {
           string email = HttpContext.Session.GetString("AdminMail");

            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = "please login first";
                return RedirectToAction("Login");
            }
            else
            {
                var blist = await (from t1 in _db.tblbook
                                   join t2 in _db.tblcat on t1.Cid equals t2.CategoryId
                                   select new Book
                                   {
                                       BookId = t1.BookId,
                                       BookName = t1.BookName,
                                       AuthorName = t1.AuthorName,
                                       PublisherName = t1.PublisherName,
                                       Dop = t1.Dop,
                                       BookFilePath = t1.BookFilePath,
                                       BookFile = t1.BookFile,
                                       Stock = t1.Stock,
                                       Availability = t1.Availability,
                                       Cid = t1.Cid,
                                       CategoryName = t2.CatName
                                   }).ToListAsync();

                if (searchText != null)
                {
                    blist = await _db.tblbook.Where(a => a.AuthorName.Contains(searchText) || a.BookName.Contains(searchText)).ToListAsync();
                    ViewBag.Message = searchText;
                }
                if (blist.Count() == 0)
                {
                    ViewBag.Message = "No data found";
                }
              return View(blist);
            }
        }


        public async Task<IActionResult> CategoryHome()
        {
            var clist = await _db.tblcat.ToListAsync();
            return View(clist);
        }

        [HttpGet]
        public IActionResult CreateCat()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCat(Category obj)
        {
            try
            {
                await _db.tblcat.AddAsync(obj);
                await _db.SaveChangesAsync();

                TempData["Message"] = "Insert Success";
            }
            catch
            {
                TempData["Message"] = "Insert Failed";
            }
            return RedirectToAction("CategoryHome");
        }


        public async Task<IActionResult> DelCat(int id)
        {
            try
            {
                var clist = await _db.tblcat.Where(a => a.CategoryId == id).FirstOrDefaultAsync();
                _db.tblcat.Remove(clist);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Delcat Success";
            }
            catch
            {
                TempData["Message"] = "Delcat failed";
            }
            return RedirectToAction("CategoryHome");
        }


        [HttpGet]
        public async Task<IActionResult> EditCat(int id)
        {
            var clist = await _db.tblcat.Where(a => a.CategoryId == id).FirstOrDefaultAsync();
            return View(clist);
        }

        [HttpPost]

        public async Task<IActionResult> EditCat(Category obj)
        {
            try
            {
                _db.tblcat.Entry(obj).State = EntityState.Modified;
               await _db.SaveChangesAsync();
                TempData["Message"] = "Edit success";
            }
            catch
            {
                TempData["Message"] = "Edit failed";
            }
            return RedirectToAction("CategoryHome");
        }

        public async Task<IActionResult> DetailsCat(int id)
        {
            var clist = await _db.tblcat.Where(a => a.CategoryId == id).FirstOrDefaultAsync();
            return View(clist);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var clist = await _db.tblcat.ToListAsync();
            ViewBag.clist = clist;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book obj)
        {
            try
            {
                if (obj.BookFile != null)
                {
                    obj.Availability = obj.Stock;
                    obj.BookFilePath = FileUpload(obj.BookFile);
                    await _db.tblbook.AddAsync(obj);
                    await _db.SaveChangesAsync();
                    TempData["Message"] = "Insert Success";
                }
                else
                {
                    TempData["Message"] = "File uploaded failed";
                }
            }
            catch
            {
                TempData["Message"] = "Insert Failed";
            }
            return RedirectToAction("Book");
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bookdel = await _db.tblbook.Where(a => a.BookId == id).FirstOrDefaultAsync();
                _db.tblbook.Remove(bookdel);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Delete success";
            }
            catch
            {
                TempData["Message"] = "Delete Failed";
            }
            return RedirectToAction("Book");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var clist = await _db.tblcat.ToListAsync();
            ViewBag.clist = clist;
            var bookedit = await _db.tblbook.Where(a => a.BookId == id).FirstOrDefaultAsync();
            return View(bookedit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book obj)
        {
            try
            {
                _db.tblbook.Entry(obj).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                TempData["Message"] = "Update complete";
            }
            catch
            {
                TempData["Message"] = "Update Failed";
            }
            return RedirectToAction("Book");
        }

        public async Task<IActionResult> Details(int id)
        {
            var bookdetails = await _db.tblbook.Where(a => a.BookId == id).FirstOrDefaultAsync();
            return View(bookdetails);
        }

        public async Task<IActionResult> Bookdetails()
        {
            var userdetails = await _db.tblBorrwedBook.ToListAsync();
            return View(userdetails);
        }

        public async Task<IActionResult> RegUser()
        {
            var users = await _db.tbluser.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var delbook = await _db.tblBorrwedBook.Where(a => a.Id == id).FirstOrDefaultAsync();
                _db.tblBorrwedBook.Remove(delbook);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Delete success";
            }
            catch
            {
                TempData["Message"] = "Delete Failed";
            }
            return RedirectToAction("Bookdetails");
        }


        public async Task<IActionResult> ToggleStatus(string email)
        {
            var user = await _db.tbluser.Where(a => a.Email == email).FirstOrDefaultAsync();

            if(user != null)
            {
                if(user.isDeactivated != true)
                {
                    user.isDeactivated = true;
                }
                else if(user.isDeactivated != false)
                {
                    user.isDeactivated = false;
                }
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("RegUser");
        } 


        string FileUpload(IFormFile book_file)
        {
            string imgpath = "";
            string path = Path.Combine(_env.WebRootPath,"BookImg");
            imgpath = Guid.NewGuid().ToString().Substring(0, 8) + "_" + book_file.FileName;
            string NewFilePath = Path.Combine(path,imgpath);

            using(var FileStream = new FileStream(NewFilePath, FileMode.Create))
            {
               book_file.CopyTo(FileStream);
            }
            return imgpath;
        }
    }
}