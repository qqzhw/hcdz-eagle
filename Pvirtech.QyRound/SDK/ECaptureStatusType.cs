using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public enum ECaptureStatusType
    {
        ECaptureReady = 0,  /*!< ready, the state after power up and stop task. */
        ECaptureTasking,    /*!< state after start task */
        ECaptureRecording,  /*!< state after start record */
        ECapturePaused, /*!< state after pause record */
        ECaptureMax
    }
}
