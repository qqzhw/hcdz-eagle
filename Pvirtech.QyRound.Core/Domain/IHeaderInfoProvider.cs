using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pvirtech.QyRound.Domain
{
    public interface IHeaderInfoProvider<T>
    {
        T HeaderInfo { get; }
    }
}
