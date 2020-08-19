using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample01.Models.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Ref_ProductCrud = new DomainModels.POCO.ProductCrud();
            Ref_Product = new DomainModels.DTO.EF.Product();
            Ref_Category = new DomainModels.DTO.EF.Category();
        }

        public int ProductId
        {
            get { return Ref_Product.Id; }
            set { Ref_Product.Id = value; }
        }

        public int? CategoryId
        {
            get { return Ref_Product.Category_Ref; }
            set { Ref_Product.Category_Ref = value; }
        }

        public string Title
        {
            get { return Ref_Product.ProductName; }
            set { Ref_Product.ProductName = value; }
        }

        public decimal? UnitPrice
        {
            get { return Ref_Product.UnitPrice; }
            set { Ref_Product.UnitPrice = value; }
        }

        public decimal? Discount
        {
            get { return Ref_Product.Discount; }
            set { Ref_Product.Discount = value; }
        }

        public int? UnitsInStock
        {
            get { return Ref_Product.Quantity; }
            set { Ref_Product.Quantity = value; }
        }

        public byte[] ProductPhoto
        {
            get { return Ref_Product.ProductPhoto; }
            set { Ref_Product.ProductPhoto = value; }
        }

        public string CategoryName
        {
            get { return Ref_Category.CategoryName; }
            set { Ref_Category.CategoryName = value; }
        }


        private DomainModels.POCO.ProductCrud Ref_ProductCrud { get; set; }
        public DomainModels.DTO.EF.Product Ref_Product { get; set; }
        public DomainModels.DTO.EF.Category Ref_Category { get; set; }

        public List<ProductViewModel> GetProduct()
        {
            var productList = Ref_ProductCrud.Select();
            var productViewModelList = productList.Select(p => new ProductViewModel()
            {
                Title = p.ProductName,
                CategoryName = p.Category_Ref.ToString(),
                ProductPhoto = p.ProductPhoto,
                UnitPrice = p.UnitPrice,
                Discount = p.Discount,
                UnitsInStock = p.Quantity
            }).ToList();
            return productViewModelList;
        }

        internal void PostProduct(DomainModels.DTO.EF.Product ref_Product)
        {
            Ref_ProductCrud.Insert(ref_Product);
        }

        internal ViewModels.ProductViewModel GetProductById(int? id)
        {
            var product = Ref_ProductCrud.FindId(id);
            var productViewModel = new ProductViewModel()
            {
                Title = product.ProductName,
                UnitPrice = product.UnitPrice,
                Discount = product.Discount,
                UnitsInStock = product.Quantity,
                ProductPhoto = product.ProductPhoto,
                CategoryName = product.Category.CategoryName
            };
            return productViewModel;
        }

        internal void DeleteProduct(int id)
        {
            Ref_ProductCrud.Delete(id);
        }

        internal void PutProduct(DomainModels.DTO.EF.Product ref_Product)
        {
            Ref_ProductCrud.Update(ref_Product);
        }
    }
}