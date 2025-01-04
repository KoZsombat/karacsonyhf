namespace ConsoleApp11
{
    internal class Program
    {
        static int budget = 0;
        static int spent = 0;
        static List<string> ajandek = new List<string>();
        static List<int> ajandekAr = new List<int>();
        static List<string> kategoria = new List<string>();

        static void Main(string[] args)
        {
            SetBudget();

            bool fut = true;

            while (fut) 
            {
                Console.WriteLine("1. Ajándék Hozzáadása\n2. Ajándék Szerkesztése\n3. Ajándék Eltávolítása\n4. Ajándéklista Megtekintése\n5. Kosár Statisztika\n6. Kilépés");
                string valasz = Console.ReadLine();

                switch (valasz) 
                {
                    case "1":
                        AddGift();
                        break;
                    case "2":
                        EditGift();
                        break;
                    case "3":
                        RemoveGift();
                        break;
                    case "4":
                        ViewGifts();
                        CategorizeGifts();
                        break;
                    case "5":
                        CheckBudget();
                        CategorizeGifts();
                        CheckMostExpensive();
                        break;
                    case "6":
                        Console.WriteLine("Kellemes karácsonyt!");
                        fut = false;
                        break;
                    default:
                        Console.WriteLine("Érvénytelen");
                        break;
                }
            }
        }

        static void AddGift()
        {
            try
            {
                Console.WriteLine("Ajándék neve:");
                string nev = Console.ReadLine();
                if (nev == "")
                {
                    throw new Exception("Meg kell adni valamit.");
                }
                Console.WriteLine("Ára:");
                int ar = Convert.ToInt32(Console.ReadLine());
                if (ar < 0) 
                {
                    throw new Exception("Nem lehet negatív az ára.");
                }
                Console.WriteLine("Kategóroia:");
                string kat = Console.ReadLine();
                if (kat == "")
                {
                    throw new Exception("Meg kell adni valamit.");
                }

                ajandek.Add(nev);
                ajandekAr.Add(ar);
                kategoria.Add(kat);

                spent = ajandekAr.Sum();

                if (budget - spent < 0)
                {
                    throw new Exception("Minuszba van az egyenleged");
                }

                if (budget - spent < budget / 10)
                {
                    throw new Exception("A pénzed az alap budget 10%-a alatt van ");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Túl magas szám");
            }
            catch (FormatException) 
            {
                Console.WriteLine("Rossz formátum");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static void EditGift()
        {
            try
            {
                Console.WriteLine("Melyiket szerretnéd módosítani?");
                for (int i = 0; i < ajandek.Count; i++)
                {
                    Console.WriteLine($"{i}. {ajandek[i]}");
                }
                int valasz = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Ezt választottad: {ajandek[valasz]}");
                Console.WriteLine($"Mit szeretnél módosítani a nevét, az árát vagy a kategóriát? (1,2,3)");
                string valasz2 = Console.ReadLine();
                switch (valasz2)
                {
                    case "1":
                        Console.WriteLine("Ajándék neve:");
                        string nev = Console.ReadLine();
                        if (nev == "")
                        {
                            throw new Exception("Meg kell adni valamit.");
                        }
                        ajandek[valasz] = nev;
                        break;
                    case "2":
                        Console.WriteLine("Ára:");
                        int ar = Convert.ToInt32(Console.ReadLine());
                        if (ar < 0)
                        {
                            throw new Exception("Nem lehet negatív az ára.");
                        }
                        ajandekAr[valasz] = ar;
                        break;
                    case "3":
                        Console.WriteLine("Kategóroia:");
                        string kat = Console.ReadLine();
                        if (kat == "")
                        {
                            throw new Exception("Meg kell adni valamit.");
                        }
                        kategoria[valasz] = kat;
                        break;
                    default:
                        Console.WriteLine("Nincs ilyen opció");
                        break;

                }
                spent = ajandekAr.Sum();

                if (budget - spent < 0)
                {
                    throw new Exception("Minuszba van az egyenleged");
                }

                if (budget - spent < budget / 10)
                {
                    throw new Exception("A pénzed az alap budget 10%-a alatt van ");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Túl magas szám");
            }
            catch (FormatException)
            {
                Console.WriteLine("Rossz formátum");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Nincs elem ezen a sloton");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void RemoveGift()
        {
            try
            {
                Console.WriteLine("Melyiket szerretnéd törölni?");
                for (int i = 0; i < ajandek.Count; i++)
                {
                    Console.WriteLine($"{i}. {ajandek[i]}");
                }
                int valasz = Convert.ToInt32(Console.ReadLine());
                ajandek.Remove(ajandek[valasz]);
                ajandekAr.Remove(ajandekAr[valasz]);
                kategoria.Remove(kategoria[valasz]);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Túl magas szám");
            }
            catch (FormatException)
            {
                Console.WriteLine("Rossz formátum");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Nincs elem ezen a sloton");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SetBudget()
        {
            bool budgetsetted = false;

            while (!budgetsetted) 
            {
                try
                {
                    Console.WriteLine("Budget:");
                    budget = Convert.ToInt32(Console.ReadLine());
                    if (budget < 0)
                    {
                        throw new Exception("Nem lehet negatív az ára.");
                    }
                    budgetsetted = true;

                }
                catch (OverflowException)
                {
                    Console.WriteLine("Túl magas szám");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Rossz formátum");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        static void CheckBudget()
        {
            Console.WriteLine($"A lista {ajandek.Count} ajándékot tartalmaz ami összesen {spent} Ft");
            Console.WriteLine($"Eddig elköltött összeg: {spent}, Hátralévő összeg: {budget-spent}");
        }

        static void ViewGifts()
        {
            for (int i = 0; i < ajandek.Count; i++)
            {
                Console.WriteLine($"{ajandek[i]}, {ajandekAr[i]}, {kategoria[i]}");
            }
        }

        static void CategorizeGifts()
        {
            List<string> kategoriak = new List<string>();

            for (int i = 0; i < ajandek.Count; i++)
            {
                if (kategoriak.Contains(kategoria[i]))
                {
                    
                }
                else
                {
                    kategoriak.Add(kategoria[i]);
                }
            }
            for (int i = 0; i < kategoriak.Count; i++)
            {
                Console.WriteLine(kategoriak[i] + ":");
                for (int a = 0; a < ajandek.Count; a++) 
                {
                    if (kategoriak[i] == kategoria[a])
                    {
                        Console.WriteLine(ajandek[a]);
                    }
                }
            }
        }

        static void CheckMostExpensive()
        {
            Console.WriteLine($"Legolcsóbb: {ajandek[ajandekAr.IndexOf(ajandekAr.Min())]} Legdrágább: {ajandek[ajandekAr.IndexOf(ajandekAr.Max())]}");
        }
    }
}