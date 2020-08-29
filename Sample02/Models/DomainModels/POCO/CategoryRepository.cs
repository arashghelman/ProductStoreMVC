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

        #region [- Delete(int id) -]
        public void Delete(int id)
        {
            using (var context = new DTO.EF.ProductStoreEntities())
            {
                try
                {
                    var ref_Category = new DTO.EF.Category { Id = id };
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

        #region [- Update(DTO.EF.Category ref_Category) -]
        public void Update(DTO.EF.Category ref_Category)
        {
            using (var context = new DTO.EF.ProductStoreEntities())
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
    }
}