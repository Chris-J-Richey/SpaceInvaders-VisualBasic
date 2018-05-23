
'Name Chris Richey
'Period 2
'date 3/14/11
'discription Space Invaders game

Public Class frmMain

    Private x As Integer = 10
    Private invader(6) As PictureBox
    Private bullet(6) As PictureBox
    Private EnemyShoot(6) As Timer

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        invader(1) = picIn1
        invader(2) = picIn2
        invader(3) = picIn3
        invader(4) = PicIn4
        invader(5) = picIn5
        invader(6) = picIn6
        bullet(1) = picBullet1
        bullet(2) = picBullet2
        bullet(3) = picBullet3
        bullet(4) = picBullet4
        bullet(5) = picBullet5
        bullet(6) = picBullet6
        EnemyShoot(1) = EnemyShoot1
        EnemyShoot(2) = EnemyShoot2
        EnemyShoot(3) = EnemyShoot3
        EnemyShoot(4) = EnemyShoot4
        EnemyShoot(5) = EnemyShoot5
        EnemyShoot(6) = EnemyShoot6
        My.Computer.Audio.Play(My.Resources.spaceinvaders1, AudioPlayMode.Background)
    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim x = picYou.Left
        Dim key As KeyEventArgs

        key = e
        'moves you left and right
        If InvadersMove.Enabled = True Then
            If picYou.Left >= -1 And picYou.Right <= Me.Width Then
                Select Case key.KeyCode
                    Case 37
                        x -= 10
                    Case 39
                        x += 10
                End Select
            End If
            If picYou.Left <= 0 Then
                x += 10
            End If
            If picYou.Right >= Me.Width Then
                x -= 10
            End If
            If key.KeyCode = 32 Then
                'shoots the bullet
                Shoot.Enabled = True
                My.Computer.Audio.Play(My.Resources.shoot, AudioPlayMode.Background)
            End If
            picYou.SetBounds(x, picYou.Top, picYou.Width, picYou.Height)
            If Shoot.Enabled = False Then
                picYouBullet.SetBounds(picYou.Left + 20, picYou.Top - 36, picYouBullet.Width, picYouBullet.Height)
            End If
        End If
        If key.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub Shoot_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Shoot.Tick
        Dim p As Integer = 1
        picYouBullet.Visible = True
        picYouBullet.Top -= 10
        If picYouBullet.Top <= 0 Then
            picYouBullet.Top = picYou.Top - 36
            picYouBullet.Left = picYou.Left + 20
            picYouBullet.Visible = False
            Shoot.Enabled = False
        End If
        For p = 1 To 6
            'sees if you hit them
            If picYouBullet.Bounds.IntersectsWith(invader(p).Bounds) Then
                invader(p).Top = -300
                Shoot.Enabled = False
                picYouBullet.Top = picYou.Top - 36
                picYouBullet.Left = picYou.Left + 20
                picYouBullet.Visible = False
                My.Computer.Audio.Play(My.Resources.explosion, AudioPlayMode.Background)
            End If
        Next
    End Sub

    Private Sub EnemyShootStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnemyShootStart.Tick
        'send an enemy shoot it random number is right
        Dim random As Integer
        Dim h As Integer = 1
        Dim g As Integer = 1
        Randomize()
        random = Rnd() * 600
        If random = 50 Then
            If picIn1.Top >= -1 Then
                bullet(1).SetBounds(picIn1.Left + 20, picIn1.Top, bullet(1).Width, bullet(1).Height)
                EnemyShoot1.Enabled = True
            End If
        ElseIf random = 150 Then
            If picIn2.Top >= -1 Then
                bullet(2).SetBounds(picIn2.Left + 20, picIn2.Top, bullet(2).Width, bullet(2).Height)
                EnemyShoot2.Enabled = True
            End If
        ElseIf random = 250 Then
            If picIn3.Top >= -1 Then
                bullet(3).SetBounds(picIn3.Left + 20, picIn3.Top, bullet(3).Width, bullet(3).Height)
                EnemyShoot3.Enabled = True
            End If
        ElseIf random = 350 Then
            If PicIn4.Top >= -1 Then
                bullet(4).SetBounds(PicIn4.Left + 20, PicIn4.Top, bullet(4).Width, bullet(4).Height)
                EnemyShoot4.Enabled = True
            End If
        ElseIf random = 450 Then
            If picIn5.Top >= -1 Then
                bullet(5).SetBounds(picIn5.Left + 20, picIn5.Top, bullet(5).Width, bullet(5).Height)
                EnemyShoot5.Enabled = True
            End If
        ElseIf random = 550 Then
            If picIn6.Top >= -1 Then
                bullet(6).SetBounds(picIn6.Left + 20, picIn6.Top, bullet(6).Width, bullet(6).Height)
                EnemyShoot6.Enabled = True
            End If
        End If

        For h = 1 To 6
            'checks if it they hit you
            If bullet(h).Bounds.IntersectsWith(picYou.Bounds) Then
                bullet(h).Visible = False
                EnemyShoot(h).Enabled = False
                lblEnd.Visible = True
                lblEnd.Text = "You Lost"
                InvadersMove.Enabled = False
                EnemyShootStart.Enabled = False
                My.Computer.Audio.Play(My.Resources.explosion, AudioPlayMode.Background)
            End If
        Next
        For g = 1 To 6
            'checks if it they hit the bottom
            If invader(g).Bounds.IntersectsWith(sidebottom.Bounds) Then
                bullet(g).Visible = False
                EnemyShoot(g).Enabled = False
                lblEnd.Visible = True
                lblEnd.Text = "You Lost"
                InvadersMove.Enabled = False
                EnemyShootStart.Enabled = False
            End If
        Next
    End Sub

    Private Sub EnemyShoot1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnemyShoot1.Tick
        bullet(1).Visible = True
        bullet(1).Top += 10
    End Sub

    Private Sub EnemyShoot2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnemyShoot2.Tick
        bullet(2).Visible = True
        bullet(2).Top += 10
    End Sub

    Private Sub EnemyShoot3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnemyShoot3.Tick
        bullet(3).Visible = True
        bullet(3).Top += 10
    End Sub

    Private Sub EnemyShoot4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnemyShoot4.Tick
        bullet(4).Visible = True
        bullet(4).Top += 10
    End Sub

    Private Sub EnemyShoot5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnemyShoot5.Tick
        bullet(5).Visible = True
        bullet(5).Top += 10
    End Sub

    Private Sub EnemyShoot6_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnemyShoot6.Tick
        bullet(6).Visible = True
        bullet(6).Top += 10
    End Sub

    Private Sub InvadersMove_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvadersMove.Tick
        Dim l As Integer = 1
        Dim w As Integer = 1
        Dim a As Integer = 1
        For w = 1 To 6
            If invader(w).Bounds.IntersectsWith(sideright.Bounds) Then
                x = -10
            ElseIf invader(w).Bounds.IntersectsWith(sideleft.Bounds) Then
                x = 10
            End If
        Next
        For a = 1 To 6
            If invader(a).Bounds.IntersectsWith(sideright.Bounds) Or invader(a).Bounds.IntersectsWith(sideleft.Bounds) Then
                invader(1).Top += 15
                invader(2).Top += 15
                invader(3).Top += 15
                invader(4).Top += 15
                invader(5).Top += 15
                invader(6).Top += 15
            End If
        Next
        For l = 1 To 6
            invader(l).Left += x
        Next
        If picIn1.Top <= -1 And picIn2.Top <= -1 And picIn3.Top <= -1 And PicIn4.Top <= -1 And picIn5.Top <= -1 And picIn6.Top <= -1 Then
            lblEnd.Visible = True
            lblEnd.Text = "You Won!"
            InvadersMove.Enabled = False
            EnemyShootStart.Enabled = False
        End If
    End Sub
End Class
