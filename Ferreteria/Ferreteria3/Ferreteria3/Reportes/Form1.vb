Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        mostrarBitacoraTabla()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Public Sub mostrarBitacoraTabla()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)
        Using (sqlCon)
            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon
            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "mostrarBitacora"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            DataGridView1.DataSource = dt
        End Using
    End Sub
End Class