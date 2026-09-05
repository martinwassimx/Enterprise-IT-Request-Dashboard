Imports RestSharp
Imports Newtonsoft.Json
Imports MaterialSkin
Imports MaterialSkin.Controls

Public Class ticket
    Inherits MaterialForm

    ' controls
    Friend WithEvents btnNew As MaterialButton
    Friend WithEvents btnSave As MaterialButton
    Friend WithEvents lblReqType As MaterialLabel
    Friend WithEvents cmbReqType As MaterialComboBox
    Friend WithEvents lblSite As MaterialLabel
    Friend WithEvents cmbSite As MaterialComboBox
    Friend WithEvents lblReqNo As MaterialLabel
    Friend WithEvents txtReqNo As MaterialTextBox2
    Friend WithEvents lblRequesterDetail As MaterialLabel
    Friend WithEvents rbForMe As MaterialRadioButton
    Friend WithEvents rbOnBehalf As MaterialRadioButton
    Friend WithEvents lblUserName As MaterialLabel
    Friend WithEvents cmbUserName As MaterialComboBox
    Friend WithEvents lblManager As MaterialLabel
    Friend WithEvents cmbManager As MaterialComboBox
    Friend WithEvents btnCreateUser As MaterialButton
    Friend WithEvents lblRequestDetail As MaterialLabel
    Friend WithEvents lblReqCategory As MaterialLabel
    Friend WithEvents cmbReqCategory As MaterialComboBox
    Friend WithEvents lblDetails As MaterialLabel
    Friend WithEvents cmbReqDetails As MaterialComboBox
    Friend WithEvents swPrivate As MaterialSwitch
    Friend WithEvents lblOther As MaterialLabel
    Friend WithEvents txtOther As MaterialTextBox2
    Friend WithEvents lblRemarks As MaterialLabel
    Friend WithEvents txtRemarks As MaterialMultiLineTextBox2
    Friend WithEvents btnAddItem As MaterialButton
    Friend WithEvents dgvTicketItems As DataGridView
    Friend WithEvents colReq As DataGridViewTextBoxColumn
    Friend WithEvents colDetails As DataGridViewTextBoxColumn
    Friend WithEvents colPrivate As DataGridViewTextBoxColumn
    Friend WithEvents colOther As DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn

    ' lists to hold api results
    Private allLookups As New List(Of LookupItem)
    Private allUsers As New List(Of UserDetailDTO)

    Public Class LookupItem
        Public Property Title As String
        Public Property Name As String
    End Class

    Public Class UserDetailDTO
        Public Property EmpID As String
        Public Property Name As String
        Public Property Email As String
        Public Property DepID As Integer
        Public Property ManagerName As String
    End Class

    Public Class RequestHeaderDTO
        Public Property Req_No As String
        Public Property Req_Type As String
        Public Property Site As String
        Public Property Requester_Option As String
        Public Property User_Name As String
        Public Property Manager As String
        Public Property Created_By As String
        Public Property Created_Date As DateTime?
        Public Property DetailsList As List(Of RequestDetailDTO)
    End Class

    Public Class RequestDetailDTO
        Public Property Req_No As String
        Public Property Req As String
        Public Property Details As String
        Public Property [Private] As Boolean
        Public Property Other As String
        Public Property Remarks As String
        Public Property Status As String
    End Class

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.btnNew = New MaterialSkin.Controls.MaterialButton()
        Me.btnSave = New MaterialSkin.Controls.MaterialButton()
        Me.lblReqType = New MaterialSkin.Controls.MaterialLabel()
        Me.cmbReqType = New MaterialSkin.Controls.MaterialComboBox()
        Me.lblSite = New MaterialSkin.Controls.MaterialLabel()
        Me.cmbSite = New MaterialSkin.Controls.MaterialComboBox()
        Me.lblReqNo = New MaterialSkin.Controls.MaterialLabel()
        Me.txtReqNo = New MaterialSkin.Controls.MaterialTextBox2()
        Me.lblRequesterDetail = New MaterialSkin.Controls.MaterialLabel()
        Me.rbForMe = New MaterialSkin.Controls.MaterialRadioButton()
        Me.rbOnBehalf = New MaterialSkin.Controls.MaterialRadioButton()
        Me.lblUserName = New MaterialSkin.Controls.MaterialLabel()
        Me.cmbUserName = New MaterialSkin.Controls.MaterialComboBox()
        Me.lblManager = New MaterialSkin.Controls.MaterialLabel()
        Me.cmbManager = New MaterialSkin.Controls.MaterialComboBox()
        Me.btnCreateUser = New MaterialSkin.Controls.MaterialButton()
        Me.lblRequestDetail = New MaterialSkin.Controls.MaterialLabel()
        Me.lblReqCategory = New MaterialSkin.Controls.MaterialLabel()
        Me.cmbReqCategory = New MaterialSkin.Controls.MaterialComboBox()
        Me.lblDetails = New MaterialSkin.Controls.MaterialLabel()
        Me.cmbReqDetails = New MaterialSkin.Controls.MaterialComboBox()
        Me.swPrivate = New MaterialSkin.Controls.MaterialSwitch()
        Me.lblOther = New MaterialSkin.Controls.MaterialLabel()
        Me.txtOther = New MaterialSkin.Controls.MaterialTextBox2()
        Me.lblRemarks = New MaterialSkin.Controls.MaterialLabel()
        Me.txtRemarks = New MaterialSkin.Controls.MaterialMultiLineTextBox2()
        Me.btnAddItem = New MaterialSkin.Controls.MaterialButton()
        Me.dgvTicketItems = New System.Windows.Forms.DataGridView()
        Me.colReq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrivate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOther = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvTicketItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNew
        '
        Me.btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnNew.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnNew.Depth = 0
        Me.btnNew.HighEmphasis = True
        Me.btnNew.Icon = Nothing
        Me.btnNew.Location = New System.Drawing.Point(745, 70)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnNew.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnNew.Name = "btnNew"
        Me.btnNew.NoAccentTextColor = System.Drawing.Color.Empty
        Me.btnNew.Size = New System.Drawing.Size(64, 36)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "New"
        Me.btnNew.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined
        Me.btnNew.UseAccentColor = False
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnSave.Depth = 0
        Me.btnSave.HighEmphasis = True
        Me.btnSave.Icon = Nothing
        Me.btnSave.Location = New System.Drawing.Point(825, 70)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnSave.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnSave.Name = "btnSave"
        Me.btnSave.NoAccentTextColor = System.Drawing.Color.Empty
        Me.btnSave.Size = New System.Drawing.Size(64, 36)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnSave.UseAccentColor = False
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblReqType
        '
        Me.lblReqType.AutoSize = True
        Me.lblReqType.Depth = 0
        Me.lblReqType.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblReqType.Location = New System.Drawing.Point(24, 137)
        Me.lblReqType.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblReqType.Name = "lblReqType"
        Me.lblReqType.Size = New System.Drawing.Size(67, 19)
        Me.lblReqType.TabIndex = 4
        Me.lblReqType.Text = "Req Type"
        '
        'cmbReqType
        '
        Me.cmbReqType.AutoResize = False
        Me.cmbReqType.BackColor = System.Drawing.Color.White
        Me.cmbReqType.Depth = 0
        Me.cmbReqType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbReqType.DropDownHeight = 174
        Me.cmbReqType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReqType.DropDownWidth = 121
        Me.cmbReqType.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.cmbReqType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmbReqType.FormattingEnabled = True
        Me.cmbReqType.IntegralHeight = False
        Me.cmbReqType.ItemHeight = 43
        Me.cmbReqType.Location = New System.Drawing.Point(100, 122)
        Me.cmbReqType.MaxDropDownItems = 4
        Me.cmbReqType.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbReqType.Name = "cmbReqType"
        Me.cmbReqType.Size = New System.Drawing.Size(200, 49)
        Me.cmbReqType.StartIndex = 0
        Me.cmbReqType.TabIndex = 5
        '
        'lblSite
        '
        Me.lblSite.AutoSize = True
        Me.lblSite.Depth = 0
        Me.lblSite.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblSite.Location = New System.Drawing.Point(330, 137)
        Me.lblSite.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblSite.Name = "lblSite"
        Me.lblSite.Size = New System.Drawing.Size(28, 19)
        Me.lblSite.TabIndex = 6
        Me.lblSite.Text = "Site"
        '
        'cmbSite
        '
        Me.cmbSite.AutoResize = False
        Me.cmbSite.BackColor = System.Drawing.Color.White
        Me.cmbSite.Depth = 0
        Me.cmbSite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbSite.DropDownHeight = 174
        Me.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSite.DropDownWidth = 121
        Me.cmbSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.cmbSite.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmbSite.FormattingEnabled = True
        Me.cmbSite.IntegralHeight = False
        Me.cmbSite.ItemHeight = 43
        Me.cmbSite.Location = New System.Drawing.Point(370, 122)
        Me.cmbSite.MaxDropDownItems = 4
        Me.cmbSite.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbSite.Name = "cmbSite"
        Me.cmbSite.Size = New System.Drawing.Size(180, 49)
        Me.cmbSite.StartIndex = 0
        Me.cmbSite.TabIndex = 7
        '
        'lblReqNo
        '
        Me.lblReqNo.AutoSize = True
        Me.lblReqNo.Depth = 0
        Me.lblReqNo.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblReqNo.Location = New System.Drawing.Point(580, 137)
        Me.lblReqNo.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblReqNo.Name = "lblReqNo"
        Me.lblReqNo.Size = New System.Drawing.Size(52, 19)
        Me.lblReqNo.TabIndex = 8
        Me.lblReqNo.Text = "Req No"
        '
        'txtReqNo
        '
        Me.txtReqNo.AnimateReadOnly = False
        Me.txtReqNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.txtReqNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtReqNo.Depth = 0
        Me.txtReqNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtReqNo.HideSelection = True
        Me.txtReqNo.LeadingIcon = Nothing
        Me.txtReqNo.Location = New System.Drawing.Point(645, 122)
        Me.txtReqNo.MaxLength = 32767
        Me.txtReqNo.MouseState = MaterialSkin.MouseState.OUT
        Me.txtReqNo.Name = "txtReqNo"
        Me.txtReqNo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtReqNo.PrefixSuffixText = Nothing
        Me.txtReqNo.ReadOnly = True
        Me.txtReqNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReqNo.SelectedText = ""
        Me.txtReqNo.SelectionLength = 0
        Me.txtReqNo.SelectionStart = 0
        Me.txtReqNo.ShortcutsEnabled = True
        Me.txtReqNo.Size = New System.Drawing.Size(160, 48)
        Me.txtReqNo.TabIndex = 9
        Me.txtReqNo.TabStop = False
        Me.txtReqNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtReqNo.TrailingIcon = Nothing
        Me.txtReqNo.UseSystemPasswordChar = False
        '
        'lblRequesterDetail
        '
        Me.lblRequesterDetail.AutoSize = True
        Me.lblRequesterDetail.Depth = 0
        Me.lblRequesterDetail.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblRequesterDetail.Location = New System.Drawing.Point(24, 195)
        Me.lblRequesterDetail.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblRequesterDetail.Name = "lblRequesterDetail"
        Me.lblRequesterDetail.Size = New System.Drawing.Size(116, 19)
        Me.lblRequesterDetail.TabIndex = 10
        Me.lblRequesterDetail.Text = "Requester Detail"
        '
        'rbForMe
        '
        Me.rbForMe.AutoSize = True
        Me.rbForMe.Depth = 0
        Me.rbForMe.Location = New System.Drawing.Point(24, 225)
        Me.rbForMe.Margin = New System.Windows.Forms.Padding(0)
        Me.rbForMe.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.rbForMe.MouseState = MaterialSkin.MouseState.HOVER
        Me.rbForMe.Name = "rbForMe"
        Me.rbForMe.Ripple = True
        Me.rbForMe.Size = New System.Drawing.Size(84, 37)
        Me.rbForMe.TabIndex = 11
        Me.rbForMe.TabStop = True
        Me.rbForMe.Text = "For Me"
        Me.rbForMe.UseVisualStyleBackColor = True
        '
        'rbOnBehalf
        '
        Me.rbOnBehalf.AutoSize = True
        Me.rbOnBehalf.Depth = 0
        Me.rbOnBehalf.Location = New System.Drawing.Point(120, 225)
        Me.rbOnBehalf.Margin = New System.Windows.Forms.Padding(0)
        Me.rbOnBehalf.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.rbOnBehalf.MouseState = MaterialSkin.MouseState.HOVER
        Me.rbOnBehalf.Name = "rbOnBehalf"
        Me.rbOnBehalf.Ripple = True
        Me.rbOnBehalf.Size = New System.Drawing.Size(127, 37)
        Me.rbOnBehalf.TabIndex = 12
        Me.rbOnBehalf.TabStop = True
        Me.rbOnBehalf.Text = "On behalf of:"
        Me.rbOnBehalf.UseVisualStyleBackColor = True
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Depth = 0
        Me.lblUserName.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblUserName.Location = New System.Drawing.Point(270, 233)
        Me.lblUserName.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(81, 19)
        Me.lblUserName.TabIndex = 13
        Me.lblUserName.Text = "User_Name"
        '
        'cmbUserName
        '
        Me.cmbUserName.AutoResize = False
        Me.cmbUserName.BackColor = System.Drawing.Color.White
        Me.cmbUserName.Depth = 0
        Me.cmbUserName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbUserName.DropDownHeight = 174
        Me.cmbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserName.DropDownWidth = 121
        Me.cmbUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.cmbUserName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmbUserName.FormattingEnabled = True
        Me.cmbUserName.IntegralHeight = False
        Me.cmbUserName.ItemHeight = 43
        Me.cmbUserName.Location = New System.Drawing.Point(360, 220)
        Me.cmbUserName.MaxDropDownItems = 4
        Me.cmbUserName.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbUserName.Name = "cmbUserName"
        Me.cmbUserName.Size = New System.Drawing.Size(190, 49)
        Me.cmbUserName.StartIndex = 0
        Me.cmbUserName.TabIndex = 14
        '
        'lblManager
        '
        Me.lblManager.AutoSize = True
        Me.lblManager.Depth = 0
        Me.lblManager.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblManager.Location = New System.Drawing.Point(570, 233)
        Me.lblManager.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblManager.Name = "lblManager"
        Me.lblManager.Size = New System.Drawing.Size(64, 19)
        Me.lblManager.TabIndex = 15
        Me.lblManager.Text = "Manager"
        '
        'cmbManager
        '
        Me.cmbManager.AutoResize = False
        Me.cmbManager.BackColor = System.Drawing.Color.White
        Me.cmbManager.Depth = 0
        Me.cmbManager.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbManager.DropDownHeight = 174
        Me.cmbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbManager.DropDownWidth = 121
        Me.cmbManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.cmbManager.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmbManager.FormattingEnabled = True
        Me.cmbManager.IntegralHeight = False
        Me.cmbManager.ItemHeight = 43
        Me.cmbManager.Location = New System.Drawing.Point(645, 220)
        Me.cmbManager.MaxDropDownItems = 4
        Me.cmbManager.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbManager.Name = "cmbManager"
        Me.cmbManager.Size = New System.Drawing.Size(160, 49)
        Me.cmbManager.StartIndex = 0
        Me.cmbManager.TabIndex = 16
        '
        'btnCreateUser
        '
        Me.btnCreateUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCreateUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnCreateUser.Depth = 0
        Me.btnCreateUser.HighEmphasis = True
        Me.btnCreateUser.Icon = Nothing
        Me.btnCreateUser.Location = New System.Drawing.Point(820, 225)
        Me.btnCreateUser.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnCreateUser.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnCreateUser.Name = "btnCreateUser"
        Me.btnCreateUser.NoAccentTextColor = System.Drawing.Color.Empty
        Me.btnCreateUser.Size = New System.Drawing.Size(76, 36)
        Me.btnCreateUser.TabIndex = 17
        Me.btnCreateUser.Text = "Create"
        Me.btnCreateUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined
        Me.btnCreateUser.UseAccentColor = False
        Me.btnCreateUser.UseVisualStyleBackColor = True
        '
        'lblRequestDetail
        '
        Me.lblRequestDetail.AutoSize = True
        Me.lblRequestDetail.Depth = 0
        Me.lblRequestDetail.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblRequestDetail.Location = New System.Drawing.Point(24, 290)
        Me.lblRequestDetail.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblRequestDetail.Name = "lblRequestDetail"
        Me.lblRequestDetail.Size = New System.Drawing.Size(103, 19)
        Me.lblRequestDetail.TabIndex = 18
        Me.lblRequestDetail.Text = "Request Detail"
        '
        'lblReqCategory
        '
        Me.lblReqCategory.AutoSize = True
        Me.lblReqCategory.Depth = 0
        Me.lblReqCategory.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblReqCategory.Location = New System.Drawing.Point(24, 335)
        Me.lblReqCategory.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblReqCategory.Name = "lblReqCategory"
        Me.lblReqCategory.Size = New System.Drawing.Size(32, 19)
        Me.lblReqCategory.TabIndex = 19
        Me.lblReqCategory.Text = "Req:"
        '
        'cmbReqCategory
        '
        Me.cmbReqCategory.AutoResize = False
        Me.cmbReqCategory.BackColor = System.Drawing.Color.White
        Me.cmbReqCategory.Depth = 0
        Me.cmbReqCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbReqCategory.DropDownHeight = 174
        Me.cmbReqCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReqCategory.DropDownWidth = 121
        Me.cmbReqCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.cmbReqCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmbReqCategory.FormattingEnabled = True
        Me.cmbReqCategory.IntegralHeight = False
        Me.cmbReqCategory.ItemHeight = 43
        Me.cmbReqCategory.Location = New System.Drawing.Point(65, 320)
        Me.cmbReqCategory.MaxDropDownItems = 4
        Me.cmbReqCategory.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbReqCategory.Name = "cmbReqCategory"
        Me.cmbReqCategory.Size = New System.Drawing.Size(180, 49)
        Me.cmbReqCategory.StartIndex = 0
        Me.cmbReqCategory.TabIndex = 20
        '
        'lblDetails
        '
        Me.lblDetails.AutoSize = True
        Me.lblDetails.Depth = 0
        Me.lblDetails.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblDetails.Location = New System.Drawing.Point(260, 335)
        Me.lblDetails.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(50, 19)
        Me.lblDetails.TabIndex = 21
        Me.lblDetails.Text = "Details"
        '
        'cmbReqDetails
        '
        Me.cmbReqDetails.AutoResize = False
        Me.cmbReqDetails.BackColor = System.Drawing.Color.White
        Me.cmbReqDetails.Depth = 0
        Me.cmbReqDetails.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbReqDetails.DropDownHeight = 174
        Me.cmbReqDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReqDetails.DropDownWidth = 121
        Me.cmbReqDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.cmbReqDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmbReqDetails.FormattingEnabled = True
        Me.cmbReqDetails.IntegralHeight = False
        Me.cmbReqDetails.ItemHeight = 43
        Me.cmbReqDetails.Location = New System.Drawing.Point(320, 320)
        Me.cmbReqDetails.MaxDropDownItems = 4
        Me.cmbReqDetails.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbReqDetails.Name = "cmbReqDetails"
        Me.cmbReqDetails.Size = New System.Drawing.Size(180, 49)
        Me.cmbReqDetails.StartIndex = 0
        Me.cmbReqDetails.TabIndex = 22
        '
        'swPrivate
        '
        Me.swPrivate.AutoSize = True
        Me.swPrivate.Depth = 0
        Me.swPrivate.Location = New System.Drawing.Point(515, 326)
        Me.swPrivate.Margin = New System.Windows.Forms.Padding(0)
        Me.swPrivate.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.swPrivate.MouseState = MaterialSkin.MouseState.HOVER
        Me.swPrivate.Name = "swPrivate"
        Me.swPrivate.Ripple = True
        Me.swPrivate.Size = New System.Drawing.Size(107, 37)
        Me.swPrivate.TabIndex = 23
        Me.swPrivate.Text = "Private"
        Me.swPrivate.UseVisualStyleBackColor = True
        '
        'lblOther
        '
        Me.lblOther.AutoSize = True
        Me.lblOther.Depth = 0
        Me.lblOther.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblOther.Location = New System.Drawing.Point(635, 335)
        Me.lblOther.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblOther.Name = "lblOther"
        Me.lblOther.Size = New System.Drawing.Size(39, 19)
        Me.lblOther.TabIndex = 24
        Me.lblOther.Text = "Other"
        '
        'txtOther
        '
        Me.txtOther.AnimateReadOnly = False
        Me.txtOther.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.txtOther.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtOther.Depth = 0
        Me.txtOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtOther.HideSelection = True
        Me.txtOther.LeadingIcon = Nothing
        Me.txtOther.Location = New System.Drawing.Point(680, 320)
        Me.txtOther.MaxLength = 32767
        Me.txtOther.MouseState = MaterialSkin.MouseState.OUT
        Me.txtOther.Name = "txtOther"
        Me.txtOther.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtOther.PrefixSuffixText = Nothing
        Me.txtOther.ReadOnly = False
        Me.txtOther.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOther.SelectedText = ""
        Me.txtOther.SelectionLength = 0
        Me.txtOther.SelectionStart = 0
        Me.txtOther.ShortcutsEnabled = True
        Me.txtOther.Size = New System.Drawing.Size(130, 48)
        Me.txtOther.TabIndex = 25
        Me.txtOther.TabStop = False
        Me.txtOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtOther.TrailingIcon = Nothing
        Me.txtOther.UseSystemPasswordChar = False
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Depth = 0
        Me.lblRemarks.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblRemarks.Location = New System.Drawing.Point(24, 385)
        Me.lblRemarks.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(63, 19)
        Me.lblRemarks.TabIndex = 26
        Me.lblRemarks.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.AnimateReadOnly = False
        Me.txtRemarks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRemarks.Depth = 0
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtRemarks.HideSelection = True
        Me.txtRemarks.Location = New System.Drawing.Point(24, 410)
        Me.txtRemarks.MaxLength = 32767
        Me.txtRemarks.MouseState = MaterialSkin.MouseState.OUT
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRemarks.ReadOnly = False
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.SelectedText = ""
        Me.txtRemarks.SelectionLength = 0
        Me.txtRemarks.SelectionStart = 0
        Me.txtRemarks.ShortcutsEnabled = True
        Me.txtRemarks.Size = New System.Drawing.Size(875, 75)
        Me.txtRemarks.TabIndex = 27
        Me.txtRemarks.TabStop = False
        Me.txtRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtRemarks.UseSystemPasswordChar = False
        '
        'btnAddItem
        '
        Me.btnAddItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAddItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnAddItem.Depth = 0
        Me.btnAddItem.HighEmphasis = True
        Me.btnAddItem.Icon = Nothing
        Me.btnAddItem.Location = New System.Drawing.Point(825, 326)
        Me.btnAddItem.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnAddItem.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.NoAccentTextColor = System.Drawing.Color.Empty
        Me.btnAddItem.Size = New System.Drawing.Size(64, 36)
        Me.btnAddItem.TabIndex = 28
        Me.btnAddItem.Text = "Add"
        Me.btnAddItem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnAddItem.UseAccentColor = False
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'dgvTicketItems
        '
        Me.dgvTicketItems.AllowUserToAddRows = False
        Me.dgvTicketItems.AllowUserToDeleteRows = False
        Me.dgvTicketItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvTicketItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTicketItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReq, Me.colDetails, Me.colPrivate, Me.colOther, Me.colRemarks, Me.colStatus})
        Me.dgvTicketItems.Location = New System.Drawing.Point(24, 500)
        Me.dgvTicketItems.Name = "dgvTicketItems"
        Me.dgvTicketItems.ReadOnly = True
        Me.dgvTicketItems.RowHeadersVisible = False
        Me.dgvTicketItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTicketItems.Size = New System.Drawing.Size(875, 180)
        Me.dgvTicketItems.TabIndex = 29
        '
        'colReq
        '
        Me.colReq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colReq.HeaderText = "Req"
        Me.colReq.Name = "colReq"
        Me.colReq.ReadOnly = True
        '
        'colDetails
        '
        Me.colDetails.HeaderText = "Details"
        Me.colDetails.Name = "colDetails"
        Me.colDetails.ReadOnly = True
        '
        'colPrivate
        '
        Me.colPrivate.HeaderText = "Private"
        Me.colPrivate.Name = "colPrivate"
        Me.colPrivate.ReadOnly = True
        '
        'colOther
        '
        Me.colOther.HeaderText = "Other"
        Me.colOther.Name = "colOther"
        Me.colOther.ReadOnly = True
        '
        'colRemarks
        '
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.ReadOnly = True
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'ticket
        '
        Me.ClientSize = New System.Drawing.Size(925, 700)
        Me.Controls.Add(Me.dgvTicketItems)
        Me.Controls.Add(Me.cmbManager)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.btnAddItem)
        Me.Controls.Add(Me.txtOther)
        Me.Controls.Add(Me.lblOther)
        Me.Controls.Add(Me.swPrivate)
        Me.Controls.Add(Me.cmbReqDetails)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.cmbReqCategory)
        Me.Controls.Add(Me.lblReqCategory)
        Me.Controls.Add(Me.lblRequestDetail)
        Me.Controls.Add(Me.btnCreateUser)
        Me.Controls.Add(Me.lblManager)
        Me.Controls.Add(Me.cmbUserName)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.rbOnBehalf)
        Me.Controls.Add(Me.rbForMe)
        Me.Controls.Add(Me.lblRequesterDetail)
        Me.Controls.Add(Me.txtReqNo)
        Me.Controls.Add(Me.lblReqNo)
        Me.Controls.Add(Me.cmbSite)
        Me.Controls.Add(Me.lblSite)
        Me.Controls.Add(Me.cmbReqType)
        Me.Controls.Add(Me.lblReqType)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNew)
        Me.Name = "ticket"
        Me.Text = "New Request"
        CType(Me.dgvTicketItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    ' reset fields without touching user details
    Private Sub ClearFormExceptUser()
        cmbReqType.SelectedIndex = -1
        cmbReqType.Text = ""

        cmbSite.SelectedIndex = -1
        cmbSite.Text = ""

        cmbReqCategory.SelectedIndex = -1
        cmbReqCategory.Text = ""

        cmbReqDetails.Items.Clear()
        cmbReqDetails.SelectedIndex = -1
        cmbReqDetails.Text = ""

        txtOther.Clear()
        txtRemarks.Clear()
        swPrivate.Checked = False

        dgvTicketItems.Rows.Clear()
    End Sub

    ' initial form state before clicking create
    Private Sub SetFormInitialState()
        cmbReqType.Enabled = True
        cmbSite.Enabled = True
        rbForMe.Enabled = True
        rbOnBehalf.Enabled = True
        btnCreateUser.Enabled = True

        rbForMe.Checked = True
        ApplyRequesterOptionRules()

        ' disable bottom section
        cmbReqCategory.Enabled = False
        cmbReqDetails.Enabled = False
        swPrivate.Enabled = False
        txtOther.Enabled = False
        txtRemarks.Enabled = False
        btnAddItem.Enabled = False
        dgvTicketItems.Enabled = False
        btnSave.Enabled = False
    End Sub

    ' unlock grid and details after click create
    Private Sub SetFormCreatedState()
        cmbReqType.Enabled = False
        cmbSite.Enabled = False
        rbForMe.Enabled = False
        rbOnBehalf.Enabled = False
        cmbUserName.Enabled = False
        cmbManager.Enabled = False
        btnCreateUser.Enabled = False

        cmbReqCategory.Enabled = True
        cmbReqDetails.Enabled = True
        swPrivate.Enabled = True
        txtOther.Enabled = True
        txtRemarks.Enabled = True
        btnAddItem.Enabled = True
        dgvTicketItems.Enabled = True
        btnSave.Enabled = True
    End Sub

    ' check radio button change
    Private Sub ApplyRequesterOptionRules()
        If rbForMe.Checked Then
            cmbUserName.Enabled = False
            cmbManager.Enabled = False

            Dim resolvedUser As UserDetailDTO = GetLoggedInUserDTO()
            If resolvedUser IsNot Nothing Then
                cmbUserName.Text = resolvedUser.Name
                cmbManager.Text = resolvedUser.ManagerName
            Else
                If cmbUserName.Items.Count > 0 Then cmbUserName.SelectedIndex = 0
                UpdateManagerFromSelectedUser()
            End If

        ElseIf rbOnBehalf.Checked Then
            cmbUserName.Enabled = True
            cmbManager.Enabled = False
            cmbUserName.SelectedIndex = -1
            cmbUserName.Text = ""
            cmbManager.SelectedIndex = -1
            cmbManager.Text = ""

        Else
            cmbUserName.Enabled = False
            cmbManager.Enabled = False
            cmbUserName.SelectedIndex = -1
            cmbUserName.Text = ""
            cmbManager.SelectedIndex = -1
            cmbManager.Text = ""
        End If
    End Sub

    ' find current user by matching id or email
    Private Function GetLoggedInUserDTO() As UserDetailDTO
        If allUsers Is Nothing OrElse allUsers.Count = 0 Then Return Nothing

        Dim loginRaw As String = If(Not String.IsNullOrWhiteSpace(userid), userid, If(menuFrm IsNot Nothing AndAlso menuFrm.UserName IsNot Nothing, menuFrm.UserName.Text, "")).Trim()

        If String.IsNullOrWhiteSpace(loginRaw) Then Return Nothing

        Return allUsers.FirstOrDefault(Function(u) (Not String.IsNullOrEmpty(u.Email) AndAlso u.Email.Equals(loginRaw, StringComparison.OrdinalIgnoreCase)) OrElse
                                                   (Not String.IsNullOrEmpty(u.Name) AndAlso u.Name.Equals(loginRaw, StringComparison.OrdinalIgnoreCase)) OrElse
                                                   (loginRaw.IndexOf("@"c) > 0 AndAlso Not String.IsNullOrEmpty(u.Email) AndAlso u.Email.StartsWith(loginRaw.Split("@"c)(0), StringComparison.OrdinalIgnoreCase)))
    End Function

    ' update manager combobox when user changes
    Private Sub UpdateManagerFromSelectedUser()
        If cmbUserName.SelectedItem Is Nothing OrElse allUsers Is Nothing Then Return

        Dim selectedName As String = cmbUserName.SelectedItem.ToString().Trim()
        Dim userObj = allUsers.FirstOrDefault(Function(u) u.Name IsNot Nothing AndAlso u.Name.Trim().Equals(selectedName, StringComparison.OrdinalIgnoreCase))

        If userObj IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(userObj.ManagerName) Then
            Dim mgrName As String = userObj.ManagerName.Trim()

            If Not cmbManager.Items.Contains(mgrName) Then
                cmbManager.Items.Add(mgrName)
            End If

            cmbManager.SelectedItem = mgrName
            cmbManager.Refresh()
        Else
            If Not cmbManager.Items.Contains("None") Then cmbManager.Items.Add("None")
            cmbManager.SelectedItem = "None"
            cmbManager.Refresh()
        End If
    End Sub

    Private Sub cmbUserName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUserName.SelectedIndexChanged
        If rbOnBehalf.Checked Then
            UpdateManagerFromSelectedUser()
        End If
    End Sub

    Private Sub cmbUserName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbUserName.SelectionChangeCommitted
        If rbOnBehalf.Checked Then
            UpdateManagerFromSelectedUser()
        End If
    End Sub

    Private Sub ticket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim skinManager As MaterialSkinManager = MaterialSkinManager.Instance
        skinManager.AddFormToManage(Me)
        skinManager.Theme = MaterialSkinManager.Themes.LIGHT
        skinManager.ColorScheme = New ColorScheme(
            Primary.Blue800,
            Primary.Blue900,
            Primary.Blue500,
            Accent.Red400,
            TextShade.WHITE
        )

        SetupGridStyle()
        txtReqNo.ReadOnly = True

        LoadDropdownData()
        LoadNewRequestNumber()

        ClearFormExceptUser()
        SetFormInitialState()
    End Sub

    ' grid layout and colors
    Private Sub SetupGridStyle()
        dgvTicketItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTicketItems.Columns("colPrivate").Width = 80
        dgvTicketItems.Columns("colPrivate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        dgvTicketItems.Columns("colStatus").Width = 100
        dgvTicketItems.Columns("colStatus").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

        dgvTicketItems.EnableHeadersVisualStyles = False
        dgvTicketItems.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#002F9E")
        dgvTicketItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvTicketItems.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
        dgvTicketItems.ColumnHeadersHeight = 35

        dgvTicketItems.DefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
        dgvTicketItems.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE")
        dgvTicketItems.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvTicketItems.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8FAFC")
        dgvTicketItems.RowTemplate.Height = 30
    End Sub

    ' load combo data from api
    Private Sub LoadDropdownData()
        Try
            Dim client As New RestClient(conn & "/api/Ticket/GetLookups/")
            client.Timeout = -1
            Dim request As New RestRequest(Method.GET)
            request.AddHeader("Authorization", "Bearer " & access_token)

            Dim response As IRestResponse = client.Execute(request)
            If response.IsSuccessful AndAlso Not String.IsNullOrEmpty(response.Content) Then
                allLookups = JsonConvert.DeserializeObject(Of List(Of LookupItem))(response.Content)

                If allLookups IsNot Nothing Then
                    cmbReqType.Items.Clear()
                    For Each item In allLookups.Where(Function(x) x IsNot Nothing AndAlso x.Title = "Req Type" AndAlso Not String.IsNullOrWhiteSpace(x.Name))
                        cmbReqType.Items.Add(item.Name)
                    Next

                    cmbSite.Items.Clear()
                    For Each item In allLookups.Where(Function(x) x IsNot Nothing AndAlso x.Title = "Site" AndAlso Not String.IsNullOrWhiteSpace(x.Name))
                        cmbSite.Items.Add(item.Name)
                    Next

                    cmbReqCategory.Items.Clear()
                    For Each item In allLookups.Where(Function(x) x IsNot Nothing AndAlso x.Title = "Req" AndAlso Not String.IsNullOrWhiteSpace(x.Name))
                        cmbReqCategory.Items.Add(item.Name)
                    Next
                End If
            End If

            ' get employee records
            Dim clientUsers As New RestClient(conn & "/api/Ticket/GetUsers/")
            clientUsers.Timeout = -1
            Dim requestUsers As New RestRequest(Method.GET)
            requestUsers.AddHeader("Authorization", "Bearer " & access_token)

            Dim responseUsers As IRestResponse = clientUsers.Execute(requestUsers)
            If responseUsers.IsSuccessful AndAlso Not String.IsNullOrEmpty(responseUsers.Content) Then
                allUsers = JsonConvert.DeserializeObject(Of List(Of UserDetailDTO))(responseUsers.Content)

                If allUsers IsNot Nothing Then
                    cmbUserName.Items.Clear()
                    cmbManager.Items.Clear()

                    For Each u In allUsers
                        If Not String.IsNullOrWhiteSpace(u.Name) AndAlso Not cmbUserName.Items.Contains(u.Name) Then
                            cmbUserName.Items.Add(u.Name)
                        End If
                        If Not String.IsNullOrWhiteSpace(u.ManagerName) AndAlso Not cmbManager.Items.Contains(u.ManagerName) Then
                            cmbManager.Items.Add(u.ManagerName)
                        End If
                    Next

                    ApplyRequesterOptionRules()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Could not load dropdown options: " & ex.Message, "API Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' fill details dropdown when category is chosen
    Private Sub cmbReqCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReqCategory.SelectedIndexChanged
        If cmbReqCategory.SelectedItem Is Nothing OrElse allLookups Is Nothing Then Return

        Dim selectedCategory As String = cmbReqCategory.SelectedItem.ToString()
        cmbReqDetails.Items.Clear()

        Dim filtered = allLookups.Where(Function(x) x IsNot Nothing AndAlso Not String.IsNullOrEmpty(x.Title) AndAlso x.Title.Equals(selectedCategory, StringComparison.OrdinalIgnoreCase)).ToList()
        For Each item In filtered
            If Not String.IsNullOrWhiteSpace(item.Name) Then
                cmbReqDetails.Items.Add(item.Name)
            End If
        Next

        If cmbReqDetails.Items.Count > 0 Then
            cmbReqDetails.SelectedIndex = 0
        End If
    End Sub

    Private Sub rbForMe_CheckedChanged(sender As Object, e As EventArgs) Handles rbForMe.CheckedChanged
        ApplyRequesterOptionRules()
    End Sub

    Private Sub rbOnBehalf_CheckedChanged(sender As Object, e As EventArgs) Handles rbOnBehalf.CheckedChanged
        ApplyRequesterOptionRules()
    End Sub

    ' get next req number from database
    Private Sub LoadNewRequestNumber()
        Try
            Dim client As New RestClient(conn & "/api/Ticket/GetNextReqNo/")
            client.Timeout = -1
            Dim request As New RestRequest(Method.GET)
            request.AddHeader("Authorization", "Bearer " & access_token)

            Dim response As IRestResponse = client.Execute(request)
            If response.IsSuccessful AndAlso Not String.IsNullOrEmpty(response.Content) Then
                txtReqNo.Text = response.Content.Trim(""""c)
            Else
                txtReqNo.Text = "REQ-0001"
            End If
        Catch ex As Exception
            txtReqNo.Text = "REQ-0001"
        End Try
    End Sub

    Private Sub btnCreateUser_Click(sender As Object, e As EventArgs) Handles btnCreateUser.Click
        If cmbReqType.SelectedItem Is Nothing OrElse cmbSite.SelectedItem Is Nothing Then
            MessageBox.Show("Please select Request Type and Site first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SetFormCreatedState()
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If cmbReqCategory.SelectedItem Is Nothing OrElse cmbReqDetails.SelectedItem Is Nothing Then
            MessageBox.Show("Please select both a Request Category and Details.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        dgvTicketItems.Rows.Add(
            cmbReqCategory.Text,
            cmbReqDetails.Text,
            If(swPrivate.Checked, "Yes", "No"),
            txtOther.Text.Trim(),
            txtRemarks.Text.Trim(),
            "Pending"
        )

        ' clear fields for next entry
        txtOther.Clear()
        txtRemarks.Clear()
        swPrivate.Checked = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtReqNo.Text) Then
            MessageBox.Show("Request Number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dgvTicketItems.Rows.Count = 0 Then
            MessageBox.Show("Please add at least one line item before saving.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' figure out who is submitting
        Dim currentLoggedInUser As String = ""
        Dim resolvedUser As UserDetailDTO = GetLoggedInUserDTO()

        If resolvedUser IsNot Nothing Then
            currentLoggedInUser = resolvedUser.Name
        Else
            Dim loginRaw As String = If(Not String.IsNullOrWhiteSpace(userid), userid, If(menuFrm IsNot Nothing AndAlso menuFrm.UserName IsNot Nothing, menuFrm.UserName.Text, "")).Trim()
            currentLoggedInUser = If(Not String.IsNullOrWhiteSpace(loginRaw), loginRaw, Environment.UserName)
        End If

        Dim header As New RequestHeaderDTO With {
            .Req_No = txtReqNo.Text.Trim(),
            .Req_Type = cmbReqType.Text,
            .Site = cmbSite.Text,
            .Requester_Option = If(rbForMe.Checked, "For Me", "On behalf of"),
            .User_Name = cmbUserName.Text,
            .Manager = cmbManager.Text,
            .Created_By = currentLoggedInUser,
            .DetailsList = New List(Of RequestDetailDTO)()
        }

        For Each row As DataGridViewRow In dgvTicketItems.Rows
            If Not row.IsNewRow Then
                header.DetailsList.Add(New RequestDetailDTO With {
                    .Req_No = header.Req_No,
                    .Req = Convert.ToString(row.Cells("colReq").Value),
                    .Details = Convert.ToString(row.Cells("colDetails").Value),
                    .Private = (Convert.ToString(row.Cells("colPrivate").Value) = "Yes"),
                    .Other = Convert.ToString(row.Cells("colOther").Value),
                    .Remarks = Convert.ToString(row.Cells("colRemarks").Value),
                    .Status = If(String.IsNullOrEmpty(Convert.ToString(row.Cells("colStatus").Value)), "Pending", Convert.ToString(row.Cells("colStatus").Value))
                })
            End If
        Next

        Try
            Dim client As New RestClient(conn & "/api/Ticket/SaveTicket/")
            client.Timeout = -1
            Dim request As New RestRequest(Method.POST)
            request.AddHeader("Authorization", "Bearer " & access_token)
            request.AddHeader("Content-Type", "application/json")

            Dim jsonBody As String = JsonConvert.SerializeObject(header)
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody)

            Dim response As IRestResponse = client.Execute(request)
            If response.IsSuccessful Then
                MessageBox.Show("Ticket " & header.Req_No & " has been saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnNew.PerformClick()
            Else
                MessageBox.Show("Failed to save ticket: " & response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("API Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearFormExceptUser()
        SetFormInitialState()
        LoadNewRequestNumber()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub cmbReqDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReqDetails.SelectedIndexChanged

    End Sub

    Private Sub cmbSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSite.SelectedIndexChanged

    End Sub

    Private Sub lblReqType_Click(sender As Object, e As EventArgs) Handles lblReqType.Click

    End Sub
End Class