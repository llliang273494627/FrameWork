Option Strict Off
Option Explicit On
Module MODDriver
	Public Const MaxDev As Short = 255 ' max. # of devices
	Public Const MaxDevNameLen As Short = 49 ' original is 64; max lenght of device name
	Public Const MaxGroup As Short = 6
	Public Const MaxPort As Short = 3
	Public Const MaxszErrMsgLen As Short = 80
	Public Const MAX_DEVICE_NAME_LEN As Short = 64
	Public Const MAX_DRIVER_NAME_LEN As Short = 16
	Public Const MAX_DAUGHTER_NUM As Short = 16
	Public Const MAX_DIO_PORT As Short = 48
	Public Const MAX_AO_RANGE As Short = 16

	Public Const REMOTE As Short = 1
	Public Const REMOTE1 As Integer = REMOTE + 1 ' For PCL-818L JP7 = 5V
	Public Const REMOTE2 As Integer = REMOTE1 + 1 ' For PCL-818L JP7 =10V
	Public Const NONPROG As Short = 0
	Public Const PROG As Short = REMOTE
	Public Const INTERNAL As Short = 0
	Public Const EXTERNAL As Short = 1
	Public Const SINGLEENDD As Short = 0
	Public Const DIFFERENTIAL As Short = 1
	Public Const BIPOLAR As Short = 0
	Public Const UNIPOLAR As Short = 1
	Public Const PORTA As Short = 0
	Public Const PORTB As Short = 1
	Public Const PORTC As Short = 2
	Public Const INPORT As Short = 0
	Public Const OUTPORT As Short = 1

	Public Const AAC As Integer = &H0 'Advantech
	Public Const MB As Integer = &H1000 'Keithley/MetraByte
	Public Const BB As Integer = &H2000 'Burr Brown
	Public Const GRAYHILL As Integer = &H3000 'Grayhill
	Public Const KGS As Integer = &H4000

	'****************************************************************************
	'    Define DAS I/O CardType ID.
	'****************************************************************************
	Public Const NONE As Integer = &H0 ' not available

	'Advantech CardType ID
	Public Const BD_DEMO As Boolean = AAC Or &H0 ' demo board
	Public Const BD_PCL711 As Boolean = AAC Or &H1 ' PCL-711 board
	Public Const BD_PCL812 As Boolean = AAC Or &H2 ' PCL-812 board
	Public Const BD_PCL812PG As Boolean = AAC Or &H3 ' PCL-812PG board
	Public Const BD_PCL718 As Boolean = AAC Or &H4 ' PCL-718 board
	Public Const BD_PCL818 As Boolean = AAC Or &H5 ' PCL-818 board
	Public Const BD_PCL814 As Boolean = AAC Or &H6 ' PCL-814 board
	Public Const BD_PCL720 As Boolean = AAC Or &H7 ' PCL-722 board
	Public Const BD_PCL722 As Boolean = AAC Or &H8 ' PCL-720 board
	Public Const BD_PCL724 As Boolean = AAC Or &H9 ' PCL-724 board
	Public Const BD_AD4011 As Boolean = AAC Or &HA ' ADAM 4011 Module
	Public Const BD_AD4012 As Boolean = AAC Or &HB ' ADAM 4012 Module
	Public Const BD_AD4013 As Boolean = AAC Or &HC ' ADAM 4013 Module
	Public Const BD_AD4021 As Boolean = AAC Or &HD ' ADAM 4021 Module
	Public Const BD_AD4050 As Boolean = AAC Or &HE ' ADAM 4050 Module
	Public Const BD_AD4060 As Boolean = AAC Or &HF ' ADAM 4060 Module
	Public Const BD_PCL711B As Boolean = AAC Or &H10 ' PCL-711B
	Public Const BD_PCL818H As Boolean = AAC Or &H11 ' PCL-818H
	Public Const BD_PCL814B As Boolean = AAC Or &H12 ' PCL-814B
	Public Const BD_PCL816 As Boolean = AAC Or &H13 ' PCL-816
	Public Const BD_814_DIO_1 As Boolean = AAC Or &H14 ' PCL-816/814B 8255 DIO module
	Public Const BD_814_DA_1 As Boolean = AAC Or &H15 ' PCL-816/814B 12 bit D/A module
	Public Const BD_816_DA_1 As Boolean = AAC Or &H16 ' PCL-816/814B 16 bit D/A module
	Public Const BD_PCL830 As Boolean = AAC Or &H17 ' PCL-830 9513A Counter Card
	Public Const BD_PCL726 As Boolean = AAC Or &H18 ' PCL-726 D/A card
	Public Const BD_PCL727 As Boolean = AAC Or &H19 ' PCL-727 D/A card
	Public Const BD_PCL728 As Boolean = AAC Or &H1A ' PCL-728 D/A card
	Public Const BD_AD4052 As Boolean = AAC Or &H1B ' ADAM 4052 Module
	Public Const BD_AD4014D As Boolean = AAC Or &H1C ' ADAM 4014D Module
	Public Const BD_AD4017 As Boolean = AAC Or &H1D ' ADAM 4017 Module
	Public Const BD_AD4080D As Boolean = AAC Or &H1E ' ADAM 4080D Module
	Public Const BD_PCL721 As Boolean = AAC Or &H1F ' PCL-721 32-bit Digital in
	Public Const BD_PCL723 As Boolean = AAC Or &H20 ' PCL-723 24-bit Digital in
	Public Const BD_PCL818L As Boolean = AAC Or &H21 ' PCL-818L
	Public Const BD_PCL818HG As Boolean = AAC Or &H22 ' PCL-818HG
	Public Const BD_PCL1800 As Boolean = AAC Or &H23 ' PCL-1800
	Public Const BD_PAD71A As Boolean = AAC Or &H24 ' PCIA-71A
	Public Const BD_PAD71B As Boolean = AAC Or &H25 ' PCIA-71B
	Public Const BD_PCR420 As Boolean = AAC Or &H26 ' PCR-420
	Public Const BD_PCL731 As Boolean = AAC Or &H27 ' PCL-731 48-bit Digital I/O card
	Public Const BD_PCL730 As Boolean = AAC Or &H28 ' PCL-730 board
	Public Const BD_PCL813 As Boolean = AAC Or &H29 ' PCL-813 32-channel A/D card
	Public Const BD_PCL813B As Boolean = AAC Or &H2A ' PCL-813B 32-channel A/D card
	Public Const BD_PCL818HD As Boolean = AAC Or &H2B ' PCL-818HD
	Public Const BD_PCL725 As Boolean = AAC Or &H2C ' PCL-725 digital I/O card
	Public Const BD_PCL732 As Boolean = AAC Or &H2D ' PCL-732 high speed DIO card
	Public Const BD_AD4018 As Boolean = AAC Or &H2E ' ADAM 4018 Module
	Public Const BD_814_TC_1 As Boolean = AAC Or &H2F ' PCL-816/814B 16 bit TC module
	Public Const BD_PAD71C As Boolean = AAC Or &H30 ' PCIA-71C
	Public Const BD_AD4024 As Boolean = AAC Or &H31 ' ADAM 4024
	Public Const BD_AD5017 As Boolean = AAC Or &H32 ' ADAM 5017
	Public Const BD_AD5018 As Boolean = AAC Or &H33 ' ADAM 5018
	Public Const BD_AD5024 As Boolean = AAC Or &H34 ' ADAM 5024
	Public Const BD_AD5051 As Boolean = AAC Or &H35 ' ADAM 5051
	Public Const BD_AD5060 As Boolean = AAC Or &H36 ' ADAM 5060
	Public Const BD_PCM3718 As Boolean = AAC Or &H37 ' PCM-3718
	Public Const BD_PCM3724 As Boolean = AAC Or &H38 ' PCM-3724
	Public Const BD_MIC2718 As Boolean = AAC Or &H39 ' MIC-2718
	Public Const BD_MIC2728 As Boolean = AAC Or &H3A ' MIC-2728
	Public Const BD_MIC2730 As Boolean = AAC Or &H3B ' MIC-2730
	Public Const BD_MIC2732 As Boolean = AAC Or &H3C ' MIC-2732
	Public Const BD_MIC2750 As Boolean = AAC Or &H3D ' MIC-2750
	Public Const BD_MIC2752 As Boolean = AAC Or &H3E ' MIC-2752
	Public Const BD_PCL733 As Boolean = AAC Or &H3F ' PCL-733
	Public Const BD_PCL734 As Boolean = AAC Or &H40 ' PCL-734
	Public Const BD_PCL735 As Boolean = AAC Or &H41 ' PCL-735
	Public Const BD_AD4018M As Boolean = AAC Or &H42 ' ADAM 4018M Module
	Public Const BD_AD4080 As Boolean = AAC Or &H43 ' ADAM 4080 Module
	Public Const BD_PCL833 As Boolean = AAC Or &H44 ' PCL-833
	Public Const BD_PCA6157 As Boolean = AAC Or &H45 ' PCA-6157
	Public Const BD_PCA6149 As Boolean = AAC Or &H46 ' PCA-6149
	Public Const BD_PCA6147 As Boolean = AAC Or &H47 ' PCA-6147
	Public Const BD_PCA6137 As Boolean = AAC Or &H48 ' PCA-6137
	Public Const BD_PCA6145 As Boolean = AAC Or &H49 ' PCA-6145
	Public Const BD_PCA6144 As Boolean = AAC Or &H4A ' PCA-6144
	Public Const BD_PCA6143 As Boolean = AAC Or &H4B ' PCA-6143
	Public Const BD_PCA6134 As Boolean = AAC Or &H4C ' PCA-6134
	Public Const BD_AD5056 As Boolean = AAC Or &H4D ' ADAM 5056
	Public Const BD_DN5017 As Boolean = AAC Or &H4E ' ADAM 5017
	Public Const BD_DN5018 As Boolean = AAC Or &H4F ' ADAM 5018
	Public Const BD_DN5024 As Boolean = AAC Or &H50 ' ADAM 5024
	Public Const BD_DN5051 As Boolean = AAC Or &H51 ' ADAM 5051
	Public Const BD_DN5056 As Boolean = AAC Or &H52 ' ADAM 5056
	Public Const BD_DN5060 As Boolean = AAC Or &H53 ' ADAM 5060
	Public Const BD_PCL836 As Boolean = AAC Or &H54 ' PCL-836
	Public Const BD_PCL841 As Boolean = AAC Or &H55 ' PCL-841
	Public Const BD_DN5050 As Boolean = AAC Or &H56 ' ADAM 5050
	Public Const BD_DN5052 As Boolean = AAC Or &H57 ' ADAM 5052
	Public Const BD_AD5050 As Boolean = AAC Or &H58 ' ADAM 5050 for RS-485
	Public Const BD_AD5052 As Boolean = AAC Or &H59 ' ADAM 5052 for RS-485
	Public Const BD_PCM3730 As Boolean = AAC Or &H5A ' PCM-3730
	Public Const BD_AD4011D As Boolean = AAC Or &H5B ' ADAM 4011D
	Public Const BD_AD4016 As Boolean = AAC Or &H5C ' ADAM 4016
	Public Const BD_AD4053 As Boolean = AAC Or &H5D ' ADAM 4053
	Public Const BD_PCI1750 As Boolean = AAC Or &H5E ' PCI-1750
	Public Const BD_PCI1751 As Boolean = AAC Or &H5F ' PCI-1751
	Public Const BD_PCI1710 As Boolean = AAC Or &H60 ' PCI-1710
	Public Const BD_PCI1712 As Boolean = AAC Or &H61 ' PCI-1712
	Public Const BD_AD5068 As Boolean = AAC Or &H62 ' ADAM 5068
	Public Const BD_AD5013 As Boolean = AAC Or &H63 ' ADAM 5013
	Public Const BD_AD5017H As Boolean = AAC Or &H64 ' ADAM 5017H
	Public Const BD_AD5080 As Boolean = AAC Or &H65 ' ADAM 5080
	Public Const BD_MIC2760 As Boolean = AAC Or &H66 ' MIC-2760
	Public Const BD_PCI1710HG As Boolean = AAC Or &H67 ' PCI-1710HG
	Public Const BD_PCI1713 As Boolean = AAC Or &H68 ' PCI-1713
	Public Const BD_PCI1753 As Boolean = AAC Or &H69 ' PCI-1753
	Public Const BD_PCI1760 As Boolean = AAC Or &H6A ' PCI-1760
	Public Const BD_PCI1720 As Boolean = AAC Or &H6B ' PCI-1720
	Public Const BD_PCL752 As Boolean = AAC Or &H6C ' PCL-752
	Public Const BD_PCM3718H As Boolean = AAC Or &H6D ' PCM-3718H
	Public Const BD_PCM3718HG As Boolean = AAC Or &H6E ' PCM-3718HG
	Public Const BD_DN5068 As Boolean = AAC Or &H6F ' ADAM 5068 for Device Net
	Public Const BD_DN5013 As Boolean = AAC Or &H70 ' ADAM 5013 for Device Net
	Public Const BD_DN5017H As Boolean = AAC Or &H71 ' ADAM 5017H for Device Net
	Public Const BD_DN5080 As Boolean = AAC Or &H72 ' ADAM 5080(unavailable)  for Device Net
	Public Const BD_PCI1711 As Boolean = AAC Or &H73 ' PCI-1711
	'\\\\\\\\\\\\\\\\\\\\\\\\\\ V2.0b //////////////////////////////
	Public Const BD_PCI1711L As Boolean = AAC Or &H75 ' PCI-1711
	'////////////////////////// V2.0b //////////////////////////////
	Public Const BD_PCI1716 As Boolean = AAC Or &H74 ' PCI-1716
	Public Const BD_PCI1731 As Boolean = AAC Or &H75 ' PCI-1731
	Public Const BD_AD5051D As Boolean = AAC Or &H76 ' ADAM 5051D
	Public Const BD_AD5056D As Boolean = AAC Or &H77 ' ADAM 5056D
	Public Const BD_DN5051D As Boolean = AAC Or &H78 ' ADAM 5051D for Device Net
	Public Const BD_DN5056D As Boolean = AAC Or &H79 ' ADAM 5056D for Device Net
	Public Const BD_SIMULATE As Boolean = AAC Or &H7A ' Simulate IO
	Public Const BD_PCI1754 As Boolean = AAC Or &H7B ' PCI-1754
	Public Const BD_PCI1752 As Boolean = AAC Or &H7C ' PCI-1754
	Public Const BD_PCI1756 As Boolean = AAC Or &H7D ' PCI-1754
	Public Const BD_PCL839 As Boolean = AAC Or &H7E ' PCL-839
	Public Const BD_PCM3725 As Boolean = AAC Or &H7F ' PCM-3725
	Public Const BD_PCI1762 As Boolean = AAC Or &H80 ' PCI-1762
	Public Const BD_PCI1721 As Boolean = AAC Or &H81 ' PCI-1721
	Public Const BD_PCI1761 As Boolean = AAC Or &H82 ' PCI-1761
	Public Const BD_PCI1723 As Boolean = AAC Or &H83 ' PCI-1723
	Public Const BD_AD4019 As Boolean = AAC Or &H84 ' ADAM 4019 Module
	Public Const BD_AD5055 As Boolean = AAC Or &H85 ' ADAM 5055 Module
	Public Const BD_AD4015 As Boolean = AAC Or &H86 ' ADAM 4015 Module
	Public Const BD_PCI1730 As Boolean = AAC Or &H87 ' PCI-1730
	Public Const BD_PCI1733 As Boolean = AAC Or &H88 ' PCI-1733
	Public Const BD_PCI1734 As Boolean = AAC Or &H89 ' PCI-1734
	Public Const BD_MIC2750A As Boolean = AAC Or &H8A ' MIC-2750A
	Public Const BD_MIC2718A As Boolean = AAC Or &H8B ' MIC-2718A
	Public Const BD_AD4017P As Boolean = AAC Or &H8C ' ADAM 4017P Module
	Public Const BD_AD4051 As Boolean = AAC Or &H8D ' ADAM 4051 Module
	Public Const BD_AD4055 As Boolean = AAC Or &H8E ' ADAM 4055 Module
	Public Const BD_AD4018P As Boolean = AAC Or &H8F ' ADAM 4018P Module
	Public Const BD_PCI1710L As Boolean = AAC Or &H90 ' PCI-1710L
	Public Const BD_PCI1710HGL As Boolean = AAC Or &H91 ' PCI-1710HGL
	Public Const BD_AD4068 As Boolean = AAC Or &H92 ' ADAM 4068
	Public Const BD_PCM3712 As Boolean = AAC Or &H93 ' PCM-3712
	Public Const BD_PCM3723 As Boolean = AAC Or &H94 ' PCM-3723

	'\\\\\\\\\\\\\\\\\\\ V2.0B /////////////////////
	Public Const BD_PCI1780 As Boolean = AAC Or &H95 ' PCI-1780
	Public Const BD_CPCI3756 As Boolean = AAC Or &H96 ' CPCI-3756
	'//////////////////// V2.0B \\\\\\\\\\\\\\\\\\\\\
	'\\\\\\\\\\\\\\\\\\\ V2.0C ////////////////////
	Public Const BD_PCI1755 As Boolean = AAC Or &H97 ' PCI-1755
	Public Const BD_PCI1714 As Boolean = AAC Or &H98 ' PCI-1714
	'\\\\\\\\\\\\\\\\\\\ V2.0C ////////////////////

	'\\\\\\\\\\\\\\\\\\\ V2.0C ////////////////////
	Public Const BD_PCI1757 As Boolean = AAC Or &H99 ' PCI-1757
	'\\\\\\\\\\\\\\\\\\\ V2.0C ////////////////////

	'\\\\\\\\\\\\\\\\\\\ V2.1a /////////////////////
	Public Const BD_MIC3716 As Boolean = AAC Or &H9A ' MIC-3716
	Public Const BD_MIC3761 As Boolean = AAC Or &H9B ' MIC-3761
	Public Const BD_MIC3753 As Boolean = AAC Or &H9C ' MIC-3753
	Public Const BD_MIC3780 As Boolean = AAC Or &H9D ' MIC-3780
	'///////////////////// V2.1a ////////////////////

	Public Const BD_PCI1724 As Boolean = AAC Or &H9E ' PCI-1724
	Public Const BD_AD4015T As Boolean = AAC Or &H9F ' ADAM 4015T Module
	Public Const BD_UNO2052 As Boolean = AAC Or &HA0 ' UNO  2052 Module
	Public Const BD_PCI1680 As Boolean = AAC Or &HA1 ' PCI-1680

	'\\\\\\\\\\\\\\\\\\\ V2.2 /////////////////////
	Public Const BD_PCL839P As Boolean = AAC Or &HA2 ' PCI-839+
	Public Const BD_PCI1758UDIO As Boolean = AAC Or &HA8 ' PCI-1758UDIO
	Public Const BD_PCI1758UDI As Boolean = AAC Or &HA3 ' PCI-1758UDI
	Public Const BD_PCI1758UDO As Boolean = AAC Or &HA4 ' PCI-1758UDO
	Public Const BD_PCI1747 As Boolean = AAC Or &HA5 ' PCI-1747
	Public Const BD_PCM3780 As Boolean = AAC Or &HA6 ' PCM-3780
	Public Const BD_MIC3747 As Boolean = AAC Or &HA7 ' MIC-3747
	Public Const BD_PCI1712L As Boolean = AAC Or &HA9 ' PCI-1712L
	Public Const BD_AD4056S As Boolean = AAC Or &HAA ' ADAM 4056S Module
	Public Const BD_AD4056SO As Boolean = AAC Or &HAB ' ADAM 4056SO Module
	Public Const BD_PCI1763UP As Boolean = AAC Or &HAC ' PCI-1763UP
	Public Const BD_PCI1736UP As Boolean = AAC Or &HAD ' PCI-1736UP
	Public Const BD_PCI1714UL As Boolean = AAC Or &HAE ' PCI-1714UL
	Public Const BD_MIC3714 As Boolean = AAC Or &HAF ' MIC-3714
	Public Const BD_AD5069 As Boolean = AAC Or &HB0 ' ADAM 5069 Module
	Public Const BD_PCM3718HO As Boolean = AAC Or &HB1 ' PCM-3718HO
	Public Const BD_PCI1741U As Boolean = AAC Or &HB3 ' PCI-1741U
	Public Const BD_MIC3723 As Boolean = AAC Or &HB4 ' MIC-3723
	Public Const BD_PCI1718HDU As Boolean = AAC Or &HB5 ' PCI-1718HDU
	Public Const BD_MIC3758DIO As Boolean = AAC Or &HB6 ' MIC-3758DIO
	Public Const BD_PCI1727U As Boolean = AAC Or &HB7 ' PCI-1727U
	Public Const BD_PCI1718HGU As Boolean = AAC Or &HB8 ' PCI-1718HGU
	'///////////////////// V2.2 ////////////////////

	Public Const BD_PCI1715U As Boolean = AAC Or &HB9 ' PCI-1715U
	Public Const BD_PCI1716L As Boolean = AAC Or &HBA ' PCI-1716L
	Public Const BD_PCI1735U As Boolean = AAC Or &HBB ' PCI-1735U

	Public Const BD_USB4711 As Boolean = AAC Or &HBC ' USB-4711
	Public Const BD_PCI1737U As Boolean = AAC Or &HBD ' PCI-1737U
	Public Const BD_PCI1739U As Boolean = AAC Or &HBE ' PCI-1739U
	Public Const BD_AD4069 As Boolean = AAC Or &HBF ' ADAM 4069 Module
	Public Const BD_PCI1742U As Boolean = AAC Or &HC0 ' PCI-1742U
	Public Const BD_AD4117 As Boolean = AAC Or &HC1 ' ADAM 4117 Module
	Public Const BD_AD4118 As Boolean = AAC Or &HC2 ' ADAM 4118 Module
	Public Const BD_AD4150 As Boolean = AAC Or &HC3 ' ADAM 4150 Module
	Public Const BD_AD4168 As Boolean = AAC Or &HC4 ' ADAM 4168 Module
	Public Const BD_AD4022T As Boolean = AAC Or &HC5 ' ADAM 4022T Module
	Public Const BD_USB4718 As Boolean = AAC Or &HC6 ' USB-4718
	Public Const BD_MIC3755 As Boolean = AAC Or &HC7 ' MIC-3755
	Public Const BD_USB4761 As Boolean = AAC Or &HC8 ' USB-4761
	Public Const BD_AD4019P As Boolean = AAC Or &HC9 ' ADAM 4019 Plus Module
	Public Const BD_AD5056S As Boolean = AAC Or &HCA ' ADAM 5056S Module
	Public Const BD_AD5056SO As Boolean = AAC Or &HCB ' ADAM 5056SO Module
	Public Const BD_PCI1784 As Boolean = AAC Or &HCC ' PCI-1784
	Public Const BD_USB4716 As Boolean = AAC Or &HCD ' USB4716
	Public Const BD_PCI1752U As Boolean = AAC Or &HCE ' PCI-1752U
	Public Const BD_PCI1752USO As Boolean = AAC Or &HCF ' PCI-1752USO
	Public Const BD_USB4751 As Boolean = AAC Or &HD0 ' USB4751
	Public Const BD_USB4751L As Boolean = AAC Or &HD1 ' USB4751L
	Public Const BD_USB4750 As Boolean = AAC Or &HD2 ' USB4750
	Public Const BD_MIC3713 As Boolean = AAC Or &HD3 ' MIC-3713
	Public Const BD_USB4813 As Boolean = AAC Or &HD4 ' USB4813
	Public Const BD_USB4823 As Boolean = AAC Or &HD5 ' USB4823
	Public Const BD_USB4878 As Boolean = AAC Or &HD6 ' USB4878
	Public Const BD_USB4879 As Boolean = AAC Or &HD7 ' USB4879
	Public Const BD_USB4711A As Boolean = AAC Or &HD8 'USB4711A

	Public Const BD_MICRODAC As Boolean = GRAYHILL Or &H1 ' Grayhill MicroDAC Board ID
	Public Const BD_GIA10 As Boolean = KGS Or &H1 ' KGS GIA-10 module Board ID

	'*****************************************************************************
	'    Define Expansion Board ID.
	'*****************************************************************************
	Public Const AAC_EXP As Boolean = AAC Or &H100 'Advantech expansion bits

	'define Advantech expansion board ID.
	Public Const BD_PCLD780 As Integer = &H0 ' PCLD-780
	Public Const BD_PCLD789 As Boolean = AAC_EXP Or &H0 ' PCLD-789
	Public Const BD_PCLD779 As Boolean = AAC_EXP Or &H1 ' PCLD-779
	Public Const BD_PCLD787 As Boolean = AAC_EXP Or &H2 ' PCLD-787
	Public Const BD_PCLD8115 As Boolean = AAC_EXP Or &H3 ' PCLD-8115
	Public Const BD_PCLD770 As Boolean = AAC_EXP Or &H4 ' PCLD-770
	Public Const BD_PCLD788 As Boolean = AAC_EXP Or &H5 ' PCLD-788
	Public Const BD_PCLD8710 As Boolean = AAC_EXP Or &H6 ' PCLD-8710

	'****************************************************************************
	'    Define subsection identifier
	'****************************************************************************
	Public Const DAS_AISECTION As Integer = &H1 ' A/D subsection
	Public Const DAS_AOSECTION As Integer = &H2 ' D/A sbusection
	Public Const DAS_DISECTION As Integer = &H3 ' Digital input subsection
	Public Const DAS_DOSECTION As Integer = &H4 ' Digital output sbusection
	Public Const DAS_TEMPSECTION As Integer = &H5 ' thermocouple section
	Public Const DAS_ECSECTION As Integer = &H6 ' Event count subsection
	Public Const DAS_FMSECTION As Integer = &H7 ' frequency measurement section
	Public Const DAS_POSECTION As Integer = &H8 ' pulse output section
	Public Const DAS_ALSECTION As Integer = &H9 ' alarm section
	Public Const MT_AISECTION As Integer = &HA ' monitoring A/D subsection
	Public Const MT_DISECTION As Integer = &HB ' monitoring D/I subsection

	'***************************************************************************
	'    Define Transfer Mode
	'***************************************************************************
	Public Const POLLED_MODE As Integer = &H0 ' software transfer
	Public Const DMA_MODE As Integer = &H1 ' DMA transfer
	Public Const INTERRUPT_MODE As Integer = &H2 ' Interrupt transfer

	'***************************************************************************
	'    Define Acquisition Mode
	'***************************************************************************
	Public Const FREE_RUN As Short = 0
	Public Const PRE_TRIG As Short = 1
	Public Const POST_TRIG As Short = 2
	Public Const POSITION_TRIG As Short = 3

	'***************************************************************************
	'    Define Comparator's Condition
	'***************************************************************************
	Public Const NOCONDITION As Short = 0
	Public Const LESS As Short = 1
	Public Const BETWEEN As Short = 2
	Public Const GREATER As Short = 3
	Public Const OUTSIDE As Short = 4

	'**************************************************************************
	'    Define Status Code
	'**************************************************************************
	Public Const SUCCESS As Short = 0
	Public Const DrvErrorCode As Short = 1
	Public Const KeErrorCode As Short = 100
	Public Const DnetErrorCode As Short = 200
	Public Const USBErrorCode As Short = 500
	Public Const OPCErrorCode As Short = 1000
	Public Const MemoryAllocateFailed As Integer = (DrvErrorCode + 0)
	Public Const ConfigDataLost As Integer = (DrvErrorCode + 1)
	Public Const InvalidDeviceHandle As Integer = (DrvErrorCode + 2)
	Public Const AIConversionFailed As Integer = (DrvErrorCode + 3)
	Public Const AIScaleFailed As Integer = (DrvErrorCode + 4)
	Public Const SectionNotSupported As Integer = (DrvErrorCode + 5)
	Public Const InvalidChannel As Integer = (DrvErrorCode + 6)
	Public Const InvalidGain As Integer = (DrvErrorCode + 7)
	Public Const DataNotReady As Integer = (DrvErrorCode + 8)
	Public Const InvalidInputParam As Integer = (DrvErrorCode + 9)
	Public Const NoExpansionBoardConfig As Integer = (DrvErrorCode + 10)
	Public Const InvalidAnalogOutValue As Integer = (DrvErrorCode + 11)
	Public Const ConfigIoPortFailed As Integer = (DrvErrorCode + 12)
	Public Const CommOpenFailed As Integer = (DrvErrorCode + 13)
	Public Const CommTransmitFailed As Integer = (DrvErrorCode + 14)
	Public Const CommReadFailed As Integer = (DrvErrorCode + 15)
	Public Const CommReceiveFailed As Integer = (DrvErrorCode + 16)
	Public Const CommConfigFailed As Integer = (DrvErrorCode + 17)
	Public Const CommChecksumError As Integer = (DrvErrorCode + 18)
	Public Const InitError As Integer = (DrvErrorCode + 19)
	Public Const DMABufAllocFailed As Integer = (DrvErrorCode + 20)
	Public Const IllegalSpeed As Integer = (DrvErrorCode + 21)
	Public Const ChanConflict As Integer = (DrvErrorCode + 22)
	Public Const BoardIDNotSupported As Integer = (DrvErrorCode + 23)
	Public Const FreqMeasurementFailed As Integer = (DrvErrorCode + 24)
	Public Const CreateFileFailed As Integer = (DrvErrorCode + 25)
	Public Const FunctionNotSupported As Integer = (DrvErrorCode + 26)
	Public Const LoadLibraryFailed As Integer = (DrvErrorCode + 27)
	Public Const GetProcAddressFailed As Integer = (DrvErrorCode + 28)
	Public Const InvalidDriverHandle As Integer = (DrvErrorCode + 29)
	Public Const InvalidModuleType As Integer = (DrvErrorCode + 30)
	Public Const InvalidInputRange As Integer = (DrvErrorCode + 31)
	Public Const InvalidWindowsHandle As Integer = (DrvErrorCode + 32)
	Public Const InvalidCountNumber As Integer = (DrvErrorCode + 33)
	Public Const InvalidInterruptCount As Integer = (DrvErrorCode + 34)
	Public Const InvalidEventCount As Integer = (DrvErrorCode + 35)
	Public Const OpenEventFailed As Integer = (DrvErrorCode + 36)
	Public Const InterruptProcessFailed As Integer = (DrvErrorCode + 37)
	Public Const InvalidDOSetting As Integer = (DrvErrorCode + 38)
	Public Const InvalidEventType As Integer = (DrvErrorCode + 39)
	Public Const EventTimeOut As Integer = (DrvErrorCode + 40)
	Public Const InvalidDmaChannel As Integer = (DrvErrorCode + 41)
	Public Const IntDamChannelBusy As Integer = (DrvErrorCode + 42)

	Public Const CheckRunTimeClassFailed As Integer = (DrvErrorCode + 43)
	Public Const CreateDllLibFailed As Integer = (DrvErrorCode + 44)
	Public Const ExceptionError As Integer = (DrvErrorCode + 45)
	Public Const RemoveDeviceFailed As Integer = (DrvErrorCode + 46)
	Public Const BuildDeviceListFailed As Integer = (DrvErrorCode + 47)
	Public Const NoIOFunctionSupport As Integer = (DrvErrorCode + 48)
	'/\\\\\\\\\\\\\\\\\\\ V2.0B /////////////////////
	Public Const ResourceConflict As Integer = (DrvErrorCode + 49)
	'//////////////////// V2.0B \\\\\\\\\\\\\\\\\\\\\

	'\\\\\\\\\\\\\\\\\\\ V2.1 //////////////////////
	Public Const InvalidClockSource As Integer = (DrvErrorCode + 50)
	Public Const InvalidPacerRate As Integer = (DrvErrorCode + 51)
	Public Const InvalidTriggerMode As Integer = (DrvErrorCode + 52)
	Public Const InvalidTriggerEdge As Integer = (DrvErrorCode + 53)
	Public Const InvalidTriggerSource As Integer = (DrvErrorCode + 54)
	Public Const InvalidTriggerVoltage As Integer = (DrvErrorCode + 55)
	Public Const InvalidCyclicMode As Integer = (DrvErrorCode + 56)
	Public Const InvalidDelayCount As Integer = (DrvErrorCode + 57)
	Public Const InvalidBuffer As Integer = (DrvErrorCode + 58)
	Public Const OverloadedPCIBus As Integer = (DrvErrorCode + 59)
	Public Const OverloadedInterruptRequest As Integer = (DrvErrorCode + 60)
	'/////////////////// V2.1 \\\\\\\\\\\\\\\\\\\\\\/
	'/\\\\\\\\\\\\\\\\\\\ V2.0C /////////////////////
	Public Const ParamNameNotSupported As Integer = (DrvErrorCode + 61)
	'//////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\

	'/\\\\\\\\\\\\\\\\\\\ V2.2B /////////////////////
	Public Const CheckEventFailed As Integer = (DrvErrorCode + 62)
	'//////////////////// V2.2B \\\\\\\\\\\\\\\\\\\\\

	'/\\\\\\\\\\\\\\\\\\\ V2.2C /////////////////////
	Public Const InvalidPort As Integer = (DrvErrorCode + 63)
	Public Const DaShiftBusy As Integer = (DrvErrorCode + 64)
	'//////////////////// V2.2C \\\\\\\\\\\\\\\\\\\\\
	Public Const ThermoCoupleDisconnect As Integer = (DrvErrorCode + 65)




	Public Const KeInvalidHandleValue As Integer = (KeErrorCode + 0)
	Public Const KeFileNotFound As Integer = (KeErrorCode + 1)
	Public Const KeInvalidHandle As Integer = (KeErrorCode + 2)
	Public Const KeTooManyCmds As Integer = (KeErrorCode + 3)
	Public Const KeInvalidParameter As Integer = (KeErrorCode + 4)
	Public Const KeNoAccess As Integer = (KeErrorCode + 5)
	Public Const KeUnsuccessful As Integer = (KeErrorCode + 6)
	Public Const KeConInterruptFailure As Integer = (KeErrorCode + 7)
	Public Const KeCreateNoteFailure As Integer = (KeErrorCode + 8)
	Public Const KeInsufficientResources As Integer = (KeErrorCode + 9)
	Public Const KeHalGetAdapterFailure As Integer = (KeErrorCode + 10)
	Public Const KeOpenEventFailure As Integer = (KeErrorCode + 11)
	Public Const KeAllocCommBufFailure As Integer = (KeErrorCode + 12)
	Public Const KeAllocMdlFailure As Integer = (KeErrorCode + 13)
	Public Const KeBufferSizeTooSmall As Integer = (KeErrorCode + 14)

	Public Const DNInitFailed As Integer = (DnetErrorCode + 1)
	Public Const DNSendMsgFailed As Integer = (DnetErrorCode + 2)
	Public Const DNRunOutOfMsgID As Integer = (DnetErrorCode + 3)
	Public Const DNInvalidInputParam As Integer = (DnetErrorCode + 4)
	Public Const DNErrorResponse As Integer = (DnetErrorCode + 5)
	Public Const DNNoResponse As Integer = (DnetErrorCode + 6)
	Public Const DNBusyOnNetwork As Integer = (DnetErrorCode + 7)
	Public Const DNUnknownResponse As Integer = (DnetErrorCode + 8)
	Public Const DNNotEnoughBuffer As Integer = (DnetErrorCode + 9)
	Public Const DNFragResponseError As Integer = (DnetErrorCode + 10)
	Public Const DNTooMuchDataAck As Integer = (DnetErrorCode + 11)
	Public Const DNFragRequestError As Integer = (DnetErrorCode + 12)
	Public Const DNEnableEventError As Integer = (DnetErrorCode + 13)
	Public Const DNCreateOrOpenEventError As Integer = (DnetErrorCode + 14)
	Public Const DNIORequestError As Integer = (DnetErrorCode + 15)
	Public Const DNGetEventNameError As Integer = (DnetErrorCode + 16)
	Public Const DNTimeOutError As Integer = (DnetErrorCode + 17)
	Public Const DNOpenFailed As Integer = (DnetErrorCode + 18)
	Public Const DNCloseFailed As Integer = (DnetErrorCode + 19)
	Public Const DNResetFailed As Integer = (DnetErrorCode + 20)

	Public Const USBTransmitFailed As Integer = (USBErrorCode + 1)
	Public Const USBInvalidCtrlCode As Integer = (USBErrorCode + 2)
	Public Const USBInvalidDataSize As Integer = (USBErrorCode + 3)
	Public Const USBAIChannelBusy As Integer = (USBErrorCode + 4)
	Public Const USBAIDataNotReady As Integer = (USBErrorCode + 5)

	' define user window message
	Public Const WM_USER As Integer = &H400
	Public Const WM_ATODNOTIFY As Decimal = (WM_USER + 200)
	Public Const WM_DTOANOTIFY As Decimal = (WM_USER + 201)
	Public Const WM_DIGINNOTIFY As Decimal = (WM_USER + 202)
	Public Const WM_DIGOUTNOTIFY As Decimal = (WM_USER + 203)
	Public Const WM_MTNOTIFY As Decimal = (WM_USER + 204)
	Public Const WM_CANTRANSMITCOMPLETE As Decimal = (WM_USER + 205)
	Public Const WM_CANMESSAGE As Decimal = (WM_USER + 206)
	Public Const WM_CANERROR As Decimal = (WM_USER + 207)

	' define the wParam in user window message
	Public Const AD_NONE As Short = 0 ' AD Section
	Public Const AD_TERMINATE As Short = 1
	Public Const AD_INT As Short = 2
	Public Const AD_BUFFERCHANGE As Short = 3
	Public Const AD_OVERRUN As Short = 4
	Public Const AD_WATCHDOGACT As Short = 5
	Public Const AD_TIMEOUT As Short = 6
	Public Const DA_TERMINATE As Short = 0 ' DA Section
	Public Const DA_DMATC As Short = 1
	Public Const DA_INT As Short = 2
	Public Const DA_BUFFERCHANGE As Short = 3
	Public Const DA_OVERRUN As Short = 4
	Public Const DI_TERMINATE As Short = 0 ' DI Section
	Public Const DI_DMATC As Short = 1
	Public Const DI_INT As Short = 2
	Public Const DI_BUFFERCHANGE As Short = 3
	Public Const DI_OVERRUN As Short = 4
	Public Const DI_WATCHDOGACT As Short = 5
	Public Const DO_TERMINATE As Short = 0 ' DO Section
	Public Const DO_DMATC As Short = 1
	Public Const DO_INT As Short = 2
	Public Const DO_BUFFERCHANGE As Short = 3
	Public Const DO_OVERRUN As Short = 4
	Public Const MT_ATOD As Short = 0 ' MT Section
	Public Const MT_DIGIN As Short = 1

	Public Const CAN_TRANSFER As Short = 0 ' CAN Section
	Public Const CAN_RECEIVE As Short = 1
	Public Const CAN_ERROR As Short = 2

	'****************************************************************************
	'    define thermocopule type J, K, S, T, B, R, E
	'****************************************************************************
	Public Const BTC As Short = 4
	Public Const ETC As Short = 6
	Public Const JTC As Short = 0
	Public Const KTC As Short = 1
	Public Const RTC As Short = 5
	Public Const STC As Short = 2
	Public Const TTC As Short = 3

	'****************************************************************************
	'    define  temperature scale
	'****************************************************************************
	Public Const C As Short = 0 'Celsius
	Public Const F As Short = 1 'Fahrenheit
	Public Const R As Short = 2 ' Rankine
	Public Const K As Short = 3 ' Kelvin


	'****************************************************************************
	'    define service type for COMEscape()
	'****************************************************************************
	Public Const EscapeFlushInput As Short = 1
	Public Const EscapeFlushOutput As Short = 2
	Public Const EscapeSetBreak As Short = 3
	Public Const EscapeClearBreak As Short = 4


	'****************************************************************************
	'    define  gate mode
	'****************************************************************************
	Public Const GATE_DISABLED As Short = 0 ' no gating
	Public Const GATE_HIGHLEVEL As Short = 1 ' active high level
	Public Const GATE_LOWLEVEL As Short = 2 ' active low level
	Public Const GATE_HIGHEDGE As Short = 3 ' active high edge
	Public Const GATE_LOWEDGE As Short = 4 ' active low edge


	'****************************************************************************
	'    define input mode for PCL-833
	'****************************************************************************
	Public Const DISABLE As Short = 0 ' disable mode
	Public Const ABPHASEX1 As Short = 1 ' Quadrature input X1
	Public Const ABPHASEX2 As Short = 2 ' Quadrature input X2
	Public Const ABPHASEX4 As Short = 3 ' Quadrature input X4
	Public Const TWOPULSEIN As Short = 4 ' 2 pulse input
	Public Const ONEPULSEIN As Short = 5 ' 1 pulse input

	'****************************************************************************
	'    define latch source for PCL-833
	'****************************************************************************
	Public Const SWLATCH As Short = 0 ' S/W read latch data
	Public Const INDEXINLATCH As Short = 1 ' Index-in latch data
	Public Const DI0LATCH As Short = 2 ' DI0 latch data
	Public Const DI1LATCH As Short = 3 ' DI1 latch data
	Public Const TIMERLATCH As Short = 4 ' Timer latch data
	Public Const DI2LATCH As Short = 5
	Public Const DI3LATCH As Short = 6

	'****************************************************************************
	'    define timer base mode for PCL-1784
	'****************************************************************************
	Public Const T50KHZ As Short = 0
	Public Const T5KHZ As Short = 1
	Public Const T500HZ As Short = 2
	Public Const T50HZ As Short = 3
	Public Const T5HZ As Short = 4

	'****************************************************************************
	'    define counter overflow mode for PCI-1784
	'****************************************************************************
	Public Const OVERFLOWLOCK As Short = 1
	Public Const UNDERFLOWLOCK As Short = 2
	Public Const OVERUNDERLOCK As Short = 3

	'****************************************************************************
	'    define counter indicator type for PCL-1784
	'****************************************************************************
	Public Const OVERCOMPLEVEL As Integer = &H1
	Public Const OVERCOMPPULSE As Integer = &H2
	Public Const UNDERCOMPLEVEL As Integer = &H4
	Public Const UNDERCOMPPULSE As Integer = &H8

	'****************************************************************************
	'    define timer base mode for PCL-833
	'****************************************************************************
	Public Const TPOINT1MS As Short = 0 '    0.1 ms timer base
	Public Const T1MS As Short = 1 '    1   ms timer base
	Public Const T10MS As Short = 2 '   10   ms timer base
	Public Const T100MS As Short = 3 '  100   ms timer base
	Public Const T1000MS As Short = 4 ' 1000   ms timer base

	'****************************************************************************
	'    define clock source for PCL-833
	'****************************************************************************
	Public Const SYS8MHZ As Short = 0 ' 8 MHZ system clock
	Public Const SYS4MHZ As Short = 1 ' 4 MHZ system clock
	Public Const SYS2MHZ As Short = 2 ' 2 MHZ system clock
	Public Const SYS1MHZ As Short = 3

	'****************************************************************************
	'    define cascade mode for PCL-833
	'****************************************************************************
	Public Const NOCASCADE As Short = 0 ' 24-bit(no cascade)
	Public Const CASCADE As Short = 1 ' 48-bit(CH1, CH2 cascade)

	'\\\\\\\\\\\\\\\\\\\\\\\\\\\\ V2.0b /////////////////////////////////////
	'****************************************************************************
	'     define parameters for PCI-1780
	'****************************************************************************
	' define the counter mode register parameter
	Public Const PA_MODE_ACT_HIGH_TC_PULSE As Integer = &H0
	Public Const PA_MODE_ACT_LOW_TC_PULSE As Integer = &H1
	Public Const PA_MODE_TC_TOGGLE_FROM_LOW As Integer = &H2
	Public Const PA_MODE_TC_TOGGLE_FROM_HIGH As Integer = &H3
	Public Const PA_MODE_ENABLE_OUTPUT As Integer = &H4
	Public Const PA_MODE_DISABLE_OUTPUT As Integer = &H0
	Public Const PA_MODE_COUNT_DOWN As Integer = &H0
	Public Const PA_MODE_COUNT_UP As Integer = &H8
	Public Const PA_MODE_COUNT_RISE_EDGE As Integer = &H0
	Public Const PA_MODE_COUNT_FALL_EDGE As Integer = &H80
	Public Const PA_MODE_COUNT_SRC_OUT_N_M1 As Integer = &H100 ' N_M1 means n minus 1
	Public Const PA_MODE_COUNT_SRC_CLK_N As Integer = &H200
	Public Const PA_MODE_COUNT_SRC_CLK_N_M1 As Integer = &H300
	Public Const PA_MODE_COUNT_SRC_FOUT_0 As Integer = &H400
	Public Const PA_MODE_COUNT_SRC_FOUT_1 As Integer = &H500
	Public Const PA_MODE_COUNT_SRC_FOUT_2 As Integer = &H600
	Public Const PA_MODE_COUNT_SRC_FOUT_3 As Integer = &H700
	Public Const PA_MODE_COUNT_SRC_GATE_N_M1 As Integer = &HC00
	Public Const PA_MODE_GATE_SRC_GATE_NO As Integer = &H0
	Public Const PA_MODE_GATE_SRC_OUT_N_M1 As Integer = &H1000
	Public Const PA_MODE_GATE_SRC_GATE_N As Integer = &H2000
	Public Const PA_MODE_GATE_SRC_GATE_N_M1 As Integer = &H3000
	Public Const PA_MODE_GATE_POSITIVE As Integer = &H0
	Public Const PA_MODE_GATE_NEGATIVE As Integer = &H4000
	' Counter Mode
	Public Const MODE_A As Integer = &H0
	Public Const MODE_B As Integer = &H0
	Public Const MODE_C As Integer = &H8000
	Public Const MODE_D As Integer = &H10
	Public Const MODE_E As Integer = &H10
	Public Const MODE_F As Integer = &H8010
	Public Const MODE_G As Integer = &H20
	Public Const MODE_H As Integer = &H20
	Public Const MODE_I As Integer = &H8020
	Public Const MODE_J As Integer = &H30
	Public Const MODE_K As Integer = &H30
	Public Const MODE_L As Integer = &H8030
	Public Const MODE_O As Integer = &H8040
	Public Const MODE_R As Integer = &H8050
	Public Const MODE_U As Integer = &H8060
	Public Const MODE_X As Integer = &H8070

	' define the FOUT register parameter
	Public Const PA_FOUT_SRC_EXTER_CLK As Integer = &H0
	Public Const PA_FOUT_SRC_CLK_N As Integer = &H100
	Public Const PA_FOUT_SRC_FOUT_N_M1 As Integer = &H200
	Public Const PA_FOUT_SRC_CLK_10MHZ As Integer = &H300
	Public Const PA_FOUT_SRC_CLK_1MHZ As Integer = &H400
	Public Const PA_FOUT_SRC_CLK_100KHZ As Integer = &H500
	Public Const PA_FOUT_SRC_CLK_10KHZ As Integer = &H600
	Public Const PA_FOUT_SRC_CLK_1KHZ As Integer = &H700
	'USB4751 parameter need.
	Public Const PA_FOUT_SRC_CLK_20MHZ As Integer = &H800
	Public Const PA_FOUT_SRC_CLK_5MHZ As Integer = &H900
	'/////////////////////////////// V2.0b \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
	'****************************************************************************
	'   define event type for interrupt and DMA transfer
	'****************************************************************************
	Public Const ADS_EVT_INTERRUPT As Integer = &H1 ' interrupt
	Public Const ADS_EVT_BUFCHANGE As Integer = &H2 ' buffer change
	Public Const ADS_EVT_TERMINATED As Integer = &H4 ' termination
	Public Const ADS_EVT_OVERRUN As Integer = &H8 ' overrun
	Public Const ADS_EVT_WATCHDOG As Integer = &H10 ' watchdog actived
	Public Const ADS_EVT_CHGSTATE As Integer = &H20 ' change state event
	Public Const ADS_EVT_ALARM As Integer = &H40 ' alarm event
	Public Const ADS_EVT_PORT0 As Integer = &H80 ' port 0 event
	Public Const ADS_EVT_PORT1 As Integer = &H100 ' port 1 event
	Public Const ADS_EVT_PATTERNMATCH As Integer = &H200 ' Pattern Match for DI
	Public Const ADS_EVT_COUNTER As Integer = &H201 ' Persudo event for COUNTERMATCH and COUNTEROVERFLOW
	Public Const ADS_EVT_COUNTERMATCH As Integer = &H202 ' Counter Match setting NO. for DI
	Public Const ADS_EVT_COUNTEROVERFLOW As Integer = &H203 ' Counter Overflow for DI
	Public Const ADS_EVT_STATUSCHANGE As Integer = &H204 ' Status Change for DI
	Public Const ADS_EVT_FILTER As Integer = &H205 ' Filter Event
	'\\\\\\\\\\\\\\\\\\\\\\\\\2.2/////////////////////////////
	Public Const ADS_EVT_WATCHDOG_OVERRUN As Integer = &H206 ' Watchdong Event
	'/////////////////////////2.2 \\\\\\\\\\\\\\\\\\\\\\\\\\\\

	Public Const ADS_EVT_DEVREMOVED As Integer = &H400 ' for USB device


	'****************************************************************************
	'    define event name by device number
	'****************************************************************************
	Public Const ADS_EVT_INTERRUPT_NAME As String = "ADS_EVT_INTERRUPT"
	Public Const ADS_EVT_BUFCHANGE_NAME As String = "ADS_EVT_BUFCHANGE"
	Public Const ADS_EVT_TERMINATED_NAME As String = "ADS_EVT_TERMINATED"
	Public Const ADS_EVT_OVERRUN_NAME As String = "ADS_EVT_OVERRUN"
	Public Const ADS_EVT_WATCHDOG_NAME As String = "ADS_EVT_WATCHDOG"
	Public Const ADS_EVT_CHGSTATE_NAME As String = "ADS_EVT_CHGSTATE"
	Public Const ADS_EVT_ALARM_NAME As String = "ADS_EVT_ALARM"
	Public Const ADS_EVT_PATTERNMATCH_NAME As String = "ADS_EVT_PATTERNMATCH"
	Public Const ADS_EVT_COUNTERMATCH_NAME As String = "ADS_EVT_COUNTERMATCH"
	Public Const ADS_EVT_COUNTEROVERFLOW_NAME As String = "ADS_EVT_COUNTEROVERFLOW"
	Public Const ADS_EVT_STATUSCHANGE_NAME As String = "ADS_EVT_STATUSCHANGE"
	'\\\\\\\\\\\\\\\\\\\\\\\\\2.2/////////////////////////////
	Public Const ADS_EVT_WATCHDOG_OVERRUN_NAME As String = "ADS_EVT_WATCHDOG_OVERRUN"
	'/////////////////////////2.2 \\\\\\\\\\\\\\\\\\\\\\\\\\\\
	' ****************************************************************************
	'    define FIFO size
	' ****************************************************************************
	Public Const FIFO_SIZE As Short = 512 ' 1K FIFO size (512* 2byte/each data)

	'****************************************************************************
	'    Function ID Definition
	'****************************************************************************
	Public Const FID_DeviceOpen As Short = 0
	Public Const FID_DeviceClose As Short = 1
	Public Const FID_DeviceGetFeatures As Short = 2
	Public Const FID_AIConfig As Short = 3
	Public Const FID_AIGetConfig As Short = 4
	Public Const FID_AIBinaryIn As Short = 5
	Public Const FID_AIScale As Short = 6
	Public Const FID_AIVoltageIn As Short = 7
	Public Const FID_AIVoltageInExp As Short = 8
	Public Const FID_MAIConfig As Short = 9
	Public Const FID_MAIBinaryIn As Short = 10
	Public Const FID_MAIVoltageIn As Short = 11
	Public Const FID_MAIVoltageInExp As Short = 12
	Public Const FID_TCMuxRead As Short = 13
	Public Const FID_AOConfig As Short = 14
	Public Const FID_AOBinaryOut As Short = 15
	Public Const FID_AOVoltageOut As Short = 16
	Public Const FID_AOScale As Short = 17
	Public Const FID_DioSetPortMode As Short = 18
	Public Const FID_DioGetConfig As Short = 19
	Public Const FID_DioReadPortByte As Short = 20
	Public Const FID_DioWritePortByte As Short = 21
	Public Const FID_DioReadBit As Short = 22
	Public Const FID_DioWriteBit As Short = 23
	Public Const FID_DioGetCurrentDOByte As Short = 24
	Public Const FID_DioGetCurrentDOBit As Short = 25
	Public Const FID_WritePortByte As Short = 26
	Public Const FID_WritePortWord As Short = 27
	Public Const FID_ReadPortByte As Short = 28
	Public Const FID_ReadPortWord As Short = 29
	Public Const FID_CounterEventStart As Short = 30
	Public Const FID_CounterEventRead As Short = 31
	Public Const FID_CounterFreqStart As Short = 32
	Public Const FID_CounterFreqRead As Short = 33
	Public Const FID_CounterPulseStart As Short = 34
	Public Const FID_CounterReset As Short = 35
	Public Const FID_QCounterConfig As Short = 36
	Public Const FID_QCounterConfigSys As Short = 37
	Public Const FID_QCounterStart As Short = 38
	Public Const FID_QCounterRead As Short = 39
	Public Const FID_AlarmConfig As Short = 40
	Public Const FID_AlarmEnable As Short = 41
	Public Const FID_AlarmCheck As Short = 42
	Public Const FID_AlarmReset As Short = 43
	Public Const FID_COMOpen As Short = 44
	Public Const FID_COMConfig As Short = 45
	Public Const FID_COMClose As Short = 46
	Public Const FID_COMRead As Short = 47
	Public Const FID_COMWrite232 As Short = 48
	Public Const FID_COMWrite485 As Short = 49
	Public Const FID_COMWrite85 As Short = 50
	Public Const FID_COMInit As Short = 51
	Public Const FID_COMLock As Short = 52
	Public Const FID_COMUnlock As Short = 53
	Public Const FID_WDTEnable As Short = 54
	Public Const FID_WDTRefresh As Short = 55
	Public Const FID_WDTReset As Short = 56
	Public Const FID_FAIIntStart As Short = 57
	Public Const FID_FAIIntScanStart As Short = 58
	Public Const FID_FAIDmaStart As Short = 59
	Public Const FID_FAIDmaScanStart As Short = 60
	Public Const FID_FAIDualDmaStart As Short = 61
	Public Const FID_FAIDualDmaScanStart As Short = 62
	Public Const FID_FAICheck As Short = 63
	Public Const FID_FAITransfer As Short = 64
	Public Const FID_FAIStop As Short = 65
	Public Const FID_FAIWatchdogConfig As Short = 66
	Public Const FID_FAIIntWatchdogStart As Short = 67
	Public Const FID_FAIDmaWatchdogStart As Short = 68
	Public Const FID_FAIWatchdogCheck As Short = 69
	Public Const FID_FAOIntStart As Short = 70
	Public Const FID_FAODmaStart As Short = 71
	Public Const FID_FAOScale As Short = 72
	Public Const FID_FAOLoad As Short = 73
	Public Const FID_FAOCheck As Short = 74
	Public Const FID_FAOStop As Short = 75
	Public Const FID_ClearOverrun As Short = 76
	Public Const FID_EnableEvent As Short = 77
	Public Const FID_CheckEvent As Short = 78
	Public Const FID_AllocateDMABuffer As Short = 79
	Public Const FID_FreeDMABuffer As Short = 80
	Public Const FID_EnableCANEvent As Short = 81
	Public Const FID_GetCANEventData As Short = 82
	Public Const FID_TimerCountSetting As Short = 83
	Public Const FID_CounterPWMSetting As Short = 84
	Public Const FID_CounterPWMEnable As Short = 85
	Public Const FID_DioTimerSetting As Short = 86
	Public Const FID_EnableEventEx As Short = 87
	Public Const FID_DICounterReset As Short = 88
	Public Const FID_FDITransfer As Short = 89
	Public Const FID_EnableSyncAO As Short = 90
	Public Const FID_WriteSyncAO As Short = 91
	Public Const FID_AOCurrentOut As Short = 92
	Public Const FID_ADAMCounterSetHWConfig As Short = 93
	Public Const FID_ADAMCounterGetHWConfig As Short = 94
	Public Const FID_ADAMAISetHWConfig As Short = 95
	Public Const FID_ADAMAIGetHWConfig As Short = 96
	Public Const FID_ADAMAOSetHWConfig As Short = 97
	Public Const FID_ADAMAOGetHWConfig As Short = 98
	Public Const FID_GetFIFOSize As Short = 99
	Public Const FID_PWMStartRead As Short = 100
	Public Const FID_FAIDmaExStart As Short = 101
	Public Const FID_FAOWaveFormStart As Short = 102

	'\\\\\\\\\\\\\\\\\\\ V2.0B /////////////////////
	Public Const FID_FreqOutStart As Short = 104
	Public Const FID_FreqOutReset As Short = 105
	Public Const FID_CounterConfig As Short = 106
	Public Const FID_DeviceGetParam As Short = 107
	'/////////////////// V2.0B \\\\\\\\\\\\\\\\\\\\\

	'\\\\\\\\\\\\\\\\\\\ V2.0C /////////////////////
	Public Const FID_DeviceSetProperty As Short = 108
	Public Const FID_DeviceGetProperty As Short = 109
	Public Const FID_WritePortDword As Short = 110
	Public Const FID_ReadPortDword As Short = 111
	Public Const FID_FDIStart As Short = 112
	Public Const FID_FDICheck As Short = 113
	Public Const FID_FDIStop As Short = 114
	Public Const FID_FDOStart As Short = 115
	Public Const FID_FDOCheck As Short = 116
	Public Const FID_FDOStop As Short = 117
	Public Const FID_ClearFlag As Short = 118
	'/////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\

	'\\\\\\\\\\\\\\\\\\\ V2.2 /////////////////////
	Public Const FID_WatchdogStart As Short = 119
	Public Const FID_WatchdogFeed As Short = 120
	Public Const FID_WatchdogStop As Short = 121
	'///////////////////// V2.2/////////////////////

	'\\\\\\\\\\\\\\\\\\\ V2.2C /////////////////////
	Public Const FID_DioReadPortWord As Short = 122
	Public Const FID_DioWritePortWord As Short = 123
	Public Const FID_DioReadPortDword As Short = 124
	Public Const FID_DioWritePortDword As Short = 125
	Public Const FID_DioGetCurrentDOWord As Short = 126
	Public Const FID_DioGetCurrentDODword As Short = 127
	Public Const FID_FAODmaExStart As Short = 128
	Public Const FID_FAITerminate As Short = 129
	Public Const FID_FAOTerminate As Short = 130
	'///////////////////// V2.2C /////////////////////

	Public Const FID_DioEnableEventAndSpecifyDiPorts As Short = 131
	Public Const FID_DioDisableEvent As Short = 132
	Public Const FID_DioGetLatestEventDiPortsState As Short = 133
	Public Const FID_DioReadDiPorts As Short = 134
	Public Const FID_DioWriteDoPorts As Short = 135
	Public Const FID_DioGetCurrentDoPortsState As Short = 136

	Public Const FID_FAOCheckEx As Short = 137


	Public Const FID_DioEnableEventAndSpecifyEventCounter As Short = 138
	Public Const FID_CntrEnableEventAndSpecifyEventCounter As Short = 139
	Public Const FID_CntrGetLatestEventCounterValue As Short = 140
	Public Const FID_CntrDisableEvent As Short = 141

	Public Const FID_CustomerDataRead As Short = 142
	Public Const FID_CustomerDataWrite As Short = 143
	Public Const MaxEntries As Short = 255
	Public DeviceHandle As Integer
	Public ptDevGetFeatures As PT_DeviceGetFeatures
	'UPGRADE_WARNING: 结构 lpDevFeatures 中的数组可能需要先初始化才可以使用。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"”
	Public lpDevFeatures As DEVFEATURES
	'UPGRADE_WARNING: 数组 devicelist 可能需要对单个元素进行初始化。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"”
	Public devicelist(MaxEntries) As PT_DEVLIST
	'UPGRADE_WARNING: 数组 SubDevicelist 可能需要对单个元素进行初始化。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"”
	Public SubDevicelist(MaxEntries) As PT_DEVLIST
	Public ErrCde As Integer
	Public szErrMsg As New VB6.FixedLengthString(80)
	Public bRun As Boolean

	Public lpDioPortMode As PT_DioSetPortMode
	Public lpDioWritePort As PT_DioWritePortByte
	Public lpDioGetCurrentDoByte As PT_DioGetCurrentDOByte




	'Global lpDioPortMode As PT_DioSetPortMode
	Public lpDioReadPort As PT_DioReadPortByte
	Const ModeDir As Short = 0 ' for input mode

	'*************************************************************************
	'    define gain listing
	'************************************************************************
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

	'*************************************************************************
	'    Define hardware board(device) features.
	'
	'    Note: definition for dwPermutaion member
	'
	'           Bit 0: Software AI
	'           Bit 1: DMA AI
	'           Bit 2: Interrupt AI
	'           Bit 3: Condition AI
	'           Bit 4: Software AO
	'           Bit 5: DMA AO
	'           Bit 6: Interrupt AO
	'           Bit 7: Condition AO
	'           Bit 8: Software DI
	'           Bit 9: DMA DI
	'           Bit 10: Interrupt DI
	'           Bit 11: Condition DI
	'           Bit 12: Software DO
	'           Bit 13: DMA DO
	'           Bit 14: Interrupt DO
	'           Bit 15: Condition DO
	'           Bit 16: High Gain
	'           Bit 17: Auto Channel Scan
	'           Bit 18: Pacer Trigger
	'           Bit 19: External Trigger
	'           Bit 20: Down Counter
	'           Bit 21: Dual DMA
	'           Bit 22: Monitoring
	'           Bit 23: QCounter
	'
	'***********************************************************************
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

	'*************************************************************************
	'    AOSET Definition
	'************************************************************************
	Structure AOSET
		Dim usAOSource As Short ' 0-internal, 1-external
		Dim fAOMaxVol As Single ' maximum output voltage
		Dim fAOMinVol As Single ' minimum output voltage
		Dim fAOMaxCur As Single ' maximum output current
		Dim fAOMinCur As Single ' minimum output current
	End Structure

	Structure AORANGESET
		Dim usGainCount As Short
		Dim usAOSource As Short ' 0-internal, 1-external
		Dim usAOType As Short ' 0-voltage, 1-current
		Dim usChan As Short
		Dim fAOMax As Single ' manimum output
		Dim fAOMin As Single ' miximum output
	End Structure

	'\\\\\\\\\\\\\\\\\\\ V2.0B /////////////////////
	'Type PT_DeviceGetParam
	'    nID As Integer
	'    nSize As Long                    'pointer
	'    pBuffer As Long                  'pointer
	'End Type
	'/////////////////// V2.0B \\\\\\\\\\\\\\\\\\\\\

	'*************************************************************************
	'    DaughterSet Definition
	'*************************************************************************
	Structure DAUGHTERSET
		Dim dwBoardID As Integer ' expansion board ID
		Dim usNum As Short ' available expansion channels
		Dim fGain As Single ' gain for expansion channel
		Dim usCards As Short ' number of expansion cards
	End Structure

	'**************************************************************************
	'    Analog Input Configuration Definition
	'**************************************************************************
	Structure DEVCONFIG_AI
		Dim dwBoardID As Integer ' board ID code
		Dim ulChanConfig As Integer ' 0-single ended, 1-differential
		Dim usGainCtrMode As Short ' 1-by jumper, 0-programmable
		Dim usPolarity As Short ' 0-bipolar, 1-unipolar
		Dim usDasGain As Short ' not used if GainCtrMode = 1
		Dim usNumExpChan As Short ' DAS channels attached expansion board
		Dim usCjcChannel As Short ' cold junction channel
		<VBFixedArray(MAX_DAUGHTER_NUM - 1)> Dim Daughter() As DAUGHTERSET ' expansion board settings
		<VBFixedArray(3)> Dim ulChanConfigEx() As Integer ' Extension the channel configuration, so we can max support 128 AI channels' setting.

		'UPGRADE_TODO: 必须调用“Initialize”来初始化此结构的实例。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"”
		Public Sub Initialize()
			ReDim Daughter(MAX_DAUGHTER_NUM - 1)
			ReDim ulChanConfigEx(3)
		End Sub
	End Structure

	'**************************************************************************
	'    DEVCONFIG_COM Definition
	'**************************************************************************
	Structure DEVCONFIG_COM
		Dim usCommPort As Short ' serial port
		Dim dwBaudRate As Integer ' baud rate
		Dim usParity As Short ' parity check
		Dim usDataBits As Short ' data bits
		Dim usStopBits As Short ' stop bits
		Dim usTxMode As Short ' transmission mode
		Dim usPortAddress As Short ' communication port address
	End Structure

	'**************************************************************************
	'    TRIGLEVEL Definition
	'**************************************************************************
	Structure TRIGLEVEL
		Dim fLow As Single
		Dim fHigh As Single
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

	Structure PT_AIConfig
		Dim DasChan As Short
		Dim DasGain As Short
	End Structure

	Structure PT_AIGetConfig
		Dim buffer As Integer ' LPDEVCONFIG_AI
		Dim size As Short
	End Structure

	Structure PT_AIBinaryIn
		Dim chan As Short
		Dim TrigMode As Short
		Dim reading As Integer ' USHORT far * reading
	End Structure

	Structure PT_AIScale
		Dim reading As Short
		Dim MaxVolt As Single
		Dim MaxCount As Short
		Dim offset As Short
		Dim voltage As Integer ' FLOAT far *voltage
	End Structure

	Structure PT_AIVoltageIn
		Dim chan As Short
		Dim gain As Short
		Dim TrigMode As Short
		Dim voltage As Integer ' FLOAT far *voltage
	End Structure

	Structure PT_AIVoltageInExp
		Dim DasChan As Short
		Dim DasGain As Short
		Dim ExpChan As Short
		Dim voltage As Integer ' FLOAT far *voltage
	End Structure

	Structure PT_MAIConfig
		Dim NumChan As Short
		Dim StartChan As Short
		Dim GainArray As Integer ' USHORT far *GainArray
	End Structure

	Structure PT_MAIBinaryIn
		Dim NumChan As Short
		Dim StartChan As Short
		Dim TrigMode As Short
		Dim ReadingArray As Integer 'USHORT far *Reading
	End Structure

	Structure PT_MAIVoltageIn
		Dim NumChan As Short
		Dim StartChan As Short
		Dim GainArray As Integer 'USHORT far *GainArray
		Dim TrigMode As Short
		Dim VoltageArray As Integer 'FLOAT far *VoltageArray
	End Structure

	Structure PT_MAIVoltageInExp
		Dim NumChan As Short
		Dim DasChanArray As Integer ' USHORT far *DasChanArray
		Dim DasGainArray As Integer ' USHORT far *DasGainArray
		Dim ExpChanArray As Integer ' USHORT far *ExpChanArray
		Dim VoltageArray As Integer ' FLOAT  far *VoltageArray
	End Structure

	Structure PT_TCMuxRead
		Dim DasChan As Short
		Dim DasGain As Short
		Dim ExpChan As Short
		Dim TCType As Short
		Dim TempScale As Short
		Dim temp As Integer ' FLOAT far *temp
	End Structure

	Structure PT_AOConfig
		Dim chan As Short
		Dim RefSrc As Short
		Dim MaxValue As Single
		Dim MinValue As Single
	End Structure

	Structure PT_AOBinaryOut
		Dim chan As Short
		Dim BinData As Short
	End Structure

	Structure PT_AOVoltageOut
		Dim chan As Short
		Dim OutputValue As Single
	End Structure

	Structure PT_AOScale
		Dim chan As Short
		Dim OutputValue As Single
		Dim BinData As Integer ' USHORT far *BinData
	End Structure

	Structure PT_DioSetPortMode
		Dim Port As Short
		'UPGRADE_NOTE: dir 已升级到 dir_Renamed。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"”
		Dim dir_Renamed As Short
	End Structure

	Structure PT_DioGetConfig
		Dim PortArray As Integer ' SHORT far *PortArray
		Dim NumOfPorts As Short
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

	Structure PT_DioReadBit
		Dim Port As Short
		Dim bit As Short
		Dim state As Integer ' USHORT far *state
	End Structure

	Structure PT_DioWriteBit
		Dim Port As Short
		Dim bit As Short
		Dim state As Short
	End Structure

	Structure PT_DioGetCurrentDOByte
		Dim Port As Short
		Dim value As Integer ' USHORT far *value
	End Structure

	Structure PT_DioGetCurrentDOBit
		Dim Port As Short
		Dim bit As Short
		Dim state As Integer ' USHORT far *state
	End Structure

	Structure PT_WritePortByte
		Dim Port As Short
		Dim ByteData As Short
	End Structure

	Structure PT_WritePortWord
		Dim Port As Short
		Dim WordData As Short
	End Structure

	'////////////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\\\\
	Structure PT_WritePortDword
		Dim Port As Short
		Dim DwordData As Integer
	End Structure
	'////////////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\\\\


	Structure PT_ReadPortByte
		Dim Port As Short
		Dim ByteData As Integer ' USHORT far *ByteData
	End Structure

	Structure PT_ReadPortWord
		Dim Port As Short
		Dim WordData As Integer ' USHORT far *WordData
	End Structure

	'////////////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\\\\
	Structure PT_ReadPortDword
		Dim Port As Short
		Dim DwordData As Integer
	End Structure
	'////////////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\\\\

	Structure PT_CounterEventStart
		Dim counter As Short
		Dim GateMode As Short
	End Structure

	Structure PT_CounterEventRead
		Dim counter As Short
		Dim overflow As Integer ' USHORT far *overflow
		Dim Count As Integer ' ULONG  far *count
	End Structure

	Structure PT_CounterFreqStart
		Dim counter As Short
		Dim GatePeriod As Short
		Dim GateMode As Short
	End Structure

	Structure PT_CounterFreqRead
		Dim counter As Short
		Dim freq As Integer 'FLOAT far *freq
	End Structure

	Structure PT_CounterPulseStart
		Dim counter As Short
		Dim Period As Single
		Dim UpCycle As Single
		Dim GateMode As Short
	End Structure

	Structure PT_QCounterConfig
		Dim counter As Short
		Dim LatchSrc As Short
		Dim LatchOverflow As Short
		Dim ResetOnLatch As Short
		Dim ResetValue As Short
	End Structure

	Structure PT_QCounterConfigSys
		Dim SysClock As Short
		Dim TimeBase As Short
		Dim TimeDivider As Short
		Dim CascadeMode As Short
	End Structure

	Structure PT_QCounterStart
		Dim counter As Short
		Dim InputMode As Short
	End Structure

	Structure PT_QCounterRead
		Dim counter As Short
		Dim overflow As Integer ' USHORT far *overflow
		Dim LoCount As Integer ' ULONG  far *LoCount
		Dim HiCount As Integer ' ULONG  far *HiCount
	End Structure

	Structure PT_AlarmConfig
		Dim chan As Short
		Dim LoLimit As Single
		Dim HiLimit As Single
	End Structure

	Structure PT_AlarmEnable
		Dim chan As Short
		Dim LatchMode As Short
		Dim Enabled As Short
	End Structure

	Structure PT_AlarmCheck
		Dim chan As Short
		Dim LoState As Integer ' USHORT far *LoState
		Dim HiState As Integer ' USHORT far *HiState
	End Structure

	Structure PT_WDTEnable
		Dim message As Short
		Dim Destination As Integer ' HWND Destination
	End Structure

	Structure PT_FAIIntStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim chan As Short
		Dim gain As Short
		Dim buffer As Integer
		Dim Count As Integer
		Dim cyclic As Short
		Dim IntrCount As Short
	End Structure

	Structure PT_FAIIntScanStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim NumChans As Short
		Dim StartChan As Short
		'UPGRADE_NOTE: GainList 已升级到 GainList_Renamed。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"”
		Dim GainList_Renamed As Integer
		Dim buffer As Integer
		Dim Count As Integer
		Dim cyclic As Short
		Dim IntrCount As Short
	End Structure

	Structure PT_FAIDmaStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim chan As Short
		Dim gain As Short
		Dim buffer As Integer
		Dim Count As Integer
	End Structure

	Structure PT_FAIDmaScanStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim NumChans As Short
		Dim StartChan As Short
		'UPGRADE_NOTE: GainList 已升级到 GainList_Renamed。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"”
		Dim GainList_Renamed As Integer
		Dim buffer As Integer
		Dim Count As Integer
	End Structure

	Structure PT_FAIDualDmaStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim chan As Short
		Dim gain As Short
		Dim BufferA As Integer
		Dim BufferB As Integer
		Dim Count As Integer
		Dim cyclic As Short
	End Structure

	Structure PT_FAIDualDmaScanStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim NumChans As Short
		Dim StartChan As Short
		'UPGRADE_NOTE: GainList 已升级到 GainList_Renamed。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"”
		Dim GainList_Renamed As Integer
		Dim BufferA As Integer
		Dim BufferB As Integer
		Dim Count As Integer
		Dim cyclic As Short
	End Structure

	Structure PT_FAITransfer
		Dim ActiveBuf As Short
		Dim DataBuffer As Integer
		Dim DataType As Short
		Dim Start As Integer
		Dim Count As Integer
		Dim Overrun As Integer
	End Structure

	Structure PT_FAICheck
		Dim ActiveBuf As Integer
		Dim Stopped As Integer
		Dim retrieved As Integer
		Dim Overrun As Integer
		Dim HalfReady As Integer
	End Structure

	Structure PT_FAIWatchdogConfig
		Dim TrigMode As Short
		Dim NumChans As Short
		Dim StartChan As Short
		'UPGRADE_NOTE: GainList 已升级到 GainList_Renamed。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"”
		Dim GainList_Renamed As Integer
		Dim CondList As Integer
		Dim LevelList As Integer
	End Structure

	Structure PT_FAIIntWatchdogStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim buffer As Integer
		Dim Count As Integer
		Dim cyclic As Short
		Dim IntrCount As Short
	End Structure

	Structure PT_FAIDmaWatchdogStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim BufferA As Integer
		Dim BufferB As Integer
		Dim Count As Integer
	End Structure

	Structure PT_FAIWatchdogCheck
		Dim DataType As Short
		Dim ActiveBuf As Integer
		Dim triggered As Integer
		Dim TrigChan As Integer
		Dim TrigIndex As Integer
		Dim TrigData As Integer
	End Structure

	Structure PT_FAOIntStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim chan As Short
		Dim buffer As Integer
		Dim Count As Integer
		Dim cyclic As Short
	End Structure

	Structure PT_FAODmaExStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim StartChan As Short
		Dim NumChans As Short
		Dim buffer As Integer
		Dim Count As Integer
		Dim CyclicMode As Short
		Dim PacerSource As Short
		<VBFixedArray(3)> Dim Reserved() As Integer
		<VBFixedArray(3)> Dim pReserved() As Integer

		'UPGRADE_TODO: 必须调用“Initialize”来初始化此结构的实例。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"”
		Public Sub Initialize()
			ReDim Reserved(3)
			ReDim pReserved(3)
		End Sub
	End Structure

	Structure PT_FAODmaStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim chan As Short
		Dim buffer As Integer
		Dim Count As Integer
	End Structure


	Structure PT_FAOScale
		Dim chan As Short
		Dim Count As Integer
		Dim VoltArray As Integer
		Dim BinArray As Integer
	End Structure

	Structure PT_FAOLoad
		Dim ActiveBuf As Short
		Dim DataBuffer As Integer
		Dim Start As Short
		Dim Count As Integer
	End Structure

	Structure PT_FAOCheck
		Dim ActiveBuf As Integer
		Dim Stopped As Integer
		Dim CurrentCount As Integer
		Dim Overrun As Integer
		Dim HalfReady As Integer
	End Structure

	Structure PT_FAOCheckEx
		Dim ActiveBuf As Integer
		Dim Stopped As Integer
		Dim Transfered As Integer
		Dim Underrun As Integer
		Dim HalfReady As Integer
	End Structure


	Structure PT_EnableEvent
		Dim EventType As Short
		Dim Enabled As Short
		Dim Count As Short
	End Structure

	Structure PT_CheckEvent
		Dim EventType As Integer
		Dim Milliseconds As Integer
	End Structure

	Structure PT_AllocateDMABuffer
		Dim CyclicMode As Short
		Dim RequestBufSize As Integer
		Dim ActualBufSize As Integer
		Dim buffer As Integer
	End Structure

	Structure PT_TimerCountSetting
		Dim counter As Short
		Dim Count As Integer
	End Structure

	Structure PT_DIFilter
		Dim EventType As Short
		Dim EventEnabled As Short
		Dim Count As Short
		Dim EnableMask As Short ' Filter enable data
		Dim HiValue As Integer ' USHORT far * HiValue;  // Filter value array pointer
		Dim LowValue As Integer
	End Structure

	Structure PT_DIPattern
		Dim EventType As Short
		Dim EventEnabled As Short
		Dim Count As Short
		Dim EnableMask As Short ' Pattern Match enable data
		Dim PatternValue As Short ' Pattern Match pre_setting value;
	End Structure

	Structure PT_DICounter
		Dim EventType As Short
		Dim EventEnabled As Short
		Dim Count As Short
		Dim EnableMask As Short ' Counter enable data
		Dim TrigEdge As Short ' Counter Trigger edge 0: Rising edge  1:Falling edge
		Dim PresetValue As Integer ' USHORT far * usPreset;    // counter pre_setting value
		Dim MatchEnableMask As Short ' Counter match enable data
		Dim MatchValue As Integer ' USHORT far * usValue;     // counter match value
		Dim OverflowEnableMask As Short ' Counter overflow data
		Dim Direction As Short ' Up/Down counter direction
	End Structure

	Structure PT_DIStatus
		Dim EventType As Short
		Dim EventEnabled As Short
		Dim Count As Short
		Dim EnableMask As Short ' Status change enable data
		Dim RisingEdge As Short ' Record Rising edge trigger type
		Dim FallingEdge As Short ' Record Falling edge trigger type
	End Structure

	Structure PT_CounterPWMSetting
		Dim Port As Short ' Counter port
		Dim Period As Single ' Period unit -> 0.1ms
		Dim HiPeriod As Single ' UpCycle period unit -> 0.1 ms
		Dim OutCount As Integer ' Stop count
		Dim GateMode As Short
	End Structure

	Structure PT_DioTimerSetting
		Dim Port As Short ' Counter port
		Dim TimerOnEnable As Short
		Dim TimerOffEnable As Short
		Dim OnDuration As Integer ' Timer on duration
		Dim OffDuration As Integer ' Timer off duration
	End Structure

	Structure PT_FDITransfer
		Dim EventType As Short
		Dim RetData As Integer
	End Structure

	Structure PT_AOCurrentOut
		Dim chan As Short
		Dim OutputValue As Single
	End Structure

	Structure PT_ADAMCounterSetHWConfig
		Dim CounterMode As Short
		Dim DataFormat As Short ' Only for adam5080
		Dim GateTime As Short ' Only for adam4080,4080D
	End Structure

	Structure PT_ADAMCounterGetHWConfig
		Dim CounterMode As Integer
		Dim DataFormat As Integer ' Only for adam5080
		Dim GateTime As Integer ' Only for adam4080,4080D
	End Structure

	Structure PT_ADAMAISetHWConfig
		Dim InputRange As Short
		Dim DataFormat As Short
		Dim IntegrationTime As Short
	End Structure

	Structure PT_ADAMAIGetHWConfig
		Dim InputRange As Integer
		Dim DataFormat As Integer
		Dim IntegrationTime As Integer
	End Structure

	Structure PT_ADAMAOSetHWConfig
		Dim chan As Short
		Dim OutputRange As Short
		Dim DataFormat As Short
		Dim SlewRate As Short
	End Structure

	Structure PT_ADAMAOGetHWConfig
		Dim chan As Short
		Dim OutputRange As Integer
		Dim DataFormat As Integer
		Dim SlewRate As Integer
	End Structure

	Structure PT_PWMStartRead
		Dim usChan As Short 'USHORT usChan
		Dim flHiperiod As Integer 'FLOAT far *flHiperiod
		Dim flLowperiod As Integer 'FLOAT far *flLowperiod
	End Structure

	Structure PT_FAIDmaExStart
		Dim TrigSrc As Short
		Dim TrigMode As Short
		Dim ClockSrc As Short
		Dim TrigEdge As Short
		Dim SRCType As Short
		Dim TrigVol As Single
		Dim CyclicMode As Short
		Dim NumChans As Short
		Dim StartChan As Short
		Dim ulDelayCnt As Integer
		Dim Count As Integer
		Dim SampleRate As Integer
		'UPGRADE_NOTE: GainList 已升级到 GainList_Renamed。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"”
		Dim GainList_Renamed As Integer
		Dim CondList As Integer
		Dim LevelList As Integer
		Dim buffer0 As Integer
		Dim Buffer1 As Integer
		Dim pPt1 As Integer
		Dim pPt2 As Integer
		Dim pPt3 As Integer
	End Structure


	Structure PT_FAOWaveFormStart
		Dim TrigSrc As Short
		Dim SampleRate As Integer
		Dim WaveCount As Integer
		Dim Count As Integer
		Dim buffer As Integer
		Dim EnabledChannel As Integer
	End Structure

	'\\\\\\\\\\\\\\\\\\\ V2.0B /////////////////////
	Structure PT_CounterConfig
		Dim usCounter As Short
		Dim usInitValue As Short
		Dim usCountMode As Short
		Dim usCountDirect As Short
		Dim usCountEdge As Short
		Dim usOutputEnable As Short
		Dim usOutputMode As Short
		Dim usClkSrc As Short
		Dim usGateSrc As Short
		Dim usGatePolarity As Short
	End Structure

	Structure PT_FreqOutStart
		Dim usChannel As Short
		Dim usDivider As Short
		Dim usFoutSrc As Short
	End Structure
	'///////////////////// V2.0B \\\\\\\\\\\\\\\\\\\\\

	'\\\\\\\\\\\\\\\\\\\ V2.0C /////////////////////
	Structure PT_DeviceSetParam 'PCI-1755
		Dim nID As Short 'IN, Paramarter name ID
		Dim Length As Integer 'IN: buffer length
		Dim pData As Integer 'IN, buffer for trandsferring in.
	End Structure

	Structure PT_DeviceGetParam 'PCI-1755
		Dim nID As Short 'IN, Paramarter name ID
		Dim Length As Integer 'IN: buffer length, out data length required.
		Dim pData As Integer 'OUT, data return buffer.
	End Structure
	'///////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\

	'///////////////////// V2.2 \\\\\\\\\\\\\\\\\\\\\
	Structure PT_WatchdogStart 'PCI-1758
		Dim Reserved0 As Integer
		Dim Reserved1 As Integer
	End Structure
	'///////////////////// V2.2 \\\\\\\\\\\\\\\\\\\\\

	'///////////////////// V2.2C \\\\\\\\\\\\\\\\\\\\\
	Structure PT_DioReadPortWord
		Dim Port As Short
		Dim value As Integer ' USHORT far *value
		Dim ValidChannelMask As Integer 'Xi'an added
	End Structure

	Structure PT_DioWritePortWord
		Dim Port As Short
		Dim Mask As Short
		Dim state As Short
	End Structure

	Structure PT_DioReadPortDword
		Dim Port As Short
		Dim value As Integer ' USHORT far *value
		Dim ValidChannelMask As Integer 'Xi'an added
	End Structure

	Structure PT_DioWritePortDword
		Dim Port As Short
		Dim Mask As Integer
		Dim state As Integer
	End Structure

	Structure PT_DioGetCurrentDOWord
		Dim Port As Short
		Dim value As Integer ' USHORT far *value
		Dim ValidChannelMask As Integer 'Xi'an added
	End Structure

	Structure PT_DioGetCurrentDODword
		Dim Port As Short
		Dim value As Integer ' ULONG far *value
		Dim ValidChannelMask As Integer 'Xi'an added
	End Structure

	Structure PROCESSENTRY32
		Dim dwSize As Integer
		Dim cntUsage As Integer
		Dim th32ProcessID As Integer
		Dim th32DefaultHeapID As Integer
		Dim th32ModuleID As Integer
		Dim cntThreads As Integer
		Dim th32ParentProcessID As Integer
		Dim pcPriClassBase As Integer
		Dim dwFlags As Integer
		'UPGRADE_WARNING: 固定长度字符串的大小必须适合缓冲区。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"”
		<VBFixedString(260), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=260)> Public szExeFile() As Char
	End Structure
	'///////////////////// V2.2C \\\\\\\\\\\\\\\\\\\\\


	'**************************************************************************
	'    Function Declaration for ADSAPI32
	'**************************************************************************
	Declare Function DRV_SelectDevice Lib "adsapi32.dll" (ByVal hCaller As Integer, ByVal GetModule As Boolean, ByRef DeviceNum As Integer, ByVal Description As String) As Integer
	Declare Function DRV_DeviceGetNumOfList Lib "adsapi32.dll" (ByRef NumOfDevices As Short) As Integer
	Declare Function DRV_DeviceGetList Lib "adsapi32.dll" (ByVal devicelist As Integer, ByVal MaxEntries As Short, ByRef nOutEntries As Short) As Integer
	Declare Function DRV_DeviceGetSubList Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByVal SubDevList As Integer, ByVal MaxEntries As Short, ByRef nOutEntries As Short) As Integer
	Declare Function DRV_DeviceOpen Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByRef DriverHandle As Integer) As Integer
	Declare Function DRV_DeviceClose Lib "adsapi32.dll" (ByRef DriverHandle As Integer) As Integer
	'UPGRADE_WARNING: 结构 PT_DeviceGetFeatures 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DeviceGetFeatures Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpDevFeatures As PT_DeviceGetFeatures) As Integer
	'//////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\
	'UPGRADE_ISSUE: 不支持将参数声明为“As Any”。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"”
	Declare Function DRV_DeviceSetProperty Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal nID As Short, ByRef pBuffer As Object, ByVal dwLength As Integer) As Integer
	'UPGRADE_ISSUE: 不支持将参数声明为“As Any”。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"”
	Declare Function DRV_DeviceGetProperty Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal nID As Short, ByRef pBuffer As Object, ByRef pLength As Integer) As Integer
	'//////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\
	Declare Function DRV_BoardTypeMapBoardName Lib "adsapi32.dll" (ByVal BoardID As Integer, ByVal ExpName As String) As Integer
	Declare Sub DRV_GetErrorMessage Lib "adsapi32.dll" (ByVal lError As Integer, ByVal lpszszErrMsg As String)
	'UPGRADE_WARNING: 结构 PT_AIConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AIConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AIConfig As PT_AIConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_AIGetConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AIGetConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AIGetConfig As PT_AIGetConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_AIBinaryIn 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AIBinaryIn Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AIBinaryIn As PT_AIBinaryIn) As Integer
	'UPGRADE_WARNING: 结构 PT_AIScale 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AIScale Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AIScale As PT_AIScale) As Integer
	'UPGRADE_WARNING: 结构 PT_AIVoltageIn 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AIVoltageIn Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AIVoltageIn As PT_AIVoltageIn) As Integer
	'UPGRADE_WARNING: 结构 PT_AIVoltageInExp 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AIVoltageInExp Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AIVoltageInExp As PT_AIVoltageInExp) As Integer
	'UPGRADE_WARNING: 结构 PT_MAIConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_MAIConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef MAIConfig As PT_MAIConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_MAIBinaryIn 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_MAIBinaryIn Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef MAIBinaryIn As PT_MAIBinaryIn) As Integer
	'UPGRADE_WARNING: 结构 PT_MAIVoltageIn 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_MAIVoltageIn Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef MAIVoltageIn As PT_MAIVoltageIn) As Integer
	'UPGRADE_WARNING: 结构 PT_MAIVoltageInExp 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_MAIVoltageInExp Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef MAIVoltageInExp As PT_MAIVoltageInExp) As Integer
	'UPGRADE_WARNING: 结构 PT_TCMuxRead 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_TCMuxRead Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef TCMuxRead As PT_TCMuxRead) As Integer
	'UPGRADE_WARNING: 结构 PT_AOConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AOConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AOConfig As PT_AOConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_AOBinaryOut 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AOBinaryOut Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AOBinaryOut As PT_AOBinaryOut) As Integer
	'UPGRADE_WARNING: 结构 PT_AOVoltageOut 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AOVoltageOut Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AOVoltageOut As PT_AOVoltageOut) As Integer
	'UPGRADE_WARNING: 结构 PT_AOScale 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AOScale Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AOScale As PT_AOScale) As Integer
	'UPGRADE_WARNING: 结构 PT_DioSetPortMode 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioSetPortMode Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioSetPortMode As PT_DioSetPortMode) As Integer
	'UPGRADE_WARNING: 结构 PT_DioGetConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioGetConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioGetConfig As PT_DioGetConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_DioReadPortByte 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioReadPortByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioReadPortByte As PT_DioReadPortByte) As Integer
	'UPGRADE_WARNING: 结构 PT_DioWritePortByte 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioWritePortByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioWritePortByte As PT_DioWritePortByte) As Integer
	'UPGRADE_WARNING: 结构 PT_DioReadBit 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioReadBit Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioReadBit As PT_DioReadBit) As Integer
	'UPGRADE_WARNING: 结构 PT_DioWriteBit 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioWriteBit Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioWriteBit As PT_DioWriteBit) As Integer
	'UPGRADE_WARNING: 结构 PT_DioGetCurrentDOByte 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioGetCurrentDOByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioGetCurrentDOByte As PT_DioGetCurrentDOByte) As Integer
	'UPGRADE_WARNING: 结构 PT_DioGetCurrentDOBit 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioGetCurrentDOBit Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioGetCurrentDOBit As PT_DioGetCurrentDOBit) As Integer
	'UPGRADE_WARNING: 结构 PT_WritePortByte 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_WritePortByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef WritePortByte As PT_WritePortByte) As Integer
	'UPGRADE_WARNING: 结构 PT_WritePortWord 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_WritePortWord Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef WritePortWord As PT_WritePortWord) As Integer
	'\\\\\\\\\\\\\\\\\\\ V2.0C /////////////////////
	'UPGRADE_WARNING: 结构 PT_WritePortDword 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_WritePortDword Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef WritePortDword As PT_WritePortDword) As Integer
	'/////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\

	'UPGRADE_WARNING: 结构 PT_ReadPortByte 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_ReadPortByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef ReadPortByte As PT_ReadPortByte) As Integer
	'UPGRADE_WARNING: 结构 PT_ReadPortWord 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_ReadPortWord Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef ReadPortWord As PT_ReadPortWord) As Integer
	'\\\\\\\\\\\\\\\\\\\ V2.0C /////////////////////
	'UPGRADE_WARNING: 结构 PT_ReadPortDword 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_ReadPortDword Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef ReadPortDword As PT_ReadPortDword) As Integer
	'/////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\

	'UPGRADE_WARNING: 结构 PT_CounterEventStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_CounterEventStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef CounterEventStart As PT_CounterEventStart) As Integer
	'UPGRADE_WARNING: 结构 PT_CounterEventRead 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_CounterEventRead Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef CounterEventRead As PT_CounterEventRead) As Integer
	'UPGRADE_WARNING: 结构 PT_CounterFreqStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_CounterFreqStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef CounterFreqStart As PT_CounterFreqStart) As Integer
	'UPGRADE_WARNING: 结构 PT_CounterFreqRead 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_CounterFreqRead Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef CounterFreqRead As PT_CounterFreqRead) As Integer
	'UPGRADE_WARNING: 结构 PT_CounterPulseStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_CounterPulseStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef CounterPulseStart As PT_CounterPulseStart) As Integer
	Declare Function DRV_CounterReset Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal counter As Short) As Integer
	'\\\\\\\\\\\\\\\\\\\ V2.0B /////////////////////
	'UPGRADE_WARNING: 结构 PT_CounterConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_CounterConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef CounterConfig As PT_CounterConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_FreqOutStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FreqOutStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FreqOutStart As PT_FreqOutStart) As Integer
	Declare Function DRV_FreqOutReset Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal channel As Short) As Integer
	'/////////////////// V2.0B \\\\\\\\\\\\\\\\\\\\\
	'UPGRADE_WARNING: 结构 PT_QCounterConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_QCounterConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef QCounterConfig As PT_QCounterConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_QCounterConfigSys 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_QCounterConfigSys Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef QCounterConfigSys As PT_QCounterConfigSys) As Integer
	'UPGRADE_WARNING: 结构 PT_QCounterStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_QCounterStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef QCounterStart As PT_QCounterStart) As Integer
	'UPGRADE_WARNING: 结构 PT_QCounterRead 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_QCounterRead Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef QCounterRead As PT_QCounterRead) As Integer
	'UPGRADE_WARNING: 结构 PT_AlarmConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AlarmConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AlarmConfig As PT_AlarmConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_AlarmEnable 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AlarmEnable Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AlarmEnable As PT_AlarmEnable) As Integer
	'UPGRADE_WARNING: 结构 PT_AlarmCheck 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AlarmCheck Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AlarmCheck As PT_AlarmCheck) As Integer
	Declare Function DRV_AlarmReset Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal chan As Short) As Integer
	'UPGRADE_WARNING: 结构 PT_WDTEnable 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_WDTEnable Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef WDTEnable As PT_WDTEnable) As Integer
	Declare Function DRV_WDTRefresh Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	Declare Function DRV_WDTReset Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	'UPGRADE_ISSUE: 不支持将参数声明为“As Any”。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"”
	Declare Function DRV_GetAddress Lib "adsapi32.dll" (ByRef lpVoid As Object) As Integer
	'UPGRADE_WARNING: 结构 PT_TimerCountSetting 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_TimerCountSetting Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef TimerCountSetting As PT_TimerCountSetting) As Integer
	'UPGRADE_WARNING: 结构 PT_CounterPWMSetting 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_CounterPWMSetting Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpCounterPWMSetting As PT_CounterPWMSetting) As Integer
	Declare Function DRV_CounterPWMEnable Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal Port As Short) As Integer
	Declare Function DRV_DICounterReset Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal counter As Short) As Integer
	Declare Function DRV_EnableSyncAO Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal Enableas As Short) As Integer
	Declare Function DRV_WriteSyncAO Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	'UPGRADE_WARNING: 结构 PT_AOCurrentOut 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AOCurrentOut Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpAOCurrentOut As PT_AOCurrentOut) As Integer
	Declare Function DRV_DeviceNumToDeviceName Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByVal DeviceName As String) As Object
	Declare Function DRV_GetFIFOSize Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lSize As Integer) As Integer
	'UPGRADE_WARNING: 结构 PT_PWMStartRead 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_PWMStartRead Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpPWMStartRead As PT_PWMStartRead) As Integer

	' ADAM Configuration Function Declaration
	'UPGRADE_WARNING: 结构 PT_ADAMCounterSetHWConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_ADAMCounterSetHWConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpADAMCounterSetHWConfig As PT_ADAMCounterSetHWConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_ADAMCounterGetHWConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_ADAMCounterGetHWConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpADAMCounterGetHWConfig As PT_ADAMCounterGetHWConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_ADAMAISetHWConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_ADAMAISetHWConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpADAMAISetHWConfig As PT_ADAMAISetHWConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_ADAMAIGetHWConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_ADAMAIGetHWConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpADAMAIGetHWConfig As PT_ADAMAIGetHWConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_ADAMAOSetHWConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_ADAMAOSetHWConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpADAMAOSetHWConfig As PT_ADAMAOSetHWConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_ADAMAOGetHWConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_ADAMAOGetHWConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpADAMAOGetHWConfig As PT_ADAMAOGetHWConfig) As Integer
	' Direct I/O Functions List
	Declare Function DRV_outp Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByVal Port As Short, ByVal ByteData As Integer) As Integer
	Declare Function DRV_outpw Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByVal Port As Short, ByVal ByteData As Integer) As Integer
	Declare Function DRV_inp Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByVal Port As Short, ByRef ByteData As Integer) As Integer
	Declare Function DRV_inpw Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByVal Port As Short, ByRef ByteData As Integer) As Integer
	'/////////////////// V2.2 \\\\\\\\\\\\\\\\\\\\\
	Declare Function DRV_inpdw Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByVal Port As Short, ByRef DwordData As Integer) As Integer
	Declare Function DRV_outpdw Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByVal Port As Short, ByVal DwordData As Integer) As Integer
	'/////////////////// V2.2 \\\\\\\\\\\\\\\\\\\\\
	' High speed function declaration
	'UPGRADE_WARNING: 结构 PT_FAIWatchdogConfig 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIWatchdogConfig Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIWatchdogConfig As PT_FAIWatchdogConfig) As Integer
	'UPGRADE_WARNING: 结构 PT_FAIIntStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIIntStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIIntStart As PT_FAIIntStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAIIntScanStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIIntScanStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIIntScanStart As PT_FAIIntScanStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAIDmaStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIDmaStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIDmaStart As PT_FAIDmaStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAIDmaScanStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIDmaScanStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIDmaScanStart As PT_FAIDmaScanStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAIDualDmaStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIDualDmaStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIDualDmaStart As PT_FAIDualDmaStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAIDualDmaScanStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIDualDmaScanStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIDualDmaScanStart As PT_FAIDualDmaScanStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAIIntWatchdogStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIIntWatchdogStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIIntWatchdogStart As PT_FAIIntWatchdogStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAIDmaWatchdogStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIDmaWatchdogStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIDmaWatchdogStart As PT_FAIDmaWatchdogStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAICheck 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAICheck Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAICheck As PT_FAICheck) As Integer
	'UPGRADE_WARNING: 结构 PT_FAIWatchdogCheck 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIWatchdogCheck Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIWatchdogCheck As PT_FAIWatchdogCheck) As Integer
	'UPGRADE_WARNING: 结构 PT_FAITransfer 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAITransfer Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAITransfer As PT_FAITransfer) As Integer
	Declare Function DRV_FAIStop Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	'UPGRADE_WARNING: 结构 PT_FAOIntStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAOIntStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAOIntStart As PT_FAOIntStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAODmaStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAODmaStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAODmaStart As PT_FAODmaStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAODmaExStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAODmaExStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAODmaExStart As PT_FAODmaExStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAOScale 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAOScale Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAOScale As PT_FAOScale) As Integer
	'UPGRADE_WARNING: 结构 PT_FAOLoad 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAOLoad Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAOLoad As PT_FAOLoad) As Integer
	'UPGRADE_WARNING: 结构 PT_FAOCheck 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAOCheck Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAOCheck As PT_FAOCheck) As Integer
	'UPGRADE_WARNING: 结构 PT_FAOCheckEx 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAOCheckEx Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAOCheckEx As PT_FAOCheckEx) As Integer
	Declare Function DRV_FAOStop Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	Declare Function DRV_ClearOverrun Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	'UPGRADE_WARNING: 结构 PT_EnableEvent 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_EnableEvent Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef EnableEvent As PT_EnableEvent) As Integer
	'UPGRADE_WARNING: 结构 PT_CheckEvent 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_CheckEvent Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef CheckEvent As PT_CheckEvent) As Integer
	'UPGRADE_WARNING: 结构 PT_AllocateDMABuffer 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_AllocateDMABuffer Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef AllocateDMABuffer As PT_AllocateDMABuffer) As Integer
	Declare Function DRV_FreeDMABuffer Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal buffer As Integer) As Integer
	'UPGRADE_WARNING: 结构 PT_FDITransfer 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FDITransfer Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FDITransfer As PT_FDITransfer) As Integer
	'UPGRADE_ISSUE: 不支持将参数声明为“As Any”。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"”
	Declare Function DRV_EnableEventEx Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef EnableEventEx As Object) As Integer
	'UPGRADE_WARNING: 结构 PT_FAIDmaExStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAIDmaExStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAIDmaExStart As PT_FAIDmaExStart) As Integer
	'UPGRADE_WARNING: 结构 PT_FAOWaveFormStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_FAOWaveFormStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef FAOWaveFormStart As PT_FAOWaveFormStart) As Integer
	'\\\\\\\\\\\\\\\\\\\ V2.0B ///////////////////////
	'UPGRADE_WARNING: 结构 PT_DeviceGetParam 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DeviceGetParam Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpDeviceGetParam As PT_DeviceGetParam) As Integer
	'///////////////////// V2.0B \\\\\\\\\\\\\\\\\\\\\

	'/////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\
	Declare Function DRV_FDIStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal wCyclic As Short, ByVal dwCount As Integer, ByVal pBuf As Integer) As Integer
	Declare Function DRV_FDICheck Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef pdwStatus As Integer, ByRef pdwRetrieved As Integer) As Integer
	Declare Function DRV_FDIStop Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	Declare Function DRV_ClearFlag Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwEventType As Integer) As Integer
	Declare Function DRV_FDOStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal wCyclic As Short, ByVal dwCount As Integer, ByVal pBuf As Integer) As Integer
	Declare Function DRV_FDOCheck Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef pdwStatus As Integer, ByRef pdwRetrieved As Integer) As Integer
	Declare Function DRV_FDOStop Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	'/////////////////// V2.0C \\\\\\\\\\\\\\\\\\\\\
	'/////////////////// V2.2 \\\\\\\\\\\\\\\\\\\\\
	'UPGRADE_WARNING: 结构 PT_WatchdogStart 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_WatchdogStart Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef WatchdogStart As PT_WatchdogStart) As Integer
	Declare Function DRV_WatchdogFeed Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	Declare Function DRV_WatchdogStop Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	'/////////////////// V2.2 \\\\\\\\\\\\\\\\\\\\\

	'/////////////////// V2.2C \\\\\\\\\\\\\\\\\\\\\
	'UPGRADE_WARNING: 结构 PT_DioReadPortWord 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioReadPortWord Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioReadPortWord As PT_DioReadPortWord) As Integer
	'UPGRADE_WARNING: 结构 PT_DioWritePortWord 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioWritePortWord Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioWritePortWord As PT_DioWritePortWord) As Integer
	'UPGRADE_WARNING: 结构 PT_DioReadPortDword 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioReadPortDword Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioReadPortDword As PT_DioReadPortDword) As Integer
	'UPGRADE_WARNING: 结构 PT_DioWritePortDword 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioWritePortDword Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioWritePortDword As PT_DioWritePortDword) As Integer
	'UPGRADE_WARNING: 结构 PT_DioGetCurrentDOWord 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioGetCurrentDOWord Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioGetCurrentDOWord As PT_DioGetCurrentDOWord) As Integer
	'UPGRADE_WARNING: 结构 PT_DioGetCurrentDODword 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function DRV_DioGetCurrentDODword Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioGetCurrentDODword As PT_DioGetCurrentDODword) As Integer
	Declare Function DRV_FAITerminate Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	Declare Function DRV_FAOTerminate Lib "adsapi32.dll" (ByVal DriverHandle As Integer) As Integer
	'/////////////////// V2.2C \\\\\\\\\\\\\\\\\\\\\

	'=========================================================================
	' Description:
	'      Enable a specific DI event, and also specify a range of DI ports
	'      that will be scanned (read) when the specified event occurs.
	'
	' Parameters:
	' DriverHandle[in]:  Driver handle
	' dwEventID[in]:     which DIO Event to enable. It can be one of
	'                    ADS_EVT_DI_INTERRUPT0~184,
	'                    ADS_EVT_DI_PATTERNMATCH_PORT0~31,
	'                    ADS_EVT_DI_STATUSCHANGE_PORT0~31.
	' dwScanStart[in]:   start port which will be scaned when the specified event occurs.
	'                    this value must not exceed the max DI port the board supported.
	' dwScanCount[in]:   port count to be scaned when the specified event occurs. The
	'                    sum of this parameter plus the dwScanStart must not be bigger than
	'                    the max DI port the board supported.
	'
	'---------------------------------------------------------------------------------
	Declare Function AdxDioEnableEventAndSpecifyDiPorts Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwEventID As Integer, ByVal dwScanStart As Integer, ByVal dwScanCount As Integer) As Integer

	'=========================================================================
	' Description:
	'      Disable a specific enabled DI event. DI event can be enabled by
	'      the function AdcDioEventEnableAndSpecifyDiPorts.
	'      When the DI event is disabled, the related DI ports will also be released
	'
	' Parameters:
	' DriverHandle[in]:  Driver handle
	' dwEventID[in]:     which DI Interrupt Event to enable. It can be one of
	'                    ADS_EVT_DI_INTERRUPT0 ~184,
	'                    ADS_EVT_DI_PATTERNMATCH_PORT0~31,
	'                    ADS_EVT_DI_STATUSCHANGE_PORT0~31.
	'---------------------------------------------------------------------------------
	Declare Function AdxDioDisableEvent Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwEventID As Integer) As Integer

	'=========================================================================
	' Description:
	'      Retrieve the stored input data of the specified DI event's most
	'      recent occurrence. The event is enabled and the input range is defined
	'      by AdcDioEnableEventAndSpecifyDiPorts.
	'
	' Parameters:
	' DriverHandle[in]:  Driver handle
	' dwEventID[in]:     DI Event ID which DI data will be retrieved. It can be one of
	'                    ADS_EVT_DI_INTERRUPT0 ~184,
	'                    ADS_EVT_DI_PATTERNMATCH_PORT0~31,
	'                    ADS_EVT_DI_STATUSCHANGE_PORT0~31.
	' pBuffer[out]:      pointer to the user buffer to receive the DI data.
	' dwLength[in]:      length of the user buffer. IF the length is not enough to
	'                    store all the DI ports data, only the 'dwLength' number will
	'                    be stored.
	'
	'---------------------------------------------------------------------------------
	Declare Function AdxDioGetLatestEventDiPortsState Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwEventID As Integer, ByRef pBuffer As Byte, ByVal dwLength As Integer) As Integer

	'=========================================================================
	' Descriptions:
	'
	'    read DI ports.
	'
	' Parameters:
	' DriverHandle[in]:  Driver handle
	' dwPortStart[in]:   start port to read.
	' dwPortCount[in]:   port count to read.
	' pBuffer[out]:      pointer to user buffer. The buffer must be big enough
	'                    to store all DI data retrieved. The buffer size is equal
	'                    the number of dwPortCount in byte.
	'---------------------------------------------------------------------------------
	Declare Function AdxDioReadDiPorts Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwPortStart As Integer, ByVal dwPortCount As Integer, ByRef pBuffer As Byte) As Integer

	'=========================================================================
	' Description:
	'
	'    Write DO ports.
	'
	' Parameters:
	' DriverHandle[in]: Driver handle
	' dwPortStart[in]:  start port to write.
	' dwPortCount[in]:  port count to write.
	' pBuffer[out]:     pointer to DO data buffer to output.
	'---------------------------------------------------------------------------------
	Declare Function AdxDioWriteDoPorts Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwPortStart As Integer, ByVal dwPortCount As Integer, ByRef pBuffer As Byte) As Integer

	'=========================================================================
	' Description:
	'
	'    Get current state of DO ports
	'
	' Parameters:
	' DriverHandle[in]: Driver handle
	' dwPortStart[in]:  start port to get.
	' dwPortCount[in]:  port count to get.
	' pBuffer[out]:     pointer to user buffer. The buffer must be big enough
	'                   to store all DO data retrieved. The buffer size is equal
	'                   the number of dwPortCount in byte.
	'---------------------------------------------------------------------------------
	Declare Function AdxDioGetCurrentDoPortsState Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwPortStart As Integer, ByVal dwPortCount As Integer, ByRef pBuffer As Byte) As Integer

	'=========================================================================
	' Description:
	'
	'    Call dll driver's configuration dialog box to configure the board.
	'
	' Parameters:
	' DeviceNum[in]:  device number or fix number
	' BoardID[in]:    board ID. It's a software defined board id,
	'                 for example: BD_PCI1753, BD_MIC3753...
	'
	' hCaller[in]:    parent window handle
	'
	'---------------------------------------------------------------------------------
	Declare Function AdxDeviceConfig Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByVal BoardID As Integer, ByVal hCaller As Integer) As Integer

	Declare Function AdxDioEnableEventAndSpecifyEventCounter Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwEventID As Integer, ByVal dwScanStart As Integer, ByVal dwScanCount As Integer) As Integer
	Declare Function AdxCntrEnableEventAndSpecifyEventCounter Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwEventID As Integer, ByVal dwScanStart As Integer, ByVal dwScanCount As Integer) As Integer
	Declare Function AdxCntrDisableEvent Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwEventID As Integer) As Integer
	Declare Function AdxCntrGetLatestEventCounterValue Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal dwEventID As Integer, ByRef pBuffer As Integer, ByVal dwLength As Integer) As Integer

	Declare Function AdxPrivateHWRegionRead Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal StartAddress As Integer, ByVal DataCount As Integer, ByRef pBuffer As Byte) As Integer
	Declare Function AdxPrivateHWRegionWrite Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByVal StartAddress As Integer, ByVal DataCount As Integer, ByRef pBuffer As Byte) As Integer
	' CAN bus function declaration
	Declare Function CANPortOpen Lib "ads841.dll" (ByVal DevNum As Short, ByRef wPort As Short, ByRef wHostID As Short, ByRef wBaudRate As Short) As Integer
	Declare Function CANPortClose Lib "ads841.dll" (ByVal wPort As Short) As Integer
	Declare Function CANInit Lib "ads841.dll" (ByVal Port As Short, ByVal BTR0 As Short, ByVal BTR1 As Short, ByVal usMask As Byte) As Integer
	Declare Function CANReset Lib "ads841.dll" (ByVal Port As Short) As Integer
	Declare Function CANInpb Lib "ads841.dll" (ByVal Port As Short, ByVal offset As Short, ByRef Data As Byte) As Integer
	Declare Function CANOutpb Lib "ads841.dll" (ByVal Port As Short, ByVal offset As Short, ByVal value As Byte) As Integer
	Declare Function CANSetBaud Lib "ads841.dll" (ByVal Port As Short, ByVal BTR0 As Short, ByVal BTR1 As Short) As Integer
	Declare Function CANGetBaudRate Lib "ads841.dll" (ByVal Port As Short, ByRef wBaudRate As Short) As Integer
	Declare Function CANSetAcp Lib "ads841.dll" (ByVal Port As Short, ByVal Acp As Short, ByVal Mask As Short) As Integer
	Declare Function CANSetOutCtrl Lib "ads841.dll" (ByVal Port As Short, ByVal OutCtrl As Short) As Integer
	Declare Function CANSetNormal Lib "ads841.dll" (ByVal Port As Short) As Integer
	Declare Function CANHwReset Lib "ads841.dll" (ByVal Port As Short) As Integer
	Declare Function CANSendMsg Lib "ads841.dll" (ByVal Port As Short, ByVal TxBuf As String, ByVal Wait As Integer) As Integer
	Declare Function CANQueryMsg Lib "ads841.dll" (ByVal Port As Short, ByRef Ready As Integer, ByVal RcvBuf As String) As Integer
	Declare Function CANWaitForMsg Lib "ads841.dll" (ByVal Port As Short, ByVal RcvBuf As String, ByVal uTimeValue As Integer) As Integer
	Declare Function CANQueryID Lib "ads841.dll" (ByVal Port As Short, ByRef Ready As Integer, ByRef IDBuf As Byte) As Integer
	Declare Function CANWaitForID Lib "ads841.dll" (ByVal Port As Short, ByRef IDBuf As Byte, ByVal uTimeValue As Integer) As Integer
	Declare Function CANEnableMessaging Lib "ads841.dll" (ByVal Port As Short, ByVal Type1 As Short, ByVal Enabled As Integer, ByVal AppWnd As Integer, ByRef RcvBuf As String) As Integer
	Declare Function CANGetEventName Lib "ads841.dll" (ByVal Port As Short, ByRef RcvBuf As Byte) As Integer
	Declare Function CANEnableEvent Lib "ads841.dll" (ByVal Port As Short, ByVal Enabled As Integer) As Integer
	Declare Function CANCheckEvent Lib "ads841.dll" (ByVal Port As Short, ByVal Milliseconds As Integer) As Integer
	Declare Function CANPortOpenX Lib "ads841.dll" (ByVal wPort As Short, ByVal dwMemoryAddress As Integer, ByVal IRQ As Integer) As Integer

	'**************************************************************************
	'    Function Declaration for PCL-839
	'**************************************************************************
	Declare Function set_base Lib "ads839.dll" (ByVal address As Integer) As Integer
	Declare Function set_mode Lib "ads839.dll" (ByVal chan As Integer, ByVal mode As Integer) As Integer
	Declare Function set_speed Lib "ads839.dll" (ByVal chan As Integer, ByVal low_speed As Integer, ByVal high_speed As Integer, ByVal accelerate As Integer) As Integer
	Declare Function status Lib "ads839.dll" (ByVal chan As Integer) As Integer
	Declare Function m_stop Lib "ads839.dll" (ByVal chan As Integer) As Integer
	Declare Function slowdown Lib "ads839.dll" (ByVal chan As Integer) As Integer
	Declare Function sldn_stop Lib "ads839.dll" (ByVal chan As Integer) As Integer
	Declare Function waitrdy Lib "ads839.dll" (ByVal chan As Integer) As Integer
	Declare Function chkbusy Lib "ads839.dll" () As Integer
	Declare Function out_port Lib "ads839.dll" (ByVal port_no As Integer, ByVal value As Integer) As Integer
	Declare Function in_port Lib "ads839.dll" (ByVal port_no As Integer) As Integer
	Declare Function In_byte Lib "ads839.dll" (ByVal offset As Integer) As Integer
	Declare Function Out_byte Lib "ads839.dll" (ByVal offset As Integer, ByVal value As Integer) As Integer
	Declare Function org Lib "ads839.dll" (ByVal chan As Integer, ByVal dir1 As Integer, ByVal speed1 As Integer, ByVal dir2 As Integer, ByVal speed2 As Integer, ByVal dir3 As Integer, ByVal speed3 As Integer) As Integer
	Declare Function cmove Lib "ads839.dll" (ByVal chan As Integer, ByVal dir1 As Integer, ByVal speed1 As Integer, ByVal dir2 As Integer, ByVal speed2 As Integer, ByVal dir3 As Integer, ByVal speed3 As Integer) As Integer
	Declare Function pmove Lib "ads839.dll" (ByVal chan As Integer, ByVal dir1 As Integer, ByVal speed1 As Integer, ByVal step1 As Integer, ByVal dir2 As Integer, ByVal speed2 As Integer, ByVal step2 As Integer, ByVal dir3 As Integer, ByVal speed3 As Integer, ByVal step3 As Integer) As Integer
	Declare Function line Lib "ads839.dll" (ByVal plan_ch As Integer, ByVal dx As Integer, ByVal dy As Integer) As Integer
	Declare Function line3D Lib "ads839.dll" (ByVal plan_ch As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal dz As Integer) As Integer
	Declare Function arc Lib "ads839.dll" (ByVal plan_ch As Integer, ByVal dirc As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Integer

	Declare Function CreateToolhelp32Snapshot Lib "kernel32" (ByVal dwFlags As Integer, ByVal th32ProcessID As Integer) As Integer
	'UPGRADE_WARNING: 结构 PROCESSENTRY32 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function Process32First Lib "kernel32" (ByVal hSnapShot As Integer, ByRef lppe As PROCESSENTRY32) As Integer
	'UPGRADE_WARNING: 结构 PROCESSENTRY32 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Declare Function Process32Next Lib "kernel32" (ByVal hSnapShot As Integer, ByRef lppe As PROCESSENTRY32) As Integer
	Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal blnheritHandle As Integer, ByVal dwAppProcessId As Integer) As Integer
	Declare Function TerminateProcess Lib "kernel32" (ByVal ApphProcess As Integer, ByVal uExitCode As Integer) As Integer
	Declare Sub CloseHandle Lib "kernel32" (ByVal hPass As Integer)
	Declare Function GetTickCount Lib "kernel32" () As Integer
End Module