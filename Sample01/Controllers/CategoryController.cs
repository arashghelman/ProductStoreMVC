using Sample01.Models.DomainModels.DTO.EF;
using Sample01.Models.DomainModels.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sample01.Controllers
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
        private Models.ViewModels.CategoryViewModel Ref_CategoryViewModel { get; set; }
        #endregion

        #region [- Actions -]

        #region [- Index() -]
        [Route("~/")]
        public ActionResult Index()
        {
            return View(Ref_CategoryViewModel);
        }
        #endregion

        #endregion

        #region [- Create -]
        #region [- Get -]
        [Route("Create")]
        [HttpGet]
        public ActionResult Create()
        {
            return View(Ref_CategoryViewModel);
        }
        #endregion

        #region [- Post -]
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.ViewModels.CategoryViewModel ref_CategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                ref_CategoryViewModel.PostCategory(ref_CategoryViewModel.Ref_Category);
                return RedirectToAction("Index");
            }
            return View(ref_CategoryViewModel);
        }
        #endregion
        #endregion

        #region [- Edit -]

        #region [- Get -]
        [Route("Edit/{id:int}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = Ref_CategoryViewModel.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        #endregion

        #region [- Post -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id:int}")]
        public ActionResult Edit(Models.ViewModels.CategoryViewModel ref_CategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                ref_CategoryViewModel.PutCategory(ref_CategoryViewModel.Ref_Category);
                return RedirectToAction("Index");
            }
            return View(ref_CategoryViewModel);
        }
        #endregion
        #endregion

        #region [- Delete -]

        #region [- Get -]
        [Route("Delete/{id:int}")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = Ref_CategoryViewModel.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        #endregion

        #region [- Post -]
        [Route("Delete/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Ref_CategoryViewModel.DeleteCategory(id);
            return RedirectToAction("Index");
        }
        #endregion
        #endregion
    }
}