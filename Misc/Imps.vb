Public Class Imps

    Public Shared xinc As Single = 31.25
    Public Shared yinc As Single = 29.25

    Public Shared HoleSize As Integer = 16

    Public Shared Function IsHit(x As Integer, y As Integer, L As Level) As Boolean

        If L.CellStatus.GetLength(0) - 1 < (Math.Round(y / Imps.yinc)) Then
            Return False
        End If
        If L.CellStatus.GetLength(1) - 1 < (Math.Round(x / Imps.xinc)) Then
            Return False
        End If


        If L.CellStatus(Math.Round(y / Imps.yinc), Math.Round(x / Imps.xinc)) <> 0 Then
            Return True
        End If
        Return False

    End Function

End Class
