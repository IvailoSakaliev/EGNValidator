using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckEGN
{
    public class CheckAlgo
    {
        public int _year { get; set; }
        public int _year_for_check_leep { get; set; }
        public int _month { get; set; }
        public int _month_for_check { get; set; }
        public int _day { get; set; }
        public int _region { get; set; }
        public int _control_sum { get; set; }
        public string _enter_egn { get; set; }




        private int[] check_weight = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        private int[] month_number_of_days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public CheckAlgo(string eng)
        {
            _year = int.Parse(eng.Substring(0, 2));
            _month = int.Parse(eng.Substring(2, 2));
            _day = int.Parse(eng.Substring(4, 2));
            _region = int.Parse(eng.Substring(6, 3));
            _control_sum = int.Parse(eng[9].ToString());
            _enter_egn = eng;
        }
        public bool EGN()
        {
            bool is_ok = false;
            is_ok = Mont();
            if (is_ok )
            {
                Leap_year();
                is_ok = CheckDate();
                if (is_ok)
                {
                    is_ok = CheckControlSum();
                }
            }
            return is_ok;
        }

        private void Leap_year()
        {
            if (DateTime.IsLeapYear(_year_for_check_leep))
            {
                month_number_of_days[1] = 29;
            }
        }

        private bool CheckDate()
        {
            if (_day > 0 && _day <= month_number_of_days[_month_for_check - 1])
            {
                return true;
            }
            return false;
        }

        private bool CheckControlSum()
        {
            int _check = 0;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(_enter_egn[i].ToString()) * check_weight[i];
            }
            _check = sum % 11;
            if (_check == 10)
            {
                _check = 0;
            }
            if (_control_sum == _check)
            {
                return true;
            }
            return false;
        }

        private bool Mont()
        {
            if (_month > 40)
            {
                if(_month - 40 > 12)
                {
                    return false;
                }
                _month_for_check = _month-40;
                _year_for_check_leep = _year + 2000;
            }
            else if (_month > 20)
            {
                if (_month - 20 > 12)
                {
                    return false;
                }
                _month_for_check = _month-20;
                _year_for_check_leep = _year + 1800;
            }
            else
            {
                if (_month > 12)
                {
                    return false;
                }
                _month_for_check = _month;
               _year_for_check_leep = _year + 1900;

            }
            return true;
        }
    }
}