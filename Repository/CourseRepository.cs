using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Repository
{
    public class CourseRepository : IRepository<Course>
    {
        marworlddbEntities _courseContext;

        public CourseRepository()
        {
            _courseContext = new marworlddbEntities();
        }
        public IEnumerable<Course> List
        {
            get
            {
                return _courseContext.Courses;
            }
        }

        public void Add(Course entity)
        {
            _courseContext.Courses.Add(entity);
            try
            {
                _courseContext.SaveChanges();
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

        public void Delete(Course entity)
        {
            _courseContext.Courses.Remove(entity);
            _courseContext.SaveChanges();
        }

        public Course FindById(int Id)
        {
            var result = (from r in _courseContext.Courses where r.id == Id select r).FirstOrDefault();
            return result;
        }
        public Course FindByName(String name)
        {
            if (name == null)
            {
                return null;
            }
            var result = (from r in _courseContext.Courses where name.Equals(r.name) select r).FirstOrDefault();
            return result;
        }

        public void Update(Course entity)
        {
            _courseContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _courseContext.SaveChanges();
        }
        public List<Course> getShowedCourse()
        {
            var result = (from r in _courseContext.Courses where r.showOnSlider == true select r).ToList();
            return result;
        }
    }
}