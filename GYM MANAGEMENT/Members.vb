Imports System.Data.OleDb
Imports GYM_MANAGEMENT.Classes

Public Class Members

    Private Sub frmMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - Members"
        cboGender.Items.AddRange(New String() {"Female", "Male"})
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            sql = "SELECT * FROM Members"
            da = New OleDbDataAdapter(sql, con)
            dt = New DataTable
            da.Fill(dt)
            dgvMembers.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearFields()
        txtFirstName.Clear()
        txtLastName.Clear()
        cboGender.SelectedIndex = -1
        dtpDOB.Value = Today
        dtpJoinDate.Value = Today
        selectedID = 0
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtFirstName.Text = "" Or txtLastName.Text = "" Or cboGender.Text = "" Then
            MsgBox("Please fill all fields.")
            Exit Sub
        End If

        Try
            sql = "INSERT INTO Members (FirstName, LastName, Gender, DOB, JoinDate) VALUES (?, ?, ?, ?, ?)"
            cmd = New OleDbCommand(sql, con)
            cmd.Parameters.AddWithValue("?", txtFirstName.Text)
            cmd.Parameters.AddWithValue("?", txtLastName.Text)
            cmd.Parameters.AddWithValue("?", cboGender.Text)
            cmd.Parameters.AddWithValue("?", dtpDOB.Value)
            cmd.Parameters.AddWithValue("?", dtpJoinDate.Value)

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Member saved successfully.")
            LoadData()
            ClearFields()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub dgvMembers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMembers.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvMembers.Rows(e.RowIndex)
            selectedID = row.Cells("MemberID").Value
            lblMemberID.Text = row.Cells("MemberID").Value
            txtFirstName.Text = row.Cells("FirstName").Value.ToString()
            txtLastName.Text = row.Cells("LastName").Value.ToString()
            cboGender.Text = row.Cells("Gender").Value.ToString()
            dtpDOB.Value = Convert.ToDateTime(row.Cells("DOB").Value)
            dtpJoinDate.Value = Convert.ToDateTime(row.Cells("JoinDate").Value)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedID = 0 Then
            MsgBox("Please select a member to update.")
            Exit Sub
        End If

        Try
            sql = "UPDATE Members SET FirstName=?, LastName=?, Gender=?, DOB=?, JoinDate=? WHERE MemberID=?"
            cmd = New OleDbCommand(sql, con)
            cmd.Parameters.AddWithValue("?", txtFirstName.Text)
            cmd.Parameters.AddWithValue("?", txtLastName.Text)
            cmd.Parameters.AddWithValue("?", cboGender.Text)
            cmd.Parameters.AddWithValue("?", dtpDOB.Value)
            cmd.Parameters.AddWithValue("?", dtpJoinDate.Value)
            cmd.Parameters.AddWithValue("?", lblMemberID.Text)

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Member updated successfully.")
            LoadData()
            ClearFields()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedID = 0 Then
            MsgBox("Please select a member to delete.")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete this member?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                sql = "DELETE FROM Members WHERE MemberID=?"
                cmd = New OleDbCommand(sql, con)
                cmd.Parameters.AddWithValue("?", lblMemberID.Text)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Member deleted.")
                LoadData()
                ClearFields()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs)
        Me.Close()
        Trainers.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)
        Me.Close()
        Equipment.Show()
    End Sub

    Private Sub Label5_Click_1(sender As Object, e As EventArgs)
        Me.Close()
        Classes.Show()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        Me.Close()
        Subscriptions.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
