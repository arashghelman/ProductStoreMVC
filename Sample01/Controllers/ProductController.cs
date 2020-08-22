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
        }
        #endregion

        #region [- props -]
        public Models.ViewModels.ProductViewModel Ref_ProductViewModel { get; set; }
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
            ViewBag.CategoryList = new SelectList(Ref_ProductViewModel.GetCategoryItems(), "Id", "CategoryName");
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
                    ref_ProductViewModel.PostProduct();
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryList = new SelectList(Ref_ProductViewModel.GetCategoryItems(), "Id", "CategoryName",
                Ref_ProductViewModel.CategoryId);
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
            var product = Ref_ProductViewModel.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        #endregion

        #region [- Post -]
        [Route("Delete/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Ref_ProductViewModel.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        #endregion

        #endregion

        #region [- Edit -]

        #region [- Get -]
        [Route("Edit/{id:int}")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.ViewModels.ProductViewModel ref_ProductViewModel = Ref_ProductViewModel.GetProductById(id);
            if (ref_ProductViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Ref = new SelectList(Ref_ProductViewModel.GetCategoryItems(), "Id", "CategoryName");
            return View(ref_ProductViewModel);
        }
        #endregion

        #region [- Post -]
        [Route("Edit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.ViewModels.ProductViewModel ref_ProductViewModel, HttpPostedFileBase fileBase)
        {
            if (ModelState.IsValid)
            {
                if (fileBase != null)
                {
                    ref_ProductViewModel.ProductPhoto = new byte[fileBase.ContentLength];
                    fileBase.InputStream.Read(ref_ProductViewModel.ProductPhoto, 0, fileBase.ContentLength);
                }
                ref_ProductViewModel.PutProduct();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Ref = new SelectList(Ref_ProductViewModel.GetCategoryItems(), "Id", "CategoryName", ref_ProductViewModel.CategoryId);
            return View(ref_ProductViewModel);
        }
        #endregion

        #endregion
        #endregion
    }
}