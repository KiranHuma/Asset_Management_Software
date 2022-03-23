<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Apply_to_All_Record
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Apply_to_All_Record))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.terminate_lbl = New System.Windows.Forms.Label()
        Me.asst_id_number = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pending_lbl = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.assinie_nme_lbl = New System.Windows.Forms.Label()
        Me.running_tbl = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1291, 577)
        Me.DataGridView1.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(177, 713)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Auto_ID"
        Me.Label5.Visible = False
        '
        'terminate_lbl
        '
        Me.terminate_lbl.AutoSize = True
        Me.terminate_lbl.Location = New System.Drawing.Point(79, 713)
        Me.terminate_lbl.Name = "terminate_lbl"
        Me.terminate_lbl.Size = New System.Drawing.Size(72, 17)
        Me.terminate_lbl.TabIndex = 20
        Me.terminate_lbl.Text = "Terminate"
        Me.terminate_lbl.Visible = False
        '
        'asst_id_number
        '
        Me.asst_id_number.AutoSize = True
        Me.asst_id_number.Location = New System.Drawing.Point(381, 684)
        Me.asst_id_number.Name = "asst_id_number"
        Me.asst_id_number.Size = New System.Drawing.Size(21, 17)
        Me.asst_id_number.TabIndex = 19
        Me.asst_id_number.Text = "ID"
        Me.asst_id_number.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(732, 628)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(233, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Are you sure to Apply Changes"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 593)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(336, 25)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "The above values will be Affected"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(994, 607)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 36)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Yes"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pending_lbl
        '
        Me.pending_lbl.AutoSize = True
        Me.pending_lbl.Location = New System.Drawing.Point(79, 684)
        Me.pending_lbl.Name = "pending_lbl"
        Me.pending_lbl.Size = New System.Drawing.Size(60, 17)
        Me.pending_lbl.TabIndex = 25
        Me.pending_lbl.Text = "Pending"
        Me.pending_lbl.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(63, 621)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 22)
        Me.DateTimePicker1.TabIndex = 26
        Me.DateTimePicker1.Visible = False
        '
        'Button9
        '
        Me.Button9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.ForeColor = System.Drawing.SystemColors.Control
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.Location = New System.Drawing.Point(9, 684)
        Me.Button9.Margin = New System.Windows.Forms.Padding(4)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(63, 44)
        Me.Button9.TabIndex = 27
        Me.ToolTip1.SetToolTip(Me.Button9, "Return to Assets")
        Me.Button9.UseVisualStyleBackColor = False
        '
        'assinie_nme_lbl
        '
        Me.assinie_nme_lbl.AutoSize = True
        Me.assinie_nme_lbl.Location = New System.Drawing.Point(285, 713)
        Me.assinie_nme_lbl.Name = "assinie_nme_lbl"
        Me.assinie_nme_lbl.Size = New System.Drawing.Size(51, 17)
        Me.assinie_nme_lbl.TabIndex = 28
        Me.assinie_nme_lbl.Text = "Label6"
        Me.assinie_nme_lbl.Visible = False
        '
        'running_tbl
        '
        Me.running_tbl.AutoSize = True
        Me.running_tbl.Location = New System.Drawing.Point(260, 684)
        Me.running_tbl.Name = "running_tbl"
        Me.running_tbl.Size = New System.Drawing.Size(61, 17)
        Me.running_tbl.TabIndex = 92
        Me.running_tbl.Text = "Running"
        Me.running_tbl.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(495, 601)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 17)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "Main"
        Me.Label8.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1091, 607)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 36)
        Me.Button2.TabIndex = 95
        Me.Button2.Text = "No"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Apply_to_All_Record
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1291, 739)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.running_tbl)
        Me.Controls.Add(Me.assinie_nme_lbl)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.pending_lbl)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.terminate_lbl)
        Me.Controls.Add(Me.asst_id_number)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Apply_to_All_Record"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Terminate"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents terminate_lbl As Label
    Friend WithEvents asst_id_number As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents pending_lbl As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button9 As Button
    Friend WithEvents assinie_nme_lbl As Label
    Friend WithEvents running_tbl As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Button2 As Button
End Class
