Public Class frmMain

    Private Sub btnDisplayAccountSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayAccountSummary.Click

        Dim srReader As IO.StreamReader = IO.File.OpenText("..\..\data.txt")

        Dim strAccountNum, strPastDue, strPayments, strPurchases As String
		Dim dblFinanceCharges, dblCurrentAmountDue As Double
        Dim strFormat As String = "{0,-7}{1,12}{2,12}{3,12}{4,12}{5,12}"

		'Print Heading in ListBox
		'Show Alternate Spacing to Class!
		lstAccountSummary.Items.Add(String.Format(strFormat, "Account", "Past Due", "", "", "Finace", "Current")
		lstAccountSummary.Items.Add(String.Format(strFormat, "Number", "Amount", "Payments", "Purchases", "Charges", "Amt Due")
		
        While Not srReader.EndOfStream

            'Read Each Record from File
            strAccountNum = srReader.ReadLine
            strPastDue = srReader.ReadLine
            strPayments = srReader.ReadLine
            strPurchases = srReader.ReadLine

            'Calculate 
			dblFinanceCharges = Math.Round((CDbl(strPastDue) - CDbl(strPayments)) * .015, 2)
			dblCurrentAmountDue = CDbl(strPastDue) - CDbl(strPayments) + dblFinanceCharges + CDbl(strPurchases)
			
            'Output Results in Zones
            lstAccountSummary.Items.Add(String.Format(strFormat, strAccountNum, strPastDue, strPayments, strPurchases, dblFinanceCharges.ToString, dblCurrentAmountDue.ToString)

        End While

    End Sub
End Class
