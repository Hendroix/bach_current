Liste over hva som skal v�re inkludert i simuleringsmodellen.
-	Skal inneholder f�lgende klasser: Bil(Car), Parkeringsplass(Parkingspot), Trafikk(Queue) and Hoved(Main).
-	Disse klassene m� dokumenteres b�de i klassediagram og i kode.  
- 	Bil klassen inneholder: ID(nummerisk verdi for bilen), �nsket destinasjon(Ditt bilen skal), ankomst fra(Hvor bilen kommer fra alts� hvilken k� den stelles i), tid for ankomst(Tidsmerket n�r den ankom k�en) og tid for parkering(N�r den forlatter k�en).
-	Parkeringsplass klassen inneholder: Navn(For � holdestyr p� hvor de er), antall totalt parkeringsplasser(Kapasiteten til parkeringsplassen), antall ledige parkeringsplasser(totalt ledige minus opptatte plasser), antall opptatte parkeringsplasser(Hvor mange biler plassen har tatt imot).
-	Trafikk klassen inneholder: Navn(for � holde styr p� hvor den er), array med biler(Bilene som kom hit) og dere plass i k�en, beslektede parkeringsplasser(hvilke parkeringsplasser de kan "gi" biler til), beslektede andre k�er.
-	Main klassen innholder: Mesteparten av koden som kj�rer simuleringen s� denne kommer vi tilbake til med en grunndigere beskrivelse.
-	Skal h�ndere 1200 bilitster.
-	Ta h�yde for at noen bilister utenom de 1200 kan passere gjennom omr�de i simuleringen.
-	K�er vil g� begge veier alts� trafikk fra og til.
-	Antall parkeringsplasser skal dobbelskjekkes manuelt men enn s� lenge finnes relevant data i /resurser
-	VIKTIG og f� p� plass at dersom det er fult p� �nsket parkeringsplass i BIL klassen m� neste "n�rmeste" finnes og settes som ny "�nsket" Lokalisasjon.
-	Dersom parkeringsplassen er FULL! M� det taes inn i beregning at BILER kj�rer til �NSKET F�RST ogs� flytter seg til neste "N�rmeste" parkeringsplass.


-	Ctrl + Shift + D to ghostDoc Auto comment. Do this often and always.