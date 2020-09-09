using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample02.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {

        public ProductController()
        {
            Ref_ProductViewModel = new Models.ViewModels.ProductViewModel();
        }

        public Models.ViewModels.ProductViewModel Ref_ProductViewModel { get; set; }

        [Route("")]
        public ActionResult Index()
        {
            ViewBag.CategoryList = new SelectList(Ref_ProductViewModel.GetCategoryItems(), "Id", "CategoryName");
            return View(Ref_ProductViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Create")]
        public ActionResult Create(Models.ViewModels.ProductViewModel ref_ProductViewModel)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductViewModel.PostProduct(ref_ProductViewModel);
                ViewBag.CategoryList = new SelectList(Ref_ProductViewModel.GetCategoryItems(), "Id", "CategoryName",
                    ref_ProductViewModel.CategoryRef);
                return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { ModelState_IsValid = "False", JsonRequestBehavior.AllowGet });
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("Delete")]
        public ActionResult Delete(Models.ViewModels.ProductViewModel ref_ProductViewModel)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductViewModel.DeleteProduct(ref_ProductViewModel);
                return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { ModelState_IsValid = "False", JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("Create")]
        public ActionResult Edit(Models.ViewModels.ProductViewModel ref_ProductViewModel)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductViewModel.PutProduct(ref_ProductViewModel);
                ViewBag.CategoryList = new SelectList(Ref_ProductViewModel.GetCategoryItems(), "Id", "CategoryName",
                    ref_ProductViewModel.CategoryRef);
                return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { ModelState_IsValid = "False", JsonRequestBehavior.AllowGet });
            }
        }
    }
}