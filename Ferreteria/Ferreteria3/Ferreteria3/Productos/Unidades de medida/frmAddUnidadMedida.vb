Imports System.Data
Imports System.Data.SqlClient
Public Class frmAddUnidadMedida
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmAddUnidadMedida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()

        If tipoOper = 1 Then 'Insercion
            Me.LblTitulo.Text = "Agregar nueva unidad"
        Else
            Me.LblTitulo.Text = "Modificar una unidad"
            TxtCodCategoría.Text = frmUnidadMedida.dgvCategorias.SelectedRows.Item(0).Cells(0).Value
            txtNombre.Text = frmUnidadMedida.dgvCategorias.SelectedRows.Item(0).Cells(1).Value
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If TxtCodCategoría.Text = "" Or txtNombre.Text = "" Then
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
                sqlComm.CommandText = "spAgregarUnidadMedida"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodUnidadesDeMedida", CInt(TxtCodCategoría.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                sqlCon.Open()

                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("Unidad Registrada Correctamente", MsgBoxStyle.Information, "Registro Unidades")
                frmProveedores.mostraProvedor()
                Me.Close()
            End Using



        Else 'Modificar
            Using (sqlCon)
                If MsgBox("¿Desesa Guardar los Cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarUnidad"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodUnidadesDeMedida", CInt(TxtCodCategoría.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("La unidad se modifico correctamente", MsgBoxStyle.Information, "Modificar Unidad")
                frmProveedores.mostraProvedor()
                Me.Close()
            End Using
        End If
        TxtCodCategoría.Text = ""
        txtNombre.Text = ""
        frmUnidadMedida.llenarComboUnidades()
    End Sub
End Class