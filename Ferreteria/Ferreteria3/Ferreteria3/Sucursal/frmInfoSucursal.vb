Imports System.Data
Imports System.Data.SqlClient
Public Class frmInfoSucursal
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmInfoSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            sqlComm.CommandText = "spMostrarInfoTiendas"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@CodTienda", frmSucursal.cbProductos.SelectedValue)
            'se crea una instancia del sqldataadapter

            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            TextBox1.Text = dt(0)(0)
            CodSucursal.Text = dt(0)(1)
            TextBox3.Text = dt(0)(2)
            TextBox5.Text = dt(0)(3)
            TextBox4.Text = dt(0)(5)
            TextBox2.Text = dt(0)(4)
        End Using
    End Sub
End Class