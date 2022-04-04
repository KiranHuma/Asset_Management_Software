Imports System.ComponentModel
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
        ' FillCombo_assign()
        get_asset_record()
        'Panel3.Visible = False
        Panel4.Visible = False
        Panel3.Visible = False
        Panel1.Visible = True
        Panel5.Visible = True
        FillCombo_ad_ID()
        FillCombo_ad_location()
        FillCombo_ad_department()
        FillCombo_add_status()

    End Sub
    Private Sub get_asign_assets()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select Alot_ID,Assiginie_Name as [Assignie Name],Assign_Status as [Status],Assign_Date,Assign_Number_ID,Assign_Name as [Asset_Name],Assign_Location,Assign_Room,
            Assign_Department,Assign_Tag_Number,Assign_description,Current_Status,Current_Status_Date from Assign_Asset_TB "
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "DataGridView1")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "DataGridView1"
            DataGridView1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
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
        If asset_concatenate_id_txt.Text = String.Empty Then

            MessageBox.Show("Asset Number should not empty")
        Else

            Dim ask As MsgBoxResult = MsgBox("Are you sure you want to add", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then

                '  asset_grid()
                insert()
                get_asset_record()
            ElseIf ask = MsgBoxResult.No Then

                MessageBox.Show("Asset not add Successfully")
            End If
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


            Call (New AddAssetFrm()).Show()
            Me.Close()
            Me.Dispose()
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


    Private Sub FillCombo_assign()
        Try
            Dim conn As New System.Data.SqlClient.SqlConnection(cs)
            'Dim strSQL As String = "SELECT DISTINCT Asset_Name FROM Add_Asset_Tb "
            Dim strSQL As String = "SELECT  Asset_Name FROM Add_Asset_Tb "
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


            assign_tab_refresh()
        Catch ex As Exception
            MsgBox("Data assigned Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub yes_no_dialogue_assign()
        If assiginie_name_txt.Text = String.Empty Then

            MessageBox.Show("Fill in the Assign the asset")
        ElseIf Asset_Name_txt.Text = String.Empty Then
            MessageBox.Show("Select asset to assign")
        Else
            Dim ask As MsgBoxResult = MsgBox("Are you sure you want to assign", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then
                Label17.Text = "Assign"
                ' txtboxid_assign()

                'update_status()
                insert_assign()
                Button5.Enabled = False
                assign_tab_refresh()

            ElseIf ask = MsgBoxResult.No Then

                MessageBox.Show("Asset not assigned")
                Call (New AddAssetFrm()).Show()
                Me.Dispose()

            End If
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel4.Visible = True
        Panel3.Visible = False
        Panel1.Visible = True
        Panel5.Visible = False
        Panel7.Visible = False
        Panel8.Visible = True

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

    End Sub

    Private Sub update2()
        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Add_Asset_Tb set Asset_Number_ID='" & TextBox5.Text & "', Asset_Name='" & Asset_Name_txt.Text & "', Asset_Date='" & Asset_date_txt.Value & "',Asset_Location= '" & Asset_location_txt.Text & "',Asset_Room= '" & asset_room_txt.Text & "',Asset_Status= '" & asset_status_txt.Text & "' ,Asset_Department= '" & asset_department_txt.Text & "',Asset_Tag_Number= '" & asset_tagnumber_txt.Text & "',Asset_description= '" & asset_description_txt.Text & "'  where A_No='" & id_auto.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            get_asset_record()
            ' MessageBox.Show("Asset Update Successfully")
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


    Private Sub search__asset()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select AssetID,Asset_Number_ID,Asset_Name,Asset_Date,Asset_Location,Asset_Room,Asset_Status,Asset_Department,Asset_Tag_Number,Asset_description from Add_Asset_Tb where 
            Asset_Name like '" & TextBox1.Text & "%' or Asset_Number_ID like '" & TextBox1.Text & "%' 
               or Asset_Number like '" & TextBox1.Text & "%' or AssetID like '" & TextBox1.Text & "%' or
            Asset_Location like '" & TextBox1.Text & "%' or Asset_Room like '" & TextBox1.Text & "%' or
            Asset_Status like '" & TextBox1.Text & "%' or Asset_Department like '" & TextBox1.Text & "%' or
              Asset_Tag_Number like '" & TextBox1.Text & "%' or Asset_description like '" & TextBox1.Text & "%' 
              and Asset_Status <> 'Pending'"
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
        Panel4.Visible = False
        Panel3.Visible = False
        Panel1.Visible = True
        Panel5.Visible = True


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text = "" Then
            get_asset_record()
        Else
            search__asset()
        End If
    End Sub







    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        Apply_to_All_Record.asst_id_number.Text = asset_gridview.CurrentRow.Cells(1).Value.ToString

        Apply_to_All_Record.Label8.Text = "Tmain"



        Apply_to_All_Record.Show()
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click


        Call (New Addsub_itemsFrm()).Show()
        Me.Close()
        Me.Dispose()
        'Me.Dispose()
        'Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call (New Addsub_itemsFrm()).Show()
        Me.Close()
        Me.Dispose()
        'Me.Dispose()
        'Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call (New Addsub_itemsFrm()).Show()
        Me.Close()
        Me.Dispose()
        'Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call (New Addsub_itemsFrm()).Show()
        Me.Close()
        Me.Dispose()
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









    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        Panel4.Visible = True
        Panel3.Visible = True
        Panel1.Visible = False
        Panel5.Visible = False
        get_asign_assets()
    End Sub



    Private Sub assiginie_name_txt_TextChanged(sender As Object, e As EventArgs) Handles assiginie_name_txt.TextChanged
        Panel4.Visible = True
        Panel3.Visible = False
        Panel1.Visible = True
        Panel5.Visible = False
    End Sub



    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click



        If Asset_Name_txt.Text = String.Empty Then

            MessageBox.Show("Fill in the Assign the asset")

        Else
            Dim ask As MsgBoxResult = MsgBox("Are you sure you want to update", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then


                'update_status()
                update2()
                get_asset_record()
                Call (New AddAssetFrm()).Show()
                Me.Close()

                Me.Dispose()
            ElseIf ask = MsgBoxResult.No Then

                MessageBox.Show("Asset not Update")
                Call (New AddAssetFrm()).Show()

                Me.Close()
                Me.Dispose()
            End If
        End If

    End Sub


    Private Sub asset_gridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles asset_gridview.CellDoubleClick
        If asset_gridview.Rows(e.RowIndex).Cells(e.ColumnIndex).Value IsNot Nothing Then
            SearchspecificFrm.searchrelated_txt.Text = asset_gridview.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()

            SearchspecificFrm.Show()
            Me.Close()
            Me.Dispose()
        End If
    End Sub



    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Me.Label24.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        Me.ComboBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        Me.assignasset_status.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        Me.assign_datetxt.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString

        Me.assignasset_id.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString

        Me.assign_Asset_Name_txt.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString

        Me.assign_Asset_location_txt.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
        Me.assign_Asset_room_txt.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString


        Me.assign_Asset_department_txt.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString
        Me.assign_Asset_tag_txt.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString
        Me.assign_Asset_description_txt.Text = DataGridView1.CurrentRow.Cells(10).Value.ToString
        'get_code()
        Panel7.Visible = True
        Panel8.Visible = False
    End Sub
    Private Sub update_assign()
        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Assign_Asset_TB set Assiginie_Name='" & ComboBox1.Text & "', Assign_Status='" & assignasset_status.Text & "', Assign_Date='" & assign_datetxt.Text & "',
         Assign_Number_ID= '" & assignasset_id.Text & "',Assign_Name = '" & assign_Asset_Name_txt.Text & "',Assign_Location= '" & assign_Asset_location_txt.Text & "' ,
         Assign_Room= '" & assign_Asset_room_txt.Text & "',Assign_Department= '" & assign_Asset_department_txt.Text & "',
         Assign_Tag_Number= '" & assign_Asset_tag_txt.Text & "'  ,Assign_description= '" & assign_Asset_description_txt.Text & "' 
         where Alot_ID='" & Label24.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            get_asset_record()
            ' MessageBox.Show("Asset Update Successfully")
        Catch ex As Exception
            MsgBox("Data Inserted Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel4.Visible = True
        Panel3.Visible = True
        Panel1.Visible = False
        Panel5.Visible = False

        If ComboBox1.Text = String.Empty Then

            MessageBox.Show("Select value from List to Update")

        Else
            Dim ask As MsgBoxResult = MsgBox("Are you sure you want to update", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then


                'update_status()
                update_assign()

                get_asign_assets()

                assign_tab_refresh()
                Panel7.Visible = False
                Panel8.Visible = True

            ElseIf ask = MsgBoxResult.No Then

                MessageBox.Show("Asset not Update")
                Call (New AddAssetFrm()).Show()

                Me.Close()
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value IsNot Nothing Then
            SearchspecificFrm.searchrelated_txt.Text = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()

            SearchspecificFrm.Show()
            Me.Close()
            Me.Dispose()
        End If
    End Sub
    Private Sub ass_search()
        Dim strr As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            strr = "Select Alot_ID,Assiginie_Name,Assign_Status,Assign_Date,Assign_Number_ID,Assign_Name as [Asset_Name],Assign_Location,Assign_Room,
            Assign_Department,Assign_Tag_Number,Assign_description,Current_Status,Current_Status_Date from Assign_Asset_TB where 

              Assign_Status like '" & TextBox2.Text & "%' or Assiginie_Name  like '" & TextBox2.Text & "%'or
           Assign_Number_ID like '" & TextBox2.Text & "%' or

             Assign_Name  like '" & TextBox2.Text & "%' or Assign_Location like '" & TextBox2.Text & "%'  or 
            Assign_Room like '" & TextBox2.Text & "%' or Assign_Department like '" & TextBox2.Text & "%' or

            Assign_description  like '" & TextBox2.Text & "%' or Current_Status  like '" & TextBox2.Text & "%' or

          Assign_Tag_Number  like '" & TextBox2.Text & "%' or Assign_description  like '" & TextBox2.Text & "%'"
            cmd = New SqlCommand(strr, con)
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
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ass_search()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Panel4.Visible = True
        Panel3.Visible = True
        Panel1.Visible = False
        Panel5.Visible = False
        If Label32.Text = "Ter" Then
            MsgBox("Select the asset to terminate all assets linked to it")
        Else
            Label32.Text = "Terminate"
            Apply_to_All_Record.asst_id_number.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
            Apply_to_All_Record.assinie_nme_lbl.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString

            Apply_to_All_Record.Show()
            Me.Close()
            Me.Dispose()
        End If


    End Sub
    Private Sub remove_link()
        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Assign_Asset_TB set Current_Status='Returned',Current_Status_Date = '" & assign_datetxt.Value & "' where Alot_ID='" & Label24.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            get_asset_record()
            ' MessageBox.Show("Asset Update Successfully")
        Catch ex As Exception
            MsgBox("status Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Panel4.Visible = True
        Panel3.Visible = True
        Panel1.Visible = False
        Panel5.Visible = False
        If Label24.Text = String.Empty Then

            MessageBox.Show("Select value from List to RemoveLink")

        Else
            Dim ask As MsgBoxResult = MsgBox("Are you sure you want to Remove Link", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then


                'update_status()
                remove_link()

                get_asign_assets()

                Call (New AddAssetFrm()).Show()
                Me.Close()
                Me.Dispose()
                Panel7.Visible = False
                Panel8.Visible = True

            ElseIf ask = MsgBoxResult.No Then

                MessageBox.Show("Asset not Update")
                Call (New AddAssetFrm()).Show()

                Me.Close()
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub DeletePermanentlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletePermanentlyToolStripMenuItem.Click


        If TextBox5.Text = String.Empty Then

            MessageBox.Show("Select Asset from List to delete Permanently")

        Else
            Dim ask As MsgBoxResult = MsgBox("Are you sure you want to delete,,The associated assets will Terminate and remain in record", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then


                'update_status()
                delete_asset()
                terminate_assets_permanantly_status()

                Call (New AddAssetFrm()).Show()
                Me.Close()
                Me.Dispose()
                Panel7.Visible = False
                Panel8.Visible = True

            ElseIf ask = MsgBoxResult.No Then

                MessageBox.Show("Asset not Delete")
                Call (New AddAssetFrm()).Show()

                Me.Close()
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub terminate_assets_permanantly_status()
        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Assign_Asset_TB set Current_Status='Terminate' ,Current_Status_Date = '" & assign_datetxt.Value & "' where Assign_Number_ID='" & TextBox5.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            get_asset_record()
            ' MessageBox.Show("Asset Update Successfully")
        Catch ex As Exception
            MsgBox("status Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub get_code_assign()
        Dim con As New SqlConnection(cs)
        Try

            Dim command As New SqlCommand("select AssetID,Asset_Number from Add_Asset_Tb where Asset_Name='" & assiginie_name_txt.Text & "'", con)
            con.Open()
            cmd.Parameters.Clear()
            Dim read As SqlDataReader = command.ExecuteReader()

            Do While read.Read()
                ' TextBox4.Text = (read("AssetID").ToString())
                TextBox4.Text = (read("Asset_Number").ToString())
            Loop
            read.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click


        Call (New SearchAsset()).Show()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Call (New AddAssetFrm()).Show()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click


        Dim ask As MsgBoxResult = MsgBox("All previous Records will permanantly delete", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then


            reset_addasset_db()
            reset_Asset_Records_db()
            reset_Assign_Asset_TB_db()
            Application.Exit()

        ElseIf ask = MsgBoxResult.No Then

            MessageBox.Show("Reset Cancel")
            Call (New AddAssetFrm()).Show()

            Me.Close()
            Me.Dispose()
        End If

    End Sub
    Private Sub FillCombo_assign_get_id()
        Try
            Dim conn As New System.Data.SqlClient.SqlConnection(cs)
            'Dim strSQL As String = "SELECT DISTINCT Asset_Name FROM Add_Asset_Tb "
            Dim strSQL As String = "SELECT  Asset_Name,Asset_Number FROM Add_Asset_Tb where Asset_Name='" & assiginie_name_txt.Text & "' "
            Dim da As New System.Data.SqlClient.SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Add_Asset_Tb")
            With Me.TextBox4
                .DataSource = ds.Tables("Add_Asset_Tb")
                .DisplayMember = "Asset_Number"
                .ValueMember = "Asset_Number"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With



        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving and Populating  " & ex.Message)
            'Me.Dispose()
        End Try
    End Sub
    Private Sub assiginie_name_txt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles assiginie_name_txt.SelectedIndexChanged
        ' get_code_assign()
        FillCombo_assign_get_id()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        assign_tab_refresh()
    End Sub
    Private Sub assign_tab_refresh()
        For Each txt In Panel7.Controls.OfType(Of TextBox)()
            txt.Text = ""
        Next
        For Each txt2 In Panel7.Controls.OfType(Of ComboBox)()
            txt2.Text = ""
        Next
        For Each txt3 In Panel8.Controls.OfType(Of ComboBox)()
            txt3.Text = ""
        Next
        assign_Asset_description_txt.Text = " "
        TabControl1.SelectedIndex = 0

        TabControl1.SelectedIndex = 1
        Panel4.Visible = True
        Panel3.Visible = True
        Panel1.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
        Panel8.Visible = True
        assign_datetxt.Value = DateTime.Now
    End Sub
    Private Sub assiginie_name_txt_MouseEnter(sender As Object, e As EventArgs) Handles assiginie_name_txt.MouseEnter

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Application.Exit()
    End Sub
End Class