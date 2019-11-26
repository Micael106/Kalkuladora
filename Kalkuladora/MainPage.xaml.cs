using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kalkuladora
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        String operation;
        int n1, n2 = 0;
        int status = 0; // 0: primeiro numero ; 1: segundo número
        
        public MainPage()
        {
            InitializeComponent();

        }

        public void OnButtonTouch(Object sender, EventArgs _)
        {
            Button btn = (Button)sender;
            String val = btn.Text;

            if (IsOperator(val))
                OperatorHandle(val);
            else
                NumberHandle(val);
        }

        private void NumberHandle(String val) {
            int number = 0;
            
            if (this.status == 0)
            {
                number = int.Parse(n1.ToString() + val);
                n1 = number;
            }
            else
            {
                number = int.Parse(n2.ToString() + val);
                n2 = number;
            }

            ResultLabel.Text = Convert.ToString(number);
        }

        private void OperatorHandle(String rawOp)
        {
            if (IsMathOperator(rawOp))
                this.operation = rawOp;

            if (rawOp == "C")
            {
                ResultLabel.Text = "0";
                this.status = 0;
                this.n1 = 0;
                this.n2 = 0;
                return;

            }
            else if (rawOp == "=")
            {
                RunOperator();
            }
            
            this.status = 1;
        }


        private Boolean IsOperator(String rawOp)
        {
            return IsMathOperator(rawOp) || rawOp == "=" || rawOp == "C";
        }

        private Boolean IsMathOperator(String rawOp)
        {
            return rawOp == "+" || rawOp == "–" || rawOp == "×" || rawOp == "÷";
        }

        private void RunOperator()
        {
            int result = 0;
            switch (this.operation)
            {
                case "+":
                    result = n1 + n2;
                    break;
                case "–":
                    result = n1 - n2;
                    break;
                case "×":
                    result = n1 * n2;
                    break;
                case "÷":
                    result = n1 / n2;
                    break;
            }
            Console.WriteLine("{0} {1} {2} = {3}", n1, this.operation, n2, result);
            ResultLabel.Text = Convert.ToString(result);
            this.n1 = result;
            this.n2 = 0;
        }
    }
}
