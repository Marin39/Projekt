using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Kalkulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page{

        double ans = 0;
        bool deg;
        Math2 m2 = new Math2();


        public MainPage()
        {
            
            this.InitializeComponent();
        }


        public void buttonClick(object sender, RoutedEventArgs e) {
            Button btn = (Button)sender;

            displayTextBox.Focus(FocusState.Pointer);

            if(displayTextBox.Text.Equals("0"))
                displayTextBox.Text = "";

            //Purple buttons
            if(btn.Name == "buttonLeft" && displayTextBox.SelectionStart != 0)
                displayTextBox.SelectionStart = displayTextBox.SelectionStart - 1;
            else if(btn.Name == "buttonRight")
                displayTextBox.SelectionStart = displayTextBox.SelectionStart + 1;

            //Yellow buttons
            else if(btn.Name == "button0")
                insert("0");
            else if(btn.Name == "button1")
                insert("1");
            else if(btn.Name == "button2")
                insert("2");
            else if(btn.Name == "button3")
                insert("3");
            else if(btn.Name == "button4")
                insert("4");
            else if(btn.Name == "button5")
                insert("5");
            else if(btn.Name == "button6")
                insert("6");
            else if(btn.Name == "button7")
                insert("7");
            else if(btn.Name == "button8")
                insert("8");
            else if(btn.Name == "button9")
                insert("9");
            else if(btn.Name == "buttonPoint")
                insert(".");
            else if(btn.Name == "buttonEquals") {
                Math2 m2 = new Math2();
                //  bool deg = buttonDegRad.;

                String expression = displayTextBox.Text;
                expression = expression.Replace("e", "2.71828182845904523536");
                expression = expression.Replace("π", "3.14159265358979323846");
                expression = expression.Replace("log10", "log[10]");
                expression = expression.Replace("Ans", "" + ans);
                expression = expression.Replace(",", ".");

                double result = m2.eval(expression, deg);
                displayTextBox.Text = "= " + result;
                ans = result;
            }

            //Green buttons
            else if(btn.Name == "buttonBopen")
                insert("(");
            else if(btn.Name == "buttonBclose")
                insert(")");
            else if(btn.Name == "buttonPlus")
                insert("+");
            else if(btn.Name == "buttonMinus")
                insert("-");
            else if(btn.Name == "buttonMull")
                insert("*");
            else if(btn.Name == "buttonDiv")
                insert("/");
            else if(btn.Name == "buttonXY")
                insert("^(");
            else if(btn.Name == "buttonSqrt")
                insert("√(");

            //Orange buttons
            else if(btn.Name == "buttonX1")
                insert("^(-1)");
            else if(btn.Name == "buttonX2")
                insert("^(2)");
            else if(btn.Name == "buttonX3")
                insert("^(3)");
            else if(btn.Name == "buttonAns")
                insert("Ans");
            else if(btn.Name == "buttonLn")
                insert("ln(");
            else if(btn.Name == "buttonLog")
                insert("log[](");
            else if(btn.Name == "buttonLog10")
                insert("log10(");
            else if(btn.Name == "button10x")
                insert("10^(");
            else if(btn.Name == "buttonEn")
                insert("e^(");
            else if(btn.Name == "buttonE")
                insert("e");
            else if(btn.Name == "buttonPi")
                insert("π");
            else if(btn.Name == "buttonFact")
                insert("fact(");
            else if(btn.Name == "buttonAbs")
                insert("Abs(");
            else if(btn.Name == "buttonMod")
                insert("Mod(");
            else if(btn.Name == "buttonNsqrt")
                insert("^(4)");
            else if(btn.Name == "buttonDegRad") {
                deg = !deg;
                if(deg)
                    buttonDegRad.Content = "DEG";
                else
                    buttonDegRad.Content = "RAD";

            }

            //Red buttons
            else if(btn.Name == "buttonSin")
                insert("sin(");
            else if(btn.Name == "buttonCos")
                insert("cos(");
            else if(btn.Name == "buttonTan")
                insert("tan(");
            else if(btn.Name == "buttonAsin")
                insert("asin(");
            else if(btn.Name == "buttonAcos")
                insert("acos(");
            else if(btn.Name == "buttonAtan")
                insert("atan(");


            //Control buttons
            else if(btn.Name == "buttonDel") {
                int i = displayTextBox.SelectionStart;
                if(i < 1)
                    return;
                displayTextBox.Text = displayTextBox.Text.Remove(i - 1, 1);
                --i;
                displayTextBox.SelectionStart = i;
            } else if(btn.Name == "buttonClear")
                displayTextBox.Text = "";


        }

        private void insert(String value) {
            int i = displayTextBox.SelectionStart;
            displayTextBox.Text = displayTextBox.Text.Insert(i, value);
            i = i + value.Length;
            displayTextBox.SelectionStart = i;
        }

        private double eval(String input, Boolean deg) {
            Math2 m = new Math2();
            return m.eval(input, deg);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
}
