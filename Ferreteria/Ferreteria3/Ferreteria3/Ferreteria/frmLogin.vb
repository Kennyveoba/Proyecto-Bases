Public Class frmLogin


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("ERROR: Debe ingresar su usuario", MsgBoxStyle.Information, "Sistema")
            Exit Sub

        End If
        Usuario = TextBox1.Text
        frmFerreteria.ShowDialog()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
End Class