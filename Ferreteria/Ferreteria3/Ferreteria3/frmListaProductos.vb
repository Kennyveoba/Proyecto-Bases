Imports System.Data
Imports System.Data.SqlClient
Public Class frmListaProductos
    Private Sub frmListaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub


    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Private Sub dgvProductos_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvProductos.CellMouseDoubleClick

    End Sub

    Private Sub dgvProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class