using MarworldNewWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Service
{
    public class BaiVietService
    {

        BaiVietRepository _baiVietRepository = new BaiVietRepository();

        public void delete(BaiViet b)
        {
            _baiVietRepository.Delete(b);
        }
        public List<BaiViet> getAll()
        {
            
            return _baiVietRepository.List.ToList();
        }
        public BaiViet findById(int id)
        {
            return _baiVietRepository.FindById(id);
        }

        public void addBaiViet(int id, String title, String image, String description, String category, String detail)
        {
            BaiViet b = findById(id);
            if (b == null)
            {
                b = new BaiViet();
                b.title = title;
                b.image = image;
                b.description = description;
                b.category = category;
                b.detail = detail;             
                _baiVietRepository.Add(b);
            }
            else
            {
                b.title = title;
                if (image != null && !image.Equals(""))
                {
                    b.image = image;
                }
                b.description = description;
                b.category = category;
                b.detail = detail;
                _baiVietRepository.Update(b);
            }

        }
    }
}