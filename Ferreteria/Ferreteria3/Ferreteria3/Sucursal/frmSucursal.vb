Imports System.Data
Imports System.Data.SqlClient
Public Class frmSucursal
    Dim vadera As Integer


    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        vadera = 1
        Me.CenterToScreen()
        cargarTiendas()
        cargarEncargado()
        cargarEmpleados()
        vadera = 2
        If Tiendas = 0 Then
            cbProductos.SelectedIndex = -1

        Else
            cbProductos.SelectedValue = Tiendas
        End If


    End Sub



    Public Sub cargarEmpleados()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spSeleccionarEmpleadosSucursal"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodTienda", CInt(cbProductos.SelectedValue))
            sqlComm.Parameters.AddWithValue("@Nombre", TextBox1.Text)
            'se crea una instancia del sqldataadapter

            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            DataGridView1.DataSource = dt


        End Using
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
            sqlComm.CommandText = "spMostrarInfoTiendas"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodTienda", cbProductos.SelectedValue)
            'se crea una instancia del sqldataadapter
            Try
                sqlad = New SqlDataAdapter(sqlComm)
                dt = New DataTable("Datos")
                sqlad.Fill(dt)
                TextBox2.Text = dt(0)(1)
            Catch ex As Exception
                TextBox2.Text = ""
            End Try

        End Using
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


        End Using
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmConsultaEncargado.ShowDialog()
    End Sub

    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
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
                frmAddSucusal.CodSucursal.Text = CStr(CInt(dt.Rows(0).Item(0)) + 1)

            Catch ex As Exception
                'En caso que la tabla de clientes no tenga valores 
                frmAddSucusal.CodSucursal.Text = 1
            End Try

        End Using
        tipoOper = 1
        frmAddSucusal.CodSucursal.Enabled = False
        frmAddSucusal.ShowDialog()
    End Sub

    Public Sub btnModificar_Click_1(sender As Object, e As EventArgs) Handles btnModificar.Click
        If cbProductos.SelectedValue = 0 Then
            MsgBox("Debe seleccionar una sucursal primero", MsgBoxStyle.Information, "Sistema")
            Exit Sub
        End If
        tipoOper = 2
        frmAddSucusal.ShowDialog()
    End Sub


    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub



    Private Sub cbProductos_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged
        If vadera = 2 Then
            cargarEncargado()
            Tiendas = cbProductos.SelectedValue
            cargarEmpleados()
        End If
    End Sub

    Private Sub btnBorrar_Click_1(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If cbProductos.SelectedValue = 0 Then
            MsgBox("Debe seleccionar una sucursal primero", MsgBoxStyle.Information, "Sistema")
            Exit Sub
        End If
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
            Try
                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spElimanarSucursal"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("@Tiendas", cbProductos.SelectedValue)
                sqlad.Fill(dt)
                cargarTiendas()
                cargarEncargado()
                MsgBox("Sucursal eliminada de forma exitosa", MsgBoxStyle.Information, "Sistema")
            Catch ex As Exception
                MsgBox("Error: Uno o varios empleados salen registrados en esta sucursal, debe estar vacia para continuar", MsgBoxStyle.Critical, "Sistema")
            End Try

        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cbProductos.SelectedIndex > -1 Then
            frmInfoSucursal.ShowDialog()

        Else
            MsgBox("Debe seleccionar una sucursal primero", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        cargarEmpleados()
    End Sub
End Class