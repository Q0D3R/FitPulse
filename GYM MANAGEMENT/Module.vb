Imports System.Data.OleDb
Imports System.IO

Module Module1
    Public dbFileName As String = "GYM PROJECT DATABASE1.mdb"
    Public dbPath As String = Path.Combine(Application.StartupPath, dbFileName)
    Public con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath)
    Public cmd As OleDbCommand
    Public da As OleDbDataAdapter
    Public dt As DataTable
    Public sql As String
    Public i, selectedID As Integer

End Module
