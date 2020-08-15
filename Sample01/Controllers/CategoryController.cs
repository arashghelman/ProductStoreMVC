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
        //#region [- Details(int? id) -]
        //[Route("{id:int}")]
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Category ref_Category = Ref_CategoryCrud.FindId(id);
        //    if (ref_Category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ref_Category);
        //}
        //#endregion

        //#region [- Create -]
        //#region [- Get -]
        //[Route("Create")]
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //#endregion

        //#region [- Post -]
        //[Route("Create")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,CategoryName")] Category ref_Category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Ref_CategoryCrud.Insert(ref_Category);
        //        return RedirectToAction("Index");
        //    }
        //    return View(ref_Category);
        //}
        //#endregion
        //#endregion

        //#region [- Edit -]

        //#region [- Get -]
        //[Route("Edit/{id:int}")]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var category = Ref_CategoryCrud.FindId(id);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(category);
        //}
        //#endregion

        //#region [- Post -]
        //[Route("Edit/{id:int}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,CategoryName")] Category ref_Category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Ref_CategoryCrud.Update(ref_Category);
        //        return RedirectToAction("Index");
        //    }
        //    return View(ref_Category);
        //}
        //#endregion
        //#endregion

        //#region [- Delete -]

        //#region [- Get -]
        //[Route("Delete/{id:int}")]
        //[HttpGet]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Category category = Ref_CategoryCrud.FindId(id);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(category);
        //}
        //#endregion

        //#region [- Post -]
        //[Route("Delete/{id:int}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{            
        //    Ref_CategoryCrud.Delete(id);
        //    return RedirectToAction("Index");
        //}  
        //#endregion
        //#endregion
        //#endregion
    }
}