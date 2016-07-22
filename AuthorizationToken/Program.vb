Imports Microsoft.VisualBasic.Serialization.JSON

Module Program

    Sub Main()
        Dim s As New Server("127.0.0.1", "root", "1234")
        Dim dev As device_tree = UsersAPI.CurrentDevice
        Dim u As New users With {
            .email = "amethyst.asuka@gcmodeller.org"
        }

        Call s.NewUser(u, dev).__DEBUG_ECHO

        '      Dim m As String = Win32.HardwareInfo.SystemSerialNumber
        '    Dim c As String = Win32.HardwareInfo.CPU_Id
        '    Dim hd = Win32.HardwareInfo.HarddriveInfo

        '    Call m.__DEBUG_ECHO
        '  Call c.__DEBUG_ECHO
        '  Call hd.GetJson.__DEBUG_ECHO

        Pause()
    End Sub
End Module
