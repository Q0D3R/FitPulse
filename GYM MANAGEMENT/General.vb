Public Class General

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnEquip.Click
        Me.Hide()
        Equipment.Show()

    End Sub

    Private Sub btnMemb_Click(sender As Object, e As EventArgs) Handles btnMemb.Click
        Me.Hide()
        Members.Show()
    End Sub

    Private Sub btnTrain_Click(sender As Object, e As EventArgs) Handles btnTrain.Click
        Me.Hide()
        Trainers.Show()
    End Sub

    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        Me.Hide()
        Subscriptions.Show()
    End Sub

    Private Sub btnClass_Click(sender As Object, e As EventArgs) Handles btnClass.Click
        Me.Hide()
        Classes.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)
        Me.Close()
        Equipment.Show()

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
        Me.Close()
        Trainers.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Members.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        Me.Close()
        Subscriptions.Show()

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)
        Me.Close()
        Classes.Show()
    End Sub

    Private Sub General_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - General"
    End Sub
End Class