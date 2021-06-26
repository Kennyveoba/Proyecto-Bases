Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Digite un usuario", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Exit Sub
        End If
        Usuario = TextBox1.Text

        Me.Close()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
End Class