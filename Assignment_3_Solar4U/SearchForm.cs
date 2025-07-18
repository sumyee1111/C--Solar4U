using System;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Assignment_3_Solar4U
{
    public partial class SearchForm : Form
    {

        private FinanceForm financeForm;
        public SearchForm()
        {
            InitializeComponent();
            this.financeForm = new FinanceForm();
        }

        private void FindOrderButton_Click(object sender, EventArgs e)
        {
            // Get searching input from user
            string searchCriteria = SearchTextBox.Text.Trim();

            // Clear the previous results
            OrderInfoTextBox.Clear();

            // Check if the input is valid
            if (string.IsNullOrEmpty(searchCriteria))
            {
                MessageBox.Show("Please enter a valid search criteria.", "Error", MessageBoxButtons.OK);
                return;
            }

            // Determine if the input is a valid date or transaction number
            bool isDataSearch = DateTime.TryParseExact(searchCriteria, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime searchDate);
            bool isTransactionNumberSearch = int.TryParse(searchCriteria, out int searchTransactionNumber);

            try
            {
                using (StreamReader reader = new StreamReader(@"D:\Visual Studio文件\Assignment_3_Solar4U\ConfirmOrderInfo.txt"))
                {
                    string line;
                    bool found = false;
                    StringBuilder result = new StringBuilder(); // Store the result in StringBuilder

                    // Read each line of the file
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Search by date
                        if (isDataSearch && line.Contains("TransactionNumber:"))
                        {
                            // Extract the transaction number from the line
                            string transactionNumber = line.Substring(line.IndexOf("TransactionNumber:") + "TransactionNumber:".Length).Trim();

                            // Move to the next line to extract the date
                            line = reader.ReadLine();
                            if (line != null && line.Contains("Date:"))
                            {
                                // Extract the date part after "Date:" (and remove "Date:")
                                string dateString = line.Substring(line.IndexOf("Date:") + "Date:".Length).Trim();

                                // Compare the extracted date with the search date
                                if (dateString == searchDate.ToString("dd-MM-yyyy"))
                                {
                                    found = true;
                                    result.AppendLine($"Transaction Number: {transactionNumber}"); // Add the transaction number
                                    result.AppendLine(line); // Add the date line

                                    // Continue reading until "=== End ==="
                                    while ((line = reader.ReadLine()) != null && !line.Contains("=== End ==="))
                                    {
                                        result.AppendLine(line);
                                    }
                                    result.AppendLine("=== End ==="); // Append End line
                                }
                            }
                        }
                        // Search by transaction number
                        else if (isTransactionNumberSearch && line.Contains("TransactionNumber:"))
                        {
                            // Extract the transaction number from the line
                            string transactionNumber = line.Substring(line.IndexOf("TransactionNumber:") + "TransactionNumber:".Length).Trim();

                            // Compare with the search transaction number
                            if (transactionNumber == searchTransactionNumber.ToString())
                            {
                                found = true;
                                result.AppendLine(line); // Add the transaction number line

                                // Continue reading until "=== End ==="
                                while ((line = reader.ReadLine()) != null && !line.Contains("=== End ==="))
                                {
                                    result.AppendLine(line);
                                }

                                // Append the End line
                                result.AppendLine("=== End ===");
                            }
                        }
                    }

                    if (found)
                    {
                        OrderInfoTextBox.Text = result.ToString();
                        OrderInfoTextBox.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("No Matching Data Found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

