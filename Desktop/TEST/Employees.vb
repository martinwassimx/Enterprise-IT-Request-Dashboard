Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports RestSharp
Imports System.Net

Public Class Employees

    Private currentEID As Integer = 0


    Private Sub Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtStatus.ReadOnly = True
        txtStatus.BackColor = SystemColors.Control
        LoadLatestSerial()
    End Sub


    Private Sub LoadLatestSerial()
        Try
            Dim client As New RestClient(conn & "/api/Employee/GetLatestSerial/")
            Dim request As New RestRequest(Method.GET)
            request.AddHeader("Authorization", "Bearer " & access_token)
            request.AddHeader("Accept", "application/json")

            Dim response As IRestResponse = client.Execute(request)

            If response.StatusCode = HttpStatusCode.OK Then
                Dim json As JObject = JObject.Parse(response.Content)
                Dim lastSerial As String = If(json("LastSerial") IsNot Nothing, json("LastSerial").ToString(), "None")
                Dim nextSerial As String = If(json("NextSerial") IsNot Nothing, json("NextSerial").ToString(), "N001")

                lblSerialInfo.Text = "Last Serial: " & lastSerial & "   |   Next Serial: " & nextSerial
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrWhiteSpace(txtSearchID.Text) Then
            MsgBox("Please enter a National ID to search.")
            Exit Sub
        End If

        Try
            Dim client As New RestClient(conn & "/api/Employee/GetByNationalID?NationalID=" & txtSearchID.Text.Trim())
            Dim request As New RestRequest(Method.GET)

            request.AddHeader("Authorization", "Bearer " & access_token)
            request.AddHeader("Accept", "application/json")

            Dim response As IRestResponse = client.Execute(request)

            If response.StatusCode = HttpStatusCode.OK Then
                Dim json As JObject = JObject.Parse(response.Content)

                currentEID = 0
                If json("EID") IsNot Nothing Then
                    Integer.TryParse(json("EID").ToString(), currentEID)
                End If

                txtFirstName.Text = If(json("FirstName") IsNot Nothing, json("FirstName").ToString(), "")
                txtSecoendName.Text = If(json("SecoendName") IsNot Nothing, json("SecoendName").ToString(), "")
                txtNationalID.Text = If(json("NationalID") IsNot Nothing, json("NationalID").ToString(), "")
                txtPhone.Text = If(json("PhoneNumber") IsNot Nothing, json("PhoneNumber").ToString(), "")
                txtAddress.Text = If(json("Address") IsNot Nothing, json("Address").ToString(), "")
                txtTitle.Text = If(json("Title") IsNot Nothing, json("Title").ToString(), "")
                txtStatus.Text = If(json("Serial") IsNot Nothing, json("Serial").ToString(), "")
                txtMail.Text = If(json("Mail") IsNot Nothing, json("Mail").ToString(), "")

                Dim bDate As DateTime
                If json("BirthDate") IsNot Nothing AndAlso DateTime.TryParse(json("BirthDate").ToString(), bDate) Then
                    dtpBirthDate.Value = bDate
                End If

                ' Lock search box
                txtSearchID.ReadOnly = True
                btnSearch.Enabled = False

            ElseIf response.StatusCode = HttpStatusCode.NotFound Then
                MsgBox("الموظف غير موجود")
                ClearInputs()
            ElseIf response.StatusCode = HttpStatusCode.Unauthorized Then
                MsgBox("Session expired. Please login again.")
            Else
                MsgBox("Error: " & response.StatusDescription & " (" & response.StatusCode.ToString() & ")")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ClearInputs()
        LoadLatestSerial()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInputs() Then Exit Sub

        Try
            Dim emp As New EmpData With {
                .FirstName = txtFirstName.Text.Trim(),
                .SecoendName = txtSecoendName.Text.Trim(),
                .BirthDate = dtpBirthDate.Value,
                .NationalID = Convert.ToInt32(txtNationalID.Text.Trim()),
                .PhoneNumber = txtPhone.Text.Trim(),
                .Address = txtAddress.Text.Trim(),
                .Title = txtTitle.Text.Trim(),
                .Mail = txtMail.Text.Trim()
            }

            Dim empList As New List(Of EmpData) From {emp}

            Dim client As New RestClient(conn & "/api/Employee/SaveEmp/")
            Dim request As New RestRequest(Method.POST)
            request.AddHeader("Authorization", "Bearer " & access_token)
            request.AddHeader("Content-Type", "application/json")
            request.AddParameter("application/json", JsonConvert.SerializeObject(empList), ParameterType.RequestBody)

            Dim response As IRestResponse = client.Execute(request)

            If response.StatusCode = HttpStatusCode.OK Then
                MsgBox("تم الحفظ بنجاح")
                ClearInputs()
                LoadLatestSerial()
            Else
                MsgBox("Failed to save: " & response.StatusDescription & " (" & response.StatusCode.ToString() & ")")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If currentEID = 0 Then
            MsgBox("Please search and load an employee first before updating.")
            Exit Sub
        End If

        If Not ValidateInputs() Then Exit Sub

        Try
            Dim emp As New EmpData With {
                .EID = currentEID,
                .FirstName = txtFirstName.Text.Trim(),
                .SecoendName = txtSecoendName.Text.Trim(),
                .BirthDate = dtpBirthDate.Value,
                .NationalID = Convert.ToInt32(txtNationalID.Text.Trim()),
                .PhoneNumber = txtPhone.Text.Trim(),
                .Address = txtAddress.Text.Trim(),
                .Title = txtTitle.Text.Trim(),
                .Mail = txtMail.Text.Trim()
            }

            Dim empList As New List(Of EmpData) From {emp}

            Dim client As New RestClient(conn & "/api/Employee/UpdateEmp/")
            Dim request As New RestRequest(Method.POST)
            request.AddHeader("Authorization", "Bearer " & access_token)
            request.AddHeader("Content-Type", "application/json")
            request.AddParameter("application/json", JsonConvert.SerializeObject(empList), ParameterType.RequestBody)

            Dim response As IRestResponse = client.Execute(request)

            If response.StatusCode = HttpStatusCode.OK Then
                MsgBox("تم التعديل بنجاح")
                ClearInputs()
                LoadLatestSerial()
            Else
                MsgBox("Failed to update: " & response.StatusDescription & " (" & response.StatusCode.ToString() & ")")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If currentEID = 0 Then
            MsgBox("Please search and load an employee first before deleting.")
            Exit Sub
        End If

        Dim confirm = MsgBox("Are you sure you want to delete this employee?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
        If confirm <> MsgBoxResult.Yes Then Exit Sub

        Try
            Dim client As New RestClient(conn & "/api/Employee/DeleteEmp/?EID=" & currentEID)
            Dim request As New RestRequest(Method.POST)
            request.AddHeader("Authorization", "Bearer " & access_token)

            Dim response As IRestResponse = client.Execute(request)

            If response.StatusCode = HttpStatusCode.OK Then
                MsgBox("تم الحذف بنجاح")
                ClearInputs()
                LoadLatestSerial()
            Else
                MsgBox("Failed to delete: " & response.StatusDescription & " (" & response.StatusCode.ToString() & ")")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub


    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtNationalID.Text) Then
            MsgBox("Please provide at least the First Name and National ID.")
            Return False
        End If

        Dim parsedID As Integer
        If Not Integer.TryParse(txtNationalID.Text.Trim(), parsedID) Then
            MsgBox("National ID must be numeric.")
            Return False
        End If

        Return True
    End Function

    Private Sub ClearInputs()
        currentEID = 0
        txtSearchID.ReadOnly = False
        btnSearch.Enabled = True
        txtSearchID.Clear()

        txtFirstName.Clear()
        txtSecoendName.Clear()
        txtNationalID.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        txtTitle.Clear()
        txtStatus.Clear()
        txtMail.Clear()
        dtpBirthDate.Value = DateTime.Now

        txtSearchID.Focus()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles lblSerialInfo.Click

    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class

Public Class EmpData
    Public Property EID As Integer
    Public Property FirstName As String
    Public Property SecoendName As String
    Public Property BirthDate As DateTime?
    Public Property NationalID As Integer?
    Public Property PhoneNumber As String
    Public Property Address As String
    Public Property Title As String
    Public Property Serial As String
    Public Property Mail As String
End Class