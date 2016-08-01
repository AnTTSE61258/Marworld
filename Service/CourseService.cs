using MarworldNewWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Service
{
    public class CourseService
    {
        CourseRepository _courseRepository;
        public CourseService()
        {
            _courseRepository = new CourseRepository();
        }
        public List<Course> getAll()
        {
            return _courseRepository.List.ToList();
        }

        public List<Course> getShowedCourse()
        {
            return _courseRepository.getShowedCourse();
        }

        public void addCourse(String name, String picture, int lithuyet, int caseStudy, int workshop, String address, 
            int thoiluong, DateTime khaigiang, double hocphi, String thoigianhoc, DateTime handangki, String noidung, String doituong,String ghichu, String gioithieu,bool isShowed)
           
        {
            Course c = findByName(name);
            if (c == null)
            {
                c = new Course();
                c.name = name;
                c.picture = picture;
                c.lithuyet = lithuyet;
                c.casestudy = caseStudy;
                c.workshop = workshop;
                c.address = address;
                c.thoiluong = thoiluong;
                c.khaigiang = khaigiang;
                c.hocphi = hocphi;
                c.thoigianhoc = thoigianhoc;
                c.handangki = handangki;
                c.noichung = noidung;
                c.doituong = doituong;
                c.ghichu = ghichu;
                c.gioithieu = gioithieu;
                c.showOnSlider = isShowed;
                _courseRepository.Add(c);
            }
            else
            {
                c.name = name;
                if (picture!=null && !picture.Equals(""))
                {
                    c.picture = picture;
                }
                c.lithuyet = lithuyet;
                c.casestudy = caseStudy;
                c.workshop = workshop;
                c.address = address;
                c.thoiluong = thoiluong;
                c.khaigiang = khaigiang;
                c.hocphi = hocphi;
                c.thoigianhoc = thoigianhoc;
                c.handangki = handangki;
                c.noichung = noidung;
                c.doituong = doituong;
                c.ghichu = ghichu;
                c.gioithieu = gioithieu;
                c.showOnSlider = isShowed;
                _courseRepository.Update(c);
            }
           
        }
        public void deleteCourse(Course c)
        {
            _courseRepository.Delete(c);
        }
        public Course findByName(String name)
        {
            return _courseRepository.FindByName(name);
        }
        public Course findById(int id)
        {
            return _courseRepository.FindById(id);
        }
    }
}