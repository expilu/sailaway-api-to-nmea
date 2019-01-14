using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailawayToNMEA.Model
{
    public class LogText
    {
        public LogText(string txt, Nullable<Color> color = null)
        {
            Txt = txt;
            Color = color ?? Color.Black;
        }

        public string Txt { get; set; }
        public Color Color { get; set; }
    }
}
