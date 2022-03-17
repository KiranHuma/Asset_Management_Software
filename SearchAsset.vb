Imports System.Data.SqlClient
Imports System.IO
Public Class SearchAsset

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

    Private Sub search__any_asset()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select Alot_ID,Assiginie_Name,Assign_Status,Assign_Date,Assign_Number_ID,Assign_Name,Assign_Location,Assign_Room,Assign_Department,Assign_Tag_Number,Assign_description from Assign_Asset_TB where Assign_Number_ID like '" & search_assets.Text & "%' or Assign_Status like '" & search_assets.Text & "%'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Main_Search_Assets")
            con.Close()
            Main_Search_Assets.DataSource = ds
            Main_Search_Assets.DataMember = "Main_Search_Assets"
            Main_Search_Assets.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private Sub get_asign_asset()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select AssetID,Asset_Number_ID,Asset_Name,Asset_Date,Asset_Location,Asset_Room,Asset_Status,Asset_Department,Asset_Tag_Number,Asset_description from Add_Asset_Tb "
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Main_Search_Assets")
            con.Close()
            Main_Search_Assets.DataSource = ds
            Main_Search_Assets.DataMember = "Main_Search_Assets"
            Main_Search_Assets.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub

    Private Sub search__asset()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select AssetID,Asset_Number_ID,Asset_Name,Asset_Location,Asset_Room,Asset_Status,Asset_Department,Asset_Tag_Number,Asset_description from Add_Asset_Tb where Asset_Name like '" & search_assets.Text & "%' or Asset_Number_ID like '" & search_assets.Text & "%' "
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Add_Asset_Tb")
            con.Close()
            Main_Search_Assets.DataSource = ds
            Main_Search_Assets.DataMember = "Add_Asset_Tb"
            Main_Search_Assets.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub


    Private Sub AddAssetFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get_asign_asset()
    End Sub


    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        get_asign_asset()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub asset_gridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub asset_gridview_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)

    End Sub

    Private Sub asset_concatenate_id_txt_Validated(sender As Object, e As EventArgs)

    End Sub

    Private Sub Asset_Number_txt_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Assett_Name_txt_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        AddAssetFrm.Show()
    End Sub

    Private Sub search_assets_TextChanged(sender As Object, e As EventArgs) Handles search_assets.TextChanged

    End Sub

    Private Sub Main_Search_Assets_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Main_Search_Assets.CellContentClick


        '  SearchspecificFrm.id_auto.Text = Main_Search_Assets.CurrentRow.Cells(0).Value.ToString
        '
        ' SearchspecificFrm.Assett_Name_txt.Text = Main_Search_Assets.CurrentRow.Cells(1).Value.ToString
        ' SearchspecificFrm.Asset_Number_txt.Text = Main_Search_Assets.CurrentRow.Cells(2).Value.ToString

        ' SearchspecificFrm.TextBox5.Text = Main_Search_Assets.CurrentRow.Cells(3).Value.ToString
        ' SearchspecificFrm.Asset_Name_txt.Text = Main_Search_Assets.CurrentRow.Cells(4).Value.ToString
        ' SearchspecificFrm.Asset_date_txt.Value = Main_Search_Assets.CurrentRow.Cells(5).Value.ToString
        ' SearchspecificFrm.Asset_location_txt.Text = Main_Search_Assets.CurrentRow.Cells(6).Value.ToString
        ' SearchspecificFrm.asset_room_txt.Text = Main_Search_Assets.CurrentRow.Cells(7).Value.ToString
        ' SearchspecificFrm.asset_status_txt.Text = Main_Search_Assets.CurrentRow.Cells(8).Value.ToString
        ' SearchspecificFrm.asset_department_txt.Text = Main_Search_Assets.CurrentRow.Cells(9).Value.ToString
        ' SearchspecificFrm.asset_tagnumber_txt.Text = Main_Search_Assets.CurrentRow.Cells(10).Value.ToString
        ' SearchspecificFrm.asset_description_txt.Text = Main_Search_Assets.CurrentRow.Cells(11).Value.ToString


        ' SearchspecificFrm.Show()

        If Main_Search_Assets.Rows(e.RowIndex).Cells(e.ColumnIndex).Value IsNot Nothing Then
            SearchspecificFrm.searchrelated_txt.Text = Main_Search_Assets.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
            SearchspecificFrm.Show()
        End If


    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        PendingFrm.Show()
    End Sub
End Class