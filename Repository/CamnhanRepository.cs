using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Repository
{
    public class CamnhanRepository : IRepository<Camnhan>
    {

        marworlddbEntities _camnhanContext;
        public CamnhanRepository()
        {
            _camnhanContext = new marworlddbEntities();
        }
        public IEnumerable<Camnhan> List
        {
            get
            {
                return _camnhanContext.Camnhans;
            }
        }

        public void Add(Camnhan entity)
        {
            _camnhanContext.Camnhans.Add(entity);
            try
            {
                _camnhanContext.SaveChanges();
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

        public void Delete(Camnhan entity)
        {
            _camnhanContext.Camnhans.Remove(entity);
            _camnhanContext.SaveChanges();
        }

        public Camnhan FindById(int Id)
        {
            var result = (from r in _camnhanContext.Camnhans where r.id == Id select r).FirstOrDefault();
            return result;
        }

        public void Update(Camnhan entity)
        {
            _camnhanContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _camnhanContext.SaveChanges();
        }
    }
}