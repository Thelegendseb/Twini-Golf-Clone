Public Class Session

    Public MyGraphics As GameGraphics

    Public MouseOperations As MouseOps

    Public CurrentLevel As New Level

    Public Ball1 As Ball
    Public Ball2 As Ball

    Sub New(CtrlSize As Size)
        MyGraphics = New GameGraphics(CtrlSize)
        MouseOperations = New MouseOps()

        LoadLevel(1)
        BallInits(CtrlSize)
    End Sub

    Public Sub Update()

        Ball1.Update(CurrentLevel)
        Ball2.Update(CurrentLevel)

        Drawings()
    End Sub

    Public Sub Drawings()
        MyGraphics.DrawBackground()
        MyGraphics.DrawLevel(CurrentLevel)
        MyGraphics.Balls(Ball1, Ball2)
    End Sub

    Public Sub LoadLevel(Level As Integer)
        CurrentLevel = CurrentLevel.Load(Level)
    End Sub


    '=====================================
    'INITS()
    Private Sub BallInits(CtrlSize As Size)
        Ball1 = New Ball(CurrentLevel.Start1, New Rectangle(0, 0, CtrlSize.Width / 2, CtrlSize.Height))
        Ball2 = New Ball(CurrentLevel.Start2, New Rectangle(CtrlSize.Width / 2, 0, CtrlSize.Width / 2, CtrlSize.Height))
    End Sub


End Class
