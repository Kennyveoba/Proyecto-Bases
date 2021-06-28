Imports System.Data
Imports System.Data.SqlClient
Public Class frmReportes
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        CargarVentas()
    End Sub



    Private Sub CargarVentas()

        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spMostrarVentas"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodVenta", txtbuscar.Text)

            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            DataGridView1.DataSource = dt
        End Using


    End Sub

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged
        CargarVentas()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            frmAddProductos.TxtCodProducto.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
            frmInfoVentas.ShowDialog()
        Catch ex As Exception
            MsgBox("Debe seleccionar una factura primero", MsgBoxStyle.Information, "Sistema")
        End Try
    End Sub
End Class