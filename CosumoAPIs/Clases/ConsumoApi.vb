Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class ConsumoApi
    Public Property JsonRequest As String
    Public Property Response As String

    Public Property Err As Boolean
    'Public Property ErrString As String
    Friend Function Consumir() As String
        Dim request = CType(WebRequest.Create("https://min-api.cryptocompare.com/data/top/mktcapfull?limit=10&tsym=COP"), HttpWebRequest)
        request.Method = "GET"
        request.ContentType = "application/json"
        request.AllowAutoRedirect = False
        Using resp As HttpWebResponse = TryCast(Request.GetResponse(), HttpWebResponse)
            If resp.StatusCode = HttpStatusCode.OK Then
                Using respStream As Stream = resp.GetResponseStream()
                    Dim reader As StreamReader = New StreamReader(respStream, Encoding.UTF8)
                    Me.Response = reader.ReadToEnd()
                End Using
            Else
                Me.Err = True
                Me.Response = resp.StatusCode & ": " & resp.StatusDescription
            End If
        End Using

        Return Response
    End Function

End Class
