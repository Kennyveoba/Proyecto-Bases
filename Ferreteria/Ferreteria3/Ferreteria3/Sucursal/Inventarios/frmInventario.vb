Imports System.Data
Imports System.Data.SqlClient
Public Class frmInventario
    Private Sub frmInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        llenarComboProductos()
    End Sub

    Sub llenarComboProductos()
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spSeleccionarProductos"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            DataGridView1.DataSource = dt
        End Using

    End Sub



    Private Sub txtCodProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim sqlad As SqlDataAdapter
            Dim dt As DataTable

            sqlCon = New SqlConnection(conn)

            Using (sqlCon)

                Dim sqlComm As New SqlCommand()
                'se hace la referencia a la conexión, OJO ver código del Módulo 1
                sqlComm.Connection = sqlCon

                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spSeleccionarProducto"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure

                Try
                    sqlComm.Parameters.AddWithValue("@CodProducto", CInt(txtCodProducto.Text))
                    'se crea una instancia del sqldataadapter
                    sqlad = New SqlDataAdapter(sqlComm)
                    dt = New DataTable("Datos")
                    sqlad.Fill(dt)
                    asistente.DataSource = dt
                Catch ex As Exception
                    MsgBox("Error: Solo se permiten numeros", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End Try
            End Using

            'Pone el nombre del producto que se va a agregar en el inventario  
            Try
                NombreProducto.Text = asistente.SelectedRows.Item(0).Cells(1).Value
                TxtCantidad.Enabled = True
                TxtCantidad.Focus()
            Catch ex As Exception
                MsgBox("Error: El codigo de producto no pertenece a ninguno registrado", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End If
        If Asc(e.KeyChar) = 8 Then
            TxtCantidad.Enabled = False
            TxtCantidad.Text = ""
            NombreProducto.Text = ""

        End If
    End Sub


End Class