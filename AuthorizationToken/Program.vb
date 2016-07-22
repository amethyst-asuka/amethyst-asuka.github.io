Imports Microsoft.VisualBasic.Serialization.JSON

Module Program

    Sub Main()
        Dim m As String = Win32.HardwareInfo.SystemSerialNumber
        Dim c As String = Win32.HardwareInfo.CPU_Id
        Dim hd = Win32.HardwareInfo.HarddriveInfo

        Call m.__DEBUG_ECHO
        Call c.__DEBUG_ECHO
        Call hd.GetJson.__DEBUG_ECHO

        Pause()
    End Sub
End Module
