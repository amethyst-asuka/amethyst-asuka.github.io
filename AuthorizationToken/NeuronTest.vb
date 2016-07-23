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
    ''' <param name="token"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' 为了确保安全，会进行若干次测试，假若通过测试，则会将得分最高的添加进入数据库之中
    ''' </remarks>
    Public Function Test(token As neural_tokens(), user As Long) As Boolean
        Dim SQL As String = String.Format(SQLGetTestByUserId, user)
        Dim testData As Storage.MySql.neural_tokens() =
            __server.MySql.Query(Of Storage.MySql.neural_tokens)(SQL)
        Dim ANN As New Network(5, 10, 1,,, New IFuncs.SigmoidFunction) ' 输入5个数据计算出一个最偏爱的数值，共10层网络
        Dim learn As New TrainingUtils(ANN) With {
            .TrainingType = TrainingType.Epoch
        }

        For Each x In testData
            Call learn.Add(x.ToArray, {x.GetValue})
        Next

        Call learn.Train()

        Dim result As New List(Of Double)

        For Each x In token
            result += learn.NeuronNetwork.Compute(x.ToArray)(Scan0)
        Next


    End Function

    Const SQLGetTestByUserId As String = "SELECT * FROM neural_tokens WHERE user={0};"

End Class
