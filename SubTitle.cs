using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ndi_SubTitle
{
    public class SubTitle
    {
        public int id;
        public string First_Sub;
        public string Second_Sub;
        public bool Has_Shown = false;

        public SubTitle(int _id, string _first, string _second)
        {
            id = _id;
            First_Sub = _first;
            Second_Sub = _second;
        }
        public override string ToString()
        {
            return ToString(false);
        }
        public string ToString(bool double_line = false)
        {
            if (double_line)
                return First_Sub + "\n" + Second_Sub;
            return id.ToString() + " " + First_Sub + " " + Second_Sub;
        }
        public int Set_Shown()
        {
            Has_Shown = true;
            return id;
        }
        public bool HasShown() => Has_Shown;

        public SubTitle Clone()
        {
            var _new = new SubTitle(id, First_Sub, Second_Sub);
            _new.Has_Shown = this.Has_Shown;
            return _new;
        }
    }
}
