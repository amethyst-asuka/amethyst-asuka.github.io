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

        If (ping <= MySql.Connect(cnn)) = -1.0R Then
            Throw New Exception("MySql connection failed!")
        Else
            Call $"Ping {ping}ms".__DEBUG_ECHO
        End If
    End Sub
End Class
