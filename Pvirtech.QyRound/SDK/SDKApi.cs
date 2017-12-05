using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.SDK
{
    public class SDKApi
    {
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void EagleData_GetVersion(ref int major, ref int minor);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_Init();

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_RefetchRecList();
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_CheckAndRemountFileSystem(int device_id, DISK_MOUNT_TYPE mount_type);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_RemoveFileSystem(int device_id, DISK_MOUNT_TYPE mount_type);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_GetRecordNumber();

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_GetRecordList(out EagleData_Record_Id[] rec_ids_buf, int num);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern IntPtr EagleData_GetRecordAndAllocMemory(EagleData_Record_Id id);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void EagleData_FreeRecordMemory(IntPtr record);//ref EagleData_Record

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_ReadOneStoredFrame(EagleData_Record_Id rec_id, EagleData_CcdRecord_Id ccd_rec_id, long frame_index, out string data_buf, int data_buf_len, out string head_buf, int head_buf_len);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_Read512InsideFrame(
      EagleData_Record_Id rec_id,
      EagleData_CcdRecord_Id ccd_rec_id,
      long frame_index,
      long offset,
    out string buf);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_ReadInfoTxtFile(
     EagleData_Record_Id rec_id,
     EagleData_CcdRecord_Id ccd_rec_id,
   out string buf,
   ref int buf_size);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void EagleData_ProcessScaledColumnLine(
        ref int column,
     ref int line,
      int color_depth,
      char shrink_level);


        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_ReadOneRealtimeFrame(
     EagleData_CcdRecord_Id ccd_rec_id,
     int column,
     int line,
     int color_depth,
    out string data_buf,
     int data_buf_len,
   out string head_buf,
     int head_buf_len);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_CheckOneFrame(
      EagleData_Record_Id rec_id,
      EagleData_CcdRecord_Id ccd_rec_id,
      int frame_index,
    out long err_pix);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void EagleData_AnalyzeFrameHead(
    string buf,
    out FrameHead head);
        ////函数指针使用c++: typedef double (*fun_type1)(double); 对应 c#:public delegate double  fun_type1(double);
        public    delegate    void record_list_change_callback();


        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void EagleData_RegisterRecListChangeCallback(record_list_change_callback callback);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_RenameTask(  EagleData_Record_Id id,   string new_name);


        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_DeleteRecord(  EagleData_Record_Id rec_id,   EagleData_CcdRecord_Id ccd_rec_id);

        [DllImport("SDK.dll",CharSet=CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetSystemNICs(ref eagle_all_netcards nics);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_SetControlNICs( eagle_all_netcards nics);

        [DllImport("SDK.dll",CharSet =CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_ScanAndGetDeviceNum(ref int device_num);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetDeviceNum();
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetDeviceIds(ref int[] id_array,   int array_size, ref int actual_ids);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetCurrentControlNIC(  int device_id,  ref eagle_netcard_info netcard);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetDeviceMacAddress(  int device_id, ref byte mac);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetNICMacAddress(  int device_id, ref byte mac);//mac=6

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetNICMtu(  int device_id, ref int mtu);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_SetRealtimePackageSize(  int device_id,   int size);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_SetDeviceName(  int device_id,  string name);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetDeviceName(  int device_id, out string name);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetMaxCameraNumber(  int device_id,out int num);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_SetDeviceCameraValid(  int device_id,   int camera_serial,   bool valid);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern bool EagleControl_IsCameraValid(  int device_id,   int camera_serial);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern EDeviceType EagleControl_GetDeviceType(int device_id);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetElfVersion(  int device_id, out char version);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetDeviceSerial(  int device_id, out char serial);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetFpgaSerial(  int device_id, out char serial);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetCameraCaptureParam(  int device_id,   out eagle_capture_config* config);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_SetCameraCaptureParam(  int device_id,   eagle_capture_config *config);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetCameraDetectedParam( int device_id, out eagle_capture_config* config);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetSystemStatus( int device_id, out eagle_system_status  status);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetCameraDiskMapping( int device_id, out eagle_camera_disk_config config);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_SetCameraDiskMapping( int device_id,   eagle_camera_disk_config config);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_ReinitDisk(  int device_id);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_ReformatDisk(  int device_id);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_RestoreConfig(  int device_id);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_StartTask(  int device_id,   string task_name,  int task_type,  int sampling_type);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_StopTask(  int device_id);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_StartRecord( int device_id,  int capture_frame_num,  int capture_time,  int capture_frame_interval);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_ContinueRecordByFrame( int device_id,  int capture_frame_num);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_PauseRecord( int device_id);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_ResumeRecord( int device_id);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_StopRecord(  int device_id);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_CameraSet(  int device_id,   ref eagle_camera_config config);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern bool EagleControl_IsCameraChecked(  int device_id,   int camera_serial);

        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_CheckCamera(  int device_id,   int camera_serial,   bool check);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_SetCameraName(  int device_id,   int camera_serial,   string name);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetCameraName(  int device_id,   int camera_serial, out string name);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetCameraRealtimeShrinkLevel(  int device_id,   int camera_serial,   char* shrink_scale_level);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_SetCameraRealtimeShrinkLevel( int device_id,  int camera_serial,   char shrink_scale_level);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetDeviceTriggerFrequency( int device_id, out eagle_trigger_frequency_config trigger_fps);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_SetDeviceTriggerFrequency( int device_id,  eagle_trigger_frequency_config new_trigger_fps);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleControl_GetDeviceCameraStatus( int device_id,  eagle_camera_line_staus current_status);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern  int EagleControl_GetDeviceDiskVolume( int device_id,  eagle_disk_total_volume disk_volume);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_ExpStartRead(int device_id, ref eagle_exp_export_info export_info);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_ExpGetExportStatus(int device_id, ref eagle_exp_export_status status);
        [DllImport("SDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int EagleData_ExpStopRead(int device_id);
    }
}
