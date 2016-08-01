using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Repository
{
    public class TaiLieuRepository : IRepository<Tailieu>
    {
        marworlddbEntities _tailieuContext;
        public TaiLieuRepository()
        {
            _tailieuContext = new marworlddbEntities();
        }
        public IEnumerable<Tailieu> List
        {
            get
            {
                return _tailieuContext.Tailieux;
            }
        }

        public void Add(Tailieu entity)
        {
            _tailieuContext.Tailieux.Add(entity);
            try
            {
                _tailieuContext.SaveChanges();
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

        public void Delete(Tailieu entity)
        {
            _tailieuContext.Tailieux.Remove(entity);
            _tailieuContext.SaveChanges();
        }

        public Tailieu FindById(int Id)
        {
            var result = (from r in _tailieuContext.Tailieux where r.id == Id select r).FirstOrDefault();
            return result;
        }

        public void Update(Tailieu entity)
        {
            _tailieuContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _tailieuContext.SaveChanges();
        }
    }
}