Public Class Form1

    Dim WithEvents Cl As New CombineCl
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Cl Is Nothing) Then
            Cl = New CombineCl()
        End If
    End Sub

    Private Sub Drag_Enter(sender As Object, e As DragEventArgs) Handles TextBox1.DragEnter, TextBox2.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Drag_Drop(sender As Object, e As DragEventArgs) Handles TextBox1.DragDrop, TextBox2.DragDrop
        Dim files As String() = e.Data.GetData(DataFormats.FileDrop)
        Select Case True
            Case sender Is TextBox1
                TextBox1.Text = files(0)
            Case sender Is TextBox2
                TextBox2.Text = files(0)
        End Select
    End Sub

    Sub HandleComboListEvent(ByVal sender As Object, ByVal e As List(Of String)) Handles Cl.RaiseFinishedList
        ListBox1.Items.Clear()
        For Each result As String In e
            ListBox1.Items.Add(result)
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim userlist As List(Of String) = Cl.LoadFile(TextBox1.Text)
        Dim passlist As List(Of String) = Cl.LoadFile(TextBox2.Text)

        Cl.CombineList(userlist, passlist)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        if (listbox1.Items.Count <= 0) then
            Return
        End If
        Using  sfd as New SaveFileDialog()
            With sfd
                .Filter = ".txt|*.txt"
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                .DefaultExt = ".txt"
            End With
           If (sfd.ShowDialog() = DialogResult.OK) Then
               dim textout as String
               For Each res As string In ListBox1.Items
                   textout += res + vbNewLine
               Next
               System.IO.File.WriteAllText(sfd.FileName, textout)
           End If
        End Using


    End Sub
End Class