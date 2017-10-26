using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public struct EagleData_Record
    {
       public EagleData_Record_Id id; /*!< The identifier for the record */
       public  EagleData_CcdRecord ccd_record_list;   /*!< List of CCD records */
    }
}
