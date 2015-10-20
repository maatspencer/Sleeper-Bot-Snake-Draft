Imports System.IO
Imports Sleeper_Bot_Snake_Draft.Globals
Imports Sleeper_Bot_Snake_Draft.initialBuild
Imports System.Net

Public Class Main
    ' Load event
    Private Sub Main_Load_1(sender As Object, e As EventArgs) Handles Me.Load
        ' Download CSV
        If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "/Tables") Then
            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "/Tables")
        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "/Tables/ALL.csv") Then
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "/Tables/ALL.csv")
        End If
        Dim web_client As WebClient = New WebClient
        web_client.DownloadFile("http://www.fantasysharks.com/apps/Projections/WeeklyProjections.php?pos=ALL&format=csv", _
            My.Application.Info.DirectoryPath & "/Tables/ALL.csv")

        ' Build lists
        initialBuild.readOffense(My.Application.Info.DirectoryPath & "/Tables/ALL.csv")
        sortAndRank()

        ' Quarter Backs
        For i = 0 To oQB.Count - 1
            ListBox2.Items.Add(oQB.Item(i).CSRPoints & vbTab & oQB.Item(i).Points & vbTab & oQB.Item(i).name)
        Next
        ListBox2.Update()

        ' Wide Recievers
        For i = 0 To oWR.Count - 1
            ListBox3.Items.Add(oWR.Item(i).CSRPoints & vbTab & oWR.Item(i).Points & vbTab & oWR.Item(i).name)
        Next
        ListBox3.Update()

        ' Running Backs
        For i = 0 To oRB.Count - 1
            ListBox4.Items.Add(oRB.Item(i).CSRPoints & vbTab & oRB.Item(i).Points & vbTab & oRB.Item(i).name)
        Next
        ListBox4.Update()

        ' Tight Ends
        For i = 0 To oTE.Count - 1
            ListBox5.Items.Add(oTE.Item(i).CSRPoints & vbTab & oTE.Item(i).Points & vbTab & oTE.Item(i).name)
        Next
        ListBox5.Update()

        ' Flex
        buildFlex()
        For i = 0 To oFlex.Count - 1
            ListBox8.Items.Add(oFlex.Item(i).FlexPoints & vbTab & oFlex.Item(i).Pos & vbTab & oFlex.Item(i).name)
        Next
        ListBox8.Update()


        ' Overall
        buildOverall()
        For i = 0 To oOvr.Count - 1
            ListBox1.Items.Add(oOvr.Item(i).CSRPoints & vbTab & oOvr.Item(i).Pos & vbTab & oOvr.Item(i).name)
        Next
        ListBox1.Update()

        ' Update Overall rank in all lists
        updateOverallRank()

        ' Set initial Labels
        updateRosters()

        ' Set initial Selection
        ListBox1.SetSelected(0, True)
    End Sub

    'Overall
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim t As Offense = oOvr.Item(ListBox1.SelectedIndex)

        Label11.Text = t.Pos

        Label2.Text = t.name
        Label20.Text = t.team

        Label3.Text = t.Points

        Label7.Text = t.OvrRank
        Label9.Text = t.PosRank

        Label12.Text = t.PassingYards
        Label14.Text = t.PassingTD

        Label26.Text = t.RushingYD
        Label24.Text = t.RushingTD

        Label28.Text = t.RecievingYD
        Label22.Text = t.RecievingTD

        Label32.Text = t.Receptions
        Label30.Text = t.Fumble
    End Sub

    ' Quarterback
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Dim t As Offense = oQB.Item(ListBox2.SelectedIndex)

        Label11.Text = t.Pos

        Label2.Text = t.name
        Label20.Text = t.team

        Label3.Text = t.Points

        Label7.Text = t.OvrRank
        Label9.Text = t.PosRank

        Label12.Text = t.PassingYards
        Label14.Text = t.PassingTD

        Label26.Text = t.RushingYD
        Label24.Text = t.RushingTD

        Label28.Text = t.RecievingYD
        Label22.Text = t.RecievingTD

        Label32.Text = t.Receptions
        Label30.Text = t.Fumble
    End Sub

    ' Wide Reciever
    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        Dim t As Offense = oWR.Item(ListBox3.SelectedIndex)

        Label11.Text = t.Pos

        Label2.Text = t.name
        Label20.Text = t.team

        Label3.Text = t.Points

        Label7.Text = t.OvrRank
        Label9.Text = t.PosRank

        Label12.Text = t.PassingYards
        Label14.Text = t.PassingTD

        Label26.Text = t.RushingYD
        Label24.Text = t.RushingTD

        Label28.Text = t.RecievingYD
        Label22.Text = t.RecievingTD

        Label32.Text = t.Receptions
        Label30.Text = t.Fumble
    End Sub

    ' Running Back
    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        Dim t As Offense = oRB.Item(ListBox4.SelectedIndex)

        Label11.Text = t.Pos

        Label2.Text = t.name
        Label20.Text = t.team

        Label3.Text = t.Points

        Label7.Text = t.OvrRank
        Label9.Text = t.PosRank

        Label12.Text = t.PassingYards
        Label14.Text = t.PassingTD

        Label26.Text = t.RushingYD
        Label24.Text = t.RushingTD

        Label28.Text = t.RecievingYD
        Label22.Text = t.RecievingTD

        Label32.Text = t.Receptions
        Label30.Text = t.Fumble
    End Sub

    ' Tight End
    Private Sub ListBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox5.SelectedIndexChanged
        Dim t As Offense = oTE.Item(ListBox5.SelectedIndex)

        Label11.Text = t.Pos

        Label2.Text = t.name
        Label20.Text = t.team

        Label3.Text = t.Points

        Label7.Text = t.OvrRank
        Label9.Text = t.PosRank

        Label12.Text = t.PassingYards
        Label14.Text = t.PassingTD

        Label26.Text = t.RushingYD
        Label24.Text = t.RushingTD

        Label28.Text = t.RecievingYD
        Label22.Text = t.RecievingTD

        Label32.Text = t.Receptions
        Label30.Text = t.Fumble
    End Sub

    ' Flex
    Private Sub ListBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox8.SelectedIndexChanged
        Dim t As Offense = oFlex.Item(ListBox8.SelectedIndex)

        Label11.Text = t.Pos

        Label2.Text = t.name
        Label20.Text = t.team

        Label3.Text = t.Points

        Label7.Text = t.OvrRank
        Label9.Text = t.PosRank

        Label12.Text = t.PassingYards
        Label14.Text = t.PassingTD

        Label26.Text = t.RushingYD
        Label24.Text = t.RushingTD

        Label28.Text = t.RecievingYD
        Label22.Text = t.RecievingTD


        Label32.Text = t.Receptions
        Label30.Text = t.Fumble
    End Sub

    Private Sub updateOverallRank()
        For i = 0 To oRB.Count - 1
            Dim index As Integer = oOvr.FindIndex(Function(a) a.name.Equals(oRB.Item(i).name, StringComparison.Ordinal))
            oRB.Item(i).OvrRank = oOvr.Item(index).OvrRank
        Next

        For i = 0 To oWR.Count - 1
            Dim index As Integer = oOvr.FindIndex(Function(a) a.name.Equals(oWR.Item(i).name, StringComparison.Ordinal))
            oWR.Item(i).OvrRank = oOvr.Item(index).OvrRank
        Next

        For i = 0 To oTE.Count - 1
            Dim index As Integer = oOvr.FindIndex(Function(a) a.name.Equals(oTE.Item(i).name, StringComparison.Ordinal))
            oTE.Item(i).OvrRank = oOvr.Item(index).OvrRank
        Next

        For i = 0 To oQB.Count - 1
            Dim index As Integer = oOvr.FindIndex(Function(a) a.name.Equals(oQB.Item(i).name, StringComparison.Ordinal))
            oQB.Item(i).OvrRank = oOvr.Item(index).OvrRank
        Next

        For i = 0 To oFlex.Count - 1
            Dim index As Integer = oOvr.FindIndex(Function(a) a.name.Equals(oFlex.Item(i).name, StringComparison.Ordinal))
            oFlex.Item(i).OvrRank = oOvr.Item(index).OvrRank
        Next

    End Sub
    ' Ovr
    Private Sub oDraft_Click(sender As Object, e As EventArgs) Handles oDraft.Click
        Dim t As Offense = oOvr.Item(ListBox1.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, True)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox1.SetSelected(0, True)
    End Sub

    Private Sub oRemove_Click(sender As Object, e As EventArgs) Handles oRemove.Click
        Dim t As Offense = oOvr.Item(ListBox1.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, False)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox1.SetSelected(0, True)

    End Sub

    ' QB
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim t As Offense = oQB.Item(ListBox2.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, True)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox2.SetSelected(0, True)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As Offense = oQB.Item(ListBox2.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, False)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox2.SetSelected(0, True)
    End Sub

    ' Flex
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim t As Offense = oFlex.Item(ListBox8.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, True)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox8.SetSelected(0, True)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim t As Offense = oFlex.Item(ListBox8.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, False)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox8.SetSelected(0, True)
    End Sub

    ' RB
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim t As Offense = oRB.Item(ListBox4.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, True)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox4.SetSelected(0, True)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim t As Offense = oRB.Item(ListBox4.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, False)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox4.SetSelected(0, True)
    End Sub

    ' WR
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim t As Offense = oWR.Item(ListBox3.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, True)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox3.SetSelected(0, True)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim t As Offense = oWR.Item(ListBox3.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, False)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox3.SetSelected(0, True)
    End Sub

    ' TE
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim t As Offense = oTE.Item(ListBox5.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, True)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox5.SetSelected(0, True)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim t As Offense = oTE.Item(ListBox5.SelectedIndex)
        UpdateItems.Start(t.name, t.Pos, False)
        initialBuild.buildFlex()
        initialBuild.buildOverall()

        updateOverallRank()
        updateListBoxes()
        ListBox5.SetSelected(0, True)
    End Sub

    Private Sub updateListBoxes()
        ' Quarterback
        ListBox2.Items.Clear()
        For i = 0 To oQB.Count - 1
            ListBox2.Items.Add(oQB.Item(i).CSRPoints & vbTab & oQB.Item(i).Points & vbTab & oQB.Item(i).name)
        Next
        ListBox2.Update()

        ' Wide Recievers
        ListBox3.Items.Clear()
        For i = 0 To oWR.Count - 1
            ListBox3.Items.Add(oWR.Item(i).CSRPoints & vbTab & oWR.Item(i).Points & vbTab & oWR.Item(i).name)
        Next
        ListBox3.Update()

        ' Running Backs
        ListBox4.Items.Clear()
        For i = 0 To oRB.Count - 1
            ListBox4.Items.Add(oRB.Item(i).CSRPoints & vbTab & oRB.Item(i).Points & vbTab & oRB.Item(i).name)
        Next
        ListBox4.Update()

        ' Tight Ends
        ListBox5.Items.Clear()
        For i = 0 To oTE.Count - 1
            ListBox5.Items.Add(oTE.Item(i).CSRPoints & vbTab & oTE.Item(i).Points & vbTab & oTE.Item(i).name)
        Next
        ListBox5.Update()

        ' Flex
        ListBox8.Items.Clear()
        For i = 0 To oFlex.Count - 1
            ListBox8.Items.Add(oFlex.Item(i).CSRPoints & vbTab & oFlex.Item(i).Pos & vbTab & oFlex.Item(i).name)
        Next
        ListBox8.Update()

        ' Overall
        ListBox1.Items.Clear()
        For i = 0 To oOvr.Count - 1
            ListBox1.Items.Add(oOvr.Item(i).CSRPoints & vbTab & oOvr.Item(i).Pos & vbTab & oOvr.Item(i).name)
        Next
        ListBox1.Update()

        updateRosters()
    End Sub
    Private Sub updateRosters()
        ' My Team
        Label43.Text = mQB
        Label41.Text = mRB
        Label39.Text = mWR

        Label47.Text = mTE

        Label53.Text = mFLEX
        Label51.Text = mRoster

        ' All Teams
        Label67.Text = aQB
        Label65.Text = aRB
        Label63.Text = aWR

        Label61.Text = aTE

        Label55.Text = aFLEX
        Label49.Text = aRoster
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ' Create Directory
        If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "/Reports") Then
            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "/Reports")
        End If

        'Overall
        Using sw As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "/Reports/OverallRank.csv")
            sw.WriteLine("Overall Rank,Position Rank,Position,Name,Team,CSR Points,Points")
            For i = 0 To oOvr.Count - 1
                Dim t As Offense = oOvr.Item(i)
                sw.WriteLine(t.OvrRank & "," & t.PosRank & "," & t.Pos & "," & t.name & "," & t.team & "," & t.CSRPoints & "," & t.Points)
            Next
        End Using

        'Flex
        Using sw As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "/Reports/FlexRank.csv")
            sw.Write("Overall Rank,Position Rank,Position,Name,Team,CSR Points,Points")
            For i = 0 To oFlex.Count - 1
                Dim t As Offense = oFlex.Item(i)
                sw.Write(t.OvrRank & "," & t.PosRank & "," & t.Pos & "," & t.name & "," & t.team & "," & t.FlexPoints & "," & t.Points)
            Next
        End Using
    End Sub
End Class
