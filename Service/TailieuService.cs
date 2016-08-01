using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarworldNewWeb.Repository;
namespace MarworldNewWeb.Service
{
    public class TailieuService
    {
        TaiLieuRepository _tailieuRepository = new TaiLieuRepository();
        public List<Tailieu> getAll()
        {
            return _tailieuRepository.List.ToList();
        } 
        public void addTailieu(int id, String name, String authorName, String company, String loimodau, String gioithieu, String fileUrl, String pictureUrl, String noidung, String category, String authorURL)
        {
            Tailieu t = findById(id);
            Boolean isExist = true;
            if (t == null)
            {
                isExist = false;
                t = new Tailieu();
            }
            t.name = name;
            t.authorname = authorName;
            t.company = company;
            t.loimodau = loimodau;
            t.gioithieuchung = gioithieu;
            if(fileUrl!=null && !fileUrl.Equals(""))
            {
                t.fileURL = fileUrl;
            }
            if(pictureUrl!=null && !pictureUrl.Equals(""))
            {
                t.imageUrl = pictureUrl;
            }
            if(authorURL!=null && !authorURL.Equals(""))
            {
                t.authorURL = authorURL;
            }
            t.category = category;
            t.noidung = noidung;
            if (isExist)
            {
                _tailieuRepository.Update(t);
            }
            else
            {
                _tailieuRepository.Add(t);
            }
        } 

        public void delete(Tailieu t)
        {
            _tailieuRepository.Delete(t);
        }
        public Tailieu findById(int id)
        {
            return _tailieuRepository.FindById(id);
        }
    }
}