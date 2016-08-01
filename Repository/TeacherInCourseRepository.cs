using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Repository
{
    public class TeacherInCourseRepository : IRepository<TeacherInCourse>
    {
        marworlddbEntities _teacherInCourseContext;
        public TeacherInCourseRepository()
        {
            _teacherInCourseContext = new marworlddbEntities();
        }

        public IEnumerable<TeacherInCourse> List
        {
            get
            {
                return _teacherInCourseContext.TeacherInCourses.OrderByDescending(r => r.id);
            }
        }

        public void Add(TeacherInCourse entity)
        {
            _teacherInCourseContext.TeacherInCourses.Add(entity);
            try
            {
                _teacherInCourseContext.SaveChanges();
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

        public void Delete(TeacherInCourse entity)
        {
            _teacherInCourseContext.TeacherInCourses.Remove(entity);
            _teacherInCourseContext.SaveChanges();
        }

        public TeacherInCourse FindById(int Id)
        {
            var result = (from r in _teacherInCourseContext.TeacherInCourses where r.id == Id select r).FirstOrDefault();
            return result;
        }
        public TeacherInCourse FindByTeacherInCourse(int courseid, int teacherid)
        {
            var result = (from r in _teacherInCourseContext.TeacherInCourses
                          where r.courseId == courseid && r.teacherid == teacherid  select r).FirstOrDefault();
            return result;
        }


        public void Update(TeacherInCourse entity)
        {
            _teacherInCourseContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _teacherInCourseContext.SaveChanges();
        }
    }
}