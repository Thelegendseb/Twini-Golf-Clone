Public Class MouseOps

    'OfClick
    Public StartPos As Point
    Public EndPos As Point
    Public Sub Reset()
        StartPos = Nothing
        EndPos = Nothing
    End Sub
    Public Sub Clicked(e As MouseEventArgs)
        StartPos = New Point(e.X, e.Y)
    End Sub
    Public Sub Lifted(e As MouseEventArgs)
        EndPos = New Point(e.X, e.Y)
    End Sub

End Class
