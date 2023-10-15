using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_LAB2
{
    public class Validator
    {
        static public bool Is_Letter(string target)
        {
            if (int.TryParse(target, out var a))
            {
                return true;
            }
            return false;
        }
        static public bool In_Interval(int start, int finish, string target)
        {
            if (Is_Letter(target))
            {
                int _target = int.Parse(target);
                if (_target < start || _target > finish)
                {
                    return false;
                }

                return true;
            }
            return false;
        }
    }
}
