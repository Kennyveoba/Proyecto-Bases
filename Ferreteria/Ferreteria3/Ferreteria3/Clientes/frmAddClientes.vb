Imports System.Data
Imports System.Data.SqlClient
Public Class frmAddClientes
    Private Sub frmAddClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        Me.TxtCodCliente.Enabled = False

        If tipoOper = 1 Then 'Insercion
            Me.LblTitulo.Text = "Agregar nuevo cliente"
        Else
            Me.LblTitulo.Text = "Modificar un cliente"
            TxtCodCliente.Text = frmClientes.DataGridView1.SelectedRows.Item(0).Cells(0).Value
            txtNombre.Text = frmClientes.DataGridView1.SelectedRows.Item(0).Cells(1).Value
            txtTelefono.Text = frmClientes.DataGridView1.SelectedRows.Item(0).Cells(2).Value
            txtCorreo.Text = frmClientes.DataGridView1.SelectedRows.Item(0).Cells(3).Value
            txtDireccion.Text = frmClientes.DataGridView1.SelectedRows.Item(0).Cells(4).Value
        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles LblTitulo.Click

    End Sub

    Private Sub TxtCodCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCodCliente.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If TxtCodCliente.Text = "" Or txtNombre.Text = "" Or txtTelefono.Text = "" Or txtCorreo.Text = "" Or txtDireccion.Text = "" Then
            MsgBox("Complete Todos Los Datos Porfavor", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If


        sqlCon = New SqlConnection(conn)
        Dim sqlComm As New SqlCommand()
        'se hace la referencia a la conexión, OJO ver código del Módulo 1
        sqlComm.Connection = sqlCon

        If tipoOper = 1 Then 'Insercion
            Using (sqlCon)
                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "AgregarCliente"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodCliente", CInt(TxtCodCliente.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)

                Try
                    sqlComm.Parameters.AddWithValue("@Telefono", CInt(txtTelefono.Text))
                Catch ex As Exception
                    MsgBox("ERROR: Ingrese un numero valido", MsgBoxStyle.Critical, "Sistema")
                    Exit Sub
                End Try

                sqlComm.Parameters.AddWithValue("@Correo", txtCorreo.Text)
                sqlComm.Parameters.AddWithValue("@Direccion", txtDireccion.Text)
                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("Cliente Registrado Correctamente", MsgBoxStyle.Information, "Registro Clientes")
                frmClientes.mostrarcliente()

                Me.Close()
            End Using



        Else 'Modificar
            Using (sqlCon)
                If MsgBox("¿Desesa Guardar los Cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarCliente"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodCliente", CInt(TxtCodCliente.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                sqlComm.Parameters.AddWithValue("@Telefono", CInt(txtTelefono.Text))
                sqlComm.Parameters.AddWithValue("@Correo", txtCorreo.Text)
                sqlComm.Parameters.AddWithValue("@Direccion", txtDireccion.Text)
                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("El cliente se modifico correctamente", MsgBoxStyle.Information, "Modificar Clientes")
                frmClientes.mostrarcliente()
                Me.Close()
            End Using
        End If
        TxtCodCliente.Text = ""
        txtNombre.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        txtDireccion.Text = ""

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub frmAddClientes_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        txtNombre.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        txtDireccion.Text = ""
    End Sub
End Class