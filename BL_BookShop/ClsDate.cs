//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace BL_BookShop
{
    class ClsDate
    {
        PersianCalendar P = new PersianCalendar();
        public string strN = "";

        public string Today()
        {
            string DATE;
            int Mounth = Convert.ToInt32(P.GetMonth(DateTime.Now).ToString());
            int Day = Convert.ToInt32(P.GetDayOfMonth(DateTime.Today).ToString());
            string mounth, day;

            if (Mounth < 10)
            {
                mounth = ("0" + Mounth.ToString()).ToString();
            }
            else
            {
                mounth = (Mounth.ToString()).ToString();
            }
            if (Day < 10)
            {
                day = ("0" + Day.ToString()).ToString();
            }
            else
            {
                day = (Day.ToString()).ToString();
            }
            DATE = P.GetYear(DateTime.Now).ToString() + '/' + mounth + '/' + day;
            return DATE;
        }

        public string TodayN()
        {
            string DATE;
            int Mounth = Convert.ToInt32(P.GetMonth(DateTime.Now).ToString());
            int Day = Convert.ToInt32(P.GetDayOfMonth(DateTime.Today).ToString());
            string mounth, day;

            if (Mounth < 10)
            {
                mounth = ("0" + Mounth.ToString()).ToString();
            }
            else
            {
                mounth = (Mounth.ToString()).ToString();
            }
            if (Day < 10)
            {
                day = ("0" + Day.ToString()).ToString();
            }
            else
            {
                day = (Day.ToString()).ToString();
            }
            strN = P.GetYear(DateTime.Now).ToString() + mounth + day;
            return strN;
        }

        public string FirstDate(string D, string M, string Y)
        {

            string MounthF, DayF, str1;
            int Dayf = Convert.ToInt32(D);

            int Mounthf = Convert.ToInt32(M);

            if (Dayf < 10)
            {
                DayF = "0" + D;
            }
            else
            {
                DayF = Dayf.ToString();
            }

            if (Mounthf < 10)
            {
                MounthF = "0" + M;
            }
            else
            {
                MounthF = Mounthf.ToString();
            }

            str1 = Y + "/" + MounthF + "/" + DayF;
            return str1;
        }
        public string GetDay()
        {
            string Day;
            Day = P.GetDayOfMonth(DateTime.Now).ToString();
            return Day;
        }
        public string GetMounth()
        {
            string Mounth;
            Mounth = P.GetMonth(DateTime.Now).ToString();
            return Mounth;
        }
        public string GetYear()
        {
            string year;
            year = P.GetYear(DateTime.Now).ToString();
            return year;
        }

    }
}