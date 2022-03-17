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
        get_asign_asset()
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
    End Sub


    Private Sub no_terminate()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Assign_Asset_TB set Current_Status='" & Label7.Text & "', Current_Status_Date='" & DateTimePicker1.Value & "' where Assign_Number_ID='" & Label3.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            ' get_asset_record()
            '  MessageBox.Show("Operation completed Successfully")
        Catch ex As Exception
            MessageBox.Show("Failed:Deleting Selected Values" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub update_main_table()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Add_Asset_Tb set Asset_Status='" & Label4.Text & "', Asset_Date='" & DateTimePicker1.Value & "' where Asset_Number_ID='" & Label3.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            ' get_asset_record()
            '  MessageBox.Show("Operation completed Successfully")
        Catch ex As Exception
            MessageBox.Show("Failed:Deleting Selected Values" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub update_main_table_pending()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Add_Asset_Tb set Asset_Status='" & Label7.Text & "', Asset_Date='" & DateTimePicker1.Value & "' where Asset_Number_ID='" & Label3.Text & "'"

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
            cmd.CommandText = "Update Assign_Asset_TB set Current_Status='" & Label4.Text & "', Current_Status_Date='" & DateTimePicker1.Value & "' where Assign_Number_ID='" & Label3.Text & "'"

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
            str = "Select Alot_ID,Assiginie_Name,Assign_Status,Assign_Date,Assign_Number_ID,Assign_Name,Assign_Location,Assign_Room,Assign_Department,Assign_Tag_Number,Assign_description,Current_Status,Current_Status_Date from Assign_Asset_TB where Assign_Number_ID='" & Label3.Text & "' And Current_Status='Running' "
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

            update_running()
            update_main_table()
            SearchAsset.Show()
                    Me.Close()
                    MessageBox.Show("All Assets Terminated successfully")
                ElseIf ask = MsgBoxResult.No Then
            no_terminate()
            'update_main_table_pending()
            MessageBox.Show("Termination Cancel successfully")
                End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        SearchAsset.Show()
        Me.Close()
    End Sub





    Private Sub Button3_Click_2(sender As Object, e As EventArgs) Handles Button3.Click
        AddAssetFrm.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        'update_main_table()
    End Sub
End Class