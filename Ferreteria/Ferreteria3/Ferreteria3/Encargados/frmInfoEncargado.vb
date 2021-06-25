Imports System.Data
Imports System.Data.SqlClient
Public Class frmInfoEncargado
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter


        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spSeleccionarEncargados"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se pasan los parámetros al store procedure

            sqlComm.Parameters.AddWithValue("@CodigoEncargado", frmSucursal.TextBox3.Text)
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            frmConsultaEncargado.Asistente.DataSource = dt
        End Using

        'Pone los datos del producto a modificar en la ventana 

        TxtCodProvedor.Text = dt(0)(0)
        txtNombre.Text = dt(0)(1)
        txtTelefono.Text = dt(0)(3)
        txtCorreo.Text = dt(0)(4)
        txtDireccion.Text = dt(0)(2)
    End Sub

    Private Sub frmInfoEncargado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class