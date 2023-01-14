# language: nl-NL

Functionaliteit: Zoeken in de product catalogus
    
Als klant van de boekenwinkel
Wil ik kunnen zoeken naar boeken
Zodat ik boeken kan bestellen 
    
    Scenario: Een boek zoeken met een titel en in een bepaalde categorie
        Gegeven Simone wil een boek kopen met de titel "Specification By Example" 
        En ze selecteerd de categorie "SoftwareDevelopment"
        Als ze gaat zoeken
        Dan krijgt ze de keuze uit de volgende boeken
          | Titel                    | Auteur      | Formaat   |
          | Specification By Example | Gojko Adzic | PDF       |
          | Specification By Example | Gojko Adzic | Hardcover |
   
    Scenario: Boeken zoeken op formaat
        Gegeven Simone wil een book kopen van het formaat 'PDF'
        Als ze gaat zoeken
        Dan krijgt ze de keuze uit de volgende boeken
        | Titel                       | Auteur      | Formaat |
        | Specification By Example    | Gojko Adzic | PDF     |
        | Code That Fits In Your Head | Mark Seeman | PDF     |
    
    Scenario: Boeken zoeken in een bepaalde categorie
        Gegeven Simone zoekt in de categorie "Testing"
        Als ze gaat zoeken
        Dan krijgt ze de keuze uit de volgende boeken
          | Titel                        | Auteur        | Formaat   |
          | Specification By Example     | Gojko Adzic   | PDF       |
          | Specification By Example     | Gojko Adzic   | Hardcover | 
          | Writing Great Specifications | Kamil Nicieja | Epub      |
          | Writing Great Specifications | Kamil Nicieja | Paperback | 
        