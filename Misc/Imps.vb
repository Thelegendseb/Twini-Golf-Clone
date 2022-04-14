Public Class Imps

    Public Shared xinc As Single = 31.25
    Public Shared yinc As Single = 29.25

    Public Shared HoleSize As Integer = 16

    Public Shared Function IsHit(x As Integer, y As Integer, L As Level) As Boolean

        Dim PredictedRect As Rectangle = New Rectangle(x - CSng(Ball.Size / 2), y - CSng(Ball.Size / 2),
                                                       Ball.Size, Ball.Size)

        For Each Block In L.Blocks
            If PredictedRect.IntersectsWith(Block) Then
                Return True
            End If
        Next
        Return False
    End Function

End Class
