<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SearchAsset
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchAsset))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Main_Search_Assets = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.pictureBox3 = New System.Windows.Forms.PictureBox()
        Me.search_assets = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Main_Search_Assets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel3.SuspendLayout()
        CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1230, 788)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Main_Search_Assets)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.panel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1222, 759)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(873, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(310, 20)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "You have authority to add 1 more person"
        '
        'Main_Search_Assets
        '
        Me.Main_Search_Assets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Main_Search_Assets.Location = New System.Drawing.Point(8, 245)
        Me.Main_Search_Assets.Name = "Main_Search_Assets"
        Me.Main_Search_Assets.RowHeadersWidth = 51
        Me.Main_Search_Assets.RowTemplate.Height = 24
        Me.Main_Search_Assets.Size = New System.Drawing.Size(1206, 506)
        Me.Main_Search_Assets.TabIndex = 99
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(919, 185)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(103, 32)
        Me.Button2.TabIndex = 98
        Me.Button2.Text = "More"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(779, 185)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 32)
        Me.Button1.TabIndex = 97
        Me.Button1.Text = "New Asset"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'panel3
        '
        Me.panel3.BackColor = System.Drawing.Color.White
        Me.panel3.Controls.Add(Me.pictureBox3)
        Me.panel3.Controls.Add(Me.search_assets)
        Me.panel3.Location = New System.Drawing.Point(113, 54)
        Me.panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(951, 55)
        Me.panel3.TabIndex = 96
        '
        'pictureBox3
        '
        Me.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pictureBox3.Image = CType(resources.GetObject("pictureBox3.Image"), System.Drawing.Image)
        Me.pictureBox3.Location = New System.Drawing.Point(889, 12)
        Me.pictureBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pictureBox3.Name = "pictureBox3"
        Me.pictureBox3.Size = New System.Drawing.Size(43, 31)
        Me.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox3.TabIndex = 2
        Me.pictureBox3.TabStop = False
        '
        'search_assets
        '
        Me.search_assets.BackColor = System.Drawing.Color.LightGray
        Me.search_assets.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.search_assets.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.search_assets.Location = New System.Drawing.Point(12, 12)
        Me.search_assets.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.search_assets.Name = "search_assets"
        Me.search_assets.Size = New System.Drawing.Size(856, 31)
        Me.search_assets.TabIndex = 2
        Me.search_assets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SearchAsset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1230, 788)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SearchAsset"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddAssetFrm"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.Main_Search_Assets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Private WithEvents panel3 As Panel
    Private WithEvents pictureBox3 As PictureBox
    Friend WithEvents search_assets As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Main_Search_Assets As DataGridView
    Friend WithEvents Label12 As Label
End Class
