Public Class Users
    Private Sub lblRole_Click(sender As Object, e As EventArgs) Handles lblRole.Click

    End Sub

    Private Sub lblLogIn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblLogIn.LinkClicked
        Me.Hide()
        Login.Show()
    End Sub
End Class