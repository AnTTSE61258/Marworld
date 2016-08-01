using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Repository
{
    public class CustomImageRepository : IRepository<CustomImage>
    {
        marworlddbEntities _customImageContext;
        public CustomImageRepository()
        {
            _customImageContext = new marworlddbEntities();
        }

        public IEnumerable<CustomImage> List
        {
            get
            {
                return _customImageContext.CustomImages;
            }
        }

        public void Add(CustomImage entity)
        {
            _customImageContext.CustomImages.Add(entity);
            try
            {
                _customImageContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public void Delete(CustomImage entity)
        {
            _customImageContext.CustomImages.Remove(entity);
            _customImageContext.SaveChanges();
        }

        public CustomImage FindById(int Id)
        {
            var result = (from r in _customImageContext.CustomImages where r.id == Id select r).FirstOrDefault();
            return result;
        }

        public void Update(CustomImage entity)
        {
            _customImageContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _customImageContext.SaveChanges();
        }
    }
}