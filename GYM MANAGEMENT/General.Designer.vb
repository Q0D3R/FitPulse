<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class General
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(General))
        Me.btnMemb = New System.Windows.Forms.Button()
        Me.btnTrain = New System.Windows.Forms.Button()
        Me.btnSub = New System.Windows.Forms.Button()
        Me.btnClass = New System.Windows.Forms.Button()
        Me.btnEquip = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnMemb
        '
        Me.btnMemb.Font = New System.Drawing.Font("Microsoft Uighur", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMemb.Location = New System.Drawing.Point(492, 211)
        Me.btnMemb.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnMemb.Name = "btnMemb"
        Me.btnMemb.Size = New System.Drawing.Size(93, 32)
        Me.btnMemb.TabIndex = 0
        Me.btnMemb.Text = "Members"
        Me.btnMemb.UseVisualStyleBackColor = True
        '
        'btnTrain
        '
        Me.btnTrain.Font = New System.Drawing.Font("Microsoft Uighur", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrain.Location = New System.Drawing.Point(272, 208)
        Me.btnTrain.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnTrain.Name = "btnTrain"
        Me.btnTrain.Size = New System.Drawing.Size(77, 35)
        Me.btnTrain.TabIndex = 1
        Me.btnTrain.Text = "Trainers"
        Me.btnTrain.UseVisualStyleBackColor = True
        '
        'btnSub
        '
        Me.btnSub.Font = New System.Drawing.Font("Microsoft Uighur", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSub.Location = New System.Drawing.Point(367, 145)
        Me.btnSub.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSub.Name = "btnSub"
        Me.btnSub.Size = New System.Drawing.Size(109, 35)
        Me.btnSub.TabIndex = 2
        Me.btnSub.Text = "Subscription"
        Me.btnSub.UseVisualStyleBackColor = True
        '
        'btnClass
        '
        Me.btnClass.Font = New System.Drawing.Font("Microsoft Uighur", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClass.Location = New System.Drawing.Point(381, 208)
        Me.btnClass.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnClass.Name = "btnClass"
        Me.btnClass.Size = New System.Drawing.Size(83, 35)
        Me.btnClass.TabIndex = 3
        Me.btnClass.Text = "Classes"
        Me.btnClass.UseVisualStyleBackColor = True
        '
        'btnEquip
        '
        Me.btnEquip.Font = New System.Drawing.Font("Microsoft Uighur", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquip.Location = New System.Drawing.Point(367, 269)
        Me.btnEquip.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnEquip.Name = "btnEquip"
        Me.btnEquip.Size = New System.Drawing.Size(110, 35)
        Me.btnEquip.TabIndex = 4
        Me.btnEquip.Text = "Equipment"
        Me.btnEquip.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(11, 20)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 213)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'General
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BackgroundImage = Global.GYM_MANAGEMENT.My.Resources.Resources.s
        Me.ClientSize = New System.Drawing.Size(1112, 620)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnEquip)
        Me.Controls.Add(Me.btnClass)
        Me.Controls.Add(Me.btnSub)
        Me.Controls.Add(Me.btnTrain)
        Me.Controls.Add(Me.btnMemb)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "General"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "General"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMemb As System.Windows.Forms.Button
    Friend WithEvents btnTrain As System.Windows.Forms.Button
    Friend WithEvents btnSub As System.Windows.Forms.Button
    Friend WithEvents btnClass As System.Windows.Forms.Button
    Friend WithEvents btnEquip As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
