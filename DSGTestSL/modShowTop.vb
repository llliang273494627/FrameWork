Option Strict Off
Option Explicit On
Module modShowTop
	'窗体置于顶层
	'使用方法：在form load过程中SetTopWindow Me.hWnd
	
	
	Public Enum VideoWindowType
		OneWindow = 0
		FourWindow = 1
		NineWindow = 2
		SixteenWindow = 3
		OneplusFiveWindow = 4
	End Enum
	
	Public Const HWND_TOP As Short = 0
	Public Const HWND_BOTTOM As Short = 1
	Public Const HWND_TOPMOST As Short = -1
	Public Const HWND_NOTOPMOST As Short = -2
	Public Const SWP_NOSIZE As Integer = &H1
	Public Const SWP_NOMOVE As Integer = &H2
	Public Const SWP_NOZORDER As Integer = &H4
	Public Const SWP_NOREDRAW As Integer = &H8
	Public Const SWP_SHOWWINDOW As Integer = &H0
	
	Public Const HTCAPTION As Short = 2
	Public Const WM_NCLBUTTONDOWN As Integer = &HA1
	
	Public Declare Function ReleaseCapture Lib "user32" () As Integer
	Public Declare Function SendMessage Lib "user32"  Alias "SendMessageA"(ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
	
	Public Declare Function SetWindowPos Lib "user32 " (ByVal hWnd As Integer, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
	
	Public Declare Function GetWindowLong Lib "user32"  Alias "GetWindowLongA"(ByVal hWnd As Integer, ByVal nIndex As Integer) As Integer
	Public Declare Function SetWindowLong Lib "user32"  Alias "SetWindowLongA"(ByVal hWnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
	Public Const GWL_STYLE As Short = (-16)
	Public Const WS_SYSMENU As Integer = &H80000
	'
	'Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As Long, ByVal nIndex As Long) As Long
	'Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As Long, ByVal nIndex As Long, ByVal dwNewLong As Long) As Long
	'Private Const GWL_STYLE = (-16)
	'Private Const WS_SYSMENU = &H80000
	Private Const WS_MINIMIZEBOX As Integer = &H20000
	Private Const GWL_WNDPROC As Short = (-4)
	
	Private Declare Function CallWindowProc Lib "user32"  Alias "CallWindowProcA"(ByVal lpPrevWndFunc As Integer, ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
	Private Const WM_SYSCOMMAND As Integer = &H112
	Private Const SC_CLOSE As Integer = &HF060
	Private Const WM_CLOSE As Integer = &H10
	Private Const WM_DESTROY As Integer = &H2
	
	'Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, lParam As Any) As Long
	
	
	Dim mlOldproc As Integer
	
	Private Function WndProc(ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
		Select Case Msg
			Case WM_SYSCOMMAND
				If wParam = SC_CLOSE Then
					SendMessage(hWnd, WM_CLOSE, 0, 0)
				End If
			Case WM_DESTROY
				SetWindowLong(hWnd, GWL_WNDPROC, mlOldproc)
		End Select
		WndProc = CallWindowProc(mlOldproc, hWnd, Msg, wParam, lParam)
	End Function

	'Public Sub subclass(ByRef hWnd As Integer)
	'	Dim lStyle As Integer
	'	lStyle = GetWindowLong(hWnd, GWL_STYLE)
	'	lStyle = lStyle Or WS_MINIMIZEBOX Or WS_SYSMENU
	'	SetWindowLong(hWnd, GWL_STYLE, lStyle)
	'	'UPGRADE_WARNING: 为 AddressOf WndProc 添加委托 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"”
	'	mlOldproc = SetWindowLong(hWnd, GWL_WNDPROC, AddressOf WndProc)
	'End Sub

	'设置窗口为最顶层
	'函数:SetTopWindow
	'参数:Winwnd   要设置为最顶层窗口的HWND
	'返回值:
	'例子：
	Public Function SetTopWindow(ByRef WinWnd As Integer) As Object
		'    SetWindowPos WinWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE Or SWP_NOMOVE
		SetWindowPos(WinWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE Or SWP_NOMOVE)
	End Function
End Module