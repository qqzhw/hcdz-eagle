using Prism.Mvvm;
using Pvirtech.QyRound.Core.Common;
using Pvirtech.QyRound.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.ViewModels
{
    public class SDKViewModel: BindableBase
    {
        public void Get_Record_List()
        {
            SDKApi.EagleData_RefetchRecList();
            int record_num = SDKApi.EagleData_GetRecordNumber();
            LogHelper.WriteLog(string.Format("get record number {0}\n", record_num));
            if (record_num > 0)
            {
                EagleData_Record_Id[] ids = new EagleData_Record_Id[record_num];
                int actual_num = SDKApi.EagleData_GetRecordList(out ids, record_num);
                //_print_record_list(ids, actual_num);
                for (int i = 0; i < actual_num; i++)
                {
                    var record = SDKApi.EagleData_GetRecordAndAllocMemory(ids[i]);
                    if (record!=IntPtr.Zero)
                    {
                        //_print_record_detail(&record->id, i + 1);
                        //EagleData_CcdRecord ccd_record = record.ccd_record_list;
                        //int ccd_record_index = 0;
                        //while (ccd_record)
                        //{
                        //   // _print_ccd_record_detail(ccd_record, ++ccd_record_index);
                        //    ccd_record = ccd_record->next;
                        //}
                        //SDKApi.EagleData_FreeRecordMemory(ref record);
                    }
                }
               // delete[] ids;
            }
        }

        public void ReNameTask()
        {
            SDKApi.EagleData_RefetchRecList();
            int record_num = SDKApi.EagleData_GetRecordNumber();
            if (record_num > 0)
            {
                EagleData_Record_Id[] ids = new EagleData_Record_Id[record_num];
                int actual_num = SDKApi.EagleData_GetRecordList(out ids, record_num);
                //_print_record_list(ids, actual_num);
                //int record_index = _select_input("input record to rename", actual_num, 1, 0);
                //if (record_index == 0)
                //{ 
                //    return;
                //}
                //printf("input new name:");
                //wchar_t new_name[32] = { '\0' };
                //wscanf_s(L"%ls", new_name, 31);
                int ret = SDKApi.EagleData_RenameTask(ids[actual_num - 1], "new-code");
                //PrintResult(ret, "rename");
                //delete[] ids;
                
            }
        }
        /// <summary>
        /// 开始记录
        /// </summary>
        /// <param name="deviceId"></param>
        private void StartRecord(int deviceId,int capture_frame_num=0,int capture_time=0,int capture_frame_interval=0)
        {
            SDKApi.EagleControl_StartRecord(deviceId, 0, 0, 0);
        }
        /// <summary>
        /// 暂停记录
        /// </summary>
        /// <param name="deviceId"></param>
        private void PauseRecord(int deviceId)
        {
            SDKApi.EagleControl_PauseRecord(deviceId);
        }
        /// <summary>
        /// 继续记录
        /// </summary>
        /// <param name="deviceId"></param>
        private void ResumeRecord(int deviceId)
        {
            SDKApi.EagleControl_ResumeRecord(deviceId);
        }
        private void StopRecord(int deviceId)
        {
            SDKApi.EagleControl_StopRecord(deviceId);
        }

        private void StartRecordTask(int deviceId,string taskName,int taskType,int sampling_type)
        {
            SDKApi.EagleControl_StartTask(deviceId, taskName, taskType, sampling_type);
        }
        private void StopTask(int deviceId)
        {
            SDKApi.EagleControl_StopTask(deviceId);
        }

        /// <summary>
        /// 扫描并获取设备数量
        /// </summary>
        /// <returns></returns>
        private int ScanAndGetDeviceNum()
        {
            int deviceNum = 0;
            SDKApi.EagleControl_ScanAndGetDeviceNum(ref deviceNum);
            return deviceNum;
        }

        public void Delete_Ccd_Record()
        {
            SDKApi.EagleData_RefetchRecList();
            int record_num = SDKApi.EagleData_GetRecordNumber();
            if (record_num > 0)
            {
                //get record list
                var ids = new EagleData_Record_Id[record_num];
                int actual_num = SDKApi.EagleData_GetRecordList(out ids, record_num);
               // _print_record_list(ids, actual_num);
               // int record_index = _select_input("input record to delete", actual_num, 1, 0);
                if (actual_num == 0)
                {
                   // delete[] ids;
                    return;
                }

                var record = SDKApi.EagleData_GetRecordAndAllocMemory(ids[actual_num - 1]);
                if (record!=IntPtr.Zero)
                {
                    //EagleData_CcdRecord* ccd_record = record->ccd_record_list;
                    //int ccd_record_index = 0;
                    //while (ccd_record)
                    //{
                    //    _print_ccd_record_detail(ccd_record, ++ccd_record_index);
                    //    ccd_record = ccd_record->next;
                    //}
                    int ccd_record_index_to_delete = 0;// _select_input("input ccd record to delete.", ccd_record_index, 1, 0);
                    if (0 == ccd_record_index_to_delete)
                    {
                       // SDKApi.EagleData_FreeRecordMemory(record);
                        //delete[] ids;
                        return;
                    }
                    else
                    {
                        //to delete
                        //ccd_record = record->ccd_record_list;
                        //ccd_record_index = 0;
                        //while (ccd_record)
                        //{
                        //    if (++ccd_record_index == ccd_record_index_to_delete)
                        //    {
                        //        int ret = EagleData_DeleteRecord(ccd_record->record_id, ccd_record->id);
                        //        PrintResult(ret, "delete");
                        //        break;
                        //    }
                        //    ccd_record = ccd_record->next;
                        //}
                    }
                    SDKApi.EagleData_FreeRecordMemory(record);
                }
                 
            }
        }

        public  List<T> MarshalPtrToStructArray<T>(IntPtr p, int count)
        {
            List<T> list = new List<T>();
            for (int i = 0; i < count; i++, p = new IntPtr(p.ToInt32() + Marshal.SizeOf(typeof(T))))
            {
                T t = (T)Marshal.PtrToStructure(p, typeof(T));
                list.Add(t);
            }
            return list;
        }
    }
}
