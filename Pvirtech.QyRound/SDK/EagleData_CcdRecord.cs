using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public struct EagleData_CcdRecord
    {
        [MarshalAs(UnmanagedType.AsAny)]
        public  IntPtr next;  /*!< ccd record list node EagleData_CcdRecord */
        public EagleData_CcdRecord_Id id;  /*!< Identifier for the ccd record */
        public EagleData_Record_Id record_id;  /*!< Identifier for the record */
        public long task_index;    /*!< Zero-based index of the task.It is the suffix number of TASKnnnn*/
        public long record_index;  /*!< Zero-based index of the record.It is the suffix number of RECDnnnn */
        public long column;    /*!< The column */
        public long line;  /*!< The line */
        public long color_depth;   /*!< The storage color depth. */
        public long real_color_depth;  /*!< The real color depth */
        public long frame_number;  /*!< The frame number */

        public string start_time;//[MAX_TIME_BUF_LEN];   /*!< The start time. Format:  YYYYMMDDHHMMSS (eg.20160104120000)*/
        public string end_time;//[MAX_TIME_BUF_LEN]; /*!< The end time. Format: YYYYMMDDHHMMSS (eg.20160104120001)*/


        public string path;//[MAX_PATH_BUF_LEN]=128; /*!< Path of the ccd record. X:\\TASKnnnn\\RECDnnnn */
        public string task_path;//[MAX_PATH_BUF_LEN];/*!< Path of the task. X:\\TASKnnnn */
        public  DATA_SOURCE_TYPE data_source_type;  /*!< Type of the data source */
        public  PIXEL_SAMPLING_TYPE pixel_sampling_type;    /*!< Type of the pixel sampling */
        public  byte disk_bitmap;  /*!< The disk bitmap of the ccd record.One bit reprecent one disk(support 8 disks per device at most). \n
								8 bits reprecent 8 disks from low address.Bit set shows this ccd record use this disk, and not set for unuse.*/

    }
}
