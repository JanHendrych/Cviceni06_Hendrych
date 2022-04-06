# Exercise 06 - Liga Mistrů - spojový seznam

Pokračujte v projektech z minulého cvičení a nahraďte v knihovně použití pole za ADS spojový seznam. Spojový seznam bude realizovat všechny požadované operace, které definují základní rozhraní v C# pro třídy kolekcí dat. Ačkoliv spojový seznam rozhodně není polem (resp. obecně přímo indexovatelnou datovou strukturou)
je v rámci procvičení realizováno i rozhraí **IList**

* Poznámka: V předchozím cvičení byl zapomenut test metody **FindBestClubs** ve třídě **PlayerRecords** - v aktuálním cvičení je test doplněn a je tak možné ověřit správnost implementace a v případě chyby jej opravit.

## Postup
* Projekty (obsah složek) **ChampionsLeague** a **ChampionsLeagueLibrary** nahraďte hotovými projekty z minulého cvičení
* Projekt **ChampionsLeagueLibraryTests** neměňte! Obsahuje nové jednotkové testy.
* Realizujte spojový seznam v souboru **ObjectLinkedList.cs**
  * Vytvořte třídu **ObjectLinkedList**
	* třída implicitně realizuje rozhraní **ICollection**, **IEnumerable**, **IList** (z ns **System.Collections** - NEgenerické varianty!)
	* realizujte všechny vlastnosti a metody vyžadované předepsanými rozhraními
	* interní struktura spojového seznamu je acyklický obousměrně zřetězený seznam bez hlavy
	  * třída pro reprezentaci jednoho uzlu v seznamu by neměla být vidět mimo třídu **ObjectLinkedList**
	* pro realizaci není dovoleno použít jiné kolekce z knihovny .NET, ani z jiné externí knihovny
	* veškeré výjimky jsou nahrazeny "no-op" stylem - místo výjimky se nic nestane! v případě návratových hodnot se vrací null
	* vlastnosti kolekcí **IsSynchronized** = false, **SyncRoot** = this, **IsFixedSize** = false, **IsReadOnly** = false
	* **indexer** - indexuje se od nuly do počtu prvků - 1
	* **Remove** - odebírá první shodný (**Equals**) prvek
	* **Insert** - umožňuje vložení pouze na platné indexy uprostřed seznamu + začátek + konec seznamu
	  * pokus o přidání na záporné indexy nebo indexy za koncem seznamu neprovádí nic (žádný prvek se nepřidá)
	  * prázdný seznam ```[]``` - je dovoleno pouze
	  	* ```Insert(0, x)``` - ```[x]``` 
	  * seznam s jedním prvkem ```[x]``` - jsou přípustné následující varianty
	  	* ```Insert(0, y)``` - vložení na začátek seznamu - ```[y, x]```
	  	* ```Insert(1, y)``` - vložení na konec seznamu - ```[x, y]```
	  * seznam se dvěma prvky ```[x, y]``` - jsou přípustné následující varianty
	  	* ```Insert(0, z)``` - ```[z, x, y]```
	  	* ```Insert(1, z)``` - ```[x, z, y]```
	  	* ```Insert(2, z)``` - ```[x, y, z]```
	  * obdobně pro seznamy s větším počtem prvků
* Ve třídě **PlayerRecords** 
  * Změňte typ atributu **players** na **ObjectLinkedList**, upravte všechny reference na atribut a obnovte původní funkcionalitu
  * Doplňte implicitní realizaci rozhraní **IEnumerable** (ns **System.Collections**); volání metody delegujte na atribut **players**
