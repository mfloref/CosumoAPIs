Imports System.Web.Services.Description
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data


Public Class MuestaDatos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.vDatos.Visible = False
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs)

        Dim _servicioREST As New ConsumoApi
        Dim _db As New db_class
        Dim _Response As String
        Dim _fullNombre As String
        Dim _Query As String = Nothing

        Dim FullName As String
        Dim PRICE As Double
        Dim HIGHDAY As Double
        Dim LOWDAY As Double
        Dim CHANGEPCT24HOUR As Double

        Dim _CoinInfo As New List(Of CoinInfo)
        Dim _COP As New List(Of COP)

        _Response = _servicioREST.Consumir()
        If Not _servicioREST.Err Then

            Dim jObject = JsonConvert.DeserializeObject(Of JObject)(_Response).Root.SelectToken("Data").ToList()
            Dim count As Integer = jObject.Count
            For Each item In jObject
                _fullNombre = item.SelectToken("CoinInfo").SelectToken("FullName").ToString()
                If (_fullNombre = "Bitcoin") Or (_fullNombre = "Tether") Then

                    FullName = item.SelectToken("CoinInfo").SelectToken("FullName").ToString()
                    PRICE = item.SelectToken("RAW").SelectToken("COP").SelectToken("PRICE")
                    HIGHDAY = item.SelectToken("RAW").SelectToken("COP").SelectToken("HIGHDAY")
                    LOWDAY = item.SelectToken("RAW").SelectToken("COP").SelectToken("LOWDAY")
                    CHANGEPCT24HOUR = item.SelectToken("RAW").SelectToken("COP").SelectToken("CHANGEPCT24HOUR")


                    _Query += "Insert into bitacoraApi (DATETIME, FULLNAME, PRICE, HIGHDAY, LOWDAY, CHANGEPCT24HOUR)"
                    _Query += " values ( SYSDATETIME ( ) ,'" + FullName + "'," + PRICE.ToString() + ", "
                    _Query += HIGHDAY.ToString() + "," + LOWDAY.ToString() + "," + CHANGEPCT24HOUR.ToString() + " )" & vbCrLf

                End If
            Next

            _db.agregar(_Query)
            If _db.Err Then
                mostrarMensaje(_db.ErrString, "error")
            Else
                mostrarMensaje("El proceso termino correctamente", "correcto")
                Me.Mostrartarjetas()
            End If
        Else
            mostrarMensaje(_servicioREST.Response, "error")
        End If
    End Sub

    Protected Sub btnMuestaDatos_Click(sender As Object, e As EventArgs)
        Me.Mostrartarjetas()
    End Sub

    Sub Mostrartarjetas()
        Dim _db As New db_class
        Dim _ds As DataSet
        Dim count As Integer = 1

        _ds = _db.conUltimosRegistros()

        If _db.Err Then
            mostrarMensaje(_db.ErrString, "error")
            Me.vDatos.Visible = False
        Else
            For Each item In _ds.Tables(0).Rows()
                Select Case count
                    Case 1
                        lblTitulo1.Text = _ds.Tables(0).Rows(0).Item(2).ToString()
                        lblFecha1.Text = _ds.Tables(0).Rows(0).Item(1).ToString()
                        lblPRICE1.Text = _ds.Tables(0).Rows(0).Item(3).ToString()
                        lblHIGHDAY1.Text = _ds.Tables(0).Rows(0).Item(4).ToString()
                        lblLOWDAY1.Text = _ds.Tables(0).Rows(0).Item(5).ToString()
                        lblCHANGEPCT24HOUR1.Text = _ds.Tables(0).Rows(0).Item(6).ToString()
                    Case 2
                        lblTitulo2.Text = _ds.Tables(0).Rows(1).Item(2).ToString()
                        lblFecha2.Text = _ds.Tables(0).Rows(1).Item(1).ToString()
                        lblPRICE2.Text = _ds.Tables(0).Rows(1).Item(3).ToString()
                        lblHIGHDAY2.Text = _ds.Tables(0).Rows(1).Item(4).ToString()
                        lblLOWDAY2.Text = _ds.Tables(0).Rows(1).Item(5).ToString()
                        lblCHANGEPCT24HOUR2.Text = _ds.Tables(0).Rows(1).Item(6).ToString()
                    Case 3
                        lblTitulo3.Text = _ds.Tables(0).Rows(2).Item(2).ToString()
                        lblFecha3.Text = _ds.Tables(0).Rows(2).Item(1).ToString()
                        lblPRICE3.Text = _ds.Tables(0).Rows(2).Item(3).ToString()
                        lblHIGHDAY3.Text = _ds.Tables(0).Rows(2).Item(4).ToString()
                        lblLOWDAY3.Text = _ds.Tables(0).Rows(2).Item(5).ToString()
                        lblCHANGEPCT24HOUR3.Text = _ds.Tables(0).Rows(2).Item(6).ToString()
                    Case 4
                        lblTitulo4.Text = _ds.Tables(0).Rows(3).Item(2).ToString()
                        lblFecha4.Text = _ds.Tables(0).Rows(3).Item(1).ToString()
                        lblPRICE4.Text = _ds.Tables(0).Rows(3).Item(3).ToString()
                        lblHIGHDAY4.Text = _ds.Tables(0).Rows(3).Item(4).ToString()
                        lblLOWDAY4.Text = _ds.Tables(0).Rows(3).Item(5).ToString()
                        lblCHANGEPCT24HOUR4.Text = _ds.Tables(0).Rows(3).Item(6).ToString()
                End Select
                Me.vDatos.Visible = True
                count += 1
            Next
        End If


    End Sub

    Private Sub mostrarMensaje(msg As String, status As String)
        Select Case status
            Case "error"
                ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "Swal.fire", "Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: '" + msg + "',
            })", True)
            Case "correcto"
                ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "Swal.fire", "Swal.fire({
                icon: 'success',
                title: 'Correcto...',
                text: '" + msg + "',
            })", True)

        End Select



    End Sub

End Class
