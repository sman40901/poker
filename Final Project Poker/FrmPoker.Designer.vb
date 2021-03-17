<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPoker
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
        Me.GrpDraw = New System.Windows.Forms.Panel()
        Me.chkDeal5 = New System.Windows.Forms.CheckBox()
        Me.ChkDeal4 = New System.Windows.Forms.CheckBox()
        Me.ChkDeal3 = New System.Windows.Forms.CheckBox()
        Me.chkDeal2 = New System.Windows.Forms.CheckBox()
        Me.btnStay = New System.Windows.Forms.Button()
        Me.btnDraw = New System.Windows.Forms.Button()
        Me.chkDeal1 = New System.Windows.Forms.CheckBox()
        Me.GrpDeal = New System.Windows.Forms.Panel()
        Me.btnDeal = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lstCards = New System.Windows.Forms.ListBox()
        Me.GrpPlayAgain = New System.Windows.Forms.Panel()
        Me.btnPlayAgain = New System.Windows.Forms.Button()
        Me.btnPlayGame = New System.Windows.Forms.Button()
        Me.GrpPlayGame = New System.Windows.Forms.Panel()
        Me.GrpDraw.SuspendLayout()
        Me.GrpDeal.SuspendLayout()
        Me.GrpPlayAgain.SuspendLayout()
        Me.GrpPlayGame.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpDraw
        '
        Me.GrpDraw.Controls.Add(Me.chkDeal5)
        Me.GrpDraw.Controls.Add(Me.ChkDeal4)
        Me.GrpDraw.Controls.Add(Me.ChkDeal3)
        Me.GrpDraw.Controls.Add(Me.chkDeal2)
        Me.GrpDraw.Controls.Add(Me.btnStay)
        Me.GrpDraw.Controls.Add(Me.btnDraw)
        Me.GrpDraw.Controls.Add(Me.chkDeal1)
        Me.GrpDraw.Location = New System.Drawing.Point(2, 29)
        Me.GrpDraw.Name = "GrpDraw"
        Me.GrpDraw.Size = New System.Drawing.Size(471, 210)
        Me.GrpDraw.TabIndex = 5
        '
        'chkDeal5
        '
        Me.chkDeal5.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkDeal5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.chkDeal5.Location = New System.Drawing.Point(370, 19)
        Me.chkDeal5.Name = "chkDeal5"
        Me.chkDeal5.Size = New System.Drawing.Size(81, 92)
        Me.chkDeal5.TabIndex = 10
        Me.chkDeal5.UseVisualStyleBackColor = False
        '
        'ChkDeal4
        '
        Me.ChkDeal4.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkDeal4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ChkDeal4.Location = New System.Drawing.Point(283, 19)
        Me.ChkDeal4.Name = "ChkDeal4"
        Me.ChkDeal4.Size = New System.Drawing.Size(81, 92)
        Me.ChkDeal4.TabIndex = 9
        Me.ChkDeal4.UseVisualStyleBackColor = False
        '
        'ChkDeal3
        '
        Me.ChkDeal3.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkDeal3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ChkDeal3.Location = New System.Drawing.Point(196, 19)
        Me.ChkDeal3.Name = "ChkDeal3"
        Me.ChkDeal3.Size = New System.Drawing.Size(81, 92)
        Me.ChkDeal3.TabIndex = 8
        Me.ChkDeal3.UseVisualStyleBackColor = False
        '
        'chkDeal2
        '
        Me.chkDeal2.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkDeal2.BackColor = System.Drawing.Color.Red
        Me.chkDeal2.Location = New System.Drawing.Point(109, 19)
        Me.chkDeal2.Name = "chkDeal2"
        Me.chkDeal2.Size = New System.Drawing.Size(81, 92)
        Me.chkDeal2.TabIndex = 7
        Me.chkDeal2.UseVisualStyleBackColor = False
        '
        'btnStay
        '
        Me.btnStay.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnStay.ForeColor = System.Drawing.Color.Black
        Me.btnStay.Location = New System.Drawing.Point(323, 175)
        Me.btnStay.Name = "btnStay"
        Me.btnStay.Size = New System.Drawing.Size(75, 23)
        Me.btnStay.TabIndex = 6
        Me.btnStay.Text = "Stay"
        Me.btnStay.UseVisualStyleBackColor = False
        '
        'btnDraw
        '
        Me.btnDraw.BackColor = System.Drawing.Color.Green
        Me.btnDraw.ForeColor = System.Drawing.Color.Yellow
        Me.btnDraw.Location = New System.Drawing.Point(34, 175)
        Me.btnDraw.Name = "btnDraw"
        Me.btnDraw.Size = New System.Drawing.Size(75, 23)
        Me.btnDraw.TabIndex = 5
        Me.btnDraw.Text = "Draw"
        Me.btnDraw.UseVisualStyleBackColor = False
        '
        'chkDeal1
        '
        Me.chkDeal1.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkDeal1.BackColor = System.Drawing.Color.Red
        Me.chkDeal1.Location = New System.Drawing.Point(22, 19)
        Me.chkDeal1.Name = "chkDeal1"
        Me.chkDeal1.Size = New System.Drawing.Size(81, 92)
        Me.chkDeal1.TabIndex = 0
        Me.chkDeal1.UseVisualStyleBackColor = False
        '
        'GrpDeal
        '
        Me.GrpDeal.Controls.Add(Me.btnDeal)
        Me.GrpDeal.Location = New System.Drawing.Point(22, 373)
        Me.GrpDeal.Name = "GrpDeal"
        Me.GrpDeal.Size = New System.Drawing.Size(112, 65)
        Me.GrpDeal.TabIndex = 6
        '
        'btnDeal
        '
        Me.btnDeal.Location = New System.Drawing.Point(9, 33)
        Me.btnDeal.Name = "btnDeal"
        Me.btnDeal.Size = New System.Drawing.Size(75, 23)
        Me.btnDeal.TabIndex = 0
        Me.btnDeal.Text = "Deal"
        Me.btnDeal.UseVisualStyleBackColor = True
        '
        'BtnExit
        '
        Me.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnExit.Location = New System.Drawing.Point(362, 406)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 1
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(-1, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(74, 26)
        Me.lblID.TabIndex = 7
        Me.lblID.Text = "Steven Tirpak" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CS 115"
        '
        'lstCards
        '
        Me.lstCards.FormattingEnabled = True
        Me.lstCards.Location = New System.Drawing.Point(479, 8)
        Me.lstCards.Name = "lstCards"
        Me.lstCards.Size = New System.Drawing.Size(291, 355)
        Me.lstCards.TabIndex = 8
        '
        'GrpPlayAgain
        '
        Me.GrpPlayAgain.Controls.Add(Me.btnPlayAgain)
        Me.GrpPlayAgain.Location = New System.Drawing.Point(186, 373)
        Me.GrpPlayAgain.Name = "GrpPlayAgain"
        Me.GrpPlayAgain.Size = New System.Drawing.Size(112, 65)
        Me.GrpPlayAgain.TabIndex = 7
        '
        'btnPlayAgain
        '
        Me.btnPlayAgain.Location = New System.Drawing.Point(9, 33)
        Me.btnPlayAgain.Name = "btnPlayAgain"
        Me.btnPlayAgain.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayAgain.TabIndex = 0
        Me.btnPlayAgain.Text = "Play Again"
        Me.btnPlayAgain.UseVisualStyleBackColor = True
        '
        'btnPlayGame
        '
        Me.btnPlayGame.Location = New System.Drawing.Point(14, 22)
        Me.btnPlayGame.Name = "btnPlayGame"
        Me.btnPlayGame.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayGame.TabIndex = 0
        Me.btnPlayGame.Text = "PLay Game"
        Me.btnPlayGame.UseVisualStyleBackColor = True
        '
        'GrpPlayGame
        '
        Me.GrpPlayGame.Controls.Add(Me.btnPlayGame)
        Me.GrpPlayGame.Location = New System.Drawing.Point(22, 307)
        Me.GrpPlayGame.Name = "GrpPlayGame"
        Me.GrpPlayGame.Size = New System.Drawing.Size(109, 60)
        Me.GrpPlayGame.TabIndex = 9
        '
        'FrmPoker
        '
        Me.AcceptButton = Me.btnDeal
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnExit
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GrpPlayGame)
        Me.Controls.Add(Me.GrpPlayAgain)
        Me.Controls.Add(Me.lstCards)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.GrpDeal)
        Me.Controls.Add(Me.GrpDraw)
        Me.Name = "FrmPoker"
        Me.Text = "Poker Game"
        Me.GrpDraw.ResumeLayout(False)
        Me.GrpDeal.ResumeLayout(False)
        Me.GrpPlayAgain.ResumeLayout(False)
        Me.GrpPlayGame.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrpDraw As Panel
    Friend WithEvents GrpDeal As Panel
    Friend WithEvents btnDeal As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents lblID As Label
    Friend WithEvents lstCards As ListBox
    Friend WithEvents chkDeal1 As CheckBox
    Friend WithEvents btnStay As Button
    Friend WithEvents btnDraw As Button
    Friend WithEvents GrpPlayAgain As Panel
    Friend WithEvents btnPlayAgain As Button
    Friend WithEvents chkDeal5 As CheckBox
    Friend WithEvents ChkDeal4 As CheckBox
    Friend WithEvents ChkDeal3 As CheckBox
    Friend WithEvents chkDeal2 As CheckBox
    Friend WithEvents btnPlayGame As Button
    Friend WithEvents GrpPlayGame As Panel
End Class
