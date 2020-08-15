using Sample01.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample01.Models.DomainModels.POCO
{
    public class CategoryCrud
    {
        #region [- ctor -]
        public CategoryCrud()
        {

        }
        #endregion

        #region [- Select() -]
        public List<Category> Select()
        {
            using (var context = new ProductStoreEntities())
            {
                try
                {
                    var categoryList = context.Category.ToList();
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

        #region [- Insert(Category ref_Category) -]
        public void Insert(Category ref_Category)
        {
            using (var context = new ProductStoreEntities())
            {
                try
                {
                    context.Category.Add(ref_Category);
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

        #region [- Update(Category ref_Category) -]
        public void Update(Category ref_Category)
        {
            using (var context = new ProductStoreEntities())
            {
                try
                {
                    context.Entry(ref_Category).State = System.Data.Entity.EntityState.Modified;
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
                    //context.Category.Remove(FindId(id));
                    //context.SaveChanges();
                    var ref_Category = new Category { Id = id };
                    context.Category.Attach(ref_Category);
                    context.Entry(ref_Category).State = System.Data.Entity.EntityState.Deleted;
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
        public Category FindId(int? id)
        {
            using (var context = new ProductStoreEntities())
            {
                try
                {
                    var ref_Category = context.Category.Find(id);
                    return ref_Category;
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