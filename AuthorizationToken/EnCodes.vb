Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Language

Module EnCodes

    Public Enum NumProperties As Integer

        ''' <summary>
        ''' 1、4、9、0为平方数，因为相应数量的点或圆形可以排列成完美的正方形
        ''' </summary>
        SquareNumber = 2
        ''' <summary>
        ''' 1、3、6、为三角形数，同样，相应数量的点可以形成正三角形
        ''' </summary>
        TriangularNumber = 4
        ''' <summary>
        ''' 2、6、为长方形数，相应数量的点可以排成矩形
        ''' </summary>
        RectangleNumber = 8
        ''' <summary>
        ''' 5
        ''' </summary>
        N5 = 16
        N7 = 32
        N8 = 64

        ''' <summary>
        ''' 部分连续重复出现
        ''' </summary>
        Repeats = 128
        ''' <summary>
        ''' 全部连续重复出现
        ''' </summary>
        AllRepeats = 256
        ''' <summary>
        ''' 以什么数字结束
        ''' </summary>
        EndWith = 512
        ''' <summary>
        ''' 组成最多的
        ''' </summary>
        MostComposition = 1024

        ''' <summary>
        ''' 质数
        ''' </summary>
        Prime = 2048
        ''' <summary>
        ''' 偶数
        ''' </summary>
        Even = 4096
        ''' <summary>
        ''' 奇数
        ''' </summary>
        Odd = 8192
    End Enum

    <Extension>
    Public Function Transform(n As Long) As Double
        Dim s As String = CStr(n)
        Dim p As NumProperties

        If s.Length = 1 Then
            Return CInt(n).Type
        End If
        If s.Length > 1 Then
            p = GetRepeats(s)
            If p <> 0 Then
                Return p
            End If
        End If
        If s.Length > 2 Then
            p = s.Composition
            If p <> 0 Then
                Return p
            End If
        End If

        p = s.EndWith

        Return p
    End Function

    <Extension>
    Public Function Composition(n As String) As NumProperties
        Dim maxn As Integer, maxL As Integer = -1
        Dim c As New Value(Of Integer)

        For i As Integer = 0 To 9
            If (c = n.Count(i.ToString.First)) > 0 Then
                If maxL < c.value Then
                    maxL = c.value
                    maxn = i
                End If
            End If
        Next

        If c = 1 Then
            Return 0
        Else
            Return NumProperties.MostComposition + maxn.Type
        End If
    End Function

    <Extension>
    Public Function EndWith(n As String) As NumProperties
        n = n.Last
        Return CInt(n).Type
    End Function

    Public Function GetRepeats(n As String) As NumProperties
        Dim m As String
        Dim rs As New List(Of String)

        For i As Integer = 0 To 9
            m = Regex.Match(n, i & "{2,}").Value
            If Not String.IsNullOrEmpty(m) Then
                rs += m
            End If
        Next

        If rs.Count = 0 Then
            Return 0
        Else
            Dim first As New Value(Of String)
            Dim ml As String

            If rs.Count = 1 Then
                If (first = rs.First).Length = n.Length Then
                    Return NumProperties.AllRepeats + CInt(CStr(first.value.First)).Type
                Else
                    ml = first
                End If
            Else
                ml = LinqAPI.DefaultFirst(Of String) <=
                    From x As String
                    In rs
                    Select x
                    Order By x.GetLength Descending   ' 只按照最长的那个来计算
            End If

            Return NumProperties.Repeats + CInt(CStr(first.value.First)).Type
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="n">0-9</param>
    ''' <returns></returns>
    <Extension>
    Public Function Type(n As Integer) As NumProperties
        Select Case n
            Case 1, 4, 9, 0
                Return NumProperties.SquareNumber
            Case 1, 3, 6
                Return NumProperties.TriangularNumber
            Case 2, 6
                Return NumProperties.RectangleNumber
            Case 5
                Return NumProperties.N5
            Case 7
                Return NumProperties.N7
            Case 8
                Return NumProperties.N8
            Case Else
                Throw New Exception($"n:={n}")
        End Select
    End Function
End Module
