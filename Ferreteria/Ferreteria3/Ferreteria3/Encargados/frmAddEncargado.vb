Imports System.Data
Imports System.Data.SqlClient
Public Class frmAddEncargado
    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmInfoEncargado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        If tipoOper = 1 Then 'Insercion
            Me.LblTitulo.Text = "Agregar nuevo encargado"
        Else
            Me.LblTitulo.Text = "Modificar un encargado"

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

                sqlComm.Parameters.AddWithValue("@CodigoEncargado", CInt(frmConsultaEncargado.DataGridView1.SelectedRows.Item(0).Cells(0).Value))
                'se crea una instancia del sqldataadapter
                sqlad = New SqlDataAdapter(sqlComm)
                dt = New DataTable("Datos")
                sqlad.Fill(dt)
                frmConsultaEncargado.Asistente.DataSource = dt
            End Using

            'Pone los datos del producto a modificar en la ventana 

            TxtCodProvedor.Text = frmConsultaEncargado.Asistente.SelectedRows.Item(0).Cells(0).Value
            txtNombre.Text = frmConsultaEncargado.Asistente.SelectedRows.Item(0).Cells(1).Value
            txtTelefono.Text = frmConsultaEncargado.Asistente.SelectedRows.Item(0).Cells(3).Value
            txtCorreo.Text = frmConsultaEncargado.Asistente.SelectedRows.Item(0).Cells(4).Value
            txtDireccion.Text = frmConsultaEncargado.Asistente.SelectedRows.Item(0).Cells(2).Value

        End If
    End Sub



    Private Sub frmAddEncargado_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        txtNombre.Text = ""
        txtCorreo.Text = ""
        txtDireccion.Text = ""
        txtTelefono.Text = ""
        frmConsultaEncargado.mostrarEmpleadoFiltroNombre()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Valida que se pongan todos los datos
        If txtTelefono.Text = "" Or TxtCodProvedor.Text = "" Or txtNombre.Text = "" Or txtDireccion.Text = "" Or txtCorreo.Text = "" Then
            MsgBox("Complete Todos Los Datos Porfavor", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        sqlCon = New SqlConnection(conn)
        Dim sqlComm As New SqlCommand()
        'se hace la referencia a la conexión, OJO ver código del Módulo 1
        sqlComm.Connection = sqlCon
        If tipoOper = 1 Then 'Insercion
            Using (sqlCon)

                'Valida que se ingrese solamente numeros en el campo de telefono
                Try
                    'se indica el nombre del stored procedure y el tipo
                    sqlComm.CommandText = "spAgregarEncargado"
                    sqlComm.CommandType = CommandType.StoredProcedure
                    sqlComm.Parameters.AddWithValue("@Telefono", CInt(txtTelefono.Text))

                Catch ex As Exception
                    MsgBox("Error: El telefono debe ser un numero", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End Try

                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodigoEncargado", CInt(TxtCodProvedor.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                sqlComm.Parameters.AddWithValue("@Direccion", txtDireccion.Text)
                sqlComm.Parameters.AddWithValue("@Correo", txtCorreo.Text)
                sqlCon.Open()

                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("Encargado Registrado Correctamente", MsgBoxStyle.Information, "Registro Encargado")
                frmEmpleados.llenarComboProductos()
                Me.Close()

            End Using

        Else 'Modificar
            Using (sqlCon)
                If MsgBox("¿Desesa Guardar los Cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarEncargad"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodigoEncargado", CInt(TxtCodProvedor.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                sqlComm.Parameters.AddWithValue("@Direccion", txtDireccion.Text)

                'Valida que se ingrese solamente numeros en el campo de telefono
                Try
                    sqlComm.Parameters.AddWithValue("@Telefono", CInt(txtTelefono.Text))
                Catch ex As Exception
                    MsgBox("Error: El telefono debe ser un numero", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End Try

                sqlComm.Parameters.AddWithValue("@Correo", txtCorreo.Text)

                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("El encargado se modifico correctamente", MsgBoxStyle.Information, "Modificar Encargado")
                'Actualiza la tabla de productos
                frmConsultaEncargado.mostrarEmpleadoFiltroNombre()
                Me.Close()
            End Using

        End If
        'Actualiza la tabla de productos
    End Sub


End Class