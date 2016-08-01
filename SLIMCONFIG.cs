using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace MarworldNewWeb
{
    public class SLIMCONFIG
    {
        public static string path = "~/Images/";
        //  Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string category_tintuccongdong = "text_tintuccongdong";
        public static string category_baivietchuyengia = "text_baivietchuyengia";
        public static string category_tieudiemchuyennganh = "text_tieudiemchuyennganh";
        public static string category_sukien = "text_sukien_sukien";

        public static string text_khampha = "text_khampha";
        public static string text_giangvienchuyengia = "text_giangvienchuyengia";
        public static string text_vechungtoi = "text_vechungtoi";
        public static string text_taisaolaichon = "text_taisaolaichon";
        public static string text_tamnhinsumenh = "text_tamnhinsumenh";
        public static string text_giaotrinhthuctien = "text_giaotrinhthuctien";
        public static string text_baitapungdung = "text_baitapungdung";
        public static string text_linhhoatsangtao = "text_linhhoatsangtao";
        public static string text_chuongtrinhdaotaodoanhnghiep = "text_chuongtrinhdaotaodoanhnghiep";
        public static string text_phantichkhaosat = "text_phantichkhaosat";
        public static string text_tuvangiaiphap = "text_tuvangiaiphap";
        public static string text_danhgiaketqua = "text_danhgiaketqua";
        public static string text_chuongtrinhtuvandoanhnghiep = "text_chuongtrinhtuvandoanhnghiep";
        public static string select_sinhvien = "select_sinhvien";
        public static string select_doanhnghiep = "select_doanhnghiep";
        public static string text_giaotrinhchuyenbiet = "text_giaotrinhchuyenbiet";
        public static string text_cohoinghenghiep = "text_cohoinghenghiep";
        public static string text_sukiennoibat = "text_sukiennoibat";
        public static string customImage_category_camnhan = "customImage_category_camnhan";
        public static string customImage_background = "customImage_background";
        public static string tailieu_text = "tailieu_text";
        public static string tailieu_category_thuonghieu = "thuonghieu_category";
        public static string tailieu_category_marketing = "marketing_category";
        public static string convertToCurrency(String a)
        {
            StringBuilder result = new StringBuilder();
            int test = 0;
           for(int i = a.Length - 1; i >= 0; i--)
            {
                Char c = a.ElementAt(i);
                if (test != 0 && (test % 3 == 0))
                {
                    result.Insert(0, ",");

                }
                result.Insert(0, c);
                test++;
            }
            return result.ToString();
        }
    }

}