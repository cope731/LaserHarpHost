Public Class Form1
    Dim ofd As New OpenFileDialog()
    Dim validMode As New Byte
    Dim pathList(11, 7) As String


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

    End Sub

    Private Sub Path1_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path1_0.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(1, 0) = ofd.FileName

            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path1_0.Text = System.IO.Path.GetFileName(ofd.FileName)
        End If
    End Sub

    Private Sub Path1_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path1_1.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(1, 1) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path1_1.Text = System.IO.Path.GetFileName(ofd.FileName)
        End If
    End Sub

    Private Sub Path1_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path1_2.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(1, 2) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path1_2.Text = System.IO.Path.GetFileName(ofd.FileName)
        End If
    End Sub

    Private Sub Path2_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path2_0.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(2, 0) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path2_0.Text = System.IO.Path.GetFileName(ofd.FileName)
        End If
    End Sub

    Private Sub Path2_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path2_1.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(2, 1) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path2_1.Text = System.IO.Path.GetFileName(ofd.FileName)
        End If
    End Sub

    Private Sub Path2_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path2_2.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(2, 2) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path2_2.Text = System.IO.Path.GetFileName(ofd.FileName)
        End If
    End Sub

    Private Sub Path3_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path3_0.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(3, 0) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path3_0.Text = System.IO.Path.GetFileName(ofd.FileName)
        End If
    End Sub

    Private Sub Path3_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path3_1.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(3, 1) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path3_1.Text = System.IO.Path.GetFileName(ofd.FileName)
        End If
    End Sub

    Private Sub Path3_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path3_2.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(3, 2) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path3_2.Text = System.IO.Path.GetFileName(ofd.FileName)
        End If
    End Sub

    Private Sub Path4_0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path4_0.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path4_0.Text = System.IO.Path.GetFileName(ofd.FileName)
            pathList(4, 0) = ofd.FileName
        End If
    End Sub

    Private Sub Path4_1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path4_1.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(4, 1) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path4_1.Text = System.IO.Path.GetFileName(ofd.FileName)
        End If
    End Sub

    Private Sub Path4_2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Path4_2.MouseDoubleClick
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            pathList(4, 2) = ofd.FileName
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Path4_2.Text = System.IO.Path.GetFileName(ofd.FileName)

        End If
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
        Label1.Text = e.KeyChar
        If IsNumeric(e.KeyChar) = True Then
            Dim KeyByte As Byte
            KeyByte = Convert.ToInt16(e.KeyChar)
            ModeChange(KeyByte)
            'If 0 < KeyByte < 5 Then
            'ModeChange(KeyByte)
            'End If
        End If
    End Sub

    Private Function ModeChange(ByVal vMo As Byte)
        'validModeの変更と、ボタン表示の変更
        Dim cs As Control() = Me.Controls.Find("Button1", True)
        validMode = vMo

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

End Class
