using System;
using System.Runtime.InteropServices;

public class ClassFFmpeg
{
    /// <summary>
    /// 初始化ffmpeg指针
    /// </summary>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_new", CallingConvention = CallingConvention.Cdecl)]
    public extern static System.IntPtr ff_new();

    /// <summary>
    /// 释放ffmpeg指针
    /// </summary>
    /// <param name="hWnd_new"></param>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_destory", CallingConvention = CallingConvention.Cdecl)]
    public extern static int ff_destory(System.IntPtr hWnd_new);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <param name="hWnd">显示控件指针</param>
    /// <param name="right"></param>
    /// <param name="left"></param>
    /// <param name="top"></param>
    /// <param name="bottom"></param>
    /// <param name="type">文件类型（type 0-视音频合一；1-视频；2音频）</param>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_init", CallingConvention = CallingConvention.Cdecl)]
    public extern static int ff_init(System.IntPtr hWnd_new, System.IntPtr hWnd, int right, int left, int top, int bottom, int type);

    /// <summary>
    /// 打开文件并自动播放
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <param name="in_file">文件路径</param>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_open_file", CallingConvention = CallingConvention.Cdecl)]
    public extern static int ff_open_file(System.IntPtr hWnd_new, string in_file);

    /// <summary>
    /// 播放与暂停
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    [DllImport("AVplayer.dll", EntryPoint = "ff_play_pause", CallingConvention = CallingConvention.Cdecl)]
    public extern static void ff_play_pause(System.IntPtr hWnd_new);

    /// <summary>
    /// 播放与停止
    /// </summary>
    /// <param name="hWnd_new"></param>
    [DllImport("AVplayer.dll", EntryPoint = "ff_play_stop", CallingConvention = CallingConvention.Cdecl)]
    public extern static void ff_play_stop(System.IntPtr hWnd_new);

    /// <summary>
    /// 获取总时长（音频用）
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_get_duration", CallingConvention = CallingConvention.Cdecl)]
    public extern static double ff_get_duration(System.IntPtr hWnd_new);

    /// <summary>
    /// 获取总帧数（视频用）
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_get_total_frames_number", CallingConvention = CallingConvention.Cdecl)]
    public extern static Int64 ff_get_total_frames_number(System.IntPtr hWnd_new);

    /// <summary>
    /// 获取当前位置（音频用）
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_get_current_time", CallingConvention = CallingConvention.Cdecl)]
    public extern static double ff_get_current_time(System.IntPtr hWnd_new);

    /// <summary>
    /// 获取当前帧数（视频用）
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_get_current_frame_number", CallingConvention = CallingConvention.Cdecl)]
    public extern static Int64 ff_get_current_frame_number(System.IntPtr hWnd_new);

    /// <summary>
    /// 指定位置播放（音频用）
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <param name="seek_time">位置值</param>
    [DllImport("AVplayer.dll", EntryPoint = "ff_seek_time", CallingConvention = CallingConvention.Cdecl)]
    public extern static void ff_seek_time(System.IntPtr hWnd_new, double seek_time);

    /// <summary>
    /// 指定位置播放（视频用）
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <param name="seek_time">位置帧</param>
    [DllImport("AVplayer.dll", EntryPoint = "ff_seek_frame", CallingConvention = CallingConvention.Cdecl)]
    public extern static void ff_seek_frame(System.IntPtr hWnd_new, Int64 seek_time);

    /// <summary>
    /// 帧进
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    [DllImport("AVplayer.dll", EntryPoint = "ff_step_next", CallingConvention = CallingConvention.Cdecl)]
    public extern static void ff_step_next(System.IntPtr hWnd_new);

    /// <summary>
    /// 重设显示区域
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <param name="right"></param>
    /// <param name="left"></param>
    /// <param name="top"></param>
    /// <param name="bottom"></param>
    [DllImport("AVplayer.dll", EntryPoint = "ff_video_resize", CallingConvention = CallingConvention.Cdecl)]
    public extern static void ff_video_resize(System.IntPtr hWnd_new, int right, int left, int top, int bottom);

    /// <summary>
    /// 截帧
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <param name="out_file">保存路径</param>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_save_image", CallingConvention = CallingConvention.Cdecl)]
    public extern static int ff_save_image(System.IntPtr hWnd_new, string out_file);

    /// <summary>
    /// 获取音频强度
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <param name="max_channels">需要获取声道数</param>
    /// <param name="channels">获取到的声道数</param>
    /// <param name="volume">音频强度</param>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_get_audio_volume", CallingConvention = CallingConvention.Cdecl)]
    public extern static int ff_get_audio_volume(System.IntPtr hWnd_new, int max_channels, ref int channels, float[] volume);

    /// <summary>
    /// 设置播放速率
    /// </summary>
    /// <param name="hWnd_new">ffmpeg指针</param>
    /// <param name="param">播放速率（0：1.5倍速；1至5：1倍速-5倍速）</param>
    /// <returns></returns>
    [DllImport("AVplayer.dll", EntryPoint = "ff_set_play_speed", CallingConvention = CallingConvention.Cdecl)]
    public extern static int ff_set_play_speed(System.IntPtr hWnd_new, int param);

    /// <summary>
    /// 退出ffmpeg（关闭当前窗口时使用）
    /// </summary>
    [DllImport("AVplayer.dll", EntryPoint = "ff_quit", CallingConvention = CallingConvention.Cdecl)]
    public extern static void ff_quit();
}
