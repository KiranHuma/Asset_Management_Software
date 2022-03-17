Imports System.Data.SqlClient
Imports System.IO
Public Class AddAssetFrm
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

    Private Sub AddAssetFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtboxid()
        txtboxid_assign()
        FillCombo_assign()
        Button1.Visible = True
        'FillCombo_ad_ID()
        count_login()
        get_asset_record()
        'Panel3.Visible = False


        FillCombo_ad_ID()
        FillCombo_ad_location()
        FillCombo_ad_department()
        FillCombo_add_status()

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
    Private Sub get_asset_record()
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim da As New SqlDataAdapter("Select A_No,Asset_Number_ID,Asset_Name,Asset_Date,Asset_Location,Asset_Room,Asset_Status,Asset_Department,Asset_Tag_Number,Asset_description from Add_Asset_Tb where Asset_Status <> 'Pending' ", con)
            Dim dt As New DataTable
            da.Fill(dt)
            source2.DataSource = dt
            asset_gridview.DataSource = dt
            asset_gridview.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving  Data" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub yes_no_dialogue_add()
        Dim ask As MsgBoxResult = MsgBox("Are you sure you want to add", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then

            '  asset_grid()
            insert()
            get_asset_record()
        ElseIf ask = MsgBoxResult.No Then

            MessageBox.Show("Asset not add Successfully")
        End If
    End Sub
    Private Sub txtboxid()
        Try
            Dim num As New Integer
            Dim constr As String = cs
            Using con As SqlConnection = New SqlConnection(constr)
                Using cmd As SqlCommand = New SqlCommand("SELECT MAX(A_No) FROM Add_Asset_Tb ")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()



                    If (IsDBNull(cmd.ExecuteScalar)) Then
                        num = 1
                        id_auto.Text = num.ToString
                    Else

                        num = cmd.ExecuteScalar + 1
                        id_auto.Text = num.ToString
                        ' getvaluedb()

                    End If

                    con.Close()

                End Using
            End Using
        Catch ex As Exception
            MsgBox("Failed:Autoincrement  " & ex.Message)
            Me.Dispose()
        End Try

    End Sub
    Private Sub txtboxid_assign()
        Try
            Dim num As New Integer
            Dim constr As String = cs
            Using con As SqlConnection = New SqlConnection(constr)
                Using cmd As SqlCommand = New SqlCommand("SELECT MAX(Alot_ID) FROM Assign_Asset_TB ")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()



                    If (IsDBNull(cmd.ExecuteScalar)) Then
                        num = 1
                        assign_asset_ID.Text = num.ToString
                    Else

                        num = cmd.ExecuteScalar + 1
                        assign_asset_ID.Text = num.ToString
                        ' getvaluedb()

                    End If

                    con.Close()

                End Using
            End Using
        Catch ex As Exception
            MsgBox("Failed:Autoincrement  " & ex.Message)
            Me.Dispose()
        End Try

    End Sub
    Private Sub insert()
        '  txtboxid()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "INSERT INTO Add_Asset_Tb (A_No,AssetID,Asset_Number,Asset_Number_ID,Asset_Name,Asset_Date,Asset_Location,Asset_Room,Asset_Status,Asset_Department,Asset_Tag_Number,Asset_description)values
                                                 ('" & id_auto.Text & "','" & Asset_Code_txt.Text & "','" & Asset_Number_txt.Text & "','" & asset_concatenate_id_txt.Text & "','" & Asset_Name_txt.Text & "','" & Asset_date_txt.Value & "','" & Asset_location_txt.Text & "','" & asset_room_txt.Text & "','" & asset_status_txt.Text & "','" & asset_department_txt.Text & "','" & asset_tagnumber_txt.Text & "','" & asset_description_txt.Text & "')"

            cmd.ExecuteNonQuery()
            con.Close()

            Me.Hide()
            Call (New AddAssetFrm()).Show()
            '
        Catch ex As Exception
            MsgBox("Data Inserted Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        yes_no_dialogue_add()
    End Sub

    Private Sub Asset_Number_txt_TextChanged(sender As Object, e As EventArgs) Handles Asset_Number_txt.TextChanged
        Dim strMyString As String = Assett_Name_txt.Text
        Dim usertext As String = "IT-"
        Asset_Code_txt.Text = usertext + Microsoft.VisualBasic.Left(strMyString, 2)

        asset_concatenate_id_txt.Text = Asset_Code_txt.Text + separater_txt.Text + Asset_Number_txt.Text
        code_check()




    End Sub
    Public Sub code_check()
        Dim con As New SqlConnection(cs)
        con.Open()
        str = "select count(*)from Add_Asset_Tb where Asset_Number_ID='" & asset_concatenate_id_txt.Text & "'"
        com = New SqlCommand(str, con)
        Dim count As Integer = Convert.ToInt32(com.ExecuteScalar())
        con.Close()
        If count > 0 Then
            Label13.Visible = True
            Label13.Text = "Sorry! Already registered"
            Label13.ForeColor = Color.Red
            'label7.Text = "";
        Else
            Label13.Text = ""
            Label13.Visible = False

        End If

    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Me.Close()
        Admin_CodeFrm.Show()
    End Sub
    Private Sub FillCombo_assign()
        Try
            Dim conn As New System.Data.SqlClient.SqlConnection(cs)
            Dim strSQL As String = "SELECT Asset_Name FROM Add_Asset_Tb where AssetID='IT-EM'"
            Dim da As New System.Data.SqlClient.SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Add_Asset_Tb")
            With Me.assiginie_name_txt
                .DataSource = ds.Tables("Add_Asset_Tb")
                .DisplayMember = "Asset_Name"
                .ValueMember = "Asset_Name"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With



        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving and Populating  " & ex.Message)
            'Me.Dispose()
        End Try
    End Sub

    Private Sub FillCombo_ad_ID()
        Try
            Dim conn As New System.Data.SqlClient.SqlConnection(cs)
            Dim strSQL As String = "SELECT Add_ID_code,Add_subitems FROM Asset_Records where Add_ID_code IS NOT NULL AND Add_ID_code <>'Enter Here' AND Add_subitems IS NULL "
            Dim da As New System.Data.SqlClient.SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Asset_Records")
            With Me.Assett_Name_txt
                .DataSource = ds.Tables("Asset_Records")
                .DisplayMember = "Add_ID_code"
                .ValueMember = "Add_ID_code"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With



        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving and Populating  " & ex.Message)
            'Me.Dispose()
        End Try
    End Sub
    Private Sub FillCombo_ad_location()
        Try
            Dim conn As New System.Data.SqlClient.SqlConnection(cs)
            Dim strSQL As String = "SELECT Add_Location,Add_subitems FROM Asset_Records where Add_Location IS NOT NULL AND Add_Location <>'Enter Here' AND Add_subitems IS NULL"
            Dim da As New System.Data.SqlClient.SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Asset_Records")
            With Me.Asset_location_txt
                .DataSource = ds.Tables("Asset_Records")
                .DisplayMember = "Add_Location"
                .ValueMember = "Add_Location"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With



        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving and Populating  " & ex.Message)
            'Me.Dispose()
        End Try
    End Sub
    Private Sub FillCombo_ad_department()
        Try
            Dim conn As New System.Data.SqlClient.SqlConnection(cs)
            Dim strSQL As String = "SELECT Add_Department,Add_subitems FROM Asset_Records where Add_Department IS NOT NULL AND Add_Department <>'Enter Here'  AND Add_subitems IS NULL "
            Dim da As New System.Data.SqlClient.SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Asset_Records")
            With Me.asset_department_txt
                .DataSource = ds.Tables("Asset_Records")
                .DisplayMember = "Add_Department"
                .ValueMember = "Add_Department"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With



        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving and Populating  " & ex.Message)
            'Me.Dispose()
        End Try
    End Sub
    Private Sub FillCombo_add_status()
        Try
            Dim conn As New System.Data.SqlClient.SqlConnection(cs)
            Dim strSQL As String = "SELECT Add_Statuses,Add_subitems FROM Asset_Records where Add_Statuses IS NOT NULL AND Add_Statuses <>'Enter Here' AND Add_subitems IS NULL "
            Dim da As New System.Data.SqlClient.SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Asset_Records")
            With Me.asset_status_txt
                .DataSource = ds.Tables("Asset_Records")
                .DisplayMember = "Add_Statuses"
                .ValueMember = "Add_Statuses"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With



        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving and Populating  " & ex.Message)
            'Me.Dispose()
        End Try
    End Sub
    Private Sub insert_assign()
        '  txtboxid()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "INSERT INTO Assign_Asset_TB (Alot_ID,Assiginie_Name,Assign_Status,Assign_Date,Assign_Number_ID,Assign_Name,Assign_Location,Assign_Room,Assign_Department,Assign_Tag_Number,Assign_description,Current_Status,Current_Status_Date)values
                                                 ('" & assign_asset_ID.Text & "','" & assiginie_name_txt.Text & "','" & asset_status_txt.Text & "','" & assign_datetxt.Value & "','" & TextBox5.Text & "','" & Asset_Name_txt.Text & "','" & Asset_location_txt.Text & "','" & asset_room_txt.Text & "','" & asset_department_txt.Text & "','" & asset_tagnumber_txt.Text & "','" & asset_description_txt.Text & "','" & Label33.Text & "','" & assign_datetxt.Text & "')"

            cmd.ExecuteNonQuery()
            con.Close()

            Me.Hide()
            Call (New AddAssetFrm()).Show()
            '
        Catch ex As Exception
            MsgBox("Data assigned Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub yes_no_dialogue_assign()
        If assiginie_name_txt.Text = String.Empty Then

            MessageBox.Show("Fill in the Assign the asset")
        Else
            Dim ask As MsgBoxResult = MsgBox("Are you sure you want to assign", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then
                Label17.Text = "Assign"
                ' txtboxid_assign()

                'update_status()
                insert_assign()
                Button5.Enabled = False
                Call (New AddAssetFrm()).Show()
                Me.Hide()
                Me.Close()

            ElseIf ask = MsgBoxResult.No Then

                MessageBox.Show("Asset not assigned")
                Call (New AddAssetFrm()).Show()
                Me.Hide()
                Me.Close()
            End If
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


        yes_no_dialogue_assign()


    End Sub
    Private Sub get_code()
        Dim con As New SqlConnection(cs)
        Try

            Dim command As New SqlCommand("select AssetID,Asset_Number from Add_Asset_Tb where Asset_Number_ID='" & asset_concatenate_id_txt.Text & "'", con)
            con.Open()
            cmd.Parameters.Clear()
            Dim read As SqlDataReader = command.ExecuteReader()

            Do While read.Read()
                Assett_Name_txt.Text = (read("AssetID").ToString())
                Asset_Number_txt.Text = (read("Asset_Number").ToString())
            Loop
            read.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            Me.Dispose()
        End Try
    End Sub




    Private Sub Assett_Name_txt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Assett_Name_txt.SelectedIndexChanged
        Dim strMyString As String = Assett_Name_txt.Text
        Asset_Code_txt.Text = Microsoft.VisualBasic.Left(strMyString, 2)

    End Sub

    Private Sub asset_gridview_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles asset_gridview.CellMouseClick
        Try
            Label15.Text = "Edit"

            Me.id_auto.Text = asset_gridview.CurrentRow.Cells(0).Value.ToString

            Me.TextBox5.Text = asset_gridview.CurrentRow.Cells(1).Value.ToString
            Me.Asset_Name_txt.Text = asset_gridview.CurrentRow.Cells(2).Value.ToString

            Me.Asset_date_txt.Value = asset_gridview.CurrentRow.Cells(3).Value.ToString
            Me.Asset_location_txt.Text = asset_gridview.CurrentRow.Cells(4).Value.ToString
            Me.asset_room_txt.Text = asset_gridview.CurrentRow.Cells(5).Value.ToString
            Me.asset_status_txt.Text = asset_gridview.CurrentRow.Cells(6).Value.ToString
            Me.asset_department_txt.Text = asset_gridview.CurrentRow.Cells(7).Value.ToString
            Me.asset_tagnumber_txt.Text = asset_gridview.CurrentRow.Cells(8).Value.ToString
            Me.asset_description_txt.Text = asset_gridview.CurrentRow.Cells(9).Value.ToString
            ' asset_concatenate_id_txt.Visible = True

            Asset_Number_txt.Visible = False
            Assett_Name_txt.Visible = False
            Label2.Visible = False
            Label1.Visible = False
            Button7.Visible = False
            Label35.Visible = True
            TextBox5.Visible = True
            get_code()
        Catch ex As Exception
            MsgBox("Failed:GridCick " & ex.Message)
            Me.Dispose()
        End Try
    End Sub

    Private Sub asset_gridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles asset_gridview.CellContentClick
        If asset_gridview.Rows(e.RowIndex).Cells(e.ColumnIndex).Value IsNot Nothing Then
            SearchspecificFrm.searchrelated_txt.Text = asset_gridview.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
            SearchspecificFrm.Show()
        End If
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub update2()
        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Add_Asset_Tb set Asset_Number_ID='" & TextBox5.Text & "', Asset_Name='" & Asset_Name_txt.Text & "', Asset_Date='" & Asset_date_txt.Value & "',Asset_Location= '" & Asset_location_txt.Text & "',Asset_Room= '" & asset_room_txt.Text & "',Asset_Status= '" & asset_status_txt.Text & "' ,Asset_Department= '" & asset_department_txt.Text & "',Asset_Tag_Number= '" & asset_tagnumber_txt.Text & "',Asset_description= '" & asset_description_txt.Text & "'  where A_No='" & id_auto.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            get_asset_record()
            MessageBox.Show("Asset Update Successfully")
        Catch ex As Exception
            MsgBox("Data Inserted Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub update_status()
        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Add_Asset_Tb set Asset_Status='" & TextBox6.Text & "' where A_No='" & Label24.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            get_asset_record()
            MessageBox.Show("Asset Update Successfully")
        Catch ex As Exception
            MsgBox("status Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub delete_asset()
        Try
            Dim ObjConnection As New SqlConnection()
            Dim i As Integer
            Dim mResult
            mResult = MsgBox("Want you really delete the selected records?",
            vbYesNo + vbQuestion, "Removal confirmation")
            If mResult = vbNo Then
                Exit Sub
            End If
            ObjConnection.ConnectionString = cs
            Dim ObjCommand As New SqlCommand()
            ObjCommand.Connection = ObjConnection
            For i = Me.asset_gridview.SelectedRows.Count - 1 To 0 Step -1
                ObjCommand.CommandText = "delete from Add_Asset_Tb where A_No='" & asset_gridview.SelectedRows(i).Cells("A_No").Value & "'"
                ObjConnection.Open()
                ObjCommand.ExecuteNonQuery()
                ObjConnection.Close()
                Me.asset_gridview.Rows.Remove(Me.asset_gridview.SelectedRows(i))
            Next
        Catch ex As Exception
            MessageBox.Show("Failed:Deleting Selected Values" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub asset_concatenate_id_txt_Validated(sender As Object, e As EventArgs) Handles asset_concatenate_id_txt.Validated
        If Label15.Text = "noedit" Then
            Dim strMyString As String = Assett_Name_txt.Text
            Asset_Code_txt.Text = Microsoft.VisualBasic.Left(strMyString, 2)

            asset_concatenate_id_txt.Text = Asset_Code_txt.Text + separater_txt.Text + Asset_Number_txt.Text
            code_check()


        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        delete_asset()
        get_asset_record()
    End Sub


    Private Sub search__asset()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select A_No,Asset_Number_ID,Asset_Name,Asset_Date,Asset_Location,Asset_Room,Asset_Status,Asset_Department,Asset_Tag_Number,Asset_description from Add_Asset_Tb where Asset_Name like '" & TextBox1.Text & "%' or Asset_Number_ID like '" & TextBox1.Text & "%' and Asset_Status <> 'Pending'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Add_Asset_Tb")
            con.Close()
            asset_gridview.DataSource = ds
            asset_gridview.DataMember = "Add_Asset_Tb"
            asset_gridview.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub










    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        Button1.Visible = True
        Button5.Visible = False
        Button8.Visible = False
        Button10.Visible = False
        Button19.Visible = False
    End Sub





    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text = "" Then
            get_asset_record()
        Else
            search__asset()
        End If
    End Sub






    Private Sub assignasset_status_SelectedIndexChanged(sender As Object, e As EventArgs)
        '  status_control()
    End Sub


    Private Sub multiple_values_assign()
        Dim ask As MsgBoxResult = MsgBox("Are you sure you want to assign Again", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then

            Button5.Enabled = True

        ElseIf ask = MsgBoxResult.No Then

            MessageBox.Show("Select an other asset")
        End If
    End Sub






    Private Sub assign_gridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub












    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        txtboxid_assign()

        Dim ask As MsgBoxResult = MsgBox("Are you sure you want to Reassign", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then


            Button5.Enabled = True
        ElseIf ask = MsgBoxResult.No Then

            MessageBox.Show("Asset not Reassigned")
        End If

    End Sub

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        Apply_to_All_Record.Label3.Text = asset_gridview.CurrentRow.Cells(1).Value.ToString

        Apply_to_All_Record.Show()
        Me.Close()
    End Sub





    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Addsub_itemsFrm.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Addsub_itemsFrm.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Addsub_itemsFrm.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Addsub_itemsFrm.Show()
        Me.Close()
    End Sub



























    Private Sub reset_addasset_db()

        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "delete from Add_Asset_Tb"

            cmd.ExecuteNonQuery()
            con.Close()
            get_asset_record()
            '  MessageBox.Show("Reset Successfully")
        Catch ex As Exception
            MsgBox(" Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub reset_Asset_Records_db()

        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "delete from Asset_Records"

            cmd.ExecuteNonQuery()
            con.Close()
            get_asset_record()
            'MessageBox.Show("Reset Successfully")
        Catch ex As Exception
            MsgBox(" Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub reset_Assign_Asset_TB_db()

        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "delete from Assign_Asset_TB"

            cmd.ExecuteNonQuery()
            con.Close()
            get_asset_record()
            MessageBox.Show("Reset Successfully")
        Catch ex As Exception
            MsgBox(" Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub Resetbtn_Click(sender As Object, e As EventArgs)


        Dim ask As MsgBoxResult = MsgBox("Are you sure you want to reset.All data will delete permanently", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then

            reset_addasset_db()
            reset_Asset_Records_db()
            reset_Assign_Asset_TB_db()
        ElseIf ask = MsgBoxResult.No Then

            MessageBox.Show("Resetting Cancel successfully")
        End If
    End Sub

    Private Sub Button8_MouseClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)
        Dim f2 As New AddAssetFrm
        Me.Dispose()  '~~> Or Me.Close()
        f2.Show()

    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs)
        insert()
    End Sub

    Private Sub Button8_Click_2(sender As Object, e As EventArgs) Handles Button8.Click
        'update_asset()
        update2()
        get_asset_record()
        ' Dim f2 As New AddAssetFrm
        ' Me.Dispose()  '~~> Or Me.Close()
        ' f2.Show()
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub



    Private Sub assign_date_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        Button1.Visible = False
        Button5.Visible = True
        Button8.Visible = True
        Button10.Visible = True
        Button19.Visible = True
    End Sub

    Private Sub TabPage1_DragLeave(sender As Object, e As EventArgs) Handles TabPage1.DragLeave

    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click

    End Sub
End Class