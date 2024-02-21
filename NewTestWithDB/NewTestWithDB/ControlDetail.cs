using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTestWithDB
{
    [Serializable]
    internal class ControlDetail
    {
        public string ControlName { get; set; }
        public string ControlType { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
