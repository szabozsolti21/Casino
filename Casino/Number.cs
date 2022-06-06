using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Number
    {

        public int Value;

        public string Parity; // 0 : Z , páros: 0 , páratlan: 1
        public string Half;   // 0 : Z , 1-18 : 0 , 19-36 : 1 
        public string Column; // 0 : Z , %3=1 : P , %3=2 : M , %3=0 : D
        public string Dozen;  // 0 : Z , 1-12 : 0 , 13-24 : 1 , 25-36 : 2
        public string Color;  // Zöld : Z , Fekete: 0 , Piros: 1

        public Number(int r)
        {
            this.Value = r;
            SetParity(r);
            SetColumn(r);
            SetHalf(r);
            SetDozen(r);
            SetColor(r);
        }

        private void SetParity(int r)
        {
            if(r == 0) this.Parity = "PZ";
            if(r % 2 == 0 && r != 0) this.Parity = "P0";
            if(r % 2 == 1) this.Parity = "P1";
        }

        private void SetColumn(int r)
        {
            if (r == 0) this.Column = "CZ";
            if (r % 3 == 1) this.Column = "CP";
            if (r % 3 == 2) this.Column = "CM";
            if (r % 3 == 0) this.Column = "CD";
        }
        private void SetHalf(int r)
        {
            if(r == 0) this.Half = "HZ";
            if(r <= 18 && r > 0) this.Half = "H1";
            if(r <= 36 && r >= 19) this.Half = "H2";
        }

        private void SetDozen(int r)
        {
            if(r == 0) this.Dozen = "DZ";
            if(r <= 12 && r > 0) this.Dozen = "D1";
            if(r <= 24 && r >= 13) this.Dozen = "D2";
            if(r <= 36 && r >= 25) this.Dozen = "D3";
        }

        private void SetColor(int r)
        {
            int[] black = { 15, 4, 2, 17, 6, 13, 11, 8, 10, 24, 33, 20, 31, 22, 29, 28, 35, 26 };
            int[] red = { 32, 19, 21, 25, 34, 27, 36, 30, 23, 5, 16, 1, 14, 9, 18, 7, 12, 3 };

            if (r == 0) this.Color = "CoZ";
            if(black.Contains(r)) this.Color = "CoF";
            if (red.Contains(r)) this.Color = "CoP";
        }
        

        public String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"A szám:\tértéke: {this.Value}\n" +
                            $"\tparitása: {this.Parity}\n"+
                            $"\toszlopa: {this.Column}\n"+
                            $"\tfél: {this.Half}\n"+
                            $"\ttucat: {this.Dozen}\n"+
                            $"\tszín: {this.Color}\n"
                            );

            return sb.ToString();
        }

        public String ToFormattedString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"A szám:\tértéke: {this.Value}\n");

            if(this.Value == 0)
            {
                sb.Append("\t-Zöld");
            }
            else
            {
                if (this.Parity == "P0") sb.Append("\t-Páros\n");
                if (this.Parity == "P1") sb.Append("\t-Páratlan\n");

                if (this.Column == "CP") sb.Append("\t-Premier\n");
                if (this.Column == "CM") sb.Append("\t-Moyen\n");
                if (this.Column == "CD") sb.Append("\t-Dernier\n");

                if (this.Half == "H1") sb.Append("\t-Első fél\n");
                if (this.Half == "H2") sb.Append("\t-Második fél\n");

                if (this.Dozen == "D1") sb.Append("\t-Első tucat\n");
                if (this.Dozen == "D2") sb.Append("\t-Második tucat\n");
                if (this.Dozen == "D3") sb.Append("\t-Harmadik tucat\n");

                if (this.Color == "CoP") sb.Append("\t-Piros\n");
                if (this.Color == "CoF") sb.Append("\t-Fekete\n");
            }

            return sb.ToString();
        }
    }
}
