using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.ViewModels
{
    public class ProductViewModel
    {
        #region [- ctor -]
        internal ProductViewModel()
        {
            Ref_ProductRepository = new DomainModels.POCO.ProductRepository();
        }
        #endregion

        #region [- props for class -]
        private DomainModels.POCO.ProductRepository Ref_ProductRepository { get; set; }
        private DomainModels.DTO.EF.Product Ref_Product { get; set; }
        #endregion

        #region [- props for model -]
        public int Id { get; set; }
        public int CategoryRef { get; set; }
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public byte[] ProductPhoto { get; set; }
        public DomainModels.DTO.EF.Category Ref_Category { get; set; }
        public List<ProductViewModel> ProductList { get { return GetProduct(); } }
        #endregion

        #region [- GetProduct() -]
        internal List<ProductViewModel> GetProduct()
        {
            var productList = Ref_ProductRepository.Select();
            var productViewModelList = productList.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                CategoryRef = p.Category_Ref.Value,
                Ref_Category = p.Category,
                Title = p.ProductName,
                UnitPrice = p.UnitPrice.Value,
                Discount = p.Discount.Value,
                Quantity = p.Quantity.Value,
                ProductPhoto = p.ProductPhoto
            }).ToList();
            return productViewModelList;
        } 
        #endregion

        #region [- GetCategoryItems() -]
        public dynamic GetCategoryItems()
        {
            var categoryList = Ref_ProductRepository.SelectCategoryItems();
            return categoryList;
        }
        #endregion

        #region [- PostProduct(ProductViewModel ref_ProductViewModel) -]
        public void PostProduct(ProductViewModel ref_ProductViewModel)
        {
            Ref_Product = new DomainModels.DTO.EF.Product()
            {
                Category_Ref = ref_ProductViewModel.CategoryRef,
                ProductName = ref_ProductViewModel.Title,
                UnitPrice = ref_ProductViewModel.UnitPrice,
                Discount = ref_ProductViewModel.Discount,
                Quantity = ref_ProductViewModel.Quantity,
                ProductPhoto = ref_ProductViewModel.ProductPhoto
            };

            Ref_ProductRepository.Insert(Ref_Product);
        } 
        #endregion

        #region [- DeleteProduct(ProductViewModel ref_ProductViewModel) -]
        public void DeleteProduct(ProductViewModel ref_ProductViewModel)
        {
            Ref_Product = new DomainModels.DTO.EF.Product()
            {
                Id = ref_ProductViewModel.Id
            };

            Ref_ProductRepository.Delete(Ref_Product.Id);
        }
        #endregion

        #region [- PutProduct(ProductViewModel ref_ProductViewModel) -]
        public void PutProduct(ProductViewModel ref_ProductViewModel)
        {
            Ref_Product = new DomainModels.DTO.EF.Product()
            {
                Id = ref_ProductViewModel.Id,
                Category_Ref = ref_ProductViewModel.CategoryRef,
                ProductName = ref_ProductViewModel.Title,
                UnitPrice = ref_ProductViewModel.UnitPrice,
                Discount = ref_ProductViewModel.Discount,
                Quantity = ref_ProductViewModel.Quantity,
                ProductPhoto = ref_ProductViewModel.ProductPhoto
            };

            Ref_ProductRepository.Update(Ref_Product);
        } 
        #endregion

    }
}