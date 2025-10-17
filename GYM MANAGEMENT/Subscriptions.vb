Imports System.Data.OleDb
Imports System.Net.Mime.MediaTypeNames

Public Class Subscriptions

    Private Sub frmSubscriptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - Subscriptions"
        cboPlanType.Items.AddRange(New String() {"Monthly", "Weekly", "Yearly"})
        LoadMembers()
        LoadData()
        Me.Close()
        General.Show()
    End Sub

    Private Sub LoadMembers()
        Try
            sql = "SELECT DISTINCT MemberID FROM Members ORDER BY MemberID"
            da = New OleDbDataAdapter(sql, con)
            dt2 = New DataTable
            da.Fill(dt2)

            cboMemberID.Items.Clear()
            For Each row As DataRow In dt2.Rows
                cboMemberID.Items.Add(row("MemberID").ToString())
            Next
        Catch ex As Exception
            MsgBox("Error loading Member IDs: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearFields()
        cboMemberID.SelectedIndex = -1
        cboPlanType.SelectedIndex = -1
        txtAmount.Clear()
        dtpStartDate.Value = Today
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If lblMemberID.Text = "" Then
            MsgBox("Class name can not be empty. Please provide it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        ElseIf cboPlanType.SelectedIndex = -1 Then
            MsgBox("Plan type can not be empty. Please select it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        ElseIf txtAmount.Text = "" Then
            MsgBox("Amount paid can not be empty. Please provide it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        ElseIf dtpStartDate.Value < Now Then
            MsgBox("Scheduled date is invalid. Please schedule a valid one.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        Else
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                cmd = New OleDb.OleDbCommand("INSERT INTO Suscriptions (MemberID, Package, Amount, StartDate, EndDate, Modified) VALUES (? ,? ,? ,? , ?, Now())", con)
                cmd.Parameters.AddWithValue("?", lblMemberID.Text)
                cmd.Parameters.AddWithValue("?", cboPlanType.Text)
                cmd.Parameters.AddWithValue("?", txtAmount.Text)
                cmd.Parameters.AddWithValue("?", dtpStartDate.Value)
                cmd.Parameters.AddWithValue("?", lblEndDate.Text)

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

            cmd = New OleDb.OleDbCommand("DELETE FROM Subscriptions WHERE SubscriptionID = ?", con)
            cmd.Parameters.AddWithValue("?", lblSubID.Text)

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

            cmd = New OleDb.OleDbCommand("UPDATE Suscriptions SET MemberID = ?, Package= ?, Amount = ?, StartDate = ?, EndDate = ?, Modified = Now() WHERE SubscriptionID = ?", con)
            cmd.Parameters.AddWithValue("?", lblMemberID.Text)
            cmd.Parameters.AddWithValue("?", cboPlanType.Text)
            cmd.Parameters.AddWithValue("?", txtAmount.Text)
            cmd.Parameters.AddWithValue("?", dtpStartDate.Value)
            cmd.Parameters.AddWithValue("?", lblEndDate.Text)
            cmd.Parameters.AddWithValue("?", lblSubID.Text)

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
            .lblMemberID.ResetText()
            .txtAmount.Clear()
            .dtpStartDate.Value = Date.Now()
            .cboPlanType.SelectedIndex = -1
            .lblSubID.ResetText()
            .lblEndDate.ResetText()
        End With
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If cri < dt2.Rows.Count - 1 Then
            cri += 1
            CurrentRecord()
        End If
    End Sub

    Sub CurrentRecord()
        If cri >= 0 AndAlso cri < dt2.Rows.Count Then
            cr = dt2.Rows(cri)
            lblSubID.Text = cr("SubscriptionID").ToString
            lblMemberID.Text = cr("MemberID").ToString
            cboPlanType.Text = cr("Package").ToString
            txtAmount.Text = cr("Amount").ToString
            dtpStartDate.Value = cr("StartDate").ToString
            lblEndDate.Text = cr("EndDate").ToString
            lblPayment.Text = cr("Modified").ToString

            btnPrior.Enabled = (cri > 0)
            btnNext.Enabled = (cri < dt2.Rows.Count - 1)
            btnFirst.Enabled = (cri > 0)
            btnLast.Enabled = (cri < dt2.Rows.Count - 1)
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
                        dt2.Load(dr) ' Load all data from DataReader into DataTable
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
        cri = dt2.Rows.Count - 1
        CurrentRecord()
    End Sub
End Class
