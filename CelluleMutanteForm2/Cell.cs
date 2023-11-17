using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelluleMutanteForm2
{
    public class Cell
    {
        public int _size;
        public Color _color;
        public List<string> _genetic = new List<string>() { "TGT", "ATT", "CTC", "ACT", "GTC", "GAA" };
        string _adn = "GAA";
        int nb_T = 0;

        public Cell()
        {
            this._size = 10;
            this._color = Color.Black;
            this._genetic = new List<string>() { "TGT", "ATT", "CTC", "ACT", "GTC", "GAA" };
        }

        public void Mutation()
        {
            Random random = new Random();
            string newgeneration = "";

            List<string> acgt = new List<string>() { "A", "C", "G", "T" };

            for (int j = 0; j < _adn.Length; j++)
            {
                switch (_adn[j].ToString())
                {
                    case "A":
                        newgeneration += (random.NextDouble() < 0.15) ? "T" : "A";
                        break;
                    case "T":
                        newgeneration += (random.NextDouble() < 0.07) ? "AA" : "T";
                        break;
                    case "C":
                        newgeneration += (random.NextDouble() < 0.21) ? "G" : "C";
                        break;
                    case "G":
                        newgeneration += (random.NextDouble() < 0.04) ? "CG" : "G";
                        break;

                }
                if (_adn[j] == 'T')
                        nb_T++;

                if (random.NextDouble() < 0.05)
                {
                newgeneration += (acgt[random.Next(4)]);
                         
                }
                
            }

            _adn = newgeneration;

            UpdateSize();
            UpdateColor();
            Console.WriteLine(_adn);
        }
         
        public void UpdateSize()
        {
            _size = 10 + (int)_adn.Length/5 + Math.Min(nb_T, _size);
        }
        public void UpdateColor()
        {
            _color = MaxOccureColor();
           
        }
        private Color MaxOccureColor()
        {
            if (this._adn.Length < 3)
            {
                return Color.Black;
            }

            (Color, string, int) black = (Color.Black, "TGT", 0);
            (Color, string, int) blue = (Color.Blue, "ATT", 0);
            (Color, string, int) yellow = (Color.Yellow, "CTC", 0);
            (Color, string, int) purple = (Color.MediumPurple, "ACT", 0);
            (Color, string, int) orange = (Color.Orange, "GTC", 0);
            (Color, string, int) green = (Color.SeaGreen, "GAA", 0);



            for (int i = 0; i < this._adn.Length - 2; i++)
            {
                string codes = $"{_adn[i]}{_adn[i + 1]}{_adn[i + 2]}";
                Console.WriteLine(codes);

                switch (codes)
                {
                    case "TGT":
                        black.Item3++;
                        break;
                    case "ATT":
                        blue.Item3++;
                        break;
                    case "CTC":
                        yellow.Item3++;
                        break;
                    case "ACT":
                        purple.Item3++;
                        break;
                    case "GTC":
                        orange.Item3++;
                        break;
                    case "GAA":
                        green.Item3++;
                        break;
                }
            }

            List<(Color, string, int)> colorsOccured = new List<(Color, string, int)>()
            { black, blue, yellow, purple, orange, green };

            colorsOccured = colorsOccured.OrderBy(i => -i.Item3).ToList();

            Console.WriteLine(colorsOccured[0].Item1);
            Console.WriteLine(colorsOccured[0].Item3);
            Console.WriteLine(colorsOccured[1].Item1);
            Console.WriteLine(colorsOccured[1].Item3);
            Console.WriteLine(colorsOccured[2].Item1);
            Console.WriteLine(colorsOccured[2].Item3);

            return colorsOccured[0].Item1;
        }
    }
}
