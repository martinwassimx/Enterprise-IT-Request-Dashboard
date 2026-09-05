Public Class menuFrm
    Private Sub ITToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ITToolStripMenuItem.Click

    End Sub

    Private Sub ISToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISToolStripMenuItem.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim emp As New Employees()
        emp.Show()
    End Sub

    Private Sub menuFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        login.ShowDialog()
    End Sub

    Private Sub TicketToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TicketToolStripMenuItem.Click
        Dim frmTicket As New ticket()
        frmTicket.Show()
    End Sub

    Private Sub ViewTicketsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTicketsToolStripMenuItem.Click
        Dim frmView As New view_tickets()
        frmView.Show()
    End Sub
End Class