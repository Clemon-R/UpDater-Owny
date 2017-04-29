Imports UpDater.configuration, System.IO, UpDater.fonction, System.Collections.Generic, System.Threading, System.Windows.Forms.MenuItem, System.Windows.Forms.ContextMenu
Imports System.Net

Public Class UpDater

#Region "Fonction"
    Dim mouse_offset

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        mouse_offset = New Point(-e.X, -e.Y)
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouse_offset.X, mouse_offset.Y)
            Location = mousePos
        End If
    End Sub

    Private thread As Thread
    Private total As Integer = 0
    Private encour As Integer = 0
    Private compteur As Integer = 10
    Private old_dl As Double = 0
    Private old_tp As Double = 0
    Private vitesse As Double = 1
    Private temps As Double = 0
    Private maj_encour As Boolean = True
    Private maj_chemin As String = ""
    Private maj_old As String = ""
    Private infos_survol As Boolean = False
    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Try
            Dim encour As Integer = Format((e.BytesReceived / 1024) / 1024, "###,###,##0.00")
            Dim total As Integer = Format((e.TotalBytesToReceive / 1024) / 1024, "###,###,##0.00")
            Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
            Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
            Dim percentage As Double = bytesIn / totalBytes * 100
            NewWidth(pb1, (689 / 100) * e.ProgressPercentage)
            If (compteur >= 10) Then
                Dim old_vitesse As Double = vitesse
                If (old_dl = 0) Then
                    old_dl = Format(e.BytesReceived, "###,###,##0")
                    vitesse = old_dl
                Else
                    Dim mtn_dl As Double = Format(e.BytesReceived, "###,###,##0")
                    vitesse = Format((mtn_dl - old_dl) / 1024, "###,###,##0")
                    old_dl = mtn_dl
                End If
                If (vitesse <= 1) Then
                    vitesse = old_vitesse
                End If
                old_tp = ((totalBytes / 1024) - (bytesIn / 1024)) / vitesse
                Dim minute As Integer = 0
                While old_tp >= 60
                    old_tp -= 60
                    minute += 1
                End While
                old_tp = Format(old_tp, "###,###,##0")
                If (old_tp < 0) Then
                    old_tp = 0
                End If
                temps = minute & "," & old_tp
                compteur = 0
            End If
            compteur += 1
            NewText(stats2, encour & "/" & total & "MO " & vitesse & "KO/s " & temps.ToString.Replace(",", "m"))
            AlignRight(stats2, Me, 3)
        Catch z As Exception
        End Try
    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        encour += 1
        NewText(stats, "Fichier : " & encour & "/" & total)
        If (infos_survol = False) Then
            NewText(infos, "Mise à jour en cours : " & Format((100 / total) * encour, "###,###,##0") & "%")
            CenterText(infos, Me)
        End If
        notif.Text = "Mise à jour en cours : " & Format((100 / total) * encour, "###,###,##0") & "%"
        NewWidth(pb2, (689 / 100) * ((100 / total) * encour))
    End Sub

    Private Sub maj_DoWork() Handles maj.DoWork
        Try
            NewText(infos, "Vérification des fichiers...")
            CenterText(infos, Me)
            If (File.Exists("cache.upd")) Then
                Dim LaDate As Date = IO.File.GetLastWriteTime("cache.upd")
                If ((LaDate.Day - Now.Day) >= 7 Or (LaDate.Month - Now.Month) >= 1 Or (LaDate.Year - Now.Year) >= 1) Then
                    File.Delete("cache.upd")
                End If
            End If
            ListRepertoirWeb(client.DownloadString(configuration.owner & "fichier.php"))
            If (File.Exists("cache.upd")) Then
                ListCache()
                ListRepertoirLocalName(Application.StartupPath)
                Dim infos As New Dictionary(Of String, String)
                For Each value As KeyValuePair(Of String, String) In listefile_cache
                    If (listefile_tempo.Contains(value.Key)) Then
                        infos.Add(value.Key, value.Value)
                    End If
                Next
                listefile_local = infos
            Else
                ListRepertoirLocal(Application.StartupPath)
            End If
            Dim download As New Dictionary(Of String, String)
            Dim delete As New List(Of String)
            For Each value As KeyValuePair(Of String, String) In listefile_web
                Try
                    If (listefile_local.ContainsKey(value.Key)) Then
                        If (Not listefile_local(value.Key).Equals(value.Value)) Then
                            download.Add(configuration.owner & "client/" & value.Key, value.Key.Replace("/", "\"))
                        End If
                    Else
                        download.Add(configuration.owner & "client/" & value.Key, value.Key.Replace("/", "\"))
                    End If
                Catch z As Exception
                    Continue For
                End Try
            Next
            If (download.Count > 0) Then
                maj_encour = True
                total = delete.Count + download.Count
                If (Me.WindowState = FormWindowState.Minimized) Then
                    notif.BalloonTipText = "Mise à jour en cours..."
                    notif.ShowBalloonTip(5000)
                End If
                If (infos_survol = False) Then
                    NewText(infos, "Mise à jour en cours : " & Format((100 / total) * encour, "###,###,##0") & "%")
                    CenterText(infos, Me)
                End If
                notif.Text = "Mise à jour en cours : " & Format((100 / total) * encour, "###,###,##0") & "%"
                NewText(stats, "Fichier : " & encour & "/" & total)
            End If
            Dim client2 As New WebClient
            AddHandler client2.DownloadProgressChanged, AddressOf client_ProgressChanged
            AddHandler client2.DownloadFileCompleted, AddressOf client_DownloadCompleted
            For Each value As KeyValuePair(Of String, String) In download
                maj_chemin = value.Value
                Dim dir() As String = value.Value.Split("\")
                If maj_chemin.Contains("\") And Not Directory.Exists(maj_chemin.Replace(dir(dir.Length - 1), "")) Then
                    Directory.CreateDirectory(maj_chemin.Replace(dir(dir.Length - 1), ""))
                End If
                If File.Exists(value.Value) Then
                    Try
                        File.Delete(value.Value)
                    Catch ex As Exception
                    End Try
                End If
                client2.DownloadFileAsync(New Uri(value.Key), value.Value)
                While client2.IsBusy
                    thread.Sleep(1)
                End While
            Next
            For Each value As KeyValuePair(Of String, String) In listefile_local
                If (Not listefile_web.ContainsKey(value.Key) And Not value.Key.Contains(My.Application.Info.AssemblyName & ".exe") And Not value.Key.Contains("games.xml") And Not value.Key.Contains("Uninst.exe") And Not value.Key.Contains("cache.upd") And Not value.Key.Contains("videur.upd")) Then
                    delete.Add(value.Key.Replace("/", "\"))
                End If
            Next
            If (delete.Count > 0) Then
                maj_encour = True
                total = delete.Count + download.Count
                If (Me.WindowState = FormWindowState.Minimized) Then
                    notif.BalloonTipText = "Mise à jour en cours..."
                    notif.ShowBalloonTip(5000)
                End If
                If (infos_survol = False) Then
                    NewText(infos, "Mise à jour en cours : " & Format((100 / total) * encour, "###,###,##0") & "%")
                    CenterText(infos, Me)
                End If
                notif.Text = "Mise à jour en cours : " & Format((100 / total) * encour, "###,###,##0") & "%"
                NewText(stats, "Fichier : " & encour & "/" & total)
            End If
            For Each value As String In delete
                If (File.Exists(value)) Then
                    maj_chemin = value
                    Try
                        File.Delete(value)
                        encour += 1
                    Catch ex As Exception
                    End Try
                    NewText(stats, "Fichier : " & encour & "/" & total)
                    If (infos_survol = False) Then
                        NewText(infos, "Mise à jour en cours : " & Format((100 / total) * encour, "###,###,##0") & "%")
                        CenterText(infos, Me)
                    End If
                    notif.Text = "Mise à jour en cours : " & Format((100 / total) * encour, "###,###,##0") & "%"
                    NewWidth(pb2, (689 / 100) * ((100 / total) * encour))
                End If
            Next
            If (Me.WindowState = FormWindowState.Minimized) Then
                notif.BalloonTipText = "Mise à jour terminée !"
                notif.ShowBalloonTip(5000)
            End If
            If (delete.Count > 0 Or download.Count > 0) Then
                maj_encour = False
                NewText(infos, "Mise à jour terminée !")
                CenterText(infos, Me)
                If (File.Exists("cache.upd")) Then
                    File.Delete("cache.upd")
                End If
                File.WriteAllText("cache.upd", liste_web)
                File.SetAttributes("cache.upd", FileAttributes.Hidden)
            Else
                maj_encour = False
                NewText(infos, "Aucune mise à jour nécessaire !")
                CenterText(infos, Me)
                If (Not File.Exists("cache.upd")) Then
                    File.WriteAllText("cache.upd", liste_web)
                    File.SetAttributes("cache.upd", FileAttributes.Hidden)
                End If
            End If
        Catch z As Exception
            MsgBox(z.ToString)
        End Try
    End Sub
#End Region
#Region "boutton"
    Private Sub infos_Hover() Handles infos.MouseHover
        infos_survol = True
        If (maj_chemin.Length > 0 And maj_encour = True) Then
            maj_old = infos.Text
            infos.Text = maj_chemin
            CenterText(infos, Me)
        End If
    End Sub

    Private Sub infos_Leave() Handles infos.MouseLeave
        infos_survol = False
        If (maj_old.Length > 0) Then
            infos.Text = maj_old
            CenterText(infos, Me)
        End If
    End Sub

    Private Sub MenuBulles()
        Dim menu As New ContextMenu
        Dim bouton1 As New MenuItem
        bouton1.Index = 0
        bouton1.Text = "Fermer"
        AddHandler bouton1.Click, AddressOf CloseMe
        menu.MenuItems.AddRange(New MenuItem() {bouton1})
        notif.ContextMenu = menu
    End Sub

    Private Sub CloseMe()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf CloseMe))
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub reduire_Click(sender As Object, e As EventArgs) Handles reduire.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub close_exit_Click(sender As Object, e As EventArgs) Handles close_exit.Click
        Me.Close()
    End Sub

    Private Sub news_scroll_Scroll(sender As Object, e As ScrollEventArgs) Handles news_scroll.Scroll
        If (news_scroll.Value > 94) Then
            news1.Text = configuration.news(4)
            news2.Text = configuration.news(5)
            news3.Text = configuration.news(6)
            news4.Text = configuration.news(7)
        ElseIf (news_scroll.Value > 69) Then
            news1.Text = configuration.news(3)
            news2.Text = configuration.news(4)
            news3.Text = configuration.news(5)
            news4.Text = configuration.news(6)
        ElseIf (news_scroll.Value > 44) Then
            news1.Text = configuration.news(2)
            news2.Text = configuration.news(3)
            news3.Text = configuration.news(4)
            news4.Text = configuration.news(5)
        ElseIf (news_scroll.Value > 19) Then
            news1.Text = configuration.news(1)
            news2.Text = configuration.news(2)
            news3.Text = configuration.news(3)
            news4.Text = configuration.news(4)
        Else
            news1.Text = configuration.news(0)
            news2.Text = configuration.news(1)
            news3.Text = configuration.news(2)
            news4.Text = configuration.news(3)
        End If
    End Sub

    Private Sub bouton1_Click(sender As Object, e As EventArgs) Handles bouton1.Click
        Try
            System.Diagnostics.Process.Start(configuration.site)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub bouton2_Click(sender As Object, e As EventArgs) Handles bouton2.Click
        Try
            System.Diagnostics.Process.Start(configuration.forum)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub bouton3_Click(sender As Object, e As EventArgs) Handles bouton3.Click
        Try
            Dim cache As String = client.DownloadString(configuration.owner & "cache.php")
            If (cache.Length > 0) Then
                If (File.Exists("videur.upd")) Then
                    Dim text As String = File.ReadAllText("videur.upd")
                    If (Not text.Equals(cache)) Then
                        Process.Start("Cache.exe")
                        File.Delete("videur.upd")
                        File.WriteAllText("videur.upd", cache)
                        File.SetAttributes("videur.upd", FileAttributes.Hidden)
                    Else
                        If (maj_encour = False) Then
                            Process.Start("Dofus.exe")
                        Else
                            MsgBox("Éxécution impossible pour le moment.", MsgBoxStyle.Information)
                        End If
                    End If
                Else
                    Process.Start("Cache.exe")
                    File.WriteAllText("videur.upd", cache)
                    File.SetAttributes("videur.upd", FileAttributes.Hidden)
                End If
            Else
                If (maj_encour = False) Then
                    Process.Start("Dofus.exe")
                Else
                    MsgBox("Éxécution impossible pour le moment.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub bouton4_Click(sender As Object, e As EventArgs) Handles bouton4.Click
        Try
            If (maj_encour = False) Then
                Process.Start("Cache.exe")
            Else
                MsgBox("Éxécution impossible pour le moment.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Bouton_Survol(sender As Object, e As EventArgs) Handles bouton1.MouseHover, bouton2.MouseHover, bouton3.MouseHover
        Select Case sender.name()
            Case "bouton1"
                bouton1.BackgroundImage = My.Resources.Resources.site_hover
            Case "bouton2"
                    bouton2.BackgroundImage = My.Resources.Resources.forum_hover
            Case "bouton3"
                    bouton3.BackgroundImage = My.Resources.Resources.jouer_hover
        End Select
    End Sub

    Private Sub Bouton_Exit(sender As Object, e As EventArgs) Handles bouton1.MouseLeave, bouton2.MouseLeave, bouton3.MouseLeave
        Select Case sender.name()
            Case "bouton1"
                bouton1.BackgroundImage = My.Resources.Resources.spell
            Case "bouton2"
                    bouton2.BackgroundImage = My.Resources.Resources.forum
            Case "bouton3"
                    bouton3.BackgroundImage = My.Resources.Resources.jouer
        End Select
    End Sub

    Private Sub open() Handles notif.DoubleClick
        Me.WindowState = FormWindowState.Normal
    End Sub
#End Region
    Private start As Thread
    Private Sub updater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not AsInternet()) Then
            Me.Close()
            Return
        End If
        If (IO.File.Exists(My.Application.Info.AssemblyName & "_old.exe")) Then
            IO.File.Delete(My.Application.Info.AssemblyName & "_old.exe")
        End If
        Dim md5 As String = client.DownloadString(configuration.owner & "updater.php")
        If (md5.Length > 0) Then
            Dim source As String = crypteur.CrypteFile_md5(My.Application.Info.AssemblyName & ".exe")
            If (Not source.Equals(md5)) Then
                My.Computer.FileSystem.RenameFile(My.Application.Info.AssemblyName & ".exe", My.Application.Info.AssemblyName & "_old.exe")
                client.DownloadFile(configuration.owner & My.Application.Info.AssemblyName & ".exe", My.Application.Info.AssemblyName & ".exe")
                Process.Start(My.Application.Info.AssemblyName & ".exe")
                Me.Close()
                Return
            End If
        End If
        version.Text = configuration.version & " v"
        loadNews()
        MenuBulles()
        maj.RunWorkerAsync()
    End Sub
End Class
