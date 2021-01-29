Option Strict Off
Option Explicit On
Public Class CVT520

    Private m_CommPort As Short

    Private m_ComSettings As String

    Private m_OpenPort As Boolean

    Private m_Result As String

    Private m_TireIDResult As String

    Private m_TireMdlResult As String
    Private m_TirePreResult As String
    Private m_TireTempResult As String
    Private m_TireBatteryResult As String
    Private m_TireAcSpeedResult As String

    Private m_Status As Short

    Private WithEvents m_Comm As IO.Ports.SerialPort

    Dim m_Form As System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        m_Comm = Form1.SerialPort1
        OpenPort = False
    End Sub

    Public Property CommPort() As Short
        Get '���ں�
            CommPort = m_CommPort
        End Get
        Set(ByVal Value As Short)
            m_CommPort = Value
        End Set
    End Property

    Public Property ComSettings() As String
        Get '���ڲ���
            ComSettings = m_ComSettings
        End Get
        Set(ByVal Value As String)
            m_ComSettings = Value
        End Set
    End Property

    Public Property OpenPort() As Boolean
        Get '���ڿ���
            OpenPort = m_OpenPort
        End Get
        Set(ByVal Value As Boolean)
            On Error Resume Next
            If m_OpenPort = Value Then
            Else
                SerialPortOnline(m_Comm, CommPort, m_ComSettings)
            End If
        End Set
    End Property

    Public ReadOnly Property Status() As Short
        Get '��VT520�����󷵻�״̬
            Status = m_Status
        End Get
    End Property

    Public ReadOnly Property Result() As String
        Get '���ز�������ַ���
            Result = m_Result
        End Get
    End Property

    Public ReadOnly Property TireIDResult() As Object
        Get '���ز�����̥ID�ַ���
            'UPGRADE_WARNING: δ�ܽ������� TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
            TireIDResult = m_TireIDResult
        End Get
    End Property

    Public ReadOnly Property TireTempResult() As Object
        Get '�¶�
            'UPGRADE_WARNING: δ�ܽ������� TireTempResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
            TireTempResult = m_TireTempResult
        End Get
    End Property
    Public ReadOnly Property TirePreResult() As Object
        Get 'ѹ��
            'UPGRADE_WARNING: δ�ܽ������� TirePreResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
            TirePreResult = m_TirePreResult
        End Get
    End Property
    Public ReadOnly Property TireAcSpeedResult() As Object
        Get '���ٶ�
            'UPGRADE_WARNING: δ�ܽ������� TireAcSpeedResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
            TireAcSpeedResult = m_TireAcSpeedResult
        End Get
    End Property
    Public ReadOnly Property TireMdlResult() As Object
        Get 'ģʽ
            'UPGRADE_WARNING: δ�ܽ������� TireMdlResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
            TireMdlResult = m_TireMdlResult
        End Get
    End Property
    Public ReadOnly Property TireBatteryResult() As Object
        Get '���
            'UPGRADE_WARNING: δ�ܽ������� TireBatteryResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
            TireBatteryResult = m_TireBatteryResult
        End Get
    End Property


    '******************************************************************************
    '** �� �� ����Start
    '** ��    �룺
    '** ��    ����
    '** ������������ʼ���
    '** ȫ�ֱ�����
    '** ����ģ�飺
    '** ��    �ߣ����
    '** ��    �䣺tonylicao@163.com.cn
    '** ��    �ڣ�2009-03-03
    '** �� �� �ߣ�
    '** ��    �ڣ�
    '** ��    ����1.0
    '******************************************************************************
    Public Sub Start(ByRef TestType As String, Optional ByRef portNum As Short = 0, Optional ByRef state As Boolean = False)
        On Error Resume Next
        Dim byt(7) As Byte
        Select Case TestType
            Case "Comm"
                'FF 05 00 01 FF 00 C8 24
                byt(0) = &HFF
                byt(1) = &H5
                byt(2) = &H0
                byt(3) = &H1
                byt(4) = &HFF
                byt(5) = &H0
                byt(6) = &HC8
                byt(7) = &H24
                m_Comm.Write(byt, 0, byt.Length)
            Case "IO"
                Call OutputController(portNum, state)
            Case Else
                MsgBox("��Ч��TestType����")
        End Select
        DelayTime(100)
    End Sub

    'Add by ZCJ 2014-05-08
    Public Sub SendProNum(ByRef proNum As Short)
        On Error Resume Next

        '���ó���ţ���9���ֽ�Ϊ����ţ���������ֽ�ΪУ��
        'FF 10 02 00 00 01 02 00 00 CD F4

        'FF 10 02 00 00 01 02 01 00 CC 64

        'FF 10 02 00 00 01 02 02 00 CC 94
        'FF 10 02 00 00 01 02 03 00 CD 04
        'FF 10 02 00 00 01 02 04 00 CF 34

        'FF 10 02 00 00 01 02 05 00 CE A4
        'FF 10 02 00 00 01 02 06 00 CE 54
        'FF 10 02 00 00 01 02 07 00 CF C4
        'FF 10 02 00 00 01 02 08 00 CA 34
        'FF 10 02 00 00 01 02 09 00 CB A4

        Dim chByte(10) As Byte

        chByte(0) = &HFF
        chByte(1) = &H10
        chByte(2) = &H2
        chByte(3) = &H0
        chByte(4) = &H0
        chByte(5) = &H1
        chByte(6) = &H2

        'Add by ZCJ 2013-06-25 �������ϳ���Ŵ�0��ʼ����
        proNum = proNum - 1

        If proNum = 0 Then
            chByte(7) = &H0
            chByte(8) = &H0
            chByte(9) = &HCD
            chByte(10) = &HF4
        ElseIf proNum = 1 Then
            chByte(7) = &H1
            chByte(8) = &H0
            chByte(9) = &HCC
            chByte(10) = &H64
        ElseIf proNum = 2 Then
            chByte(7) = &H2
            chByte(8) = &H0
            chByte(9) = &HCC
            chByte(10) = &H94
        ElseIf proNum = 3 Then
            chByte(7) = &H3
            chByte(8) = &H0
            chByte(9) = &HCD
            chByte(10) = &H4
        ElseIf proNum = 4 Then
            chByte(7) = &H4
            chByte(8) = &H0
            chByte(9) = &HCF
            chByte(10) = &H34
        ElseIf proNum = 5 Then
            chByte(7) = &H5
            chByte(8) = &H0
            chByte(9) = &HCE
            chByte(10) = &HA4
        ElseIf proNum = 6 Then
            chByte(7) = &H6
            chByte(8) = &H0
            chByte(9) = &HCE
            chByte(10) = &H54
        ElseIf proNum = 7 Then
            chByte(7) = &H7
            chByte(8) = &H0
            chByte(9) = &HCF
            chByte(10) = &HC4
        ElseIf proNum = 8 Then
            chByte(7) = &H8
            chByte(8) = &H0
            chByte(9) = &HCA
            chByte(10) = &H34
        ElseIf proNum = 9 Then
            chByte(7) = &H9
            chByte(8) = &H0
            chByte(9) = &HCB
            chByte(10) = &HA4
        End If
        m_Comm.Write(chByte, 0, chByte.Length)
        DelayTime(30)

    End Sub

    '******************************************************************************
    '** �� �� ����ResetResult
    '** ��    �룺
    '** ��    ����
    '** ��������������ϴβ������
    '** ȫ�ֱ�����
    '** ����ģ�飺
    '** ��    �ߣ����
    '** ��    �䣺tonylicao@163.com.cn
    '** ��    �ڣ�2009-03-03
    '** �� �� �ߣ�
    '** ��    �ڣ�
    '** ��    ����1.0
    '******************************************************************************
    Public Sub ResetResult()
        On Error Resume Next
        'FF 05 00 02 FF 00 38 24
        m_TireIDResult = ""
        m_TireMdlResult = ""
        m_TirePreResult = ""
        m_TireTempResult = ""
        m_TireBatteryResult = ""
        m_TireAcSpeedResult = ""
        Dim byt(7) As Byte
        byt(0) = &HFF
        byt(1) = &H5
        byt(2) = &H0
        byt(3) = &H2
        byt(4) = &HFF
        byt(5) = &H0
        byt(6) = &H38
        byt(7) = &H24
        m_Comm.Write(byt, 0, byt.Length)
        Threading.Thread.Sleep(100)
    End Sub


    '******************************************************************************
    '** �� �� ����ReadResult
    '** ��    �룺
    '** ��    ����
    '** ������������ȡ�������
    '** ȫ�ֱ�����
    '** ����ģ�飺
    '** ��    �ߣ����
    '** ��    �䣺tonylicao@163.com.cn
    '** ��    �ڣ�2009-03-03
    '** �� �� �ߣ�
    '** ��    �ڣ�
    '** ��    ����1.0
    '******************************************************************************
    Public Sub ReadResult()
        On Error Resume Next
        'FF 03 00 10 00 0D 90 14
        'FF 03 00 10 00 6E D0 3D
        Dim byt(7) As Byte
        byt(0) = &HFF
        byt(1) = &H3
        byt(2) = &H0
        byt(3) = &H10
        byt(4) = &H0
        '    byt(5) = &HD
        '    byt(6) = &H90
        '    byt(7) = &H14
        byt(5) = &H6E
        byt(6) = &HD0
        byt(7) = &H3D
        m_Comm.Write(byt, 0, byt.Length)
        Threading.Thread.Sleep(100)
    End Sub


    Private Sub m_Comm_OnComm(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_Comm.DataReceived
        On Error Resume Next
        Threading.Thread.Sleep(100)
        Dim byt(m_Comm.BytesToRead - 1) As Byte
        m_Comm.Read(byt, 0, m_Comm.BytesToRead)
        If UBound(byt) = -1 Then Exit Sub
        Dim tmp As String
        Dim i As Short
        For i = 0 To UBound(byt)

            tmp = tmp & Hex(byt(i)) & " "
        Next
        Dim cbit, gbit, zbit, dbit As String
        Select Case tmp
            Case "FF 5 0 1 FF 0 C8 24 "
                m_Status = 1 '�����ɹ���״̬������Ϊ1
            Case "FF 5 0 2 FF 0 38 24 " '��ս���ɹ���״̬������Ϊ3
                m_Status = 3
            Case Else
                'If Left(tmp, 7) = "FF 3 1A" Then
                If Left(tmp, 7) = "FF 3 DC" Then
                    m_Status = 2 '�����ȡ�ɹ���״̬������Ϊ2
                    m_Result = tmp

                    '                m_TireIDResult =  IIf(Len(Hex(byt(26))) = 2, Hex(byt(26)), "0" & Hex(byt(26))) & IIf(Len(Hex(byt(25))) = 2, Hex(byt(25)), "0" & Hex(byt(25))) & IIf(Len(Hex(byt(24))) = 2, Hex(byt(24)), "0" & Hex(byt(24))) 'ȡ��̥ID
                    gbit = IIf(Len(Hex(byt(26))) = 2, Hex(byt(26)), "0" & Hex(byt(26)))
                    zbit = IIf(Len(Hex(byt(25))) = 2, Hex(byt(25)), "0" & Hex(byt(25)))
                    cbit = IIf(Len(Hex(byt(24))) = 2, Hex(byt(24)), "0" & Hex(byt(24)))
                    dbit = IIf(Len(Hex(byt(23))) = 2, Hex(byt(23)), "0" & Hex(byt(23)))
                    m_TireIDResult = gbit & zbit & cbit & dbit

                    'ģʽ��û�а�������Ϣ
                    gbit = Chr(CInt("&H" & Hex(byt(81))))
                    zbit = Chr(CInt("&H" & Hex(byt(82))))
                    cbit = gbit & zbit
                    dbit = cBin(CInt("&H" & cbit))
                    dbit = Left(dbit, Len(dbit) - 4)
                    m_TireMdlResult = BIN_to_HEX(dbit)

                    'ѹ��ֵ
                    gbit = IIf(Len(Hex(byt(14))) = 2, Hex(byt(14)), "0" & Hex(byt(14)))
                    zbit = IIf(Len(Hex(byt(13))) = 2, Hex(byt(13)), "0" & Hex(byt(13)))
                    cbit = IIf(Len(Hex(byt(12))) = 2, Hex(byt(12)), "0" & Hex(byt(12)))
                    dbit = IIf(Len(Hex(byt(11))) = 2, Hex(byt(11)), "0" & Hex(byt(11)))
                    m_TirePreResult = CStr(CInt("&H" & gbit & zbit & cbit & dbit) / 1000)
                    '�¶�ֵ
                    gbit = IIf(Len(Hex(byt(18))) = 2, Hex(byt(18)), "0" & Hex(byt(18)))
                    zbit = IIf(Len(Hex(byt(17))) = 2, Hex(byt(17)), "0" & Hex(byt(17)))
                    'm_TireTempResult = CLng("&H" & gbit & zbit) / 10
                    'Modiy by ZCJ 2012-08-14 �¶�Ҫ����100����ȷ����������
                    m_TireTempResult = CStr(CShort(CInt("&H" & gbit & zbit) / 100))
                    '���ٶ�ֵ
                    gbit = IIf(Len(Hex(byt(22))) = 2, Hex(byt(22)), "0" & Hex(byt(22)))
                    zbit = IIf(Len(Hex(byt(21))) = 2, Hex(byt(21)), "0" & Hex(byt(21)))
                    m_TireAcSpeedResult = CStr(CInt("&H" & gbit & zbit))
                    '���״̬
                    gbit = IIf(Len(Hex(byt(31))) = 2, Hex(byt(31)), "0" & Hex(byt(31)))
                    zbit = IIf(Len(Hex(byt(32))) = 2, Hex(byt(32)), "0" & Hex(byt(32)))
                    If gbit & zbit <> "4F4B" Then
                        m_TireBatteryResult = "Low"
                    Else
                        m_TireBatteryResult = "OK"
                    End If
                Else
                    m_Status = 0 '����ʧ�ܣ�״̬������Ϊ0
                End If
        End Select
        '    Debug.Print "a" & tmp & "b"

    End Sub

    Function cBin(ByVal N As Integer) As String
        On Error Resume Next
        Do
            cBin = N Mod 2 & cBin
            N = N \ 2
        Loop While N > 0
    End Function

    Public Function BIN_to_HEX(ByVal Bin As String) As String
        On Error Resume Next
        Dim i As Integer
        Dim H As String
        If Len(Bin) Mod 4 <> 0 Then
            Bin = New String("0", 4 - Len(Bin) Mod 4) & Bin
        End If

        For i = 1 To Len(Bin) Step 4
            Select Case Mid(Bin, i, 4)
                Case "0000" : H = H & "0"
                Case "0001" : H = H & "1"
                Case "0010" : H = H & "2"
                Case "0011" : H = H & "3"
                Case "0100" : H = H & "4"
                Case "0101" : H = H & "5"
                Case "0110" : H = H & "6"
                Case "0111" : H = H & "7"
                Case "1000" : H = H & "8"
                Case "1001" : H = H & "9"
                Case "1010" : H = H & "A"
                Case "1011" : H = H & "B"
                Case "1100" : H = H & "C"
                Case "1101" : H = H & "D"
                Case "1110" : H = H & "E"
                Case "1111" : H = H & "F"
            End Select
        Next i
        While Left(H, 1) = "0"
            H = Right(H, Len(H) - 1)
        End While
        BIN_to_HEX = H
    End Function

    Private Sub DelayTime(ByRef LngTime As Integer)
        Threading.Thread.Sleep(LngTime)
    End Sub


    '******************************************************************************
    '** �� �� ����OutputController
    '** ��    �룺portNum�����˿ںţ�0-15����state��������״̬��true=����false=�أ�
    '** ��    ����
    '** ����������IO���������
    '** ȫ�ֱ�����
    '** ��    �ߣ�yangshuai
    '** ��    �䣺shuaigoplay@live.cn
    '** ��    �ڣ�2009-2-27
    '** �� �� �ߣ�
    '** ��    �ڣ�
    '** ��    ����1.0
    '******************************************************************************
    Private Sub OutputController(ByRef portNum As Short, ByRef state As Boolean)
        Debug.Print("�˿ں�:" & portNum & "״̬��" & state)
    End Sub
End Class