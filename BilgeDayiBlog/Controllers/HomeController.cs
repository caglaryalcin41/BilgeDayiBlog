using BilgeDayiBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeDayiBlog.Controllers
{
    public class HomeController : BaseController
    {


        public ActionResult Index(int? cid, int page =1)
        {
            int pageSize = 5;
            ViewBag.SubTitle = "Yazılarım";
          IQueryable <Post> result = db.Posts;
            Category cat = null;

            if (cid != null)
            {
                cat = db.Categories.Find(cid);
                if (cat == null)
                {
                    return HttpNotFound();
                }

                ViewBag.SubTitle = cat.CategoryName;
              result = result.Where(x => x.CategoryId == cid);

                ViewBag.page = page;
                ViewBag.pageCount = Math.Ceiling(result.Count() / (decimal)pageSize); // toplam sayfa sayısını aldık. //bölmenin tam çıkabilmesi için decimala cast ettik ve celing sonucu yukarı yuvarladık.
                ViewBag.NextPage = page + 1;
                ViewBag.PrevPage = page - 1;
                ViewBag.cid = cid;
            }
            return View(result.OrderByDescending(x=> x.CreationTime).Skip((page-1)*pageSize).Take(pageSize).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CategoriesPartial()
        {
            return PartialView("_CategoriesPartial", db.Categories.ToList());
        }
    }
}