<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpDater
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpDater))
        Me.notif = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.maj = New System.ComponentModel.BackgroundWorker()
        Me.stats2 = New System.Windows.Forms.Label()
        Me.stats = New System.Windows.Forms.Label()
        Me.infos = New System.Windows.Forms.Label()
        Me.pb2 = New System.Windows.Forms.PictureBox()
        Me.pb1 = New System.Windows.Forms.PictureBox()
        Me.news_scroll = New System.Windows.Forms.VScrollBar()
        Me.bouton3 = New System.Windows.Forms.PictureBox()
        Me.bouton2 = New System.Windows.Forms.PictureBox()
        Me.bouton1 = New System.Windows.Forms.PictureBox()
        Me.reduire = New System.Windows.Forms.PictureBox()
        Me.close_exit = New System.Windows.Forms.PictureBox()
        Me.news3 = New System.Windows.Forms.Label()
        Me.news2 = New System.Windows.Forms.Label()
        Me.news1 = New System.Windows.Forms.Label()
        Me.news4 = New System.Windows.Forms.Label()
        Me.version = New System.Windows.Forms.Label()
        Me.bouton4 = New System.Windows.Forms.Button()
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bouton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bouton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bouton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reduire, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.close_exit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'notif
        '
        Me.notif.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.notif.BalloonTipTitle = "UpDater"
        Me.notif.Icon = CType(resources.GetObject("notif.Icon"), System.Drawing.Icon)
        Me.notif.Text = "UpDater"
        Me.notif.Visible = True
        '
        'maj
        '
        '
        'stats2
        '
        Me.stats2.AutoSize = True
        Me.stats2.BackColor = System.Drawing.Color.Transparent
        Me.stats2.Font = New System.Drawing.Font("Myriad Pro Light", 8.0!)
        Me.stats2.ForeColor = System.Drawing.Color.White
        Me.stats2.Location = New System.Drawing.Point(692, 183)
        Me.stats2.Name = "stats2"
        Me.stats2.Size = New System.Drawing.Size(0, 13)
        Me.stats2.TabIndex = 53
        '
        'stats
        '
        Me.stats.AutoSize = True
        Me.stats.BackColor = System.Drawing.Color.Transparent
        Me.stats.Font = New System.Drawing.Font("Myriad Pro Light", 8.0!)
        Me.stats.ForeColor = System.Drawing.Color.White
        Me.stats.Location = New System.Drawing.Point(3, 183)
        Me.stats.Name = "stats"
        Me.stats.Size = New System.Drawing.Size(0, 13)
        Me.stats.TabIndex = 52
        '
        'infos
        '
        Me.infos.AutoSize = True
        Me.infos.BackColor = System.Drawing.Color.Transparent
        Me.infos.Font = New System.Drawing.Font("Myriad Pro Light", 8.0!)
        Me.infos.ForeColor = System.Drawing.Color.White
        Me.infos.Location = New System.Drawing.Point(171, 183)
        Me.infos.Name = "infos"
        Me.infos.Size = New System.Drawing.Size(0, 13)
        Me.infos.TabIndex = 51
        Me.infos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb2
        '
        Me.pb2.BackColor = System.Drawing.Color.Transparent
        Me.pb2.BackgroundImage = Global.UpDater.My.Resources.Resources.pb
        Me.pb2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb2.Location = New System.Drawing.Point(3, 196)
        Me.pb2.MaximumSize = New System.Drawing.Size(689, 10)
        Me.pb2.MinimumSize = New System.Drawing.Size(0, 10)
        Me.pb2.Name = "pb2"
        Me.pb2.Size = New System.Drawing.Size(0, 10)
        Me.pb2.TabIndex = 50
        Me.pb2.TabStop = False
        '
        'pb1
        '
        Me.pb1.BackColor = System.Drawing.Color.Transparent
        Me.pb1.BackgroundImage = Global.UpDater.My.Resources.Resources.pb
        Me.pb1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb1.Location = New System.Drawing.Point(3, 207)
        Me.pb1.MaximumSize = New System.Drawing.Size(689, 10)
        Me.pb1.MinimumSize = New System.Drawing.Size(0, 10)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(0, 10)
        Me.pb1.TabIndex = 49
        Me.pb1.TabStop = False
        '
        'news_scroll
        '
        Me.news_scroll.LargeChange = 5
        Me.news_scroll.Location = New System.Drawing.Point(675, 218)
        Me.news_scroll.Maximum = 10
        Me.news_scroll.Name = "news_scroll"
        Me.news_scroll.Size = New System.Drawing.Size(17, 173)
        Me.news_scroll.TabIndex = 48
        '
        'bouton3
        '
        Me.bouton3.BackColor = System.Drawing.Color.Transparent
        Me.bouton3.BackgroundImage = Global.UpDater.My.Resources.Resources.jouer
        Me.bouton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bouton3.Location = New System.Drawing.Point(3, 304)
        Me.bouton3.MaximumSize = New System.Drawing.Size(140, 51)
        Me.bouton3.Name = "bouton3"
        Me.bouton3.Size = New System.Drawing.Size(140, 43)
        Me.bouton3.TabIndex = 47
        Me.bouton3.TabStop = False
        '
        'bouton2
        '
        Me.bouton2.BackColor = System.Drawing.Color.Transparent
        Me.bouton2.BackgroundImage = Global.UpDater.My.Resources.Resources.forum
        Me.bouton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bouton2.Location = New System.Drawing.Point(3, 261)
        Me.bouton2.MaximumSize = New System.Drawing.Size(140, 51)
        Me.bouton2.Name = "bouton2"
        Me.bouton2.Size = New System.Drawing.Size(140, 43)
        Me.bouton2.TabIndex = 46
        Me.bouton2.TabStop = False
        '
        'bouton1
        '
        Me.bouton1.BackColor = System.Drawing.Color.Transparent
        Me.bouton1.BackgroundImage = Global.UpDater.My.Resources.Resources.spell
        Me.bouton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bouton1.Location = New System.Drawing.Point(3, 218)
        Me.bouton1.MaximumSize = New System.Drawing.Size(140, 51)
        Me.bouton1.Name = "bouton1"
        Me.bouton1.Size = New System.Drawing.Size(140, 43)
        Me.bouton1.TabIndex = 45
        Me.bouton1.TabStop = False
        '
        'reduire
        '
        Me.reduire.BackColor = System.Drawing.Color.Transparent
        Me.reduire.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.reduire.Cursor = System.Windows.Forms.Cursors.Hand
        Me.reduire.Location = New System.Drawing.Point(640, 3)
        Me.reduire.Name = "reduire"
        Me.reduire.Size = New System.Drawing.Size(19, 32)
        Me.reduire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.reduire.TabIndex = 44
        Me.reduire.TabStop = False
        '
        'close_exit
        '
        Me.close_exit.BackColor = System.Drawing.Color.Transparent
        Me.close_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.close_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.close_exit.Location = New System.Drawing.Point(658, 3)
        Me.close_exit.Name = "close_exit"
        Me.close_exit.Size = New System.Drawing.Size(34, 32)
        Me.close_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.close_exit.TabIndex = 43
        Me.close_exit.TabStop = False
        '
        'news3
        '
        Me.news3.AutoSize = True
        Me.news3.BackColor = System.Drawing.Color.Transparent
        Me.news3.Font = New System.Drawing.Font("Myriad Pro Light", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.news3.ForeColor = System.Drawing.Color.Black
        Me.news3.Location = New System.Drawing.Point(143, 305)
        Me.news3.Name = "news3"
        Me.news3.Size = New System.Drawing.Size(0, 17)
        Me.news3.TabIndex = 40
        '
        'news2
        '
        Me.news2.AutoSize = True
        Me.news2.BackColor = System.Drawing.Color.Transparent
        Me.news2.Font = New System.Drawing.Font("Myriad Pro Light", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.news2.ForeColor = System.Drawing.Color.Black
        Me.news2.Location = New System.Drawing.Point(143, 262)
        Me.news2.Name = "news2"
        Me.news2.Size = New System.Drawing.Size(0, 17)
        Me.news2.TabIndex = 39
        '
        'news1
        '
        Me.news1.AutoSize = True
        Me.news1.BackColor = System.Drawing.Color.Transparent
        Me.news1.Font = New System.Drawing.Font("Myriad Pro Light", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.news1.ForeColor = System.Drawing.Color.Black
        Me.news1.Location = New System.Drawing.Point(143, 218)
        Me.news1.Name = "news1"
        Me.news1.Size = New System.Drawing.Size(0, 17)
        Me.news1.TabIndex = 38
        '
        'news4
        '
        Me.news4.AutoSize = True
        Me.news4.BackColor = System.Drawing.Color.Transparent
        Me.news4.Font = New System.Drawing.Font("Myriad Pro Light", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.news4.ForeColor = System.Drawing.Color.Black
        Me.news4.Location = New System.Drawing.Point(143, 348)
        Me.news4.Name = "news4"
        Me.news4.Size = New System.Drawing.Size(0, 17)
        Me.news4.TabIndex = 41
        '
        'version
        '
        Me.version.AutoSize = True
        Me.version.BackColor = System.Drawing.Color.Transparent
        Me.version.Font = New System.Drawing.Font("Myriad Pro", 7.0!)
        Me.version.ForeColor = System.Drawing.Color.Black
        Me.version.Location = New System.Drawing.Point(5, 378)
        Me.version.Name = "version"
        Me.version.Size = New System.Drawing.Size(25, 12)
        Me.version.TabIndex = 37
        Me.version.Text = "V 0.1"
        '
        'bouton4
        '
        Me.bouton4.BackColor = System.Drawing.Color.SteelBlue
        Me.bouton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.bouton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bouton4.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.bouton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.bouton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue
        Me.bouton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bouton4.Font = New System.Drawing.Font("Jokerman", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.bouton4.ForeColor = System.Drawing.Color.White
        Me.bouton4.Location = New System.Drawing.Point(3, 346)
        Me.bouton4.Name = "bouton4"
        Me.bouton4.Size = New System.Drawing.Size(140, 29)
        Me.bouton4.TabIndex = 54
        Me.bouton4.Text = "Vider le cache"
        Me.bouton4.UseVisualStyleBackColor = False
        '
        'UpDater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Plum
        Me.BackgroundImage = Global.UpDater.My.Resources.Resources.fond
        Me.ClientSize = New System.Drawing.Size(695, 395)
        Me.Controls.Add(Me.bouton4)
        Me.Controls.Add(Me.stats2)
        Me.Controls.Add(Me.stats)
        Me.Controls.Add(Me.infos)
        Me.Controls.Add(Me.pb2)
        Me.Controls.Add(Me.pb1)
        Me.Controls.Add(Me.news_scroll)
        Me.Controls.Add(Me.bouton3)
        Me.Controls.Add(Me.bouton2)
        Me.Controls.Add(Me.bouton1)
        Me.Controls.Add(Me.reduire)
        Me.Controls.Add(Me.close_exit)
        Me.Controls.Add(Me.news3)
        Me.Controls.Add(Me.news2)
        Me.Controls.Add(Me.news1)
        Me.Controls.Add(Me.news4)
        Me.Controls.Add(Me.version)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UpDater"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UpDater Owny"
        Me.TransparencyKey = System.Drawing.Color.Plum
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bouton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bouton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bouton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.reduire, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.close_exit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents notif As System.Windows.Forms.NotifyIcon
    Friend WithEvents maj As System.ComponentModel.BackgroundWorker
    Friend WithEvents stats2 As System.Windows.Forms.Label
    Friend WithEvents stats As System.Windows.Forms.Label
    Friend WithEvents infos As System.Windows.Forms.Label
    Friend WithEvents pb2 As System.Windows.Forms.PictureBox
    Friend WithEvents pb1 As System.Windows.Forms.PictureBox
    Friend WithEvents news_scroll As System.Windows.Forms.VScrollBar
    Friend WithEvents bouton3 As System.Windows.Forms.PictureBox
    Friend WithEvents bouton2 As System.Windows.Forms.PictureBox
    Friend WithEvents bouton1 As System.Windows.Forms.PictureBox
    Friend WithEvents reduire As System.Windows.Forms.PictureBox
    Friend WithEvents close_exit As System.Windows.Forms.PictureBox
    Friend WithEvents news3 As System.Windows.Forms.Label
    Friend WithEvents news2 As System.Windows.Forms.Label
    Friend WithEvents news1 As System.Windows.Forms.Label
    Friend WithEvents news4 As System.Windows.Forms.Label
    Friend WithEvents version As System.Windows.Forms.Label
    Friend WithEvents bouton4 As System.Windows.Forms.Button

End Class
