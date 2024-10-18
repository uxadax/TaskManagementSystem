
# 📊 Zustände der Masken (Mask State Planning)
 
Diese Übersicht beschreibt die Zustände und Übergänge der verschiedenen Masken (UI-Formulare) im Task Management System. Jeder Zustand repräsentiert eine spezifische Ansicht oder Interaktion im UI.
 
## 🗂 Inhaltsverzeichnis
- [🏠 Startansicht (Home)](#home)
- [📝 Aufgabenverwaltung (Task Management)](#task-management)
- [👥 Benutzerverwaltung (User Management)](#user-management)
- [🔄 CSV-Import/Export (CSV Import/Export)](#csv-importexport)
- [⚠️ Fehler und Ausnahmen (Error States)](#error-states)
 
---
 
## 🏠 Home
### 🟢 Zustand: Startseite (`Home`)
- **Beschreibung**: Die Standardansicht, die beim Start des Programms angezeigt wird.
- **Anzeigen**:
  - Begrüßungstext: `Willkommen zum Task Management System`
  - Navigation: Schaltflächen für Aufgaben- und Benutzerverwaltung
- **Übergänge**:
  - ➡️ `Task Management`: Wenn der Benutzer auf `Aufgaben verwalten` klickt.
  - ➡️ `User Management`: Wenn der Benutzer auf `Benutzer verwalten` klickt.
 
---
 
## 📝 Aufgabenverwaltung (Task Management)
### 🟡 Zustand: Aufgabenübersicht (`Task Overview`)
- **Beschreibung**: Zeigt die Liste aller Aufgaben im DataGridView.
- **Anzeigen**:
  - Aufgabenliste: Titel, Beschreibung, Erstellungsdatum, Benutzerzuweisung
  - Schaltflächen: `Erstellen`, `Ändern`, `Löschen`
- **Aktionen**:
  - 🔘 `Erstellen`: Wechselt zum `Erstellen-Modus` (Formular wird angezeigt).
  - ✏️ `Ändern`: Markiert die Aufgabe und wechselt in den `Bearbeiten-Modus`.
  - 🗑️ `Löschen`: Entfernt die markierte Aufgabe und aktualisiert die Ansicht.
  - 🔄 `CSV Export`: Exportiert aktuelle Aufgaben in eine CSV-Datei.
  - 📥 `CSV Import`: Importiert Aufgaben aus einer ausgewählten CSV-Datei.
 
### 🔵 Zustand: Aufgabe erstellen (`Create Task`)
- **Beschreibung**: Formular zur Erstellung einer neuen Aufgabe.
- **Anzeigen**:
  - Eingabefelder: `Titel`, `Beschreibung`, Benutzerzuweisung
  - Schaltfläche: `Speichern`
- **Übergänge**:
  - 🔙 `Abbrechen`: Kehrt zur `Aufgabenübersicht` zurück.
  - ✔️ `Speichern`: Fügt die Aufgabe hinzu und wechselt zur `Aufgabenübersicht`.
 
### 🟠 Zustand: Aufgabe bearbeiten (`Edit Task`)
- **Beschreibung**: Formular zur Bearbeitung einer bestehenden Aufgabe.
- **Anzeigen**:
  - Eingabefelder: `Titel`, `Beschreibung` (vorhandene Werte werden angezeigt)
  - Schaltfläche: `Speichern`, `Abbrechen`
- **Übergänge**:
  - 🔙 `Abbrechen`: Kehrt zur `Aufgabenübersicht` zurück.
  - ✔️ `Speichern`: Speichert die Änderungen und kehrt zur `Aufgabenübersicht` zurück.
 
---
 
## 👥 Benutzerverwaltung (User Management)
### 🟢 Zustand: Benutzerübersicht (`User Overview`)
- **Beschreibung**: Zeigt die Liste aller Benutzer und ermöglicht das Hinzufügen/Löschen.
- **Anzeigen**:
  - Benutzerliste: `Benutzername`
  - Schaltflächen: `Benutzer hinzufügen`, `Benutzer löschen`
- **Aktionen**:
  - ➕ `Benutzer hinzufügen`: Wechselt in den `Benutzer erstellen`-Modus.
  - ❌ `Benutzer löschen`: Entfernt den markierten Benutzer aus der Liste.
- **Übergänge**:
  - ➡️ `Benutzer erstellen`: Wenn auf `Benutzer hinzufügen` geklickt wird.
  - 🔄 `Zurück zu Home`: Wenn der Benutzer zurück zur Startseite navigiert.
 
### 🔵 Zustand: Benutzer erstellen (`Create User`)
- **Beschreibung**: Formular zur Erstellung eines neuen Benutzers.
- **Anzeigen**:
  - Eingabefelder: `Benutzername`
  - Schaltflächen: `Speichern`, `Abbrechen`
- **Übergänge**:
  - ✔️ `Speichern`: Fügt den neuen Benutzer hinzu und kehrt zur `Benutzerübersicht` zurück.
  - 🔙 `Abbrechen`: Kehrt zur `Benutzerübersicht` zurück.
 
---
 
## 🔄 CSV-Import/Export (CSV Import/Export)
### 📤 Zustand: CSV Export (`CSV Export`)
- **Beschreibung**: Exportiert die Aufgabenliste in eine CSV-Datei.
- **Aktionen**:
  - `Datei speichern`: Wählt den Speicherort für die CSV-Datei aus.
  - `Abbrechen`: Bricht den Exportvorgang ab.
### 📥 Zustand: CSV Import (`CSV Import`)
- **Beschreibung**: Importiert Aufgaben aus einer CSV-Datei.
- **Aktionen**:
  - `Datei auswählen`: Wählt die CSV-Datei zum Import aus.
  - `Importieren`: Fügt Aufgaben zur Liste hinzu.
  - `Abbrechen`: Bricht den Importvorgang ab.
 
---
 
## ⚠️ Fehler und Ausnahmen (Error States)
### ❌ Zustand: Benutzer kann nicht gelöscht werden (`Delete User Error`)
- **Beschreibung**: Tritt auf, wenn ein Benutzer Aufgaben zugewiesen hat und daher nicht gelöscht werden kann.
- **Anzeigen**:
  - Fehlermeldung: `Benutzer kann nicht gelöscht werden, solange Aufgaben zugewiesen sind.`
- **Übergänge**:
  - 🔙 `Zurück zur Benutzerübersicht`
 
### ❌ Zustand: Keine CSV-Datei ausgewählt (`No CSV File Selected`)
- **Beschreibung**: Tritt auf, wenn im Importdialog keine Datei ausgewählt wurde.
- **Anzeigen**:
  - Fehlermeldung: `Bitte wählen Sie eine CSV-Datei aus.`
- **Übergänge**:
  - 🔙 `Zurück zum Importdialog`
 
---
 
## 📜 Lizenz
Dieses Dokument ist unter der [MIT-Lizenz](https://opensource.org/licenses/MIT) lizenziert. Weitere Informationen finden Sie in der Datei `LICENSE`.
