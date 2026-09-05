<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class view_tickets
    Inherits MaterialSkin.Controls.MaterialForm

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnRefresh = New MaterialSkin.Controls.MaterialButton()
        Me.btnDeleteTicket = New MaterialSkin.Controls.MaterialButton()
        Me.btnExit = New MaterialSkin.Controls.MaterialButton()
        Me.lblSearch = New MaterialSkin.Controls.MaterialLabel()
        Me.txtSearch = New MaterialSkin.Controls.MaterialTextBox2()
        Me.lblFilter = New MaterialSkin.Controls.MaterialLabel()
        Me.cmbFilterType = New MaterialSkin.Controls.MaterialComboBox()
        Me.lblHeaders = New MaterialSkin.Controls.MaterialLabel()
        Me.dgvHeaders = New System.Windows.Forms.DataGridView()
        Me.lblDetails = New MaterialSkin.Controls.MaterialLabel()
        Me.dgvDetails = New System.Windows.Forms.DataGridView()
        Me.btnInProgress = New MaterialSkin.Controls.MaterialButton()
        Me.btnComplete = New MaterialSkin.Controls.MaterialButton()
        CType(Me.dgvHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRefresh
        '
        Me.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRefresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnRefresh.Depth = 0
        Me.btnRefresh.HighEmphasis = True
        Me.btnRefresh.Icon = Nothing
        Me.btnRefresh.Location = New System.Drawing.Point(625, 75)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnRefresh.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.NoAccentTextColor = System.Drawing.Color.Empty
        Me.btnRefresh.Size = New System.Drawing.Size(84, 36)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnRefresh.UseAccentColor = False
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnDeleteTicket
        '
        Me.btnDeleteTicket.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDeleteTicket.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnDeleteTicket.Depth = 0
        Me.btnDeleteTicket.HighEmphasis = True
        Me.btnDeleteTicket.Icon = Nothing
        Me.btnDeleteTicket.Location = New System.Drawing.Point(725, 75)
        Me.btnDeleteTicket.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnDeleteTicket.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnDeleteTicket.Name = "btnDeleteTicket"
        Me.btnDeleteTicket.NoAccentTextColor = System.Drawing.Color.Empty
        Me.btnDeleteTicket.Size = New System.Drawing.Size(73, 36)
        Me.btnDeleteTicket.TabIndex = 2
        Me.btnDeleteTicket.Text = "Delete"
        Me.btnDeleteTicket.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnDeleteTicket.UseAccentColor = True
        Me.btnDeleteTicket.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnExit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnExit.Depth = 0
        Me.btnExit.HighEmphasis = False
        Me.btnExit.Icon = Nothing
        Me.btnExit.Location = New System.Drawing.Point(825, 75)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnExit.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnExit.Name = "btnExit"
        Me.btnExit.NoAccentTextColor = System.Drawing.Color.Empty
        Me.btnExit.Size = New System.Drawing.Size(64, 36)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text
        Me.btnExit.UseAccentColor = False
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Depth = 0
        Me.lblSearch.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblSearch.Location = New System.Drawing.Point(24, 137)
        Me.lblSearch.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(54, 19)
        Me.lblSearch.TabIndex = 4
        Me.lblSearch.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.AnimateReadOnly = False
        Me.txtSearch.Depth = 0
        Me.txtSearch.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtSearch.HideSelection = True
        Me.txtSearch.Hint = "Req No, User, Manager..."
        Me.txtSearch.Location = New System.Drawing.Point(85, 122)
        Me.txtSearch.MaxLength = 32767
        Me.txtSearch.MouseState = MaterialSkin.MouseState.OUT
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearch.ReadOnly = False
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.SelectionLength = 0
        Me.txtSearch.SelectionStart = 0
        Me.txtSearch.ShortcutsEnabled = True
        Me.txtSearch.Size = New System.Drawing.Size(320, 48)
        Me.txtSearch.TabIndex = 5
        Me.txtSearch.TabStop = False
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'lblFilter
        '
        Me.lblFilter.AutoSize = True
        Me.lblFilter.Depth = 0
        Me.lblFilter.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblFilter.Location = New System.Drawing.Point(430, 137)
        Me.lblFilter.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(40, 19)
        Me.lblFilter.TabIndex = 6
        Me.lblFilter.Text = "Type:"
        '
        'cmbFilterType
        '
        Me.cmbFilterType.AutoResize = False
        Me.cmbFilterType.BackColor = System.Drawing.Color.White
        Me.cmbFilterType.Depth = 0
        Me.cmbFilterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbFilterType.DropDownHeight = 174
        Me.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterType.DropDownWidth = 121
        Me.cmbFilterType.Font = New System.Drawing.Font("Roboto Medium", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.cmbFilterType.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0)
        Me.cmbFilterType.FormattingEnabled = True
        Me.cmbFilterType.IntegralHeight = False
        Me.cmbFilterType.ItemHeight = 43
        Me.cmbFilterType.Location = New System.Drawing.Point(480, 122)
        Me.cmbFilterType.MaxDropDownItems = 4
        Me.cmbFilterType.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbFilterType.Name = "cmbFilterType"
        Me.cmbFilterType.Size = New System.Drawing.Size(220, 49)
        Me.cmbFilterType.StartIndex = 0
        Me.cmbFilterType.TabIndex = 7
        '
        'lblHeaders
        '
        Me.lblHeaders.AutoSize = True
        Me.lblHeaders.Depth = 0
        Me.lblHeaders.Font = New System.Drawing.Font("Roboto Medium", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.lblHeaders.Location = New System.Drawing.Point(24, 190)
        Me.lblHeaders.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblHeaders.Name = "lblHeaders"
        Me.lblHeaders.Size = New System.Drawing.Size(126, 19)
        Me.lblHeaders.TabIndex = 8
        Me.lblHeaders.Text = "All IT Tickets Log"
        '
        'dgvHeaders
        '
        Me.dgvHeaders.AllowUserToAddRows = False
        Me.dgvHeaders.AllowUserToDeleteRows = False
        Me.dgvHeaders.BackgroundColor = System.Drawing.Color.White
        Me.dgvHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHeaders.Location = New System.Drawing.Point(24, 215)
        Me.dgvHeaders.MultiSelect = False
        Me.dgvHeaders.Name = "dgvHeaders"
        Me.dgvHeaders.ReadOnly = True
        Me.dgvHeaders.RowHeadersVisible = False
        Me.dgvHeaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHeaders.Size = New System.Drawing.Size(875, 185)
        Me.dgvHeaders.TabIndex = 9
        '
        'lblDetails
        '
        Me.lblDetails.AutoSize = True
        Me.lblDetails.Depth = 0
        Me.lblDetails.Font = New System.Drawing.Font("Roboto Medium", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.lblDetails.Location = New System.Drawing.Point(24, 415)
        Me.lblDetails.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(161, 19)
        Me.lblDetails.TabIndex = 10
        Me.lblDetails.Text = "Selected Ticket Items"
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetails.Location = New System.Drawing.Point(24, 440)
        Me.dgvDetails.MultiSelect = False
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.RowHeadersVisible = False
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(875, 185)
        Me.dgvDetails.TabIndex = 11
        '
        'btnInProgress
        '
        Me.btnInProgress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnInProgress.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnInProgress.Depth = 0
        Me.btnInProgress.HighEmphasis = True
        Me.btnInProgress.Icon = Nothing
        Me.btnInProgress.Location = New System.Drawing.Point(620, 640)
        Me.btnInProgress.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnInProgress.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnInProgress.Name = "btnInProgress"
        Me.btnInProgress.NoAccentTextColor = System.Drawing.Color.Empty
        Me.btnInProgress.Size = New System.Drawing.Size(126, 36)
        Me.btnInProgress.TabIndex = 12
        Me.btnInProgress.Text = "In Progress"
        Me.btnInProgress.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnInProgress.UseAccentColor = False
        Me.btnInProgress.UseVisualStyleBackColor = True
        '
        'btnComplete
        '
        Me.btnComplete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnComplete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnComplete.Depth = 0
        Me.btnComplete.HighEmphasis = True
        Me.btnComplete.Icon = Nothing
        Me.btnComplete.Location = New System.Drawing.Point(760, 640)
        Me.btnComplete.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnComplete.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnComplete.Name = "btnComplete"
        Me.btnComplete.NoAccentTextColor = System.Drawing.Color.Empty
        Me.btnComplete.Size = New System.Drawing.Size(139, 36)
        Me.btnComplete.TabIndex = 13
        Me.btnComplete.Text = "Set Completed"
        Me.btnComplete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnComplete.UseAccentColor = True
        Me.btnComplete.UseVisualStyleBackColor = True
        '
        'view_tickets
        '
        Me.ClientSize = New System.Drawing.Size(925, 700)
        Me.Controls.Add(Me.btnComplete)
        Me.Controls.Add(Me.btnInProgress)
        Me.Controls.Add(Me.dgvDetails)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.dgvHeaders)
        Me.Controls.Add(Me.lblHeaders)
        Me.Controls.Add(Me.cmbFilterType)
        Me.Controls.Add(Me.lblFilter)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDeleteTicket)
        Me.Controls.Add(Me.btnRefresh)
        Me.Name = "view_tickets"
        Me.Text = "IT Ticket Monitor"
        CType(Me.dgvHeaders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents btnRefresh As MaterialSkin.Controls.MaterialButton
    Friend WithEvents btnDeleteTicket As MaterialSkin.Controls.MaterialButton
    Friend WithEvents btnExit As MaterialSkin.Controls.MaterialButton
    Friend WithEvents lblSearch As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents txtSearch As MaterialSkin.Controls.MaterialTextBox2
    Friend WithEvents lblFilter As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents cmbFilterType As MaterialSkin.Controls.MaterialComboBox
    Friend WithEvents lblHeaders As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents dgvHeaders As System.Windows.Forms.DataGridView
    Friend WithEvents lblDetails As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnInProgress As MaterialSkin.Controls.MaterialButton
    Friend WithEvents btnComplete As MaterialSkin.Controls.MaterialButton
End Class