Imports Microsoft.VisualBasic.Language
Imports Oracle.LinuxCompatibility.MySQL

Public Class Server

    Public ReadOnly Property MySql As New MySQL

    Sub New(ip As String, user As String, pass As String)
        Dim cnn As New ConnectionUri With {
            .IPAddress = ip,
            .User = user,
            .Password = pass,
            .ServicesPort = 3306,
            .Database = "authorization_token"
        }
        Dim ping As New Value

        If (ping = MySql.Connect(cnn)) = -1.0R Then
            Throw New Exception("MySql connection failed!")
        Else
            Call $"Ping {ping}ms".__DEBUG_ECHO
        End If
    End Sub

    ''' <summary>
    ''' 返回<see cref="Storage.MySql.users.uid"/>
    ''' </summary>
    ''' <param name="user"></param>
    ''' <param name="root"></param>
    ''' <returns></returns>
    Public Function NewUser(user As users, root As device_tree) As Long
        If GetUserByEMail(user.email) Is Nothing Then
            ' 因为是新用户注册，所以当前设备是根设备，-1
            Dim dev As Storage.MySql.device_tree = root.NewDevice
            dev.parent = -1
            MySql.ExecInsert(dev)
            dev = GetNewDevice(dev)

            Dim usr As New Storage.MySql.users With {
                .email = user.email,
                .root_device = dev.uid
            }

            If MySql.ExecInsert(usr) Then
                Return GetUserByEMail(usr.email)?.uid
            Else
                Return -2
            End If
        Else
            Return -1
        End If
    End Function

    Public Function MaxDeviceUid() As Long
        Return MySql.ExecuteAggregate(Of Long)(SQLMaxDeviceUid)
    End Function

    Public Function GetNewDevice([new] As Storage.MySql.device_tree) As Storage.MySql.device_tree
        Dim SQL As String = String.Format(SQLGetNewDevice, [new].token, [new].parent, MaxDeviceUid)
        Return MySql.ExecuteScalar(Of Storage.MySql.device_tree)(SQL)
    End Function

    Const SQLMaxDeviceUid As String = "SELECT MAX(uid) FROM device_tree;"
    Const SQLGetNewDevice As String = "SELECT * FROM device_tree WHERE lower(token)='{0}' AND parent={1} AND uid>={2} LIMIT 1;"
    Const SQLGetUserByEMail As String = "SELECT * FROM users WHERE lower(email)='{0}' LIMIT 1;"

    Public Function GetUserByEMail(email As String) As Storage.MySql.users
        Dim SQL As String = String.Format(SQLGetUserByEMail, email.ToLower)
        Return MySql.ExecuteScalar(Of Storage.MySql.users)(SQL)
    End Function
End Class
