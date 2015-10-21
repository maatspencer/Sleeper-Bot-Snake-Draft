Imports System.IO
Imports Sleeper_Bot_Snake_Draft.Globals
Imports Sleeper_Bot_Snake_Draft.initialBuild
Imports Sleeper_Bot_Snake_Draft.Main

Public Class UpdateItems

    Public Shared Sub Start(name As String, pos As String, isDraft As Boolean)
        globalVars(pos, isDraft)
        removeItem(name)
        CSRValues()
        Lists()
    End Sub

    Private Shared Sub removeItem(name As String)
        ' QB
        For i = 0 To oQB.Count - 1
            Dim index As Integer = oQB.FindIndex(Function(a) a.name.Equals(name, StringComparison.Ordinal))
            If Not index = -1 Then
                oQB.RemoveAt(index)
                Exit For
            End If
        Next

        ' RB
        For i = 0 To oRB.Count - 1
            Dim index As Integer = oRB.FindIndex(Function(a) a.name.Equals(name, StringComparison.Ordinal))
            If Not index = -1 Then
                oRB.RemoveAt(index)
                Exit For
            End If
        Next

        ' WR
        For i = 0 To oWR.Count - 1
            Dim index As Integer = oWR.FindIndex(Function(a) a.name.Equals(name, StringComparison.Ordinal))
            If Not index = -1 Then
                oWR.RemoveAt(index)
                Exit For
            End If
        Next

        ' TE
        For i = 0 To oTE.Count - 1
            Dim index As Integer = oTE.FindIndex(Function(a) a.name.Equals(name, StringComparison.Ordinal))
            If Not index = -1 Then
                oTE.RemoveAt(index)
                Exit For
            End If
        Next

    End Sub

    Private Shared Sub Lists()
        ' QB
        For i = 0 To oQB.Count - 1
            Try
                oQB.Item(i).CSRPoints = oQB.Item(i).Points() - oQB.Item(cQB - 1).Points
            Catch
                oQB.Item(i).CSRPoints = oQB.Item(i).Points() - oQB.Item(0).Points
            End Try
        Next

        oQB.Sort(Function(x, y) y.CSRPoints.CompareTo(x.CSRPoints))

        For i = 0 To oQB.Count - 1
            oQB.Item(i).PosRank = i + 1
        Next

        ' RB
        For i = 0 To oRB.Count - 1
            Try
                oRB.Item(i).CSRPoints = oRB.Item(i).Points() - oRB.Item(cRB - 1).Points
            Catch
                oRB.Item(i).CSRPoints = oRB.Item(i).Points() - oRB.Item(0).Points
            End Try
        Next

        oRB.Sort(Function(x, y) y.CSRPoints.CompareTo(x.CSRPoints))

        For i = 0 To oRB.Count - 1
            oRB.Item(i).PosRank = i + 1
        Next

        ' WR
        For i = 0 To oWR.Count - 1
            Try
                oWR.Item(i).CSRPoints = oWR.Item(i).Points() - oWR.Item(cWR - 1).Points
            Catch
                oWR.Item(i).CSRPoints = oWR.Item(i).Points() - oWR.Item(0).Points
            End Try
        Next

        oWR.Sort(Function(x, y) y.CSRPoints.CompareTo(x.CSRPoints))

        For i = 0 To oWR.Count - 1
            oWR.Item(i).PosRank = i + 1
        Next

        ' TE
        For i = 0 To oTE.Count - 1
            Try
                oTE.Item(i).CSRPoints = oTE.Item(i).Points() - oTE.Item(cTE - 1).Points
            Catch
                oTE.Item(i).CSRPoints = oTE.Item(i).Points() - oTE.Item(0).Points
            End Try
        Next

        oTE.Sort(Function(x, y) y.CSRPoints.CompareTo(x.CSRPoints))

        For i = 0 To oTE.Count - 1
            oTE.Item(i).PosRank = i + 1
        Next
    End Sub

    Private Shared Sub globalVars(pos As String, isDraft As Boolean)
        Select Case pos
            Case "QB"
                If isDraft Then
                    mQB += 1
                    aQB += 1
                    switchQB = False
                Else
                    aQB += 1
                End If
            Case "WR"
                If isDraft Then
                        mWR += 1
                        aWR += 1
                        If mWR = 2 Then
                            switchWR = False
                        End If
                Else
                    aWR += 1
                End If
            Case "RB"
                    If isDraft Then
                        mRB += 1
                    aRB += 1
                    If mRB = 2 Then
                        switchRB = False
                    End If
                    Else
                        aRB += 1
                    End If
            Case "TE"
                    If isDraft Then
                        mTE += 1
                    aTE += 1
                    switchTE = False
                    Else
                        aTE += 1
                    End If
        End Select

        If isDraft Then
            mRoster += 1
            aRoster += 1
        Else
            aRoster += 1
        End If
    End Sub

    Private Shared Sub CSRValues()
        ' Check for starters
        If mRoster < 8 Then
            cQB = 12 - aQB
            cFLEX = 60 - aFLEX
            cTE = 12 - aTE
            cRB = 24 - aRB
            cWR = 24 - aWR
        Else
            cQB = 24 - aQB
            cFLEX = 120 - aFLEX
            cTE = 24 - aTE
            cRB = 48 - aRB
            cWR = 48 - aWR
        End If
    End Sub
End Class
