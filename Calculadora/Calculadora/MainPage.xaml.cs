using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        #region [Atributos]
        private Double n1;

        private Double n2;

        private Double res;

        private int currentOperation;
        #endregion

        public MainPage()
        {
            InitializeComponent();

            btn0.Clicked += Btn0_Clicked;
            btn1.Clicked += Btn1_Clicked;
            btn2.Clicked += Btn2_Clicked;
            btn3.Clicked += Btn3_Clicked;
            btn4.Clicked += Btn4_Clicked;
            btn5.Clicked += Btn5_Clicked;
            btn6.Clicked += Btn6_Clicked;
            btn7.Clicked += Btn7_Clicked;
            btn8.Clicked += Btn8_Clicked;
            btn9.Clicked += Btn9_Clicked;
            btnDot.Clicked += BtnDot_Clicked;
            Equal.Clicked += Equal_Clicked;
            Sum.Clicked += Sum_Clicked;
            Sub.Clicked += Sub_Clicked;
            Mult.Clicked += Mult_Clicked;
            Div.Clicked += Div_Clicked;
            Clear.Clicked += Clear_Clicked;
            Delete.Clicked += Delete_Clicked;
        }

        #region [Métodos - Actions]
        private void Delete_Clicked(object sender, EventArgs e)
        {
            var x = firstLabel.Text;
            if (x.Length >= 1)
            {
                x = x.Substring(0, x.Length - 1);
                firstLabel.Text = x;
                return;
            }
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            firstLabel.Text = "";
            historyLabel.Text = "";
            n1 = 0; n2 = 0;
        }

        private void Div_Clicked(object sender, EventArgs e)
        {
            try
            {
                currentOperation = 1;
                if (n1 == 0)
                {
                    n1 = Convert.ToDouble(firstLabel.Text);
                    historyLabel.Text = firstLabel.Text + Div.Text;
                    firstLabel.Text = "";
                    return;
                }
                else
                {
                    n2 = Convert.ToDouble(firstLabel.Text);
                    Calculate(1, false);
                    historyLabel.Text = res.ToString() + Div.Text;
                    firstLabel.Text = "";
                    n1 = res;
                    n2 = 0;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.ToString(), "OK");
            }
        }

        private void Mult_Clicked(object sender, EventArgs e)
        {
            try
            {
                currentOperation = 2;
                if (n1 == 0)
                {
                    n1 = Convert.ToDouble(firstLabel.Text);
                    historyLabel.Text = firstLabel.Text + Mult.Text;
                    firstLabel.Text = "";
                    return;
                }
                else
                {
                    n2 = Convert.ToDouble(firstLabel.Text);
                    Calculate(2, false);
                    historyLabel.Text = res.ToString() + Mult.Text;
                    firstLabel.Text = "";
                    n1 = res;
                    n2 = 0;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.ToString(), "OK");
            }
        }

        private void Sub_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (firstLabel.Text.Length == 0)
                {
                    firstLabel.Text = Sub.Text;
                }
                else
                {
                    currentOperation = 4;
                    if (n1 == 0)
                    {
                        n1 = Convert.ToDouble(firstLabel.Text);
                        historyLabel.Text = firstLabel.Text + Sub.Text;
                        firstLabel.Text = "";
                        return;
                    }
                    else
                    {
                        n2 = Convert.ToDouble(firstLabel.Text);
                        Calculate(4, false);
                        historyLabel.Text = res.ToString() + Sub.Text;
                        firstLabel.Text = "";
                        n1 = res;
                        n2 = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.ToString(), "OK");
            }
        }

        private void Sum_Clicked(object sender, EventArgs e)
        {
            try
            {
                currentOperation = 3;
                if (n1 == 0)
                {
                    n1 = Convert.ToDouble(firstLabel.Text);
                    historyLabel.Text = firstLabel.Text + Sum.Text;
                    firstLabel.Text = "";
                    return;
                }
                else
                {
                    n2 = Convert.ToDouble(firstLabel.Text);
                    Calculate(3, false);
                    historyLabel.Text = res.ToString() + Sum.Text;
                    firstLabel.Text = "";
                    n1 = res;
                    n2 = 0;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.ToString(), "OK");
            }
        }

        private void Equal_Clicked(object sender, EventArgs e)
        {
            historyLabel.Text += Convert.ToString(n2);
            Calculate(currentOperation);
        }

        private void Calculate(int type = 0, bool equal = true)
        {
            switch (type)
            {
                case 1:
                    {
                        if (n2 != 0)
                        {
                            res = n1 / n2;
                        }
                        else
                        {
                            DisplayAlert("Erro", "Não é possível dividir por zero.", "OK");
                            Clear_Clicked(null, null);
                        }
                        break;
                    }

                case 2:
                    {
                        res = n1 * n2;
                        break;
                    }

                case 3:
                    {
                        res = n1 + n2;
                        break;
                    }
                case 4:
                    {
                        res = n1 - n2;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            if (equal)
            {
                firstLabel.Text = res.ToString();
            }
            n1 = 0; n2 = 0;
        }

        #endregion

        #region [Botões]

        private void BtnDot_Clicked(object sender, EventArgs e)
        {
            if (!firstLabel.Text.Contains('.'))
            {
                firstLabel.Text += btnDot.Text;
            }
        }

        private void Btn9_Clicked(object sender, EventArgs e)
        {
            if (firstLabel.Text != "0")
            {
                //SeparadorDeMilhar();
                if (n1 != 0)
                {
                    firstLabel.Text += btn9.Text;
                    n2 = Convert.ToDouble(firstLabel.Text);
                    //historyLabel.Text += btn9.Text;
                    //Calculate(3);
                    return;
                }
                firstLabel.Text += btn9.Text;
            }
            else
            {
                firstLabel.Text = btn9.Text;
            }
        }

        private void Btn8_Clicked(object sender, EventArgs e)
        {
            if (firstLabel.Text != "0")
            {
                //SeparadorDeMilhar();
                if (n1 != 0)
                {
                    firstLabel.Text += btn8.Text;
                    n2 = Convert.ToDouble(firstLabel.Text);
                    //historyLabel.Text += btn8.Text;
                    //Calculate(3);
                    return;
                }
                firstLabel.Text += btn8.Text;
            }
            else
            {
                firstLabel.Text = btn8.Text;
            }
        }

        private void Btn7_Clicked(object sender, EventArgs e)
        {
            if (firstLabel.Text != "0")
            {
                //SeparadorDeMilhar();
                if (n1 != 0)
                {
                    firstLabel.Text += btn7.Text;
                    n2 = Convert.ToDouble(firstLabel.Text);
                    //historyLabel.Text += btn7.Text;
                    //Calculate(3);
                    return;
                }
                firstLabel.Text += btn7.Text;
            }
            else
            {
                firstLabel.Text = btn7.Text;
            }
        }

        private void Btn6_Clicked(object sender, EventArgs e)
        {
            if (firstLabel.Text != "0")
            {
                //SeparadorDeMilhar();
                if (n1 != 0)
                {
                    firstLabel.Text += btn6.Text;
                    n2 = Convert.ToDouble(firstLabel.Text);
                    //historyLabel.Text += btn6.Text;
                    //Calculate(3);
                    return;
                }
                firstLabel.Text += btn6.Text;
            }
            else
            {
                firstLabel.Text = btn6.Text;
            }
        }

        private void Btn5_Clicked(object sender, EventArgs e)
        {
            if (firstLabel.Text != "0")
            {
                //SeparadorDeMilhar();
                if (n1 != 0)
                {
                    firstLabel.Text += btn5.Text;
                    n2 = Convert.ToDouble(firstLabel.Text);
                    //historyLabel.Text += btn5.Text;
                    //Calculate(3);
                    return;
                }
                firstLabel.Text += btn5.Text;
            }
            else
            {
                firstLabel.Text = btn5.Text;
            }
        }

        private void Btn4_Clicked(object sender, EventArgs e)
        {
            if (firstLabel.Text != "0")
            {
                //SeparadorDeMilhar();
                if (n1 != 0)
                {
                    firstLabel.Text += btn4.Text;
                    n2 = Convert.ToDouble(firstLabel.Text);
                    //historyLabel.Text += btn4.Text;
                    //Calculate(3);
                    return;
                }
                firstLabel.Text += btn4.Text;
            }
            else
            {
                firstLabel.Text = btn4.Text;
            }
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            if (firstLabel.Text != "0")
            {
                //SeparadorDeMilhar();
                if (n1 != 0)
                {
                    firstLabel.Text += btn3.Text;
                    n2 = Convert.ToDouble(firstLabel.Text);
                    //historyLabel.Text += btn3.Text;
                    //Calculate(3);
                    return;
                }
                firstLabel.Text += btn3.Text;
            }
            else
            {
                firstLabel.Text = btn3.Text;
            }
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            if (firstLabel.Text != "0")
            {
                //SeparadorDeMilhar();
                if (n1 != 0)
                {
                    firstLabel.Text += btn2.Text;
                    n2 = Convert.ToDouble(firstLabel.Text);
                    //historyLabel.Text += btn2.Text;
                    //Calculate(currentOperation);
                    return;
                }
                firstLabel.Text += btn2.Text;
            }
            else
            {
                firstLabel.Text = btn2.Text;
            }
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            if (firstLabel.Text != "0")
            {
                //SeparadorDeMilhar();
                if (n1 != 0)
                {
                    firstLabel.Text += btn1.Text;
                    n2 = Convert.ToDouble(firstLabel.Text);
                    //historyLabel.Text += btn1.Text;
                    //Calculate(3);
                    return;
                }
                firstLabel.Text += btn1.Text;
            }
            else
            {
                firstLabel.Text = btn1.Text;
            }
        }

        private void Btn0_Clicked(object sender, EventArgs e)
        {
            if (firstLabel.Text != "0")
            {
                //SeparadorDeMilhar();
                if (n1 != 0)
                {
                    firstLabel.Text += btn0.Text;
                    n2 = Convert.ToDouble(firstLabel.Text);
                    //historyLabel.Text += btn0.Text;
                    //Calculate(3);
                    return;
                }
                firstLabel.Text += btn0.Text;
            }
            else
            {
                firstLabel.Text = btn0.Text;
            }
        }

        #endregion

        private void SeparadorDeMilhar()
        {
            //if (!firstLabel.Text.Contains('.'))
            //{
            //    if(firstLabel.Text.Count() >= 3)
            //    {
            //        var x = firstLabel.Text.Substring(3, firstLabel.Text.Length);
            //        return;
            //    }
            //}
        }
    }
}
