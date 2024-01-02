using System.Linq;
using System.Web.Mvc;
using blog.Models;
using PagedList;

namespace BlogwebsiteMVC.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        DBBlogWebsiteEntities db = new DBBlogWebsiteEntities();
        public ActionResult Index(int page = 1)
        {
            var blog = db.Blogs.OrderByDescending(b => b.BlogID).ToPagedList(page, 2);

            return View(blog);
        }

        public ActionResult Hakkinda()
        {
            var hakkinda = db.Hakkindas.ToList();

            return View(hakkinda);

        }

        public ActionResult BlogDetay(int id)
        {
            var blogdetay = db.Blogs.Where(b => b.BlogID == id).SingleOrDefault();
            if (blogdetay == null)
            {
                return HttpNotFound();

            }

            return View(blogdetay);
        }
        public ActionResult OkunmaArttir(int blogid)
        {
            var blog = db.Blogs.Where(b => b.BlogID == blogid).SingleOrDefault();
            blog.BlogOkunmaSayisi = blog.BlogOkunmaSayisi + 1;
            db.SaveChanges();
            return View();
        }
        public PartialViewResult Partial()
        {
            return PartialView();
        }
    }
}