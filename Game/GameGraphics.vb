Public Class GameGraphics

    Public Canvas As Bitmap

    Sub New(S As Size)
        Canvas = New Bitmap(S.Width, S.Height)
    End Sub
    Public Sub DrawBackground()
        Using g As Graphics = Graphics.FromImage(Canvas)
            g.DrawImage(My.Resources.bg, 0, 0, Canvas.Width, Canvas.Height)
        End Using
    End Sub
    Public Sub DrawTile(Size As Integer, Shade As Char, P As Point)

        Using g As Graphics = Graphics.FromImage(Canvas)
            Select Case Size
                Case 32
                    If Shade = "L" Then
                        g.DrawImage(My.Resources.tile32_light, P.X, P.Y, 32 - 1, 32 - 1)
                    ElseIf Shade = "D" Then
                        g.DrawImage(My.Resources.tile32_dark, P.X, P.Y, 32 - 1, 32 - 1)
                    End If
                Case 64
                    If Shade = "L" Then
                        g.DrawImage(My.Resources.tile64_light, P.X, P.Y, 64 - 1, 64 - 1)
                    ElseIf Shade = "D" Then
                        g.DrawImage(My.Resources.tile64_dark, P.X, P.Y, 64 - 1, 64 - 1)
                    End If
                Case Else
            End Select
        End Using
    End Sub

    Public Sub DrawLevel(L As Level)

        For i = 0 To L.CellStatus.GetLength(0) - 1
            For j = 0 To L.CellStatus.GetLength(1) - 1

                If L.CellStatus(i, j) = 2 Then
                    DrawTile(32, "L", New Point(i * Imps.xinc, j * Imps.yinc))
                ElseIf L.CellStatus(i, j) = 3 Then
                    DrawTile(32, "D", New Point(i * Imps.xinc, j * Imps.yinc))
                ElseIf L.CellStatus(i, j) = 4 Then
                    DrawTile(64, "L", New Point(i * Imps.xinc, j * Imps.yinc))
                ElseIf L.CellStatus(i, j) = 5 Then
                    DrawTile(64, "D", New Point(i * Imps.xinc, j * Imps.yinc))
                End If

            Next
        Next

        DrawHoles(L)
    End Sub
    Private Sub DrawHoles(L As Level)
        Using g As Graphics = Graphics.FromImage(Canvas)
            g.FillEllipse(Brushes.Black, L.Hole1.X - CSng(Imps.HoleSize / 2), L.Hole1.Y - CSng(Imps.HoleSize / 2), Imps.HoleSize, Imps.HoleSize)
            g.FillEllipse(Brushes.Black, L.Hole2.X - CSng(Imps.HoleSize / 2), L.Hole2.Y - CSng(Imps.HoleSize / 2), Imps.HoleSize, Imps.HoleSize)
        End Using
    End Sub

    Public Sub DrawBall(B As Ball)
        Using g As Graphics = Graphics.FromImage(Canvas)
            g.FillEllipse(Brushes.White, B.x - CSng((B.Size / 2)), B.y - CSng((B.Size / 2)), B.Size, B.Size)
        End Using
    End Sub

End Class
