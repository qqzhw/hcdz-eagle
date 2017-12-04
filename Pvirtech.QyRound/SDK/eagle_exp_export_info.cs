using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    
   public struct eagle_exp_export_info
    {
        public  char[] exp_name; //exp_name[50]
        public  int channel_no;
        public  UInt32   start_frame;   //start from 0;
        public  UInt32   read_frame_num;
        public  UInt32   frame_scale;   // default 1;
    };
}
