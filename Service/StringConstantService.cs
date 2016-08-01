using MarworldNewWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarworldNewWeb
{
    public class StringConstantService
    {
        StringConstantRepository stringConstantRepository;
        public StringConstantService()
        {
            stringConstantRepository = new StringConstantRepository();
        }
        public void addStringConstant(String name, String value)
        {
            StringConstant st;
            st = stringConstantRepository.FindByName(name);
            if (st == null)
            {
                st = new StringConstant();
                st.name = name;
                st.value = value;
                stringConstantRepository.Add(st);
            }
            else
            {
                st.value = value;
                stringConstantRepository.Update(st);
            }
        }
        public String getValue(String name)
        {
            StringConstant st = stringConstantRepository.FindByName(name);
            if(st == null)
            {
                return "";
            }
            else
            {
                return st.value;
            }
        }
    }
}