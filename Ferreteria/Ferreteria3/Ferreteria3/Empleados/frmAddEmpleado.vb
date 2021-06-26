Imports System.Data
Imports System.Data.SqlClient
Public Class frmAddEmpleado
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub frmAddEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        cargarOcupaciones()
        cargarSucursales()
        ComboBox1.SelectedValue = -1

        If tipoOper = 1 Then 'Insercion
            Me.LblTitulo.Text = "Agregar nuevo empleado"
        Else
            Me.LblTitulo.Text = "Modificar un empleado"

            Dim sqlad As SqlDataAdapter
            Dim dt As DataTable

            sqlCon = New SqlConnection(conn)

            Using (sqlCon)

                Dim sqlComm As New SqlCommand()
                'se hace la referencia a la conexión, OJO ver código del Módulo 1
                sqlComm.Connection = sqlCon

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarEmpleado"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodEmpleado", CInt(frmEmpleados.DataGridView1.SelectedRows.Item(0).Cells(0).Value))
                'se crea una instancia del sqldataadapter
                sqlad = New SqlDataAdapter(sqlComm)
                dt = New DataTable("Datos")
                sqlad.Fill(dt)
                frmEmpleados.Asistente.DataSource = dt
            End Using

            'Pone los datos del producto a modificar en la ventana 
            ComboBox1.SelectedValue = CInt(frmEmpleados.Asistente.SelectedRows.Item(0).Cells(2).Value)
            TxtCodProvedor.Text = frmEmpleados.Asistente.SelectedRows.Item(0).Cells(0).Value
            txtNombre.Text = frmEmpleados.Asistente.SelectedRows.Item(0).Cells(1).Value
            txtTelefono.Text = frmEmpleados.Asistente.SelectedRows.Item(0).Cells(3).Value
            txtCorreo.Text = frmEmpleados.Asistente.SelectedRows.Item(0).Cells(5).Value
            txtDireccion.Text = frmEmpleados.Asistente.SelectedRows.Item(0).Cells(6).Value
            DateTimePicker1.Value = frmEmpleados.Asistente.SelectedRows.Item(0).Cells(4).Value
            ComboBox2.SelectedValue = CInt(frmEmpleados.Asistente.SelectedRows.Item(0).Cells(7).Value)
        End If
    End Sub


    Public Sub cargarSucursales()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable
        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spMostrarTiendas"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            ComboBox2.DataSource = dt
            ComboBox2.DisplayMember = "NombreTienda"
            ComboBox2.ValueMember = "CodTienda"


        End Using
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


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Valida que se pongan todos los datos
        If txtTelefono.Text = "" Or TxtCodProvedor.Text = "" Or txtNombre.Text = "" Or txtDireccion.Text = "" Or txtCorreo.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or DateTimePicker1.Text = "" Then
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
                    sqlComm.CommandText = "spAgregarEmpleado"
                    sqlComm.CommandType = CommandType.StoredProcedure
                    sqlComm.Parameters.AddWithValue("@Telefono", CInt(txtTelefono.Text))

                Catch ex As Exception
                    MsgBox("Error: El telefono debe ser un numero", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End Try

                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodEmpleado", CInt(TxtCodProvedor.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                sqlComm.Parameters.AddWithValue("@Direccion", txtDireccion.Text)
                sqlComm.Parameters.AddWithValue("@Correo", txtCorreo.Text)
                sqlComm.Parameters.AddWithValue("@CodOCupacion", CInt(ComboBox1.SelectedValue))
                sqlComm.Parameters.AddWithValue("@CodSucursal", CInt(ComboBox2.SelectedValue))
                sqlComm.Parameters.AddWithValue("@FechaNacimiento", DateTimePicker1.Text)
                sqlCon.Open()

                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("Empleado Registrado Correctamente", MsgBoxStyle.Information, "Registro Empleados")
                frmEmpleados.llenarComboProductos()
                Me.Close()

            End Using

        Else 'Modificar
            Using (sqlCon)
                If MsgBox("¿Desesa Guardar los Cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarEmpleados"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodEmpleado", CInt(TxtCodProvedor.Text))
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
                sqlComm.Parameters.AddWithValue("@CodOCupacion", CInt(ComboBox1.SelectedValue))
                sqlComm.Parameters.AddWithValue("@CodSucursal", CInt(ComboBox2.SelectedValue))
                sqlComm.Parameters.AddWithValue("@FechaNacimiento", DateTimePicker1.Text)

                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
                MsgBox("El empleado se modifico correctamente", MsgBoxStyle.Information, "Modificar Empleado")
                'Actualiza la tabla de productos
                frmEmpleados.llenarComboProductos()
                Me.Close()
            End Using

        End If
        'Actualiza la tabla de productos
    End Sub

    Private Sub frmAddEmpleado_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ComboBox1.SelectedValue = -1
        txtNombre.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        txtDireccion.Text = ""
        ComboBox2.SelectedValue = -1
    End Sub



    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        frmSucursal.ShowDialog()
    End Sub
End Class