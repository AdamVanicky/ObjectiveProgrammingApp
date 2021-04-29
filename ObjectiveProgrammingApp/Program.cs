using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveProgrammingApp
{
    class Program
    {
        interface ILokalizovatelne
        {
            double X { get; set; }
            double Y { get; set; }
        }

        interface IProdejne
        {
            int Cena { get; set; }
            DateTime TK { get; set; }
        }

        class DopravniProstredek
        {
            public int MaximalniRychlost { get; set; }
            public int Dojezd { get; set; }
            public string Pohon { get; set; }

            public DopravniProstredek(int maxrychlost, int dojezd, string pohon)
            {
                MaximalniRychlost = maxrychlost;
                Dojezd = dojezd;
                Pohon = pohon;
            }
        }

        class Auto : DopravniProstredek, ILokalizovatelne, IProdejne, IComparable
        {
            private double x;
            public double X 
            {
                get
                {
                    return x;
                }
                set
                {
                    try
                    {
                        Convert.ToInt32(value);
                        x = value;
                    }
                    catch
                    {
                        throw new ArgumentException("Špatně zadaný argument!");
                    }
                } 
            }

            private double y;
            public double Y
            {
                get
                {
                    return y;
                }
                set
                {
                    try
                    {
                        Convert.ToInt32(value);
                        y = value;
                    }
                    catch
                    {
                        throw new ArgumentException("Špatně zadaný argument!");
                    }
                }
            }

            private int cena;
            public int Cena
            {
                get
                {
                    return cena;
                }
                set
                {
                    try
                    {
                        Convert.ToInt32(value);
                        cena = value;
                    }
                    catch
                    {
                        throw new ArgumentException("Špatně zadaný argument!");
                    }
                }
            }
            public DateTime TK { get; set; }

            public Auto(int maxrychlost, int dojezd, string pohon, double x, double y, int cena, DateTime tk) : base(maxrychlost, dojezd, pohon)
            {
                X = x;
                Y = y;
                Cena = cena;
                TK = tk;
            }

            public int CompareTo(object obj)
            {
                DopravniProstredek k = obj as DopravniProstredek;
                if (MaximalniRychlost > k.MaximalniRychlost)
                {
                    return 1;
                }
                else if (MaximalniRychlost < k.MaximalniRychlost)
                {
                    return -1;
                }
                else { return 0; }
            }
        }

        class Kolo: DopravniProstredek, ILokalizovatelne, IComparable
        {
            private double x;
            public double X
            {
                get
                {
                    return x;
                }
                set
                {
                    try
                    {
                        Convert.ToInt32(value);
                        x = value;
                    }
                    catch
                    {
                        throw new ArgumentException("Špatně zadaný argument!");
                    }
                }
            }

            private double y;
            public double Y
            {
                get
                {
                    return y;
                }
                set
                {
                    try
                    {
                        Convert.ToInt32(value);
                        y = value;
                    }
                    catch
                    {
                        throw new ArgumentException("Špatně zadaný argument!");
                    }
                }
            }

            public Kolo(int maxrychlost, int dojezd, string pohon, double x, double y) : base(maxrychlost, dojezd, pohon)
            {
                X = x;
                Y = y;
            }

            public int CompareTo(object obj)
            {
                DopravniProstredek k = obj as DopravniProstredek;
                if (MaximalniRychlost > k.MaximalniRychlost)
                {
                    return 1;
                }
                else if (MaximalniRychlost < k.MaximalniRychlost)
                {
                    return -1;
                }
                else { return 0; }
            }
        }

        static void Main(string[] args)
        {
            Kolo k1 = new Kolo(20, 500, "Řetěz", 528.4, 111.1);
            Auto a1 = new Auto(120, 1500, "Motor", 400.0, 251.9, 150_000, DateTime.Today);
            Auto a2 = new Auto(150, 3000, "Elektromotor", 450.4, -251.9, 480_999, new DateTime(2025, 5, 19));
            ILokalizovatelne[] localizedArr = { k1, a1, a2 };

            foreach(var v in localizedArr)
            {
                if(v is Auto)
                {
                    Auto a = v as Auto;
                    Console.WriteLine($@"Automobil:
Cena - {a.Cena} Kč
Datum ukončení platnosti povinné technické kontroly - {a.TK}
max. rychlost - {a.MaximalniRychlost} km/h
Dojezd - {a.Dojezd} km
Pohon - {a.Pohon}
Pozice - X{a.X}, Y{a.Y}
");

                }
                else
                {
                    Kolo k = v as Kolo;
                    Console.WriteLine($@"Kolo:
max. rychlost - {k.MaximalniRychlost} km/h
Dojezd - {k.Dojezd} km
Pohon - {k.Pohon}
Pozice - X{k.X}, Y{k.Y}
");
                }
            }

            IComparable[] compareArr = { k1, a1, a2 };

            Console.ReadLine();
        }
    }
}
