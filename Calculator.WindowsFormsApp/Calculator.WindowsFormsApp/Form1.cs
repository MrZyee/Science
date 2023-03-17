namespace Calculator.WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public enum Operation
        {
            None,
            Addition,
            Substraction,
            Division,
            Multiplication
        }
        string _firstValue;
        string _secondValue;
        private Operation _currentOperation = Operation.None;
        private bool _isTheResultOnTheScreen;
        public Form1()
        {
            InitializeComponent();
            tbScreen.Text = "0";
        }

        private void OnBtnNumberClick(object sender, EventArgs e)
        {
            var clickValue = (sender as Button).Text;

            if (tbScreen.Text == "0" && clickValue != ",")
                tbScreen.Text = String.Empty;
         
            tbScreen.Text += clickValue;
            SetResultBtnState(true);

            if (_isTheResultOnTheScreen)
            {
                _isTheResultOnTheScreen = false;
                tbScreen.Text = string.Empty;

                if (clickValue == ",")
                    clickValue = "0";
                
            }

            if (_currentOperation != Operation.None)
                _secondValue += clickValue;
            else
                SetOperationBtnState(true);

        }

        private void OnBtnOperationClick(object sender, EventArgs e)
        {
            _firstValue = tbScreen.Text;

            var operation = (sender as Button).Text;

            _currentOperation = operation switch
            {
                "+" => Operation.Addition,
                "-" => Operation.Substraction,
                "/" => Operation.Division,
                "*" => Operation.Multiplication,
                 _ => Operation.None,
            };

            tbScreen.Text += $" {operation} ";

            if (_isTheResultOnTheScreen)
                _isTheResultOnTheScreen = false;

            SetOperationBtnState(false);
            SetResultBtnState(false);
        }

        private void OneBtnResultClick(object sender, EventArgs e)
        {

            if (_currentOperation == Operation.None)
                return;
            
            var firstNumber = double.Parse(_firstValue);
            var secondNumber = double.Parse(_secondValue);

            var result = Calculate(firstNumber, secondNumber);

            tbScreen.Text = result.ToString();
            _secondValue = string.Empty;
            _currentOperation = Operation.None;
            _isTheResultOnTheScreen = true;
            SetOperationBtnState(true);
            SetResultBtnState(true);

        }

        private double Calculate(double firstNumber, double secondNumber)
        {
            switch (_currentOperation)
            {
                case Operation.None:
                    return firstNumber;
                    
                case Operation.Addition:
                    return firstNumber + secondNumber;
                    
                case Operation.Substraction:
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Nie mo¿na dzieliæ przez zero!");
                        return 0;
                    }
                    return firstNumber - secondNumber;
                    
                case Operation.Division:
                    return firstNumber / secondNumber;
                    
                case Operation.Multiplication:
                    return firstNumber * secondNumber;
                    
            }

            return 0;
        }

        private void OneBtnClearClick(object sender, EventArgs e)
        {
            tbScreen.Text = "0";
            _firstValue = string.Empty;
            _secondValue = string.Empty;
            _currentOperation = Operation.None;
        }

        private void SetOperationBtnState(bool value)
        {
            btnAdd.Enabled = value;
            btnMultiplication.Enabled = value;
            btnDivision.Enabled = value;
            btnSubstraction.Enabled = value;
        }
        private void SetResultBtnState(bool value)
        {
            btnResult.Enabled = value;
        }
    }
}