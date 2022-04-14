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
        P.Y -= 14
        P.X -= 4
        Using g As Graphics = Graphics.FromImage(Canvas)
            Select Case Size
                Case 32
                    If Shade = "L" Then
                        g.DrawImage(My.Resources.tile32_light, P.X, P.Y, 32, 32)
                    ElseIf Shade = "D" Then
                        g.DrawImage(My.Resources.tile32_dark, P.X, P.Y, 32, 32)
                    End If
                Case 64
                    If Shade = "L" Then
                        g.DrawImage(My.Resources.tile32_light, P.X, P.Y, 64, 64)
                    ElseIf Shade = "D" Then
                        g.DrawImage(My.Resources.tile32_dark, P.X, P.Y, 64, 64)
                    End If
                Case Else
            End Select
        End Using
    End Sub

    Public Sub DrawLevel(L As Level)

        For i = 0 To L.CellStatus.GetLength(0) - 1
            For j = 0 To L.CellStatus.GetLength(1) - 1

                If L.CellStatus(i, j) = 3 Then
                    DrawTile(32, "L", New Point(i * 32, j * 32))
                ElseIf L.CellStatus(i, j) = 4 Then
                    DrawTile(32, "D", New Point(i * 32, j * 32))
                End If

            Next
        Next

        DrawHoles(L)
    End Sub

    Public Sub Balls(Ball1 As Ball, Ball2 As Ball)
        DrawBall(Ball1)
        DrawBall(Ball2)
    End Sub
    Private Sub DrawHoles(L As Level)
        Using g As Graphics = Graphics.FromImage(Canvas)
            g.FillEllipse(Brushes.Black, L.Hole1.X - 8, L.Hole1.Y - 8, 16, 16)
            g.FillEllipse(Brushes.Black, L.Hole2.X - 8, L.Hole2.Y - 8, 16, 16)
        End Using
    End Sub

    Public Sub DrawBall(B As Ball)
        Using g As Graphics = Graphics.FromImage(Canvas)
            g.FillEllipse(Brushes.White, B.x - CSng((B.Size / 2)), B.y - CSng((B.Size / 2)), B.Size, B.Size)
        End Using
    End Sub

End Class
