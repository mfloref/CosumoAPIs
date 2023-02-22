Imports System.Data.SqlClient
Imports System.Configuration.SettingAttribute
Imports CosumoAPIs.My
Imports System.EnterpriseServices.Internal

Public Class db_class
    Public Property CadenaConexion As String = ConfigurationManager.AppSettings("SQLConexion")
    Public Property Err As Boolean
    Public Property ErrString As String
    Public Property Comm As System.Data.SqlClient.SqlCommand
    Public Property Conn As New System.Data.SqlClient.SqlConnection
    Public Sub agregar(ByRef consulta As String)
        Dim dr As System.Data.SqlClient.SqlDataReader
        Try
            Conn = New System.Data.SqlClient.SqlConnection(CadenaConexion)
            Conn.Open()
            Comm = New System.Data.SqlClient.SqlCommand()
            Comm.Connection = Conn
            Comm.CommandText = consulta
            Comm.CommandTimeout = 0
            dr = Comm.ExecuteReader()
        Catch ex As Exception
            Err = True
            ErrString = ex.Message
        Finally
            Conn.Close()
            Conn.Dispose()
        End Try
    End Sub

    Public Function conUltimosRegistros() As DataSet
        Dim ds As New DataSet()
        Dim consulta As String = "select top(4)* from bitacoraApi order by Datetime desc"
        Try
            Conn = New SqlConnection(CadenaConexion)
            Conn.Open()
            Dim adaptador As New SqlDataAdapter(consulta, Conn)
            adaptador.SelectCommand.CommandTimeout = 0
            adaptador.Fill(ds)
        Catch ex As Exception
            Err = True
            ErrString = ex.Message
        Finally
            Conn.Close()
            Conn.Dispose()
        End Try

        Return ds


    End Function

End Class
