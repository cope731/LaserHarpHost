Imports System
Imports System.IO.Ports
Imports System.Text

Public Class Form1

    Private Class BuadRateItem
        Inherits Object

        Private m_name As String = ""
        Private m_value As Integer = 0

        '表示名称
        Public Property NAME() As String
            Set(ByVal value As String)
                m_name = value
            End Set
            Get
                Return m_name
            End Get
        End Property

        'ボーレート設定値.
        Public Property BAUDRATE() As Integer
            Set(ByVal value As Integer)
                m_value = value
            End Set
            Get
                Return m_value
            End Get
        End Property

        'コンボボックス表示用の文字列取得関数.
        Public Overrides Function ToString() As String
            Return m_name
        End Function

    End Class

    Private Class HandShakeItem
        Inherits Object

        Private m_name As String = ""
        Private m_value As Handshake = Handshake.None

        '表示名称
        Public Property NAME() As String
            Set(ByVal value As String)
                m_name = value
            End Set
            Get
                Return m_name
            End Get
        End Property

        '制御プロトコル設定値.
        Public Property HANDSHAKE() As Handshake
            Set(ByVal value As Handshake)
                m_value = value
            End Set
            Get
                Return m_value
            End Get
        End Property

        'コンボボックス表示用の文字列取得関数.
        Public Overrides Function ToString() As String
            Return m_name
        End Function

    End Class

    Private Delegate Sub Delegate_RcvDataToTextBox(data As String)

    Dim ofd As New OpenFileDialog()
    Dim validMode As New Byte
    Dim pathList(9, 2) As String
    Dim lhlList(4) As String
    'wav再生用WMP
    Dim mediaPlayer0 As New WMPLib.WindowsMediaPlayer()
    Dim mediaPlayer1 As New WMPLib.WindowsMediaPlayer()
    Dim mediaPlayer2 As New WMPLib.WindowsMediaPlayer()


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModeChange(1) 'モードの初期化
        LoadingFile.Text = ""

        '「ファイルを開く」ダイアログ初期設定

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        ofd.FileName = ""
        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        ofd.InitialDirectory = ""
        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = "waveファイル(*.wav;*.wave)|*.wav;*.wave|すべてのファイル(*.*)|*.*"
        '[ファイルの種類]ではじめに選択されるものを指定する
        '2番目の「すべてのファイル」が選択されているようにする
        ofd.FilterIndex = 1
        'タイトルを設定する
        ofd.Title = "開くファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True
        '存在しないファイルの名前が指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckFileExists = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckPathExists = True


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'シリアル入力関連　設定初期化

        '利用可能なシリアルポート名の配列を取得する.
        Dim PortList As String()
        PortList = SerialPort.GetPortNames()

        cmbPortName.Items.Clear()

        'シリアルポート名をコンボボックスにセットする.
        Dim PortName As String
        For Each PortName In PortList
            cmbPortName.Items.Add(PortName)
        Next PortName

        If cmbPortName.Items.Count > 0 Then
            cmbPortName.SelectedIndex = 0
        End If

        cmbBaudRate.Items.Clear()
        'ボーレート選択コンボボックスに選択項目をセットする.
        Dim baud As BuadRateItem
        baud = New BuadRateItem
        baud.NAME = "4800bps"
        baud.BAUDRATE = 4800
        cmbBaudRate.Items.Add(baud)

        baud = New BuadRateItem
        baud.NAME = "9600bps"
        baud.BAUDRATE = 9600
        cmbBaudRate.Items.Add(baud)

        baud = New BuadRateItem
        baud.NAME = "19200bps"
        baud.BAUDRATE = 19200
        cmbBaudRate.Items.Add(baud)

        baud = New BuadRateItem
        baud.NAME = "115200bps"
        baud.BAUDRATE = 115200
        cmbBaudRate.Items.Add(baud)
        cmbBaudRate.SelectedIndex = 1

        cmbHandShake.Items.Clear()

        'フロー制御選択コンボボックスに選択項目をセットする.
        Dim ctrl As HandShakeItem
        ctrl = New HandShakeItem
        ctrl.NAME = "なし"
        ctrl.HANDSHAKE = Handshake.None
        cmbHandShake.Items.Add(ctrl)

        ctrl = New HandShakeItem
        ctrl.NAME = "XON/XOFF制御"
        ctrl.HANDSHAKE = Handshake.XOnXOff
        cmbHandShake.Items.Add(ctrl)

        ctrl = New HandShakeItem
        ctrl.NAME = "RTS/CTS制御"
        ctrl.HANDSHAKE = Handshake.RequestToSend
        cmbHandShake.Items.Add(ctrl)

        ctrl = New HandShakeItem
        ctrl.NAME = "XON/XOFF + RTS/CTS制御"
        ctrl.HANDSHAKE = Handshake.RequestToSendXOnXOff
        cmbHandShake.Items.Add(ctrl)
        cmbHandShake.SelectedIndex = 0

    End Sub



    Private Sub Path1_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path1_0.MouseDoubleClick
        PathSet(1, 0)
    End Sub

    Private Sub Path1_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path1_1.MouseDoubleClick
        PathSet(1, 1)
    End Sub

    Private Sub Path1_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path1_2.MouseDoubleClick
        PathSet(1, 2)
    End Sub

    Private Sub Path2_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path2_0.MouseDoubleClick
        PathSet(2, 0)
    End Sub

    Private Sub Path2_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path2_1.MouseDoubleClick
        PathSet(2, 1)
    End Sub

    Private Sub Path2_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path2_2.MouseDoubleClick
        PathSet(2, 2)
    End Sub

    Private Sub Path3_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path3_0.MouseDoubleClick
        PathSet(3, 0)
    End Sub

    Private Sub Path3_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path3_1.MouseDoubleClick
        PathSet(3, 1)
    End Sub

    Private Sub Path3_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path3_2.MouseDoubleClick
        PathSet(3, 2)
    End Sub

    Private Sub Path4_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path4_0.MouseDoubleClick
        PathSet(4, 0)
    End Sub

    Private Sub Path4_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path4_1.MouseDoubleClick
        PathSet(4, 1)
    End Sub

    Private Sub Path4_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path4_2.MouseDoubleClick
        PathSet(4, 2)
    End Sub

    Private Sub Path5_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path5_0.MouseDoubleClick
        PathSet(5, 0)
    End Sub

    Private Sub Path5_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path5_1.MouseDoubleClick
        PathSet(5, 1)
    End Sub

    Private Sub Path5_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path5_2.MouseDoubleClick
        PathSet(5, 2)
    End Sub

    Private Sub Path6_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path6_0.MouseDoubleClick
        PathSet(6, 0)
    End Sub

    Private Sub Path6_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path6_1.MouseDoubleClick
        PathSet(6, 1)
    End Sub

    Private Sub Path6_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path6_2.MouseDoubleClick
        PathSet(6, 2)
    End Sub

    Private Sub Path7_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path7_0.MouseDoubleClick
        PathSet(7, 0)
    End Sub

    Private Sub Path7_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path7_1.MouseDoubleClick
        PathSet(7, 1)
    End Sub

    Private Sub Path7_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path7_2.MouseDoubleClick
        PathSet(7, 2)
    End Sub

    Private Sub Path8_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path8_0.MouseDoubleClick
        PathSet(8, 0)
    End Sub

    Private Sub Path8_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path8_1.MouseDoubleClick
        PathSet(8, 1)
    End Sub

    Private Sub Path8_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path8_2.MouseDoubleClick
        PathSet(8, 2)
    End Sub

    Private Sub Path9_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path9_0.MouseDoubleClick
        PathSet(9, 0)
    End Sub

    Private Sub Path9_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path9_1.MouseDoubleClick
        PathSet(9, 1)
    End Sub

    Private Sub Path9_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path9_2.MouseDoubleClick
        PathSet(9, 2)
    End Sub

    Private Sub Path0_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path0_0.MouseDoubleClick
        PathSet(0, 0)
    End Sub

    Private Sub Path0_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path0_1.MouseDoubleClick
        PathSet(0, 1)
    End Sub

    Private Sub Path0_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path0_2.MouseDoubleClick
        PathSet(0, 2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ModeChange(1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ModeChange(2)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ModeChange(3)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ModeChange(4)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ModeChange(5)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ModeChange(6)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ModeChange(7)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ModeChange(8)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ModeChange(9)
    End Sub

    Private Sub Button0_Click(sender As Object, e As EventArgs) Handles Button0.Click
        ModeChange(0)
    End Sub

    Private Sub KeyIn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles KeyIn.KeyPress
        'キーからのモード変更

        If IsNumeric(e.KeyChar) = True Then
            '入力されたキーが数値ならByte型に変換し、ModeChangeを行う
            Dim KeyByte As Byte
            KeyByte = Convert.ToInt16(e.KeyChar)
            KeyByte = KeyByte - 48
            ModeChange(KeyByte)
        ElseIf e.KeyChar = "i" Then
            PlaySound(0)
        ElseIf e.KeyChar = "k" Then
            PlaySound(1)
        ElseIf e.KeyChar = "m" Then
            PlaySound(2)
        ElseIf e.KeyChar = "s" Then
            mediaPlayer0.controls.stop()
            mediaPlayer1.controls.stop()
            mediaPlayer2.controls.stop()
        ElseIf e.KeyChar = "q" Then
            LoadlhlFile(lhlList(0))
        ElseIf e.KeyChar = "w" Then
            LoadlhlFile(lhlList(1))
        ElseIf e.KeyChar = "e" Then
            LoadlhlFile(lhlList(2))
        ElseIf e.KeyChar = "r" Then
            LoadlhlFile(lhlList(3))
        ElseIf e.KeyChar = "t" Then
            LoadlhlFile(lhlList(4))
        ElseIf e.KeyChar = " " Then
            If AutoNextButton.Enabled = True Then
                AutoNextButton.PerformClick()
            End If
        ElseIf e.KeyChar = "x" Then
            If AutoPrevButton.Enabled = True Then
                AutoPrevButton.PerformClick()
            End If
        ElseIf e.KeyChar = "z" Then
            If AutoBackButton.Enabled = True Then
                AutoBackButton.PerformClick()
            End If
        End If
    End Sub

    Private Sub PathSet(ByVal num1 As Byte, num2 As Byte)
        'ダイアログを表示する
        ofd.Filter = "waveファイル(*.wav;*.wave)|*.wav;*.wave|すべてのファイル(*.*)|*.*"
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(num1, num2) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Dim cs As Control() = Me.Controls.Find("Button1", True)
            cs = Me.Controls.Find("Path" + num1.ToString + "_" + num2.ToString, True)
            If cs.Length > 0 Then
                CType(cs(0), TextBox).Text = System.IO.Path.GetFileName(ofd.FileName)
            End If
        End If
    End Sub

    Private Sub lhlPathSet(ByVal num1 As Byte)

        'ダイアログを表示する
        ofd.Filter = "LaserHarpListファイル(*.lhl)|*.lhl|すべてのファイル(*.*)|*.*"
        If ofd.ShowDialog() = DialogResult.OK Then
            lhlList(num1) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Dim cs As Control() = Me.Controls.Find("lhlBox0", True)
            cs = Me.Controls.Find("lhlBox" + num1.ToString, True)
            If cs.Length > 0 Then
                CType(cs(0), TextBox).Text = System.IO.Path.GetFileName(ofd.FileName)
            End If
        End If
    End Sub

    Private Sub ModeChange(ByVal vMo As Byte)
        validMode = vMo
        'validModeの変更と、ボタン表示の変更
        Dim cs As Control() = Me.Controls.Find("Button1", True)


        'すべてのテキストボックスを初期色化
        For i As Byte = 0 To 9
            cs = Me.Controls.Find("Button" + i.ToString, True)
            If cs.Length > 0 Then
                CType(cs(0), Button).BackColor = SystemColors.ControlLight
                CType(cs(0), Button).Font = New Font(CType(cs(0), Button).Font, FontStyle.Regular)
                CType(cs(0), Button).ForeColor = SystemColors.ControlText
            End If
        Next i

        '押されたボタンの背景色、文字色、太文字設定
        cs = Me.Controls.Find("Button" + vMo.ToString, True)
        If cs.Length > 0 Then
            CType(cs(0), Button).BackColor = SystemColors.Highlight
            CType(cs(0), Button).Font = New Font(CType(cs(0), Button).Font, FontStyle.Bold)
            CType(cs(0), Button).ForeColor = SystemColors.Control
        End If

    End Sub

    Private Sub PlaySound(ByVal pNum As Byte)

        If pNum = 0 Then
            If (Not String.IsNullOrEmpty(pathList(validMode, pNum))) Then
                'オーディオファイルを指定する（自動的に再生される）
                mediaPlayer0.URL = pathList(validMode, pNum)
                '再生する
                mediaPlayer0.controls.play()
            End If
        ElseIf pNum = 1 Then
            If (Not String.IsNullOrEmpty(pathList(validMode, pNum))) Then
                'オーディオファイルを指定する（自動的に再生される）
                mediaPlayer1.URL = pathList(validMode, pNum)
                '再生する
                mediaPlayer1.controls.play()
            End If
        ElseIf pNum = 2 Then
            If (Not String.IsNullOrEmpty(pathList(validMode, pNum))) Then
                'オーディオファイルを指定する（自動的に再生される）
                mediaPlayer2.URL = pathList(validMode, pNum)
                '再生する
                mediaPlayer2.controls.play()
            End If
        End If

    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'シリアルポートをオープンしていない場合、処理を行わない.
        If SerialPort1.IsOpen = False Then
            Return
        End If

        Try
            '受信データを読み込む.
            Dim data As String
            data = SerialPort1.ReadExisting()
            '受信したデータをテキストボックスに書き込む.
            Dim args(0) As Object
            args(0) = data
            Invoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), args)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RcvDataToTextBox(data As String)
        '受信時の処理

        '受信データをテキストボックスの最後に追記する.
        If IsNothing(data) = False Then
            TextBox1.Text = data
        End If

        If IsNumeric(data) = True Then
            '入力が数値ならplaysoundを実行
            Dim databyte As Byte
            databyte = Convert.ToByte(data)
            PlaySound(databyte)
        ElseIf data = "S" Then
            AutoNextButton.PerformClick

        End If

    End Sub

    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click

        If SerialPort1.IsOpen = True Then

            'シリアルポートをクローズする.
            SerialPort1.Close()

            'ボタンの表示を[切断]から[接続]に変える.
            ConnectButton.Text = "接続"
        Else

            'オープンするシリアルポートをコンボボックスから取り出す.
            SerialPort1.PortName = cmbPortName.SelectedItem.ToString()

            'ボーレートをコンボボックスから取り出す.
            Dim baud As BuadRateItem
            baud = cmbBaudRate.SelectedItem
            SerialPort1.BaudRate = baud.BAUDRATE

            'データビットをセットする. (データビット = 8ビット)
            SerialPort1.DataBits = 8

            'パリティビットをセットする. (パリティビット = なし)
            SerialPort1.Parity = Parity.None

            'ストップビットをセットする. (ストップビット = 1ビット)
            SerialPort1.StopBits = StopBits.One

            'フロー制御をコンボボックスから取り出す.
            Dim ctrl As HandShakeItem
            ctrl = cmbHandShake.SelectedItem
            SerialPort1.Handshake = ctrl.HANDSHAKE

            '文字コードをセットする.
            'SerialPort1.Encoding = Encoding.Unicode
            SerialPort1.Encoding = System.Text.Encoding.GetEncoding(932)

            Try
                'シリアルポートをオープンする.
                SerialPort1.Open()

                'ボタンの表示を[接続]から[切断]に変える.
                ConnectButton.Text = "切断"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    'Stopボタン
    Private Sub StopAll_Click(sender As Object, e As EventArgs) Handles StopAll.Click
        mediaPlayer0.controls.stop()
        mediaPlayer1.controls.stop()
        mediaPlayer2.controls.stop()
    End Sub

    Private Sub Stop0_Click(sender As Object, e As EventArgs) Handles Stop0.Click
        mediaPlayer0.controls.stop()
    End Sub

    Private Sub Stop1_Click(sender As Object, e As EventArgs) Handles Stop1.Click
        mediaPlayer1.controls.stop()
    End Sub

    Private Sub Stop2_Click(sender As Object, e As EventArgs) Handles Stop2.Click
        mediaPlayer2.controls.stop()
    End Sub

    Private Sub PlayButton0_Click(sender As Object, e As EventArgs) Handles PlayButton0.Click
        PlaySound(0)
    End Sub

    Private Sub PlayButton1_Click(sender As Object, e As EventArgs) Handles PlayButton1.Click
        PlaySound(1)
    End Sub

    Private Sub PlayButton2_Click(sender As Object, e As EventArgs) Handles PlayButton2.Click
        PlaySound(2)
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        'ファイルへの保存

        'SaveFileDialogクラスのインスタンスを作成
        Dim sfd As New SaveFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        sfd.FileName = "新しいファイル.lhl"
        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        sfd.InitialDirectory = ""
        '[ファイルの種類]に表示される選択肢を指定する
        sfd.Filter = "LaserHarpListファイル(*.lhl)|*.lhl|すべてのファイル(*.*)|*.*"
        '[ファイルの種類]ではじめに選択されるものを指定する
        '2番目の「すべてのファイル」が選択されているようにする
        sfd.FilterIndex = 1
        'タイトルを設定する
        sfd.Title = "保存先のファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        sfd.RestoreDirectory = True
        '既に存在するファイル名を指定したとき警告する
        'デフォルトでTrueなので指定する必要はない
        sfd.OverwritePrompt = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        sfd.CheckPathExists = True

        'ダイアログを表示する
        If sfd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、書き込み開始

            Dim write As New System.IO.StreamWriter(sfd.FileName, False, System.Text.Encoding.GetEncoding("shift_jis"))
            Dim s As String = ""

            For Each s In pathList
                write.WriteLine(s)
            Next
            write.Close()
        End If
    End Sub

    Private Sub LoadButton_Click(sender As Object, e As EventArgs) Handles LoadButton.Click
        'OpenFileDialogクラスのインスタンスを作成
        Dim Oofd As New OpenFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        Oofd.FileName = ""
        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        Oofd.InitialDirectory = ""
        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        Oofd.Filter = "LaserHarpListファイル(*.lhl)|*.lhl|すべてのファイル(*.*)|*.*"
        '[ファイルの種類]ではじめに選択されるものを指定する
        '2番目の「すべてのファイル」が選択されているようにする
        Oofd.FilterIndex = 1
        'タイトルを設定する
        Oofd.Title = "開くファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        Oofd.RestoreDirectory = True
        '存在しないファイルの名前が指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        Oofd.CheckFileExists = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        Oofd.CheckPathExists = True

        'ダイアログを表示する
        If Oofd.ShowDialog() = DialogResult.OK Then
            LoadlhlFile(Oofd.FileName)
        End If
    End Sub

    Private Sub LoadlhlFile(ByVal FileName As String)
        If System.IO.File.Exists(FileName) Then
            Dim load As New System.IO.StreamReader(FileName, System.Text.Encoding.GetEncoding("shift_jis"))
            Dim Nofile As Integer = 0
            Dim cntA As Byte = 0
            Dim cntB As Byte = 0
            Dim loadtext As String = ""
            Dim cs As Control() = Me.Controls.Find("Path0_0", True)

            '１行ずつ読み込む
            While load.Peek() > -1
                LoadingFile.Text = System.IO.Path.GetFileName(FileName)

                loadtext = load.ReadLine()
                'ファイルの存在をチェックしてから読み込み
                If System.IO.File.Exists(loadtext) Or loadtext = "" Then
                    pathList(cntA, cntB) = loadtext

                    cs = Me.Controls.Find("Path" + cntA.ToString + "_" + cntB.ToString, True)
                    If cs.Length > 0 Then
                        CType(cs(0), TextBox).Text = System.IO.Path.GetFileName(loadtext)
                    End If

                Else
                    Nofile = Nofile + 1
                End If

                cntB = cntB + 1
                If cntB = 3 Then
                    cntB = 0
                    cntA = cntA + 1
                End If

                If cntA = 10 Then
                    Exit While
                End If
            End While

            load.Close()

            If Nofile > 0 Then
                MsgBox("読み込めないファイルが" + Nofile.ToString + "個ありました。")
            End If
        End If
    End Sub

    Private Sub LhlBox0_DoubleClick(sender As Object, e As EventArgs) Handles lhlBox0.DoubleClick
        lhlPathSet(0)
    End Sub

    Private Sub LhlBox1_DoubleClick(sender As Object, e As EventArgs) Handles lhlBox1.DoubleClick
        lhlPathSet(1)
    End Sub

    Private Sub LhlBox2_DoubleClick(sender As Object, e As EventArgs) Handles lhlBox2.DoubleClick
        lhlPathSet(2)
    End Sub

    Private Sub LhlBox3_DoubleClick(sender As Object, e As EventArgs) Handles lhlBox3.DoubleClick
        lhlPathSet(3)
    End Sub

    Private Sub LhlBox4_DoubleClick(sender As Object, e As EventArgs) Handles lhlBox4.DoubleClick
        lhlPathSet(4)
    End Sub

    Private Sub lhlButton0_Click(sender As Object, e As EventArgs) Handles lhlButton0.Click
        LoadlhlFile(lhlList(0))
    End Sub

    Private Sub lhlButton1_Click(sender As Object, e As EventArgs) Handles lhlButton1.Click
        LoadlhlFile(lhlList(1))
    End Sub

    Private Sub lhlButton2_Click(sender As Object, e As EventArgs) Handles lhlButton2.Click
        LoadlhlFile(lhlList(2))
    End Sub

    Private Sub lhlButton3_Click(sender As Object, e As EventArgs) Handles lhlButton3.Click
        LoadlhlFile(lhlList(3))
    End Sub

    Private Sub lhlButton4_Click(sender As Object, e As EventArgs) Handles lhlButton4.Click
        LoadlhlFile(lhlList(4))
    End Sub

    'Auto操作関連

    Function getLineNumText(file_path As String)
        Dim StReader As New System.IO.StreamReader(file_path)
        Dim cnt As Long
        While (StReader.Peek() >= 0)
            StReader.ReadLine()
            cnt += 1
        End While
        Return cnt
    End Function

    Dim AutoCommand() As String
    Dim ComLength As Integer
    Dim ComNum As Integer = 0

    Private Sub AutoFileBox_DoubleClick(sender As Object, e As EventArgs) Handles AutoFileBox.DoubleClick

        Dim fileName As String

        'ダイアログを表示する
        ofd.Filter = "Textファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*"
        If ofd.ShowDialog() = DialogResult.OK Then
            fileName = ofd.FileName
            AutoFileBox.Text = System.IO.Path.GetFileName(ofd.FileName)

            ' StreamReader の新しいインスタンスを生成する
            Dim cReader As New System.IO.StreamReader(fileName, System.Text.Encoding.UTF8)
            Dim s As Integer = 0
            Dim lnum As Integer = getLineNumText(fileName)
            ReDim AutoCommand(lnum - 1)

            For i As Integer = 0 To lnum - 1
                AutoCommand(i) = ""
            Next

            ' 読み込みできる文字がなくなるまで繰り返す
            Dim readbuffer As String

            While (cReader.Peek() >= 0)
                readbuffer = cReader.ReadLine()
                If readbuffer.Length = 2 Or readbuffer.Length = 4 Then
                    If System.Text.RegularExpressions.Regex.IsMatch(readbuffer, "L[0-4]") Or
                        System.Text.RegularExpressions.Regex.IsMatch(readbuffer, "C[0-9]") Or
                         System.Text.RegularExpressions.Regex.IsMatch(readbuffer, "P[0-2]") Or
                          System.Text.RegularExpressions.Regex.IsMatch(readbuffer, "L[0-4]C[0-9]") Then
                        ' ファイルを 1 行ずつ読み込む
                        ' 読み込んだものを追加で格納する
                        AutoCommand(s) = readbuffer
                        s += 1
                    End If
                End If
            End While

            cReader.Close()

            ComLength = s
            ComNum = 0

            If ComLength > 1 Then
                AutoPrevBox.Text = ""
                AutoNowBox.Text = ""
                AutoNextBox.Text = AutoCommand(0)
            Else
                For i As Integer = 0 To lnum - 1
                    AutoCommand(i) = ""
                Next
            End If

        End If

        If ComLength < 2 Then
            MsgBox("有効なコマンドが２つ以上のファイルを選択してください。")
            AutoNextButton.Enabled = False
            AutoPrevButton.Enabled = False
            AutoBackButton.Enabled = False
        Else
            LabelCm.Text = "0/" + ComLength.ToString
            AutoNextButton.Enabled = True
            AutoPrevButton.Enabled = True
            AutoBackButton.Enabled = True
        End If
    End Sub

    Private Sub AutoRun(ByVal NowText As String)
        'コマンドの種類別に実行
        If Not NowText = "" Then
            If System.Text.RegularExpressions.Regex.IsMatch(NowText, "L[0-4]") And NowText.Length = 2 Then
                'Lコマンド　LHLのロード
                If IsNumeric(NowText.Substring(1, 1)) Then
                    LoadlhlFile(lhlList(NowText.Substring(1, 1)))
                End If
            ElseIf System.Text.RegularExpressions.Regex.IsMatch(NowText, "C[0-9]") And NowText.Length = 2 Then
                'Cコマンド モードチェンジ
                If IsNumeric(NowText.Substring(1, 1)) Then
                    ModeChange(NowText.Substring(1, 1))
                End If
            ElseIf System.Text.RegularExpressions.Regex.IsMatch(NowText, "P[0-2]") And NowText.Length = 2 Then
                'Pコマンド　プレイ
                If IsNumeric(NowText.Substring(1, 1)) Then
                    PlaySound(NowText.Substring(1, 1))
                End If
            ElseIf System.Text.RegularExpressions.Regex.IsMatch(NowText, "L[0-4]C[0-9]") And NowText.Length = 4 Then
                'LCコマンド LHLのロード　＆　モードチェンジ
                If IsNumeric(NowText.Substring(1, 1)) And IsNumeric(NowText.Substring(3, 1)) Then
                    LoadlhlFile(lhlList(NowText.Substring(1, 1)))
                    ModeChange(NowText.Substring(3, 1))
                End If
            End If
        End If
    End Sub

    Private Sub AutoNextButton_Click(sender As Object, e As EventArgs) Handles AutoNextButton.Click
        If ComNum <= ComLength - 1 Then
            Dim NowText As String = AutoNextBox.Text

            AutoRun(NowText)

            '表示の変更
            If ComNum = 0 Then
                AutoPrevBox.Text = ""
                AutoNowBox.Text = AutoCommand(ComNum)
                AutoNextBox.Text = AutoCommand(ComNum + 1)
            ElseIf 1 <= ComNum And ComNum < (ComLength - 1) Then
                AutoPrevBox.Text = AutoCommand(ComNum - 1)
                AutoNowBox.Text = AutoCommand(ComNum)
                AutoNextBox.Text = AutoCommand(ComNum + 1)
            ElseIf ComNum = (ComLength - 1) Then
                AutoPrevBox.Text = AutoCommand(ComNum - 1)
                AutoNowBox.Text = AutoCommand(ComNum)
                AutoNextBox.Text = ""
            End If

            ComNum += 1

        ElseIf ComNum > ComLength - 1 Then
            ComNum = 0
            AutoPrevBox.Text = ""
            AutoNowBox.Text = ""
            AutoNextBox.Text = AutoCommand(0)
        End If

        LabelCm.Text = ComNum.ToString + "/" + ComLength.ToString
    End Sub

    Private Sub AutoPrevButton_Click(sender As Object, e As EventArgs) Handles AutoPrevButton.Click
        If 2 <= ComNum Then
            Dim NowText As String = AutoPrevBox.Text

            AutoRun(NowText)

            ComNum -= 1

            If 2 <= ComNum Then
                AutoPrevBox.Text = AutoCommand(ComNum - 2)
                AutoNowBox.Text = AutoCommand(ComNum - 1)
                AutoNextBox.Text = AutoCommand(ComNum)
            ElseIf ComNum = 1 Then
                AutoPrevBox.Text = ""
                AutoNowBox.Text = AutoCommand(ComNum - 1)
                AutoNextBox.Text = AutoCommand(ComNum)
            End If

        End If

        LabelCm.Text = ComNum.ToString + "/" + ComLength.ToString
    End Sub

    Private Sub AutoBackButton_Click(sender As Object, e As EventArgs) Handles AutoBackButton.Click
        ComNum = 0
        AutoPrevBox.Text = ""
        AutoNowBox.Text = ""
        AutoNextBox.Text = AutoCommand(0)

        Dim NowText As String = AutoNextBox.Text

        AutoRun(NowText)

        LabelCm.Text = "1/" + ComLength.ToString
    End Sub

End Class
