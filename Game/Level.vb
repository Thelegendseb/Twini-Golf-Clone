Public Class Level

    Public Over As Boolean
    Public CellStatus(14, 19) As Byte
    Public Hole1, Hole2 As Point
    Public Start1, Start2 As Point


    Public Sub Assign(x As Integer, y As Integer, type As Char, size As Integer)
        Select Case size
            Case 32
                If type = "L" Then
                    CellStatus(y, x) = 3
                Else
                    CellStatus(y, x) = 4
                End If
            Case 64
                If type = "L" Then
                    CellStatus(y, x) = 3
                    CellStatus(y + 1, x) = 1
                    CellStatus(y, x + 1) = 1
                    CellStatus(y + 1, x + 1) = 1
                Else
                    CellStatus(y, x) = 4
                    CellStatus(y + 1, x) = 2
                    CellStatus(y, x + 1) = 2
                    CellStatus(y + 1, x + 1) = 2
                End If
        End Select
    End Sub


    '==========================================
    'LEVELS
    Public Function Load(x As Integer) As Level
        Dim r As New Level
        Select Case x
            Case 1
                r.Hole1 = New Point(160 - (Ball.Size / 2), 150)
                r.Hole2 = New Point(480 - Ball.Size - 3, 350)
                r.Start1 = New Point(160 - (Ball.Size / 2), 350)
                r.Start2 = New Point(480 - Ball.Size - 3, 250)

                Assign(14, 2, "L", 64)
            Case 2
            Case 3
            Case 4
            Case 5
            Case 6
            Case 7
            Case 8
            Case 9
            Case 10
        End Select
        Return r
    End Function

End Class
