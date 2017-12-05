using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.Models
{
    /// <summary>
    /// 采集模式控制
    /// </summary>
    public class CollectMode
    {
        /// <summary>
        /// 采集对应值
        /// </summary>
        public byte ModeByte { get; set; }

        /// <summary>
        /// 模式名称
        /// </summary>
        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}
