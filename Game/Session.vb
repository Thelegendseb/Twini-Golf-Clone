Public Class Session

    Public MyGraphics As GameGraphics

    Public MouseOperations As MouseOps

    Public CurrentLevel As Level
    Public CurrentLevelCount As Integer = 1

    Public Power As Integer
    Public Xoffset As Integer
    Public Yoffset As Integer

    Public Ball1 As Ball
    Public Ball2 As Ball

    Sub New(CtrlSize As Size)
        MyGraphics = New GameGraphics(CtrlSize)
        MouseOperations = New MouseOps()
        CurrentLevel = New Level(CtrlSize)
        BallInits(CtrlSize)
        LoadLevel(CurrentLevelCount)
    End Sub

    Public Sub Update()
        UpdateBalls()
        HoleChecks()
        Drawings()
        If CurrentLevel.Hole1Status = True And CurrentLevel.Hole2Status = True Then
            CurrentLevelCount += 1
            LoadLevel(CurrentLevelCount)
            Ball1.dx = 0
            Ball1.dy = 0
            Ball2.dx = 0
            Ball2.dy = 0
        End If
    End Sub
    Public Sub UpdateBalls()
        If Ball1.IsStationary = False Then
            If CurrentLevel.Hole1Status = False Then
                Ball1.Update(CurrentLevel)
            End If
        End If
        If Ball2.IsStationary = False Then
            If CurrentLevel.Hole2Status = False Then
                Ball2.Update(CurrentLevel)
            End If
        End If

    End Sub

    Public Sub HoleChecks()
        If CurrentLevel.Hole1Status = False Then
            If Ball1.GetBounds.IntersectsWith(New Rectangle(CurrentLevel.Hole1.X - CSng(Imps.HoleSize / 2),
                                                        CurrentLevel.Hole1.Y - CSng(Imps.HoleSize / 2),
                                                       Imps.HoleSize, Imps.HoleSize)) Then
                My.Computer.Audio.Play(My.Resources.hole, AudioPlayMode.Background)
                CurrentLevel.Hole1Status = True
                Ball1.Reset()
            End If
        End If
        If CurrentLevel.Hole2Status = False Then
            If Ball2.GetBounds.IntersectsWith(New Rectangle(CurrentLevel.Hole2.X - CSng(Imps.HoleSize / 2),
                                                        CurrentLevel.Hole2.Y - CSng(Imps.HoleSize / 2),
                                                       Imps.HoleSize, Imps.HoleSize)) Then
                My.Computer.Audio.Play(My.Resources.hole, AudioPlayMode.Background)
                CurrentLevel.Hole2Status = True
                Ball2.Reset()
            End If
        End If
    End Sub

    Public Sub LoadLevel(Level As Integer)
        CurrentLevel.Load(Level)
        Ball1.x = CurrentLevel.Start1.X
        Ball1.y = CurrentLevel.Start1.Y
        Ball2.x = CurrentLevel.Start2.X
        Ball2.y = CurrentLevel.Start2.Y
    End Sub
    Public Sub Drawings()

        GameGraphics.AddLevelbg(CurrentLevel.Levelbg, MyGraphics.Canvas)


        If CurrentLevel.Hole1Status = False Then
            MyGraphics.DrawBall(MyGraphics.Canvas, Ball1)
        End If
        If CurrentLevel.Hole2Status = False Then
            MyGraphics.DrawBall(MyGraphics.Canvas, Ball2)
        End If

        GameGraphics.DrawPowerBar(MyGraphics.Canvas, Me.Power)
        GameGraphics.DrawStrokeCount(MyGraphics.Canvas, CurrentLevel.StrokeCount)

    End Sub

    '=====================================
    'INITS()
    Private Sub BallInits(CtrlSize As Size)
        Ball1 = New Ball(CurrentLevel.Start1, New Rectangle(0, 0, CtrlSize.Width / 2, CtrlSize.Height))
        Ball2 = New Ball(CurrentLevel.Start2, New Rectangle(CtrlSize.Width / 2, 0, CtrlSize.Width / 2, CtrlSize.Height))
    End Sub


End Class
