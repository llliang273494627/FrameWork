Option Strict Off
Option Explicit On
Module MODDriver
    Public Const MaxDev As Short = 255 ' max. # of devices
    Public Const MaxDevNameLen As Short = 49 ' original is 64; max lenght of device name
    Public Const MAX_DRIVER_NAME_LEN As Short = 16
    Public Const INPORT As Short = 0
    Public Const OUTPORT As Short = 1

    Public Const MaxEntries As Short = 255
    Public DeviceHandle As Integer
    Public ptDevGetFeatures As PT_DeviceGetFeatures
    Public lpDevFeatures As DEVFEATURES
    Public devicelist(MaxEntries) As PT_DEVLIST
    Public SubDevicelist(MaxEntries) As PT_DEVLIST
    Public ErrCde As Integer
    Public szErrMsg As New VB6.FixedLengthString(80)
    Public bRun As Boolean

    Public lpDioPortMode As PT_DioSetPortMode
    Public lpDioWritePort As PT_DioWritePortByte
    Public lpDioGetCurrentDoByte As PT_DioGetCurrentDOByte
    Public lpDioReadPort As PT_DioReadPortByte

    Structure GainList
        Dim usGainCde As Short
        Dim fMaxGainVal As Single
        Dim fMinGainVal As Single
        <VBFixedArray(15)> Dim szGainStr() As Byte

        'UPGRADE_TODO: 必须调用“Initialize”来初始化此结构的实例。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"”
        Public Sub Initialize()
            ReDim szGainStr(15)
        End Sub
    End Structure

    Structure DEVFEATURES
        <VBFixedArray(7)> Dim szDriverVer() As Byte ' device driver version
        <VBFixedArray((MAX_DRIVER_NAME_LEN - 1))> Dim szDriverName() As Byte ' device driver name
        Dim dwBoardID As Integer ' board ID
        Dim usMaxAIDiffChl As Short ' Max. number of differential channel
        Dim usMaxAISiglChl As Short ' Max. number of single-end channel
        Dim usMaxAOChl As Short ' Max. number of D/A channel
        Dim usMaxDOChl As Short ' Max. number of digital out channel
        Dim usMaxDIChl As Short ' Max. number of digital input channel
        Dim usDIOPort As Short ' specifies if programmable or not
        Dim usMaxTimerChl As Short ' Max. number of Counter/Timer channel
        Dim usMaxAlarmChl As Short ' Max number of  alram channel
        Dim usNumADBit As Short ' number of bits for A/D converter
        Dim usNumADByte As Short ' A/D channel width in bytes.
        Dim usNumDABit As Short ' number of bits for D/A converter.
        Dim usNumDAByte As Short ' D/A channel width in bytes.
        Dim usNumGain As Short ' Max. number of gain code
        'UPGRADE_WARNING: 数组 glGainList 可能需要对单个元素进行初始化。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"”
        <VBFixedArray(15)> Dim glGainList() As GainList ' Gain listing
        <VBFixedArray(3)> Dim dwPermutation() As Integer ' Permutation

        'UPGRADE_TODO: 必须调用“Initialize”来初始化此结构的实例。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"”
        Public Sub Initialize()
            ReDim szDriverVer(7)
            ReDim szDriverName((MAX_DRIVER_NAME_LEN - 1))
            ReDim glGainList(15)
            ReDim dwPermutation(3)
        End Sub
    End Structure

    Structure PT_DEVLIST
        Dim dwDeviceNum As Integer
        <VBFixedArray(49)> Dim szDeviceName() As Byte
        Dim nNumOfSubdevices As Short

        'UPGRADE_TODO: 必须调用“Initialize”来初始化此结构的实例。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"”
        Public Sub Initialize()
            ReDim szDeviceName(49)
        End Sub
    End Structure

    Structure PT_DeviceGetFeatures
        Dim buffer As Integer ' LPDEVFEATURES
        Dim size As Short
    End Structure

    Structure PT_DioSetPortMode
        Dim Port As Short
        'UPGRADE_NOTE: dir 已升级到 dir_Renamed。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"”
        Dim dir_Renamed As Short
    End Structure

    Structure PT_DioReadPortByte
        Dim Port As Short
        Dim value As Integer ' USHORT far *value
    End Structure

    Structure PT_DioWritePortByte
        Dim Port As Short
        Dim Mask As Short
        Dim state As Short
    End Structure

    Structure PT_DioGetCurrentDOByte
        Dim Port As Short
        Dim value As Integer ' USHORT far *value
    End Structure

    Declare Function DRV_DeviceGetNumOfList Lib "adsapi32.dll" (ByRef NumOfDevices As Short) As Integer
    Declare Function DRV_DeviceGetList Lib "adsapi32.dll" (ByVal devicelist As Integer, ByVal MaxEntries As Short, ByRef nOutEntries As Short) As Integer
    Declare Function DRV_DeviceOpen Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByRef DriverHandle As Integer) As Integer
    Declare Function DRV_DeviceGetFeatures Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpDevFeatures As PT_DeviceGetFeatures) As Integer
    Declare Sub DRV_GetErrorMessage Lib "adsapi32.dll" (ByVal lError As Integer, ByVal lpszszErrMsg As String)
    Declare Function DRV_DioSetPortMode Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioSetPortMode As PT_DioSetPortMode) As Integer
    Declare Function DRV_DioReadPortByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioReadPortByte As PT_DioReadPortByte) As Integer
    Declare Function DRV_DioWritePortByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioWritePortByte As PT_DioWritePortByte) As Integer
    Declare Function DRV_DioGetCurrentDOByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioGetCurrentDOByte As PT_DioGetCurrentDOByte) As Integer
    Declare Function DRV_GetAddress Lib "adsapi32.dll" (ByRef lpVoid As Object) As Integer

End Module