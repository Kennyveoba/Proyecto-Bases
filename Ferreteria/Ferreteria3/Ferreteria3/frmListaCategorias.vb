Imports System.Data
Imports System.Data.SqlClient
Public Class frmListaCategorias
    Private Sub dgvCategorias_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategorias.CellContentClick

    End Sub

    Sub llenarListaCategorias()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spSeleccionarCategorias"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            dgvCategorias.DataSource = dt
        End Using

    End Sub
    Sub llenarListaCategoriasXNombre()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spSeleccionarCategoriasNombre"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure
            sqlComm.Parameters.AddWithValue("@Nombre", txtDescripcion.Text)
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            dgvCategorias.DataSource = dt
        End Using

    End Sub
    Private Sub frmListaCategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        llenarListaCategorias()
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged
        llenarListaCategoriasXNombre()
    End Sub

    Private Sub dgvCategorias_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategorias.CellContentDoubleClick
        frmCategorias.txtCodCategoria.Text = dgvCategorias.SelectedRows.Item(0).Cells(0).Value
        frmCategorias.txtCategoria.Text = dgvCategorias.SelectedRows.Item(0).Cells(1).Value
        frmCategorias.btnModificar.Enabled = True
        Me.Close()

    End Sub
End Class