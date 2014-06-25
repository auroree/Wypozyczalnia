Podzia� obowi�zk�w wg okienek:

Hania - pracownicy
Pawe� - statki
Tomek - cz��ci
Krzysiek - rezerwacje
Krystian - lista zam�wie�

Wzorujcie si� na rozwi�zaniu Hani.

Narz�dzia:
Microsoft Sql Server Management Studio 2012 - na dobrychprogramach jest, na microsofcie co� nie dzia�a
Visual Studio 2013 Express

�eby utworzy� baz� danych uruchamiacie zapytania z folderu queries w odpowiedniej kolejno�ci, na pocz�tku oczywi�cie ddl.sql, a potem reszta.

BUGI:

rezerwacje
1. nie mozna dodac daty zamkniecia rezerwacji przy dodawaniu.
2. proponuje powiekszyc okienko / zmniejszyc naglowek tabeli z wyborem klienta i satku, zeby bylo jasne, ze pododaniu drugiego zostal podmieniony.
3. dopisac informacje o prawidlowym formacie daty.
[WAZNE] 4. w oknie edycji nie wczytuje sie aktualnie wybrany statek, ale nie mago na liscie, niemozliwa edycja rezerwacji
5. przydalaby sie mozliwosc dodawania statku, ktory jest zarezerwowany za rok, a chcemy go zarezerowac za miesiac. mozna by dodac dla informacji pole z data najblizszej rezerwacji, zeby mozna bylo okreslic czy sie "wyrobi" na czas. dodac wymog podania daty zamkniecia rezerwacji.

czesci
[WAZNE] 1. nie mozna dodac czesci bez id zamowienia. (baza nie pozwala na null id zamowienia)
zmienilam plik ddl.
2. komunikat o bledzie wyswietla wall of text na temat wyjatku. straszy uzytkownika.
[WAZNE] 3. proba dodania czesci z id zamowienia wywoluje wyjatek. proponuje umozliwienie dodawania wylacznie czesci do zamowienia i dodanie przycisku dodawania czesci w formularzu zamowien. dane o nowej czesci wyslac po wstawieniu do bazy rekordu zamowienia.
4. dodac przycisk "odebrano zamowienie" zmieniajacy status wszystkich czesci w tym zamowieniu na "w magazynie"


