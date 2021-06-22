Imports System.Data
Imports System.Data.SqlClient
Public Class frmCargos
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
                sqlComm.CommandText = "spObtenerMaximaocupacion"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se crea una instancia del sqldataadapter
                sqlad = New SqlDataAdapter(sqlComm)
                dt = New DataTable("Datos")
                sqlad.Fill(dt)
                frmAddCargo.TxtCodProvedor.Text = CStr(CInt(dt.Rows(0).Item(0)) + 1)
            Catch ex As Exception
                'En caso que la tabla de clientes no tenga valores 
                frmAddCargo.TxtCodProvedor.Text = 1
            End Try

        End Using
        tipoOper = 1
        frmAddCargo.ShowDialog()
    End Sub



    Private Sub frmCargos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
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
            sqlComm.CommandText = "spSeleccionarOcupaciones"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            DataGridView1.DataSource = dt
        End Using

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            frmAddCargo.TxtCodProvedor.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
            tipoOper = 2
            frmAddCargo.ShowDialog()
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
            If MsgBox("¿Realmente desea eliminar esta ocupacion?" + vbCr + " Se eliminara para siempre eso es mucho tiempo!!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim sqlComm As New SqlCommand()
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spElimanarOcupacion"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodOcupacion", DataGridView1.SelectedRows.Item(0).Cells(0).Value)
            sqlad.Fill(dt)
        End Using
        Me.llenarComboProductos()
    End Sub

    Private Sub frmCargos_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmAddEmpleado.cargarOcupaciones()
    End Sub
End Class