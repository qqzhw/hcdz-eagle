using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public struct EagleData_Record_Id
    {
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst=64)]
        public string task_name;//[MAX_NAME_BUF_LEN]=64;    /*!< task name */
        public DateTime start_time; /*!< Cameras start record at the same time will be classified into same record */
    }
}
