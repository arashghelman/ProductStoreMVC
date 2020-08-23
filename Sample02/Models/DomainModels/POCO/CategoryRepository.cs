using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.DomainModels.POCO
{
    public class CategoryRepository
    {

        #region [- ctor -]
        public CategoryRepository()
        {

        }
        #endregion

        #region [- Select() -]
        internal List<DTO.EF.Category> Select()
        {
            using (var context = new DTO.EF.ProductStoreEntities())
            {
                try
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    var categoryList = context.Category.ToList();
                    return categoryList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Insert(DTO.EF.Category ref_Category) -]
        internal void Insert(DTO.EF.Category ref_Category)
        {
            using (var context = new DTO.EF.ProductStoreEntities())
            {
                try
                {
                    context.Category.Add(ref_Category);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        } 
        #endregion
    }
}