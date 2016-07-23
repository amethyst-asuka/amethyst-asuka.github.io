Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Serialization.JSON

Module ModelAPI

    <Extension>
    Public Function NewDevice(dev As device_tree) As Storage.MySql.device_tree
        Return New Storage.MySql.device_tree With {
            .device_name = dev.device_name,
            .note = dev.note,
            .register_time = dev.register_time,
            .token = dev.token,
            .uid = dev.uid
        }
    End Function

    <Extension>
    Public Function NewToken(test As neural_tokens, index As Integer, user As Long) As Storage.MySql.neural_tokens
        Return New Storage.MySql.neural_tokens With {
            .key = index,
            .t1 = test.t1.Transform,
            .t2 = test.t2.Transform,
            .t3 = test.t3.Transform,
            .t4 = test.t4.Transform,
            .t5 = test.t5.Transform,
            .user = user
        }
    End Function

    <Extension>
    Public Function ToArray(x As Storage.MySql.neural_tokens) As Double()
        Return New Double() {x.t1, x.t2, x.t3, x.t4, x.t5}
    End Function

    <Extension>
    Public Function ToArray(x As neural_tokens) As Double()
        Return New Double() {
            x.t1.Transform,
            x.t2.Transform,
            x.t3.Transform,
            x.t4.Transform,
            x.t5.Transform
        }
    End Function

    ''' <summary>
    ''' 返回的值是已经被编码过的
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    <Extension>
    Public Function GetValue(x As Storage.MySql.neural_tokens) As Double
        Select Case x.key
            Case 0 : Return Maps(x.t1)
            Case 1 : Return Maps(x.t2)
            Case 2 : Return Maps(x.t3)
            Case 3 : Return Maps(x.t4)
            Case 4 : Return Maps(x.t5)
            Case Else
                Throw New Exception(x.GetJson)
        End Select
    End Function
End Module
