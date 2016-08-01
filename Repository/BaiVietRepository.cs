using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Repository
{
    public class BaiVietRepository : IRepository<BaiViet>
    {
        marworlddbEntities _baiVietContext;
        public BaiVietRepository()
        {
            _baiVietContext = new marworlddbEntities();
        }

        public IEnumerable<BaiViet> List
        {
            get
            {
                return _baiVietContext.BaiViets.OrderByDescending(r => r.id);
            }
        }

        public void Add(BaiViet entity)
        {
            _baiVietContext.BaiViets.Add(entity);
            try
            {
                _baiVietContext.SaveChanges();
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

        public void Delete(BaiViet entity)
        {
            _baiVietContext.BaiViets.Remove(entity);
            _baiVietContext.SaveChanges();
        }

        

        public BaiViet FindById(int Id)
        {
            var result = (from r in _baiVietContext.BaiViets where r.id == Id select r).FirstOrDefault();
            return result;
        }

        public void Update(BaiViet entity)
        {
            _baiVietContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _baiVietContext.SaveChanges();
        }
    }
}