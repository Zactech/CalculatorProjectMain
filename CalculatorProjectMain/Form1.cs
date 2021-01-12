using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorProjectMain
{
    public partial class StandardCalculator : Form
    {
        bool enter_value = false;
        double result =0;
        string operation = "";
        public StandardCalculator()
        {
            InitializeComponent();
        }

        private void BtnNum(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if ((textDisplay.Text == "0") || (enter_value))
                textDisplay.Text = "";
            enter_value = false;

            if (b.Text == ".")
            {
                if (!textDisplay.Text.Contains("."))
                    textDisplay.Text += b.Text;
            }
            else
            {
                textDisplay.Text += b.Text;
            }
        }

        private void BtnArithmetic(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (result != 0)
            {
                btnResult.PerformClick();
                enter_value = true;
                operation = b.Text;
            }
            else
            {
                operation = b.Text;
                result = Double.Parse(textDisplay.Text);
                enter_value = true;
            }

        }

        private void btnResult_Click(object sender, EventArgs e)
        {
           switch (operation)
            {
                case "+":
                    textDisplay.Text = (result + Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "-":
                    textDisplay.Text = (result - Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "X":
                    textDisplay.Text = (result * Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "/":
                    textDisplay.Text = (result / Double.Parse(textDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(textDisplay.Text);
            operation = "";
        }
        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (textDisplay.Text.Length > 0)
            {
                textDisplay.Text = textDisplay.Text.Remove(textDisplay.Text.Length - 1, 1);
            }
            if (textDisplay.Text == "")
            {
                textDisplay.Text = "0";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textDisplay.Text = "0";
            result = 0;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            textDisplay.Clear();
            textDisplay.Text = "0";
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double sq = Double.Parse(textDisplay.Text);
            sq = Math.Sqrt(sq);
            textDisplay.Text = System.Convert.ToString(sq);
        }

        private void btnFract_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(1.0 / Convert.ToDouble(textDisplay.Text));
            textDisplay.Text = System.Convert.ToString(a);

        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(textDisplay.Text) / Convert.ToDouble(100);
            textDisplay.Text = System.Convert.ToString(a);
        }

        private void btnSignChange_Click(object sender, EventArgs e)
        {
            if (textDisplay.Text.Contains("-"))
                textDisplay.Text = textDisplay.Text.Remove(0, 1);
            else
                textDisplay.Text = "-" + textDisplay.Text;
        }
    }
}
