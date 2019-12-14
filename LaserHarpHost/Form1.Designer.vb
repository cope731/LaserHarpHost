<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Path1_0 = New System.Windows.Forms.TextBox()
        Me.Path1_1 = New System.Windows.Forms.TextBox()
        Me.Path1_2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Path2_2 = New System.Windows.Forms.TextBox()
        Me.Path2_1 = New System.Windows.Forms.TextBox()
        Me.Path2_0 = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Path3_2 = New System.Windows.Forms.TextBox()
        Me.Path3_1 = New System.Windows.Forms.TextBox()
        Me.Path3_0 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Path4_2 = New System.Windows.Forms.TextBox()
        Me.Path4_1 = New System.Windows.Forms.TextBox()
        Me.Path4_0 = New System.Windows.Forms.TextBox()
        Me.KeyIn = New System.Windows.Forms.Button()
        Me.cmbPortName = New System.Windows.Forms.ComboBox()
        Me.cmbBaudRate = New System.Windows.Forms.ComboBox()
        Me.cmbHandShake = New System.Windows.Forms.ComboBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Path1_0
        '
        Me.Path1_0.Location = New System.Drawing.Point(3, 3)
        Me.Path1_0.Name = "Path1_0"
        Me.Path1_0.ReadOnly = True
        Me.Path1_0.Size = New System.Drawing.Size(165, 25)
        Me.Path1_0.TabIndex = 0
        '
        'Path1_1
        '
        Me.Path1_1.Location = New System.Drawing.Point(3, 34)
        Me.Path1_1.Name = "Path1_1"
        Me.Path1_1.ReadOnly = True
        Me.Path1_1.Size = New System.Drawing.Size(165, 25)
        Me.Path1_1.TabIndex = 1
        '
        'Path1_2
        '
        Me.Path1_2.Location = New System.Drawing.Point(3, 65)
        Me.Path1_2.Name = "Path1_2"
        Me.Path1_2.ReadOnly = True
        Me.Path1_2.Size = New System.Drawing.Size(165, 25)
        Me.Path1_2.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(20, 62)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 43)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "1"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Path1_2)
        Me.Panel1.Controls.Add(Me.Path1_1)
        Me.Panel1.Controls.Add(Me.Path1_0)
        Me.Panel1.Location = New System.Drawing.Point(20, 111)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(173, 95)
        Me.Panel1.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button2.Location = New System.Drawing.Point(206, 62)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(173, 43)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "2"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button3.Location = New System.Drawing.Point(385, 62)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(173, 43)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Path2_2)
        Me.Panel2.Controls.Add(Me.Path2_1)
        Me.Panel2.Controls.Add(Me.Path2_0)
        Me.Panel2.Location = New System.Drawing.Point(206, 111)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(173, 95)
        Me.Panel2.TabIndex = 6
        '
        'Path2_2
        '
        Me.Path2_2.Location = New System.Drawing.Point(3, 65)
        Me.Path2_2.Name = "Path2_2"
        Me.Path2_2.ReadOnly = True
        Me.Path2_2.Size = New System.Drawing.Size(165, 25)
        Me.Path2_2.TabIndex = 2
        '
        'Path2_1
        '
        Me.Path2_1.Location = New System.Drawing.Point(3, 34)
        Me.Path2_1.Name = "Path2_1"
        Me.Path2_1.ReadOnly = True
        Me.Path2_1.Size = New System.Drawing.Size(165, 25)
        Me.Path2_1.TabIndex = 1
        '
        'Path2_0
        '
        Me.Path2_0.Location = New System.Drawing.Point(3, 3)
        Me.Path2_0.Name = "Path2_0"
        Me.Path2_0.ReadOnly = True
        Me.Path2_0.Size = New System.Drawing.Size(165, 25)
        Me.Path2_0.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Path3_2)
        Me.Panel3.Controls.Add(Me.Path3_1)
        Me.Panel3.Controls.Add(Me.Path3_0)
        Me.Panel3.Location = New System.Drawing.Point(385, 111)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(173, 95)
        Me.Panel3.TabIndex = 7
        '
        'Path3_2
        '
        Me.Path3_2.Location = New System.Drawing.Point(3, 65)
        Me.Path3_2.Name = "Path3_2"
        Me.Path3_2.ReadOnly = True
        Me.Path3_2.Size = New System.Drawing.Size(165, 25)
        Me.Path3_2.TabIndex = 2
        '
        'Path3_1
        '
        Me.Path3_1.Location = New System.Drawing.Point(3, 34)
        Me.Path3_1.Name = "Path3_1"
        Me.Path3_1.ReadOnly = True
        Me.Path3_1.Size = New System.Drawing.Size(165, 25)
        Me.Path3_1.TabIndex = 1
        '
        'Path3_0
        '
        Me.Path3_0.Location = New System.Drawing.Point(3, 3)
        Me.Path3_0.Name = "Path3_0"
        Me.Path3_0.ReadOnly = True
        Me.Path3_0.Size = New System.Drawing.Size(165, 25)
        Me.Path3_0.TabIndex = 0
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button4.Location = New System.Drawing.Point(564, 62)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(173, 43)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "4"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Path4_2)
        Me.Panel4.Controls.Add(Me.Path4_1)
        Me.Panel4.Controls.Add(Me.Path4_0)
        Me.Panel4.Location = New System.Drawing.Point(564, 111)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(173, 95)
        Me.Panel4.TabIndex = 7
        '
        'Path4_2
        '
        Me.Path4_2.Location = New System.Drawing.Point(3, 65)
        Me.Path4_2.Name = "Path4_2"
        Me.Path4_2.ReadOnly = True
        Me.Path4_2.Size = New System.Drawing.Size(165, 25)
        Me.Path4_2.TabIndex = 2
        '
        'Path4_1
        '
        Me.Path4_1.Location = New System.Drawing.Point(3, 34)
        Me.Path4_1.Name = "Path4_1"
        Me.Path4_1.ReadOnly = True
        Me.Path4_1.Size = New System.Drawing.Size(165, 25)
        Me.Path4_1.TabIndex = 1
        '
        'Path4_0
        '
        Me.Path4_0.Location = New System.Drawing.Point(3, 3)
        Me.Path4_0.Name = "Path4_0"
        Me.Path4_0.ReadOnly = True
        Me.Path4_0.Size = New System.Drawing.Size(165, 25)
        Me.Path4_0.TabIndex = 0
        '
        'KeyIn
        '
        Me.KeyIn.Location = New System.Drawing.Point(20, 12)
        Me.KeyIn.Name = "KeyIn"
        Me.KeyIn.Size = New System.Drawing.Size(717, 44)
        Me.KeyIn.TabIndex = 9
        Me.KeyIn.Text = "数字ボタンから変更"
        Me.KeyIn.UseVisualStyleBackColor = True
        '
        'cmbPortName
        '
        Me.cmbPortName.FormattingEnabled = True
        Me.cmbPortName.Location = New System.Drawing.Point(11, 434)
        Me.cmbPortName.Name = "cmbPortName"
        Me.cmbPortName.Size = New System.Drawing.Size(187, 26)
        Me.cmbPortName.TabIndex = 10
        '
        'cmbBaudRate
        '
        Me.cmbBaudRate.FormattingEnabled = True
        Me.cmbBaudRate.Location = New System.Drawing.Point(204, 434)
        Me.cmbBaudRate.Name = "cmbBaudRate"
        Me.cmbBaudRate.Size = New System.Drawing.Size(187, 26)
        Me.cmbBaudRate.TabIndex = 11
        '
        'cmbHandShake
        '
        Me.cmbHandShake.FormattingEnabled = True
        Me.cmbHandShake.Location = New System.Drawing.Point(397, 434)
        Me.cmbHandShake.Name = "cmbHandShake"
        Me.cmbHandShake.Size = New System.Drawing.Size(187, 26)
        Me.cmbHandShake.TabIndex = 12
        '
        'SerialPort1
        '
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(777, 434)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(30, 25)
        Me.TextBox1.TabIndex = 13
        '
        'ConnectButton
        '
        Me.ConnectButton.Location = New System.Drawing.Point(590, 429)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(181, 35)
        Me.ConnectButton.TabIndex = 14
        Me.ConnectButton.Text = "接続"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 472)
        Me.Controls.Add(Me.ConnectButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmbHandShake)
        Me.Controls.Add(Me.cmbBaudRate)
        Me.Controls.Add(Me.cmbPortName)
        Me.Controls.Add(Me.KeyIn)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Path1_0 As TextBox
    Friend WithEvents Path1_1 As TextBox
    Friend WithEvents Path1_2 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Path2_2 As TextBox
    Friend WithEvents Path2_1 As TextBox
    Friend WithEvents Path2_0 As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Path3_2 As TextBox
    Friend WithEvents Path3_1 As TextBox
    Friend WithEvents Path3_0 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Path4_2 As TextBox
    Friend WithEvents Path4_1 As TextBox
    Friend WithEvents Path4_0 As TextBox
    Friend WithEvents KeyIn As Button
    Friend WithEvents cmbBaudRate As ComboBox
    Friend WithEvents cmbHandShake As ComboBox
    Private WithEvents cmbPortName As ComboBox
    Friend WithEvents SerialPort1 As SerialPort
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ConnectButton As Button
End Class
