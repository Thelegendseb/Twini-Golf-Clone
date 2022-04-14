Public Class GameGraphics

    Public Canvas As Bitmap

    Sub New(S As Size)
        Canvas = New Bitmap(S.Width, S.Height)
    End Sub
    Public Shared Sub DrawBackground(ByRef bmp As Bitmap)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.DrawImage(My.Resources.bg, 0, 0, bmp.Width, bmp.Height)
        End Using
    End Sub
    Public Shared Sub AddLevelbg(bg As Bitmap, ByRef curr As Bitmap)
        Using g As Graphics = Graphics.FromImage(curr)
            g.DrawImage(bg, 0, 0, bg.Width, bg.Height)
        End Using
    End Sub
    Public Shared Sub DrawTile(ByRef bmp As Bitmap, Size As Integer, Shade As Char, P As Point)

        Using g As Graphics = Graphics.FromImage(bmp)
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

    Public Shared Sub DrawLevel(ByRef bmp As Bitmap, L As Level)

        For i = 0 To L.CellStatus.GetLength(0) - 1
            For j = 0 To L.CellStatus.GetLength(1) - 1

                If L.CellStatus(i, j) = 2 Then
                    DrawTile(bmp, 32, "L", New Point(i * Imps.xinc, j * Imps.yinc))
                ElseIf L.CellStatus(i, j) = 3 Then
                    DrawTile(bmp, 32, "D", New Point(i * Imps.xinc, j * Imps.yinc))
                ElseIf L.CellStatus(i, j) = 4 Then
                    DrawTile(bmp, 64, "L", New Point(i * Imps.xinc, j * Imps.yinc))
                ElseIf L.CellStatus(i, j) = 5 Then
                    DrawTile(bmp, 64, "D", New Point(i * Imps.xinc, j * Imps.yinc))
                End If

            Next
        Next
    End Sub
    Public Shared Sub DrawHoles(ByRef bmp As Bitmap, L As Level)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.FillEllipse(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), L.Hole1.X - CSng(Imps.HoleSize / 2), L.Hole1.Y - CSng(Imps.HoleSize / 2) - 2, Imps.HoleSize, Imps.HoleSize)
            g.FillEllipse(Brushes.Black, L.Hole1.X - CSng(Imps.HoleSize / 2), L.Hole1.Y - CSng(Imps.HoleSize / 2), Imps.HoleSize, Imps.HoleSize)

            g.FillEllipse(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), L.Hole2.X - CSng(Imps.HoleSize / 2), L.Hole2.Y - CSng(Imps.HoleSize / 2) - 2, Imps.HoleSize, Imps.HoleSize)
            g.FillEllipse(Brushes.Black, L.Hole2.X - CSng(Imps.HoleSize / 2), L.Hole2.Y - CSng(Imps.HoleSize / 2), Imps.HoleSize, Imps.HoleSize)
        End Using
    End Sub

    Public Shared Sub DrawBall(ByRef bmp As Bitmap, B As Ball)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.FillEllipse(Brushes.White, B.x - CSng((B.Size / 2)), B.y - CSng((B.Size / 2)), B.Size, B.Size)
        End Using
    End Sub

End Class
