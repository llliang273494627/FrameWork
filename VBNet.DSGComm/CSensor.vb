Option Strict Off
Option Explicit On
Friend Class CSensor
	
    Private WithEvents IOC As IOCard
	Event onChange(ByRef state As Boolean)
	Public m_IOPort As Short
	Private m_State As Boolean

	Public Sub New()
		MyBase.New()
		IOC = oIOCard
	End Sub

	Private Sub IOC_EventTest(ByRef testPort As System.Array) Handles IOC.EventTest
		If m_State <> testPort(m_IOPort) Then
			m_State = testPort(m_IOPort)
			RaiseEvent onChange(m_State)
		End If
	End Sub
	
	
	
	Public WriteOnly Property IOPort() As Short
		Set(ByVal Value As Short)
			Dim col As Collection
			m_IOPort = Value
			col = IOC.getState
			'UPGRADE_WARNING: 未能解析对象 col() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			m_State = col.Item(m_IOPort + 1)
		End Set
	End Property
	
	
	'得到当前状态
    Public ReadOnly Property state() As Object
        Get
            state = m_State
        End Get
    End Property
End Class