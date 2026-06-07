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

Klasa `Ticket` stanowi bazę dla wszystkich typów zgłoszeń i definiuje wspólne właściwości oraz zachowania.

### Dziedziczenie

Typy zgłoszeń:

- `BugTicket`
- `FeatureRequestTicket`
- `TechnicalTicket`

dziedziczą po klasie bazowej `Ticket`.

### Polimorfizm

Metoda:

```csharp
GetEstimatedResolutionTime()
```

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
