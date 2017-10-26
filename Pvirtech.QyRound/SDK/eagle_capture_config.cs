using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public struct eagle_capture_config
    {
        public ushort camera_no;   /*!< [in] camera index from 1 to 4 */
        public UInt16 column;/*!< the column */
        public UInt16 line;/*!< the line */
        public UInt16 frame_rate;/*!< the frame rate, this is only used in GetCameraDetectedParam interface */
        public byte color_depth;/*!< the color depth * unsigned char*/
        public  byte taps;/*!< the taps *unsigned char */
        public UInt16 capture_status;/*!< 0:init; 1:capturing; 2:recording; 3:paused see ECaptureStatusType*/
    }
}
