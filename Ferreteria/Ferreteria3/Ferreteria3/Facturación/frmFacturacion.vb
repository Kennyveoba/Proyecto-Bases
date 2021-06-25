Imports System.Data
Imports System.Data.SqlClient
Public Class frmFacturacion
    Dim thisDate As Date
    Dim cargar As Boolean

    Private Sub frmFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar = False
        Me.CenterToScreen()
        cargarSucursales()
        Me.lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")
    End Sub


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

    Public Sub mostrarClientesFiltroNombre()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            If IsNumeric(TextBox4.Text) = False Then
                MsgBox("Error: El codigo debe ser un numero", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Sub
            End If
            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spSeleccionarEmpleado"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure
            sqlComm.Parameters.AddWithValue("@CodEmpleado", CInt(TextBox4.Text))
            sqlComm.Parameters.AddWithValue("@CodSucursal", CInt(ComboBox2.SelectedValue))
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            asistente.DataSource = dt
            Try

                TextBox2.Text = asistente.SelectedRows.Item(0).Cells(1).Value
                TextBox1.Focus()

            Catch ex As Exception
                MsgBox("Error: El codigo del empleado no pertenece a ninguno registrado en esta sucursal", MsgBoxStyle.Critical, "Mensaje del Sistema")
                TextBox2.Text = ""
                TextBox4.Focus()
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

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        frmEmpleados.ShowDialog()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        frmSucursal.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        frmClientes.ShowDialog()
    End Sub



    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            mostrarClientesFiltroNombre()
        End If

        If Asc(e.KeyChar) = 8 Then
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If cargar Then
            mostrarClientesFiltroNombre()
        End If

    End Sub
End Class