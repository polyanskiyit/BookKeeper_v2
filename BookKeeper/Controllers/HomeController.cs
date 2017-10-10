using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BookKeeper.Models;

namespace BookKeeper.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext _db = new BookContext();

        [HttpGet]
        public ActionResult Index(int? id)
        {
            ViewBag.Id = id;

            //  sort by id
            ViewBag.Books = SordDbById();

            var book = _db.Books.Find(id);

            if (book != null)
                return View("Index", book);
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(book).State = EntityState.Modified;
                _db.SaveChanges();
                TempData["m"] = $"Книгу з назвою '{book.Name}' успішно змінено!";
                ViewBag.Books = _db.Books;
                return View("Index");
            }
            ViewBag.Books = _db.Books;
            return View("Index", book);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult LocalEditBook(int? id)
        {
            ViewBag.Id = id;
            ViewBag.Books = _db.Books;
            if (id == null) return RedirectToAction("Index");
            var book = _db.Books.Find(id);
            if (book != null)
                return View("Index", book);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult LocalEditBook(Book book)
        {
            ViewBag.Books = _db.Books;
            if (ModelState.IsValid)
            {
                _db.Entry(book).State = EntityState.Modified;
                _db.SaveChanges();
                TempData["m"] = $"Книгу з назвою '{book.Name}' успішно змінено!";
                return RedirectToAction("Index");
            }
            return LocalEditBook(book.Id);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var book = _db.Books.Find(id);
            if (book != null)
                return View(book);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(book).State = EntityState.Modified;
                _db.SaveChanges();
                TempData["m"] = $"Книгу з назвою '{book.Name}' успішно змінено!";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                TempData["m"] = $"Книгу з назвою '{book.Name}' успішно додано до колекції!";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return View("Index");

            var book = _db.Books.FirstOrDefault(m => m.Id == id);
            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
                TempData["m"] = $"Книгу з назвою '{book.Name}' успішно видалено!";
            }
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult CreateLocal(int? id)
        {
            ViewBag.NewBookFlag = 1;
            ViewBag.Books = SordDbById();
            if (id == null)
            {
                ViewBag.NewBookFlag = 1;
                return View("Index");
            }
            ViewBag.Id = id;
            var book = _db.Books.Find(id);
            if (book != null)
                return View("Index", book);
            return View("Index");
        }

        private IOrderedQueryable<Book> SordDbById()
        {
            return from n in _db.Books
                orderby n.Id
                select n;
        }

        [HttpPost]
        public ActionResult CreateLocal(Book book)
        {
            ViewBag.Books = _db.Books;
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                TempData["m"] = $"Книгу з назвою '{book.Name}' успішно додано до колекції!";
                return RedirectToAction("Index");
            }
            return CreateLocal(book.Id);
        }
    }
}