Imports System.Data.OleDb
Imports System.IO

Module Module1
    Public dbFileName As String = "GYM PROJECT DATABASE1.mdb"
    Public dbPath As String = Path.Combine(Application.StartupPath, dbFileName)
    Public con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath)
    Public cmd As OleDbCommand
    Public cr As DataRow
    Public da As OleDbDataAdapter
    Public dr As OleDbDataReader
    Public dt1, dt2, dt3, dt4, dt5, dt6, dt7 As New DataTable()
    Public sql As String
    Public cri, i, selectedID As Integer


    Public Function LoadLbl(d As String, t As String, g As String, e As Object, f As Object)
        Try
            sql = "SELECT " & d & " FROM " & t & " WHERE " & g & " = '" & e & "'"

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            cmd = New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader

            While dr.Read
                f.text = dr.GetInt64(d)
            End While
        Catch ex As Exception
            MsgBox("Error loading Types: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try

        Return 0
    End Function

End Module
