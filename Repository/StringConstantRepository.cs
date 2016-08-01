using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Repository
{
    public class StringConstantRepository : IRepository<StringConstant>
    {
        marworlddbEntities _stringconstantContext;
        public StringConstantRepository()
        {
            _stringconstantContext = new marworlddbEntities();
        }
        public IEnumerable<StringConstant> List
        {
            get
            {
                return _stringconstantContext.StringConstants;
            }
        }

        public void Add(StringConstant entity)
        {
            _stringconstantContext.StringConstants.Add(entity);
            try
            {
                _stringconstantContext.SaveChanges();
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

        public void Delete(StringConstant entity)
        {
            _stringconstantContext.StringConstants.Remove(entity);
            _stringconstantContext.SaveChanges();
        }

        public StringConstant FindById(int Id)
        {
            var result = (from r in _stringconstantContext.StringConstants where r.id == Id select r).FirstOrDefault();
            return result;
        }

        public void Update(StringConstant entity)
        {
            _stringconstantContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _stringconstantContext.SaveChanges();
        }
        public StringConstant FindByName(String name)
        {
            if (name == null)
            {
                return null;
            }
            var result = (from r in _stringconstantContext.StringConstants where name.Equals(r.name) select r).FirstOrDefault();
            
            return result;
        }
    }
}