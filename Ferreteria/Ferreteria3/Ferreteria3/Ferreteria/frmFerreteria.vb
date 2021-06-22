Public Class frmFerreteria
    Private Sub CategoríasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoríasToolStripMenuItem.Click
        frmCategorias.ShowDialog()
    End Sub

    Private Sub frmFerreteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        frmProductos.ShowDialog()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaciónToolStripMenuItem.Click
        frmFacturacion.ShowDialog()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        frmAcercaDe.ShowDialog()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        frmClientes.ShowDialog()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        frmProveedores.ShowDialog()
    End Sub

    Private Sub ProveedoresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem1.Click
        frmConsultasProveedor.ShowDialog()
    End Sub

    Private Sub UnidadesDeMedidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnidadesDeMedidaToolStripMenuItem.Click
        frmUnidadMedida.ShowDialog()
    End Sub

    Private Sub ProductosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem1.Click
        frmConsultaProducto.ShowDialog()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub InventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarioToolStripMenuItem.Click
        frmInventario.ShowDialog()
    End Sub

    Private Sub SucursalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SucursalToolStripMenuItem.Click
        frmSucursal.ShowDialog()
    End Sub

    Private Sub PuestosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PuestosToolStripMenuItem.Click
        frmCargos.ShowDialog()
    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpleadosToolStripMenuItem.Click
        frmEmpleados.ShowDialog()
    End Sub
End Class
