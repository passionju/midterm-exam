Public Class Form1
    Const Row = 8
    Const Col = 8
    Dim bot(Row, Col) As PictureBox

    Dim c As Integer = 1
    Dim k As Integer = 1
    Dim hh As Integer = 0
    Dim ww As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim block As Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)

        ww = CInt(Format(Now(), "sssss"))
        If ww >= 50 Then
            ww -= 1
        End If
        For i As Integer = 0 To Row
            For j As Integer = 0 To Col


                Dim mBmpImg As Bitmap
                Dim g As Graphics
                Dim b As New SolidBrush(Color.Gray)

                mBmpImg = New Bitmap(50, 50)
                g = Graphics.FromImage(mBmpImg)
                b.Color = Color.White
                g.FillRectangle(b, 5, 5, 50 - 10, 50 - 10)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
                b.Color = Color.Black

                g.DrawString(c, New Font("Arial", 10), b, 18, 18)



                bot(i, j) = New PictureBox
                Me.Controls.Add(bot(i, j))
                bot(i, j).Name = "picturebox" & ((2 + 1) * i + j + 1)
                bot(i, j).Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)
                bot(i, j).SizeMode = PictureBoxSizeMode.StretchImage
                bot(i, j).BorderStyle = BorderStyle.Fixed3D
                bot(i, j).Visible = True
                bot(i, j).Width = 50
                bot(i, j).Height = 50
                bot(i, j).Top = 50 * i + 10
                bot(i, j).Left = 50 * j + 10
                bot(i, j).BackgroundImage = mBmpImg
                bot(i, j).Tag = c
                c += 1

                AddHandler bot(i, j).Click, AddressOf abc_click
            Next j

        Next i

        Randomize()


    End Sub


    Sub abc_click(sender As Object, e As EventArgs)
        Dim b = CType(sender, PictureBox)
        b.Image = Nothing
        b.Enabled = False

        If b.Tag <> k Then
            Threading.Thread.Sleep(500)
            b.Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)
            b.Enabled = True
        Else
            k += 1
        End If

        If k = 81 Then
            'hh = Format(Now(), "sssss")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If CInt(Format(Now(), "sssss")) - ww + ww >= 59 Then
            hh += 1
        End If
        'TextBox1.Text = CInt(Format(Now(), "sssss"))
        'TextBox2.Text = ww
        If hh >= 1 Then
            If CInt(Format(Now(), "sssss")) <= ww Then
                Me.Text = -(CInt(Format(Now(), "sssss")) - ww) + (hh * ww)
            Else
                Me.Text = (CInt(Format(Now(), "sssss")) - ww) + (hh * ww)
            End If
        Else
            Me.Text = CInt(Format(Now(), "sssss")) - ww - 3 + (hh * ww)
        End If

        If (CInt(Format(Now(), "sssss")) - ww - 3) < 0 Then
            'MsgBox("1111111")
            For i As Integer = 0 To Row
                For j As Integer = 0 To Col
                    bot(i, j).Image = Nothing
                Next j
            Next i
        Else
            For i As Integer = 0 To Row
                For j As Integer = 0 To Col
                    bot(i, j).Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)
                Next j
            Next i

        End If
    End Sub
End Class





