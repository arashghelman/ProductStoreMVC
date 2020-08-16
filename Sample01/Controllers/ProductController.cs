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
    [RoutePrefix("Product")]
    //[Route("{action=Index}")]
    public class ProductController : Controller
    {
        #region [- ctors -]
        public ProductController()
        {
            Ref_ProductViewModel = new Models.ViewModels.ProductViewModel();
            Ref_CategoryViewModel = new Models.ViewModels.CategoryViewModel();
            var product = new Models.DomainModels.DTO.EF.Product();
        }
        #endregion

        #region [- props -]
        public Models.ViewModels.ProductViewModel Ref_ProductViewModel { get; set; }
        public Models.ViewModels.CategoryViewModel Ref_CategoryViewModel { get; set; }
        #endregion

        #region [- Actions -]

        #region [- Index() -]
        [Route("")]
        public ActionResult Index()
        {
            return View(Ref_ProductViewModel);
        }
        #endregion

        #region [- Create -]

        #region [- Get -]
        [Route("Create")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(Ref_CategoryViewModel.GetCategory(), "Id", "CategoryName");
            return View(Ref_ProductViewModel);
        }
        #endregion

        #region [- Post -]
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.ViewModels.ProductViewModel ref_ProductViewModel, HttpPostedFileBase fileBase)
        {

            if (ModelState.IsValid)
            {
                if (fileBase != null)
                {
                    ref_ProductViewModel.ProductPhoto = new byte[fileBase.ContentLength];
                    fileBase.InputStream.Read(ref_ProductViewModel.ProductPhoto, 0, fileBase.ContentLength);
                    ref_ProductViewModel.PostProduct(ref_ProductViewModel.Ref_Product);
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryList = new SelectList(Ref_CategoryViewModel.GetCategory(), "Id", "CategoryName",
                ref_ProductViewModel.CategoryId);
            }
            return View(ref_ProductViewModel);
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
        //    var ref_Product = Ref_ProductCrud.FindId(id);
        //    if (ref_Product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ref_Product);
        //} 
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
        //    var product = Ref_ProductCrud.FindId(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}
        //#endregion

        //#region [- Post -]
        //[Route("Delete/{id:int}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    Ref_ProductCrud.Delete(id);
        //    return RedirectToAction("Index");
        //}
        //#endregion

        //#endregion

        //#region [- Edit -]

        //#region [- Get -]
        //[Route("Edit/{id:int}")]
        //[HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var ref_Product = Ref_ProductCrud.FindId(id);
        //    if (ref_Product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Category_Ref = new SelectList(Ref_CategoryCrud.Select(), "Id", "CategoryName");
        //    return View(ref_Product);
        //}
        //#endregion

        //#region [- Post -]
        //[Route("Edit/{id:int}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id, Category_Ref, ProductName, UnitPrice, Discount, Quantity, ProductPhoto")] Product ref_Product, HttpPostedFileBase fileBase)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (fileBase != null)
        //        {
        //            ref_Product.ProductPhoto = new byte[fileBase.ContentLength];
        //            fileBase.InputStream.Read(ref_Product.ProductPhoto, 0, fileBase.ContentLength);
        //        }
        //        Ref_ProductCrud.Update(ref_Product);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Category_Ref = new SelectList(Ref_CategoryCrud.Select(), "Id", "CategoryName", ref_Product.Category_Ref);
        //    return View(ref_Product);
        //}  
        //#endregion

        //#endregion
        #endregion
    }
}