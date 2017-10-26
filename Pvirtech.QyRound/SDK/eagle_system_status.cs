using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public struct eagle_system_status
    {
        public int fpga_tempture;  /*!< temperature of core system */
        public byte current_disk_owener;  /*!< 0: fpga and embeded system; 1:AoE; 2:USB3.see CURRENT_DISK_OWENER_XXX */
        public byte disk_num; /*!< current system disk number, valid elements in remained_volume array */
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Int16[] remained_volume;   /*!< max 8 disks per eagle device */
        public byte frame_is_successional;	/*!< bitmap, every bit shows one camera, from low address, 0:successional; 1:not successional. This bit will be set by fpga when it detects frame lose and clear after stop record.*/
    }
}
