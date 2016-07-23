Imports Microsoft.VisualBasic.DataMining
Imports Microsoft.VisualBasic.DataMining.NeuralNetwork
Imports Microsoft.VisualBasic

''' <summary>
''' Using neuron network to test a authorization.
''' </summary>
''' <remarks>
''' 质数: 质数（prime number）又称素数，有无限个。除了1和它本身以外不再被其他的除数整除。
''' 偶数: 所有整数不是奇数（单数），就是偶数（双数）。若某数是2的倍数，它就是偶数（双数），可表示为2n；
''' 奇数: 若某数不是2的倍数，它就是奇数（单数），可表示为2n+1（n为整数），即奇数（单数）除以二的余数是一
''' 重复数: 数字之中某一个数多次重复出现
''' </remarks>
Public Class NeuronTest

    ReadOnly __server As Server

    Sub New(server As Server)
        __server = server
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="token">从客户端传输到服务器端进行验证的数据，输入的数据都是原始的未经过转换的数据</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' 为了确保安全，会进行若干次测试，假若通过测试，则会将得分最高的添加进入数据库之中
    ''' </remarks>
    Public Function Test(token As neural_tokens(), user As Long) As Boolean
        Dim SQL As String = String.Format(SQLGetTestByUserId, user)
        Dim testData As Storage.MySql.neural_tokens() =
            __server.MySql.Query(Of Storage.MySql.neural_tokens)(SQL)
        Dim ANN As New Network(5, 30, 1, 0.1,, New IFuncs.SigmoidFunction) ' 输入5个数据计算出一个最偏爱的数值，共10层网络
        Dim learn As New TrainingUtils(ANN)

        For Each x In testData
            Call learn.Add(x.ToArray, {x.GetValue})
        Next

        Call learn.Train()

        Dim result As New List(Of Boolean)

        For Each x As neural_tokens In token
            Dim out As NumProperties = Maps.Decode(learn.NeuronNetwork.Compute(x.ToArray)(Scan0))
            Dim [in] As NumProperties = x(x.key).Transform
            result += [in] = out
        Next

        Dim nT As Integer = result.Where(Function(x) x).Count
        Dim hn As Integer = result.Count / 2
        Dim testResult As Boolean = nT >= hn

        If testResult = True Then  ' update database when success
            For i As Integer = 0 To token.Length - 1
                If result(i) Then
                    Dim write As Storage.MySql.neural_tokens =
                        token(i).NewToken(token(i).key, user)
                    Call __server.MySql.ExecInsert(write)
                End If
            Next
        End If

        Return testResult
    End Function

    Const SQLGetTestByUserId As String = "SELECT * FROM neural_tokens WHERE user={0};"

End Class
