Public Class frmInfoProveedor

    Private Sub frmInfoProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()


        'Desabilita la edicion de los textbox
        Me.TxtCodProvedor.Enabled = False
        Me.txtNombre.Enabled = False
        Me.txtTelefono.Enabled = False
        Me.txtCorreo.Enabled = False
        Me.txtDireccion.Enabled = False



        Try
            'Desabilita la edicion de los textbox
            Me.TxtCodProvedor.Enabled = False
            Me.txtNombre.Enabled = False
            Me.txtTelefono.Enabled = False
            Me.txtCorreo.Enabled = False
            Me.txtDireccion.Enabled = False
        Catch ex As Exception

        End Try
        'Rellena los textbox con la informacion consultada
        TxtCodProvedor.Text = frmConsultasProveedor.dvgProvedores.SelectedRows.Item(0).Cells(0).Value
        txtNombre.Text = frmConsultasProveedor.dvgProvedores.SelectedRows.Item(0).Cells(1).Value
        txtTelefono.Text = frmConsultasProveedor.dvgProvedores.SelectedRows.Item(0).Cells(2).Value
        txtCorreo.Text = frmConsultasProveedor.dvgProvedores.SelectedRows.Item(0).Cells(3).Value
        txtDireccion.Text = frmConsultasProveedor.dvgProvedores.SelectedRows.Item(0).Cells(4).Value

    End Sub



    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class