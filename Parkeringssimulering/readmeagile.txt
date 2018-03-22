Liste over hva som skal være inkludert i simuleringsmodellen.
-	Skal inneholder følgende klasser: Bil(Car), Parkeringsplass(Parkingspot), Trafikk(Queue) and Hoved(Main).
-	Disse klassene må dokumenteres både i klassediagram og i kode.  
- 	Bil klassen inneholder: ID(nummerisk verdi for bilen), Ønsket destinasjon(Ditt bilen skal), ankomst fra(Hvor bilen kommer fra altså hvilken kø den stelles i), tid for ankomst(Tidsmerket når den ankom køen) og tid for parkering(Når den forlatter køen).
-	Parkeringsplass klassen inneholder: Navn(For å holdestyr på hvor de er), antall totalt parkeringsplasser(Kapasiteten til parkeringsplassen), antall ledige parkeringsplasser(totalt ledige minus opptatte plasser), antall opptatte parkeringsplasser(Hvor mange biler plassen har tatt imot).
-	Trafikk klassen inneholder: Navn(for å holde styr på hvor den er), array med biler(Bilene som kom hit) og dere plass i køen, beslektede parkeringsplasser(hvilke parkeringsplasser de kan "gi" biler til), beslektede andre køer.
-	Main klassen innholder: Mesteparten av koden som kjører simuleringen så denne kommer vi tilbake til med en grunndigere beskrivelse.
-	Skal håndere 1200 bilitster.
-	Ta høyde for at noen bilister utenom de 1200 kan passere gjennom område i simuleringen.
-	Køer vil gå begge veier altså trafikk fra og til.
-	Antall parkeringsplasser skal dobbelskjekkes manuelt men enn så lenge finnes relevant data i /resurser
-	VIKTIG og få på plass at dersom det er fult på Ønsket parkeringsplass i BIL klassen må neste "nærmeste" finnes og settes som ny "Ønsket" Lokalisasjon.
-	Dersom parkeringsplassen er FULL! Må det taes inn i beregning at BILER kjører til ØNSKET FØRST også flytter seg til neste "Nærmeste" parkeringsplass.


-	Ctrl + Shift + D to ghostDoc Auto comment. Do this often and always.