Imports System.Data.OleDb

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
            dt = New DataTable
            da.Fill(dt)

            cboMemberID.Items.Clear()
            For Each row As DataRow In dt.Rows
                cboMemberID.Items.Add(row("MemberID").ToString())
            Next
        Catch ex As Exception
            MsgBox("Error loading Member IDs: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            sql = "SELECT * FROM Subscriptions"
            da = New OleDbDataAdapter(sql, con)
            dt = New DataTable
            da.Fill(dt)
            dvgPayments.DataSource = dt
        Catch ex As Exception
            MsgBox("Error loading subscriptions: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cboMemberID.Text = "" Or cboPlanType.Text = "" Or txtAmount.Text = "" Then
            MsgBox("Please fill all fields.")
            Exit Sub
        End If

        Try
            sql = "INSERT INTO Subscriptions (MemberID, PlanType, Amount, PaymentDate) VALUES (?, ?, ?, ?)"
            cmd = New OleDbCommand(sql, con)
            cmd.Parameters.AddWithValue("?", Val(cboMemberID.Text))
            cmd.Parameters.AddWithValue("?", cboPlanType.Text)
            cmd.Parameters.AddWithValue("?", Val(txtAmount.Text))
            cmd.Parameters.AddWithValue("?", dtpPaymentDate.Value)

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Subscription saved successfully.")
            LoadData()
            ClearFields()
        Catch ex As Exception
            MsgBox("Error saving subscription: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        cboMemberID.SelectedIndex = -1
        cboPlanType.SelectedIndex = -1
        txtAmount.Clear()
        dtpPaymentDate.Value = Today
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnBackToMembers_Click(sender As Object, e As EventArgs)
        Dim membersForm As New Members
        Members.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Members.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
        Me.Close()
        Trainers.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)
        Me.Close()
        Equipment.Show()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)
        Me.Close()
        Classes.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblStatus_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub
End Class
