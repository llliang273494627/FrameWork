Option Strict Off
Option Explicit On
Module Modhddinfo
	'UPGRADE_WARNING: 结构 LARGE_INTEGER 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	'UPGRADE_WARNING: 结构 LARGE_INTEGER 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	'UPGRADE_WARNING: 结构 LARGE_INTEGER 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Public Declare Function GetDiskFreeSpaceEx Lib "kernel32"  Alias "GetDiskFreeSpaceExA"(ByVal lpRootPathName As String, ByRef lpFreeBytesAvailableToCaller As LARGE_INTEGER, ByRef lpTotalNumberOfBytes As LARGE_INTEGER, ByRef lpTotalNumberOfFreeBytes As LARGE_INTEGER) As Integer
	Public Declare Function GetVolumeInformation Lib "kernel32"  Alias "GetVolumeInformationA"(ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As String, ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, ByVal lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer
	Public Declare Function GetDiskFreeSpace Lib "kernel32"  Alias "GetDiskFreeSpaceA"(ByVal lpRootPathName As String, ByRef lpSectorsPerCluster As Integer, ByRef lpBytesPerSector As Integer, ByRef lpNumberOfFreeClusters As Integer, ByRef lpTotalNumberOfClusters As Integer) As Integer
	
	Public Structure LARGE_INTEGER
		Dim Lowpart As Integer
		Dim Highpart As Integer
	End Structure
	Public Result As Double
	Public Const SIZE_KB As Double = 1024
	Public Const SIZE_MB As Double = 1024 * SIZE_KB
	Public Const SIZE_GB As Double = 1024 * SIZE_MB
	Public Const SIZE_TB As Double = 1024 * SIZE_GB
	Public Declare Function GetLogicalDriveStrings Lib "kernel32"  Alias "GetLogicalDriveStringsA"(ByVal nBufferLength As Integer, ByVal lpBuffer As String) As Integer
	Public Const DRIVE_UNKNOWN As Short = 0
	Public Const DRIVE_NOTEXIST As Short = 1
	Public Const DRIVE_REMOVABLE As Short = 2
	Public Const DRIVE_FIXED As Short = 3
	Public Const DRIVE_REMOTE As Short = 4
	Public Const DRIVE_RAMDISK As Short = 6
	Public Const DRIVE_CDROM As Short = 5
	
	Public Const FILE_CASE_SENSITIVE_SEARCH As Integer = &H1
	Public Const FILE_CASE_PRESERVED_NAMES As Integer = &H2
	Public Const FILE_UNICODE_ON_DISK As Integer = &H4
	Public Const FILE_PERSISTENT_ACLS As Integer = &H8
	Public Const FILE_FILE_COMPRESSION As Integer = &H10
	Public Const FILE_VOLUME_QUOTAS As Integer = &H20
	Public Const FILE_SUPPORTS_SPARSE_FILES As Integer = &H40
	Public Const FILE_SUPPORTS_REPARSE_POINTS As Integer = &H80
	Public Const FILE_SUPPORTS_REMOTE_STORAGE As Integer = &H100
	Public Const FILE_VOLUME_IS_COMPRESSED As Integer = &H8000
	Public Const FILE_SUPPORTS_OBJECT_IDS As Integer = &H10000
	Public Const FILE_SUPPORTS_ENCRYPTION As Integer = &H20000
	Public Const FILE_NAMED_STREAMS As Integer = &H40000
	
	Public Const FS_CASE_IS_PRESERVED As Integer = FILE_CASE_PRESERVED_NAMES
	Public Const FS_CASE_SENSITIVE As Integer = FILE_CASE_SENSITIVE_SEARCH
	Public Const FS_UNICODE_STORED_ON_DISK As Integer = FILE_UNICODE_ON_DISK
	Public Const FS_PERSISTENT_ACLS As Integer = FILE_PERSISTENT_ACLS
	Public Const FS_VOL_IS_COMPRESSED As Integer = FILE_VOLUME_IS_COMPRESSED
	Public Const FS_FILE_COMPRESSION As Integer = FILE_FILE_COMPRESSION
	Public Const FS_FILE_ENCRYPTION As Integer = FILE_SUPPORTS_ENCRYPTION
	
	Public sDriveNames As String
	Public lBuffer As Integer
	Public lReturn As Integer
	Public nLoopCtr As Short
	Public nOffset As Short
	Public sTempStr As String
	
	Public Root As String
	Public Volume_Name As String
	Public Serial_Number As Integer
	Public Max_Component_Length As Integer
	Public File_System_Flags As Integer
	Public File_System_Name As String
	Public Pos As Short
	Public Dbl_Total As Double
	Public Dbl_Free As Double
	
	Public lSectorsPerCluster As Integer
	Public lBytesPerSector As Integer
	Public lFreeClusters As Integer
	Public lTotalClusters As Integer
	Public sDrive As String
	Public Function GetHDDState(ByRef HDDID As String, ByRef FreeHDD As Integer) As Short
		Dim TempHDDID As String
		Dim Bytes_Avail As LARGE_INTEGER
		Dim Bytes_Total As LARGE_INTEGER
		Dim Bytes_Free As LARGE_INTEGER
		TempHDDID = Trim(UCase(HDDID) & ":\")
		On Error Resume Next
		If GetVolumeInformation(TempHDDID, Volume_Name, Len(Volume_Name), Serial_Number, Max_Component_Length, File_System_Flags, File_System_Name, Len(File_System_Name)) = 0 Then
			GetHDDState = 2 '"盘符出错"
			Exit Function
		End If
		GetDiskFreeSpaceEx(TempHDDID, Bytes_Avail, Bytes_Total, Bytes_Free)
		Dbl_Free = LargeIntegerToDouble(Bytes_Free.Lowpart, Bytes_Free.Highpart)
		If CDbl(SizeString(Dbl_Free)) < FreeHDD Then
			GetHDDState = 0 'UCase(HDDID) & "盘空间已满"
		Else
			GetHDDState = 1 'UCase(HDDID) & "盘空间正常"
		End If
	End Function
	Private Function LargeIntegerToDouble(ByRef Low_Part As Integer, ByRef High_Part As Integer) As Double
		Result = High_Part
		If High_Part < 0 Then Result = Result + 2 ^ 32
		Result = Result * 2 ^ 32
		Result = Result + Low_Part
		If Low_Part < 0 Then Result = Result + 2 ^ 32
		LargeIntegerToDouble = Result
	End Function
	Private Function SizeString(ByVal Num_Bytes As Double) As String
		SizeString = VB6.Format(Num_Bytes / SIZE_MB, "0.00")
	End Function
End Module