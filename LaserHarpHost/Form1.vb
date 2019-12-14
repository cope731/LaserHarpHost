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
    Dim pathList(11, 7) As String
    'wav再生用WMP
    Dim mediaPlayer0 As New WMPLib.WindowsMediaPlayer()
    Dim mediaPlayer1 As New WMPLib.WindowsMediaPlayer()
    Dim mediaPlayer2 As New WMPLib.WindowsMediaPlayer()


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        validMode = 1 'モードの初期化

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

    Private Sub KeyIn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles KeyIn.KeyPress
        'テンキーからのモード変更

        If IsNumeric(e.KeyChar) = True Then
            '入力されたキーが数値ならByte型に変換し、ModeChangeを行う
            Dim KeyByte As Byte
            KeyByte = Convert.ToInt16(e.KeyChar)
            KeyByte = KeyByte - 48
            ModeChange(KeyByte)
        End If
    End Sub

    Private Function PathSet(ByVal num1 As Byte, num2 As Byte)
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(num1, num2) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Dim cs As Control() = Me.Controls.Find("Button1", True)
            cs = Me.Controls.Find("Path" + num1.ToString + "_" + num2.ToString, True)
            If cs.Length > 0 Then
                CType(cs(0), TextBox).Text = System.IO.Path.GetFileName(ofd.FileName)
            End If
        End If


    End Function


    Private Function ModeChange(ByVal vMo As Byte)
        validMode = vMo
        'validModeの変更と、ボタン表示の変更
        Dim cs As Control() = Me.Controls.Find("Button1", True)


        'すべてのテキストボックスを初期色化
        For i As Byte = 1 To 4
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

    End Function

    Private Function PlaySound(ByVal pNum As Byte)

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

    End Function

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
End Class
