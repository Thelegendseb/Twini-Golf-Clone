Public Class Level

    Public Over As Boolean
    Public CellStatus(19, 14) As Byte
    Public Hole1, Hole2 As Point
    Public Hole1Status, Hole2Status As Boolean
    Public Start1, Start2 As Point


    Public Sub Assign(y As Integer, x As Integer, type As Char, size As Integer)
        Select Case size
            Case 32
                If type = "L" Then
                    CellStatus(y, x) = 2
                Else
                    CellStatus(y, x) = 3
                End If
            Case 64
                If type = "L" Then
                    CellStatus(y, x) = 4
                    CellStatus(y + 1, x) = 1
                    CellStatus(y, x + 1) = 1
                    CellStatus(y + 1, x + 1) = 1
                Else
                    CellStatus(y, x) = 5
                    CellStatus(y + 1, x) = 1
                    CellStatus(y, x + 1) = 1
                    CellStatus(y + 1, x + 1) = 1
                End If
        End Select
    End Sub


    '==========================================
    'LEVELS
    Public Sub Load(x As Integer)

        ResetMe()

        Select Case x
            Case 1
                Me.Hole1 = New Point(160 - (Ball.Size / 2), 150)
                Me.Hole2 = New Point(480 - Ball.Size - 3, 350)
                Me.Start1 = New Point(160 - (Ball.Size / 2), 350)
                Me.Start2 = New Point(480 - Ball.Size - 3, 250)

                Me.Assign(14, 3, "L", 64)
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

    End Sub

    Public Sub ResetMe()
        Hole1Status = False
        Hole2Status = False
        CellStatus = New Byte(19, 14) {}
    End Sub

End Class
