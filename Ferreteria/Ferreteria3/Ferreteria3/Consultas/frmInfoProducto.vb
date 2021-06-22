Public Class frmInfoProducto
    Private Sub frmInfoProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        'Desabilita la edicion de los textbox
        Me.TxtCodProducto.Enabled = False
        Me.txtNombre.Enabled = False
        Me.txtProveedor.Enabled = False
        Me.txtCategoria.Enabled = False
        Me.txtUnidadMedida.Enabled = False
        Me.txtDescripcion.Enabled = False
        Me.txtPrecioCompra.Enabled = False
        Me.txtPrecioVenta.Enabled = False

        'Rellena los textbox con la informacion consultada
        TxtCodProducto.Text = frmConsultaProducto.DataGridView1.SelectedRows.Item(0).Cells(0).Value
        txtNombre.Text = frmConsultaProducto.DataGridView1.SelectedRows.Item(0).Cells(1).Value
        txtProveedor.Text = frmConsultaProducto.DataGridView1.SelectedRows.Item(0).Cells(4).Value

        txtCategoria.Text = frmConsultaProducto.DataGridView1.SelectedRows.Item(0).Cells(3).Value

        txtUnidadMedida.Text = frmConsultaProducto.DataGridView1.SelectedRows.Item(0).Cells(5).Value
        txtDescripcion.Text = frmConsultaProducto.DataGridView1.SelectedRows.Item(0).Cells(2).Value
        txtPrecioCompra.Text = frmConsultaProducto.DataGridView1.SelectedRows.Item(0).Cells(6).Value
        txtPrecioVenta.Text = frmConsultaProducto.DataGridView1.SelectedRows.Item(0).Cells(7).Value
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class