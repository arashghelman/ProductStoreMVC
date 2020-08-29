using Newtonsoft.Json.Linq;
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
        [AllowAnonymous]
        [Route("Create")]
        public ActionResult Create(Models.ViewModels.CategoryViewModel ref_CategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Ref_CategoryViewModel.PostCategory(ref_CategoryViewModel);
                return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { ModelState_IsValid = "False", JsonRequestBehavior.AllowGet });
            }
        }
        #endregion


        [HttpPost]
        [AllowAnonymous]
        [Route("Delete")]
        public ActionResult Delete(Models.ViewModels.CategoryViewModel ref_CategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Ref_CategoryViewModel.DeleteCategory(ref_CategoryViewModel);
                return Json(JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Edit")]
        public ActionResult Edit(Models.ViewModels.CategoryViewModel ref_CategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Ref_CategoryViewModel.PutCategory(ref_CategoryViewModel);
                return Json(JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { JsonRequestBehavior.AllowGet });
            }
        }

    }
}