Public Class Offense
    ' Name
    Public Property name() As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property
    Private m_name As String

    ' Player Team
    Public Property team() As String
        Get
            Return m_team
        End Get
        Set(value As String)
            m_team = value
        End Set
    End Property
    Private m_team As String

    ' Passing Yards
    Public Property PassingYards() As Decimal
        Get
            Return mPassingYards
        End Get
        Set(value As Decimal)
            mPassingYards = value
        End Set
    End Property
    Private mPassingYards As Decimal

    ' Passing TDs
    Public Property PassingTD() As Decimal
        Get
            Return mPassingTD
        End Get
        Set(value As Decimal)
            mPassingTD = value
        End Set
    End Property
    Private mPassingTD As Decimal

    ' Passing INT
    Public Property PassingINT() As Decimal
        Get
            Return mPassingINT
        End Get
        Set(value As Decimal)
            mPassingINT = value
        End Set
    End Property
    Private mPassingINT As Decimal

    ' Rushing Yards
    Public Property RushingYD() As Decimal
        Get
            Return mRushingYD
        End Get
        Set(value As Decimal)
            mRushingYD = value
        End Set
    End Property
    Private mRushingYD As Decimal

    ' Rushing TDs
    Public Property RushingTD() As Decimal
        Get
            Return mRushingTD
        End Get
        Set(value As Decimal)
            mRushingTD = value
        End Set
    End Property
    Private mRushingTD As Decimal

    ' Receptions
    Public Property Receptions() As Decimal
        Get
            Return mReceptions
        End Get
        Set(value As Decimal)
            mReceptions = value
        End Set
    End Property
    Private mReceptions As Decimal

    ' Recieving Yards
    Public Property RecievingYD() As Decimal
        Get
            Return mRecievingYD
        End Get
        Set(value As Decimal)
            mRecievingYD = value
        End Set
    End Property
    Private mRecievingYD As Decimal

    ' Recieving TDs
    Public Property RecievingTD() As Decimal
        Get
            Return mRecievingTD
        End Get
        Set(value As Decimal)
            mRecievingTD = value
        End Set
    End Property
    Private mRecievingTD As Decimal

    ' Fumble
    Public Property Fumble() As Decimal
        Get
            Return mFumble
        End Get
        Set(value As Decimal)
            mFumble = value
        End Set
    End Property
    Private mFumble As Decimal

    ' Matts Points
    Public Property Points() As Decimal
        Get
            Return mPoints
        End Get
        Set(value As Decimal)
            mPoints = value
        End Set
    End Property
    Private mPoints As Decimal

    ' CSR
    Public Property CSRPoints() As Decimal
        Get
            Return mCSRPoints
        End Get
        Set(value As Decimal)
            mCSRPoints = value
        End Set
    End Property
    Private mCSRPoints As Decimal

    ' Flex Points
    Public Property FlexPoints() As Decimal
        Get
            Return mFlexPoints
        End Get
        Set(value As Decimal)
            mFlexPoints = value
        End Set
    End Property
    Private mFlexPoints As Decimal

    ' Pos Rank
    Public Property PosRank() As Integer
        Get
            Return mPosRank
        End Get
        Set(value As Integer)
            mPosRank = value
        End Set
    End Property
    Private mPosRank As Integer

    ' Overall Rank
    Public Property OvrRank() As Integer
        Get
            Return mOvrRank
        End Get
        Set(value As Integer)
            mOvrRank = value
        End Set
    End Property
    Private mOvrRank As Integer

    ' Position
    Public Property Pos() As String
        Get
            Return mPos
        End Get
        Set(value As String)
            mPos = value
        End Set
    End Property
    Private mPos As String

End Class
