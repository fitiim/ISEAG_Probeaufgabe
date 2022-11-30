# C# Coding Challenge

## Aufgabe

Bei dieser Challenge geht es darum, eine C# Konsolenapplikation zu schreiben, mit welchem Schüler und Lehrpersonen an Klassen zugeteilt werden. Die Daten stammen aus verschiedenen Formaten (csv und xml).

Daten:
- users.csv: alle Benutzer mit Id, Name, Vorname, Geburtsdatum
- lessons.xml: Lektionen mit Id, Titel, Datum, Teilnehmer und Lehrpersonen

## Anforderungen

### Funktionale Anforderungen:

1. für jede Lektion wird eine Gruppe erstellt
2. Lehrpersonen werden den der jeweiligen Lektions-Gruppe als Owner hinzugefügt
3. Schüler werden den der jeweiligen Lektions-Gruppe als Member hinzugefügt
4. MailNickname(GroupId) der Gruppe wird nach folgendem Schema erstellt: `grp-{Lesson:title}@hogwarts.com`
5. MailNickname der Benutzer wird nach folgendem Schema erstellt: `{first_name}.{last_name}@hogwarts.com`

erweiterte Anforderungen (optional):

6. erweitere die Applikation so, dass sie mit einem Parameter aufgerufen werden kann. Mit dem Parameter wird ein Datum übergeben (Ausführungsdatum).
7. teile nun die Gruppenzugehörigkeiten anhand der folgenden Regeln auf:
   7.1. Füge den Schüler der Gruppe einen Monat vor dem Lektionsdatum hinzu
   7.2. Entferne den Schüler einen Monat nach dem Lektionsdatum aus der Gruppe.

### Auf was schauen wir noch:

- Arbeitsmethodik: eine klare Struktur soll ersichtlich sein, wie das Problem angegangen wurde. Aus den Commits soll der Vorgang ersichtlich sein.
- Testing: Unit Tests sind erwünscht, teste was dir sinnvoll erscheint.
- Wir haben auch Papier, ein Model kann helfen.


## Tagesablauf

grober Tagesablauf, es wird nicht strikt eingehalten:

- 08:00 - 08:45 -- Einführung, Aufgabenstellung, Fragen
- 08:45 - 09:30 -- Planung/Konzeption
- 09:30 - 09:45 -- Pause
- 09:45 - 10:15 -- Planung/Konzeption
- 10:15 - 11:45 -- Coding

- 11:45 - 13:00 -- Mittag

- 13:00 - 14:00 -- Coding (Fortsetzung)
- 14:00 - 15:00 -- Pair Programming
- 15:00 - 15:15 -- Pause
- 15:15 - 16:00 -- Coding
- 16:00 - Ende  -- Besprechung, Fragen, Feedback
