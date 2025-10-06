Imports System
Public Class Equipment

    Private Sub Label5_Click(sender As Object, e As EventArgs)
        Me.Close()
        Classes.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        Me.Close()
        Subscriptions.Show()
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs)
        Me.Close()
        Trainers.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Members.Show()
    End Sub

    Private Sub Equipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - Equipment"
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class