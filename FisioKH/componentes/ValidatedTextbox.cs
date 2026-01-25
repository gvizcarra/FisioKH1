using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace FisioKH
{
    public class ValidatedNumericTextBox : TextBox
    {
        // ===== Validation properties =====
        private bool _isRequired = true;
        private bool _numericOnly = false;
        private decimal? _minValue;
        private decimal? _maxValue;
        private string _errorMessage = "Valor no Valido";

        [Browsable(false)]
        public ErrorProvider ErrorProvider { get; set; }

        [Category("Validation")]
        public bool IsRequired
        {
            get => _isRequired;
            set => _isRequired = value;
        }

        [Category("Validation")]
        public bool NumericOnly
        {
            get => _numericOnly;
            set => _numericOnly = value;
        }

        [Category("Validation")]
        public decimal? MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        [Category("Validation")]
        public decimal? MaxValue
        {
            get => _maxValue;
            set => _maxValue = value;
        }

        [Category("Validation")]
        public string ErrorMessage
        {
            get => _errorMessage;
            set => _errorMessage = value;
        }

        [Browsable(false)]
        public bool IsValid => ValidateValue(false);

        // ===== Validation logic =====
        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            if (!ValidateValue(true))
                e.Cancel = true;
        }

        private bool ValidateValue(bool showError)
        {
            if (_isRequired && string.IsNullOrWhiteSpace(Text))
                return Fail(showError, "La informacion es Necesaria");

            if (!_numericOnly || string.IsNullOrWhiteSpace(Text))
            {
                ClearError();
                return true;
            }

            if (!decimal.TryParse(Text, NumberStyles.Number, CultureInfo.CurrentCulture, out var value))
                return Fail(showError, "Numero no Valido");

            if (_minValue.HasValue && value < _minValue.Value)
                return Fail(showError, $"La cantidad  Minima es de {_minValue} Caracteres");

            if (_maxValue.HasValue && value > _maxValue.Value)
                return Fail(showError, $"La cantidad  Maxima es de {_minValue} Caracteres");

            ClearError();
            return true;
        }

        private bool Fail(bool showError, string message)
        {
            if (showError)
                ShowError(message);
            return false;
        }

        private void ShowError(string message)
        {
            ErrorProvider?.SetError(this, message);
        }

        private void ClearError()
        {
            ErrorProvider?.SetError(this, "");
        }

        // ===== Prevent invalid typing =====
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (!_numericOnly)
                return;

            char decimalSeparator = Convert.ToChar(
                CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != decimalSeparator &&
                e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // Only one decimal separator
            if (e.KeyChar == decimalSeparator && Text.Contains(decimalSeparator.ToString()))
                e.Handled = true;

            // Minus only at start
            if (e.KeyChar == '-' && SelectionStart != 0)
                e.Handled = true;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            ClearError(); // remove error as user types
        }
    }
}
