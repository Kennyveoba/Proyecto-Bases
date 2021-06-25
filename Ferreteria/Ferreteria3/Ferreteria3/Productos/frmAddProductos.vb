Imports System.Data
Imports System.Data.SqlClient
Public Class frmAddProductos

    Private Sub frmListaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        cargarcategorias()
        cargarProveedores()
        cragarUnidadMedida()
        'Resetea los valores a los iniciales al abrir la ventana para agrgar un producto
        cbxCategoria.SelectedValue = -1
        cbxProveedor.SelectedValue = -1
        cbxUnidad.SelectedValue = -1
        txtNombre.Text = ""
        txtDescripcion.Text = ""
        txtPrecioCompra.Text = ""
        txtPrecioVenta.Text = ""


        If tipoOper = 1 Then 'Insercion
            Me.LblTitulo.Text = "Agregar nuevo producto"
        Else
            Me.LblTitulo.Text = "Modificar un producto"

            Dim sqlad As SqlDataAdapter
            Dim dt As DataTable

            sqlCon = New SqlConnection(conn)

            Using (sqlCon)

                Dim sqlComm As New SqlCommand()
                'se hace la referencia a la conexión, OJO ver código del Módulo 1
                sqlComm.Connection = sqlCon

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spSeleccionarProducto"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodProducto", CInt(frmProductos.DataGridView1.SelectedRows.Item(0).Cells(0).Value))
                'se crea una instancia del sqldataadapter
                sqlad = New SqlDataAdapter(sqlComm)
                dt = New DataTable("Datos")
                sqlad.Fill(dt)
                frmProductos.Asistente.DataSource = dt
            End Using

            'Pone los datos del producto a modificar en la ventana 
            TxtCodProducto.Text = frmProductos.Asistente.SelectedRows.Item(0).Cells(0).Value
            txtNombre.Text = frmProductos.Asistente.SelectedRows.Item(0).Cells(1).Value
            txtDescripcion.Text = frmProductos.Asistente.SelectedRows.Item(0).Cells(2).Value
            cbxCategoria.SelectedValue = CInt(frmProductos.Asistente.SelectedRows.Item(0).Cells(3).Value)
            cbxProveedor.SelectedValue = CInt(frmProductos.Asistente.SelectedRows.Item(0).Cells(4).Value)
            cbxUnidad.SelectedValue = CInt(frmProductos.Asistente.SelectedRows.Item(0).Cells(5).Value)
            txtPrecioCompra.Text = frmProductos.Asistente.SelectedRows.Item(0).Cells(6).Value
            txtPrecioVenta.Text = frmProductos.Asistente.SelectedRows.Item(0).Cells(7).Value

        End If
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        'Valida que se pongan todos los datos
        If txtNombre.Text = "" Or txtPrecioCompra.Text = "" Or txtDescripcion.Text = "" Or txtPrecioCompra.Text = "" Or txtPrecioVenta.Text = "" Then
            MsgBox("Complete Todos Los Datos Porfavor", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If


        If IsNumeric(txtPrecioVenta.Text) = False Or IsNumeric(txtPrecioCompra.Text) = False Then
            MsgBox("Error: El precio debe ser un numero", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Exit Sub
        End If

        sqlCon = New SqlConnection(conn)
        Dim sqlComm As New SqlCommand()
        'se hace la referencia a la conexión, OJO ver código del Módulo 1
        sqlComm.Connection = sqlCon

        If tipoOper = 1 Then 'Insercion
            Using (sqlCon)
                Try
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
                    sqlComm.Parameters.AddWithValue("@PrecioVenta", CInt(txtPrecioVenta.Text))
                    sqlComm.Parameters.AddWithValue("@PrecioCompra", CInt(txtPrecioCompra.Text))
                    sqlCon.Open()

                    'se ejecuta el el stored procedure en el servidor de bases de datos
                    sqlComm.ExecuteNonQuery()
                    MsgBox("Producto Registrado Correctamente", MsgBoxStyle.Information, "Registro producto")
                    frmProductos.llenarComboProductos()
                    Me.Close()
                Catch ex As Exception
                    MsgBox("Complete Todos Los Datos Porfavor", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                End Try
                agregarInventario()
            End Using

        Else 'Modificar
            Using (sqlCon)
                If MsgBox("¿Desesa Guardar los Cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarProducto"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodProducto", CInt(TxtCodProducto.Text))
                sqlComm.Parameters.AddWithValue("@CodProvedor", cbxProveedor.SelectedValue)
                sqlComm.Parameters.AddWithValue("@CodCategoria", cbxCategoria.SelectedValue)
                sqlComm.Parameters.AddWithValue("@CodUnidadMedida", cbxUnidad.SelectedValue)
                sqlComm.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text)
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                sqlComm.Parameters.AddWithValue("@PrecioVenta", CInt(txtPrecioVenta.Text))
                sqlComm.Parameters.AddWithValue("@PrecioCompra", CInt(txtPrecioCompra.Text))

                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("El producto se modifico correctamente", MsgBoxStyle.Information, "Modificar Producto")
                'Actualiza la tabla de productos
                frmProductos.llenarComboProductos()
                Me.Close()
            End Using

        End If
    End Sub


    Private Sub agregarInventario()
        Dim indice As Integer
        indice = SacarMaximoSucursal()

        Using (sqlCon)

            For i = 0 To indice - 1 Step 1
                sqlCon = New SqlConnection(conn)
                Dim sqlComm As New SqlCommand()
                'se hace la referencia a la conexión, OJO ver código del Módulo 1
                sqlComm.Connection = sqlCon
                Using (sqlCon)

                    'se indica el nombre del stored procedure y el tipo
                    sqlComm.CommandText = "spCrearInventario"
                    sqlComm.CommandType = CommandType.StoredProcedure
                    sqlComm.Parameters.AddWithValue("@CodTienda", i + 1)
                    sqlComm.Parameters.AddWithValue("@CodProducto", CInt(TxtCodProducto.Text))
                    sqlComm.Parameters.AddWithValue("@Cantidad", 0)

                    sqlCon.Open()
                    'se ejecuta el el stored procedure en el servidor de bases de datos
                    sqlComm.ExecuteNonQuery()
                End Using
            Next

        End Using
    End Sub


    Private Function SacarMaximoSucursal() As Integer
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
                sqlComm.CommandText = "spObtenerMaximaSucursal"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se crea una instancia del sqldataadapter
                sqlad = New SqlDataAdapter(sqlComm)
                dt = New DataTable("Datos")
                sqlad.Fill(dt)
                Return CInt(dt.Rows(0).Item(0))
            Catch ex As Exception
                Return 0
            End Try

        End Using
    End Function


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmProveedores.ShowDialog()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        frmCategorias.ShowDialog()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        frmUnidadMedida.ShowDialog()
    End Sub

    Private Sub frmListaProductos_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Resetea los valores a los iniciales al abrir la ventana para agrgar un producto
        cbxCategoria.SelectedValue = -1
        cbxProveedor.SelectedValue = -1
        cbxUnidad.SelectedValue = -1
        txtNombre.Text = ""
        txtDescripcion.Text = ""
        txtPrecioCompra.Text = ""
        txtPrecioVenta.Text = ""
    End Sub


End Class