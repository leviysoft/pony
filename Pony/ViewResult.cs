using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pony
{
    /// <summary>
    /// Cross-framework replacement for System.Windows.Forms.DialogResult
    /// The order of values is the same as in DialogResult, so straight-forward conversion
    /// throught typecast is possible
    /// </summary>
    public enum ViewResult : int
    {
        None,
        OK,
        Cancel,
        Abort,
        Retry,
        Ignore,
        Yes,
        No
    }
}
