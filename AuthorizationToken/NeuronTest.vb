Imports Microsoft.VisualBasic.DataMining
Imports Microsoft.VisualBasic.DataMining.NeuralNetwork
Imports Microsoft.VisualBasic

''' <summary>
''' Using neuron network to test a authorization.
''' </summary>
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
