Imports System
Imports System.Data.OleDb
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

        cboStatus.Items.AddRange(New String() {"New", "Refurbished", "Old"})
        cboCondition.Items.AddRange(New String() {"Good", "Average", "Bad"})

        LoadData()
        LoadType()

        If dt1.Rows.Count > 0 Then
            cri = 0
            CurrentRecord()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtName.Text = "" Then
            MsgBox("Equipment name can not be empty. Please provide it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        ElseIf cboType.SelectedIndex = -1 Then
            MsgBox("Equipment type can not be empty. Please select it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        ElseIf cboCondition.SelectedIndex = -1 Then
            MsgBox("Equipment condition can not be empty. Please select it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        ElseIf cboStatus.SelectedIndex = -1 Then
            MsgBox("Equipment status can not be empty. Please select it.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Input Error")
            Exit Sub
        Else
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                cmd = New OleDb.OleDbCommand("INSERT INTO Equipment(Name, TypeID, Condition, PurchaseDate, Status) VALUES (?, ?, ?, Now(), ?)", con)
                cmd.Parameters.AddWithValue("?", txtName.Text)
                cmd.Parameters.AddWithValue("?", Convert.ToInt32(lblTypeID.Text))
                cmd.Parameters.AddWithValue("?", cboCondition.Text)
                cmd.Parameters.AddWithValue("?", cboStatus.Text)

                i = cmd.ExecuteNonQuery()

                If i >= 0 Then
                    MsgBox("Equipment record successfully saved!")
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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            cmd = New OleDb.OleDbCommand("DELETE FROM Equipment WHERE ID = ?", con)
            cmd.Parameters.AddWithValue("?", Convert.ToInt32(lblEquipmentID.Text))

            i = cmd.ExecuteNonQuery()
            If i >= 0 Then
                MsgBox("Equipment record successfully deleted!")
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

            cmd = New OleDb.OleDbCommand("UPDATE Classes SET Name = ?, TypeID = ?, Condition = ?, PurchaseDate = Now(), Status = ? WHERE ID = ?", con)
            cmd.Parameters.AddWithValue("?", txtName.Text)
            cmd.Parameters.AddWithValue("?", Convert.ToInt32(lblTypeID.Text))
            cmd.Parameters.AddWithValue("?", cboCondition.Text)
            cmd.Parameters.AddWithValue("?", cboStatus.Text)
            cmd.Parameters.AddWithValue("?", Convert.ToInt32(lblEquipmentID.Text))

            i = cmd.ExecuteNonQuery()
            If i >= 0 Then
                MsgBox("Equipment record successfully updated!")
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
            .lblEquipmentID.ResetText()
            .txtName.Clear()
            .dtpPurchase.Value = Date.Now()
            .cboType.SelectedIndex = -1
            .cboCondition.SelectedIndex = -1
            .cboStatus.SelectedIndex = -1
        End With
    End Sub

    Sub CurrentRecord()
        Try
            If cri >= 0 AndAlso cri < dt1.Rows.Count Then
                cr = dt1.Rows(cri)
                lblEquipmentID.Text = cr("ID").ToString
                txtName.Text = cr("Name").ToString
                lblTypeID.Text = cr("TypeID").ToString
                cboType.Text = cr("Condition").ToString
                dtpPurchase.Value = cr("PurchaseDate").ToString
                cboStatus.Text = cr("Status").ToString

                btnPrior.Enabled = (cri > 0)
                btnNext.Enabled = (cri < dt1.Rows.Count - 1)
                btnFirst.Enabled = (cri > 0)
                btnLast.Enabled = (cri < dt1.Rows.Count - 1)
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Sub LoadData()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If


            Using cmd As New OleDbCommand("SELECT * FROM Equipment", con)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Using dr As OleDbDataReader = cmd.ExecuteReader()
                    If dr.Read Then
                        dt1.Load(dr) ' Load all data from DataReader into DataTable
                    Else
                        MsgBox("No data to display!")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            dt1.Dispose()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub LoadType()
        Try
            sql = "SELECT DISTINCT Type FROM Types ORDER BY Type"
            da = New OleDbDataAdapter(sql, con)
            dt1 = New DataTable
            da.Fill(dt1)

            cboType.Items.Clear()
            For Each row As DataRow In dt1.Rows
                cboType.Items.Add(row("Type").ToString())
            Next
        Catch ex As Exception
            MsgBox("Error loading Types: " & ex.Message)
        End Try
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        LoadLbl("TypeID", "Types", "Type", cboType.Text, lblTypeID.Text)
    End Sub

End Class