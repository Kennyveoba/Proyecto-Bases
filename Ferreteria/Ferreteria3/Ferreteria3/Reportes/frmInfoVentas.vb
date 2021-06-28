Imports System.Data
Imports System.Data.SqlClient
Public Class frmInfoVentas
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmInfoVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
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
            sqlComm.Parameters.AddWithValue("@CodVenta", frmReportes.DataGridView1.SelectedRows.Item(0).Cells(0).Value)

            sqlCon.Open()
            'se ejecuta el el stored procedure en el servidor de bases de datos
            Try

                sqlComm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Debe seleccionar un factura primero", MsgBoxStyle.Information, "Sistema")
                Exit Sub
            End Try

            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            DataGridView1.DataSource = dt
            sqlCon.Close()
        End Using
        Label11.Text = Format(frmReportes.DataGridView1.SelectedRows.Item(0).Cells(0).Value, "0000000")
        lblFecha.Text = frmReportes.DataGridView1.SelectedRows.Item(0).Cells(1).Value
        TextBox2.Text = frmReportes.DataGridView1.SelectedRows.Item(0).Cells(2).Value
        NombreCliente.Text = frmReportes.DataGridView1.SelectedRows.Item(0).Cells(3).Value
        TextBox1.Text = frmReportes.DataGridView1.SelectedRows.Item(0).Cells(7).Value
        Subtotal.Text = frmReportes.DataGridView1.SelectedRows.Item(0).Cells(4).Value
        IVA.Text = frmReportes.DataGridView1.SelectedRows.Item(0).Cells(5).Value
        Total.Text = frmReportes.DataGridView1.SelectedRows.Item(0).Cells(6).Value
    End Sub


End Class