
Imports System.Data.OleDb
Public Class Trainers
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.NET Framework Data Provider for OLE DB")

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            con.Open()
            Dim cmd As New OleDb.OleDbCommand("INSERT INTO Trainers (TrainerName, Specialty, Contact) VALUES (?, ?, ?)", con)
            cmd.Parameters.AddWithValue("?", txtName.Text)
            cmd.Parameters.AddWithValue("?", txtSpecialty.Text)
            cmd.Parameters.AddWithValue("?", txtContact.Text)
            cmd.ExecuteNonQuery()
            MsgBox("Trainer added successfully")
            con.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
            con.Close()
        End Try
    End Sub
    Private Sub trainers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - Trainers"
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)
        Me.Close()
        Classes.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)
        Me.Close()
        Equipment.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        Me.Close()
        Subscriptions.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Members.Show()
    End Sub
End Class