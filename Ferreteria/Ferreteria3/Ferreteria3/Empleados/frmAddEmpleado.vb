Imports System.Data
Imports System.Data.SqlClient
Public Class frmAddEmpleado
    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmAddEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        cargarOcupaciones()
        ComboBox1.SelectedValue = -1
    End Sub

    Public Sub cargarOcupaciones()
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
            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "Ocupacion"
            ComboBox1.ValueMember = "CodOcupacion"
        End Using
    End Sub



    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmCargos.ShowDialog()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Valida que se pongan todos los datos
        If txtNombre.Text = "" Then
            MsgBox("Complete Todos Los Datos Porfavor", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        sqlCon = New SqlConnection(conn)
        Dim sqlComm As New SqlCommand()
        'se hace la referencia a la conexión, OJO ver código del Módulo 1
        sqlComm.Connection = sqlCon

        If tipoOper = 1 Then 'Insercion
            Using (sqlCon)
                Try
                    'se indica el nombre del stored procedure y el tipo
                    sqlComm.CommandText = "spAgregarEmpleado"
                    sqlComm.CommandType = CommandType.StoredProcedure
                    'se pasan los parámetros al store procedure

                    sqlComm.Parameters.AddWithValue("@CodEmpleado", CInt(TxtCodProvedor.Text))
                    sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                    sqlComm.Parameters.AddWithValue("@Direccion", txtDireccion.Text)
                    sqlComm.Parameters.AddWithValue("@Telefono", CInt(txtTelefono.Text))
                    sqlComm.Parameters.AddWithValue("@Correo", txtCorreo.Text)
                    sqlComm.Parameters.AddWithValue("@CodOCupacion", CInt(ComboBox1.SelectedValue))
                    sqlComm.Parameters.AddWithValue("@FechaNacimiento", DateTimePicker1.Text)

                    sqlCon.Open()

                    'se ejecuta el el stored procedure en el servidor de bases de datos
                    sqlComm.ExecuteNonQuery()
                    MsgBox("Producto Registrado Correctamente", MsgBoxStyle.Information, "Registro Productos")
                    frmEmpleados.llenarComboProductos()
                    Me.Close()
                Catch ex As Exception
                    MsgBox("Complete Todos Los Datos Porfavor", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                End Try

            End Using



        Else 'Modificar
            Using (sqlCon)
                If MsgBox("¿Desesa Guardar los Cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarEmpleado"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodEmpleado", CInt(TxtCodProvedor.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                sqlComm.Parameters.AddWithValue("@Direccion", txtDireccion.Text)
                sqlComm.Parameters.AddWithValue("@Telefono", CInt(txtTelefono.Text))
                sqlComm.Parameters.AddWithValue("@Correo", txtCorreo.Text)
                sqlComm.Parameters.AddWithValue("@CodOCupacion", CInt(ComboBox1.SelectedValue))
                sqlComm.Parameters.AddWithValue("@FechaNacimiento", DateTimePicker1.Text)

                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("El empleado se modifico correctamente", MsgBoxStyle.Information, "Modificar Categoria")
                'Actualiza la tabla de productos
                frmEmpleados.llenarComboProductos()
                Me.Close()
            End Using

        End If
        'Actualiza la tabla de productos
    End Sub

    Private Sub TxtCodProvedor_TextChanged(sender As Object, e As EventArgs) Handles TxtCodProvedor.TextChanged

    End Sub
End Class