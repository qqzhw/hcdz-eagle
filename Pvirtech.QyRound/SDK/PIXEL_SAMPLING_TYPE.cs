using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public enum PIXEL_SAMPLING_TYPE
    {
        PixelSamplingGrey = 0,  /*!< One sampling value represent one pixel. All grey scale camlink camera and bayer transformation camera use this type.*/
        PixelSamplingYCbCr422i, /*!< Two sampling values represent one pixel. This use on interlaced scanning SDI camera.*/
        PixelSamplingYCbCr422p, /*!< Two sampling values represent one pixel. This use on progressive scanning SDI camera. */
                                // reserve to expand in the future 
        PixelSamplingMax
    }
}
