###Petter Fagerlund

## Redovisning
Källkoden ska vara pushad till ett eget publikt repository på GitHub. Ert fullständiga namn, samt en *kort* reflektion över dina arkitekturella val, såsom:

- Vad du valt att testa och varför?
  #Testade sorterings logiken på metoderna, och vad de returnerar. På så vis om någon ändrar sortering eller vad det returnerar failar testerna. 
  #borde även testat httresponsen och try catch, men hade för lite tid. 
- Vilket/vilka designmönster har du valt, varför? Hade det gått att göra på ett annat sätt?
  V#alde Factory för att det var enklast då vi behövde använda flera instanser av MovieClient i Controllern. Hade förmodligen fungerat med även en Singelton 
- Hur mycket valde du att optimera koden, varför är det en rimlig nivå för vårt program?
  #Valde att flytta ut allt, från controllern, ändra namn, metoder returnerar modeller istället för strängar. 
  #Det finns en mängd saker jag vill göra bättre, men knappt om tid. 

ska finnas med i README.md i repots main-branch (master).
