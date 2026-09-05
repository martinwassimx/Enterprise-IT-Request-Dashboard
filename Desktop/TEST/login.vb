Imports RestSharp
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class login
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = "https://localhost:44372"
        Me.AcceptButton = btnLogin
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        menuFrm.UserName.Text = txtUsername.Text
        userid = txtUsername.Text
        password = txtPassword.Text
        loginFu()
        If access_token = "" Then
            MsgBox("Invalid Username & Password")
            Exit Sub
        End If
        Close()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown, txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class