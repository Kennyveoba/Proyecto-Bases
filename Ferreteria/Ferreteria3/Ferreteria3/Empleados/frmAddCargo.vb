Imports System.Data
Imports System.Data.SqlClient
Public Class frmAddCargo
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If TxtCodProvedor.Text = "" Or txtDireccion.Text = "" Then
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
                sqlComm.CommandText = "spCrearOcupacion"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodOcupacion", CInt(TxtCodProvedor.Text))
                sqlComm.Parameters.AddWithValue("@Descripcion", txtDireccion.Text)
                sqlComm.Parameters.AddWithValue("@Ocupacion", txtNombre.Text)
                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("Ocupacion Registrada Correctamente", MsgBoxStyle.Information, "Registro Ocupacion")
                frmCargos.llenarComboProductos()
                Me.Close()
            End Using



        Else 'Modificar
            Using (sqlCon)
                If MsgBox("¿Desesa Guardar los Cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarCargo"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodOcupacion", CInt(TxtCodProvedor.Text))
                sqlComm.Parameters.AddWithValue("@Descripcion", txtDireccion.Text)
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)

                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("El cargo se modifico correctamente", MsgBoxStyle.Information, "Modificar Cargo")
                frmCargos.llenarComboProductos()
                Me.Close()
            End Using
        End If
        TxtCodProvedor.Text = ""
        txtDireccion.Text = ""

    End Sub

    Private Sub frmAddCargo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        txtNombre.Text = ""
        txtDireccion.Text = ""
        If tipoOper = 1 Then 'Insercion
            Me.LblTitulo.Text = "Agregar nuevo cargo"
        Else
            Me.LblTitulo.Text = "Modificar un cargo"
            TxtCodProvedor.Text = frmCargos.DataGridView1.SelectedRows.Item(0).Cells(0).Value
            txtNombre.Text = frmCargos.DataGridView1.SelectedRows.Item(0).Cells(1).Value
            txtDireccion.Text = frmCargos.DataGridView1.SelectedRows.Item(0).Cells(2).Value
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtCodProvedor_TextChanged(sender As Object, e As EventArgs) Handles TxtCodProvedor.TextChanged

    End Sub


End Class