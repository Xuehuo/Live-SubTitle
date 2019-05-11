using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDI_SubTitle
{
    public class SubTitle
    {
        public int id;
        public string First_Sub;
        public string Second_Sub;
        public bool Has_Shown = false;
        public int alpha;

        public SubTitle(int _id, string _first, string _second, int _alpha = NDIRender.Alpha_Max)
        {
            id = _id;
            First_Sub = _first;
            Second_Sub = _second;
            alpha = _alpha; //max for alpha
        }
        public override string ToString()
        {
            return ToString(false);
        }
        public string ToString(bool double_line = false)
        {
            if (double_line)
                return $"{First_Sub} \n {Second_Sub}";
            return $"{id.ToString()} {First_Sub} {Second_Sub}";
        }

        public SubTitle Clone()
        {
            var _new = new SubTitle(id, First_Sub, Second_Sub);
            _new.Has_Shown = this.Has_Shown;
            _new.alpha = this.alpha;
            return _new;
        }

        private static SubTitle _empty;
        public static SubTitle Empty
        {
            get
            {
                if (_empty == null)
                    _empty = new SubTitle(-1, "", "");
                return _empty;
            }
        }
    }
}
