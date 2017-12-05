using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct eagle_all_netcards
    {
        //cards=10;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
      public  eagle_netcard_info[] cards;   /*!< all netcards on the computer. */
      public   int card_num;   /*!< actual card number, max 10. */
    }
}
