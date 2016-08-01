using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Repository
{
    public class TeacherRepository:IRepository<Teacher>
    {
        marworlddbEntities _teacherContext;
        public TeacherRepository()
        {
            _teacherContext = new marworlddbEntities();
        }

        public IEnumerable<Teacher> List
        {
            get
            {
                return _teacherContext.Teachers;
                    }
        }

        public void Add(Teacher entity)
        {
            _teacherContext.Teachers.Add(entity);
            try
            {
                _teacherContext.SaveChanges();
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

        public void Delete(Teacher entity)
        {
            _teacherContext.Teachers.Remove(entity);
            _teacherContext.SaveChanges();
        }

        public Teacher FindById(int Id)
        {
            var result = (from r in _teacherContext.Teachers where r.id == Id select r).FirstOrDefault();
            return result;
        }
        public Teacher FindByName(String name)
        {
            if (name == null)
            {
                return null;
            }
            var result = (from r in _teacherContext.Teachers where name.Equals(r.name) select r).FirstOrDefault();
            return result;
        }

        public void Update(Teacher entity)
        {
            _teacherContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _teacherContext.SaveChanges();
        }
    }
}