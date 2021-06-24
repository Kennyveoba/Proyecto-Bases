Imports System.Data
Imports System.Data.SqlClient
Public Class frmAddSucusal

    Private Sub frmAddSucusal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        cargarEncargado()
    End Sub

    Public Sub cargarEncargado()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spMostrarEncargados"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            cbProductos.DataSource = dt
            cbProductos.DisplayMember = "Nombre"
            cbProductos.ValueMember = "CodigoEncargado"
        End Using
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmInfoEncargado.ShowDialog()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Valida que se pongan todos los datos
        If CodSucursal.Text = "" Then
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
                sqlComm.CommandText = "spAgregarSucursal"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodTienda", CInt(CodSucursal.Text))
                sqlComm.Parameters.AddWithValue("@CodEncargado", cbProductos.SelectedValue)
                sqlComm.Parameters.AddWithValue("@Direccion", TextBox3.Text)
                sqlComm.Parameters.AddWithValue("@NombreTienda", TextBox5.Text)
                sqlComm.Parameters.AddWithValue("@Telefono", CInt(TextBox2.Text))
                sqlComm.Parameters.AddWithValue("@Correo", TextBox2.Text)
                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("Sucursal Registrada Correctamente", MsgBoxStyle.Information, "Registro Sucursal")
                frmProductos.llenarComboProductos()

            End Using
            crearInventario()
            Me.Close()

        Else 'Modificar
            Using (sqlCon)
                If MsgBox("¿Desesa Guardar los Cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarProducto"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodTienda", CInt(CodSucursal.Text))
                sqlComm.Parameters.AddWithValue("@CodEncargado", cbProductos.SelectedValue)
                sqlComm.Parameters.AddWithValue("@Direccion", TextBox3.Text)
                sqlComm.Parameters.AddWithValue("@NombreTienda", TextBox5.Text)
                sqlComm.Parameters.AddWithValue("@Telefono", CInt(TextBox4.Text))
                sqlComm.Parameters.AddWithValue("@Correo", CInt(TextBox2.Text))

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

    Public Function SacarMaximoProveedor() As Integer
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
                Return CInt(dt.Rows(0).Item(0))
            Catch ex As Exception
                Return 0
            End Try
        End Using
    End Function


    Private Sub crearInventario()
        Dim indice As Integer
        indice = SacarMaximoProveedor()

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
                    sqlComm.Parameters.AddWithValue("@CodTienda", CInt(CodSucursal.Text))
                    sqlComm.Parameters.AddWithValue("@CodProducto", i + 1)
                    sqlComm.Parameters.AddWithValue("@Cantidad", 0)

                    sqlCon.Open()
                    'se ejecuta el el stored procedure en el servidor de bases de datos
                    sqlComm.ExecuteNonQuery()
                End Using
            Next
        End Using
    End Sub

    Private Sub frmAddSucusal_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmSucursal.cargarTiendas()
    End Sub
End Class