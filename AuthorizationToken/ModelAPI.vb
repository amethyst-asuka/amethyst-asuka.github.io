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
            .t1 = test.t1,
            .t2 = test.t2,
            .t3 = test.t3,
            .t4 = test.t4,
            .t5 = test.t5,
            .user = user
        }
    End Function

    <Extension>
    Public Function ToArray(x As Storage.MySql.neural_tokens) As Double()
        Return New Double() {x.t1, x.t2, x.t3, x.t4, x.t5}
    End Function

    <Extension>
    Public Function ToArray(x As neural_tokens) As Double()
        Return New Double() {x.t1, x.t2, x.t3, x.t4, x.t5}
    End Function

    <Extension>
    Public Function GetValue(x As Storage.MySql.neural_tokens) As Double
        Select Case x.key
            Case 0 : Return x.t1
            Case 1 : Return x.t2
            Case 2 : Return x.t3
            Case 3 : Return x.t4
            Case 4 : Return x.t5
            Case Else
                Throw New Exception(x.GetJson)
        End Select
    End Function
End Module
