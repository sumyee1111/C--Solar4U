/* Student Name: Zhang Xinyi
 * Student ID: 24231639
 * Date:18/11/2024
 * Assignment: 3
 * Assignment: This time, the content is an extension of Assignment 2, where an additional window was added to allow   
 * customers to enter personal information after placing an order. All the information is then displayed in the FinanceForm, 
 * and the loan interest rate is calculated based on the amount. Additionally, this assignment also includes functionality 
 * for writing to and reading from a file, enabling us to search using key information.
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Assignment_3_Solar4U
{
    public partial class MainForm : Form
    {
        //PANEL TYPE MASTER DATA
        const string PANEL1 = "LONGi Solar", PANEL2 = "Jinko Solar", PANEL3 = "Trina Solar",
                     PANEL4 = "Canadian Solar", PANEL5 = "Q-Cell", PANEL6 = "First Solar";

        const decimal PANEL1COST = 129.5M, PANEL2COST = 135M, PANEL3COST = 112.79M, PANEL4COST = 149M,
                      PANEL5COST = 131M, PANEL6COST = 119M;

        //PANEL SIZE MASTER DATA
        const string CELL1 = "30 Cell", CELL2 = "48 Cell", CELL3 = "60 Cell", CELL4 = "72 Cell", CELL5 = "84 Cell", CELL6 = "96 Cell";

        const int CELLSNUM1 = 30, CELLSNUM2 = 48, CELLSNUM3 = 60, CELLSNUM4 = 72, CELLSNUM5 = 84, CELLSNUM6 = 96, CELLBOUNDARY = 700;

        const decimal CELLS1PERCENT = .25M, CELLS2PERCENT = -.15M, CELLS3PERCENT = .0M,
                      CELLS4PERCENT = 1.15M, CELLS5PERCENT = 1.25M, CELLS6PERCENT = 1.4M, BUNDLEDISCOUNT = 0.03M;


        //BATTERY, INVERTER & INSTALL MASTER DATA
        const string BATTERY1 = "5 KWh", BATTERY2 = "10KWh", BATTERY3 = "20KWh", NOBATTERY = "Not Required";


        const decimal BATTERYPRICE1 = 4500m, BATTERYPRICE2 = 75000m, BATTERYPRICE3 = 9500m;

        const string INVERTER1 = "Strandard < 700 Cells", INVERTER2 = "Strandard > 700 Cells", INVERTER3 = "Hybrid < 700 Cells",
                     INVERTER4 = "Hybrid > 700 Cells",
                     STANDARDINSTALL = "Standard Install", EXPINSTALL = "Expediated Install";

        const decimal INVERTERPRICE1 = 650m, INVERTERPRICE2 = 950m, INVERTERPRICE3 = 1150m, INVERTERPRICE4 = 1350m,
                      INSTALLATION = 499m, EXPEDIATEDINSTALL = 299m;

        const int INCREMENT = 4, FORMSTARTWIDTH = 1000, FORMSTARTHEIGHT = 747, FORMEXPANDHEIGHT = 760, FORMEXPANDWIDTH = 1100;

        // Field Variable

        public static string PanelType, NumberCells, BatteryType, InverterType, InstallationType;
        public static decimal TotalCompanyOrderRevenue, TotalCompanyDiscountGiven, TotalQuoteRevenue, TotalQuoteDiscount;
        public static int TotalSystemSales = 0, TotalSystemWithDiscount = 0, NumberPanels = 0, NumberCellsPanel = 0;
        Boolean BatterySelected = false, DiscountAchived = false;
        Boolean FormWidthExpanded = false, FormHeightExpanded = false;

        public static string FullName, Postcode, Telephone, EmailAdress,currentDate;
        public static Random SomeMadNumber = new Random();
        public static int TransactionNumber;

        public MainForm()
        {
            InitializeComponent();

            // Use ToopTip to display Info about Buttons
            ButtonInfoToolTip.SetToolTip(QuoteButton, "Please Press Ctrl+Q to Quote");
            ButtonInfoToolTip.SetToolTip(OrderButton, "Please Press Ctrl+O to Order");
            ButtonInfoToolTip.SetToolTip(SearchButton, "Please Press Ctrl+S to Search");
            ButtonInfoToolTip.SetToolTip(ClearButton, "Please Press Ctrl+C to Clear");
            ButtonInfoToolTip.SetToolTip(ExitButton, "Please Press Ctrl+E to Exit");
        }

        //Main Application Functionality
        private void QuoteButton_Click(object sender, EventArgs e)
        {
            int PanelIndex, SizeIndex, TotalSystemNumberCells;

            decimal PanelPrice = 0m, PriceMultipler = 0m, BatteryPrice = 0m, InstallationPrice = 0m,
                    InverterPrice = 0m, SystemCostBeforeDiscount = 0m, DiscountTemp = 0m;
            NumberPanelsTextBox.Enabled = false;
            PanelsListBox.Enabled = false;
            SizesListBox.Enabled = false;
            RadioButtonsPanel.Enabled = false;
            ExpInstallstionCheckBox.Enabled = false;

            //Select all requirements
            if (NumberPanelsTextBox.Text != "")
            {
                if (int.TryParse(NumberPanelsTextBox.Text, out NumberPanels))
                {
                    if (NumberPanels > 0)
                    {
                        if ((PanelsListBox.SelectedIndex != -1))
                        {
                            if ((SizesListBox.SelectedIndex != -1))
                            {
                                PanelIndex = PanelsListBox.SelectedIndex + 1;
                                SizeIndex = SizesListBox.SelectedIndex + 1;

                                switch (PanelIndex)
                                {
                                    case 1: PanelType = PANEL1; PanelPrice = PANEL1COST; break;
                                    case 2: PanelType = PANEL2; PanelPrice = PANEL2COST; break;
                                    case 3: PanelType = PANEL3; PanelPrice = PANEL3COST; break;
                                    case 4: PanelType = PANEL4; PanelPrice = PANEL4COST; break;
                                    case 5: PanelType = PANEL5; PanelPrice = PANEL5COST; break;
                                    case 6: PanelType = PANEL6; PanelPrice = PANEL6COST; break;
                                }

                                switch (SizeIndex)
                                {
                                    case 1: NumberCells = CELL1; PriceMultipler = CELLS1PERCENT; NumberCellsPanel = CELLSNUM1; break;
                                    case 2: NumberCells = CELL2; PriceMultipler = CELLS2PERCENT; NumberCellsPanel = CELLSNUM2; break;
                                    case 3: NumberCells = CELL3; PriceMultipler = CELLS3PERCENT; NumberCellsPanel = CELLSNUM3; break;
                                    case 4: NumberCells = CELL4; PriceMultipler = CELLS4PERCENT; NumberCellsPanel = CELLSNUM4; break;
                                    case 5: NumberCells = CELL5; PriceMultipler = CELLS5PERCENT; NumberCellsPanel = CELLSNUM5; break;
                                    case 6: NumberCells = CELL6; PriceMultipler = CELLS6PERCENT; NumberCellsPanel = CELLSNUM6; break;
                                }

                                // Battery

                                if (FiveKWhRadioButton.Checked)
                                {
                                    BatteryType = BATTERY1;
                                    BatteryPrice = BATTERYPRICE1;
                                    BatterySelected = true;
                                }
                                else if (TenKWhRadioButton.Checked)
                                {
                                    BatteryType = BATTERY2;
                                    BatteryPrice = BATTERYPRICE2;
                                    BatterySelected = true;
                                }
                                else if (TwentyKWhRadioButton.Checked)
                                {
                                    BatteryType = BATTERY3;
                                    BatteryPrice = BATTERYPRICE3;
                                    BatterySelected = true;
                                }
                                else
                                {
                                    BatteryType = NOBATTERY;
                                    BatteryPrice = 0m;
                                    BatterySelected = false;
                                }

                                // Installation type choosed

                                if (ExpInstallstionCheckBox.Checked)
                                {
                                    InstallationType = EXPINSTALL;
                                    InstallationPrice = (INSTALLATION + EXPEDIATEDINSTALL);
                                }
                                else
                                {
                                    InstallationType = STANDARDINSTALL;
                                    InstallationPrice = INSTALLATION;
                                }

                                // Inverter type

                                TotalSystemNumberCells = (NumberPanels * NumberCellsPanel);

                                if (TotalSystemNumberCells < CELLBOUNDARY)
                                {
                                    if (BatterySelected)
                                    {
                                        InverterType = INVERTER3;
                                        InverterPrice = INVERTERPRICE3;
                                    }
                                    else
                                    {
                                        InverterType = INVERTER1;
                                        InverterPrice = INVERTERPRICE1;
                                    }
                                }
                                else
                                {
                                    if (BatterySelected)
                                    {
                                        InverterType = INVERTER4;
                                        InverterPrice = INVERTERPRICE4;
                                    }
                                    else
                                    {
                                        InverterType = INVERTER2;
                                        InverterPrice = INVERTERPRICE2;
                                    }
                                }

                                // Discount Calculation

                                decimal SystemPricePanels = (NumberPanels * (PanelPrice + (PanelPrice * PriceMultipler)));

                                SystemCostBeforeDiscount = SystemPricePanels + BatteryPrice + InstallationPrice + InverterPrice;

                                if ((BatteryPrice > BATTERYPRICE1) && (TotalSystemNumberCells > CELLBOUNDARY))
                                {
                                    DiscountTemp = (BUNDLEDISCOUNT * SystemCostBeforeDiscount);
                                    TotalQuoteRevenue = (SystemCostBeforeDiscount - DiscountTemp);
                                    DiscountAddedLabel.Visible = true;
                                    DiscountAchived = true;
                                }
                                else
                                {
                                    TotalQuoteRevenue = SystemCostBeforeDiscount;
                                }

                                // Display UI

                                PanelTypeTextBox.Text = PanelType;
                                PanelSizeTextBox.Text = NumberCells;
                                PricePerPanleTextBox.Text = (PanelPrice + (PanelPrice * PriceMultipler)).ToString("C2");
                                NumberofPanelsTextBox.Text = NumberPanels.ToString("N0");
                                TotalPanelCostTextBox.Text = SystemPricePanels.ToString("C2");

                                //Display battery Cost
                                BatteryTypeTextBox.Text = BatteryType;
                                if (BatteryPrice > 0)
                                {
                                    BatteryCostTextBox.Text = BatteryPrice.ToString("C2");
                                }
                                else
                                {
                                    BatteryCostTextBox.Text = "N/A";
                                }

                                InverterTypeTextBox.Text = InverterType;
                                InverterCostTextBox.Text = InverterPrice.ToString("C2");
                                InstallationTypeTextBox.Text = InstallationType;
                                InstallationCostTextBox.Text = InstallationPrice.ToString("C2");

                                if (DiscountTemp > 0)
                                {
                                    DiscountAvailableTextBox.Text = DiscountTemp.ToString("C2");
                                    TotalQuoteDiscount = DiscountTemp;
                                    DiscountAvailableTextBox.Visible = true;
                                    DiscountDisplayLabel.Visible = true;
                                }
                                else
                                {
                                    DiscountAvailableTextBox.Visible = false;
                                    DiscountDisplayLabel.Visible = false;
                                }

                                OverallSystemCostTextBox.Text = TotalQuoteRevenue.ToString("C2");

                                // Set Up UI
                                LogoPictureBox.Visible = false;
                                NotRequiredRadioButton.Visible = true;
                                QuoteGroupBox.Visible = true;
                                OrderButton.Enabled = true;
                                OrderButton.Focus();
                                QuoteButton.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("A Panel Size is needed to proceed", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("A Type of Solar Panel is needed to proceed", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Number of Panels need to be greater than 0", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NumberPanelsTextBox.Focus();
                        NumberPanelsTextBox.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Entry of numerical whole number requires", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NumberPanelsTextBox.Focus();
                    NumberPanelsTextBox.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Number of Panel Required", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NumberPanelsTextBox.Focus();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(FORMSTARTWIDTH, FORMSTARTHEIGHT);
        }
        private void OrderButton_Click(object sender, EventArgs e)
        {
            DialogResult Result;
            string PanelsOnly = "\n You have selected " + NumberPanels + " " + PanelType + " " + NumberCells + "Panels" +
                           "\n\nYour order includes a " + InverterType + " Inverter and " + InstallationType + "." +
                           "\n\nTotal cost of your order is " + TotalQuoteRevenue.ToString("C2") + "\n\nDo you wish to proceed ?";

            string PanelsAndBattery = "\nYou have a selected " + NumberPanels + " " + PanelType + " " + NumberCells + "Panels" +
                           "with a " + BatteryType + "Battery" + "\n\nYour Order Includes a " + InverterType + "Inverter and" + InstallationType + "Installation" +
                           "\n\nTotal cost of your order is " + TotalQuoteRevenue.ToString("C2") + "\n\nDo you Wish to proceed ?";
            
            // Check if Battery is selected
            if (BatterySelected)
            {
                Result = MessageBox.Show(PanelsAndBattery, "Order Comfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                Result = MessageBox.Show(PanelsOnly, "Order Comfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (Result == DialogResult.Yes)
            {
                TotalSystemSales++;
                TotalCompanyOrderRevenue += TotalQuoteRevenue;
                TotalCompanyDiscountGiven += TotalQuoteDiscount;

                if (DiscountAchived)
                {
                    TotalSystemWithDiscount++;
                }

                OrderButton.Enabled = false;
                ClearButton_Click(sender, e);
                QuoteGroupBox.Visible = true;
            }

            // Expand Form
            if (!FormWidthExpanded)
            {
                for (int i = FORMSTARTWIDTH; i < FORMEXPANDWIDTH; i += INCREMENT)
                {
                    this.Size = new Size(i, FORMSTARTHEIGHT);
                    this.Update();
                    System.Threading.Thread.Sleep(1);
                }

                FormWidthExpanded = true;
                FormHeightExpanded = false;
            }

            // Create Customer Info
            CustomerInfoGroupBox.Visible = true;

            Random SomeMadNumber = new Random();
            TransactionNumber = SomeMadNumber.Next(100000, 1000000);
            TransactionNumberLabel.Text = "TransactionNumber:" + TransactionNumber;

            currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            DateLabel.Text = "Date:" + currentDate;

            // Set limit of TextBox
            if (FullNameTextBox.Text != "")
            {
                if (PostcodeTextBox.Text != "" && PostcodeTextBox.Text.Length == 6 && System.Text.RegularExpressions.Regex.IsMatch(PostcodeTextBox.Text, "^[a-zA-Z0-9]+$"))
                {
                    if (EmailAddressTextBox.Text.Contains("@") && EmailAddressTextBox.Text != "" && EmailAddressTextBox.Text.Contains("."))
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(TelephoneTextBox.Text, "^[0-9]+$"))
                        {
                            SubmitButton_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Telephone number must contain only number");
                            TelephoneTextBox.Focus();
                            TelephoneTextBox.SelectAll();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email address is wrong format, it should contain '@' 和 '.'");
                        EmailAddressTextBox.Focus();
                        EmailAddressTextBox.SelectAll();
                        return;

                    }
                }
                else
                {
                    MessageBox.Show("Postcode must contain only number and 6 charactors");
                    PostcodeTextBox.Focus();
                    PostcodeTextBox.SelectAll();
                    return;
                }
            }
            else
            {

            }

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();

        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Display UI
            QuoteButton.Enabled = true;
            OrderButton.Enabled = false;
            NumberPanelsTextBox.Enabled = true;
            PanelsListBox.Enabled = true;
            SizesListBox.Enabled = true;
            RadioButtonsPanel.Enabled = true;
            ExpInstallstionCheckBox.Enabled = true;

            PanelsListBox.SelectedIndex = SizesListBox.SelectedIndex = -1;

            NumberPanelsTextBox.Text = "";
            DiscountAddedLabel.Visible = NotRequiredRadioButton.Visible = false;

            NotRequiredRadioButton.Checked = true;
            ExpInstallstionCheckBox.Checked = false;

            QuoteGroupBox.Visible = false;
            LogoPictureBox.Visible = SelectPanel.Visible = true;

            TotalQuoteDiscount = 0;
            DiscountAchived = false;

            CustomerInfoGroupBox.Visible = false;

        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrderButton.Enabled)
            {
                QuoteButton_Click(null, null);
            }
        }
        private void SizesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelsListBox_SelectedIndexChanged(null, null);
        }

        private void NumberPanelsTextBox_TextChanged(object sender, EventArgs e)
        {
            int PanelNumber = 0, SizeIndex;

            // Check if panel number is vaild
            try
            {
                PanelNumber = int.Parse(NumberPanelsTextBox.Text);

                if (PanelNumber > 0)
                {
                    if ((PanelsListBox.SelectedIndex != -1) || (PanelsListBox.SelectedIndex != 0))
                    {
                        if ((SizesListBox.SelectedIndex != -1) || (SizesListBox.SelectedIndex != 0))
                        {
                            SizeIndex = SizesListBox.SelectedIndex;

                            switch (SizeIndex)
                            {
                                case 1: NumberCellsPanel = CELLSNUM1; break;
                                case 2: NumberCellsPanel = CELLSNUM2; break;
                                case 3: NumberCellsPanel = CELLSNUM3; break;
                                case 4: NumberCellsPanel = CELLSNUM4; break;
                                case 5: NumberCellsPanel = CELLSNUM5; break;
                                case 6: NumberCellsPanel = CELLSNUM6; break;
                            }
                        }
                    }

                    if ((PanelNumber * NumberCellsPanel) >= CELLBOUNDARY)
                    {
                        DiscountAddedLabel.Visible = true;
                        LogoPictureBox.Visible = false;

                        if (OrderButton.Enabled)
                        {
                            QuoteButton_Click(null, null);
                        }
                    }
                    else
                    {
                        DiscountAddedLabel.Visible = false;
                        LogoPictureBox.Visible = true;

                        if (OrderButton.Enabled)
                        {
                            QuoteButton_Click(null, null);
                        }
                    }
                }
            }
            catch
            {
               

            }

        }

        private void ExpInstallstionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PanelsListBox_SelectedIndexChanged(null, null);
        }

        private void TenKWhRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TenKWhRadioButton.Checked)
            {
                PanelsListBox_SelectedIndexChanged(null, null);
            }
        }

        private void TwentyKWhRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TwentyKWhRadioButton.Checked)
            {
                PanelsListBox_SelectedIndexChanged(null, null);
            }
        }
        private void NotRequiredRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NotRequiredRadioButton.Checked)
            {
                PanelsListBox_SelectedIndexChanged(null, null);
            }
        }
        private void FiveKWhRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FiveKWhRadioButton.Checked)
            {
                PanelsListBox_SelectedIndexChanged(null, null);
            }
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            currentDate = DateLabel.Text;
            FullName = FullNameTextBox.Text;
            Telephone = TelephoneTextBox.Text;
            Postcode = PostcodeTextBox.Text;
            EmailAdress = EmailAddressTextBox.Text;

            FinanceForm MyFinanceForm = new FinanceForm();
            MyFinanceForm.ShowDialog();
        }

        private void ClearSubmitButton_Click(object sender, EventArgs e)
        {
            CustomerInfoGroupBox.Visible = false;
        }

    }
}
