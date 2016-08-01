using MarworldNewWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Service
{
    public class TeacherInCourseService
    {
        TeacherInCourseRepository _teacherInCourseRepository = new TeacherInCourseRepository();
        TeacherService _teacherService = new TeacherService();
        public void add(int teacher, int course)
        {
            TeacherInCourse tic = new TeacherInCourse();
            tic.teacherid = teacher;
            tic.courseId = course;
            _teacherInCourseRepository.Add(tic);
        }
        
        public void deleteByTeacherInCourse(int courseid, int teacherid)
        {
            TeacherInCourse tic = findByTeacherInCourse(courseid, teacherid);
            if (tic != null)
            {
                _teacherInCourseRepository.Delete(tic);
            }
        }
        public TeacherInCourse findByTeacherInCourse(int courseid, int teacherid)
        {
            return _teacherInCourseRepository.FindByTeacherInCourse(courseid, teacherid);
        }

        public List<Teacher> listTeacher(int course)
        {
            List<TeacherInCourse> allTeacherInCourse = getAll();
            List<Teacher> teacherResult = new List<Teacher>();
            foreach(TeacherInCourse tnc in allTeacherInCourse)
            {
                if (tnc.teacherid != null && tnc.courseId == course)
                {
                    Teacher t = _teacherService.findById(tnc.teacherid.Value);
                    if (t != null)
                    {
                        teacherResult.Add(t);
                    }
                }
               
            }
            return teacherResult;

        }
        public List<TeacherInCourse> getAll()
        {
            return _teacherInCourseRepository.List.ToList();
        }
        public TeacherInCourse findById(int id)
        {
            return _teacherInCourseRepository.FindById(id);
        }
    }

}