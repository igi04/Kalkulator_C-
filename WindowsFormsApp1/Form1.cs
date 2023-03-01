using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public enum Operation
    {
        Dodawania,
        Odejmowanie,
        Mnozenie,
        Dzielenie,
        None
    }
    public partial class Form1 : Form
    {
     
        private string _firstValue;
        private string _secondValue;
        private Operation _obecnaOperacja = Operation.None;
        private bool _isTheResult = false;
        public Form1()
        {
            InitializeComponent();
            txt_1.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnClikBtnNumber(object sender, EventArgs e)
        {
            var clickedValue = (sender as Button).Text;
            if(txt_1.Text == "0")
            {
                txt_1.Text = string.Empty;
            }
            if (_isTheResult)
            {
                _isTheResult = false;
                txt_1.Text = string.Empty;
            }

            txt_1.Text += clickedValue;
            if(_obecnaOperacja != Operation.None)
            {
                _secondValue += clickedValue;
            }

        }

        private void OnButtonClickOperation(object sender, EventArgs e)
        {
            _firstValue = txt_1.Text;
            var opearation = (sender as Button).Text;
            txt_1.Text += $" {opearation} ";

           if(opearation == "+")
            {
                _obecnaOperacja = Operation.Dodawania;
            }

            if (opearation == "-")
            {
                _obecnaOperacja = Operation.Odejmowanie;
            }

            if (opearation == "*")
            {
                _obecnaOperacja = Operation.Mnozenie;
            }

            if (opearation == "/")
            {
                _obecnaOperacja = Operation.Dzielenie;
            }

            if (opearation == " ")
            {
                _obecnaOperacja = Operation.None;
            }
        }

        private void OnButtonClearOperation(object sender, EventArgs e)
        {
            txt_1.Text = string.Empty;
        }

        private void OnButtonEqualOperation(object sender, EventArgs e)
        {
            var firstNumber = double.Parse(_firstValue);
            var secondNumber = double.Parse(_secondValue);
            var result = 0d;
            switch (_obecnaOperacja)
            {
                case Operation.None:
                    result = firstNumber;
                    break;

                case Operation.Dodawania:
                    result = firstNumber + secondNumber;
                    break;

                case Operation.Odejmowanie:
                    result =  firstNumber -secondNumber;
                    break;

                case Operation.Mnozenie:
                    result = firstNumber *secondNumber;
                    break;

                case Operation.Dzielenie:
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("NIe dzielimy przez zero!");
                    }
                    result = firstNumber / secondNumber;
                    break;
            }

            txt_1.Text = result.ToString();
            _secondValue = string.Empty;
            _obecnaOperacja = Operation.None;
            _isTheResult = true;
        }
        }

}
