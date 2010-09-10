Public Class frmMain

    Private Sub btnDisplayAccountSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayAccountSummary.Click

        Dim srReader As IO.StreamReader = IO.File.OpenText("..\..\data.txt")

        Dim strAccountNum, strPastDue, strPayments, strPurchases As String
        Dim strFormat As String = "{0}"

        While Not srReader.EndOfStream

            'Read Each Record from File
            strAccountNum = srReader.ReadLine
            strPastDue = srReader.ReadLine
            strPayments = srReader.ReadLine
            strPurchases = srReader.ReadLine

            'Calculate 

            'Output Results in Zones
            lstAccountSummary.Items.Add(strAccountNum & strPastDue & strPayments & strPurchases)

        End While

    End Sub
End Class
