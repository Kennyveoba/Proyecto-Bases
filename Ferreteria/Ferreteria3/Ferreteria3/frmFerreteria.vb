Public Class frmFerreteria
    Private Sub CategoríasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoríasToolStripMenuItem.Click
        frmCategorias.Show()
    End Sub

    Private Sub frmFerreteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        frmProductos.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaciónToolStripMenuItem.Click
        frmFacturacion.Show()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        frmAcercaDe.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        frmClientes.Show()
    End Sub
End Class
