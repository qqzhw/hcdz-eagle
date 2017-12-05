using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct eagle_netcard_info
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string dev_name; /*!< name of the nic */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string dev_description; /*!< description of the nic */
    }
}
