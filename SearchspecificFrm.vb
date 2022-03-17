Imports System.Data.SqlClient
Imports System.IO

Public Class SearchspecificFrm

    Dim cmd As New SqlCommand()
    Dim con As New SqlConnection()
    Dim str As String
    Dim com As SqlCommand
    Dim source2 As New BindingSource()
    Dim source3 As New BindingSource()
    Dim ds As DataSet = New DataSet
    Dim da As SqlDataAdapter
    Dim cs As String = "Data Source=ANIRUDH;Initial Catalog=assetmanagement_DB;Integrated Security=true"
    Private Sub dbaccessconnection()
        Try
            con.ConnectionString = cs
            cmd.Connection = con
        Catch ex As Exception
            MsgBox("DataBase not connected due to the reason because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub SearchspecificFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    '  str = "Select A_ID,Assiginie_Name,Assign_Status,Assign_Date,Assign_Number_ID,Assign_Name,Assign_Location,Assign_Room,Assign_Department,Assign_Tag_Number,Assign_description,Current_Status,Current_Status_Date from Assign_Asset_TB 


    Private Sub search__asset()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select Assiginie_Name,Assign_Status,Assign_Date,Assign_Number_ID,Assign_Name as [Asset_Name],Assign_Location,Assign_Room,
Assign_Department,Assign_Tag_Number,Assign_description,Current_Status,Current_Status_Date from Assign_Asset_TB  where 

Assign_Status like '" & searchrelated_txt.Text & "%' or Assign_Number_ID like '" & searchrelated_txt.Text & "%' or

Assign_Name  like '" & searchrelated_txt.Text & "%' or Assign_Location like '" & searchrelated_txt.Text & "%'  Or 
Assign_Room like '" & searchrelated_txt.Text & "%' or Assign_Department like '" & searchrelated_txt.Text & "%' or

Assign_description  like '" & searchrelated_txt.Text & "%' "


            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Add_Asset_Tb")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "Add_Asset_Tb"
            DataGridView1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub

    Private Sub searchrelated_txt_TextChanged(sender As Object, e As EventArgs) Handles searchrelated_txt.TextChanged
        search__asset()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class