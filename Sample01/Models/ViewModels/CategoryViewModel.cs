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
        private DomainModels.DTO.EF.Category Ref_Category { get; set; }
        #endregion

        #region [- props for Model -]
        public int CategoryId
        {
            get { return Ref_Category.Id; }
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
    }
}