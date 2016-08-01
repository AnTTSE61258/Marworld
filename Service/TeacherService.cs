using MarworldNewWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Service
{
    public class TeacherService
    {
        TeacherRepository _teacherRepository;
        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();
        }
        public Teacher findById(int id)
        {
            return _teacherRepository.FindById(id);
        }
        public List<Teacher> getAll()
        {
            return _teacherRepository.List.ToList();
        }
        public List<Teacher> getRandom()
        {
            List<Teacher> allTeacher = getAll();
            List<Teacher> result = new List<Teacher>();
            Random rd = new Random();
            for(int i = 0; i < 3; i++)
            {
                if (allTeacher != null && allTeacher.Count > 0)
                {
                    int position = rd.Next(0, allTeacher.Count);
                    result.Add(allTeacher.ElementAt(position));
                    allTeacher.RemoveAt(position);
                }
            }
            return result;

        }


        public void deteleTeacher(Teacher t)
        {
            _teacherRepository.Delete(t);
        }
            public void addTeacher(int id, String name, String congty, String picture, String caunoi, String gioithieu)
        {
            Teacher c = null;
            c = _teacherRepository.FindById(id);
            if (c == null)
            {
                c = new Teacher();
                c.name = name;
                c.congty = congty;
                c.picture = picture;
                c.caunoi = caunoi;
                c.gioithieu = gioithieu;
                _teacherRepository.Add(c);
            }
            else
            {
                c.name = name;
                c.congty = congty;
                if (!picture.Equals(""))
                {
                    c.picture = picture;

                }
                c.caunoi = caunoi;
                c.gioithieu = gioithieu;
                _teacherRepository.Update(c);
            }
        }
    }
}