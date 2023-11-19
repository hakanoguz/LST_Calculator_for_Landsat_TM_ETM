﻿Imports System.IO
Public Class FormLandsatTMETM

    Private Sub FormLandsatTMETM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.RadioButton1.Select() 'Option1 is selected as default
        Me.txtBoxLmdMax.Clear()
        Me.txtBoxLmdMin.Clear()
        Me.txtBoxQcalMax.Clear()
        Me.txtBoxQcalMin.Clear()
        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TextBox3.Clear()
        Me.TextBox4.Clear()
        Me.txtBoxBandMin.Clear()
        Me.Label10.Text = ""
        Me.btnOK.Enabled = True
        Me.PictureBox1.Visible = False
        Me.PictureBox2.Visible = False

    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If RadioButton1.Checked = True Then
            If TextBox1.Text.Length = 0 Or TextBox2.Text.Length = 0 Or txtBoxLmdMax.Text.Length = 0 Or txtBoxLmdMin.Text.Length = 0 Or txtBoxQcalMax.Text.Length = 0 Or txtBoxQcalMin.Text.Length = 0 Or txtBoxBandMin.Text.Length = 0 Then
                MessageBox.Show("Please input all parameters and then select the directory path to save in!", "Warning!")
                Me.txtBoxLmdMax.Focus()
            Else
                Me.Cursor = Cursors.WaitCursor
                Me.PictureBox1.Visible = True
                Me.PictureBox1.Update()
                Me.btnOK.Enabled = False
                'Me.Label10.Text = "Processing... Please Wait!"
                'Me.Label10.Update()
                Me.Label12.Visible = False
                Me.Label12.Update()
                Me.Label10.Text = "Processing... Please Wait!"
                Me.Label10.Update()

                Dim s1 As FileStream 'Load file 1
                Dim s3 As FileStream 'Save output

                If System.IO.File.Exists(TextBox2.Text) Then
                    System.IO.File.Delete(TextBox2.Text)
                End If

                '---read from and write to a binary file
                s1 = New FileStream(TextBox1.Text, FileMode.Open, FileAccess.Read)
                s3 = New FileStream(TextBox2.Text, FileMode.CreateNew, FileAccess.Write)

                Dim br1 As BinaryReader
                Dim bw As BinaryWriter

                br1 = New BinaryReader(s1)
                bw = New BinaryWriter(s3)

                Dim fLen1 As Integer
                Dim f1 As New System.IO.FileInfo(TextBox1.Text)
                fLen1 = f1.Length

                'Dim snglRead1(fLen1) As Single
                'Dim snglOutput(fLen1) As Single 'wıll hold results from division

                Dim snglRead1 As Single
                Dim snglOutput As Single 'wıll hold results from division

                Dim i As Integer
                'Dim m As Integer

                Dim LMax As Single
                Dim LMin As Single
                Dim QCalMax As Single
                Dim QCalMin As Single
                Dim BandMin As Single


                LMax = CSng(txtBoxLmdMax.Text)
                LMin = CSng(txtBoxLmdMin.Text)
                QCalMax = CSng(txtBoxQcalMax.Text)
                QCalMin = CSng(txtBoxQcalMin.Text)
                BandMin = CSng(txtBoxBandMin.Text)


                ' Llamda = ((LMAXlamda - LMINlamda)/(QCALMAX-QCALMIN)) * (QCAL-QCALMIN) + LMINlamda

                'Read binary file1 and fill the array with pixel values 
                For i = 0 To fLen1 - 1
                    snglRead1 = br1.ReadByte
                    'If snglRead1 >= BandMin Then
                    '    snglRead1 = snglRead1 - BandMin
                    'Else
                    '    snglRead1 = BandMin
                    'End If
                    snglOutput = ((LMax - LMin) / (QCalMax - QCalMin)) * ((snglRead1 - BandMin) - QCalMin) + LMin
                    bw.Write(snglOutput)
                Next


                'For m = 0 To fLen1 - 1
                '    snglOutput(m) = ((LMax - LMin) / (QCalMax - QCalMin)) * (snglRead1(m) - QCalMin) + LMin
                '    bw.Write(snglOutput(m))
                'Next

                'following 4 msgboxes are used for testing purposes
                'MsgBox("LMax= " & LMax)
                'MsgBox("LMin= " & LMin)
                'MsgBox("QCalMax= " & QCalMax)
                'MsgBox("QCalMin= " & QCalMin)
                'MsgBox("snglRead1(0)= " & snglRead1(0))
                'MsgBox("snglOutput(0)= " & snglOutput(0))

                s1.Close()
                s3.Close()

                Me.PictureBox1.Visible = False
                Me.PictureBox2.Visible = True
                'Me.Label10.Text = "Process Completed!"
                'Me.Label10.Update()

                Me.Label10.Visible = False
                Me.Label10.Update()
                Me.Label12.Visible = True
                Me.Label12.Text = "Process Completed!"
                Me.Label12.Update()

                btnCancel.Text = "Close"
                Me.Cursor = Cursors.Default
                MessageBox.Show("File created successfully!", "Success!")
                'Me.Close()
            End If
        End If

        If RadioButton2.Checked = True Then
            If TextBox1.Text.Length = 0 Or TextBox2.Text.Length = 0 Or TextBox3.Text.Length = 0 Or TextBox4.Text.Length = 0 Or txtBoxBandMin.Text.Length = 0 Then
                MessageBox.Show("Please input all parameters and then select the directory path to save in!", "Warning!")
                Me.txtBoxLmdMax.Focus()
            Else
                Me.Cursor = Cursors.WaitCursor
                Me.PictureBox1.Visible = True
                Me.PictureBox1.Update()
                Me.btnOK.Enabled = False
                Me.Label12.Visible = False
                Me.Label12.Update()
                Me.Label10.Text = "Processing... Please Wait!"
                Me.Label10.Update()

                'Me.Label10.Text = "Processing... Please Wait!"
                'Me.Label10.Update()

                Dim s1 As FileStream 'Load file 1
                Dim s3 As FileStream 'Save output

                If System.IO.File.Exists(TextBox2.Text) Then
                    System.IO.File.Delete(TextBox2.Text)
                End If

                '---read from and write to a binary file
                s1 = New FileStream(TextBox1.Text, FileMode.Open, FileAccess.Read)
                s3 = New FileStream(TextBox2.Text, FileMode.CreateNew, FileAccess.Write)

                Dim br1 As BinaryReader
                Dim bw As BinaryWriter

                br1 = New BinaryReader(s1)
                bw = New BinaryWriter(s3)

                Dim fLen1 As Integer
                Dim f1 As New System.IO.FileInfo(TextBox1.Text)
                fLen1 = f1.Length

                'Dim snglRead1(fLen1) As Single
                'Dim snglOutput(fLen1) As Single 'wıll hold results from division

                Dim snglRead1 As Single
                Dim snglOutput As Single

                Dim j As Integer
                'Dim k As Integer
                Dim gain As Single
                Dim bias As Single 'bias and offset are the same thing...
                Dim BandMin As Single


                gain = CSng(TextBox3.Text)
                bias = CSng(TextBox4.Text)
                BandMin = CSng(txtBoxBandMin.Text)


                'Read binary file1 and fill the array with pixel values 
                For j = 0 To fLen1 - 1
                    snglRead1 = br1.ReadByte
                    snglOutput = gain * (snglRead1 - BandMin) + bias
                    bw.Write(snglOutput)
                Next

                'Dim LMax As Single
                'Dim LMin As Single
                'Dim QCalMax As Single
                'Dim QCalMin As Single



                'LMax = CSng(txtBoxLmdMax.Text)
                'LMin = CSng(txtBoxLmdMin.Text)
                'QCalMax = CSng(txtBoxQcalMax.Text)
                'QCalMin = CSng(txtBoxQcalMin.Text)

                ' Llambda = ((LMAXlambda - LMINlambda)/(QCALMAX-QCALMIN)) * (QCAL-QCALMIN) + LMINlamda
                ' Llambda = Gain * DN + bias


                'For k = 0 To fLen1 - 1
                '    snglOutput(k) = gain * snglRead1(k) + bias
                '    bw.Write(snglOutput(k))
                'Next


                'following 4 msgboxes are used for testing purposes
                'MsgBox("LMax= " & LMax)
                'MsgBox("LMin= " & LMin)
                'MsgBox("QCalMax= " & QCalMax)
                'MsgBox("QCalMin= " & QCalMin)
                'MsgBox("snglRead1(0)= " & snglRead1(0))
                'MsgBox("snglOutput(0)= " & snglOutput(0))

                s1.Close()
                s3.Close()

                Me.PictureBox1.Visible = False
                Me.PictureBox2.Visible = True
                'Me.Label10.Text = "Process Completed!"
                'Me.Label10.Update()

                Me.Label10.Visible = False
                Me.Label10.Update()
                Me.Label12.Visible = True
                Me.Label12.Text = "Process Completed!"
                Me.Label12.Update()

                btnCancel.Text = "Close"
                Me.Cursor = Cursors.Default
                MessageBox.Show("File created successfully!", "Success!")
                'Me.Close()
            End If
        End If


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OpenFD.InitialDirectory = "C:\"
        OpenFD.Multiselect = False
        OpenFD.Title = "Select a Landsat ETM+ Band"
        OpenFD.Filter = "All Files [*.*]| *.*"
        ' Make sure the User clicked OK and not Cancel
        If (OpenFD.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            TextBox1.Text = ""
            Dim loadFileName1 As String = OpenFD.FileName

            'show the full path of selected file in TextBox1
            TextBox1.AppendText(loadFileName1)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveFD.InitialDirectory = "C:\"
        SaveFD.Title = "Save Output File As..."
        SaveFD.Filter = "All Files [*.*]| *.*"
        ' Make sure the User clicked OK and not Cancel
        If (SaveFD.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            TextBox2.Text = ""
            Dim saveFileName As String = SaveFD.FileName

            'show the full path of selected file
            TextBox2.AppendText(saveFileName)
        End If
    End Sub

    Private Sub txtBoxLmdMax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoxLmdMax.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 48 Or Asc(e.KeyChar) = 49 Or Asc(e.KeyChar) = 50 Or Asc(e.KeyChar) = 51 Or Asc(e.KeyChar) = 52 Or Asc(e.KeyChar) = 53 Or Asc(e.KeyChar) = 54 Or Asc(e.KeyChar) = 55 Or Asc(e.KeyChar) = 56 Or Asc(e.KeyChar) = 57 Then
            e.Handled = False
        Else
            MessageBox.Show("Please Enter Numbers Only!")
            e.Handled = True
        End If
    End Sub

    Private Sub txtBoxLmdMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoxLmdMin.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 48 Or Asc(e.KeyChar) = 49 Or Asc(e.KeyChar) = 50 Or Asc(e.KeyChar) = 51 Or Asc(e.KeyChar) = 52 Or Asc(e.KeyChar) = 53 Or Asc(e.KeyChar) = 54 Or Asc(e.KeyChar) = 55 Or Asc(e.KeyChar) = 56 Or Asc(e.KeyChar) = 57 Then
            e.Handled = False
        Else
            MessageBox.Show("Please Enter Numbers Only!")
            e.Handled = True
        End If
    End Sub

    Private Sub txtBoxQcalMax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoxQcalMax.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 48 Or Asc(e.KeyChar) = 49 Or Asc(e.KeyChar) = 50 Or Asc(e.KeyChar) = 51 Or Asc(e.KeyChar) = 52 Or Asc(e.KeyChar) = 53 Or Asc(e.KeyChar) = 54 Or Asc(e.KeyChar) = 55 Or Asc(e.KeyChar) = 56 Or Asc(e.KeyChar) = 57 Then
            e.Handled = False
        Else
            MessageBox.Show("Please Enter Numbers Only!")
            e.Handled = True
        End If
    End Sub

    Private Sub txtBoxQcalMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoxQcalMin.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 48 Or Asc(e.KeyChar) = 49 Or Asc(e.KeyChar) = 50 Or Asc(e.KeyChar) = 51 Or Asc(e.KeyChar) = 52 Or Asc(e.KeyChar) = 53 Or Asc(e.KeyChar) = 54 Or Asc(e.KeyChar) = 55 Or Asc(e.KeyChar) = 56 Or Asc(e.KeyChar) = 57 Then
            e.Handled = False
        Else
            MessageBox.Show("Please Enter Numbers Only!")
            e.Handled = True
        End If
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        If RadioButton1.Checked = True Then
            'RadioButton1.Text = "selected"
            'RadioButton2.Text = "unselected"
            txtBoxLmdMax.Enabled = True
            txtBoxLmdMin.Enabled = True
            txtBoxQcalMax.Enabled = True
            txtBoxQcalMin.Enabled = True
            TextBox3.Enabled = False
            TextBox4.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        If RadioButton2.Checked = True Then
            'RadioButton1.Text = "unselected"
            'RadioButton2.Text = "selected"
            txtBoxLmdMax.Enabled = False
            txtBoxLmdMin.Enabled = False
            txtBoxQcalMax.Enabled = False
            txtBoxQcalMin.Enabled = False
            TextBox3.Enabled = True
            TextBox4.Enabled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 48 Or Asc(e.KeyChar) = 49 Or Asc(e.KeyChar) = 50 Or Asc(e.KeyChar) = 51 Or Asc(e.KeyChar) = 52 Or Asc(e.KeyChar) = 53 Or Asc(e.KeyChar) = 54 Or Asc(e.KeyChar) = 55 Or Asc(e.KeyChar) = 56 Or Asc(e.KeyChar) = 57 Then
            e.Handled = False
        Else
            MessageBox.Show("Please Enter Numbers Only!")
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 48 Or Asc(e.KeyChar) = 49 Or Asc(e.KeyChar) = 50 Or Asc(e.KeyChar) = 51 Or Asc(e.KeyChar) = 52 Or Asc(e.KeyChar) = 53 Or Asc(e.KeyChar) = 54 Or Asc(e.KeyChar) = 55 Or Asc(e.KeyChar) = 56 Or Asc(e.KeyChar) = 57 Then
            e.Handled = False
        Else
            MessageBox.Show("Please Enter Numbers Only!")
            e.Handled = True
        End If
    End Sub

    Private Sub txtBoxBandMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoxBandMin.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 48 Or Asc(e.KeyChar) = 49 Or Asc(e.KeyChar) = 50 Or Asc(e.KeyChar) = 51 Or Asc(e.KeyChar) = 52 Or Asc(e.KeyChar) = 53 Or Asc(e.KeyChar) = 54 Or Asc(e.KeyChar) = 55 Or Asc(e.KeyChar) = 56 Or Asc(e.KeyChar) = 57 Then
            e.Handled = False
        Else
            MessageBox.Show("Please Enter Numbers Only!")
            e.Handled = True
        End If
    End Sub
End Class