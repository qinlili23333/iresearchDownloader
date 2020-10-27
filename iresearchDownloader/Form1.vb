Imports System.Net
Imports System.Web

Public Class Form1
    Dim DownloadClient As New WebClient
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler DownloadClient.DownloadProgressChanged, AddressOf ShowDownProgress
        AddHandler DownloadClient.DownloadFileCompleted, AddressOf DownloadFileCompleted
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    End Sub
    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click

    End Sub
    Private Sub ShowDownProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Invoke(New Action(Of Integer)(Sub(i) ProgressBar1.Value = i), e.ProgressPercentage)
    End Sub
    Private Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        MessageBox.Show("下载成功!")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pdfQuery = HttpUtility.ParseQueryString(New Uri(TextBox1.Text).Query)
        Dim bookId = pdfQuery.GetValues("bookId")(0)
        Dim cdf = pdfQuery.GetValues("cdf")(0)
        Dim downloadURL = "https://www.iresearchbook.cn/f/cdf/file?file=" + cdf + "&bookId=" + bookId
        DownloadClient.DownloadFileAsync(New Uri(downloadURL), (TextBox2.Text))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pdfQuery = HttpUtility.ParseQueryString(New Uri(TextBox1.Text).Query)
        Dim bookId = pdfQuery.GetValues("bookId")(0)
        Dim cdf = pdfQuery.GetValues("cdf")(0)
        Dim downloadURL = "https://www.iresearchbook.cn/f/cdf/file?file=" + cdf + "&bookId=" + bookId
        Shell("curl -o " + TextBox2.Text + " " + downloadURL)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pdfQuery = HttpUtility.ParseQueryString(New Uri(TextBox1.Text).Query)
        Dim bookId = pdfQuery.GetValues("bookId")(0)
        Dim cdf = pdfQuery.GetValues("cdf")(0)
        Dim downloadURL = "https://www.iresearchbook.cn/f/cdf/file?file=" + cdf + "&bookId=" + bookId
        Clipboard.SetText(downloadURL)
        MessageBox.Show("复制成功！")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        System.Diagnostics.Process.Start("https://github.com/qinlili23333/iresearchDownloader")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        System.Diagnostics.Process.Start("https://www.iresearchbook.cn/")
    End Sub
End Class

