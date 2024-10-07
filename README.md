# 📝 Task Management System
 
Eine einfache Windows Forms-Anwendung zur Verwaltung von Aufgaben (Tasks) und Benutzern. Mit dieser Anwendung kannst du neue Aufgaben erstellen, bestehende Aufgaben bearbeiten oder löschen sowie Benutzer verwalten. Außerdem bietet die Anwendung eine CSV-Exportfunktion für alle Aufgaben.
 
## 📋 Funktionen
### 📌 Aufgabenverwaltung
- **Erstellen:** ➕ Neue Aufgaben mit Titel und Beschreibung hinzufügen.
- **Ändern:** ✏️ Vorhandene Aufgaben bearbeiten.
- **Löschen:** 🗑️ Aufgaben entfernen.
- **Benutzerzuordnung:** 👤 Aufgaben Benutzern zuweisen.
 
### 👥 Benutzerverwaltung
- **Hinzufügen:** ➕ Neue Benutzer erstellen und zu Aufgaben hinzufügen.
- **Löschen:** 🗑️ Benutzer aus der Liste entfernen.
- **Dropdown-Auswahl:** 📂 Benutzer in einer DropDown-Liste anzeigen lassen.
 
### 📤 CSV-Export
- Exportiert alle Aufgaben mit den zugeordneten Benutzern und Aufgabeninformationen in eine CSV-Datei.
- Beim Export kannst du den Speicherort und Dateinamen der CSV-Datei auswählen.
 
## 🖥️ Benutzeroberfläche
Die Anwendung bietet folgende Hauptbereiche:
 
- **🗂 DataGridView**: Anzeige aller Aufgaben, inklusive Titel, Beschreibung, Erstellungsdatum, Status (`IsCompleted`), Benutzer-ID und Benutzername.
- **✏️ Aufgabenfelder**: Eingabefelder für Titel und Beschreibung der Aufgaben.
- **👥 Benutzerauswahl**: Dropdown zur Auswahl von Benutzern.
- **👤 Benutzerverwaltungsbereich**: Bereich zum Hinzufügen und Löschen von Benutzern.
- **📤 Export-Button**: Schaltfläche zum Exportieren der Aufgabenliste als CSV-Datei.
 
## 📂 Projektstruktur
```
TaskManagementSystem/
├── DataAccess/
│   ├── AppDbContext.cs          # Datenbankkontext für Entity Framework
│   ├── TaskRepository.cs        # Repository für Aufgabenmanagement
│   └── UserRepository.cs        # Repository für Benutzermanagement
├── Migrations/
│   ├── Configuration.cs         # Konfigurationsdatei für Migrationen
│   └── <Migration-Files>.cs     # Automatisch generierte Migrationsdateien
├── Models/
│   ├── Task.cs                  # Modellklasse für Aufgaben
│   └── User.cs                  # Modellklasse für Benutzer
├── Forms/
│   ├── Form1.cs                 # Hauptform und Logik der Anwendung
│   └── Form1.Designer.cs        # Designer-Datei für die Form1-Benutzeroberfläche
├── Properties/
│   └── AssemblyInfo.cs          # Projektinformationen
├── App.config                   # Konfigurationsdatei mit Verbindungseinstellungen
├── Program.cs                   # Einstiegspunkt der Anwendung
└── README.md                    # Projektdokumentation
## 🛠️ Voraussetzungen
- **.NET Framework 4.8** oder höher
- **SQL Server Express** oder eine andere SQL Server-Instanz
 
## ⚙️ Konfiguration
1. Öffne die Datei `App.config` und stelle sicher, dass die Verbindungszeichenfolge korrekt konfiguriert ist:
    ```xml
<connectionStrings>
<add name="TaskManagementDB"
           connectionString="Server=DESKTOP-QDJ0VMJ\SQLEXPRESS;Database=TaskManagementDB;Trusted_Connection=True;"
           providerName="System.Data.SqlClient" />
</connectionStrings>
    ```
 
2. Führe die Migrationen in der `Package Manager Console` von Visual Studio aus:
    ```bash
    Enable-Migrations
    Add-Migration InitialCreate
    Update-Database
    ```
 
## 🚀 Installation und Ausführung
1. **Projekt klonen:**
    ```bash
    git clone https://github.com/uxadax/TaskManagementSystem.git
    ```
2. **Projekt öffnen:** Starte das Projekt in Visual Studio.
3. **Migration anwenden:** Stelle sicher, dass die Datenbank migriert ist (`Update-Database`).
4. **Anwendung starten:** Drücke `F5` oder klicke auf `Start`.
 
## 📤 CSV-Export
Um die Aufgabenliste als CSV zu exportieren:
 
1. Klicke auf den Button **"CSV Export"**.
2. Wähle den Speicherort und den Dateinamen.
3. Die Aufgabenliste wird als CSV-Datei gespeichert.
 
## 📥 CSV-Import
Um Aufgaben aus einer CSV-Datei zu importieren:
 
1. Klicke auf den Button **"CSV Import"**.
2. Wähle die gewünschte CSV-Datei aus.
3. Die Aufgabenliste wird entsprechend aktualisiert.
 
## 💻 Beispiel-CSV-Datei
Die CSV-Datei wird folgendes Format haben:
 
```(csv)
Id,Title,Description,CreateDate,IsCompleted,UserId,UserName
1, "Projekt erstellen", "Task Management System erstellen", "2024-10-01", false, 1, "Max Mustermann"
2, "Dokumentation schreiben", "README für das Projekt erstellen", "2024-10-02", true, 1, "Max Mustermann"
```
 
## 🔧 Fehlerbehebung
Falls die Anwendung Fehler wie `User enthält keine Definition für 'Name'` anzeigt:
 
1. Überprüfe die Datei `User.cs` im Ordner `Models` und stelle sicher, dass die Eigenschaft `Name` vorhanden ist:
    ```(csharp)
    public string Name { get; set; }
    ```
2. Falls die Datenbankfehler auftreten, stelle sicher, dass alle Migrationen korrekt angewendet wurden:
    ```(bash)
    Update-Database
    ```
 
## 📋 Zustände der Masken
Die Anwendung verwendet verschiedene Masken für die Verwaltung von Aufgaben und Benutzern:
 
- **🏠 Startseite**: Die Standardansicht beim Start der Anwendung.
- **📝 Aufgabenverwaltung**:
  - Aufgabenübersicht: Zeigt die Liste aller Aufgaben.
  - Aufgabe erstellen: Formular zum Hinzufügen einer neuen Aufgabe.
  - Aufgabe bearbeiten: Formular zur Bearbeitung einer bestehenden Aufgabe.
- **👥 Benutzerverwaltung**:
  - Benutzerübersicht: Zeigt alle vorhandenen Benutzer.
  - Benutzer erstellen: Formular zum Hinzufügen eines neuen Benutzers.
- **📥 CSV-Import/Export**:
  - CSV Export: Exportiert die Aufgaben in eine CSV-Datei.
  - CSV Import: Importiert Aufgaben aus einer CSV-Datei.
 
## 📝 Lizenz
Dieses Projekt steht unter der **MIT-Lizenz**. Weitere Informationen findest du in der `LICENSE`-Datei.
 
## 🤝 Beitrag
Beiträge zum Projekt sind willkommen! Erstelle einfach einen Pull-Request oder öffne ein Issue, um Verbesserungen und Fehler zu diskutieren.

