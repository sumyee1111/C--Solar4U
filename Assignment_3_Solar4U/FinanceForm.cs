using System;
using System.IO;
using System.Windows.Forms;

namespace Assignment_3_Solar4U
{
    public partial class FinanceForm : Form
    {
        const string TERM1 = "1 Year < 15k", TERM2 = "3 Years < 15k", TERM3 = "5 Years < 15k", TERM4 = "1 Year > 15k", TERM5 = "3 Years > 15k",
                     TERM6 = "5 Years > 15k", TERM7 = "1 Year > 30k", TERM8 = "3 Years > 30k", TERM9 = "5 Years > 30k";

        const decimal YEARINTERESTRATE1 = 0.085m, YEARINTERESTRATE2 = 0.08m, YEARINTERESTRATE3 = 0.075m, YEARINTERESTRATE4 = 0.0815m, YEARINTERESTRATE5 = 0.0755m,
                      YEARINTERESTRATE6 = 0.068m, YEARINTERESTRATE7 = 0.0785m, YEARINTERESTRATE8 = 0.0725m, YEARINTERESTRATE9 = 0.0615m;


        const decimal INTERESTRATE1 = 0.085m / 12m, INTERESTRATE2 = 0.08m / 12m, INTERESTRATE3 = 0.075m / 12m, INTERESTRATE4 = 0.0815m / 12m, INTERESTRATE5 = 0.0755m / 12m,
                      INTERESTRATE6 = 0.068m / 12m, INTERESTRATE7 = 0.0785m / 12m, INTERESTRATE8 = 0.0725m / 12m, INTERESTRATE9 = 0.0615m / 12m;
        decimal monthlyRepayment = 0, totalInterest = 0;
        static string loanTerm;
        decimal loanInterestRate;
        Boolean FinLoanAbove30kListBoxSelected, FinLoanAbove15kListBoxSelected, FinLoanBelow15kListBoxSelected;

        public FinanceForm()
        {
            InitializeComponent();

            FinLoanBelow15kListBox.SelectedIndexChanged += FinLoanBelow15kListBox_SelectedIndexChanged;
        }

        private void FinanceForm_Load(object sender, EventArgs e)
        {
            //Showing the detail of Customer info
            FinTransactionNumberLabel.Text = "TransactionNumber:" + MainForm.TransactionNumber; ;
            FinDateLabel.Text = MainForm.currentDate;
            FinFullNameTextBox.Text = MainForm.FullName;
            FinPostcodeTextBox.Text = MainForm.Postcode;
            FinTelephoneTextBox.Text = MainForm.Telephone;
            FinEmailAddressTextBox.Text = MainForm.EmailAdress;

            // Showing the detail of Order info
            FinPanelTypeLabel.Text = "Type:" + MainForm.PanelType;
            FinSizeLabel.Text = "Size:" + MainForm.NumberCells;
            FinNumberLabel.Text = "Number:" + MainForm.NumberPanels;
            FinButteryTypeLabel.Text = "Type:" + MainForm.BatteryType;
            FinInverterLabel.Text = "Inverter:" + MainForm.InverterType;
            FinExpeditedLabel.Text = "Expedited:" + MainForm.InstallationType;
            FinOverCostLabel.Text = "Overall Cost:" + MainForm.TotalQuoteRevenue.ToString("C2");

            FinRateLabel.Text = "N/A";
            FinMonthlyRepaymentLabel.Text = "N/A";
            FinTotalInterestLabel.Text = "N/A";

            // Calculating the loan amount

            if (MainForm.TotalQuoteRevenue < 15000)
            {
                FinLoanBelow15kListBox.Visible = true;
                CalculatBelow15kLoan();
            }
            else if ((MainForm.TotalQuoteRevenue >= 15000) && (MainForm.TotalQuoteRevenue < 30000))
            {
                FinLoanAbove15kListBox.Visible = true;
                CalculatAbove15kLoan();
            }
            else if (MainForm.TotalQuoteRevenue > 30000)
            {
                FinLoanAbove30kListBox.Visible = true;
                CalculatAbove30kLoan();
            }

     

        }

        private void CalculatBelow15kLoan()
        {
            int termIndex;
            int loanTermMonths = 0;
            decimal monthlyRate = 0, yearlyRate = 0;

            //The loan amount below 15k
            if (MainForm.TotalQuoteRevenue < 15000)
            {
                if (FinLoanBelow15kListBox.SelectedIndex != -1)
                {
                    termIndex = FinLoanBelow15kListBox.SelectedIndex + 1;
                    switch (termIndex)
                    {
                        case 1: loanTerm = TERM1; loanInterestRate = INTERESTRATE1; loanTermMonths = 12; yearlyRate = YEARINTERESTRATE1; monthlyRate = INTERESTRATE1; break;
                        case 2: loanTerm = TERM2; loanInterestRate = INTERESTRATE2; loanTermMonths = 36; yearlyRate = YEARINTERESTRATE2; monthlyRate = INTERESTRATE2; break;
                        case 3: loanTerm = TERM3; loanInterestRate = INTERESTRATE3; loanTermMonths = 60; yearlyRate = YEARINTERESTRATE3; monthlyRate = INTERESTRATE3; break;
                    }

                    decimal loanPrincipal = MainForm.TotalQuoteRevenue;
                            monthlyRepayment = loanPrincipal * loanInterestRate * (decimal)Math.Pow((double)(1 + loanInterestRate), loanTermMonths) /
                                      ((decimal)Math.Pow((double)(1 + loanInterestRate), loanTermMonths) - 1);

                    decimal totalPayment = monthlyRepayment * loanTermMonths;
                    totalInterest = totalPayment - MainForm.TotalQuoteRevenue;

                    //Display the result
                    FinRateLabel.Text = "Interest Rate(Y/M):\n" + yearlyRate.ToString("P2") + "/" + monthlyRate.ToString("P2");
                    FinMonthlyRepaymentLabel.Text = "Monthly Repayment: \n" + monthlyRepayment.ToString("C2");
                    FinTotalInterestLabel.Text = "Total Interest: \n" + totalInterest.ToString("C2");

                }

            }
        }
        private void FinLoanBelow15kListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatBelow15kLoan();
            FinLoanBelow15kListBoxSelected = FinLoanBelow15kListBox.SelectedIndex != -1;
            CalculatBelow15kLoan();
        }
        private void CalculatAbove15kLoan()
        {
            int termIndex;
            int loanTermMonths = 0;
            decimal monthlyRate = 0, yearlyRate = 0;

            //The loan amount above 15k
            if ((MainForm.TotalQuoteRevenue >= 15000) && (MainForm.TotalQuoteRevenue < 30000))
            {
                if (FinLoanAbove15kListBox.SelectedIndex != -1)
                {
                    termIndex = FinLoanAbove15kListBox.SelectedIndex + 1;
                    switch (termIndex)
                    {
                        case 1: loanTerm = TERM4; loanInterestRate = INTERESTRATE4; loanTermMonths = 12; yearlyRate = YEARINTERESTRATE4; monthlyRate = INTERESTRATE4; break;
                        case 2: loanTerm = TERM5; loanInterestRate = INTERESTRATE5; loanTermMonths = 36; yearlyRate = YEARINTERESTRATE5; monthlyRate = INTERESTRATE5; break;
                        case 3: loanTerm = TERM6; loanInterestRate = INTERESTRATE6; loanTermMonths = 60; yearlyRate = YEARINTERESTRATE6; monthlyRate = INTERESTRATE6; break;
                    }

                    decimal loanPrincipal = MainForm.TotalQuoteRevenue;
                    monthlyRepayment = loanPrincipal * loanInterestRate * (decimal)Math.Pow((double)(1 + loanInterestRate), loanTermMonths) /
                              ((decimal)Math.Pow((double)(1 + loanInterestRate), loanTermMonths) - 1);

                    decimal totalPayment = monthlyRepayment * loanTermMonths;
                    totalInterest = totalPayment - MainForm.TotalQuoteRevenue;

                    //Display the result
                    FinRateLabel.Text = "Interest Rate(Y/M):\n" + yearlyRate.ToString("P2") + "/" + monthlyRate.ToString("P2");
                    FinMonthlyRepaymentLabel.Text = "Monthly Repayment: \n" + monthlyRepayment.ToString("C2");
                    FinTotalInterestLabel.Text = "Total Interest: \n" + totalInterest.ToString("C2");
                }

            }
        }
        private void FinLoanAbove15kListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatAbove15kLoan();
            FinLoanAbove15kListBoxSelected = FinLoanAbove15kListBox.SelectedIndex != -1;
            CalculatAbove15kLoan();
        }
        private void CalculatAbove30kLoan()
        {
            int termIndex;
            int loanTermMonths = 0;
            decimal monthlyRate = 0, yearlyRate = 0;

            //The loan amount above 30k
            if (MainForm.TotalQuoteRevenue > 30000)
            {
                if (FinLoanAbove30kListBox.SelectedIndex != -1)
                {
                    termIndex = FinLoanAbove30kListBox.SelectedIndex + 1;
                    switch (termIndex)
                    {
                        case 1: loanTerm = TERM7; loanInterestRate = INTERESTRATE7; loanTermMonths = 12; yearlyRate = YEARINTERESTRATE7; monthlyRate = INTERESTRATE7; break;
                        case 2: loanTerm = TERM8; loanInterestRate = INTERESTRATE8; loanTermMonths = 36; yearlyRate = YEARINTERESTRATE8; monthlyRate = INTERESTRATE8; break;
                        case 3: loanTerm = TERM9; loanInterestRate = INTERESTRATE9; loanTermMonths = 60; yearlyRate = YEARINTERESTRATE9; monthlyRate = INTERESTRATE9; break;
                    }

                    decimal loanPrincipal = MainForm.TotalQuoteRevenue;
                    monthlyRepayment = loanPrincipal * loanInterestRate * (decimal)Math.Pow((double)(1 + loanInterestRate), loanTermMonths) /
                              ((decimal)Math.Pow((double)(1 + loanInterestRate), loanTermMonths) - 1);

                    decimal totalPayment = monthlyRepayment * loanTermMonths;
                    totalInterest = totalPayment - MainForm.TotalQuoteRevenue;

                    //Display the result
                    FinRateLabel.Text = "Interest Rate(Y/M):\n" + yearlyRate.ToString("P2") + "/" + monthlyRate.ToString("P2");
                    FinMonthlyRepaymentLabel.Text = "Monthly Repayment: \n" + monthlyRepayment.ToString("C2");
                    FinTotalInterestLabel.Text = "Total Interest: \n" + totalInterest.ToString("C2");
                }

            }
        }
        private void FinLoanAbove30kListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatAbove30kLoan();
            FinLoanAbove30kListBoxSelected = FinLoanAbove30kListBox.SelectedIndex != -1;
            CalculatAbove30kLoan();
        }
        private void FinCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void FinProceedButton_Click(object sender, EventArgs e)
        {
            //Check if the customer has selected the loan term
            if (FinLoanBelow15kListBoxSelected || FinLoanAbove15kListBoxSelected || FinLoanAbove30kListBoxSelected)
            {
                DialogResult confirmResult = MessageBox.Show("Please confirm that the customer has reviewed the order and loan information.",
                                                             "Submit Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        StreamWriter OutputFile = File.AppendText(@"D:\Visual Studio文件\Assignment_3_Solar4U\ConfirmOrderInfo.txt");

                        int i = 0;

                        // While loop recodes the all info
                        while (i < 17)
                        {
                            switch (i)
                            {
                                case 0: 
                                    OutputFile.WriteLine(FinTransactionNumberLabel.Text); 
                                    break;
                                case 1: 
                                    OutputFile.WriteLine(FinDateLabel.Text); 
                                    break;
                                case 2: 
                                    OutputFile.WriteLine(FinFullNameTextBox.Text); 
                                    break;
                                case 3: 
                                    OutputFile.WriteLine(FinPostcodeTextBox.Text); 
                                    break;
                                case 4: 
                                    OutputFile.WriteLine(FinTelephoneTextBox.Text); break;
                                case 5: 
                                    OutputFile.WriteLine(FinEmailAddressTextBox.Text); 
                                    break;
                                case 6: 
                                    OutputFile.WriteLine(FinPanelTypeLabel.Text); 
                                    break;
                                case 7: 
                                    OutputFile.WriteLine(FinSizeLabel.Text); 
                                    break;
                                case 8: 
                                    OutputFile.WriteLine(FinNumberLabel.Text); 
                                    break;
                                case 9: 
                                    OutputFile.WriteLine(FinButteryTypeLabel.Text); 
                                    break;
                                case 10: 
                                    OutputFile.WriteLine(FinInverterLabel.Text); 
                                    break;
                                case 11: 
                                    OutputFile.WriteLine(FinExpeditedLabel.Text); 
                                    break;
                                case 12: 
                                    OutputFile.WriteLine(FinOverCostLabel.Text); 
                                    break;
                                case 13: 
                                    OutputFile.WriteLine(FinRateLabel.Text); 
                                    break;
                                case 14: 
                                    OutputFile.WriteLine(FinMonthlyRepaymentLabel.Text); 
                                    break;
                                case 15: 
                                    OutputFile.WriteLine(FinTotalInterestLabel.Text); 
                                    break;
                                case 16: 
                                    OutputFile.WriteLine("=== End ==="); 
                                    break;
                            }
                            i++;
                        }

                        OutputFile.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.Message, "Error:", MessageBoxButtons.OK);
                    }

                    //Close the Form
                    this.Close(); 
                }
                
            }
        }

    }
}
        
