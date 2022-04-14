Public Class Form1

    Public WithEvents Screen As PictureBox

    Public WithEvents GameRule As New Timer
    Public WithEvents MouseHeld As New Timer

    Public CurrentSession As Session
    Private Sub Updates()
        CurrentSession.Update()
        Render()
    End Sub

    Private Sub Render()
        Screen.Image = CurrentSession.MyGraphics.Canvas
    End Sub
    '==============================================================
    'INITS
    Private Sub SessionInit()
        CurrentSession = New Session(Screen.Size)
    End Sub
    Private Sub ScreenInit()

        Me.CenterToScreen()
        Me.BackColor = Color.Black

        Screen = New PictureBox With {
        .Size = Me.ClientSize,
        .Left = 0,
        .Top = 0
        }
        Me.Controls.Add(Screen)
    End Sub

    Private Sub TInit()
        GameRule.Interval = Int(1000 / 60)
        GameRule.Start()
    End Sub
    '==============================================================

    '==============================================================
    'EVENTS
    Private Sub GameRule_Tick(sender As Object, e As EventArgs) Handles GameRule.Tick
        Updates()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Twini-Golf!"
        ScreenInit()
        SessionInit()
        TInit()
    End Sub

    Private Sub Screen_MouseDown(sender As Object, e As MouseEventArgs) Handles Screen.MouseDown

        My.Computer.Audio.Play(My.Resources.charge, AudioPlayMode.Background)

        CurrentSession.MouseOperations.Clicked(e)

        MouseHeld.Interval = 20
        MouseHeld.Start()
    End Sub
    Private Sub Holding(sender As Object, e As EventArgs) Handles MouseHeld.Tick
        'Held
    End Sub
    Private Sub Screen_MouseUp(sender As Object, e As MouseEventArgs) Handles Screen.MouseUp
        MouseHeld.Stop()
        My.Computer.Audio.Play(My.Resources.swing, AudioPlayMode.Background)

        CurrentSession.MouseOperations.Lifted(e)

        CurrentSession.Ball1.SetVector(CurrentSession.MouseOperations.StartPos,
                                       CurrentSession.MouseOperations.EndPos)
        CurrentSession.Ball2.SetVector(CurrentSession.MouseOperations.StartPos,
                               CurrentSession.MouseOperations.EndPos)
    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        Me.Size = New Size(640, 480)
    End Sub
    '==============================================================
End Class
