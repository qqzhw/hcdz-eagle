using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public struct EagleData_CcdRecord_Id
    {
        public long device_id; /*!< Identifier for the device */
        public long ccd_serial;	/*!< The CCD serial, 1,2,3,4 from the first camera to the fourth */
    }
}
