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
            str = "Select * where Assign_Number_ID like '" & search_assets.Text & "%' or Assign_Status like '" & search_assets.Text & "%'"
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
            str = "Select A_No,AssetID,Asset_Number_ID,Asset_Name,Asset_Date,Asset_Location,Asset_Room,Asset_Status,Asset_Department,Asset_Tag_Number,Asset_description from Add_Asset_Tb ORDER BY A_No DESC  "
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
                    count_users.Text = count.ToString()
                    If count_users.Text = 2 Then
                        Label12.Visible = False

                    ElseIf count_users.Text = 1 Then

                        Label12.Visible = True


                    End If

                Catch ex As Exception

                    MessageBox.Show(ex.Message)
                    Me.Dispose()
                End Try
            End Using
        End Using

    End Sub

    Private Sub AddAssetFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get_asign_asset()
        count_login()
        get_asign_asset()
    End Sub





    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        AddAssetFrm.Show()
        Me.Close()
        ' Me.Dispose()
        '  Me.Close()
    End Sub
    Private Sub search__asset()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select A_No,AssetID,Asset_Number_ID,Asset_Name,Asset_Date,Asset_Location,Asset_Room,Asset_Status,Asset_Department,Asset_Tag_Number,Asset_description from Add_Asset_Tb where 
            Asset_Name like '" & search_assets.Text & "%' or Asset_Number_ID like '" & search_assets.Text & "%' 
               or Asset_Number like '" & search_assets.Text & "%' or AssetID like '" & search_assets.Text & "%' or
            Asset_Location like '" & search_assets.Text & "%' or Asset_Room like '" & search_assets.Text & "%' or
            Asset_Status like '" & search_assets.Text & "%' or Asset_Department like '" & search_assets.Text & "%' or
              Asset_Tag_Number like '" & search_assets.Text & "%' or Asset_description like '" & search_assets.Text & "%' 
              and Asset_Status <> 'Pending'  ORDER BY A_No DESC"
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
    Private Sub search_assets_TextChanged(sender As Object, e As EventArgs) Handles search_assets.TextChanged
        search__asset()
    End Sub

    Private Sub Main_Search_Assets_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Main_Search_Assets.CellContentClick







    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        PendingFrm.Show()
    End Sub

    Private Sub Label12_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub get_asign_assets()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select * from Assign_Asset_TB  ORDER BY Alot_ID DESC"
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
    Private Sub ass_search()
        Dim strr As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            strr = "Select * from Assign_Asset_TB where
   Assiginie_Name like'" & TextBox2.Text & "%' or  Assign_Asset_ID like'" & TextBox2.Text & "%' or Assign_Tag_Number like'" & TextBox2.Text & "%' or
         Assign_Current_Status like '%" & TextBox2.Text & "'or Assign_Location like '%" & TextBox2.Text & "%'or Assign_Department like '" & TextBox2.Text & "%' or
         Assign_Current_Status_Date like '%" & TextBox2.Text & "%'or Assign_Room like '" & TextBox2.Text & "%' or
         Assign_description like'" & TextBox2.Text & "%'  ORDER BY Alot_ID DESC"
            cmd = New SqlCommand(strr, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Assign_Asset_TB")
            con.Close()
            Main_Search_Assets.DataSource = ds
            Main_Search_Assets.DataMember = "Assign_Asset_TB"
            Main_Search_Assets.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ass_search()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        RadioButton2.Checked = False
        get_asign_assets()
        panel3.Visible = False
        panel3.Enabled = False
        Panel1.Visible = True
        Panel1.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        RadioButton1.Checked = False
        get_asign_asset()
        Panel1.Visible = False
        Panel1.Enabled = False
        panel3.Visible = True
        panel3.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Admin_CodeFrm.Label3.Text = Label1.Text



        Call (New Admin_CodeFrm()).Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = String.Empty Then
            MsgBox("Type File Name")
        Else
            Dim ask As MsgBoxResult = MsgBox("Are you sure you want to Export", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then

                Dim app As Microsoft.Office.Interop.Excel._Application = New Microsoft.Office.Interop.Excel.Application()
                ' creating new WorkBook within Excel application  
                Dim workbook As Microsoft.Office.Interop.Excel._Workbook = app.Workbooks.Add(Type.Missing)
                ' creating new Excelsheet in workbook  
                Dim worksheet As Microsoft.Office.Interop.Excel._Worksheet = Nothing
                ' see the excel sheet behind the program  
                app.Visible = True
                ' get the reference of first sheet. By default its name is Sheet1.  
                ' store its reference to worksheet  
                worksheet = workbook.Sheets("Sheet1")
                worksheet = workbook.ActiveSheet
                ' changing the name of active sheet  
                worksheet.Name = "Exported from gridview"
                ' storing header part in Excel  
                For i As Integer = 1 To Main_Search_Assets.Columns.Count
                    worksheet.Cells(1, i) = Main_Search_Assets.Columns(i - 1).HeaderText
                Next i
                ' storing Each row and column value to excel sheet  
                For i As Integer = 0 To Main_Search_Assets.Rows.Count - 2
                    For j As Integer = 0 To Main_Search_Assets.Columns.Count - 1
                        worksheet.Cells(i + 2, j + 1) = Main_Search_Assets.Rows(i).Cells(j).Value.ToString()
                    Next j
                Next i
                ' save the application  
                'workbook.SaveAs("D:\" & Val(TextBox1.Text) & ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                ' Exit from the application
                ' 
                workbook.SaveCopyAs("D:\" & Val(TextBox1.Text) & ".xlsx")
                app.Quit()
            ElseIf ask = MsgBoxResult.No Then

                MessageBox.Show("Exporting Cancel")
            End If
        End If

    End Sub

    Private Sub Main_Search_Assets_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Main_Search_Assets.CellContentDoubleClick
        If Main_Search_Assets.Rows(e.RowIndex).Cells(e.ColumnIndex).Value IsNot Nothing Then
            SearchspecificFrm.searchrelated_txt.Text = Main_Search_Assets.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
            SearchspecificFrm.Show()
            Me.Close()
        End If
    End Sub
End Class


