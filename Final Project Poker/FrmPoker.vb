Option Explicit On
Option Strict On
'**************************************************************************************************	
' Author: Steven TIrpak 
' CS115 
' Date:  March 16, 2021
' Description:  loader is what loads the first part GUi
' then will call phase 1() to start out the buttons / cards suits
'**************************************************************************************************	

Public Class FrmPoker
    '************************************************Constants************************************************
    Const intNUMSUITS = 4                       'number of suits
    Const intCARDS_PER_SUIT As Integer = 13     'number of cards in each suit
    Const intCARDS_PER_DECK As Integer = 52     'number cards in deck

    '****************************************************parallel arrays for the deck **************************************
    '************************************************Array of images********************************************************
    Dim imgCardArray(51) As Image
    'Array of switches: True means card has been drawn; False means card is available
    Dim blnCardUsedArray(51) As Boolean
    'Array of suits: 13 0's representing Clubs, 13 1's representing Spades; etc.
    Dim intDeckSuitArray(51) As Integer
    'Array of face values: 1 (Ace) thru 13 (King) - repeat 4 times
    Dim intDeckFaceNbrArray(51) As Integer

    '****************************************************You will also need ************************************************
    Dim intCardIndex As Integer
    Dim intcount As Integer = 0
    Dim IntTotalScoreAmerican As Integer = 0
    Dim intGameScoreAmerican As Integer = 0
    Dim intTotalScoreEnglish As Integer = 0
    Dim intGameScoreEnglish As Integer = 0
    '******************************************Parallel arrays for each hand************************************************
    Dim chkDealArray(4) As CheckBox
    '           Deal Suit array (Integers) - contains suit of each card
    Dim dealsuitarray(4) As Integer
    '           Deal Rank array (Integers) - contains face number of each card
    Dim dealfacenbrarray(4) As Integer
    Dim dealRankArray(12) As Integer
    '
    '************************************************Random number generator object*****************************************
    Dim intRandom As Integer

    Dim rand As New Random

    Dim FinalCardCount(14) As Integer


    'Most of the counters will have to be defined at class level

    Private Sub FrmPoker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GrpDraw.Visible = False
        GrpDeal.Visible = True
        GrpPlayAgain.Visible = False
        GrpPlayGame.Visible = False

        '**************************************************************************************************	
        'Subroutine:  	frmPoker_Load
        'Author:     	Steven Tirpak
        'Date:	      	March 16, 2021
        'Description:	Code invoked at Form load time
        '**************************************************************************************************	
        Randomize()
        LoadObjectsToArrays()
        chkDealArray(0) = chkDeal1
        chkDealArray(1) = chkDeal2
        chkDealArray(2) = ChkDeal3
        chkDealArray(3) = ChkDeal4
        chkDealArray(4) = chkDeal5

    End Sub

    Sub LoadObjectsToArrays()
        '**************************************************************************************************	
        'Subroutine:  	LoadCardImagesToArray
        'Author:     	Steven Tirpak
        'Date:	      	March 16, 2021
        'Description:	Load parallel arrays to create object for each
        '               card in the deck
        '**************************************************************************************************	

        'Load all cards into Image array 
        Dim strSuitArray() As String = {"Clubs", "Spades", "Hearts", "Diamonds"}
        Dim intCardWithinSuit As Integer = 1
        Dim intSuit As Integer = 0

        '************************************ Load the 2 arrays containing ********************************
        '         Face value (rank)
        '         Suit
        '**************************************************************************************************	

        lstCards.Items.Add("Index" & ControlChars.Tab & "Face Value" & ControlChars.Tab & "Suit")

        For intX = 0 To intCARDS_PER_DECK - 1
            intDeckFaceNbrArray(intX) = intCardWithinSuit
            intDeckSuitArray(intX) = intSuit
            '**************************************************************************************************	
            'code for demo purposes only - comment out for Poker program
            '    lstCards.Items.Add(intX & ControlChars.Tab & intCardWithinSuit & ControlChars.Tab &
            'ControlChars.Tab & strSuitArray(intSuit) & "  (" & intDeckSuitArray(intX).ToString & ")")
            '**************************************************************************************************	

            intCardWithinSuit += 1
            If intCardWithinSuit > 13 Then
                intCardWithinSuit = 1
                intSuit += 1
            End If
        Next



        '******************************* Load all card pictures into Image card array **********************	
        '   filename algorithm: Face Value + underscore + suit + ".jpeg"
        '   eg: Ace of clubs = "1_Clubs.jpeg"
        '   it resides in the ImagesSmall folder within the "bin" folder.
        '**************************************************************************************************	

        For intX = 0 To intCARDS_PER_DECK - 1
            imgCardArray(intX) = Image.FromFile("..\ImagesSmall\" & intDeckFaceNbrArray(intX).ToString &
            "_" & strSuitArray(intDeckSuitArray(intX)) & ".jpeg")

        Next

    End Sub
    Private Sub btnDeal_Click(sender As Object, e As EventArgs) Handles btnDeal.Click
        '***************************************Deal the Cards ********************************************	
        'First part of game will deal the cards
        'The trigger for this will be a button (in my game it
        'is labeled "Play Game") 
        'Deal_Click
        'will: initialize counter, card visibility, etc.
        '      Set status of each card: check box "checked", blnUsed status
        '      Then Deal the cards: see subroutine: DealCards
        '      After the "Deal" button has been clicked, the
        '      "Draw" button is enabled.
        '**************************************************************************************************	
        intcount = 0


        GrpDraw.Visible = True
        GrpDeal.Visible = False
        GrpPlayAgain.Visible = False
        btnDeal.Enabled = True

        '**************************************************************************************************	
        'List box showing index, suit and face value of each card
        'For illustration purposes - remove for final product
        '**************************************************************************************************	
        lstCards.Items.Add("=========================================")
        lstCards.Items.Add("Point System For" & ControlChars.Tab & "American" & ControlChars.Tab & "English")
        lstCards.Items.Add("")
        lstCards.Items.Add("Royal Flush" & ControlChars.Tab + "100" & ControlChars.Tab + "30")
        lstCards.Items.Add("Straight Flush" & ControlChars.Tab + "75" & ControlChars.Tab + "30")
        lstCards.Items.Add("Four of a Kind" & ControlChars.Tab + "50" & ControlChars.Tab + "16")
        lstCards.Items.Add("Full House" & ControlChars.Tab + "25" & ControlChars.Tab + "10")
        lstCards.Items.Add("Straight" & ControlChars.Tab & ControlChars.Tab + "15" & ControlChars.Tab + "12")
        lstCards.Items.Add("Three of a Kind" & ControlChars.Tab + "10" & ControlChars.Tab + "6")
        lstCards.Items.Add("Two Pairs" & ControlChars.Tab + "5" & ControlChars.Tab + "3")
        lstCards.Items.Add("One Pair" & ControlChars.Tab & ControlChars.Tab + "2" & ControlChars.Tab + "1")


        'For intx = 0 To chkDealArray.Length - 1
        '    intrandom = GetACard()
        '    chkDealArray(intx).Image = imgCardArray(intRandom)
        '    chkDealArray(intx).Checked = False
        '    If intcount < 3 Then
        DealCards()
        'Else
        '        Scoring()
        '        GrpPlayAgain.Visible = True

        '    End If

        'Next



    End Sub


    Private Sub btnDraw_Click(sender As Object, e As EventArgs) Handles btnDraw.Click
        'testing of card numbers only
        '2 kind
        'dealfacenbrarray = {1, 3, 2, 8, 8}

        '3 kind
        'dealfacenbrarray = {1, 1, 2, 3, 1}

        '4 kind
        'dealfacenbrarray = {1, 1, 2, 1, 1}

        '2 pair
        'dealfacenbrarray = {1, 1, 2, 2, 1}

        '2 pairs
        'dealfacenbrarray = {1, 11, 2, 2, 1}

        'single card
        'dealfacenbrarray = {1, 3, 5, 2, 4}

        ' testing for card numbers and suites
        'st flush
        'dealfacenbrarray = {1, 3, 5, 2, 4}
        'dealsuitarray = {1, 1, 1, 1, 1}

        'flush
        'dealfacenbrarray = {1, 3, 5, 2, 11}
        'dealsuitarray = {1, 1, 1, 1, 1}

        'royal
        'dealfacenbrarray = {1, 13, 10, 12, 11}
        'dealsuitarray = {1, 1, 1, 1, 1}

        ' Scoring()
        '**************************************************************************************************	
        'btnDraw_Click subroutine
        'If the "Deal Counter" is under 2, then call
        '"DealCards", otherwise Initiate the Scoring section
        '**************************************************************************************************	

        If intcount < 2 Then
            DealCards()
            intcount += 1

        Else
            Scoring()
            GrpPlayAgain.Visible = True

        End If

    End Sub

    'Private Sub btnPlayGame_Click(sender As Object, e As EventArgs) Handles btnPlayGame.Click
    'Dim intRandom As Integer
    '   GrpPlayGame.Visible = True
    '  GrpDeal.Visible = False
    ' btnDeal.Enabled = True

    ''For intx = 0 To chkDealArray.Length - 1
    '        intRandom = rand.Next(51)
    '        chkDealArray(intx).Image = imgCardArray(intRandom)
    '        blnCardUsedArray(intRandom) = True
    '    Next
    '    ' DealCards()

    'End Sub
    Sub DealCards()
        '**************************************************************************************************	
        'This is NOT the complete subroutine
        '
        'In addition, you must:
        ' set the "Deal" suit array
        ' set the "Deal" rank array
        ' set the BackColor of each checkbox
        '**************************************************************************************************	
        Dim intcardnumber As Integer
        '**************************************************************************************************	
        'if this checkbox is checked, 
        ' call GetACard, which will return the index intRandom =GetACard
        ' of the dealt card
        'get suit and put in "Deal" Suit Array
        'get rank and put in "Deal" Rank Array 
        '**************************************************************************************************	
        For intX = 0 To chkDealArray.Length - 1
            If chkDealArray(intX).Checked = False Then
                intcardnumber = GetACard()

                chkDealArray(intX).Image = imgCardArray(intcardnumber)
                dealsuitarray(intX) = intDeckSuitArray(intcardnumber)
                dealfacenbrarray(intX) = intDeckFaceNbrArray(intcardnumber)

            End If

        Next

    End Sub

    Function GetACard() As Integer
        '**************************************************************************************************	
        ' Author: Steven TIrpak 
        ' CS115 
        ' Date:  March 16, 2021
        ' Description:	Get a random number for each card
        '               If it has already been drawn,
        '               loop until you get one that
        '               has not been drawn.
        '**************************************************************************************************	

        Dim blnDone As Boolean

        blnDone = False
        Do Until blnDone = True
            intCardIndex = rand.Next(52)
            'MsgBox("next " & intCardIndex.ToString)
            If blnCardUsedArray(intCardIndex) = False Then
                blnCardUsedArray(intCardIndex) = True
                '    MsgBox(intCardIndex.ToString)

                blnCardUsedArray(intCardIndex) = True
                blnDone = True
            Else
                ' MsgBox("bad card" & intCardIndex.ToString)

            End If
        Loop
        Return intCardIndex
    End Function

    Private Sub btnStay_Click(sender As Object, e As EventArgs) Handles btnStay.Click
        '**************************************************************************************************	
        ' Author: Steven TIrpak 
        ' CS115 
        ' Date:  March 16, 2021
        ' Description:	stay btn is clicked then
        '               GrpPlayAgain panel for play again Appears then
        '               Scoring() is called 
        '               btnPlayAgain.enabled is now enabled to be click to start again.
        '               btnDeal.enable is now enabled for reloop if wish to play again.
        '**************************************************************************************************	

        Scoring()


        GrpPlayAgain.Visible = True
        btnPlayAgain.Enabled = True
        GrpPlayGame.Visible = False
        btnDeal.Enabled = False
        btnPlayAgain.Enabled = True

    End Sub
    Function countoccurences(intcountocc As Integer) As Integer
        '**************************************************************************************************	
        ' Author: Steven TIrpak 
        ' CS115 
        ' Date:  March 16, 2021
        ' Description:	CountOccurences 
        '              
        '               
        '              
        '               
        '**************************************************************************************************	
        For intx = 0 To dealfacenbrarray.Length - 1
            If dealfacenbrarray(intx) = intcountocc Then
                intcount += 1

            End If
        Next
        Return intcount
    End Function

    Function IsFlush(ByVal intSuit As Integer()) As Boolean
        Dim inty As Integer = intSuit(0)

        For intx = 1 To intSuit.Length - 1
            If (inty <> intSuit(intx)) Then
                Return False
            End If
        Next
        Return True
    End Function

    Function IsRoyalFlush(ByVal intSuit As Integer(), ByVal intCards As Integer()) As Boolean
        Dim intRoyalFlush() As Integer = {1, 10, 11, 12, 13}

        Array.Sort(intCards)
        ' check if each cards is equal 1, 10, 11, 12 and 13
        For intx = 0 To intCards.Length - 1
            If (intRoyalFlush(intx) <> intCards(intx)) Then
                ' not royal flush if one of the card is not equal to 1, 10, 11, 12 or 13
                Return False
            End If
        Next
        ' also check if they are same suite
        Return (True And IsFlush(intSuit))

    End Function

    Function IsStraight(ByVal intCards As Integer()) As Boolean

        Array.Sort(intCards)
        ' after sorting current card should be consecutive number than previous one 
        For intx = 1 To intCards.Length - 1
            If (intCards(intx - 1) <> intCards(intx) - 1) Then
                Return False
            End If
        Next
        Return (True)

    End Function

    Function IsStraightFlush(ByVal intSuit As Integer(), ByVal intCards As Integer()) As Boolean
        ' check for both straight and flush
        Return (IsStraight(intCards) And IsFlush(intSuit))

    End Function

    Function CardCount(ByVal intCards As Integer()) As Integer()
        Dim cardCount1(13) As Integer

        ' count the number of cards according to the value, not suite
        ' and store it where array index serve as value of the card 
        ' and value in the array as the count of that card
        For i = 0 To intCards.Length - 1
            cardCount1(intCards(i)) += 1
        Next
        Return cardCount1
    End Function
    Function IsThreeKind(ByVal intCards As Integer()) As Boolean
        ' count the cards
        FinalCardCount = CardCount(intCards)
        ' check if any card number is equals to 3 so that it can be 3 of a kind
        For i = 0 To FinalCardCount.Length - 1
            If (FinalCardCount(i) = 3) Then
                Return True
            End If
        Next
        Return False
    End Function


    Function GetTwoKind(ByVal intCards As Integer(), ByVal skipCard As Integer) As Integer
        ' count the cards
        FinalCardCount = CardCount(intCards)
        For i = 0 To FinalCardCount.Length - 1
            ' ignore the card if it is 'skipcard'
            If (i = skipCard) Then
                Continue For
            End If
            If (FinalCardCount(i) = 2) Then
                ' return the card that has count 2
                Return i
            End If
        Next
        ' if there is no cards with count 2, return -1
        Return -1
    End Function

    Function IsTwoPairs(ByVal intCards As Integer()) As Boolean
        ' get the card that has count 2
        Dim FirstCard = GetTwoKind(intCards, -1)
        ' get another card that has count 2 by skipping the card we already know has count 2
        Dim SecondCard = GetTwoKind(intCards, FirstCard)

        ' if there are 2 cards with count 2 then we have 2 pairs
        Return FirstCard <> -1 And SecondCard <> -1

    End Function

    Function IsFullHouse(ByVal intCards As Integer()) As Boolean
        ' if we have 2 pairs and 3 of a kind we have full house
        Return GetTwoKind(intCards, -1) <> -1 And IsThreeKind(intCards)
    End Function

    Function IsFourKind(ByVal intCards As Integer()) As Boolean
        'count the cards
        FinalCardCount = CardCount(intCards)
        ' check for cards that has count 4
        For i = 0 To FinalCardCount.Length - 1
            If (FinalCardCount(i) = 4) Then
                Return True
            End If
        Next
        Return False
    End Function
    Sub Scoring()
        '**************************************************************************************************	
        ' Author: Steven TIrpak 
        ' CS115 
        ' Date:  March 16, 2021
        ' Description:	CountOccurences 
        '              
        '               
        '              
        '               
        '**************************************************************************************************	
        'countoccurences(intcount)

        'Array.Sort(dealfacenbrarray)
        'Array.Sort(dealsuitarray)


        ''*************Scoring ***************************
        ''    Stay tuned for Scoring help
        'Dim intNumOccurences As Integer
        'Dim bln2ofakind, bln3ofakind, bln4ofakind As Boolean
        'Dim blnStraight, blnFlush, blnStraightFlush, blnRoyalFlush As Boolean
        'Dim blnFullHouse, bln2Pair, blnHighCard As Boolean

        'blnHighCard = False
        'bln2Pair = False
        'bln2ofakind = False
        'bln3ofakind = False
        'blnStraight = False
        'blnFlush = False
        'blnFullHouse = False
        'bln4ofakind = False
        'blnStraightFlush = False
        'blnRoyalFlush = False

        'Array.Sort(intDeckFaceNbrArray)

        'For intx = 1 To 13
        '    intNumOccurences = countoccurences(intx)
        '    If intNumOccurences = 1 Then
        '        If blnHighCard = True Then
        '            blnHighCard = True
        '            intGameScoreAmerican = 2
        '            intGameScoreEnglish = 1

        '        End If

        '    End If

        '    If intNumOccurences = 2 Then

        '    ElseIf bln2ofakind = True Then
        '        bln2Pair = True
        '        intGameScoreAmerican = 5
        '        intGameScoreEnglish = 2

        '        ' Else
        '        bln2ofakind = True
        '        'End If

        '    ElseIf intNumOccurences = 3 Then
        '        bln3ofakind = True
        '        intGameScoreAmerican = 10
        '        intGameScoreEnglish = 6


        '    ElseIf intNumOccurences = 4 Then
        '        blnStraight = True
        '        intGameScoreAmerican = 15
        '        intGameScoreEnglish = 12

        '    ElseIf intNumOccurences = 5 Then
        '        blnFlush = True
        '        intGameScoreAmerican = 20
        '        intGameScoreEnglish = 5


        '    ElseIf intNumOccurences = 6 Then
        '        blnFullHouse = True
        '        intGameScoreAmerican = 25
        '        intGameScoreEnglish = 10


        '    ElseIf intNumOccurences = 7 Then
        '        bln4ofakind = True
        '        intGameScoreAmerican = 50
        '        intGameScoreEnglish = 16


        '    ElseIf intNumOccurences = 8 Then
        '        blnStraightFlush = True
        '        intGameScoreAmerican = 75
        '        intGameScoreEnglish = 30

        '    ElseIf intNumOccurences = 9 Then
        '        blnRoyalFlush = True
        '        intGameScoreAmerican = 100
        '        intGameScoreEnglish = 30

        '    End If
        '    MessageBox()

        'Next

        ''       Dim number As Integer = 8
        ''      Select Case number
        ''     Case 1 To 5
        ''  Debug.WriteLine("Between 1 and 5, inclusive")
        ''  The following is the only Case clause that evaluates to True.
        ''        Case 6, 7, 8
        ''  Debug.WriteLine("Between 6 and 8, inclusive")
        ''    Case 9 To 10
        ''  Debug.WriteLine("Equal to 9 or 10")
        ''  Case Else
        ''  Debug.WriteLine("Not between 1 and 10, inclusive")
        ''        End Select

        'If bln2ofakind = True And bln3ofakind = True Then
        '    '  MsgBox("Full House")

        'End If
        'lstCards.Items.Add(bln2ofakind & "" & bln3ofakind & "" & bln4ofakind)

        If (IsRoyalFlush(dealsuitarray, dealfacenbrarray)) Then
            MessageBox.Show("Royal")
        ElseIf (IsStraightFlush(dealsuitarray, dealfacenbrarray)) Then
            MessageBox.Show("Straight flush")
        ElseIf (IsStraight(dealfacenbrarray)) Then
            MessageBox.Show("straight")
        ElseIf (IsFlush(dealsuitarray)) Then
            MessageBox.Show("Flush")
        ElseIf (IsFullHouse(dealfacenbrarray)) Then
            MessageBox.Show("full")
        ElseIf (IsThreeKind(dealfacenbrarray)) Then
            MessageBox.Show("three")
        ElseIf (IsTwoPairs(dealfacenbrarray)) Then
            MessageBox.Show("2 pair")
        ElseIf (GetTwoKind(dealfacenbrarray, -1) <> -1) Then
            MessageBox.Show("1 pair")
        ElseIf (isFourKind(dealfacenbrarray)) Then
            MessageBox.Show("4 kind")
        Else
            MessageBox.Show("single")
        End If

        IntTotalScoreAmerican = IntTotalScoreAmerican + intGameScoreAmerican
        intTotalScoreEnglish = intTotalScoreEnglish + intGameScoreEnglish
        lstCards.Items.Add("===============================================")
        lstCards.Items.Add(ControlChars.Tab & "American Score" & ControlChars.Tab & "English Score")
        lstCards.Items.Add("Round Total" & ControlChars.Tab & IntTotalScoreAmerican & ControlChars.Tab & intTotalScoreEnglish)

    End Sub

    Private Sub btnPlayAgain_Click(sender As Object, e As EventArgs) Handles btnPlayAgain.Click
        '**************************************************************************************************	
        ' Author: Steven TIrpak 
        ' CS115 
        ' Date:  March 16, 2021
        ' Description:	CountOccurences 
        '              
        '               
        '              
        '               
        '**************************************************************************************************	

        intcount = 0
        btnDeal.Enabled = True
        GrpDeal.Visible = True
        GrpDraw.Visible = False
        GrpPlayGame.Visible = False
        GrpPlayAgain.Visible = False
        lstCards.Items.Clear()


    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        '**************************************************************************************************	
        ' Author: Steven TIrpak 
        ' CS115 
        ' Date:  March 16, 2021
        ' Description:	BtnExit once clicked will close program.      
        '**************************************************************************************************	

        Me.Close()

    End Sub


End Class
