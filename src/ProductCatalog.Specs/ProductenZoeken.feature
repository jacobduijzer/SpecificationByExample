# language: nl-NL

Functionaliteit: Zoeken in de product catalogus
    
Als klant
Wil ik de product catalogus kunnen doorzoeken op producten die ik wil kopen
Zodat ik kan zien of het product leverbaar is
    
    Scenario: Een boek zoeken in een bepaalde categorie
        Gegeven Simone wil het boek "Specification By Example" kopen
        Als Simone zoekt in de categorie "SoftwareDevelopment"
        Dan krijgt ze de keuze uit de volgende boeken
          | Titel                    | Auteur      | Formaat   |
          | Specification By Example | Gojko Adzic | PDF       |
          | Specification By Example | Gojko Adzic | Hardcover |