using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        string first_number = "";
        string second_number = "";
        int current_operation = -1;
        bool first_comma = false;
        bool second_comma = false;
        enum Operation
        {
            ADD,
            SUB,
            MUL,
            DIV,
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SetResult(double result)
        {
            first_number = Convert.ToString(result);
            second_number = "";
            current_operation = -1;
        }

        private void SetResultError()
        {
            first_number = "ERROR";
            second_number = "";
            current_operation = -1;
        }

        private void OnCommaClick(System.Windows.Forms.Button button)
        {

            if (current_operation != -1)
            {
                if (second_comma == true)
                    return;
                if (second_number == "")
                    second_number = "0";
                second_number += button.Text;
                second_comma = true;
            }
            else
            {
                if (first_comma == true)
                    return;
                if (first_number == "ERROR" || second_number == "")
                    first_number = "0";
                first_number += button.Text;
                first_comma = true;
            }
        }

        private void OnEqClick(System.Windows.Forms.Button button)
        {
            double result = 0;
            switch (current_operation)
            {
                case (int)Operation.ADD:
                    result = Convert.ToDouble(first_number) + Convert.ToDouble(second_number);
                    SetResult(result);
                    break;
                case (int)Operation.SUB:
                    result = Convert.ToDouble(first_number) - Convert.ToDouble(second_number);
                    SetResult(result);
                    break;
                case (int)Operation.MUL:
                    result = Convert.ToDouble(first_number) * Convert.ToDouble(second_number);
                    SetResult(result);
                    break;
                case (int)Operation.DIV:
                    if (Convert.ToDouble(second_number) == .0)
                    {
                        SetResultError();
                    }
                    else
                    {
                        result = Convert.ToDouble(first_number) / Convert.ToDouble(second_number);
                        SetResult(result);
                    }
                    break;
            }
            if (first_number.IndexOf(',') != -1)
            {
                first_comma = false;
            }
            second_comma = false;
        }

        private void OnButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            if ("1234567890".IndexOf(button.Text[0]) != -1)
            {
                if (current_operation != -1)
                {
                    second_number += button.Text;
                }
                else
                {
                    if (first_number == "ERROR")
                    {
                        first_number = "";
                    }
                    first_number += button.Text;
                }

            }
            else if ("+-*/".IndexOf(button.Text[0]) != -1)
            {
                if (second_number != "")
                {
                    OnEqClick(button);
                }
                current_operation = "+-*/".IndexOf(button.Text[0]);
            }
            else if (button.Text == "=")
            {
                OnEqClick(button);
            }
            else if (button.Text == "C")
            {
                if (second_number != "")
                {
                    second_number = "";
                }
                else
                {
                    current_operation = -1;
                    first_number = "";
                }
            }
            else if (button.Text == "AC")
            {
                first_number = "";
                second_number = "";
                current_operation = -1;
            }
            else if (button.Text == ",")
                OnCommaClick(button);

            if (current_operation != -1 && second_number != "")
            {
                this.textBox1.Text = second_number;
            }
            else
            {
                this.textBox1.Text = first_number;
            }
        }
    }
}
