using BilgeDayiBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeDayiBlog.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public abstract class AdminBaseController : Controller
    {
        // GET: Admin/AdminBase
        protected ApplicationDbContext db = new ApplicationDbContext();



        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}