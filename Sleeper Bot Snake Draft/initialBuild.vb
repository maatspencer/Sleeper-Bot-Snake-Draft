Imports System.IO
Imports Sleeper_Bot_Snake_Draft.Globals

Public Class initialBuild
    ' Read CSV file to Offense Object
    Public Shared Sub readOffense(MyFile As String)
        ' Build Lists
        oQB = New List(Of Offense)
        oWR = New List(Of Offense)
        oRB = New List(Of Offense)
        oTE = New List(Of Offense)

        ' Loop Variables
        Dim CurrentLine As String = ""
        Dim Count As Integer = 0

        Using sr As StreamReader = New StreamReader(MyFile)
            sr.ReadLine()
            CurrentLine = sr.ReadLine
            Do While (Not CurrentLine Is Nothing)
                Dim t As Offense = New Offense

                CurrentLine = CurrentLine.Replace("""", "").Replace(" ", "")

                'RANK
                t.Pos = CurrentLine.Split(",")(1)
                'ID
                t.name = CurrentLine.Split(",")(4) & " " & CurrentLine.Split(",")(3)
                t.team = CurrentLine.Split(",")(5)
                'OPP
                'Completions
                t.PassingYards = CurrentLine.Split(",")(8)
                t.PassingTD = CurrentLine.Split(",")(9)
                t.PassingINT = CurrentLine.Split(",")(10)
                'Rushing Attempts
                t.RushingYD = CurrentLine.Split(",")(12)
                t.RushingTD = CurrentLine.Split(",")(13)
                t.Receptions = CurrentLine.Split(",")(14)
                t.RecievingYD = CurrentLine.Split(",")(15)
                t.RecievingTD = CurrentLine.Split(",")(16)

                t.Points = (t.PassingYards / 25) + (t.PassingTD * 6) - (t.PassingINT * 2)
                t.Points += (t.RushingYD / 10) + (t.RushingTD * 6)
                t.Points += t.Receptions
                t.Points += (t.RecievingYD / 10) + (t.RecievingTD * 6)

                If t.Pos.Equals("QB", StringComparison.Ordinal) Then
                    oQB.Add(t)
                ElseIf t.Pos.Equals("WR", StringComparison.Ordinal) Then
                    oWR.Add(t)
                ElseIf t.Pos.Equals("RB", StringComparison.Ordinal) Then
                    oRB.Add(t)
                ElseIf t.Pos.Equals("TE", StringComparison.Ordinal) Then
                    oTE.Add(t)
                End If

                CurrentLine = sr.ReadLine
            Loop
        End Using
    End Sub

    Public Shared Sub sortAndRank()
        ' QB
        oQB.Sort(Function(x, y) y.Points.CompareTo(x.Points))

        For i = 0 To oQB.Count - 1
            oQB.Item(i).CSRPoints = oQB.Item(i).Points - oQB.Item(12 - 1).Points
        Next

        oQB.Sort(Function(x, y) y.CSRPoints.CompareTo(x.CSRPoints))

        For i = 0 To oQB.Count - 1
            oQB.Item(i).PosRank = i + 1
        Next

        ' WR
        oWR.Sort(Function(x, y) y.Points.CompareTo(x.Points))

        For i = 0 To oWR.Count - 1
            oWR.Item(i).CSRPoints = oWR.Item(i).Points - oWR.Item(24 - 1).Points
        Next

        oWR.Sort(Function(x, y) y.CSRPoints.CompareTo(x.CSRPoints))

        For i = 0 To oWR.Count - 1
            oWR.Item(i).PosRank = i + 1
        Next

        ' RB
        oRB.Sort(Function(x, y) y.Points.CompareTo(x.Points))

        For i = 0 To oRB.Count - 1
            oRB.Item(i).CSRPoints = oRB.Item(i).Points - oRB.Item(24 - 1).Points
        Next

        oRB.Sort(Function(x, y) y.CSRPoints.CompareTo(x.CSRPoints))

        For i = 0 To oRB.Count - 1
            oRB.Item(i).PosRank = i + 1
        Next

        ' TE
        oTE.Sort(Function(x, y) y.Points.CompareTo(x.Points))

        For i = 0 To oTE.Count - 1
            oTE.Item(i).CSRPoints = oTE.Item(i).Points - oTE.Item(12 - 1).Points
        Next

        oTE.Sort(Function(x, y) y.CSRPoints.CompareTo(x.CSRPoints))

        For i = 0 To oTE.Count - 1
            oTE.Item(i).PosRank = i + 1
        Next
    End Sub

    ' Build flex Object
    Public Shared Sub buildFlex()
        oFlex = New List(Of Offense)

        ' WR
        Try
        For i = 23 - Globals.aWR To oWR.Count - 1
            oFlex.Add(oWR.Item(i))
        Next
        Catch
            For i = 0 To oWR.Count - 1
                oFlex.Add(oWR.Item(i))
            Next
        End Try

        ' RB
        Try
            For i = 23 - Globals.aRB To oRB.Count - 1
                oFlex.Add(oRB.Item(i))
            Next
        Catch
            For i = 0 To oRB.Count - 1
                oFlex.Add(oRB.Item(i))
            Next
        End Try

        ' TE
        Try
            For i = 11 - Globals.aWR To oTE.Count - 1
                oFlex.Add(oTE.Item(i))
            Next
        Catch
            For i = 0 To oTE.Count - 1
                oFlex.Add(oTE.Item(i))
            Next
        End Try


        oFlex.Sort(Function(x, y) y.Points.CompareTo(x.Points))

        For i = 0 To oFlex.Count - 1
            oFlex.Item(i).FlexPoints = oFlex.Item(i).Points - oFlex.Item(24 - 1).Points
        Next

        oFlex.Sort(Function(x, y) y.FlexPoints.CompareTo(x.FlexPoints))

    End Sub

    ' Build overall object
    Public Shared Sub buildOverall()
        oOvr = New List(Of Offense)

        ' QB
        If switchQB = True Then
            For i = 0 To oQB.Count - 1
                oOvr.Add(oQB.Item(i))
            Next
        End If

        ' RB
        If switchRB = True Then
            For i = 0 To oRB.Count - 1
                oOvr.Add(oRB.Item(i))
            Next
        End If

        ' WR
        If switchWR = True Then
            For i = 0 To oWR.Count - 1
                oOvr.Add(oWR.Item(i))
            Next
        End If

        ' TE
        If switchTE = True Then
            For i = 0 To oTE.Count - 1
                oOvr.Add(oTE.Item(i))
            Next
        End If

        oOvr.Sort(Function(x, y) y.CSRPoints.CompareTo(x.CSRPoints))

        For i = 0 To oOvr.Count - 1
            oOvr.Item(i).OvrRank = i + 1
        Next

    End Sub
End Class
