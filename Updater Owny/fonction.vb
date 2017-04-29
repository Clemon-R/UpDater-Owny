Imports System.IO
Imports System.Net
Imports UpDater.configuration
Imports UpDater.crypteur

Public Class fonction
    Public Shared Function AsInternet() As Boolean
        Dim req As Net.HttpWebRequest
        Dim res As Net.HttpWebResponse
        Dim GotInternet As Boolean = False
        Try
            req = CType(Net.HttpWebRequest.Create(owner), Net.HttpWebRequest)
            res = CType(req.GetResponse(), Net.HttpWebResponse)
            req.Abort()
            If res.StatusCode = Net.HttpStatusCode.OK Then
                GotInternet = True
            End If
        Catch weberrt As Net.WebException
            GotInternet = False
        Catch except As Exception
            GotInternet = False
        End Try
        Return GotInternet
    End Function

    Public Shared Sub loadNews()
        Dim client As New WebClient
        Dim news() As String = client.DownloadString(configuration.owner & "news.php").Split(";")
        Dim index As Integer = 1
        configuration.news.Clear()
        For Each value As String In news
            If (value.Length > 180) Then
                value = value.Substring(0, 90) & vbNewLine & value.Substring(90, 87) & "..."
            ElseIf (value.Length > 90) Then
                value = value.Substring(0, 90) & vbNewLine & value.Substring(90)
            End If
            Select Case index
                Case 1
                    UpDater.news1.Text = value
                Case 2
                    UpDater.news2.Text = value
                Case 3
                    UpDater.news3.Text = value
                Case 4
                    UpDater.news4.Text = value
            End Select
            configuration.news.Add(value)
            index += 1
        Next
        Select Case (index - 1)
            Case 5
                UpDater.news_scroll.Maximum = 25

            Case 6
                UpDater.news_scroll.Maximum = 50

            Case 7
                UpDater.news_scroll.Maximum = 75

            Case 8
                UpDater.news_scroll.Maximum = 100

            Case Else
                UpDater.news_scroll.Enabled = False
        End Select
    End Sub

    Public Shared Function getRandom(ByVal a As Integer, ByVal b As Integer) As Integer
        Dim random As New Random(), rndnbr As Integer

        '.Next permet de retourner un nombre aléatoire contenu dans la plage spécifiée entre parenthèses.
        rndnbr = random.Next(a, b)
        Return rndnbr
    End Function

    Public Shared Sub CenterText(ByVal objet As Object, ByVal center As Object)
        Dim taille As Integer = Math.Round(objet.Size.Width / 2)
        Dim size As Integer = Math.Round(center.Size.Width / 2)
        Dim pos As Integer = size - taille
        NewLocation(objet, New Point(pos, objet.Location.Y))
    End Sub

    Public Shared Sub AlignRight(ByVal objet As Object, ByVal center As Object, ByVal px As Integer)
        Dim taille As Integer = objet.Size.Width + px
        Dim size As Integer = center.Size.Width
        Dim pos As Integer = size - taille
        NewLocation(objet, New Point(pos, objet.Location.Y))
    End Sub

    Public Delegate Sub ScanNewLocation(ctrl As Object, point As Point)
    Public Shared Sub NewLocation(ctrl As Object, point As Point)
        If ctrl.InvokeRequired Then
            ctrl.Invoke(New ScanNewLocation(AddressOf NewLocation), New Object() {ctrl, point})
        Else
            ctrl.Location = point
        End If
    End Sub

    Public Delegate Sub ScanNewText(ctrl As Object, text As String)
    Public Shared Sub NewText(ctrl As Object, text As String)
        If ctrl.InvokeRequired Then
            ctrl.Invoke(New ScanNewText(AddressOf NewText), New Object() {ctrl, text})
        Else
            ctrl.Text = text
        End If
    End Sub

    Public Delegate Sub ScanNewWidth(ctrl As Object, text As Integer)
    Public Shared Sub NewWidth(ctrl As Object, text As Integer)
        If ctrl.InvokeRequired Then
            ctrl.Invoke(New ScanNewWidth(AddressOf NewWidth), New Object() {ctrl, text})
        Else
            ctrl.Size = New Size(text, ctrl.Size.Height)
        End If
    End Sub
    Public Shared Sub ListRepertoirLocal(adr As String)
        Dim dir() As String = Directory.GetFiles(adr, "*.*", SearchOption.AllDirectories)
        For Each value As String In dir
            Try
                listefile_local.Add(value.Replace(Application.StartupPath & "\", "").Replace("\", "/"), CrypteFile_md5(value))
            Catch ex As Exception
                Continue For
            End Try
        Next
    End Sub

    Public Shared Sub ListRepertoirLocalName(adr As String)
        Dim dir() As String = Directory.GetFiles(adr, "*.*", SearchOption.AllDirectories)
        For Each value As String In dir
            Try
                listefile_tempo.Add(value.Replace(Application.StartupPath & "\", "").Replace("\", "/"))
            Catch ex As Exception
                Continue For
            End Try
        Next
    End Sub

    Public Shared Sub ListCache()
        For Each value As String In File.ReadAllText("cache.upd").Split(";")
            Try
                Dim infos() As String = value.Split(">")
                listefile_cache.Add(infos(0), infos(1))
            Catch ex As Exception
                Continue For
            End Try
        Next
    End Sub

    Public Shared Sub ListRepertoirWeb(adr As String)
        adr = adr.Replace(configuration.owner & "client/", "")
        liste_web = adr
        For Each value As String In adr.Split(";")
            Dim infos() As String = value.Split(">")
            If (infos.Length < 2) Then
                Continue For
            End If
            listefile_web.Add(infos(0), infos(1))
        Next
    End Sub

    'Private Sub CloseMe()
    '    If Me.InvokeRequired Then
    '        Me.Invoke(New MethodInvoker(AddressOf CloseMe))
    '        Exit Sub
    '    End If
    '    Me.Close()
    'End Sub

    'Public Shadows Sub Close(ByVal form As Form)
    '    If form.InvokeRequired Then
    '        form.Invoke(New setLabelTxtInvoker(AddressOf setLabelTxt), text, lbl)
    '    Else
    '        lbl.Text = text
    '    End If
    'End Sub
    'Private Delegate Sub setLabelTxtInvoker(ByVal text As String, ByVal lbl As Label)
End Class
