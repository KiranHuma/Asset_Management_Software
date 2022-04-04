Imports System.Data.SqlClient
Imports System.IO
Public Class Apply_to_All_Record

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
    Private Sub Apply_to_All_Record_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Label3.Visible = False
        'Label4.Visible = False
        'Label5.Visible = False
        If Label8.Text = "Tmain" Then
            get_asign_main_asset()
        Else
            get_asign_asset()
        End If
    End Sub
    Private Sub update_main_table_pending()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Add_Asset_Tb set Asset_Status='" & pending_lbl.Text & "', Asset_Date='" & DateTimePicker1.Value & "' where Asset_Number_ID='" & asst_id_number.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            ' get_asset_record()
            '  MessageBox.Show("Operation completed Successfully")
        Catch ex As Exception
            MessageBox.Show("Failed:Deleting Selected Values" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub no_terminate_from_main_to_all_assign()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Assign_Asset_TB set Current_Status='" & pending_lbl.Text & "', Current_Status_Date='" & DateTimePicker1.Value & "' where Assign_Number_ID='" & asst_id_number.Text & "' AND Current_Status='Running'"

            cmd.ExecuteNonQuery()
            con.Close()
            ' get_asset_record()
            '  MessageBox.Show("Operation completed Successfully")
        Catch ex As Exception
            MessageBox.Show("Failed:Deleting Selected Values" & ex.Message)
            Me.Dispose()
        End Try
    End Sub



    Private Sub no_terminate()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Assign_Asset_TB set Current_Status='" & pending_lbl.Text & "', Current_Status_Date='" & DateTimePicker1.Value & "' where Assiginie_Name='" & assinie_nme_lbl.Text & "' AND Current_Status='Running'"

            cmd.ExecuteNonQuery()
            con.Close()
            ' get_asset_record()
            '  MessageBox.Show("Operation completed Successfully")
        Catch ex As Exception
            MessageBox.Show("Failed:Deleting Selected Values" & ex.Message)
            Me.Dispose()
        End Try
    End Sub

    Private Sub update_main_table_terminate_running()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Add_Asset_Tb set Asset_Status='" & terminate_lbl.Text & "', Asset_Date='" & DateTimePicker1.Value & "' where Asset_Number_ID='" & asst_id_number.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            ' get_asset_record()
            '  MessageBox.Show("Operation completed Successfully")
        Catch ex As Exception
            MessageBox.Show("Failed:Deleting Selected Values" & ex.Message)
            Me.Dispose()
        End Try
    End Sub

    Private Sub update_running()
        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Assign_Asset_TB set Current_Status='" & terminate_lbl.Text & "', Current_Status_Date='" & DateTimePicker1.Value & "' where Assiginie_Name='" & assinie_nme_lbl.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            ' get_asset_record()
            '   MessageBox.Show("Operation completed Successfully")
        Catch ex As Exception
            MsgBox("Data Inserted Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub update_running_assign_from_main()
        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Assign_Asset_TB set Current_Status='" & terminate_lbl.Text & "', Current_Status_Date='" & DateTimePicker1.Value & "' where Assign_Number_ID ='" & asst_id_number.Text & "'   AND Current_Status='Running'"

            cmd.ExecuteNonQuery()
            con.Close()
            ' get_asset_record()
            '   MessageBox.Show("Operation completed Successfully")
        Catch ex As Exception
            MsgBox("Data Inserted Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub

    Private Sub get_asign_asset()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select Alot_ID,Assiginie_Name,Assign_Status,Assign_Date,Assign_Number_ID,Assign_Name,Assign_Location,Assign_Room,Assign_Department,Assign_Tag_Number,Assign_description,Current_Status,Current_Status_Date from Assign_Asset_TB where  Assiginie_Name ='" & assinie_nme_lbl.Text & "'   AND Current_Status='" & running_tbl.Text & "' "
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Assign_Asset_TB")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "Assign_Asset_TB"
            DataGridView1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub

    Private Sub get_asign_main_asset()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select Alot_ID,Assiginie_Name,Assign_Status,Assign_Date,Assign_Number_ID,Assign_Name,Assign_Location,Assign_Room,Assign_Department,Assign_Tag_Number,Assign_description,Current_Status,Current_Status_Date from Assign_Asset_TB where  Assign_Number_ID ='" & asst_id_number.Text & "' AND Current_Status='Running' "
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Assign_Asset_TB")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "Assign_Asset_TB"
            DataGridView1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim ask As MsgBoxResult = MsgBox("All above values will be terminated", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then


            'update_main_table()
            If Label8.Text = "Tmain" Then
                get_asign_main_asset()
                update_main_table_terminate_running()
                update_running_assign_from_main()
                AddAssetFrm.ShowDialog()
                Me.Close()
            Else
                get_asign_asset()
                update_running()
                AddAssetFrm.ShowDialog()
                Me.Close()
            End If

            MessageBox.Show("All Assets Terminated successfully")
                ElseIf ask = MsgBoxResult.No Then
            If Label8.Text = "Tmain" Then

                update_main_table_pending()
                no_terminate_from_main_to_all_assign()
            Else
                get_asign_asset()
                no_terminate()
                no_terminate_from_main_to_all_assign()
                update_main_table_pending()
            End If


                MessageBox.Show("Termination Cancel successfully")
            End If

        If Label8.Text = "Tmain" Then
            get_asign_main_asset()


        Else
            get_asign_asset()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)


        Call (New SearchAsset()).Show()
        Me.Close()
    End Sub





    Private Sub Button3_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) 
        'update_main_table()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Call (New AddAssetFrm()).Show()

        Me.Close()
    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs)
        ' get_asign_asset()
    End Sub

    Private Sub Button2_Click_3(sender As Object, e As EventArgs) Handles Button2.Click
        Call (New AddAssetFrm()).Show()

        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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
End Class