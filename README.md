# Ticket System – Projekt z Programowania Obiektowego

## Opis projektu

Ticket System to konsolowa aplikacja napisana w języku C#, której celem jest symulacja prostego systemu obsługi zgłoszeń (helpdesk / service desk).

Projekt został przygotowany w ramach zajęć z Programowania Obiektowego i demonstruje praktyczne zastosowanie podstawowych zasad OOP, takich jak:

- enkapsulacja,
- dziedziczenie,
- polimorfizm,
- abstrakcja,
- separacja odpowiedzialności (SRP).

Aplikacja umożliwia tworzenie oraz obsługę zgłoszeń technicznych w podziale na różne typy problemów oraz ich późniejsze przetwarzanie przez panel administracyjny.

---

## Główne funkcjonalności

### Panel klienta

- tworzenie zgłoszeń typu:
  - Bug
  - Feature Request
  - Technical Issue
- wprowadzanie tytułu i opisu zgłoszenia
- automatyczne przypisanie statusu „Open”

### Panel administratora

- przegląd wszystkich zgłoszeń w formie tabeli
- podgląd szczegółów zgłoszenia
- zmiana statusu zgłoszenia z komentarzem
- przegląd historii zmian

---

## Struktura projektu

Projekt został podzielony na warstwy:

### Models

Zawiera definicje encji domenowych:

- `Ticket` (klasa abstrakcyjna)
- klasy dziedziczące:
  - `BugTicket`
  - `FeatureRequestTicket`
  - `TechnicalTicket`
- `TicketHistoryEntry`

### Services

Warstwa logiki biznesowej:

- `TicketService` – obsługa operacji na zgłoszeniach
- zarządzanie zmianą statusów i tworzeniem zgłoszeń

### Repository

Warstwa przechowywania danych:

- `ITicketRepository`
- implementacja pamięciowa (in-memory storage)

### ConsoleUI

Warstwa interfejsu użytkownika:

- `AdminPanel`
- `ClientPanel`
- `ConsoleHelper`
- `InputHelper`
- `ConsoleMessages`

Odpowiada za komunikację z użytkownikiem oraz prezentację danych.

---

## Zastosowane mechanizmy OOP

### Abstrakcja

Klasa `Ticket` stanowi abstrakcyjną klasę bazową dla wszystkich typów zgłoszeń. Definiuje wspólne właściwości, takie jak identyfikator zgłoszenia, tytuł, opis, status oraz historię zmian. Dodatkowo deklaruje abstrakcyjną metodę `GetEstimatedResolutionTime()`, której implementacja jest wymagana w klasach pochodnych.

### Hermetyzacja

W projekcie zastosowano hermetyzację poprzez kontrolowanie dostępu do danych obiektów za pomocą właściwości oraz odpowiednich modyfikatorów dostępu.

Przykłady:

- właściwość `Id` jest dostępna wyłącznie do odczytu,
- właściwość `Priority` posiada `protected set`,
- zmiana statusu zgłoszenia odbywa się wyłącznie przez metodę `ChangeStatus()`.

### Dziedziczenie

Klasy:

- `BugTicket`
- `FeatureRequestTicket`
- `TechnicalTicket`

dziedziczą po abstrakcyjnej klasie `Ticket`, przejmując jej wspólne właściwości i zachowania, a jednocześnie rozszerzając funkcjonalność o własne implementacje.

### Polimorfizm

Polimorfizm został zrealizowany za pomocą metody:

```csharp
GetEstimatedResolutionTime()
```

Metoda ta została zadeklarowana w klasie bazowej `Ticket`, a następnie nadpisana w klasach pochodnych:

- `BugTicket` – 8 godzin,
- `TechnicalTicket` – 16 godzin,
- `FeatureRequestTicket` – 40 godzin.

Dzięki temu możliwe jest operowanie na obiektach poprzez referencję typu `Ticket` bez znajomości ich rzeczywistego typu.

### Interfejsy

W projekcie wykorzystano interfejsy:

- `ITicketRepository`
- `ITicketService`

Pozwalają one oddzielić kontrakt od implementacji oraz zwiększają elastyczność projektu poprzez możliwość łatwej podmiany implementacji poszczególnych komponentów.

### Klasa finalna

Klasa `TicketHistoryEntry` została oznaczona słowem kluczowym `sealed`.

Uniemożliwia to dalsze dziedziczenie tej klasy i zabezpiecza model historii zgłoszeń przed niekontrolowanym rozszerzaniem. Ze względu na prostą i niemutowalną strukturę obiektu dziedziczenie nie jest wymagane.

## Autorzy

- Michał Domżoł
- Bartłomiej Baumert
- Kamil Dosa
- Tomasz Barnaś
- Michał Kuśmierek

## Prowadzący

mgr inż. Arkadiusz Banasik

## Semestr

Semestr letni 2025/2026

## Informacje

Projekt wykonany w ramach przedmiotu **Programowanie Obiektowe**.

WSB Merito.

Celem projektu było zaprojektowanie i implementacja konsolowego systemu obsługi zgłoszeń (Ticket System) z wykorzystaniem podstawowych mechanizmów programowania obiektowego, takich jak dziedziczenie, polimorfizm, abstrakcja oraz enkapsulacja.
