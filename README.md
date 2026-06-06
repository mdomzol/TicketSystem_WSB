# System obsługi zgłoszeń (TicketSystem)

## 📌 Opis projektu

System obsługi zgłoszeń (TicketSystem) to aplikacja konsolowa napisana w języku C#,
która symuluje prosty system typu helpdesk / IT support.

Użytkownik może tworzyć zgłoszenia (ticket), zarządzać nimi oraz zmieniać ich status.
Projekt został wykonany w ramach zajęć z Programowania Obiektowego.

---

## 🎯 Funkcjonalności

- tworzenie zgłoszeń (ticketów)
- obsługa różnych typów zgłoszeń:
  - zgłoszenie błędu (Bug)
  - zgłoszenie techniczne
  - prośba o nową funkcjonalność
- zmiana statusu zgłoszenia (Otwarte / W trakcie / Zamknięte)
- przypisywanie zgłoszeń do użytkowników
- wyświetlanie listy zgłoszeń
- przechowywanie danych w pamięci (bez bazy danych)

---

## 🧱 Struktura projektu

Projekt został zaprojektowany zgodnie z zasadami programowania obiektowego (OOP).

### 🔹 Interfejsy
- `ITicketRepository` – odpowiedzialny za operacje na danych (CRUD dla ticketów)
- `ITicketService` – logika biznesowa systemu zgłoszeń

### 🔹 Klasy abstrakcyjne
- `Ticket` – klasa bazowa dla wszystkich typów zgłoszeń

### 🔹 Klasy finalne (sealed)
- `BugTicket` – zgłoszenie błędu systemu
- `FeatureRequestTicket` – prośba o nową funkcjonalność
- `TechnicalTicket` – zgłoszenie problemu technicznego

### 🔹 Warstwa logiki
- `TicketService` – implementacja logiki biznesowej

### 🔹 Repozytorium danych
- `InMemoryTicketRepository` – przechowywanie zgłoszeń w pamięci

---

## 🧠 Zastosowane zasady OOP

### 🔒 Hermetyzacja
Dane zgłoszeń są chronione i mogą być modyfikowane tylko poprzez metody klasy,
np. zmiana statusu (`Close()`, `Assign()`), a nie bezpośrednio przez pola.

### 🧬 Dziedziczenie
Wszystkie typy zgłoszeń dziedziczą po klasie abstrakcyjnej `Ticket`.

### 🔄 Polimorfizm
Różne typy zgłoszeń mogą posiadać odmienne zachowania,
np. różny priorytet lub szacowany czas realizacji.

---

## 🧪 Testy

Projekt zawiera testy jednostkowe (xUnit lub NUnit), obejmujące:

- tworzenie zgłoszeń
- zmianę statusu zgłoszenia
- przypisywanie zgłoszeń
- walidację reguł biznesowych (np. brak edycji zamkniętego zgłoszenia)

---

## 🛠️ Technologie

- C#
- .NET (aplikacja konsolowa)
- xUnit / NUnit (testy jednostkowe)

---

## 🚀 Uruchomienie projektu

1. Sklonuj repozytorium:
```bash
git clone https://github.com/twoj-username/TicketSystem.git
