<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Equipment
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
        Me.lblEquipmentType = New System.Windows.Forms.Label()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.lblPurchase = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtEquipment = New System.Windows.Forms.TextBox()
        Me.cmbEquipType = New System.Windows.Forms.ComboBox()
        Me.cmbCondition = New System.Windows.Forms.ComboBox()
        Me.dtpPurchase = New System.Windows.Forms.DateTimePicker()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblEquipTitle = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEquipmentType
        '
        Me.lblEquipmentType.AutoSize = True
        Me.lblEquipmentType.BackColor = System.Drawing.Color.Transparent
        Me.lblEquipmentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquipmentType.Location = New System.Drawing.Point(24, 127)
        Me.lblEquipmentType.Name = "lblEquipmentType"
        Me.lblEquipmentType.Size = New System.Drawing.Size(82, 32)
        Me.lblEquipmentType.TabIndex = 0
        Me.lblEquipmentType.Text = "Type"
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.BackColor = System.Drawing.Color.Transparent
        Me.lblCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondition.Location = New System.Drawing.Point(24, 204)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(146, 32)
        Me.lblCondition.TabIndex = 1
        Me.lblCondition.Text = "Condition"
        '
        'lblPurchase
        '
        Me.lblPurchase.AutoSize = True
        Me.lblPurchase.BackColor = System.Drawing.Color.Transparent
        Me.lblPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurchase.Location = New System.Drawing.Point(24, 281)
        Me.lblPurchase.Name = "lblPurchase"
        Me.lblPurchase.Size = New System.Drawing.Size(215, 32)
        Me.lblPurchase.TabIndex = 2
        Me.lblPurchase.Text = "Purchase Date"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(24, 363)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(102, 32)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Status"
        '
        'txtEquipment
        '
        Me.txtEquipment.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEquipment.Location = New System.Drawing.Point(301, 46)
        Me.txtEquipment.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEquipment.Name = "txtEquipment"
        Me.txtEquipment.Size = New System.Drawing.Size(349, 38)
        Me.txtEquipment.TabIndex = 4
        '
        'cmbEquipType
        '
        Me.cmbEquipType.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEquipType.FormattingEnabled = True
        Me.cmbEquipType.Location = New System.Drawing.Point(301, 117)
        Me.cmbEquipType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbEquipType.Name = "cmbEquipType"
        Me.cmbEquipType.Size = New System.Drawing.Size(209, 39)
        Me.cmbEquipType.TabIndex = 5
        '
        'cmbCondition
        '
        Me.cmbCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCondition.FormattingEnabled = True
        Me.cmbCondition.Location = New System.Drawing.Point(301, 194)
        Me.cmbCondition.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbCondition.Name = "cmbCondition"
        Me.cmbCondition.Size = New System.Drawing.Size(209, 39)
        Me.cmbCondition.TabIndex = 6
        '
        'dtpPurchase
        '
        Me.dtpPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPurchase.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPurchase.Location = New System.Drawing.Point(301, 273)
        Me.dtpPurchase.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpPurchase.Name = "dtpPurchase"
        Me.dtpPurchase.Size = New System.Drawing.Size(231, 38)
        Me.dtpPurchase.TabIndex = 7
        '
        'cmbStatus
        '
        Me.cmbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(301, 353)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(121, 39)
        Me.cmbStatus.TabIndex = 8
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(681, 28)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(147, 192)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(681, 225)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(147, 139)
        Me.btnUpdate.TabIndex = 10
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(681, 369)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(147, 85)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblEquipTitle
        '
        Me.lblEquipTitle.AutoSize = True
        Me.lblEquipTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblEquipTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquipTitle.Location = New System.Drawing.Point(24, 49)
        Me.lblEquipTitle.Name = "lblEquipTitle"
        Me.lblEquipTitle.Size = New System.Drawing.Size(248, 32)
        Me.lblEquipTitle.TabIndex = 12
        Me.lblEquipTitle.Text = "Equipment Name"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtEquipment)
        Me.GroupBox1.Controls.Add(Me.lblEquipTitle)
        Me.GroupBox1.Controls.Add(Me.lblEquipmentType)
        Me.GroupBox1.Controls.Add(Me.lblCondition)
        Me.GroupBox1.Controls.Add(Me.lblPurchase)
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.cmbStatus)
        Me.GroupBox1.Controls.Add(Me.cmbEquipType)
        Me.GroupBox1.Controls.Add(Me.dtpPurchase)
        Me.GroupBox1.Controls.Add(Me.cmbCondition)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(659, 439)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Please enter equipment details"
        '
        'Equipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GYM_MANAGEMENT.My.Resources.Resources.s
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(837, 463)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnSave)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Equipment"
        Me.Text = "Equipment"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblEquipmentType As System.Windows.Forms.Label
    Friend WithEvents lblCondition As System.Windows.Forms.Label
    Friend WithEvents lblPurchase As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtEquipment As System.Windows.Forms.TextBox
    Friend WithEvents cmbEquipType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCondition As System.Windows.Forms.ComboBox
    Friend WithEvents dtpPurchase As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblEquipTitle As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
