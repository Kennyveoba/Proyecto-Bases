Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Public Class frmFacturacion
    Dim thisDate As Date
    Dim cargar As Boolean 'Variable para indicar que se cargo todo correctamente 
    Dim Cantidad As Integer 'Lleva la cantidad de articulos que se agrega a la factura
    Dim NumeroVenta As Integer 'Se guarda el numero de la factura 

    Private Sub frmFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox3.Text = Usuario
        'Actualiza todos los datos de los combobox y obtiene el valor de la factura 
        Cantidad = 0
        actualizarTabla()
        cargar = False
        Me.CenterToScreen()
        cargarSucursales()
        Me.lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")
        NumeroDocumento()
        crearMestroVentas()
    End Sub

    ' Crea el maestro ventas donde se guarda toda la informacion de la venjta en caso que no se cancele 
    Public Sub crearMestroVentas()
        sqlCon = New SqlConnection(conn)
        Using (sqlCon)
            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon
            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "MaestroVenta"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure
            sqlComm.Parameters.AddWithValue("@CodNumeroVenta", CInt(Label11.Text))
            sqlComm.Parameters.AddWithValue("@Fecha", lblFecha.Text)
            sqlComm.Parameters.AddWithValue("@CodigoTienda", ComboBox2.Text)
            sqlCon.Open()
            'se ejecuta el el stored procedure en el servidor de bases de datos
            sqlComm.ExecuteNonQuery()
        End Using
    End Sub


    'Actualiza los montos totales a pagar con cada cambio en la tabla 
    Public Sub actualizaMontoFinal()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)
        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon
            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "sacarTotal"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodDetalle", Label11.Text)
            sqlCon.Open()
            'se ejecuta el el stored procedure en el servidor de bases de datos
            sqlComm.ExecuteNonQuery()

            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)

            'En caso que la tabla se quede sin elementos 
            Try
                Subtotal.Text = CStr(dt(0)(0))
                IVA.Text = CInt(Subtotal.Text) * 0.13
                Total.Text = Format(CInt(Subtotal.Text) + CInt(IVA.Text), "0")
                sqlCon.Close()
            Catch ex As Exception
                Subtotal.Text = ""
                IVA.Text = ""
                Total.Text = Format("", "0")
            End Try
        End Using
    End Sub



    'Calcula el numero de la factura tomando el ultimo guardado en la tabla de maestro venta y le suma uno 
    Public Sub NumeroDocumento()

        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spObtenerNroDocumento"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            'En caso que sea la primera factura creada
            Try
                NumeroVenta = dt(0)(0) + 1
                Label11.Text = Format(dt(0)(0) + 1, "0000000")
            Catch ex As Exception
                Label11.Text = "0000001"
            End Try
            cargar = True
        End Using

    End Sub


    'Carga las sucursales al combobox
    Public Sub cargarSucursales()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spMostrarTiendas"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            ComboBox2.DataSource = dt
            ComboBox2.DisplayMember = "NombreTienda"
            ComboBox2.ValueMember = "CodTienda"

            cargar = True
        End Using
    End Sub


    'Obtiene el los datos de los clientes dado un codigo 
    Public Sub mostrarClientesFiltroNombre()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            If IsNumeric(txtCodCliente.Text) = False Then
                MsgBox("Error: El codigo debe ser un numero", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Sub
            End If
            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spSeleccionarClienteCodigo"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure
            sqlComm.Parameters.AddWithValue("@Nombre", CInt(txtCodCliente.Text))

            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            asistente.DataSource = dt
            Try

                NombreCliente.Text = asistente.SelectedRows.Item(0).Cells(1).Value
                txtCodProducto.Focus()

                'En caso que el codigo no sea de ningun cliente 
            Catch ex As Exception
                MsgBox("Error: El codigo no pertenece a ningun cliente registrado", MsgBoxStyle.Critical, "Mensaje del Sistema")
                NombreCliente.Text = ""
                txtCodCliente.Focus()
                Exit Sub
            End Try
        End Using
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmProductos.ShowDialog()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        frmSucursal.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        frmClientes.ShowDialog()
    End Sub

    'Busca el cliente al darle el boton de enter 
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodCliente.KeyPress
        If Asc(e.KeyChar) = 13 Then
            mostrarClientesFiltroNombre()
        End If

        If Asc(e.KeyChar) = 8 Then
            NombreCliente.Text = ""
        End If
    End Sub


    'Funcion para buscar un producto por codigo dando la tecla enter  
    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
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

                Try
                    sqlComm.Parameters.AddWithValue("@CodProducto", CInt(txtCodProducto.Text))
                    'se crea una instancia del sqldataadapter
                    sqlad = New SqlDataAdapter(sqlComm)
                    dt = New DataTable("Datos")
                    sqlad.Fill(dt)
                    asistente.DataSource = dt

                Catch ex As Exception
                    MsgBox("Error: Solo se permiten numeros", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End Try
            End Using

            'Pone el nombre del producto que se va a agregar en el inventario  
            Try
                Nombre_Producto.Text = asistente.SelectedRows.Item(0).Cells(1).Value
                txtPrecio.Text = asistente.SelectedRows.Item(0).Cells(7).Value
                txtCantidad.Enabled = True
                txtCantidad.Focus()

            Catch ex As Exception
                MsgBox("Error: El codigo de producto no pertenece a ninguno registrado", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End If
        If Asc(e.KeyChar) = 8 Then
            txtCantidad.Enabled = False
            txtCantidad.Text = ""
            Nombre_Producto.Text = ""
            txtPrecio.Text = ""
        End If
    End Sub


    'Funcion para agregar un articulo dando el boton de agregar 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles agregar.Click
        sqlCon = New SqlConnection(conn)
        Dim sqlComm As New SqlCommand()
        'se hace la referencia a la conexión, OJO ver código del Módulo 1
        sqlComm.Connection = sqlCon

        Using (sqlCon)

            'Valida que se ingrese solamente numeros en el campo de telefono
            Try
                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spAgregarVenta"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("@NumeroVenta", CInt(Label11.Text))
                sqlComm.Parameters.AddWithValue("@CodProducto", CInt(txtCodProducto.Text))
                sqlComm.Parameters.AddWithValue("@Cantidad", CInt(txtCantidad.Text))
                sqlComm.Parameters.AddWithValue("@Precio", CInt(txtPrecio.Text))
                sqlComm.Parameters.AddWithValue("@Total", CInt(txtPrecio.Text) * CInt(txtCantidad.Text))
                sqlComm.Parameters.AddWithValue("@Venta", Cantidad)
            Catch ex As Exception
                MsgBox("Error: La cantidad debe ser un numero", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End Try

            sqlCon.Open()

            'se ejecuta el el stored procedure en el servidor de bases de datos
            sqlComm.ExecuteNonQuery()
            actualizarTabla()
            txtCantidad.Enabled = False
            txtCantidad.Text = ""
            Nombre_Producto.Text = ""
            txtPrecio.Text = ""
            txtCodProducto.Text = ""
            Cantidad = Cantidad + 1
            txtCodProducto.Focus()
            actualizaMontoFinal()
            sqlCon.Close()
        End Using
    End Sub

    'Actualiza la tabla de la factura en caso que se agrege o se elimine 
    Private Sub actualizarTabla()

        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "verCompras"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodVenta", Label11.Text)

            sqlCon.Open()
            'se ejecuta el el stored procedure en el servidor de bases de datos
            sqlComm.ExecuteNonQuery()
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            Tabla_Factura.DataSource = dt
            sqlCon.Close()
        End Using
    End Sub


    '________________________________Funcion confirmar venta_____________________________________________________
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        'Validaciones en la factura 
        If NombreCliente.Text = "" Then
            MsgBox("Debe ingresar el cliente ", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If ComboBox1.Text = "" Then
            MsgBox("Debe elegir el metodo de pago ", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If Cantidad = 0 Then
            MsgBox("Debe ingresar al menos un producto ", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If ComboBox2.Text = "" Then
            MsgBox("Debe elegir la sucursal", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        'Recorre todos los productos comprados para eliminarlos del inventario
        For i As Integer = 0 To Tabla_Factura.RowCount - 2
            If Not Tabla_Factura.Rows.Item(i) Is Nothing Then
                sqlCon = New SqlConnection(conn)
                Dim sqlComm As New SqlCommand()
                'se hace la referencia a la conexión, OJO ver código del Módulo 1
                sqlComm.Connection = sqlCon
                Using (sqlCon)

                    'se indica el nombre del stored procedure y el tipo
                    sqlComm.CommandText = "Disminuirstock"
                    sqlComm.CommandType = CommandType.StoredProcedure
                    sqlComm.Parameters.AddWithValue("@CodTienda", ComboBox2.SelectedValue)
                    sqlComm.Parameters.AddWithValue("@CodProducto", Tabla_Factura.Item(0, i).Value)
                    sqlComm.Parameters.AddWithValue("@Cantidad", Tabla_Factura.Item(4, i).Value)

                    sqlCon.Open()
                    'se ejecuta el el stored procedure en el servidor de bases de datos
                    sqlComm.ExecuteNonQuery()
                End Using
            End If
        Next
        ModificarMaestroVentas()
        'Limpia todos los campos de texto y deje listo para la siguiente factura 
        NumeroDocumento()
        crearMestroVentas()
        actualizarTabla()
        actualizaMontoFinal()
        txtCodCliente.Text = ""
        NombreCliente.Text = ""
        TextBox11.Text = ""
        MsgBox("Factura realizada con exito!!", MsgBoxStyle.OkOnly, "Mensaje del Sistema")

    End Sub

    Private Sub ModificarMaestroVentas()
        sqlCon = New SqlConnection(conn)
        Using (sqlCon)
            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon
            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "ModificarMaestroVentas"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure
            sqlComm.Parameters.AddWithValue("@CodNumeroVenta", CInt(Label11.Text))
            sqlComm.Parameters.AddWithValue("@CodigoTienda", ComboBox2.Text)

            sqlComm.Parameters.AddWithValue("@CodTipoPago", ComboBox1.Text)
            sqlComm.Parameters.AddWithValue("@CodCliente", NombreCliente.Text)
            sqlComm.Parameters.AddWithValue("@Subtotal", CInt(Subtotal.Text))
            sqlComm.Parameters.AddWithValue("@Iva", CInt(IVA.Text))
            sqlComm.Parameters.AddWithValue("@Total", CInt(Total.Text))

            sqlCon.Open()
            'se ejecuta el el stored procedure en el servidor de bases de datos
            sqlComm.ExecuteNonQuery()
        End Using
    End Sub

    '________________________________Funcion cancelar venta_____________________________________________________
    Private Sub frmFacturacion_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        txtCodCliente.Text = ""
        txtCodProducto.Text = ""
        txtPrecio.Text = ""
        Nombre_Producto.Text = ""
        NombreCliente.Text = ""
        txtCantidad.Text = ""
        TextBox11.Text = ""
        'Limpia la tabla de los productos en caso que se cancela la venta 
        actualizarTabla()

        'Elimina los registro de la tabla de detalle de venta 
        sqlCon = New SqlConnection(conn)
        Dim sqlComm As New SqlCommand()
        'se hace la referencia a la conexión, OJO ver código del Módulo 1
        sqlComm.Connection = sqlCon
        Using (sqlCon)

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spElimanarVenta"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodDetalle", CInt(Label11.Text))
            sqlCon.Open()
            'se ejecuta el el stored procedure en el servidor de bases de datos
            sqlComm.ExecuteNonQuery()
            sqlCon.Close()
        End Using

    End Sub

    '________________________________Funcion agregar articulo a la factura con la tecla enter_____________________________________________________
    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress

        'valida que se precione la tecla enter en ascii el enter es igual a 13
        If Asc(e.KeyChar) = 13 Then
            sqlCon = New SqlConnection(conn)
            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            Using (sqlCon)

                'Valida que se ingrese solamente numeros en el campo de telefono
                Try
                    'se indica el nombre del stored procedure y el tipo
                    sqlComm.CommandText = "spAgregarVenta"
                    sqlComm.CommandType = CommandType.StoredProcedure

                    sqlComm.Parameters.AddWithValue("@NumeroVenta", CInt(Label11.Text))
                    sqlComm.Parameters.AddWithValue("@CodProducto", CInt(txtCodProducto.Text))
                    sqlComm.Parameters.AddWithValue("@Cantidad", CInt(txtCantidad.Text))
                    sqlComm.Parameters.AddWithValue("@Precio", CInt(txtPrecio.Text))
                    sqlComm.Parameters.AddWithValue("@Total", CInt(txtPrecio.Text) * CInt(txtCantidad.Text))
                    sqlComm.Parameters.AddWithValue("@Venta", Cantidad)
                Catch ex As Exception
                    MsgBox("Error: La cantidad debe ser un numero", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End Try

                sqlCon.Open()

                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                actualizarTabla()
                'Restablece los campos para el siguiente producto
                txtCantidad.Enabled = False
                txtCantidad.Text = ""
                Nombre_Producto.Text = ""
                txtPrecio.Text = ""
                txtCodProducto.Text = ""
                txtCodProducto.Focus()
                Cantidad = Cantidad + 1
                sqlCon.Close()

                'Actuaiza el monto a pagar 
                actualizaMontoFinal()
            End Using

        End If
    End Sub


    '________________________________Funcion eliminar articulo de la factura_____________________________________________________
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Eliminar.Click
        Try
            frmAddProveedores.TxtCodProvedor.Text = Tabla_Factura.SelectedRows.Item(0).Cells(0).Value
        Catch ex As Exception
            MsgBox("Debe seleccionar un articulo primero", MsgBoxStyle.Information, "Sistema")
            Exit Sub
        End Try
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        'sqlCon = New SqlConnection(conn)
        'cmd = New SqlCommand("spObtenerMaximoCategoria", sqlCon)

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)
            If MsgBox("¿Realmente desea eliminar este articulo?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                Exit Sub
            End If


            Dim sqlComm As New SqlCommand()
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spDevolverProducto"
            sqlComm.CommandType = CommandType.StoredProcedure

            sqlComm.Parameters.AddWithValue("@CodDetalle", Tabla_Factura.SelectedRows.Item(0).Cells(6).Value)
            sqlComm.Parameters.AddWithValue("@NumeroVenta", NumeroVenta)
            sqlad.Fill(dt)
        End Using
        'Actualiza la tabla y el monto a pagar 
        actualizarTabla()
        actualizaMontoFinal()
        ' Disminuye la cantidad de articulos que se lleva
        Cantidad = Cantidad - 1
    End Sub


End Class