using MarworldNewWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Service
{
    public class CustomImageService
    {
        CustomImageRepository _customImageRepository = new CustomImageRepository();
        public void AddCustomImage(int id,String category, String imageURL)
        {
            CustomImage c;
            c = findById(id);
            if (c == null)
            {
                c = new CustomImage();
                c.imageCategory = category;
                c.imageURL = imageURL;
                _customImageRepository.Add(c);
            }
            else
            {
                c.imageCategory = category;
                c.imageURL = imageURL;
                _customImageRepository.Update(c);
            }
        }
        public List<CustomImage> getAllCustomImageWithCategory(String category)
        {
            List<CustomImage> baseList = getAll();
            for(int i = baseList.Count - 1; i >= 0; i--)
            {
                CustomImage c = baseList.ElementAt(i);
                if (!c.imageCategory.Equals(category))
                {
                    baseList.RemoveAt(i);
                }

            }
            return baseList;
        }
        public List<CustomImage> getAll()
        {
            return _customImageRepository.List.ToList();
        }
        public CustomImage findById(int id)
        {
            return _customImageRepository.FindById(id);
        }
        public void delete(CustomImage c)
        {
            _customImageRepository.Delete(c);
        }
    }
}