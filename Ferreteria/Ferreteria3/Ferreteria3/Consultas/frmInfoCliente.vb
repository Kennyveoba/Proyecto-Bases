Public Class frmInfoCliente
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmInfoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        'Desabilita la edicion de los textbox
        Me.TxtCodProvedor.Enabled = False
        Me.txtNombre.Enabled = False
        Me.txtTelefono.Enabled = False
        Me.txtCorreo.Enabled = False
        Me.txtDireccion.Enabled = False

        'Rellena los textbox con la informacion consultada
        TxtCodProvedor.Text = frmConsultaCliente.DataGridView1.SelectedRows.Item(0).Cells(0).Value
        txtNombre.Text = frmConsultaCliente.DataGridView1.SelectedRows.Item(0).Cells(1).Value
        txtTelefono.Text = frmConsultaCliente.DataGridView1.SelectedRows.Item(0).Cells(2).Value
        txtCorreo.Text = frmConsultaCliente.DataGridView1.SelectedRows.Item(0).Cells(3).Value
        txtDireccion.Text = frmConsultaCliente.DataGridView1.SelectedRows.Item(0).Cells(4).Value

    End Sub
End Class