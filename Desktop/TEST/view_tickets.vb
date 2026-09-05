Imports RestSharp
Imports Newtonsoft.Json
Imports MaterialSkin
Imports MaterialSkin.Controls

Public Class view_tickets
    Private allTickets As New List(Of TicketSummaryDTO)

    Public Class TicketSummaryDTO
        Public Property Req_No As String
        Public Property Req_Type As String
        Public Property Site As String
        Public Property Requester_Option As String
        Public Property User_Name As String
        Public Property Manager As String
        Public Property TotalItems As Integer
        Public Property DetailsList As List(Of RequestDetailDTO)
    End Class

    Public Class RequestDetailDTO
        Public Property Req_No As String
        Public Property Req As String
        Public Property Details As String
        Public Property [Private] As Boolean
        Public Property Other As String
        Public Property Remarks As String
        Public Property Status As String
    End Class

    Private Sub view_tickets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim skinManager As MaterialSkinManager = MaterialSkinManager.Instance
        skinManager.AddFormToManage(Me)
        skinManager.Theme = MaterialSkinManager.Themes.LIGHT
        skinManager.ColorScheme = New ColorScheme(
            Primary.Blue800,
            Primary.Blue900,
            Primary.Blue500,
            Accent.Red400,
            TextShade.WHITE
        )

        FormatGrid(dgvHeaders)
        FormatGrid(dgvDetails)

        cmbFilterType.Items.Clear()
        cmbFilterType.Items.AddRange(New Object() {"All Types", "IT Request", "Mobile Line Request"})
        cmbFilterType.SelectedIndex = 0

        LoadAllTickets()
    End Sub

    Private Sub FormatGrid(dgv As DataGridView)
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#002F9E")
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
        dgv.ColumnHeadersHeight = 35

        dgv.DefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
        dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE")
        dgv.DefaultCellStyle.SelectionForeColor = Color.Black
        dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8FAFC")
        dgv.RowTemplate.Height = 30
    End Sub

    Private Sub dgvDetails_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDetails.CellFormatting
        If dgvDetails.Columns(e.ColumnIndex).Name = "Status" AndAlso e.Value IsNot Nothing Then
            Dim status As String = e.Value.ToString()
            If status.Equals("Pending", StringComparison.OrdinalIgnoreCase) Then
                e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6)
                e.CellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            ElseIf status.Equals("In Progress", StringComparison.OrdinalIgnoreCase) Then
                e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235)
                e.CellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            ElseIf status.Equals("Closed", StringComparison.OrdinalIgnoreCase) OrElse status.Equals("Completed", StringComparison.OrdinalIgnoreCase) Then
                e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                e.CellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            End If
        End If
    End Sub

    Private Sub LoadAllTickets(Optional targetReqNo As String = "", Optional targetCategory As String = "")
        Try
            Dim client As New RestClient(conn & "/api/Ticket/GetAllTickets/")
            client.Timeout = -1
            Dim request As New RestRequest(Method.GET)
            request.AddHeader("Authorization", "Bearer " & access_token)

            Dim response As IRestResponse = client.Execute(request)
            If response.IsSuccessful AndAlso Not String.IsNullOrEmpty(response.Content) Then
                allTickets = JsonConvert.DeserializeObject(Of List(Of TicketSummaryDTO))(response.Content)
                ApplyFilter(targetReqNo, targetCategory)
            Else
                MessageBox.Show("Could not fetch tickets: " & response.Content, "API Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading tickets: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyFilter(Optional targetReqNo As String = "", Optional targetCategory As String = "")
        If allTickets Is Nothing Then Return

        Dim searchTxt As String = txtSearch.Text.Trim().ToLower()
        Dim selectedType As String = If(cmbFilterType.SelectedItem IsNot Nothing, cmbFilterType.SelectedItem.ToString(), "All Types")

        Dim filtered = allTickets.Where(Function(t)
                                            Dim matchesType As Boolean = (selectedType = "All Types" OrElse (t.Req_Type IsNot Nothing AndAlso t.Req_Type.Equals(selectedType, StringComparison.OrdinalIgnoreCase)))
                                            Dim matchesSearch As Boolean = String.IsNullOrEmpty(searchTxt) OrElse
                                                                          (t.Req_No IsNot Nothing AndAlso t.Req_No.ToLower().Contains(searchTxt)) OrElse
                                                                          (t.User_Name IsNot Nothing AndAlso t.User_Name.ToLower().Contains(searchTxt)) OrElse
                                                                          (t.Manager IsNot Nothing AndAlso t.Manager.ToLower().Contains(searchTxt)) OrElse
                                                                          (t.Site IsNot Nothing AndAlso t.Site.ToLower().Contains(searchTxt))
                                            Return matchesType AndAlso matchesSearch
                                        End Function).Select(Function(t) New With {
                                            .Req_No = t.Req_No,
                                            .Req_Type = t.Req_Type,
                                            .Site = t.Site,
                                            .Requester = t.User_Name,
                                            .Manager = t.Manager,
                                            .Total_Items = t.TotalItems
                                        }).ToList()

        dgvHeaders.DataSource = filtered

        If dgvHeaders.Rows.Count > 0 Then
            Dim matchedRow As DataGridViewRow = Nothing

            ' If a target ticket was specified, re-select it
            If Not String.IsNullOrEmpty(targetReqNo) Then
                For Each row As DataGridViewRow In dgvHeaders.Rows
                    If Convert.ToString(row.Cells("Req_No").Value) = targetReqNo Then
                        matchedRow = row
                        Exit For
                    End If
                Next
            End If

            If matchedRow IsNot Nothing Then
                matchedRow.Selected = True
            Else
                dgvHeaders.Rows(0).Selected = True
            End If

            DisplaySelectedTicketDetails(targetCategory)
        Else
            dgvDetails.DataSource = Nothing
        End If
    End Sub

    Private Sub DisplaySelectedTicketDetails(Optional targetCategory As String = "")
        If dgvHeaders.SelectedRows.Count = 0 Then
            dgvDetails.DataSource = Nothing
            Return
        End If

        Dim selectedReqNo As String = Convert.ToString(dgvHeaders.SelectedRows(0).Cells("Req_No").Value)
        Dim ticket = allTickets.FirstOrDefault(Function(t) t.Req_No = selectedReqNo)

        If ticket IsNot Nothing AndAlso ticket.DetailsList IsNot Nothing Then
            Dim detailsTable = ticket.DetailsList.Select(Function(d) New With {
                .Category = d.Req,
                .Details = d.Details,
                .Private = If(d.Private, "Yes", "No"),
                .Other = d.Other,
                .Remarks = d.Remarks,
                .Status = d.Status
            }).ToList()

            dgvDetails.DataSource = detailsTable

            If dgvDetails.Rows.Count > 0 Then
                Dim matchedDetailRow As DataGridViewRow = Nothing

                If Not String.IsNullOrEmpty(targetCategory) Then
                    For Each dRow As DataGridViewRow In dgvDetails.Rows
                        If Convert.ToString(dRow.Cells("Category").Value) = targetCategory Then
                            matchedDetailRow = dRow
                            Exit For
                        End If
                    Next
                End If

                If matchedDetailRow IsNot Nothing Then
                    matchedDetailRow.Selected = True
                Else
                    dgvDetails.Rows(0).Selected = True
                End If
            End If
        Else
            dgvDetails.DataSource = Nothing
        End If
    End Sub

    Private Sub dgvHeaders_SelectionChanged(sender As Object, e As EventArgs) Handles dgvHeaders.SelectionChanged
        DisplaySelectedTicketDetails()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub cmbFilterType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterType.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim curReq As String = ""
        If dgvHeaders.SelectedRows.Count > 0 Then
            curReq = Convert.ToString(dgvHeaders.SelectedRows(0).Cells("Req_No").Value)
        End If
        LoadAllTickets(curReq)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnInProgress_Click(sender As Object, e As EventArgs) Handles btnInProgress.Click
        UpdateSelectedStatus("In Progress")
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        UpdateSelectedStatus("Completed")
    End Sub

    Private Sub UpdateSelectedStatus(newStatus As String)
        If dgvHeaders.SelectedRows.Count = 0 OrElse dgvDetails.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item from the bottom table first.", "Selection Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim reqNo As String = Convert.ToString(dgvHeaders.SelectedRows(0).Cells("Req_No").Value)
        Dim reqCat As String = Convert.ToString(dgvDetails.SelectedRows(0).Cells("Category").Value)

        Try
            Dim client As New RestClient(conn & String.Format("/api/Ticket/UpdateStatus/?reqNo={0}&req={1}&newStatus={2}", reqNo, reqCat, newStatus))
            client.Timeout = -1
            Dim request As New RestRequest(Method.POST)
            request.AddHeader("Authorization", "Bearer " & access_token)

            Dim response As IRestResponse = client.Execute(request)
            If response.IsSuccessful Then
                MessageBox.Show("Item status updated to '" & newStatus & "'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Reload and retain the current selected ticket & row item
                LoadAllTickets(reqNo, reqCat)
            Else
                MessageBox.Show("Failed to update status: " & response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Status Update Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeleteTicket_Click(sender As Object, e As EventArgs) Handles btnDeleteTicket.Click
        If dgvHeaders.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a ticket to delete.", "Selection Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim reqNo As String = Convert.ToString(dgvHeaders.SelectedRows(0).Cells("Req_No").Value)
        Dim ask = MessageBox.Show("Are you sure you want to delete Ticket (" & reqNo & ") permanently?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If ask = DialogResult.Yes Then
            Try
                Dim client As New RestClient(conn & "/api/Ticket/DeleteTicket/?reqNo=" & reqNo)
                client.Timeout = -1
                Dim request As New RestRequest(Method.POST)
                request.AddHeader("Authorization", "Bearer " & access_token)

                Dim response As IRestResponse = client.Execute(request)
                If response.IsSuccessful Then
                    MessageBox.Show("Ticket " & reqNo & " deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadAllTickets()
                Else
                    MessageBox.Show("Could not delete ticket: " & response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show("Delete Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class