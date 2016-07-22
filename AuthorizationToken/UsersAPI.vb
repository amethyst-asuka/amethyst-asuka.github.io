Imports Microsoft.VisualBasic.SecurityString
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Win32

Public Module UsersAPI

    Public Function CurrentDevice() As device_tree
        Dim token As String() = {
            HardwareInfo.CPU_Id,
            HardwareInfo.SystemSerialNumber,
            HardwareInfo.HarddriveInfo.FirstOrDefault?.SerialNo
        }
        Dim name As String = Environment.MachineName
        Dim os As String = Environment.OSVersion.VersionString

        Return New device_tree With {
            .device_name = name,
            .note = os,
            .register_time = Now.ToString,
            .token = token.GetJson.GetMd5Hash
        }
    End Function

    Public Function NewUser() As users

    End Function
End Module
