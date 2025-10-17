
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Trainers

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            cmd = New OleDb.OleDbCommand("INSERT INTO Trainers (Surname, Firstname, Specialty, Mobile, JoinDate) VALUES (?, ?, ?, ?, Now())", con)
            cmd.Parameters.AddWithValue("?", txtSurname.Text)
            cmd.Parameters.AddWithValue("?", txtFirstname.Text)
            cmd.Parameters.AddWithValue("?", txtSpecialty.Text)
            cmd.Parameters.AddWithValue("?", txtMobile.Text)
            i = cmd.ExecuteNonQuery()
            If i >= 0 Then
                MsgBox("Trainer record successfully saved!")
            Else
                MsgBox("Record saving failed!")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Private Sub trainers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - Trainers"

        LoadData()

        If dt5.Rows.Count > 0 Then
            cri = 0
            CurrentRecord()
        End If
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            cmd = New OleDb.OleDbCommand("INSERT INTO Trainers (Surname, Firstname, Specialty, Mobile, JoinDate) VALUES (?, ?, ?, ?, Now())", con)
            cmd.Parameters.AddWithValue("?", txtSurname.Text)
            cmd.Parameters.AddWithValue("?", txtFirstname.Text)
            cmd.Parameters.AddWithValue("?", txtSpecialty.Text)
            cmd.Parameters.AddWithValue("?", txtMobile.Text)
            i = cmd.ExecuteNonQuery()
            If i >= 0 Then
                MsgBox("Trainer record successfully updated!")
            Else
                MsgBox("Record modification failed!")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            cmd = New OleDb.OleDbCommand("DELETE FROM Trainers WHERE TrainerID = ?", con)
            cmd.Parameters.AddWithValue("?", lblTrainerID.Text)

            i = cmd.ExecuteNonQuery()
            If i >= 0 Then
                MsgBox("Trainer record successfully deleted!")
            Else
                MsgBox("Record deletion failed!")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        With Me
            .lblTrainerID.ResetText()
            .txtFirstname.Clear()
            .txtSurname.Clear()
            .txtMobile.Clear()
            .txtSpecialty.Clear()
            .lblJoinDate.ResetText()
        End With
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadData()
        CurrentRecord()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If cri < dt5.Rows.Count - 1 Then
            cri += 1
            CurrentRecord()
        End If
    End Sub

    Sub CurrentRecord()
        If cri >= 0 AndAlso cri < dt5.Rows.Count Then
            cr = dt5.Rows(cri)
            lblTrainerID.Text = cr("TrainerID").ToString
            txtSurname.Text = cr("Surname").ToString
            txtFirstname.Text = cr("Firstname").ToString
            txtSpecialty.Text = cr("Specialty").ToString
            txtMobile.Text = cr("Mobile").ToString
            lblJoinDate.Text = cr("JoinDate").ToString

            btnPrior.Enabled = (cri > 0)
            btnNext.Enabled = (cri < dt5.Rows.Count - 1)
            btnFirst.Enabled = (cri > 0)
            btnLast.Enabled = (cri < dt5.Rows.Count - 1)
        End If
    End Sub

    Sub LoadData()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If


            Using cmd As New OleDbCommand("SELECT * FROM Trainers", con)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Using dr As OleDbDataReader = cmd.ExecuteReader()
                    If dr.Read Then
                        dt5.Load(dr) ' Load all data from DataReader into DataTable
                    Else
                        MsgBox("No data to display!")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            REM dr.Dispose()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        cri = 0
        CurrentRecord()
    End Sub

    Private Sub btnPrior_Click(sender As Object, e As EventArgs) Handles btnPrior.Click
        If cri > 0 Then
            cri -= 1
            CurrentRecord()
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        cri = dt5.Rows.Count - 1
        CurrentRecord()
    End Sub
End Class