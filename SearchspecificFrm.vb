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

Assign_description  like '" & searchrelated_txt.Text & "%' or Current_Status  like '" & searchrelated_txt.Text & "%' or

Assign_Tag_Number  like '" & searchrelated_txt.Text & "%' or Assign_description  like '" & searchrelated_txt.Text & "%'
"


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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        SearchAsset.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
                For i As Integer = 1 To DataGridView1.Columns.Count
                    worksheet.Cells(1, i) = DataGridView1.Columns(i - 1).HeaderText
                Next i
                ' storing Each row and column value to excel sheet  
                For i As Integer = 0 To DataGridView1.Rows.Count - 2
                    For j As Integer = 0 To DataGridView1.Columns.Count - 1
                        worksheet.Cells(i + 2, j + 1) = DataGridView1.Rows(i).Cells(j).Value.ToString()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AddAssetFrm.Show()
        Me.Hide()
    End Sub
End Class