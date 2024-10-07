## 📜 Vorbedingungen und Nachbedingungen

### 📌 Vorbedingungen (Preconditions)
Vorbedingungen sind die notwendigen Bedingungen, die erfüllt sein müssen, bevor eine bestimmte Funktion oder Methode aufgerufen wird. Sie garantieren, dass das System in einem erwarteten Zustand ist, damit der Code korrekt ausgeführt werden kann. Im Kontext des `Task Management System` könnten folgende Vorbedingungen bestehen:

1. **Datenbankverbindung ist vorhanden:**
   - Vor dem Zugriff auf die Datenbank müssen die Verbindungsparameter in der `App.config` korrekt konfiguriert sein.
   - **Beispiel:** Die Verbindungszeichenfolge für den SQL Server sollte wie folgt aussehen:
     ```xml
     <connectionStrings>
         <add name="TaskManagementDB"
              connectionString="Server=DESKTOP-QDJ0VMJ\SQLEXPRESS;Database=TaskManagementDB;Trusted_Connection=True;"
              providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```
2. **Datenbank ist migriert:**
   - Alle Migrationen müssen angewendet sein, damit die Datenbank die erforderlichen Tabellen (`Users`, `Tasks`) und Spalten enthält.
   - **Befehl:** Führe die Migrationen mit folgendem Befehl aus:
     ```bash
     Update-Database
     ```

3. **Benutzer existieren in der Datenbank:**
   - Es müssen mindestens ein Benutzer in der `Users`-Tabelle vorhanden sein, um Aufgaben korrekt zuweisen zu können.
   - **Beispiel:** Ein Standardbenutzer wird normalerweise während der `Seed()`-Methode in der Migration hinzugefügt.

4. **Eingabewerte sind valide:**
   - Alle Eingabefelder (Titel, Beschreibung, Benutzer) müssen gültige Werte haben, bevor die Aufgabe erstellt oder bearbeitet werden kann.
   - **Beispiel:** Das Titelfeld darf nicht leer sein, und der Benutzer muss in der Dropdown-Liste ausgewählt sein.

### 📌 Nachbedingungen (Postconditions)
Nachbedingungen sind die Bedingungen, die nach der erfolgreichen Ausführung einer Funktion oder Methode erfüllt sein müssen. Sie stellen sicher, dass die Operation korrekt abgeschlossen wurde. Im `Task Management System` umfassen Nachbedingungen Folgendes:

1. **Aufgabe wird erfolgreich in der Datenbank gespeichert:**
   - Nach dem Erstellen oder Bearbeiten einer Aufgabe sollte die `Tasks`-Tabelle in der Datenbank den neuen oder aktualisierten Datensatz enthalten.
   - **Beispiel:** Eine neue Aufgabe sollte mit einem eindeutigen `Id` und den entsprechenden Benutzerinformationen in der `Tasks`-Tabelle hinzugefügt werden.

2. **Datenanzeige wird aktualisiert:**
   - Die Benutzeroberfläche (UI) muss nach jeder CRUD-Operation (Create, Read, Update, Delete) aktualisiert werden, um den aktuellen Stand der Daten anzuzeigen.
   - **Beispiel:** Nach dem Erstellen einer Aufgabe wird die `dataGridView`-Anzeige sofort aktualisiert.

3. **Benutzer wird informiert:**
   - Bei erfolgreichen Operationen (z.B. Aufgabe wurde erstellt, Benutzer wurde gelöscht) oder bei Fehlern (z.B. Eingabewerte sind nicht korrekt) wird dem Benutzer eine entsprechende Nachricht angezeigt.
   - **Beispiel:** Ein `MessageBox`-Dialog zeigt an, dass die Aufgabe erfolgreich erstellt wurde.

4. **CSV-Datei ist erfolgreich exportiert:**
   - Nach dem Klicken auf den Export-Button wird eine CSV-Datei erstellt, die alle aktuellen Aufgaben enthält, und der Benutzer wird nach dem Speicherort gefragt.
   - **Beispiel:** Der Export sollte die aktuelle `dataGridView`-Tabelle in der CSV-Datei speichern.

### 📂 Beispiel einer Methode mit Vor- und Nachbedingungen

```csharp
// Methode zum Hinzufügen einer neuen Aufgabe
public void AddTask(Task task)
{
    // Vorbedingungen prüfen
    if (string.IsNullOrEmpty(task.Title))
        throw new ArgumentException("Der Titel darf nicht leer sein.");
    if (task.UserId == 0)
        throw new ArgumentException("Ein Benutzer muss zugewiesen werden.");

    // Methode ausführen
    _context.Tasks.Add(task);
    _context.SaveChanges();

    // Nachbedingungen sicherstellen
    Debug.Assert(_context.Tasks.Any(t => t.Id == task.Id), "Die Aufgabe wurde nicht korrekt gespeichert.");
}
```

- **Vorbedingungen:** Überprüft, ob der Titel nicht leer ist und ein gültiger Benutzer ausgewählt wurde.
- **Nachbedingungen:** Stellt sicher, dass die Aufgabe nach dem Speichern in der Datenbank existiert.