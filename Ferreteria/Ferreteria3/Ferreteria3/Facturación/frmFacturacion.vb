Imports System.Data
Imports System.Data.SqlClient
Public Class frmFacturacion

    Private Sub frmFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtFecha.Text = Now
        Me.lblFecha.Text = Format(Now, "dd/mm/yyyy")
    End Sub


    Public Sub mostrarClientesFiltroNombre()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)
            Try
                Dim sqlComm As New SqlCommand()
                'se hace la referencia a la conexión, OJO ver código del Módulo 1
                sqlComm.Connection = sqlCon

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spSeleccionarClientesNombre"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@Nombre", TextBox3.Text)
                'se crea una instancia del sqldataadapter
                sqlad = New SqlDataAdapter(sqlComm)
                dt = New DataTable("Datos")
                sqlad.Fill(dt)

                txtNombreCliente.Text = dt(0)(1)
            Catch ex As Exception
                MsgBox("Error: El nombre no se encuentra en el sistema", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try

        End Using
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            mostrarClientesFiltroNombre()
        End If
    End Sub

End Class