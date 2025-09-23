
Imports System.Data.OleDb
Public Class Classes
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=GymDB.accdb")

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtClassName.Text = "" Then
            MsgBox("Class name can not be empty. Please provide it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        ElseIf cmbTrainer.SelectedIndex = -1 Then
            MsgBox("Trainer's name can not be empty. Please select it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        ElseIf dtpSchedule.Value > Now Then
            MsgBox("Scheduled date is invalid. Please schedule a valid one.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        Else
            Try
                con.Open()
                Dim cmd As New OleDb.OleDbCommand("INSERT INTO Classes (ClassName, Trainer, Schedule) VALUES (?, ?, ?)", con)
                cmd.Parameters.AddWithValue("?", txtClassName.Text)
                cmd.Parameters.AddWithValue("?", cmbTrainer.Text)
                cmd.Parameters.AddWithValue("?", dtpSchedule.Value)
                cmd.ExecuteNonQuery()
                MsgBox("Class saved successfully")
                con.Close()
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
                con.Close()
            End Try
        End If
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs)
        Me.Close()
        Trainers.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
        Me.Close()
        Subscriptions.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        Me.Close()
        Equipment.Show()
    End Sub

    Private Sub Classes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - Classes"

    End Sub

    Private Sub Classes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        General.Show()
        e.Cancel = False
    End Sub
End Class