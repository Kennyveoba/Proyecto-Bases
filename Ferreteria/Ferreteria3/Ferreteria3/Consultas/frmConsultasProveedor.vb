Imports System.Data
Imports System.Data.SqlClient
Public Class frmConsultasProveedor
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub frmConsultasProvedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        mostraProvedor()
    End Sub



    Public Sub mostrarProvedorFiltroNombre()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spSeleccionarProvedorNombre"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure
            sqlComm.Parameters.AddWithValue("@Nombre", txtbuscarProveedor.Text)
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            dvgProvedores.DataSource = dt


        End Using
    End Sub

    Public Sub mostraProvedor()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spMostrarProvedor"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            dvgProvedores.DataSource = dt
            cbProductos.SelectedIndex = 0
        End Using
    End Sub

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscarProveedor.TextChanged
        mostrarFiltroNombre()
    End Sub

    Public Sub mostrarFiltroNombre()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            If cbProductos.Text = "Nombre" Then
                sqlComm.CommandText = "spSeleccionarProvedorNombre"

            ElseIf cbProductos.Text = "Codigo" Then
                sqlComm.CommandText = "spSeleccionarProveedorCodigo"
            End If
            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure
            sqlComm.Parameters.AddWithValue("@Nombre", txtbuscarProveedor.Text)
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            dvgProvedores.DataSource = dt
        End Using
    End Sub

    Private Sub dvgProvedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dvgProvedores.CellDoubleClick
        frmInfoProveedor.ShowDialog()
    End Sub

    Private Sub cbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged
        mostrarFiltroNombre()
    End Sub

End Class