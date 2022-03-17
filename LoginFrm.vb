Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Public Class LoginFrm
    Private cmd As New SqlCommand()
    Private con As New SqlConnection()

    Dim cs As String = "Data Source=ANIRUDH;Initial Catalog=assetmanagement_DB;Integrated Security=True"
    Public Sub dbaccessconnection()
        Try
            Dim connection As New SqlConnection(cs)
            cmd.Connection = con

            '  MessageBox.Show("Connected");
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("Database not Connected")
        End Try
    End Sub
    Private Sub get_login_count()
        Dim connStr As String = cs
        Dim query As String = "SELECT count(*) FROM Adminn_Tb where User_ID='" & loginID.Text & "' AND User_Code='" & TextBox3.Text & "'"
        Using conn As New SqlConnection(connStr)
            Using cmd As New SqlCommand()
                With cmd
                    .Connection = conn
                    .CommandText = query
                    .CommandType = CommandType.Text
                End With
                Try
                    conn.Open()
                    Dim count As Int16 = Convert.ToInt16(cmd.ExecuteScalar())
                    '  MsgBox(count.ToString()
                    Label4.Text = count.ToString()
                    If Label4.Text = 1 Then
                        Label3.Visible = False
                        Label8.Visible = False
                        Me.Hide()
                        SearchAsset.Show()
                    Else

                        MsgBox("Invalid login")

                    End If

                Catch ex As Exception

                    MessageBox.Show(ex.Message)
                    Me.Dispose()
                End Try
            End Using
        End Using
    End Sub
    Private Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
         &H65, &H64, &H76, &H65, &H64, &H65,
         &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function
    Private Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
         &H65, &H64, &H76, &H65, &H64, &H65,
         &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

    Private Sub count_login()
        Dim connStr As String = cs
        Dim query As String = "SELECT count(*) FROM Adminn_Tb "
        Using conn As New SqlConnection(connStr)
            Using cmd As New SqlCommand()
                With cmd
                    .Connection = conn
                    .CommandText = query
                    .CommandType = CommandType.Text
                End With
                Try
                    conn.Open()
                    Dim count As Int16 = Convert.ToInt16(cmd.ExecuteScalar())
                    '  MsgBox(count.ToString()
                    Label4.Text = count.ToString()
                    If Label4.Text = 1 Then
                        Label3.Visible = False
                        Label8.Visible = False
                    ElseIf Label4.Text = 0 Then

                        Label3.Visible = True
                        Label8.Visible = True

                    End If

                Catch ex As Exception

                    MessageBox.Show(ex.Message)
                    Me.Dispose()
                End Try
            End Using
        End Using

    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        count_login()
    End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtPass.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox3.Text = Encrypt(txtPass.Text)
        get_login_count()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

        Admin_CodeFrm.Show()
        Me.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub loginID_TextChanged(sender As Object, e As EventArgs) Handles loginID.TextChanged

    End Sub
End Class
