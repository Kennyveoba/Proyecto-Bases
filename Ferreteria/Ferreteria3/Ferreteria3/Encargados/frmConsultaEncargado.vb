Imports System.Data
Imports System.Data.SqlClient
Public Class frmConsultaEncargado
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
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
                sqlComm.CommandText = "spObtenerMaximoEncargado"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se crea una instancia del sqldataadapter
                sqlad = New SqlDataAdapter(sqlComm)
                dt = New DataTable("Datos")
                sqlad.Fill(dt)
                frmAddEncargado.TxtCodProvedor.Text = CStr(CInt(dt.Rows(0).Item(0)) + 1)
            Catch ex As Exception
                'En caso que la tabla de clientes no tenga valores 
                frmAddEncargado.TxtCodProvedor.Text = 1
            End Try

        End Using
        tipoOper = 1
        frmAddEncargado.ShowDialog()
    End Sub


    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged
        mostrarEmpleadoFiltroNombre()
    End Sub

    Public Sub mostrarEmpleadoFiltroNombre()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spSeleccionarEncargadoNombre"
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


    Private Sub frmConsultaEncargado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrarEmpleadoFiltroNombre()
        Me.CenterToScreen()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            frmAddEmpleado.TxtCodProvedor.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
            tipoOper = 2
            frmAddEncargado.ShowDialog()
        Catch ex As Exception
            MsgBox("Debe seleccionar un encargado primero", MsgBoxStyle.Information, "Sistema")
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        Try
            frmAddProveedores.TxtCodProvedor.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        Catch ex As Exception
            MsgBox("Debe seleccionar un encargado primero", MsgBoxStyle.Information, "Sistema")
            Exit Sub
        End Try
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        'sqlCon = New SqlConnection(conn)
        'cmd = New SqlCommand("spObtenerMaximoCategoria", sqlCon)

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)
            If MsgBox("¿Realmente desea eliminar este encargado?" + vbCr + " Se eliminara para siempre eso es mucho tiempo!!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                Exit Sub
            End If
            Try

                Dim sqlComm As New SqlCommand()
                'se crea una instancia del sqldataadapter
                sqlad = New SqlDataAdapter(sqlComm)
                dt = New DataTable("Datos")
                'se hace la referencia a la conexión, OJO ver código del Módulo 1
                sqlComm.Connection = sqlCon

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spElimanarEncargado"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("@CodigoEncargado", DataGridView1.SelectedRows.Item(0).Cells(0).Value)
                sqlad.Fill(dt)
            Catch ex As Exception
                MsgBox("Este encargado se encuentra ligado a una sucursal por lo que no se puede borrar", MsgBoxStyle.Information, "Sistema")
            End Try

        End Using
        mostrarEmpleadoFiltroNombre()
    End Sub
End Class