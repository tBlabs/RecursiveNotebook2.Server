using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHydra.Framework.Core
{
    public interface IPackage
    {
        string ClassName { get; set; }
        string ClassProperties { get; set; }
    }
}