Public Class frmMain

    Private Sub btnDisplayAccountSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayAccountSummary.Click

        Dim strAccountNum, strPastDue, strPayments, strPurchases As String
        Dim dblFinanceCharges, dblCurrentAmountDue As Double
        Dim srReader As IO.StreamReader
        Dim strFormat As String = "{0,-7}{1,12}{2,12}{3,12}{4,12}{5,12}"

        'Print Heading in ListBox
        lstAccountSummary.Items.Add(String.Format(strFormat, "Account", "Past Due", "", "", "Finance", "Current"))
        lstAccountSummary.Items.Add(String.Format(strFormat, "Number", "Amount", "Payments", "Purchases", "Charges", "Amt Due"))

        Try

            'Open File
            srReader = IO.File.OpenText("..\..\data.txt")

            While Not srReader.EndOfStream

                'Read Each Record from File
                strAccountNum = srReader.ReadLine
                strPastDue = srReader.ReadLine
                strPayments = srReader.ReadLine
                strPurchases = srReader.ReadLine

                Try

                    'Calculate
                    dblFinanceCharges = Math.Round((CDbl(strPastDue) - CDbl(strPayments)) * 0.015, 2)
                    dblCurrentAmountDue = CDbl(strPastDue) - CDbl(strPayments) + dblFinanceCharges + CDbl(strPurchases)

                    'Output Results in Zones
                    lstAccountSummary.Items.Add(String.Format( _
                                                    strFormat, _
                                                    strAccountNum, _
                                                    FormatCurrency(strPastDue), _
                                                    FormatCurrency(strPayments), _
                                                    FormatCurrency(strPurchases), _
                                                    FormatCurrency(dblFinanceCharges), _
                                                    FormatCurrency(dblCurrentAmountDue) _
                                                ))

                Catch Exception As InvalidCastException

                    MessageBox.Show("Invalid Data in Database File")

                End Try

            End While

        Catch Exception As IO.FileNotFoundException

            MessageBox.Show("Database File Not Found")

        End Try

    End Sub

End Class
