Option Strict Off
Option Explicit On
Friend Class CSensor
	
	Private WithEvents IOC As IOControl.IOCard
	Event onChange(ByRef state As Boolean)
	Public m_IOPort As Short
	Private m_State As Boolean
	
	'UPGRADE_NOTE: Class_Initialize �������� Class_Initialize_Renamed�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"��
	Private Sub Class_Initialize_Renamed()
		IOC = oIOCard
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
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
			'UPGRADE_WARNING: δ�ܽ������� IOC.getState ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			col = IOC.getState
			'UPGRADE_WARNING: δ�ܽ������� col() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			m_State = col.Item(m_IOPort + 1)
		End Set
	End Property
	
	
	'�õ���ǰ״̬
	Public ReadOnly Property state() As Object
		Get
			'UPGRADE_WARNING: δ�ܽ������� state ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			state = m_State
		End Get
	End Property
End Class