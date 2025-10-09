Imports System.Data.OleDb
Imports System.Diagnostics.Eventing
Imports System.Diagnostics.Eventing.Reader

Public Class Forgot
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        With Me
            .Hide()
            Login.Show()
        End With
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim us As String
        Dim mo As String

        With Me
            If .txtPassword.Text = "" Or .txtConfirm.Text = "" Or .txtUsername.Text = "" Or txtMobile.Text = "" Then
                MsgBox("All fields are important! Please provide Username, Mobile No. and Confirm Password.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Input Error")
                Exit Sub
            Else
                If .txtPassword.Text <> .txtConfirm.Text Then
                    MsgBox("Password mismatch! Please try again.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Input Error")
                Else
                    Try
                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        cmd = New OleDbCommand("SELECT * FROM PROJECT WHERE Username=? AND Mobile=?", con)
                        cmd.Parameters.AddWithValue("?", txtUsername.Text)
                        cmd.Parameters.AddWithValue("?", txtMobile.Text)


                        Dim reader As OleDbDataReader = cmd.ExecuteReader()

                        If reader.Read() Then
                            us = reader.Item("Username").ToString
                            mo = reader.Item("Mobile").ToString
                            Dim pass As String = .txtPassword.Text
                            Dim user As String = .txtUsername.Text
                            Dim mobi As String = .txtMobile.Text

                            reader.Close()

                            If .txtUsername.Text <> us Or .txtMobile.Text <> mo Then
                                MsgBox("Invalid user credentials", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Input Error")
                                Exit Sub
                            Else
                                sql = "UPDATE PROJECT SET Password = @pa WHERE Username = @us AND Mobile = @mo;"

                                cmd.Connection = con
                                cmd.CommandText = sql

                                cmd.Parameters.Add("@pa", OleDbType.VarChar, 20, pass)
                                cmd.Parameters.Add("@us", OleDbType.VarChar, 20, user)
                                cmd.Parameters.Add("@mo", OleDbType.VarChar, 20, mobi)

                                If con.State = ConnectionState.Closed Then
                                    con.Open()
                                End If

                                i = cmd.ExecuteNonQuery()

                                If i >= 1 Then
                                    MsgBox("You password was resetted successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Saving Status")
                                Else
                                    MsgBox("Password reset failed", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Saving Status")
                                End If
                            End If
                        Else
                            MsgBox("Invalid user credentials", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Input Error")
                            Exit Sub
                        End If
                        con.Close()
                    Catch ex As Exception
                        MsgBox("Error: " & ex.Message)
                        con.Close()
                    End Try
                End If
            End If
        End With
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class