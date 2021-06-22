Imports System.Data
Imports System.Data.SqlClient
Public Class frmConsultaProducto
    Private Sub frmConsultaProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        llenarComboProductos()
    End Sub

    Sub llenarComboProductos()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spSeleccionarProductos"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            DataGridView1.DataSource = dt

            cbProductos.SelectedIndex = 0
        End Using

    End Sub

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged
        mostrarProductoFiltroNombre()
    End Sub


    Public Sub mostrarProductoFiltroNombre()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)
        Using (sqlCon)
            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon
            'se indica el nombre del stored procedure y el tipo
            If cbProductos.Text = "Nombre" Then
                sqlComm.CommandText = "spSeleccionarProductoNombre"

            ElseIf cbProductos.Text = "Categoria" Then
                sqlComm.CommandText = "spSeleccionarProductoCategoria"

            ElseIf cbProductos.Text = "Proveedor" Then
                sqlComm.CommandText = "spSeleccionarProductoProveedor"
            End If

            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure
            sqlComm.Parameters.AddWithValue("@Nombre", txtbuscar.Text)
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            DataGridView1.DataSource = dt
        End Using
    End Sub

    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged
        mostrarProductoFiltroNombre()
    End Sub



    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        frmInfoProducto.ShowDialog()
    End Sub
End Class