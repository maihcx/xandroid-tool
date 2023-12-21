// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Diagnostics;

namespace XAndroid_Tool;

class MainAssembly
{
    public static Assembly Asssembly => Assembly.GetExecutingAssembly();

    public static string ASSEMBLY_NAME { get { return AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location).Name; } }
    public static string TEMP_PATH { get; set; }
    public static string TEMP_MAIN { get; set; }
    public static string LOCAL_APPDATA_PATH { get { return Environment.GetEnvironmentVariable("LocalAppData"); } }
    public static string APP_PATH { get { return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName); } }
    public static string RES_PATH { get { return Path.Combine(APP_PATH, "Resources"); } }
    public static string APKTOOL_PATH { get { return Path.Combine(RES_PATH, "apktool.jar"); } }
    public static string APKSIGNER_PATH { get { return Path.Combine(RES_PATH, "apksigner.jar"); } }
    public static string BAKSMALI_PATH { get { return Path.Combine(RES_PATH, "baksmali.jar"); } }
    public static string SMALI_PATH { get { return Path.Combine(RES_PATH, "smali.jar"); } }
    public static string SIGNAPK_KEYPRIVATE { get { return Path.Combine(RES_PATH, "testkey.pk8"); } }
    public static string SIGNAPK_KEYPUBLIC { get { return Path.Combine(RES_PATH, "testkey.x509.pem"); } }
    public static string ZIPALIGN_PATH { get { return Path.Combine(RES_PATH, "zipalign.exe"); } }
    public static string AAPT_PATH { get { return Path.Combine(RES_PATH, "aapt.exe"); } }
    public static string AAPT2_PATH { get { return Path.Combine(RES_PATH, "aapt2.exe"); } }
    public static string APKEDITOR_PATH { get { return Path.Combine(RES_PATH, "apkeditor.jar"); } }
    public static string ADB_PATH { get { return Path.Combine(RES_PATH, "adb.exe"); } }
    public static string ADBWINAPI_PATH { get { return Path.Combine(RES_PATH, "AdbWinApi.dll"); } }
    public static string ADBWINUSBAPI_PATH { get { return Path.Combine(RES_PATH, "AdbWinUsbApi.dll"); } }
    public static string LIBWINP_PATH { get { return Path.Combine(RES_PATH, "libwinpthread-1.dll"); } }
    public static string FRAMEWORK_DIR { get { return Path.Combine(LOCAL_APPDATA_PATH, "apktool", "framework"); } }
    public static string STANDALONE_FRAMEWORK_DIR { get { return Path.Combine(LOCAL_APPDATA_PATH, ASSEMBLY_NAME, "framework"); } }
}
