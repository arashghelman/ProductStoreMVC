using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.ViewModels
{
    public class CategoryViewModel
    {

        #region [- ctor -]
        public CategoryViewModel()
        {
            Ref_CategoryRepository = new DomainModels.POCO.CategoryRepository();
        }
        #endregion


        #region [- model props -]
        public int Id { get; set; }
        public string Title { get; set; }
        #endregion

        #region [- class props -]
        public DomainModels.POCO.CategoryRepository Ref_CategoryRepository { get; set; }
        public DomainModels.DTO.EF.Category Ref_Category { get; set; }
        #endregion

        public List<CategoryViewModel> GetCategory()
        {
            var categoryList = Ref_CategoryRepository.Select();
            var categoryViewModelList = categoryList.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Title = c.CategoryName
            }).ToList();
            return categoryViewModelList;
        }

        #region [- PostCategory(DomainModels.DTO.EF.Category ref_Category) -]
        internal void PostCategory(DomainModels.DTO.EF.Category ref_Category)
        {
            ref_Category = new DomainModels.DTO.EF.Category()
            {
                CategoryName = Title
            };
            Ref_CategoryRepository.Insert(ref_Category);
        } 
        #endregion
    }
}