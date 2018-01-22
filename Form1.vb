Public Class PirateFlag
    Public FlagBM As New Bitmap(750, 500) 'Bitmap that will become the pirate flag
    Public ScaleBM As New Bitmap(20, 255) 'Bitmap for the scale

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Flagcolor As New Color
        Dim GoldGivenAway As Integer
        'Double for loop. There cannot be zero pirates. The dimensions are arbitrary, but should match the flag dimensions.
        For Gold As Integer = 0 To 749
            For Pirates As Integer = 1 To 500
                If Gold > 0 And Gold >= (Pirates / 2) - 1 Then
                    'The captain needs to give one gold piece to half of the other pirates to survive. The rest they can keep!
                    GoldGivenAway = (Pirates / 2) - 1
                    'Yellow is RGB(255,255,0)
                    'Red is RGB(255,0,0)
                    Flagcolor = Color.FromArgb(255, 255 - Math.Round((GoldGivenAway / Gold) * 255), 0)
                ElseIf Math.Round(Math.Log(Pirates - 2 * Gold, 2)) = Math.Log(Pirates - 2 * Gold, 2) Then
                    'When theirs not enough gold, every 2^x the captain will be safe (because the the next in lines want to save themselves the same fate)
                    Flagcolor = Color.Red
                Else
                    'Captain dies!
                    Flagcolor = Color.Black
                End If
                'VBNet measures xy axis as distance from the upper left, so we need to flip the y-axis
                FlagBM.SetPixel(Gold, 500 - Pirates, Flagcolor)
            Next
        Next
        Flag.Image = FlagBM
        For x As Integer = 0 To 19
            For y As Integer = 0 To 254
                ScaleBM.SetPixel(x, y, Color.FromArgb(255, 255 - y - 1, 0))
            Next
        Next
        ImageScale.Image = ScaleBM
    End Sub
End Class
