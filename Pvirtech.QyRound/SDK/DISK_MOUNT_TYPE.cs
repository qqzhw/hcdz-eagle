using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public enum DISK_MOUNT_TYPE
    {
        DISK_MOUNT_NONE = 0,
        DISK_MOUNT_FROM_USB,    /*!< mount from USB3 */
        DISK_MOUNT_FROM_AOE,    /*!< mount from  Gigabit Ethernet*/
        DISK_MOUNT_FROM_PCI,    /*!< mount from  PCI 2008 Switch*/
        DISK_MOUNT_FROM_FAST_EXPRESS,   /*!< mount from  Fast Express Port*/
        DISK_MOUNT_TYPE_MAX
    }
}
