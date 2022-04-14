Public Class Ball

    Public Shared Size As Integer = 10
    Public FrictionCoefficient As Single = 0.95
    Public Mass As Single = 2
    Public x, y As Integer
    Public dx, dy As Single

    Public Container As Rectangle

    Sub New(P As Point, R As Rectangle)

        Container = R
        x = P.X
        y = P.Y
    End Sub
    Public Sub Update(L As Level)
        If dx <> 0 Or dy <> 0 Then
            Move()
            dx *= FrictionCoefficient
            dy *= FrictionCoefficient
            Bounce(L)
        End If
    End Sub
    Public Sub Move()
        x += dx
        y += dy
    End Sub

    Public Sub Reset()
        dx = 0
        dy = 0
    End Sub

    Public Function IsStationary() As Boolean
        If dx = 0 And dy = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetBounds() As Rectangle
        Return New Rectangle(x - Size / 2, y - Size / 2, Size, Size)
    End Function


    Public Sub SetVector(P1 As Point, P2 As Point)
        dx = -(P2.X - P1.X) / Mass
        dy = -(P2.Y - P1.Y) / Mass
    End Sub

    Public Sub Bounce(L As Level)

        'WALL BOUNCES
        If x - (Size / 2) < Container.X Then
            x = Container.X + Size
            dx *= -1
        ElseIf x + (Size / 2) > Container.Width + Container.X Then
            x = Container.X + Container.Width - Size
            dx *= -1
        End If
        If y - (Size / 2) < 0 Then
            y = Container.Y + Size
            dy *= -1
        ElseIf y + (Size / 2) > Container.Height + Container.Y Then
            y = Container.Y + Container.Height - Size
            dy *= -1
        End If

        'CELL BOUNCES
        If Imps.IsHit(Me.x + Me.dx, Me.y, L) = True Then
            dx *= -1
        End If
        If Imps.IsHit(Me.x, Me.y + Me.dy, L) = True Then
            dy *= -1
        End If


    End Sub

End Class
