Imports System.Data
Imports System.Data.SqlClient
Public Class frmSucursal
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        cargarTiendas()
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmInfoEncargado.ShowDialog()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If cbProductos.SelectedValue = 0 Then
            MsgBox("Debe seleccionar una sucursal primero", MsgBoxStyle.Information, "Sistema")
            Exit Sub
        End If
        frmAddSucusal.ShowDialog()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

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

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spElimanarSucursal"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@Tiendas", cbProductos.SelectedValue)
            sqlad.Fill(dt)
            cargarTiendas()
            MsgBox("Sucursal eliminada de forma exitosa", MsgBoxStyle.Information, "Sistema")
        End Using
    End Sub
End Class