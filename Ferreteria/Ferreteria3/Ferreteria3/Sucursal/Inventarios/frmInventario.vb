Imports System.Data
Imports System.Data.SqlClient
Public Class frmInventario
    Private Sub frmInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tipoOper = 1
        CenterToScreen()

        cargarTiendas()
        filtro()

        If Tiendas = 0 Then
            cbProductos.SelectedIndex = 0

        Else
            cbProductos.SelectedIndex = Tiendas - 1
        End If


    End Sub


    Public Sub cargarTiendas()

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
            cbProductos.DataSource = dt
            cbProductos.DisplayMember = "NombreTienda"
            cbProductos.ValueMember = "CodTienda"

            tipoOper = 2
        End Using
    End Sub

    Sub llenarComboProductosMayores()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spVerInventarioMayores"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@Nombre", txtbuscar.Text)
            sqlComm.Parameters.AddWithValue("@CodTienda", cbProductos.SelectedValue)
            sqlCon.Open()
            'se ejecuta el el stored procedure en el servidor de bases de datos
            sqlComm.ExecuteNonQuery()



            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            DataGridView1.DataSource = dt
        End Using

    End Sub


    Private Sub txtCodProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodProducto.KeyPress
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
                NombreProducto.Text = asistente.SelectedRows.Item(0).Cells(1).Value
                TxtCantidad.Enabled = True
                TxtCantidad.Focus()
            Catch ex As Exception
                MsgBox("Error: El codigo de producto no pertenece a ninguno registrado", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End If
        If Asc(e.KeyChar) = 8 Then
            TxtCantidad.Enabled = False
            TxtCantidad.Text = ""
            NombreProducto.Text = ""

        End If
    End Sub

    Private Sub frmInventario_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MayoresDeCero.Checked = False
    End Sub



    Private Sub cbProductos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedValueChanged
        If tipoOper = 2 Then
            filtro()
        End If

    End Sub


    Sub filtro()

        If MayoresDeCero.Checked = False Then
            buscarNombre()

        Else
            llenarComboProductosMayores()
        End If
    End Sub

    Private Sub MayoresDeCero_CheckedChanged(sender As Object, e As EventArgs) Handles MayoresDeCero.CheckedChanged
        filtro()
    End Sub


    Private Sub buscarNombre()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spBuscarInventarioNombre"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure
            sqlComm.Parameters.AddWithValue("@Nombre", txtbuscar.Text)
            sqlComm.Parameters.AddWithValue("@CodTienda", cbProductos.SelectedValue)
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            DataGridView1.DataSource = dt
        End Using

    End Sub

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged
        buscarNombre()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TxtCantidad.Text = "" Then
            Exit Sub
        End If

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "Aumentarstock"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodTienda", cbProductos.SelectedValue)
            sqlComm.Parameters.AddWithValue("@CodProducto", CInt(txtCodProducto.Text))

            Try
                sqlComm.Parameters.AddWithValue("@Cantidad", CInt(TxtCantidad.Text))
            Catch ex As Exception
                MsgBox("Error: La cantidad debe ser un numero", MsgBoxStyle.Critical, "Mensaje del Sistema")
                TxtCantidad.Focus()
                Exit Sub
            End Try

            sqlCon.Open()
            'se ejecuta el el stored procedure en el servidor de bases de datos
            sqlComm.ExecuteNonQuery()

            filtro()

            TxtCantidad.Enabled = False
            txtCodProducto.Text = ""
            TxtCantidad.Text = ""
            NombreProducto.Text = ""
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TxtCantidad.Text = "" Then
            Exit Sub
        End If
        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "Disminuirstock"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodTienda", cbProductos.SelectedValue)
            sqlComm.Parameters.AddWithValue("@CodProducto", CInt(txtCodProducto.Text))

            Try
                sqlComm.Parameters.AddWithValue("@Cantidad", CInt(TxtCantidad.Text))
            Catch ex As Exception
                MsgBox("Error: La cantidad debe ser un numero", MsgBoxStyle.Critical, "Mensaje del Sistema")
                TxtCantidad.Focus()
                Exit Sub
            End Try

            sqlCon.Open()
            'se ejecuta el el stored procedure en el servidor de bases de datos
            sqlComm.ExecuteNonQuery()

            filtro()

            txtCodProducto.Text = ""
            TxtCantidad.Enabled = False
            TxtCantidad.Text = ""
            NombreProducto.Text = ""
        End Using
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtCodProducto_TextChanged(sender As Object, e As EventArgs) Handles txtCodProducto.TextChanged

    End Sub
End Class