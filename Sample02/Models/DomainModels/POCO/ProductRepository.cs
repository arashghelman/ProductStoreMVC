using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Sample02.Models.DomainModels.POCO
{
    public class ProductRepository
    {
        #region [- ctor -]
        public ProductRepository()
        {

        }
        #endregion

        #region [- Select() -]
        public List<DTO.EF.Product> Select()
        {
            using (var context = new DTO.EF.ProductStoreEntities())
            {
                try
                {
                    var productList = context.Product.Include(p => p.Category).ToList();
                    return productList;
                }
                catch (Exception)
                {
                    throw;
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

        #region [- SelectCategoryItems() -]
        public dynamic SelectCategoryItems()
        {
            using (var context = new DTO.EF.ProductStoreEntities())
            {
                try
                {
                    var categoryList = context.Category.Select(c => new { c.Id, c.CategoryName }).ToList();
                    return categoryList;
                }
                catch (Exception)
                {
                    throw;
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

        public void Insert(DTO.EF.Product ref_Product)
        {
            using (var context = new DTO.EF.ProductStoreEntities())
            {
                try
                {
                    context.Product.Add(ref_Product);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
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
    }
}