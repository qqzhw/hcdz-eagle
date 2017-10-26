using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public enum EAGLE_SDK_STATUS
    {
        EAGLE_SDK_STATUS_SUCCESS = 0,   /*!< operation success */
        EAGLE_SDK_INVALID_TASK_NAME = 50000,    /*!< invalid task name */
        EAGLE_SDK_INVALID_PARAM,    /*!< invalid parameter */
        EAGLE_SDK_INVALID_RESOURCE, /*!< invalid resource. eg.allocate memory failed... */
        EAGLE_SDK_INVALID_DEVICE_ID,    /*!< invalid device id. */
        EAGLE_SDK_INVALID_AOE_DEVICE,   /*!< aoe driver may not install correctly*/
        EAGLE_SDK_INVALID_CONTROL_API_HANDLE,   /*!< Control_API.dll may not correct */
        EAGLE_SDK_FAILED_INIT_CLUSTER,  /*!< initialize cluster failed */
        EAGLE_SDK_MOUNT_FILESYSTEM_TIMEOUT, /*!< mount disk filesystems timeout */
        EAGLE_SDK_FAILED_GET_DATA_FILES,    /*!< failed get data files */
        EAGLE_SDK_FAILED_GET_DISK_VOLUMN,   /*!< failed get disk volumn */
        EAGLE_SDK_READ_NEED_MORE_DATA,  /*!< read need more data */
        EAGLE_SDK_NO_SUCH_RECORD,   /*!< no record with such record id */
        EAGLE_SDK_GET_REALTIME_DATA_TIMEOUT,    /*!< read realtime data timeout */
        EAGLE_SDK_CONTROL_TIMEOUT,  /*!< control command timeout in sdk */
        EAGLE_SDK_INVALID_DISK_MOUNT_TYPE, /*!< invalid disk mount type */
        EAGLE_SDK_STATUS_MAX
    }
}
