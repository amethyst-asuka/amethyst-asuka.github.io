Imports System.Runtime.CompilerServices

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
End Module
