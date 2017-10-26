using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public struct eagle_camera_config
    {
        public uint baud_rate; /*!< [IN] serial port's baud rate */
        public UInt16 camera_mode;/*!< [IN] 0:base; 1:medium; 2:full */
        public UInt16 camera_no;   /*!< [IN] 1 to 4 */
                                   // unsigned char send_buffer[64];  /*!< [IN] */
        public byte[] send_buffer;
        public int send_len;   /*!< [IN] */
        public byte[] recv_buffer;  /*!< [OUT] */
        public int recv_len;   /*!< [OUT] */
    }
}
