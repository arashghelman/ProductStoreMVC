using Sample01.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Sample01.Models.DomainModels.POCO
{
    public class ProductCrud
    {
        #region [- ctor -]
        public ProductCrud()
        {

        }
        #endregion

        #region [- Select() -]
        public List<Product> Select()
        {
            using (var context = new ProductStoreEntities())
            {
                try
                {
                    var productList = context.Product.Include(p => p.Category);
                    return productList.ToList();
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

        #region [- Insert(Product ref_Product) -]
        public void Insert(Product ref_Product)
        {
            using (var context = new ProductStoreEntities())
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
        #endregion

        #region [- Delete(int id) -]
        public void Delete(int id)
        {
            using (var context = new ProductStoreEntities())
            {
                try
                {
                    var ref_Product = new Product { Id = id };
                    context.Product.Attach(ref_Product);
                    context.Entry(ref_Product).State = EntityState.Deleted;
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
        #endregion

        #region [- Update(Product ref_Product) -]
        public void Update(Product ref_Product)
        {
            using (var context = new ProductStoreEntities())
            {
                try
                {
                    context.Entry(ref_Product).State = EntityState.Modified;
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
        #endregion

        #region [- FindId(int? id) -]
        public Product FindId(int? id)
        {
            using (var context = new ProductStoreEntities())
            {
                try
                {
                    var product = context.Product.Find(id);
                    int categoryId = product.Category.Id;
                    return product;
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
            using (var context = new ProductStoreEntities())
            {
                try
                {
                    var categoryItemsList = context.Category.Select(c => new { c.Id, c.CategoryName }).ToList();
                    return categoryItemsList;
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

    }
}