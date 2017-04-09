using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHydra.Framework
{
    public class Claims
    {
        public bool CanAddNote { get; set; } = true;
        public bool CanReadNote { get; set; } = true;
        public bool CanDeleteNote { get; set; } = true;
        public bool CanChangeNote { get; set; } = true;

        public override string ToString()
        {
            return $"CanAddNote={CanAddNote}, CanReadNote={CanReadNote}, CanDeleteNote={CanDeleteNote}, CanChangeNote={CanChangeNote}";
        }
    }
}
