using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator {
    public class Math2 {


        public double eval(String expression, Boolean deg) {
            if(expression.Equals("") ||
               expression[expression.Length - 1] == '+' ||
               expression[expression.Length - 1] == '-' ||
               expression[expression.Length - 1] == '*' ||
               expression[expression.Length - 1] == '^' ||
               expression[expression.Length - 1] == '/')
                throw new System.Exception();

            List<String> list = new List<String>();
            String izraz = "";
            char[] c = expression.ToCharArray();
            int l = c.Length;

            for(int i = 0; i < l; ++i) {
                if(i == 0 && c[i] == '-')
                    izraz = izraz + "-"; //minus na pocetku
                else if(i == 0 && c[i] == '+')
                    izraz = izraz + "+";
                else if(i != 0 && c[i - 1] >= '0' && c[i - 1] <= '9' && c[i] == 'e')
                    izraz = izraz + "E"; //znanstveni zapis
                else if(i != 0 && c[i - 1] == 'e' && c[i] == '-')
                    izraz = izraz + "-"; //negativan eksponent
                else if(c[i] >= '0' && c[i] <= '9' || c[i] == '.')
                    izraz = izraz + c[i]; //broj
                else {
                    if(!izraz.Equals(""))
                        list.Add(izraz);
                    izraz = "";

                    if(c[i] == '(') {
                        String izraz2 = "";

                        //find last close')'
                        int x = c.Length - 1, opened = 0, y;
                        for(y = i + 1; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 1; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez = eval(izraz2, deg);
                        list.Add(pomRez.ToString());
                    }

                    //Functions				
                    //Abs
                    else if(c[i] == 'A' && c[i + 1] == 'b' && c[i + 2] == 's' && c[i + 3] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 4; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 4; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez = Math.Abs(eval(izraz2, deg));

                        list.Add(pomRez.ToString());
                    }

                    //Fact
                    else if(c[i] == 'f' && c[i + 1] == 'a' && c[i + 2] == 'c' && c[i + 3] == 't' && c[i + 4] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 5; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 5; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez = Math.Abs(Math.Round(eval(izraz2, deg)));
                        if(pomRez < 250)
                            pomRez = fact(pomRez);
                        else
                            throw new Exception();

                        list.Add(pomRez.ToString());
                    }

                    //sin
                    else if(i + 2 < l && c[i] == 's' && c[i + 1] == 'i' && c[i + 2] == 'n' && c[i + 3] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 4; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 4; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez;
                        if(deg)
                            pomRez = Math.Sin(toRadians(eval(izraz2, deg)));
                        else
                            pomRez = Math.Sin(eval(izraz2, deg));

                        list.Add(pomRez.ToString());

                        //cos
                    } else if(i + 2 < l && c[i] == 'c' && c[i + 1] == 'o' && c[i + 2] == 's' && c[i + 3] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 4; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 4; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez;
                        if(deg)
                            pomRez = Math.Cos(toRadians(eval(izraz2, deg)));
                        else
                            pomRez = Math.Cos(eval(izraz2, deg));
                        list.Add(pomRez.ToString());
                    }

                     //tan
                     else if(i + 2 < l && c[i] == 't' && c[i + 1] == 'a' && c[i + 2] == 'n' && c[i + 3] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 4; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 4; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez;
                        if(deg)
                            pomRez = Math.Tan(toRadians(eval(izraz2, deg)));
                        else
                            pomRez = Math.Tan(eval(izraz2, deg));
                        list.Add(pomRez.ToString());
                    }

                     //asin
                     else if(i + 3 < l && c[i] == 'a' && c[i + 1] == 's' && c[i + 2] == 'i' && c[i + 3] == 'n' && c[i + 4] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 5; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 5; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez;
                        if(deg)
                            pomRez = toDegrees(Math.Asin(eval(izraz2, deg)));
                        else
                            pomRez = Math.Asin(eval(izraz2, deg));
                        list.Add(pomRez.ToString());
                    }

                     //acos
                     else if(i + 3 < l && c[i] == 'a' && c[i + 1] == 'c' && c[i + 2] == 'o' && c[i + 3] == 's' && c[i + 4] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 5; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 5; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez;
                        if(deg)
                            pomRez = toDegrees(Math.Acos(eval(izraz2, deg)));
                        else
                            pomRez = Math.Acos(eval(izraz2, deg));
                        list.Add(pomRez.ToString());
                    }

                     //atan
                     else if(i + 3 < l && c[i] == 'a' && c[i + 1] == 't' && c[i + 2] == 'a' && c[i + 3] == 'n' && c[i + 4] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 5; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 5; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez;
                        if(deg)
                            pomRez = toDegrees(Math.Atan(eval(izraz2, deg)));
                        else
                            pomRez = Math.Atan(eval(izraz2, deg));
                        list.Add(pomRez.ToString());
                    }

                     //sqrt1
                     else if(i + 4 < l && c[i] == 's' && c[i + 1] == 'q' && c[i + 2] == 'r' && c[i + 3] == 't' && c[i + 4] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 5; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 5; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez = Math.Sqrt(eval(izraz2, deg));
                        list.Add(pomRez.ToString());
                    }

                     //sqrt2
                     else if(c[i] == 8730 && c[i + 1] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 2; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 2; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez = Math.Sqrt(eval(izraz2, deg));
                        list.Add(pomRez.ToString());
                    }

                     //ln
                     else if(i + 1 < l && c[i] == 'l' && c[i + 1] == 'n' && c[i + 2] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 3; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 3; i < y; ++i)
                            izraz2 = izraz2 + c[i];
                        double pomRez = Math.Log(eval(izraz2, deg));
                        list.Add(pomRez.ToString());
                    }

                     //Log
                     else if(c[i] == 'l' && c[i + 1] == 'o' && c[i + 2] == 'g' && c[i + 3] == '[') {
                        String izraz2 = "";
                        String log_base = "";
                        int x = c.Length - 1, y, opened = 0, baseC = 0;

                        for(i = i + 4; c[i] != ']'; ++i) {
                            ++baseC;
                            log_base = log_base + c[i];
                        }
                        if(baseC == 0)
                            log_base = "10";

                        for(y = i + 2; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 2; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez = Math.Log10(eval(izraz2, deg)) / Math.Log10(Double.Parse(log_base, System.Globalization.CultureInfo.InvariantCulture));

                        list.Add(pomRez.ToString());
                    }


                    //diff
                    else if(c[i] == 'd' && c[i + 1] == '/' && c[i + 2] == 'd' && c[i + 3] == 'x') {
                        //        d/dx[1](X^(2)+5*X)

                        String funkcija = "";
                        String x0 = "";

                        int p = i + 5;
                        while(c[p] != ']') {
                            x0 = x0 + c[p];
                            ++p;
                        }


                        p = p + 2;
                        int z = 1, k = p;
                        for(; z != 0; ++k) {
                            if(c[k] == ')')
                                --z;
                            else if(c[k] == '(')
                                ++z;

                            funkcija = funkcija + c[k];
                        }
                        funkcija = "(" + funkcija;

                        double? dx0 = Convert.ToDouble(x0) + 0.00000000000001;
                        String pomIzraz = funkcija.Replace("X", x0);
                        String pomIzraz2 = funkcija.Replace("X", "" + String.Format("{0:N30}", dx0.Value)).Replace(',', '.');

                        //double x = 0.00000000000001;
                        //String y = String.Format("{0:N30}", x.Value);

                        double ddx = (eval(pomIzraz2, deg) - eval(pomIzraz, deg)) / 0.00000000000001;

                        i = k;

                        String rez = "" + ddx;
                        list.Add(rez.ToString().Replace(',', '.'));
                    }

                     //upTo
                     else if(c[i] == '^' && c[i + 1] == '(') {
                        String izraz2 = "";

                        int x = c.Length - 1, y, opened = 0;
                        for(y = i + 2; y < x; ++y) {

                            if(c[y] == ')') {
                                --opened;
                                if(opened == -1)
                                    break;
                            } else if(c[y] == '(')
                                ++opened;
                        }

                        for(i = i + 2; i < y; ++i)
                            izraz2 = izraz2 + c[i];

                        double pomRez = eval(izraz2, deg);
                        list.Add("^");
                        list.Add(pomRez.ToString());
                    }



                     //Basic operators
                     else if(c[i] == '+' || c[i] == '-' || c[i] == '*' || c[i] == '/')
                        list.Add("" + c[i]);
                    else
                        throw new Exception();
                }
            }
            if(!izraz.Equals(""))
                list.Add(izraz);

            //UpTo
            int n = list.Count;
            while(list.Contains("^")) {
                for(int j = 0; j < n; ++j) {
                    if(list[j].Equals("^")) {
                        double num1 = Double.Parse(list[j - 1], System.Globalization.CultureInfo.InvariantCulture);
                        double num2 = Double.Parse(list[j + 1], System.Globalization.CultureInfo.InvariantCulture);
                        double rez = Math.Pow(num1, num2);

                        list[j - 1] = rez.ToString();
                        list.RemoveAt(j);
                        j = j - 1;
                        list.RemoveAt(j + 1);

                        n = list.Count;
                    }
                }
            }

            //Mull and div
            while(list.Contains("*") || list.Contains("/")) {
                for(int j = 0; j < n; ++j) {
                    if(list[j].Equals("*") || list[j].Equals("/")) {
                        double num1 = Double.Parse(list[j - 1], System.Globalization.CultureInfo.InvariantCulture);
                        double num2 = Double.Parse(list[j + 1], System.Globalization.CultureInfo.InvariantCulture);
                        double rez;

                        if(list[j].Equals("*"))
                            rez = num1 * num2;
                        else
                            rez = num1 / num2;

                        list[j - 1] = rez.ToString();
                        list.RemoveAt(j);
                        j = j - 1;
                        list.RemoveAt(j + 1);

                        n = list.Count;
                    }
                }
            }

            //Add and sub
            while(list.Contains("+") || list.Contains("-")) {
                for(int k = 0; k < n - 1; ++k) {
                    if(list[k].Equals("+") || list[k].Equals("-")) {
                        double num1 = Double.Parse(list[k - 1], System.Globalization.CultureInfo.InvariantCulture);
                        double num2 = Double.Parse(list[k + 1], System.Globalization.CultureInfo.InvariantCulture);
                        double rez;

                        if(list[k].Equals("+"))
                            rez = num1 + num2;
                        else
                            rez = num1 - num2;

                        list[k - 1] = rez.ToString();
                        list.RemoveAt(k);
                        k = k - 1;
                        list.RemoveAt(k + 1);

                        n = list.Count;
                    }
                }
            }

            return Double.Parse(list[0], System.Globalization.CultureInfo.InvariantCulture);
        }


        private static double fact(double n) {
            if(n == 0)
                return 1;
            else
                return n * fact(n - 1);
        }

        private static double toRadians(double deg) {
            return (Math.PI / 180) * deg;
        }

        private static double toDegrees(double rad) {
            return (180 / Math.PI) * rad;
        }


    }
}

