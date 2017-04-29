Imports System.IO, System.Net
Public Class configuration
    Public Const owner As String = "http://93.115.96.225/"
    Public Const site As String = "http://owny.alwaysdata.net/site/"
    Public Const forum As String = "http://owny.alwaysdata.net/forum/"
    Public Shared version As String = "0.1"
    Public Shared news As New List(Of String)
    Public Shared client As New WebClient
    Public Shared listefile_local As New Dictionary(Of String, String)
    Public Shared listefile_web As New Dictionary(Of String, String)
    Public Shared liste_web As String = ""
    Public Shared listefile_cache As New Dictionary(Of String, String)
    Public Shared listefile_tempo As New List(Of String)
End Class
