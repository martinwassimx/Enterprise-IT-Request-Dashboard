<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Employees
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FirstName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtSecoendName = New System.Windows.Forms.TextBox()
        Me.SecoendName = New System.Windows.Forms.Label()
        Me.txtNationalID = New System.Windows.Forms.TextBox()
        Me.NationalID = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Phone = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Address = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Title = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Serial = New System.Windows.Forms.Label()
        Me.txtMail = New System.Windows.Forms.TextBox()
        Me.Mail = New System.Windows.Forms.Label()
        Me.BirthDate = New System.Windows.Forms.Label()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearchID = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblSerialInfo = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 45)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Employe"
        '
        'FirstName
        '
        Me.FirstName.AutoSize = True
        Me.FirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstName.Location = New System.Drawing.Point(34, 140)
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(101, 24)
        Me.FirstName.TabIndex = 3
        Me.FirstName.Text = "First Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(157, 140)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(154, 20)
        Me.txtFirstName.TabIndex = 4
        '
        'txtSecoendName
        '
        Me.txtSecoendName.Location = New System.Drawing.Point(592, 138)
        Me.txtSecoendName.Name = "txtSecoendName"
        Me.txtSecoendName.Size = New System.Drawing.Size(154, 20)
        Me.txtSecoendName.TabIndex = 6
        '
        'SecoendName
        '
        Me.SecoendName.AutoSize = True
        Me.SecoendName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecoendName.Location = New System.Drawing.Point(443, 138)
        Me.SecoendName.Name = "SecoendName"
        Me.SecoendName.Size = New System.Drawing.Size(143, 24)
        Me.SecoendName.TabIndex = 5
        Me.SecoendName.Text = "Secoend Name"
        '
        'txtNationalID
        '
        Me.txtNationalID.Location = New System.Drawing.Point(157, 198)
        Me.txtNationalID.Name = "txtNationalID"
        Me.txtNationalID.Size = New System.Drawing.Size(154, 20)
        Me.txtNationalID.TabIndex = 8
        '
        'NationalID
        '
        Me.NationalID.AutoSize = True
        Me.NationalID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NationalID.Location = New System.Drawing.Point(34, 198)
        Me.NationalID.Name = "NationalID"
        Me.NationalID.Size = New System.Drawing.Size(100, 24)
        Me.NationalID.TabIndex = 7
        Me.NationalID.Text = "National ID"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(592, 196)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(154, 20)
        Me.txtPhone.TabIndex = 10
        '
        'Phone
        '
        Me.Phone.AutoSize = True
        Me.Phone.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phone.Location = New System.Drawing.Point(443, 196)
        Me.Phone.Name = "Phone"
        Me.Phone.Size = New System.Drawing.Size(140, 24)
        Me.Phone.TabIndex = 9
        Me.Phone.Text = "Phone Number"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(157, 258)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(154, 20)
        Me.txtAddress.TabIndex = 12
        '
        'Address
        '
        Me.Address.AutoSize = True
        Me.Address.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address.Location = New System.Drawing.Point(34, 258)
        Me.Address.Name = "Address"
        Me.Address.Size = New System.Drawing.Size(80, 24)
        Me.Address.TabIndex = 11
        Me.Address.Text = "Address"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(592, 256)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(154, 20)
        Me.txtTitle.TabIndex = 14
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.Location = New System.Drawing.Point(443, 256)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(45, 24)
        Me.Title.TabIndex = 13
        Me.Title.Text = "Title"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(157, 316)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(154, 20)
        Me.txtStatus.TabIndex = 16
        '
        'Serial
        '
        Me.Serial.AutoSize = True
        Me.Serial.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial.Location = New System.Drawing.Point(34, 316)
        Me.Serial.Name = "Serial"
        Me.Serial.Size = New System.Drawing.Size(57, 24)
        Me.Serial.TabIndex = 15
        Me.Serial.Text = "Serial"
        '
        'txtMail
        '
        Me.txtMail.Location = New System.Drawing.Point(592, 318)
        Me.txtMail.Name = "txtMail"
        Me.txtMail.Size = New System.Drawing.Size(154, 20)
        Me.txtMail.TabIndex = 18
        '
        'Mail
        '
        Me.Mail.AutoSize = True
        Me.Mail.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mail.Location = New System.Drawing.Point(443, 318)
        Me.Mail.Name = "Mail"
        Me.Mail.Size = New System.Drawing.Size(44, 24)
        Me.Mail.TabIndex = 17
        Me.Mail.Text = "Mail"
        '
        'BirthDate
        '
        Me.BirthDate.AutoSize = True
        Me.BirthDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BirthDate.Location = New System.Drawing.Point(34, 370)
        Me.BirthDate.Name = "BirthDate"
        Me.BirthDate.Size = New System.Drawing.Size(85, 24)
        Me.BirthDate.TabIndex = 19
        Me.BirthDate.Text = "BirthDate"
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Location = New System.Drawing.Point(157, 374)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpBirthDate.TabIndex = 20
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.Control
        Me.btnAdd.Location = New System.Drawing.Point(51, 441)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(148, 53)
        Me.btnAdd.TabIndex = 21
        Me.btnAdd.Text = "Add New Empolye"
        Me.btnAdd.UseMnemonic = False
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.TEST.My.Resources.Resources.nsf
        Me.PictureBox2.Location = New System.Drawing.Point(592, -28)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(180, 160)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.Control
        Me.btnUpdate.Location = New System.Drawing.Point(324, 442)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(148, 51)
        Me.btnUpdate.TabIndex = 23
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Red
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.Control
        Me.btnDelete.Location = New System.Drawing.Point(592, 440)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(148, 53)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Cross
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(319, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 25)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Enter the ID"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSearch.Location = New System.Drawing.Point(336, 75)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(96, 33)
        Me.btnSearch.TabIndex = 27
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearchID
        '
        Me.txtSearchID.Location = New System.Drawing.Point(324, 49)
        Me.txtSearchID.Name = "txtSearchID"
        Me.txtSearchID.Size = New System.Drawing.Size(123, 20)
        Me.txtSearchID.TabIndex = 26
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.DarkGreen
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRefresh.Location = New System.Drawing.Point(39, 75)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(96, 33)
        Me.btnRefresh.TabIndex = 29
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'lblSerialInfo
        '
        Me.lblSerialInfo.AutoSize = True
        Me.lblSerialInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialInfo.Location = New System.Drawing.Point(393, 374)
        Me.lblSerialInfo.Name = "lblSerialInfo"
        Me.lblSerialInfo.Size = New System.Drawing.Size(0, 24)
        Me.lblSerialInfo.TabIndex = 30
        '
        'Employees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 531)
        Me.Controls.Add(Me.lblSerialInfo)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearchID)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.SecoendName)
        Me.Controls.Add(Me.txtSecoendName)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dtpBirthDate)
        Me.Controls.Add(Me.BirthDate)
        Me.Controls.Add(Me.txtMail)
        Me.Controls.Add(Me.Mail)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Serial)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Address)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.Phone)
        Me.Controls.Add(Me.txtNationalID)
        Me.Controls.Add(Me.NationalID)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.FirstName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Employees"
        Me.Text = "Employees"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents FirstName As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtSecoendName As TextBox
    Friend WithEvents SecoendName As Label
    Friend WithEvents txtNationalID As TextBox
    Friend WithEvents NationalID As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents Phone As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Address As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents Title As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Serial As Label
    Friend WithEvents txtMail As TextBox
    Friend WithEvents Mail As Label
    Friend WithEvents BirthDate As Label
    Friend WithEvents dtpBirthDate As DateTimePicker
    Friend WithEvents btnAdd As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearchID As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblSerialInfo As Label
End Class
