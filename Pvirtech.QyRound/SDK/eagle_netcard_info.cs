using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct eagle_netcard_info
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public char[] dev_name; /*!< name of the nic */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public char[] dev_description; /*!< description of the nic */
    }
}
