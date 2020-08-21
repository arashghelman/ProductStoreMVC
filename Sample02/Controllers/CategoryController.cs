using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample02.Controllers
{
    [RoutePrefix("Category")]
    public class CategoryController : Controller
    {

        #region [- ctor -]
        public CategoryController()
        {
            Ref_CategoryViewModel = new Models.ViewModels.CategoryViewModel();
        }
        #endregion

        #region [- props -]
        public Models.ViewModels.CategoryViewModel Ref_CategoryViewModel { get; set; }
        #endregion

        #region [- Index() -]
        [Route("~/")]
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(Ref_CategoryViewModel);
        }
        #endregion

        #region [- Create(Models.DomainModels.DTO.EF.Category ref_Category) -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(Models.DomainModels.DTO.EF.Category ref_Category)
        {
            if (ModelState.IsValid)
            {
                return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { ModelState_IsValid = "False", JsonRequestBehavior.AllowGet });
            }
        } 
        #endregion

    }
}