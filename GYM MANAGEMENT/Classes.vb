
Imports System.Data.OleDb

Public Class Classes

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtClassName.Text = "" Then
            MsgBox("Class name can not be empty. Please provide it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        ElseIf cboTrainer.SelectedIndex = -1 Then
            MsgBox("Trainer's name can not be empty. Please select it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        ElseIf dtpSchedule.Value < Now Then
            MsgBox("Scheduled date is invalid. Please schedule a valid one.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        Else
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                cmd = New OleDb.OleDbCommand("INSERT INTO Classes (ClassName, TrainerID, ClassSchedule, Modified) VALUES (?, ?, ?, Now())", con)
                cmd.Parameters.AddWithValue("?", txtClassName.Text)
                cmd.Parameters.AddWithValue("?", cboTrainer.Text)
                cmd.Parameters.AddWithValue("?", dtpSchedule.Value)

                i = cmd.ExecuteNonQuery()

                If i >= 0 Then
                    MsgBox("Trainer record successfully saved!")
                Else
                    MsgBox("Record saving failed!")
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Classes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - Classes"

        LoadData()
        CurrentRecord()
    End Sub

    Private Sub Classes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        General.Show()
        e.Cancel = False
    End Sub


    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            cmd = New OleDb.OleDbCommand("DELETE FROM Classes WHERE ClassID = ?", con)
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            cmd = New OleDb.OleDbCommand("UPDATE Classes SET ClassName = ?, ClassSchedule= ?, TrainerID = ?, Modified = Now() WHERE ClassID = ?", con)
            cmd.Parameters.AddWithValue("?", txtClassName.Text)
            cmd.Parameters.AddWithValue("?", dtpSchedule.Value)
            cmd.Parameters.AddWithValue("?", lblTrainerID.Text)

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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        With Me
            .lblClassID.ResetText()
            .txtClassName.Clear()
            .dtpSchedule.Value = Date.Now()
            .cboTrainer.SelectedIndex = -1
            .lblDate.ResetText()
        End With
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If cri < dt3.Rows.Count - 1 Then
            cri += 1
            CurrentRecord()
        End If
    End Sub

    Sub CurrentRecord()
        If cri >= 0 AndAlso cri < dt3.Rows.Count Then
            cr = dt3.Rows(cri)
            lblClassID.Text = cr("ClassID").ToString
            txtClassName.Text = cr("ClassName").ToString
            dtpSchedule.Value = cr("ClassSchedule").ToString
            lblTrainerID.Text = cr("TrainerID").ToString
            lblDate.Text = cr("Modified").ToString

            btnPrior.Enabled = (cri > 0)
            btnNext.Enabled = (cri < dt3.Rows.Count - 1)
            btnFirst.Enabled = (cri > 0)
            btnLast.Enabled = (cri < dt3.Rows.Count - 1)
        End If
    End Sub

    Sub LoadData()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If


            Using cmd As New OleDbCommand("SELECT * FROM Classes", con)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Using dr As OleDbDataReader = cmd.ExecuteReader()
                    If dr.Read Then
                        dt3.Load(dr) ' Load all data from DataReader into DataTable
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
        cri = dt3.Rows.Count - 1
        CurrentRecord()
    End Sub

End Class