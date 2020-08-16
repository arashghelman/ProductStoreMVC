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
        public List<DomainModels.DTO.EF.Category> GetCategory()
        {
            var categoryList = Ref_CategoryCrud.Select();
            return categoryList;
        }
        #endregion

        #region [- PostCategory(DomainModels.DTO.EF.Category ref_Category) -]
        internal void PostCategory(DomainModels.DTO.EF.Category ref_Category)
        {
            Ref_CategoryCrud.Insert(ref_Category);
        }
        #endregion

        #region [- GetCategoryById(int? id) -]
        public CategoryViewModel GetCategoryById(int? id)
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

        internal void PutCategory(ViewModels.CategoryViewModel categoryViewModel)
        {
            Models.DomainModels.DTO.EF.Category category = new DomainModels.DTO.EF.Category();
            category.Id = categoryViewModel.CategoryId;
            category.CategoryName = categoryViewModel.Title;
            Ref_CategoryCrud.Update(category);
        }

        internal void DeleteCategory(int id)
        {
            Ref_CategoryCrud.Delete(id);
        }
    }
}