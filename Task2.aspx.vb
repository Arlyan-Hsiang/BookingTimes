Partial Class _Default
    Inherits Page
    Public Const MAX_DECIMAL_VALUE As Decimal = 9147483647.2147483647D  'to prevent overflow
    Public Shared DecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Public Shared SpaceString As String = " "
    Public Shared AndString As String = "and"
    Public Shared DashString As String = "-"
    Public Shared NegativeString As String = "negative"
    Public Enum RootNumbers
        zero
        one
        two
        three
        four
        five
        six
        seven
        eight
        nine
        ten
        eleven
        twelve
        thirteen
        fourteen
        fifteen
        sixteen
        seventeen
        eighteen
        nineteen
        twenty
        thirty = 30
        forty = 40
        fifty = 50
        sixty = 60
        seventy = 70
        eighty = 80
        ninety = 90
        hundred = 100
        thousand = 1000
        million = 1000000
        billion = 1000000000
    End Enum
    Public Shared Function GetDecimalWords(ByVal number As String) As String
        Dim result As New StringBuilder
        Dim mantissaString As String = number.TrimEnd("0"c)
        'make sure the decimal number's length is less or equal to 9
        If mantissaString.Length > 9 Then mantissaString = mantissaString.Substring(0, 9)
        For i = 0 To mantissaString.Length - 1
            'if the mantissa is not start with 0, use the normal logic.
            'Otherwise, transfer each number seperately
            If mantissaString(i) <> "0"c Then
                result.Append(GetNumberWords(CInt(number)))
                Exit For
            End If
            result.Append(GetRootNumberWord(Val(mantissaString(i))))
            result.Append(SpaceString)
        Next
        Return result.ToString
    End Function
    Public Shared Function GetNumberWords(ByVal number As Integer) As String
        'when input is 0 show zero
        If number = 0 Then Return GetRootNumberWord(0)
        'when input is a negative number, show negative at the beginning.
        If number < 0 Then
            Return NegativeString & SpaceString & GetNumberWords(System.Math.Abs(number))
        End If

        Dim result As New System.Text.StringBuilder
        Dim digitIndex As Integer = 9
        While digitIndex > 1
            'define billion, million, thousand or hundred
            Dim digitValue As Integer = CInt(10 ^ digitIndex)
            If number \ digitValue > 0 Then
                'output the string in a group with each three numbers
                result.Append(GetNumberWords(number \ digitValue))
                result.Append(SpaceString)
                'output billion million thousand hundred
                result.Append(GetRootNumberWord(digitValue))
                result.Append(SpaceString)
                number = number Mod digitValue
            End If
            'billion>million>thousand>hundred
            If digitIndex = 9 Then
                digitIndex = 6
            ElseIf digitIndex = 6 Then
                digitIndex = 3
            ElseIf digitIndex = 3 Then
                digitIndex = 2
            Else
                digitIndex = 0
            End If
        End While

        If number > 0 Then
            If result.Length > 0 Then
                result.Append(AndString)
                result.Append(SpaceString)
            End If
            'Seperate the logic for the number less than twenty
            If number < 20 Then
                result.Append(GetRootNumberWord(number))
            Else
                result.Append(GetRootNumberWord((number \ 10) * 10))
                Dim modTen As Integer = number Mod 10
                If modTen > 0 Then
                    result.Append(DashString)
                    result.Append(GetRootNumberWord(modTen))
                End If
            End If
        End If

        Return result.ToString
    End Function
    Public Shared Function GetRootNumberWord(ByVal number As RootNumbers) As String
        'Final transfer
        Return [Enum].GetName(GetType(RootNumbers), number)
    End Function
    Protected Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        'Empty the output label
        lblResult.Visible = False
        lblResult2.Visible = False
        If CheckNumber() = True Then
            'seperate the integer number into parts(0) and put the decimal number into parts(1) if it is existed.
            Dim parts() As String = txtNum.Text.ToString.Split({DecimalSeparator}, StringSplitOptions.None)
            lblResult.Text = GetNumberWords(CInt(parts(0))) + " Dollars"
            'the decimal number is existed
            If parts.Length = 2 Then
                lblResult2.Text = "And " + GetDecimalWords(parts(1)) + " Cents"
                lblResult2.Visible = True
            End If
        Else
            Return
        End If
        'show the label1 anyway, but unshow the label2 when there is an error.
    End Sub
    Public Function CheckNumber() As Boolean
        Dim number As Decimal
        lblResult.Visible = True
        If Decimal.TryParse(txtNum.Text, number) Then
            If number > MAX_DECIMAL_VALUE Then
                lblResult.Text = "Overflow"
                Return False
            End If
        Else
            lblResult.Text = "Invalid Number"
            Return False
        End If
        Return True
    End Function
End Class
