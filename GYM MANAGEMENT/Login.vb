
Imports System.Data.OleDb

Public Class Login

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Then
            REM lblStatus.Text = "Invalid username! Please provide it"
            txtUsername.Focus()
            Exit Sub
        ElseIf txtPassword.Text = "" Then
            REM lblStatus.Text = "Invalid password!"
            txtPassword.Focus()
            Exit Sub
        ElseIf cmbRole.SelectedIndex = -1 Then
            REM lblStatus.Text = "Invalid user role!"
            cmbRole.Focus()
            Exit Sub
        Else
            Try
                con.Open()
                cmd = New OleDbCommand("SELECT * FROM PROJECT WHERE Username=? AND Password=? AND Role=?", con)
                cmd.Parameters.AddWithValue("?", txtUsername.Text)
                cmd.Parameters.AddWithValue("?", txtPassword.Text)
                cmd.Parameters.AddWithValue("?", cmbRole.Text)

                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    MsgBox("Login successful as " & cmbRole.Text)
                    General.Show()
                    Me.Hide()
                Else
                    MsgBox("Invalid login credentials or role.")
                End If
                con.Close()
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
                con.Close()
            End Try
        End If
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - Log In"
        cmbRole.Items.Clear()
        cmbRole.Items.Add("Admin")
        cmbRole.Items.Add("Staff")
        cmbRole.SelectedIndex = -1 ' Default selection
    End Sub

    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        If cmbRole.SelectedItem.ToString = "Admin" Then
            picUser.Image = My.Resources.Admin
        ElseIf cmbRole.SelectedItem.ToString = "Staff" Then
            picUser.Image = My.Resources.Staff
        Else
            picUser.Image = My.Resources.Dummy
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub Login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub lblForgot_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblForgot.LinkClicked
        With Me
            Me.Hide()
            Forgot.Show()
        End With
    End Sub

    Private Sub lblRegister_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRegister.LinkClicked
        With Me
            Me.Hide()
            Users.Show()
        End With
    End Sub
End Class