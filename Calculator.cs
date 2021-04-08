using System;
using System.Collections.Generic;
using System.Text;

namespace Cv9
{
    class Calculator
    {
        public String Display { get; set; }
        public String Memory { get; set; }
        private enum Stav
        {
            PrvniCislo,
            Operace,
            DruheCislo,
            Vysledek
        };
        private Stav _stav = Stav.PrvniCislo;

        public double A { get; private set;  }
        public double B { get; private set;  }
        public double Vys { get; private set; }

        private string op;
        private string num;

        public void Button(String btn)
        {
            if (Convert.ToChar(btn[0]) <= Convert.ToChar("9") && Convert.ToChar(btn[0]) >= Convert.ToChar("0"))
            {
                num += btn;
            }

            switch (btn)
            {
               case ",":
                    if(num.Contains(",") == false)
                    {
                        num += btn;
                    }
                    break;

                case "+":
                    _stav = Stav.Operace;
                    op = "+";
                    break;
                case "-":
                    _stav = Stav.Operace;
                    op = "-";
                    break;
                case "*":
                    _stav = Stav.Operace;
                    op = "*";
                    break;
                case "/":
                    _stav = Stav.Operace;
                    op = "/";
                    break;
                case "x^2":
                    op = "x^2";
                    _stav = Stav.Operace;
                    break;

                case "=":
                    if (_stav != Stav.PrvniCislo)
                    {
                        _stav = Stav.Vysledek;
                    }
                    break;

                case "<-":
                    if (num.Equals("") == false)
                    {
                        num = num.Substring(0, num.Length - 1);
                        Display = num;
                    }
                    break;

                case "MS":
                    if (num.Equals(""))
                    {
                        Memory = Convert.ToString(Vys);
                    }
                    else
                    {
                        Memory = num;
                    }
                    num = "";
                    Display = num;
                    break;
                case "M+":
                    Memory = Convert.ToString(Convert.ToDouble(Memory) + Convert.ToDouble(num));
                    break;
                case "M-":
                    Memory = Convert.ToString(Convert.ToDouble(Memory) - Convert.ToDouble(num));
                    break;
                case "MC":
                    Memory = "";
                    break;
                case "MR":
                    Display = Memory;
                    num = Memory;
                    break;

                case "CE":
                    num = "";
                    Display = num;
                    break;
                case "C":
                    num = "";
                    A = 0;
                    B = 0;
                    Display = num;
                    _stav = Stav.PrvniCislo;
                    break;
            }

            switch (_stav)
            {
                case Stav.PrvniCislo:
                    Display = num;
                    break;

                case Stav.DruheCislo:
                    Display = num;
                    break;

                case Stav.Operace:
                    
                    if (num.Equals(""))
                    {
                        A = Vys;
                    }

                    else
                    {
                        A = Convert.ToDouble(num);
                        num = "";
                    }

                    Display = Convert.ToString(A) + op;
                    
                    if (op == "x^2")
                    {
                        _stav = Stav.Vysledek;
                        goto mocnina;
                    }

                    else
                    {
                        _stav = Stav.DruheCislo;
                    }

                    break;

                case Stav.Vysledek:
                
                mocnina:
                    if (num.Equals("") == false)
                    {
                        B = Convert.ToDouble(num);
                        num = "";
                    }

                    switch (op)
                    {
                        case "+":
                            Vys = A + B;
                            break;
                        case "-":
                            Vys = A - B;
                            break;
                        case "*":
                            Vys = A * B;
                            break;
                        case "/":
                            if(B != 0)
                            {
                                Vys = A / B;
                            }
                            else
                            {
                                Vys = 0;
                            }
                            break;
                        case "x^2":
                            Vys = A * A;
                            break;
                    }

                    if(B == 0 && op == "/")
                    {
                        Display = "Nulou se nedá dělit";
                    }
                    else
                    {
                        Display = Convert.ToString(Vys);
                    }

                    _stav = Stav.PrvniCislo;
                    break;
            }
        } 
    }
}
