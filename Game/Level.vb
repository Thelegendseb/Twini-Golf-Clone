Public Class Level

    Public Over As Boolean
    Public CellStatus(19, 14) As Byte
    Public Hole1, Hole2 As Point
    Public Hole1Status, Hole2Status As Boolean
    Public Start1, Start2 As Point
    Public StrokeCount As Integer

    Public Blocks As New List(Of Rectangle)

    Public Levelbg As Bitmap

    Sub New(S As Size)
        Levelbg = New Bitmap(S.Width, S.Height)
    End Sub

    Public Sub Assign(y As Integer, x As Integer, type As Char, size As Integer)

        Dim mult As Integer = 2
        If size = 32 Then mult = 1
        Blocks.Add(New Rectangle(x * Imps.xinc, y * Imps.yinc, mult * Imps.xinc, mult * Imps.yinc))
        Select Case size
            Case 32
                If type = "L" Then
                    CellStatus(x, y) = 2
                Else
                    CellStatus(x, y) = 3
                End If
            Case 64
                If type = "L" Then
                    CellStatus(x, y) = 4
                Else
                    CellStatus(x, y) = 5
                End If
        End Select
    End Sub


    '==========================================
    'LEVELS
    Public Sub Load(x As Integer)

        ResetMe()
        GameGraphics.DrawBackground(Levelbg)

        Select Case x
            Case 1
                Me.Hole1 = New Point(160 - (Ball.Size / 2), 150)
                Me.Hole2 = New Point(480 - Ball.Size - 3, 350)
                Me.Start1 = New Point(160 - (Ball.Size / 2), 350)
                Me.Start2 = New Point(480 - Ball.Size - 3, 250)

                Me.Assign(3, 14, "L", 64)
            Case 2
                Me.Hole1 = New Point(Imps.xinc * 7, Imps.yinc * 12)
                Me.Hole2 = New Point(Imps.xinc * 17, Imps.yinc * 3)
                Me.Start1 = New Point(Imps.xinc * 7, Imps.yinc * 3)
                Me.Start2 = New Point(Imps.xinc * 17, Imps.yinc * 12)

                Me.Assign(3, 1, "D", 64)
                Me.Assign(11, 1, "D", 32)
                Me.Assign(13, 4, "D", 32)
                Me.Assign(9, 6, "D", 32)
                Me.Assign(7, 7, "D", 32)

                Me.Assign(10, 12, "L", 64)
                Me.Assign(7, 11, "L", 32)
                Me.Assign(1, 12, "L", 32)
                Me.Assign(5, 16, "L", 32)
                Me.Assign(6, 17, "L", 32)
            Case 3

            Case 4
            Case 5
            Case 6
            Case 7
            Case 8
            Case 9
            Case 10
        End Select
        GameGraphics.DrawLevel(Levelbg, Me)
        GameGraphics.DrawHoles(Levelbg, Me)

    End Sub

    Public Sub ResetMe()
        Blocks.Clear()
        Hole1Status = False
        Hole2Status = False
        Hole1 = Nothing
        Hole2 = Nothing
        Start1 = Nothing
        Start2 = Nothing
        CellStatus = New Byte(19, 14) {}
        StrokeCount = 0
    End Sub

End Class
