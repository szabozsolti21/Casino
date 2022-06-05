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
            if(r == 0) this.Parity = "Z";
            if(r % 2 == 0 && r != 0) this.Parity = "0";
            if(r % 2 == 1) this.Parity = "1";
        }

        private void SetHalf(int r)
        {
            if(r == 0) this.Half = "Z";
            if(r <= 18 && r > 0) this.Half = "1";
            if(r <= 36 && r >= 19) this.Half = "2";
        }

        private void SetColumn(int r)
        {
            if(r == 0) this.Column = "Z";
            if(r % 3 == 1) this.Column = "P";
            if(r % 3 == 2) this.Column = "M";
            if(r % 3 == 0) this.Column = "D";
        }

        private void SetDozen(int r)
        {
            if(r == 0) this.Dozen = "Z";
            if(r <= 12 && r > 0) this.Dozen = "1";
            if(r <= 24 && r >= 13) this.Dozen = "2";
            if(r <= 36 && r >= 25) this.Dozen = "3";
        }

        private void SetColor(int r)
        {
            int[] black = { 15, 4, 2, 17, 6, 13, 11, 8, 10, 24, 33, 20, 31, 22, 29, 28, 35, 26 };
            int[] red = { 32, 19, 21, 25, 34, 27, 36, 30, 23, 5, 16, 1, 14, 9, 18, 7, 12, 3 };

            if (r == 0) this.Color = "Z";
            if(black.Contains(r)) this.Color = "F";
            if (red.Contains(r)) this.Color = "P";
        }
        

        public String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"A szám: {this.Value}\n" +
                            $"\tparitása: {this.Parity}\n"+
                            $"\toszlopa: {this.Column}\n"+
                            $"\tfél: {this.Half}\n"+
                            $"\ttucat: {this.Dozen}\n"+
                            $"\tszín: {this.Color}\n"
                            );


            return sb.ToString();
        }


    }
}
