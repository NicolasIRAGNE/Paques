using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Salut
{
    static bool Anneebissextile(int annee)
    {
        if ((annee % 400 == 0) || (annee % 4 == 0 && annee % 100 != 0))
            return (true);
        else
            return (false);
    }

    static int NombreDeJours(int mois)
    {
        if (mois == 2)
            return (28);
        else if (mois <= 7)
        {
            if (mois % 2 == 0)
                return (30);
            else
                return (31);
        }
        else
        {
            if (mois % 2 == 0)
                return (31);
            else
                return (30);
        }
    }

    static int NombreDeJoursAnnee(int mois, int annee)
    {
        if (mois == 2 && Anneebissextile(annee))
            return (29);
        else if (mois == 2)
            return (28);
        else if (mois <= 7)
        {
            if (mois % 2 == 0)
                return (30);
            else
                return (31);
        }
        else
        {
            if (mois % 2 == 0)
                return (31);
            else
                return (30);
        }
    }

    static DateTime GaussGregorien(int annee)
    {
        int a = annee % 19;
        int b = annee % 4;
        int c = annee % 7;
        int k = annee / 100;
        int p = (13 + 8 * k) / 25;
        int q = k / 4;
        int M = (15 - p + k - q) % 30;
        int N = (4 + k - q) % 7;
        int d = (19 * a + M) % 30;
        int e = (2 * b + 4 * c + 6 * d + N) % 7;
        int H = (22 + d + e);
        int Q = (H - 31);

        if (d == 29 && e == 6)
            Q = 19;
        if (d == 29 && e == 6 && ((11*M + 11) % 30 > 19))
            Q = 18;
        if (H < 31)
            return new DateTime(annee, 3, H);
        else
            return new DateTime(annee, 4, Q);
    }

    static DateTime GaussJulien(int annee)
    {
        int a = annee % 19;
        int b = annee % 4;
        int c = annee % 7;
        int M = 15;
        int N = 6;
        int d = (19 * a + M) % 30;
        int e = (2 * b + 4 * c + 6 * d + N) % 7;
        int H = (22 + d + e);
        int Q = (d + e - 9);

        if (d == 29 && e == 6)
            Q = 19;
        if (d == 29 && e == 6 && ((11 * M + 11) % 30 > 19))
            Q = 18;
        if (H < 31)
            return new DateTime(annee, 3, H);
        else
            return new DateTime(annee, 4, Q);
    }

    static DateTime Conway(int annee)
    {
        int s = annee / 100;
        int t = annee % 100;
        int a = t / 4;
        int p = s % 4;
        int jps = (9 - 2 * p) % 7;
        int jp = (jps + t + a) % 7;
        int g = annee % 19;
        int G = g + 1;
        int b = s / 4;
        int r = ((8 * (s + 11)) / 25);
        int C = -s + b + r;
        int d = (11 * G + C) % 30;
        d = (d + 30) % 30;
        int h = (551 - 19 * d + G) / 544;
        int e = (50 - d - h) % 7;
        int f = (e + jp) % 7;
        int R = 57 - d - f - h;

        if (R <= 31)
            return new DateTime(annee, 3, R);
        else
            return new DateTime(annee, 4, R - 31);
    }



    static DateTime MeeusGregorien(int annee)
    {
        int n = annee % 19;
        int c = annee / 100;
        int u = annee % 100;
        int s = c / 4;
        int t = c % 4;
        int p = (c + 8) / 25;
        int q = (c - p + 1) / 3;
        int e = (19 * n + c - s - q + 15) % 30;
        int b = u / 4;
        int d = u % 4;
        int L = (32 + 2 * t + 2 * b - e - d) % 7;
        int h = (n + 11 * e + 22 * L) / 451;
        int m = (e + L - 7 * h + 114) / 31;
        int j = (e + L - 7 * h + 114) % 31;

        return new DateTime(annee, m, j + 1);
    }

    static DateTime MeeusJulien(int annee)
    {
        int A = annee % 19;
        int B = annee % 7;
        int C = annee % 4;
        int D = (19 * A + 15) % 30;
        int E = (2 * C + 4 * B - D + 34) % 7;
        int F = (D + E + 114) / 31;
        int G = (D + E + 114) % 31;

        return new DateTime(annee, F, G+1);
    }

    static void FetesMobiles(int annee)
    {
        Console.WriteLine("Triodion:                              " + Conway(annee).AddDays(-70).ToString("dd/MM"));
        Console.WriteLine("Septuagésime:                          " + Conway(annee).AddDays(-63).ToString("dd/MM"));
        Console.WriteLine("Samedi des âmes:                       " + Conway(annee).AddDays(-57).ToString("dd/MM"));
        Console.WriteLine("Sexagésime:                            " + Conway(annee).AddDays(-56).ToString("dd/MM"));
        Console.WriteLine("Quinquagésime:                         " + Conway(annee).AddDays(-49).ToString("dd/MM"));
        Console.WriteLine("Lundi Gras:                            " + Conway(annee).AddDays(-48).ToString("dd/MM"));
        Console.WriteLine("Mardi Gras:                            " + Conway(annee).AddDays(-47).ToString("dd/MM"));
        Console.WriteLine("Mercredi des Cendres:                  " + Conway(annee).AddDays(-46).ToString("dd/MM"));
        Console.WriteLine("Dimanche de l'Orthodoxie:              " + Conway(annee).AddDays(-42).ToString("dd/MM"));
        Console.WriteLine("People's Sunday:                       " + Conway(annee).AddDays(-41).ToString("dd/MM"));
        Console.WriteLine("Mothering Sunday:                      " + Conway(annee).AddDays(-21).ToString("dd/MM"));
        Console.WriteLine("Dimanche de la Passion:                " + Conway(annee).AddDays(-14).ToString("dd/MM"));
        Console.WriteLine("Samedi de Lazare:                      " + Conway(annee).AddDays(-8).ToString("dd/MM"));
        Console.WriteLine("Dimanche des Rameaux:                  " + Conway(annee).AddDays(-7).ToString("dd/MM"));
        Console.WriteLine("Jeudi saint:                           " + Conway(annee).AddDays(-3).ToString("dd/MM"));
        Console.WriteLine("Vendredi saint:                        " + Conway(annee).AddDays(-2).ToString("dd/MM"));
        Console.WriteLine("Samedi saint:                          " + Conway(annee).AddDays(-1).ToString("dd/MM"));
        Console.WriteLine("Pâques:                                " + Conway(annee).ToString("dd/MM"));
        Console.WriteLine("Fête de saint Grégoire:                " + Conway(annee).AddDays(3).ToString("dd/MM"));
        Console.WriteLine("Quasimodo:                             " + Conway(annee).AddDays(7).ToString("dd/MM"));
        Console.WriteLine("Radonitsa:                             " + Conway(annee).AddDays(8).ToString("dd/MM") + " ou " + Conway(annee).AddDays(9).ToString("dd/MM"));
        Console.WriteLine("Ascension:                             " + Conway(annee).AddDays(39).ToString("dd/MM"));
        Console.WriteLine("Pentecôte:                             " + Conway(annee).AddDays(49).ToString("dd/MM"));
        Console.WriteLine("Lundi de Pentecôte:                    " + Conway(annee).AddDays(50).ToString("dd/MM"));
        Console.WriteLine("Fête de la Sainte Trinité / Toussaint: " + Conway(annee).AddDays(56).ToString("dd/MM"));
        Console.WriteLine("Fête-Dieu:                             " + Conway(annee).AddDays(60).ToString("dd/MM"));

    }

    static void Fetes()
    {
        string anneeStr;
        int annee;
        int decennie;
        Console.WriteLine("Veuillez entrer une année.");
        anneeStr = Console.ReadLine();
        annee = Convert.ToInt32(anneeStr);
        while (annee <= 1583)
        {
            Console.WriteLine("Veuillez entrer une année supérieure à 1583.");
            anneeStr = Console.ReadLine();
            annee = Convert.ToInt32(anneeStr);
        }
        decennie = annee / 10;
        decennie = decennie * 10;
        Console.Clear();
        Console.WriteLine("Fêtes mobiles de l'année " + annee + ":");
        FetesMobiles(annee);
        Console.WriteLine("Dates de Pâques de " + decennie + " à " + (decennie + 10) + ":");
        annee = decennie;
        while (annee < decennie + 10)
        {
            if (annee < 1583)
                Console.WriteLine("L'affichage de la date de Pâques à l'année " + annee + " est impossible avec l'algorithme.");
            else
                Console.WriteLine(MeeusGregorien(annee).ToString("dd/MM/yyyy"));
            annee++;
        }
        Console.WriteLine("Appuyez sur une touche pour continuer...");
        Console.ReadKey();
        Console.Clear();
    }

    static void CalendrierPerpetuel()
    {
        Console.Clear();
        Console.WriteLine("Entrer une date sous format jj/mm/aaaa");
        string input = Console.ReadLine();
        string verbe = " était";
        DateTime date = new DateTime(Convert.ToInt32(input.Substring(6, 4)), Convert.ToInt32(input.Substring(3, 2)), Convert.ToInt32(input.Substring(0, 2)));
        DateTime now = DateTime.Now;
        if (DateTime.Compare(date, now) > 0)
            verbe = " sera";
        Console.WriteLine("Le " + date.ToString("dd/MM/yyyy") + verbe + " un " + date.ToString("dddd", new System.Globalization.CultureInfo("fr-FR")) + ".\n");
        Console.WriteLine("Appuyez sur une touche pour continuer...");
        Console.ReadKey();
        Console.Clear();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("A: Fetes");
        Console.WriteLine("B: Calendrier perpetuel");
        Console.WriteLine("Echap: Quitter");
        ConsoleKeyInfo key = Console.ReadKey();
        while (key.Key != ConsoleKey.Escape)
        {
            Console.Clear();

            if (key.Key == ConsoleKey.A)
                Fetes();
            else if (key.Key == ConsoleKey.B)
                CalendrierPerpetuel();
            else
                Console.WriteLine("Erreur: Touche non reconnue");
            Console.WriteLine("A: Fetes");
            Console.WriteLine("B: Calendrier perpetuel");
            Console.WriteLine("Echap: Quitter");
            key = Console.ReadKey();
        }
    }
}