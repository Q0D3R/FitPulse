Imports System.Data.OleDb
Imports GYM_MANAGEMENT.Classes

Public Class Members

    Private Sub frmMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gym Management - Members"
        cboGender.Items.AddRange(New String() {"Female", "Male"})
        cboMembership.Items.AddRange(New String() {"Premium", "Basic", "General"})

        LoadData()
        CurrentRecord()
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
            sql = "INSERT INTO Members (FirstName, LastName, Gender, DOB, JoinDate, Phone, Email, MembershipType) VALUES (?, ?, ?, ?, ?,  ?, ?, ?)"
            cmd = New OleDbCommand(sql, con)
            cmd.Parameters.AddWithValue("?", txtFirstName.Text)
            cmd.Parameters.AddWithValue("?", txtLastName.Text)
            cmd.Parameters.AddWithValue("?", cboGender.Text)
            cmd.Parameters.AddWithValue("?", dtpDOB.Value)
            cmd.Parameters.AddWithValue("?", dtpJoinDate.Value)
            cmd.Parameters.AddWithValue("?", txtPhone.Text)
            cmd.Parameters.AddWithValue("?", txtEmail.Text)
            cmd.Parameters.AddWithValue("?", cboMembership.Text)

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
            sql = "UPDATE Members SET FirstName=?, LastName=?, Gender=?, DOB=?, JoinDate=?, Phone=?, Email=?, MembershipType=? WHERE MemberID=?"
            cmd = New OleDbCommand(sql, con)
            cmd.Parameters.AddWithValue("?", txtFirstName.Text)
            cmd.Parameters.AddWithValue("?", txtLastName.Text)
            cmd.Parameters.AddWithValue("?", cboGender.Text)
            cmd.Parameters.AddWithValue("?", dtpDOB.Value)
            cmd.Parameters.AddWithValue("?", dtpJoinDate.Value)
            cmd.Parameters.AddWithValue("?", txtPhone.Text)
            cmd.Parameters.AddWithValue("?", txtEmail.Text)
            cmd.Parameters.AddWithValue("?", cboMembership.Text)

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

    Sub CurrentRecord()
        If cri >= 0 AndAlso cri < dt4.Rows.Count Then
            cr = dt4.Rows(cri)
            lblMemberID.Text = cr("MemberID").ToString
            txtFirstName.Text = cr("FirstName").ToString
            txtLastName.Text = cr("LastName").ToString
            cboGender.Text = cr("Gender").ToString
            dtpDOB.Value = cr("DOB").ToString
            dtpJoinDate.Value = cr("JoinDate").ToString
            txtPhone.Text = cr("Phone").ToString
            txtEmail.Text = cr("Email").ToString
            cboMembership.Text = cr("MembershipType").ToString

            btnPrior.Enabled = (cri > 0)
            btnNext.Enabled = (cri < dt4.Rows.Count - 1)
            btnFirst.Enabled = (cri > 0)
            btnLast.Enabled = (cri < dt4.Rows.Count - 1)
        End If
    End Sub

    Sub LoadData()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If


            Using cmd As New OleDbCommand("SELECT * FROM Members", con)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Using dr As OleDbDataReader = cmd.ExecuteReader()
                    If dr.Read Then
                        dt4.Load(dr) ' Load all data from DataReader into DataTable
                        dgvMembers.DataSource = dt4
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
        cri = dt4.Rows.Count - 1
        CurrentRecord()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If cri < dt4.Rows.Count - 1 Then
            cri += 1
            CurrentRecord()
        End If
    End Sub

End Class
