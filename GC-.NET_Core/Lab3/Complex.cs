using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Complex
    {
        public float ParteReala { get; set; }
        public float ParteImaginara { get; set; }

        public Complex(float parteReala = 0, float parteImaginara = 0)
        {
            ParteReala = parteReala;
            ParteImaginara = parteImaginara;
        }

        public static Complex operator + (Complex a, Complex b)
        {
            float pr = a.ParteReala + b.ParteReala;
            float pi = a.ParteImaginara + b.ParteImaginara;
            return new Complex(pr, pi);
        }

        public static Complex operator - (Complex a, Complex b)
        {
            float pr = a.ParteReala - b.ParteReala;
            float pi = a.ParteImaginara - b.ParteImaginara;
            return new Complex(pr, pi);
        }

        public static Complex operator * (Complex a, Complex b)
        {
            float pr = a.ParteReala * b.ParteReala - a.ParteImaginara * b.ParteImaginara;
            float pi = a.ParteReala * b.ParteImaginara + a.ParteImaginara * b.ParteReala;
            return new Complex(pr, pi);
        }

        public static Complex operator ^ (Complex a, int pow)
        {
            Complex result = new(1);
            for (int i = 0; i < pow; i++)
            {
                result *= a;
            }
            return result;
        }

        public string ToTrigonometricForm()
        {
            float rad = (float)Math.Sqrt(Math.Pow(ParteReala, 2) + Math.Pow(ParteImaginara, 2));
            float phi = (float)Math.Atan(ParteImaginara / ParteReala);

            string s = rad + " * (cos(" + phi + ") + sin(" + phi + "))";
            return s;
            //bool asignedPhi = false;
            //int k = 0;
            //if (a.ParteReala < 0)
            //{
            //    k = 1;
            //}
            //else if (a.ParteReala > 0)
            //{
            //    if (a.ParteImaginara >= 0)
            //    {
            //        k = 0;
            //    }
            //    else
            //    {
            //        k = 2;
            //    }
            //}
            //else
            //{
            //    if (a.ParteImaginara < 0)
            //    {
            //        phi = (float)Math.PI / 2;
            //    }
            //    else if (a.ParteImaginara < 0)
            //    {
            //        phi = (float)Math.PI * (3 / 2);
            //    }
            //    else
            //    {
            //        return "0";
            //    }
            //    asignedPhi = true;
            //}

            //if (!asignedPhi)
            //{
            //    phi = (float)(Math.Atan(a.ParteImaginara / a.ParteReala) + k * Math.PI);
            //}

        }

        public override string ToString()
        { 
            StringBuilder sb = new StringBuilder();
            if (ParteImaginara > 0)
            {
                sb.AppendFormat("{0:0.00} + {1:0.00}i", ParteReala, ParteImaginara);
            }
            else if (ParteImaginara < 0)
            {
                sb.AppendFormat("{0:0.00} - {1:0.00}i", ParteReala, Math.Abs(ParteImaginara));
            }
            else
            {
                sb.AppendFormat("{0:0.00}", ParteReala);
            }

            return sb.ToString();
        }
    }
}
