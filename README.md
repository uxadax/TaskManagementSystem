# TaskManagementSystem

Ein einfaches Task-Management-System, das es ermöglicht, Aufgaben (Tasks) zu erstellen, anzuzeigen, zu aktualisieren und zu löschen sowie Benutzer (Users) zu verwalten. Das System nutzt eine relationale Datenbank zur Speicherung der Informationen und bietet eine Windows Forms-Benutzeroberfläche zur Interaktion.

## Inhalt

- [Beschreibung](#beschreibung)
- [Features](#features)
- [Installation](#installation)
- [Migrationen und Datenbankaktualisierung](#migrationen-und-datenbankaktualisierung)
- [Verwendung](#verwendung)
- [Projektstruktur](#projektstruktur)
- [Technologien](#technologien)
- [Problemlösungen](#problemlösungen)

## Beschreibung

Das **TaskManagementSystem** ist eine Windows Forms-Anwendung, die als Aufgaben- und Benutzerverwaltungssystem dient. Es unterstützt grundlegende CRUD-Operationen (Erstellen, Lesen, Aktualisieren und Löschen) sowohl für Aufgaben als auch für Benutzer. Die Anwendung nutzt **Entity Framework** als ORM (Object-Relational Mapping) und eine SQL Server-Datenbank zur Speicherung der Daten.

### Features

- Erstellen von Aufgaben mit Titel, Beschreibung, Fälligkeitsdatum und Status.
- Bearbeiten und Löschen von bestehenden Aufgaben.
- Verknüpfung von Aufgaben mit einem Benutzer.
- Erstellung, Anzeige und Verwaltung von Benutzern.
- Datenbindung zur Anzeige der Aufgaben in einem `DataGridView`.

## Installation

### Voraussetzungen

- **Visual Studio 2019/2022** oder höher.
- **.NET Framework 4.8** oder höher.
- **SQL Server Express** oder eine andere SQL Server-Instanz.
- NuGet-Pakete: EntityFramework

### Schritte zur Installation

1. **Clone das Repository**:
   
   ```bash
   git clone https://github.com/dein-benutzername/TaskManagementSystem.git
   cd TaskManagementSystem
   ```

2. **Öffne das Projekt in Visual Studio**:
   - Öffne `TaskManagementSystem.sln` in Visual Studio.

3. **NuGet-Pakete wiederherstellen**:
   - Klicke mit der rechten Maustaste auf das Projekt und wähle **NuGet-Pakete verwalten** > **Pakete wiederherstellen**.

4. **App.config anpassen**:
   - Stelle sicher, dass in `App.config` der korrekte SQL Server-Verbindungsstring vorhanden ist.
   
   ```xml
   <connectionStrings>
     <add name="AppDbContext" 
          connectionString="Data Source=DESKTOP-QDJ0VMJ\SQLEXPRESS;Initial Catalog=TaskManagementDB;Integrated Security=True" 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

## Migrationen und Datenbankaktualisierung

Bevor du die Anwendung ausführst, führe die Migrationen aus, um die Datenbank zu erstellen und zu aktualisieren:

1. **Migrationen aktivieren** (nur beim ersten Mal erforderlich):

   ```powershell
   Enable-Migrations
   ```

2. **Migration erstellen**:

   ```powershell
   Add-Migration InitialCreate
   ```

3. **Datenbank aktualisieren**:

   ```powershell
   Update-Database
   ```

Diese Schritte sorgen dafür, dass die Datenbankstruktur mit den Entitäten `Task` und `User` übereinstimmt.

## Verwendung

1. **Starte die Anwendung**:
   - F5 in Visual Studio drücken oder das Projekt über **Projekt** > **Starten ohne Debuggen** ausführen.

2. **Aufgaben verwalten**:
   - Fülle die Textfelder unten aus, um eine neue Aufgabe zu erstellen.
   - Wähle eine Aufgabe in der Tabelle aus und bearbeite die Details.
   - Klicke auf **Ändern**, um die Änderungen zu speichern.

3. **Benutzer hinzufügen**:
   - Füge über den Benutzerbereich neue Benutzer hinzu und verknüpfe sie mit Aufgaben.

## Projektstruktur

Die Projektstruktur ist wie folgt organisiert:

```plaintext
TaskManagementSystem/
├── DataAccess/
│   ├── AppDbContext.cs         # DbContext-Klasse für den Zugriff auf die Datenbank
│   ├── TaskRepository.cs       # Repository-Klasse für Aufgaben (CRUD-Operationen)
│   └── UserRepository.cs       # Repository-Klasse für Benutzer (CRUD-Operationen)
├── Migrations/
│   ├── Configuration.cs        # Migrationseinstellungen
│   └── [weitere Migrationen].cs # Generierte Migrationsdateien
├── Models/
│   ├── Task.cs                 # Task-Entitätsmodell
│   ├── User.cs                 # User-Entitätsmodell
│   └── TaskViewModel.cs        # ViewModel für die Anzeige von Aufgaben im DataGridView
├── Form1.cs                    # Windows Forms GUI-Logik
├── Form1.Designer.cs           # Automatisch generierter GUI-Code
├── Program.cs                  # Startpunkt der Anwendung
├── App.config                  # Konfigurationsdatei (Datenbankverbindungsstring)
└── TaskManagementSystem.sln    # Visual Studio Projektdatei
```

## Technologien

Dieses Projekt verwendet die folgenden Technologien:

- **C#** – Hauptprogrammiersprache.
- **Windows Forms** – Benutzeroberflächenentwicklung.
- **Entity Framework** – Object-Relational Mapping (ORM).
- **SQL Server** – Relationale Datenbank.
- **.NET Framework 4.8** – .NET-Laufzeitumgebung.

## Problemlösungen

### Fehler beim Hinzufügen einer Aufgabe ("An error occurred while updating the entries")

Dieser Fehler tritt häufig auf, wenn der `UserId`-Wert für die Aufgabe nicht korrekt gesetzt ist oder es eine Inkonsistenz in der Fremdschlüsselbeziehung gibt. Stellen Sie sicher, dass der `UserId`-Wert auf einen vorhandenen Benutzer verweist.

### DataGridView-Ausnahme: "Ungültige Umwandlung von 'System.String'"

Dieser Fehler tritt auf, wenn versucht wird, ein komplexes Objekt (z.B. `User`) als `string` anzuzeigen. Verwenden Sie die `TaskViewModel`-Klasse, um die Daten anzuzeigen, oder passen Sie die `DataSource` entsprechend an.

## Kontakt

Bei weiteren Fragen oder Problemen kannst du uns über GitHub erreichen.
