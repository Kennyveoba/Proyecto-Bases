Imports System.Data
Imports System.Data.SqlClient
Public Class frmListaProductos

    Private Sub frmListaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        cargarcategorias()
        cargarProveedores()
        cragarUnidadMedida()
    End Sub


    Public Sub cargarcategorias()
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
            cbxCategoria.DataSource = dt
            cbxCategoria.DisplayMember = "Nombre"
            cbxCategoria.ValueMember = "CodCategoria"
        End Using
    End Sub

    Public Sub cargarProveedores()

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
            cbxProveedor.DataSource = dt
            cbxProveedor.DisplayMember = "Nombre"
            cbxProveedor.ValueMember = "CodProvedor"
        End Using
    End Sub


    Public Sub cragarUnidadMedida()

        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spMostrarUnidades"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            cbxUnidad.DataSource = dt
            cbxUnidad.DisplayMember = "Nombre"
            cbxUnidad.ValueMember = "CodUnidadesDeMedida"
        End Using
    End Sub




    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        'Escribir aqui doble click
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub LblTitulo_Click(sender As Object, e As EventArgs) Handles LblTitulo.Click

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If txtNombre.Text = "" Or txtPrecioCompra.Text = "" Or txtDescripcion.Text = "" Or txtPrecioCompra.Text = "" Or txtPrecioVenta.Text = "" Then
            MsgBox("Complete Todos Los Datos Porfavor", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If


        sqlCon = New SqlConnection(conn)
        Dim sqlComm As New SqlCommand()
        'se hace la referencia a la conexión, OJO ver código del Módulo 1
        sqlComm.Connection = sqlCon

        If tipoOper = 1 Then 'Insercion
            Using (sqlCon)
                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spAgregarProducto"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodProducto", CInt(TxtCodProducto.Text))
                sqlComm.Parameters.AddWithValue("@CodProvedor", cbxProveedor.SelectedValue)
                sqlComm.Parameters.AddWithValue("@CodCategoria", cbxCategoria.SelectedValue)
                sqlComm.Parameters.AddWithValue("@CodUnidadMedida", cbxUnidad.SelectedValue)
                sqlComm.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text)
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                sqlComm.Parameters.AddWithValue("@PrecioVenta", Convert.ToDecimal(txtPrecioVenta.Text))
                sqlComm.Parameters.AddWithValue("@PrecioCompra", Convert.ToDecimal(txtPrecioCompra.Text))
                sqlCon.Open()

                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("Producto Registrado Correctamente", MsgBoxStyle.Information, "Registro Productos")
                frmProveedores.mostraProvedor()
                Me.Close()
            End Using



        Else 'Modificar
            Using (sqlCon)
                If MsgBox("¿Desesa Guardar los Cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarCategoria"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodCategoria", cbxCategoria.SelectedIndex)
                sqlComm.Parameters.AddWithValue("@CodProvedor", cbxProveedor.SelectedIndex)
                sqlComm.Parameters.AddWithValue("@CodProducto", CInt(TxtCodProducto.Text))
                sqlComm.Parameters.AddWithValue("@CodUnidadMedida", cbxUnidad.SelectedIndex)
                sqlComm.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text)
                sqlComm.Parameters.AddWithValue("@PrecioVenta", CDec(txtPrecioVenta.Text))
                sqlComm.Parameters.AddWithValue("@PrecioCompra", CDec(txtPrecioCompra.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)

                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("El producto se modifico correctamente", MsgBoxStyle.Information, "Modificar Categoria")
                frmProveedores.mostraProvedor()
                Me.Close()
            End Using
        End If

        txtNombre.Text = ""
        txtPrecioCompra.Text = ""
        txtDescripcion.Text = ""
        txtPrecioCompra.Text = ""
        txtPrecioVenta.Text = ""


        frmCategorias.llenarComboCategorias()
    End Sub


End Class