using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public struct FrameHead
    {
        public UInt16 frame_index_low;/*!< frame index low 16 bits */
        public ushort frame_index_high;/*!< frame index high 16 bits */
        public UInt16 frame_column;    /*!< column number */
        public UInt16 frame_line;/*!< line number */
        public UInt16 ms;/*!< milliseconds */
        public byte s;/*!< seconds */
        public byte m;/*!< minutes */
        public byte h;/*!< hour */
        public UInt32 tag;/*!< tag number */
    }
}
