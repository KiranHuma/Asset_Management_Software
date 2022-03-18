Imports System.Data.SqlClient
Imports System.IO

Public Class Addsub_itemsFrm
    Dim cmd As New SqlCommand()
    Dim con As New SqlConnection()
    Dim null_valuee As String = "Enter Here"

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


    Private Sub txtboxid_assign()
        Try
            Dim num As New Integer
            Dim constr As String = cs
            Using con As SqlConnection = New SqlConnection(constr)
                Using cmd As SqlCommand = New SqlCommand("SELECT MAX(M_ID) FROM Asset_Records ")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()



                    If (IsDBNull(cmd.ExecuteScalar)) Then
                        num = 1
                        TextBox2.Text = num.ToString
                    Else

                        num = cmd.ExecuteScalar + 1
                        TextBox2.Text = num.ToString
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
            cmd.CommandText = "INSERT INTO Asset_Records (M_ID,Add_ID_code,Add_Statuses,Add_Department,Add_Location)values
                                                 ('" & TextBox2.Text & "','" & TextBox1.Text & "','" & TextBox4.Text & "','" & TextBox3.Text & "','" & TextBox5.Text & "')"

            cmd.ExecuteNonQuery()
            con.Close()
            ' getdata()
            ' MessageBox.Show("Asset add Successfully")
            ' Me.Hide()

        Catch ex As Exception
            MsgBox("Data Inserted Failed because " & ex.Message)
            Me.Dispose()
        End Try

    End Sub
    Private Sub AddStatusFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtboxid_assign()
        get_idasset()
    End Sub
    Public Sub code_check_id()
        Dim con As New SqlConnection(cs)
        con.Open()
        str = "select count(*)from Asset_Records where Add_ID_code='" & TextBox1.Text & "' AND Add_ID_code IS NOT NULL AND Add_ID_code <>'Enter Here' AND Add_subitems IS NULL"
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
    Public Sub code_check_dep()
        Dim con As New SqlConnection(cs)
        con.Open()
        str = "select count(*)from Asset_Records where Add_Department='" & TextBox3.Text & "' AND Add_Department IS NOT NULL AND Add_Department <>'Enter Here' AND Add_subitems IS NULL"
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
    Public Sub code_Status()
        Dim con As New SqlConnection(cs)
        con.Open()
        str = "select count(*)from Asset_Records where Add_Statuses='" & TextBox4.Text & "'AND Add_Statuses IS NOT NULL AND Add_Statuses <>'Enter Here' AND Add_subitems IS NULL "
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
    Public Sub code_check_loc()
        Dim con As New SqlConnection(cs)
        con.Open()
        str = "select count(*)from Asset_Records where Add_Location='" & TextBox5.Text & "' AND Add_Location IS NOT NULL AND Add_Location <>'Enter Here' AND Add_subitems IS NULL"
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
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtboxid_assign()
        insert()
        get_location_grid()
        Button4.Enabled = False
        Button3.Enabled = False
        Button2.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtboxid_assign()

        insert()
        get_department()
        Button4.Enabled = False
        Button3.Enabled = False
        Button2.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txtboxid_assign()
        insert()
        get_status()
        Button4.Enabled = False
        Button3.Enabled = False
        Button2.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtboxid_assign()

        insert()
        get_idasset()
        Button4.Enabled = False
        Button3.Enabled = False
        Button2.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        txtboxid_assign()
        get_status()
        get_idasset()
        TextBox3.Text = null_valuee
        TextBox4.Text = null_valuee
        TextBox5.Text = null_valuee



    End Sub


    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        txtboxid_assign()

        get_department()
        TextBox1.Text = null_valuee
        TextBox4.Text = null_valuee
        TextBox5.Text = null_valuee

    End Sub



    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        txtboxid_assign()
        TextBox1.Text = null_valuee
        get_status()

        TextBox3.Text = null_valuee
        TextBox5.Text = null_valuee

    End Sub



    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        txtboxid_assign()
        get_location_grid()
        TextBox1.Text = null_valuee
        TextBox4.Text = null_valuee
        TextBox3.Text = null_valuee

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
    Private Sub get_idasset()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select M_ID,Add_ID_code FROM Asset_Records where Add_ID_code IS NOT NULL AND Add_ID_code <>'Enter Here' AND Add_subitems IS NULL "
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Asset_Records")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "Asset_Records"
            DataGridView1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try

    End Sub
    Private Sub get_location_grid()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select M_ID, Add_Location FROM Asset_Records where Add_Location IS NOT NULL AND Add_Location <>'Enter Here' AND Add_subitems IS NULL "
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Asset_Records")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "Asset_Records"
            DataGridView1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try

    End Sub
    Private Sub get_department()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select M_ID,Add_Department FROM Asset_Records where Add_Department IS NOT NULL AND Add_Department <>'Enter Here' AND Add_subitems IS NULL"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Asset_Records")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "Asset_Records"
            DataGridView1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private Sub get_status()
        Dim str As String
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            str = "Select M_ID,Add_Statuses FROM Asset_Records where Add_Statuses IS NOT NULL AND Add_Statuses <>'Enter Here' AND Add_subitems IS NULL "
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Asset_Records")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "Asset_Records"
            DataGridView1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private Sub update_status()
        Try

            dbaccessconnection()
            con.Open()
            cmd.CommandText = "Update Asset_Records set Add_subitems='" & TextBox6.Text & "' where M_ID='" & TextBox8.Text & "'"

            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Operation completed Successfully")
        Catch ex As Exception
            MsgBox("Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim ask As MsgBoxResult = MsgBox("Are you sure to remove ", MsgBoxStyle.YesNo)
        If TextBox7.Text <> "" Then
            If ask = MsgBoxResult.Yes Then

                ' TextBox7.Text =
                update_status()

                get_idasset()
                Button8.Enabled = False
                Button7.Enabled = False
                Button6.Enabled = False

                Button5.Enabled = False
            Else ask = MsgBoxResult.No

                MessageBox.Show(" not delete")

            End If
        Else
            MessageBox.Show("Select values")
        End If



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick

        Me.TextBox8.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        Me.TextBox7.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString

        Button8.Enabled = True
        Button7.Enabled = True
        Button6.Enabled = True

        Button5.Enabled = True

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        code_check_dep()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        code_check_loc()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ask As MsgBoxResult = MsgBox("Are you sure to remove ", MsgBoxStyle.YesNo)
        If TextBox7.Text <> "" Then
            If ask = MsgBoxResult.Yes Then

                ' TextBox7.Text =
                update_status()
                get_location_grid()

                Button8.Enabled = False
                Button7.Enabled = False
                Button6.Enabled = False

                Button5.Enabled = False
            Else ask = MsgBoxResult.No

                MessageBox.Show(" not delete")

            End If
        Else
            MessageBox.Show("Select values")
        End If


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        code_check_id()
    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        TextBox1.Text = ""
        Button1.Enabled = True

        TextBox3.Text = null_valuee
        TextBox4.Text = null_valuee
        TextBox5.Text = null_valuee
    End Sub

    Private Sub TextBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseClick
        TextBox3.Text = ""
        Button2.Enabled = True

        TextBox1.Text = null_valuee

        TextBox4.Text = null_valuee
        TextBox5.Text = null_valuee
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        code_Status()
    End Sub

    Private Sub TextBox4_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox4.MouseClick
        TextBox3.Text = null_valuee
        TextBox1.Text = null_valuee
        Button3.Enabled = True
        TextBox4.Text = ""
        TextBox5.Text = null_valuee
    End Sub

    Private Sub TextBox5_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox5.MouseClick
        TextBox3.Text = null_valuee
        TextBox1.Text = null_valuee
        Button4.Enabled = True
        TextBox4.Text = null_valuee
        TextBox5.Text = ""
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim ask As MsgBoxResult = MsgBox("Are you sure to remove ", MsgBoxStyle.YesNo)
        If TextBox7.Text <> "" Then
            If ask = MsgBoxResult.Yes Then

                ' TextBox7.Text =
                update_status()

                get_department()
                Button8.Enabled = False
                Button7.Enabled = False
                Button6.Enabled = False

                Button5.Enabled = False
            Else ask = MsgBoxResult.No

                MessageBox.Show(" not delete")

            End If
        Else
            MessageBox.Show("Select values")
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ask As MsgBoxResult = MsgBox("Are you sure to remove ", MsgBoxStyle.YesNo)
        If TextBox7.Text <> "" Then
            If ask = MsgBoxResult.Yes Then

                ' TextBox7.Text =
                update_status()

                get_status()
                Button8.Enabled = False
                Button7.Enabled = False
                Button6.Enabled = False

                Button5.Enabled = False
            Else ask = MsgBoxResult.No

                MessageBox.Show(" not delete")

            End If
        Else
            MessageBox.Show("Select values")
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        AddAssetFrm.Show()
    End Sub
End Class