using System;
using System.Collections.Generic;
using System.Text;

namespace _4OpEenRij2
{
    class VierOpEenRij
    {
		private int[,] spelbord;

		public int[,] Spelbord
		{
			get { return spelbord; }
			set { spelbord = value; }
			//geen set -> readonly
		}
		public int AantalKolommen { get; set; } = 7;
		public int AantalRijen { get; set; } = 6;


		//constructor maakt spel'bord' aan en maakt spelbord leeg
		public VierOpEenRij()
		{
			spelbord = new int[this.AantalKolommen, this.AantalRijen];
			maakleeg(spelbord);
		}

		//constructor met variabele grootte van spelbord
		public VierOpEenRij(int kolommen, int rijen)
		{
			AantalKolommen = kolommen;
			AantalRijen = rijen;
			spelbord = new int[this.AantalKolommen, this.AantalRijen];
			maakleeg(spelbord);
		}
		//maakleeg methode maakt spelbord leeg: zet alle waarden van array spelbord op nul
		public void maakleeg(int[,] spelbord)
		{
			for (int kolom = 0; kolom < this.AantalKolommen; kolom++)
			{
				for (int rij = 0; rij < this.AantalRijen; rij++)
				{
					spelbord[kolom, rij] = 0;
				}
			}
		}
		public void SteekJetonIn(int kolom, int jetonKleur, out bool kolomIsVol)
		{
			//adhv deze functie kan je een jeton in het spelbord laten 'vallen'
			//de functie geeft ook mee of de kolom waarin je de jeton probeert te steken reeds vol is
			//
			//als er een waarde in de bovenste rij zit, is de kolom vol en wordt enkel de out bool kolomvol op true gezet
			//kolom is niet vol: jeton komt op beschikbare plaats onderaan de kolom terecht
			kolomIsVol = false;
			if (spelbord[kolom, AantalRijen-1] != 0)
			{
				kolomIsVol = true;
			}
			else
			{
				for (int i = 0; i < AantalRijen; i++)
				{
					if (spelbord[kolom, i] == 0)
					{
						spelbord[kolom, i] = jetonKleur;
						break;
					}
				}
			}
		}
		public int WieWint(int[,] spelbord)
		{


			int vieropeenrijcheck;
			//kolommen
			for (int kolom = 0; kolom < AantalKolommen; kolom++)
			{
				vieropeenrijcheck = 1;
				for (int rij = 1; rij < AantalRijen; rij++)
				{
					if (spelbord[kolom, rij - 1] ==  spelbord[kolom, rij])
					{
						vieropeenrijcheck++;
						if (vieropeenrijcheck >= 4 && spelbord[kolom, rij-1] !=0)
						{
							return spelbord[kolom, rij - 1];
						}
					}
					else
					{
						vieropeenrijcheck = 1;
					}
				}
			}

			//rijen
			for (int rij = 0; rij < AantalRijen; rij++)
			{
				vieropeenrijcheck = 1;
				for (int kolom = 1; kolom < AantalKolommen; kolom++)
				{
					if (spelbord[kolom - 1, rij] == spelbord[kolom, rij])
					{
						vieropeenrijcheck++;
						if (vieropeenrijcheck >= 4 && spelbord[kolom - 1, rij] != 0)
						{
							return spelbord[kolom - 1, rij];
						}
					}
					else
					{
						vieropeenrijcheck = 1;
					}
				}
			}


			//diagonaal rechtsboven linksonder 1e helft (start locatie [5,5] vergelijken met [4,4]
			// if (aantalKolommen-i-j-1 >= 0) && (aantalrijen-j-1 >= 0)
			// [aantalKolommen-i-j, aantalRijen-j] == [aantalKolommen-i-j - 1, aantalRijen-j - 1]
			// andere aanpak hier
			for (int i = 0; i < AantalKolommen-1; i++)
			{
				vieropeenrijcheck = 1;
				for (int j = 0; AantalKolommen - i - j - 2 >= 0 && AantalRijen - j - 2 >= 0; j++)
				{
					if (spelbord[AantalKolommen - i - j - 1, AantalRijen - j - 1] == spelbord[AantalKolommen - i - j - 2, AantalRijen - j - 2])
					{
						vieropeenrijcheck++;
						if (vieropeenrijcheck >= 4 && spelbord[AantalKolommen - i - j-1, AantalRijen - j-1] != 0)
						{
							return spelbord[AantalKolommen - i - j, AantalRijen - j];
						}
					}
					else
					{
						vieropeenrijcheck = 1;
					}
				}
			}
			//		0 1 2 3 4 5 6
			//
			//	5	0 0 0 0 0 0 0
			//	4	0 0 0 0 0 0 0
			//	3	0 0 0 0 0 0 0
			//	2	0 0 0 0 0 0 0
			//	1	0 0 0 0 0 0 0
			//	0	0 0 0 0 0 0 0
			//diagonaal rechtsboven linksonder 2e helft
			//
			// [aantalKolommen-1-j, aantalRijen-1-j-i] == [aantalKolommen-1-j - 1, aantalRijen-1-j-i - 1]
			//

			for (int i = 0; i < AantalRijen - 1; i++)
			{
				vieropeenrijcheck = 1;
				for (int j = 0; AantalKolommen - j - 2 >= 0 && AantalRijen - j - i - 2 >= 0; j++)
				{
					if (spelbord[AantalKolommen - j - 1, AantalRijen - j - i - 1] == spelbord[AantalKolommen - j - 2, AantalRijen - j - i - 2])
					{
						vieropeenrijcheck++;
						if (vieropeenrijcheck >= 4 && spelbord[AantalKolommen - i - j - 1, AantalRijen - j - 1] != 0)
						{
							return spelbord[AantalKolommen - i - j, AantalRijen - j];
						}
					}
					else
					{
						vieropeenrijcheck = 1;
					}
				}
			}
			//		0 1 2 3 4 5 6 7 8
			//
			//	5	0 0 0 3 0 0 0 0 0
			//	4	0 0 3 0 0 0 0 0 0
			//	3	0 3 0 0 0 0 0 0 0
			//	2	3 0 0 0 0 0 0 0 0
			//	1	0 0 0 0 0 0 0 0 0
			//	0	0 0 0 0 0 0 0 0 0
			//
			//
			//

			//diagonaal linksboven rechtsonder
			// [kolomnr j + i, aantalrijen - j] == [kolomnr j + i + 1, aantalrijen - j -1]
			for (int i = 0; i < AantalKolommen - 2; i++)
			{
				vieropeenrijcheck = 1;
				for (int j = 0; i + j + 1 < AantalKolommen && AantalRijen -1 - j - 1 >= 0; j++)
				{
					if (spelbord[i+j, AantalRijen-1-j] == spelbord[i+j+1, AantalRijen-1-j-1])
					{
						vieropeenrijcheck++;
						if (vieropeenrijcheck >= 4 && spelbord[i + j, AantalRijen - 1 - j] != 0)
						{
							return spelbord[i + j, AantalRijen - 1 - j];
						}
					}
				}
			}
			//diagonaal linksboven rechtsonder
			// [kolomnr j, aantalrijen - 1 - j - i] == [kolomnr j + 1, aantalrijen - 1 - j - i -1]
			for (int i = 0; i < AantalRijen - 2; i++)
			{
				vieropeenrijcheck = 1;
				for (int j = 0; j + 1 < AantalKolommen && AantalRijen - 1 - j - i - 1 >= 0; j++)
				{
					if (spelbord[j, AantalRijen - 1 - j - i] == spelbord[j + 1, AantalRijen - 1 - j -i - 1])
					{
						vieropeenrijcheck++;
						if (vieropeenrijcheck >= 4 && spelbord[j, AantalRijen - 1 - j - i] != 0)
						{
							return spelbord[j, AantalRijen - 1 - j - i];
						}
					}
				}
			}
			//
			//diagonaal rechtsboven linksonder 2de helft andere aanpak 
			//for (int rij = 1; rij < AantalRijen; rij++)
			//{
			//	int temp = rij;
			//	vieropeenrijcheck = 1;
			//	for (int kolom = AantalKolommen - 1; temp >= 1; kolom--)
			//	{
			//		if (spelbord[kolom, temp] == spelbord[kolom - 1, temp - 1])
			//		{
			//			vieropeenrijcheck++;
			//			if (vieropeenrijcheck == 4 && spelbord[kolom, temp] != 0)
			//			{
			//				return spelbord[kolom, temp];
			//			}
			//		}
			//		else
			//		{
			//			vieropeenrijcheck = 1;
			//		}
			//		temp--;
			//	}
			//}

			return 5;
		}

		public bool IsGelijk(int a, int b)
		{
			if (a == b)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}

}
