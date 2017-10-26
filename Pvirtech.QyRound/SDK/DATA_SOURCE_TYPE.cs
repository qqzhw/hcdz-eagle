using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public enum DATA_SOURCE_TYPE
    {
        DATA_SOURCE_CHECK_LINE = 0x00,  /*!< static horizontal stripe internal data pattern */
        DATA_SOURCE_CHECK_COLUMN = 0x10,    /*!< static vertical stripe internal data pattern */
        DATA_SOURCE_CHECK_DIAGONAL = 0x20,  /*!< static diagonal stripe internal data pattern */
        DATA_SOURCE_CHECK_MOVING_LINE = 0x80,   /*!< static diagonal stripe internal data pattern */
        DATA_SOURCE_CHECK_MOVING_COLUMN = 0x90, /*!< static diagonal stripe internal data pattern */
        DATA_SOURCE_CHECK_MOVING_DIAGONAL = 0xA0,   /*!< static diagonal stripe internal data pattern */
        DATA_SOURCE_NORMAL_CL = 0x01,   /*!< camlink camera data source */
        DATA_SOURCE_NORMAL_GTX = 0x02,  /*!< GTX data source (Reserved) */
        DATA_SOURCE_NORMAL_SDI = 0x04   /*!< SDI camera data source */
    }
}
