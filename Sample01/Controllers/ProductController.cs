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
            Ref_ProductCrud = new ProductCrud();
            Ref_CategoryCrud = new CategoryCrud();
        }
        #endregion

        #region [- props -]
        public ProductCrud Ref_ProductCrud { get; set; }
        public CategoryCrud Ref_CategoryCrud { get; set; }
        #endregion

        #region [- Actions -]

        #region [- Index() -]
        [Route("")]
        public ActionResult Index()
        {
            return View(Ref_ProductCrud.Select());
        }
        #endregion

        #region [- Create -]

        #region [- Get -]
        [Route("Create")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category_Ref = new SelectList(Ref_CategoryCrud.Select(), "Id", "CategoryName");
            return View();
        }
        #endregion

        #region [- Post -]
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Category_Ref, ProductName, UnitPrice, Discount, Quantity, ProductPhoto")] Product product, HttpPostedFileBase fileBase)
        {

            if (ModelState.IsValid)
            {
                if (fileBase != null)
                {
                    product.ProductPhoto = new byte[fileBase.ContentLength];
                    fileBase.InputStream.Read(product.ProductPhoto, 0, fileBase.ContentLength);
                    Ref_ProductCrud.Insert(product);
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Category_Ref = new SelectList(Ref_CategoryCrud.Select(), "Id", "CategoryName", product.Category_Ref);
            return View(product);
        }
        #endregion

        #endregion

        #region [- Details(int? id) -]
        [Route("{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ref_Product = Ref_ProductCrud.FindId(id);
            if (ref_Product == null)
            {
                return HttpNotFound();
            }
            return View(ref_Product);
        } 
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
            var product = Ref_ProductCrud.FindId(id);
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
            Ref_ProductCrud.Delete(id);
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
            var ref_Product = Ref_ProductCrud.FindId(id);
            if (ref_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Ref = new SelectList(Ref_CategoryCrud.Select(), "Id", "CategoryName");
            return View(ref_Product);
        }
        #endregion

        #region [- Post -]
        [Route("Edit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Category_Ref, ProductName, UnitPrice, Discount, Quantity, ProductPhoto")] Product ref_Product, HttpPostedFileBase fileBase)
        {
            if (ModelState.IsValid)
            {
                if (fileBase != null)
                {
                    ref_Product.ProductPhoto = new byte[fileBase.ContentLength];
                    fileBase.InputStream.Read(ref_Product.ProductPhoto, 0, fileBase.ContentLength);
                }
                Ref_ProductCrud.Update(ref_Product);
                return RedirectToAction("Index");
            }
            ViewBag.Category_Ref = new SelectList(Ref_CategoryCrud.Select(), "Id", "CategoryName", ref_Product.Category_Ref);
            return View(ref_Product);
        }  
        #endregion

        #endregion
        #endregion
    }
}