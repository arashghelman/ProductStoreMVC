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
        internal void PostCategory(CategoryViewModel ref_CategoryViewModel)
        {
            Ref_Category = new DomainModels.DTO.EF.Category()
            {
                CategoryName = ref_CategoryViewModel.Title
            };
            Ref_CategoryRepository.Insert(Ref_Category);
        }
        #endregion

        #region [- DeleteCategory(CategoryViewModel ref_CategoryViewModel) -]
        internal void DeleteCategory(CategoryViewModel ref_CategoryViewModel)
        {
            Ref_Category = new DomainModels.DTO.EF.Category()
            {
                Id = ref_CategoryViewModel.Id
            };
            Ref_CategoryRepository.Delete(Ref_Category.Id);
        }
        #endregion

        #region [- PutCategory(CategoryViewModel ref_CategoryViewModel) -]
        internal void PutCategory(CategoryViewModel ref_CategoryViewModel)
        {
            Ref_Category = new DomainModels.DTO.EF.Category()
            {
                Id = ref_CategoryViewModel.Id,
                CategoryName = ref_CategoryViewModel.Title
            };

            Ref_CategoryRepository.Update(Ref_Category);
        } 
        #endregion

    }
}