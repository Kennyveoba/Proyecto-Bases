Imports System.Data
Imports System.Data.SqlClient
Public Class frmCategorias
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim sqlad As SqlDataAdapter
        Dim dt As DataTable

        'sqlCon = New SqlConnection(conn)
        'cmd = New SqlCommand("spObtenerMaximoCategoria", sqlCon)

        sqlCon = New SqlConnection(conn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            'se hace la referencia a la conexión, OJO ver código del Módulo 1
            sqlComm.Connection = sqlCon

            'se indica el nombre del stored procedure y el tipo
            sqlComm.CommandText = "spObtenerMaximoCategoria"
            sqlComm.CommandType = CommandType.StoredProcedure
            'se crea una instancia del sqldataadapter
            sqlad = New SqlDataAdapter(sqlComm)
            dt = New DataTable("Datos")
            sqlad.Fill(dt)
            Me.txtCodCategoria.Text = CStr(CInt(dt.Rows(0).Item(0)) + 1)
        End Using
        tipoOper = 1
        btnGuardar.Enabled = True
        Me.txtCategoria.Enabled = True

    End Sub

    Private Sub frmCategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        deshabilitarObjetos()
    End Sub

    Private Sub deshabilitarObjetos()
        Me.txtCategoria.Enabled = False
        Me.txtCodCategoria.Enabled = False
        Me.btnBorrar.Enabled = False
        Me.btnGuardar.Enabled = False
        Me.btnModificar.Enabled = False
    End Sub

    Private Sub habilitarObjetos()
        Me.txtCategoria.Enabled = True
        Me.btnBorrar.Enabled = True
        Me.btnGuardar.Enabled = True
        Me.btnModificar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        sqlCon = New SqlConnection(conn)
        Dim sqlComm As New SqlCommand()
        'se hace la referencia a la conexión, OJO ver código del Módulo 1
        sqlComm.Connection = sqlCon

        If tipoOper = 1 Then 'Insercion
            Using (sqlCon)
                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spInsertarCategoria"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodCategoria", CInt(txtCodCategoria.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtCategoria.Text)
                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
            End Using
        Else
            Using (sqlCon)
                'se indica el nombre del stored procedure y el tipo
                sqlComm.CommandText = "spModificarCategoria"
                sqlComm.CommandType = CommandType.StoredProcedure
                'se pasan los parámetros al store procedure
                sqlComm.Parameters.AddWithValue("@CodCategoria", CInt(txtCodCategoria.Text))
                sqlComm.Parameters.AddWithValue("@Nombre", txtCategoria.Text)
                sqlCon.Open()
                'se ejecuta el el stored procedure en el servidor de bases de datos
                sqlComm.ExecuteNonQuery()
            End Using
        End If

    End Sub



    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tipoOper = 2
        habilitarObjetos()
        Me.btnModificar.Enabled = False
        Me.btnGuardar.Enabled = True
        'Me.txtCategoria.set
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        frmListaCategorias.Show()
    End Sub

    Private Sub cbxCategorias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCategorias.SelectedIndexChanged

    End Sub
End Class