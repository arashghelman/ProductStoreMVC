using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample01.Models.ViewModels
{
    public class CategoryViewModel
    {
        #region [- ctor -]
        public CategoryViewModel()
        {
            Ref_CategoryCrud = new DomainModels.POCO.CategoryCrud();
            Ref_Category = new DomainModels.DTO.EF.Category();
        }
        #endregion

        #region [- props -]
        private DomainModels.POCO.CategoryCrud Ref_CategoryCrud { get; set; }
        internal DomainModels.DTO.EF.Category Ref_Category { get; set; }
        #endregion

        #region [- props for Model -]
        public int CategoryId
        {
            get { return Ref_Category.Id; }
            set { Ref_Category.Id = value; }
        }

        public string Title
        {
            get { return Ref_Category.CategoryName; }
            set { Ref_Category.CategoryName = value; }
        }
        #endregion

        #region [- GetCategory() -]
        public List<CategoryViewModel> GetCategory()
        {
            var categoryList = Ref_CategoryCrud.Select();
            var categoryViewModelList = categoryList.Select(c => new CategoryViewModel()
            {
                CategoryId = c.Id,
                Title = c.CategoryName
            }).ToList();
            return categoryViewModelList;
        }
        #endregion

        #region [- PostCategory(DomainModels.DTO.EF.Category ref_Category) -]
        internal void PostCategory(DomainModels.DTO.EF.Category ref_Category)
        {
            Ref_CategoryCrud.Insert(ref_Category);
        }
        #endregion

        #region [- GetCategoryById(int? id) -]
        internal CategoryViewModel GetCategoryById(int? id)
        {
            var category = Ref_CategoryCrud.FindId(id);
            CategoryViewModel ref_CategoryViewModel = new CategoryViewModel()
            {
                CategoryId = category.Id,
                Title = category.CategoryName
            };
            return ref_CategoryViewModel;
        }
        #endregion

        #region [- PutCategory(ViewModels.CategoryViewModel categoryViewModel) -]
        internal void PutCategory(DomainModels.DTO.EF.Category ref_Category)
        {
            Ref_CategoryCrud.Update(ref_Category);
        }
        #endregion

        #region [- DeleteCategory(int id) -]
        internal void DeleteCategory(int id)
        {
            Ref_CategoryCrud.Delete(id);
        } 
        #endregion
    }
}