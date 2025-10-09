Public Class General

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnEquip.Click
        Equipment.Show()
    End Sub

    Private Sub btnMemb_Click(sender As Object, e As EventArgs) Handles btnMemb.Click
        Members.Show()
    End Sub

    Private Sub btnTrain_Click(sender As Object, e As EventArgs) Handles btnTrain.Click
        Trainers.Show()
    End Sub

    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        Subscriptions.Show()
    End Sub

    Private Sub btnClass_Click(sender As Object, e As EventArgs) Handles btnClass.Click
        Classes.Show()
    End Sub

    Private Sub General_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - General"
    End Sub


End Class