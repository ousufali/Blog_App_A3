using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_App_A3.Models;

namespace Blog_App_A3.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext data_context = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View(data_context.Blogs.ToList());
        }
        public ActionResult AddBlog()
        {
            return View();
        }
        public ActionResult Add()
        {
            string author = Request["author"];
            string blog = Request["blog"];

            Blog b = new Blog();
            b.author = author;
            b.blog = blog;

            data_context.Blogs.InsertOnSubmit(b);
            data_context.SubmitChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditBlog(int id)
        {
            var blog = data_context.Blogs.First(b => b.Id == id);

            return View(blog);
        }
        public ActionResult Edit(int id)
        {
            var blog = data_context.Blogs.First(b => b.Id == id);
            blog.author = Request["author"];
            blog.blog = Request["blog"];
            data_context.SubmitChanges();

            return RedirectToAction("Index");
        }

    }
}
