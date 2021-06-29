Imports System.Data
Imports System.Data.SqlClient

Public Class frmProductos
    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbProductos.SelectedIndex = 0
        CenterToScreen()
        'spSeleccionarProductos
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
        End Using

    End Sub


    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        'sqlCon = New SqlConnection(conn)
        'cmd = New SqlCommand("spObtenerMaximoCategoria", sqlCon

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon


            Try
                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spObtenerMaximoProducto"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se crea una instancia del sqldataadapter
                sqlad = New SqlDataAdapter(sqlComm)
                dt = New DataTable("Datos")
                sqlad.Fill(dt)
                frmAddProductos.TxtCodProducto.Text = CStr(CInt(dt.Rows(0).Item(0)) + 1)
            Catch ex As Exception
                'En caso que la tabla de clientes no tenga valores 
                frmAddProductos.TxtCodProducto.Text = 1
            End Try

        End Using
        tipoOper = 1
        frmAddProductos.TxtCodProducto.Enabled = False
        frmAddProductos.ShowDialog()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            frmAddProductos.TxtCodProducto.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
            tipoOper = 2
            frmAddProductos.ShowDialog()
        Catch ex As Exception
            MsgBox("Debe seleccionar un producto primero", MsgBoxStyle.Information, "Sistema")
        End Try
    End Sub



    Private Sub dvgProvedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        frmAddProductos.TxtCodProducto.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        Try

            tipoOper = 2
            frmAddProductos.ShowDialog()
        Catch ex As Exception
            MsgBox("Debe seleccionar un producto primero", MsgBoxStyle.Information, "Sistema")
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        Try
            frmAddProveedores.TxtCodProvedor.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        Catch ex As Exception
            MsgBox("Debe seleccionar un producto primero", MsgBoxStyle.Information, "Sistema")
            Exit Sub
        End Try
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        'sqlCon = New SqlConnection(conn)
        'cmd = New SqlCommand("spObtenerMaximoCategoria", sqlCon)

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)
            If MsgBox("¿Realmente desea eliminar este producto?" + vbCr + " Se eliminara para siempre eso es mucho tiempo!!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim sqlComm As New SqlCommand()
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spElimanarProducto"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodProducto", DataGridView1.SelectedRows.Item(0).Cells(0).Value)
            sqlad.Fill(dt)
        End Using
        Me.llenarComboProductos()
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
    Private Sub cbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged
        llenarComboProductos()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
