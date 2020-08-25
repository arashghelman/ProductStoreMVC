using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample01.Models.ViewModels
{
    public class ProductViewModel
    {
        #region [- ctor -]
        public ProductViewModel()
        {
            Ref_ProductCrud = new DomainModels.POCO.ProductCrud();
        }
        #endregion

        #region [- props -]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public int? UnitsInStock { get; set; }

        public byte[] ProductPhoto { get; set; }

        public Models.DomainModels.DTO.EF.Category Category { get; set; }
        private DomainModels.POCO.ProductCrud Ref_ProductCrud { get; set; }

        public List<ProductViewModel> ProductList { get { return GetProduct(); } }
        #endregion

        #region [- Methods -]

        #region [- GetProduct() -]
        internal List<ProductViewModel> GetProduct()
        {
            var productList = Ref_ProductCrud.Select();
            var productViewModelList = productList.Select(p => new ProductViewModel()
            {
                Title = p.ProductName,
                CategoryId = p.Category_Ref.Value,
                Category = p.Category,
                ProductPhoto = p.ProductPhoto,
                UnitPrice = p.UnitPrice,
                Discount = p.Discount,
                UnitsInStock = p.Quantity
            }).ToList();
            return productViewModelList;
        }
        #endregion

        #region [- PostProduct() -]
        internal void PostProduct()
        {
            DomainModels.DTO.EF.Product ref_Product = new DomainModels.DTO.EF.Product
            {
                Category_Ref = CategoryId,
                ProductName = Title,
                UnitPrice = UnitPrice,
                Discount = Discount,
                Quantity = UnitsInStock,
                ProductPhoto = ProductPhoto
            };
            Ref_ProductCrud.Insert(ref_Product);
        }
        #endregion

        #region [- GetProductById(int? id) -]
        internal ProductViewModel GetProductById(int? id)
        {
            var product = Ref_ProductCrud.FindId(id);
            ProductViewModel ref_ProductViewModel = new ProductViewModel()
            {
                ProductId = product.Id,
                Category = product.Category,
                Title = product.ProductName,
                UnitPrice = product.UnitPrice,
                Discount = product.Discount,
                UnitsInStock = product.Quantity,
                ProductPhoto = product.ProductPhoto
            };
            return ref_ProductViewModel;
        }
        #endregion

        #region [- DeleteProduct(int id) -]
        internal void DeleteProduct(int id)
        {
            Ref_ProductCrud.Delete(id);
        }
        #endregion

        #region [- PutProduct(DomainModels.DTO.EF.Product ref_Product) -]
        internal void PutProduct()
        {
            DomainModels.DTO.EF.Product ref_Product = new DomainModels.DTO.EF.Product()
            {
                Category_Ref = CategoryId,
                ProductName = Title,
                UnitPrice = UnitPrice,
                Discount = Discount,
                Quantity = UnitsInStock,
                ProductPhoto = ProductPhoto
            };
            Ref_ProductCrud.Update(ref_Product);
        }
        #endregion

        #region [- GetCategoryItems() -]
        internal dynamic GetCategoryItems()
        {
            var categoryItemsList = Ref_ProductCrud.SelectCategoryItems();
            return categoryItemsList;
        } 
        #endregion

        #endregion
    }
}