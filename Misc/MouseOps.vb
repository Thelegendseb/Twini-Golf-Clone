Public Class MouseOps

    'OfClick
    Public StartPos As Point
    Public EndPos As Point
    Public Sub Reset()
        StartPos = Nothing
        EndPos = Nothing
    End Sub
    Public Sub Clicked()
        StartPos = New Point(Cursor.Current.Position.X, Cursor.Current.Position.Y)
    End Sub
    Public Sub Lifted()
        EndPos = New Point(Cursor.Current.Position.X, Cursor.Current.Position.Y)
    End Sub

End Class
