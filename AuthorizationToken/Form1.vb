Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim test As neural_tokens = neural_tokens.NewToken
        Button1.Text = test.t1
        Button2.Text = test.t2
        Button3.Text = test.t3
        Button4.Text = test.t4
        Button5.Text = test.t5
    End Sub

    Dim server As New Server("127.0.0.1", "root", "1234")
    Dim n As Integer = 5
    Dim testTokens As New List(Of neural_tokens)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click
        Dim index As Integer = DirectCast(sender, Button).Text.Match("\d+").ParseInteger
        Dim test As New neural_tokens With {
            .t1 = CInt(Button1.Text),
            .t2 = CInt(Button2.Text),
            .t3 = CInt(Button3.Text),
            .t4 = CInt(Button4.Text),
            .t5 = CInt(Button5.Text)
        }

        test.key = test.IndexOf(index)

        '     If n > -1 Then
        '   testTokens += test
        '    n -= 1
        '   Else
        '  n = 5
        '   MsgBox(New NeuronTest(server).Test(testTokens, 2))
        '  testTokens.Clear()
        '  End If

        Dim data = test.NewToken(test.IndexOf(index), 2)
        Call server.MySql.ExecInsert(data)
        Call Button6_Click(Nothing, Nothing)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Button6_Click(Nothing, Nothing)


        Call 22222222L.Transform
    End Sub
End Class