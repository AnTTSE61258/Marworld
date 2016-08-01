using MarworldNewWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb.Service
{
    public class CamnhanService
    {
        CamnhanRepository camnhanRepository = new CamnhanRepository();
        public List<Camnhan> getAll()
        {
            return camnhanRepository.List.ToList();
        }
        public void addCamnhan(int id,String name, String camnhan, String doituong)
        {
            Camnhan c;
            c = findByid(id);
            if (c == null)
            {
                c = new Camnhan();
                c.name = name;
                c.camnhan1 = camnhan;
                c.doituong = doituong;
                camnhanRepository.Add(c);
            }
            else
            {
                c.name = name;
                c.camnhan1 = camnhan;
                c.doituong = doituong;
                camnhanRepository.Update(c);
            }
        }
        public void delete(Camnhan c)
        {
            camnhanRepository.Delete(c);
        }
        public Camnhan findByid(int id)
        {
            if (id < 0)
            {
                return null;

            }
            Camnhan c = camnhanRepository.FindById(id);
            return c;
        }
    }
}