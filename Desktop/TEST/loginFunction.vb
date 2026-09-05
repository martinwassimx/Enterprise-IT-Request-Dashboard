Imports Newtonsoft.Json.Linq
Imports RestSharp

Module loginFunction
    Public userid As String
    Public password As String
    Public Function loginFu()
        Dim client = New RestClient(conn & "/token")
        client.Timeout = -1
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Content-Type", "text/plain")
        request.AddHeader("Cookie", ".AspNet.Cookies=CjhUvqt26uRFa0g3zneM9QTmtKe3c8DZ1Ne7RbmcPTgcTZxoaJIta7fb8jH3V4SCeZeL1KQWCT1SPtLh9EOaQHUEtBOScy4aj1LUQFpxu2qxejNdo12ZtloMkajyv_04i9FnOkkVrwDwMTNXdIpdUh-EztWMZTUno20E0-nVyr3uxob9pWbIvvQ5TE2xAAidoiVIoH57BW1NDkL5d_yhod4Z74-a5VW7pEpVigWOTOXs49zLoEclsGqEWCZQfCn5hTcrlayRZzZGmzz8ZYXfu6h_NemTEYjlXfNNexOy-2trzWghIzrvyVMno8VxaH0ceLt9-Zywnr7n7rrg6B3lVW1jtES8ymhvxDG6XWkZR4Gm4VXnBoU-zQAtSl5ZVfXQ5cIRRhiRrRB14dmvv9m1NPTNNw6q1qTcpva1GDw8t6T5B5mj0wBpAAvrk89MWBn0naQdHTyyGwQHSrWBTx38PO9BoktEviOlHEATXiyJ3rg")
        Dim body = "username=" & userid & "&password=" & password & "&grant_type=password"
        request.AddParameter("text/plain", body, ParameterType.RequestBody)
        Dim response As IRestResponse = client.Execute(request)
        Try
            Dim rawresp As String = response.Content
            Dim json As JObject = JObject.Parse(rawresp)
            access_token = (json.Item("access_token"))
            expires_in = (json.Item("expires_in"))
            token_type = (json.Item("token_type"))
            scope = (json.Item("scope"))
        Catch ex As Exception
        End Try
        Return access_token
    End Function
    Public Function logout()

        Dim client = New RestClient(conn & "/api/Account/Logout")
        client.Timeout = -1
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Content-Type", "text/plain")
        request.AddHeader("Cookie", ".AspNet.Cookies=CjhUvqt26uRFa0g3zneM9QTmtKe3c8DZ1Ne7RbmcPTgcTZxoaJIta7fb8jH3V4SCeZeL1KQWCT1SPtLh9EOaQHUEtBOScy4aj1LUQFpxu2qxejNdo12ZtloMkajyv_04i9FnOkkVrwDwMTNXdIpdUh-EztWMZTUno20E0-nVyr3uxob9pWbIvvQ5TE2xAAidoiVIoH57BW1NDkL5d_yhod4Z74-a5VW7pEpVigWOTOXs49zLoEclsGqEWCZQfCn5hTcrlayRZzZGmzz8ZYXfu6h_NemTEYjlXfNNexOy-2trzWghIzrvyVMno8VxaH0ceLt9-Zywnr7n7rrg6B3lVW1jtES8ymhvxDG6XWkZR4Gm4VXnBoU-zQAtSl5ZVfXQ5cIRRhiRrRB14dmvv9m1NPTNNw6q1qTcpva1GDw8t6T5B5mj0wBpAAvrk89MWBn0naQdHTyyGwQHSrWBTx38PO9BoktEviOlHEATXiyJ3rg")
        Dim response As IRestResponse = client.Execute(request)
        Try

            access_token = ""
            expires_in = ""
            token_type = ""
            scope = ""
        Catch ex As Exception


        End Try

        Return access_token
    End Function
End Module
