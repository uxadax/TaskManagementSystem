# 🛠️ Programmtechnische Teilprobleme und Lösungen

In diesem Abschnitt werden die wichtigsten technischen Herausforderungen des Task Management Systems erläutert. Jede Herausforderung wird separat aufgeführt und die entsprechenden Lösungen sowie deren Implementierung beschrieben.

## 1. 🗄️ **Datenbankverbindung konfigurieren**
### **Problem**:
Bei der ersten Ausführung des Projekts wurde keine Verbindung zur Datenbank hergestellt. Dies führte zu Fehlern wie `No connection string named 'TaskManagementSystemConnection' could be found`.

### **Ursache**:
Die Verbindungszeichenfolge in der `App.config` war entweder nicht korrekt definiert oder nicht vorhanden.

### **Lösung**:
- Hinzufügen einer `connectionString`-Definition in der `App.config`:
  
  ```xml
  <connectionStrings>
      <add name="TaskManagementDB"
           connectionString="Server=DEIN_SERVER;Database=TaskManagementDB;Trusted_Connection=True;"
           providerName="System.Data.SqlClient" />
  </connectionStrings>
  ```

- Überprüfen der Migrationskonfiguration und der `AppDbContext`-Klasse, um sicherzustellen, dass die Verbindungszeichenfolge korrekt referenziert wird.

### **Implementierung**:
Die Änderungen wurden in `App.config` vorgenommen und alle Migrationen neu ausgeführt.

---

## 2. 👤 **Benutzerverwaltung**
### **Problem**:
Es war nicht möglich, neue Benutzer über das GUI hinzuzufügen, und die vorhandenen Benutzer konnten nicht gelöscht werden. Dies führte zu Problemen beim Zuweisen von Aufgaben.

### **Ursache**:
Fehlende Implementierung der Benutzerverwaltung und falsche Zuordnung der Steuerelemente (z. B. `comboBoxUsers`).

### **Lösung**:
- Implementieren einer Methode zur Erstellung, Bearbeitung und Löschung von Benutzern in der `UserRepository.cs`.
- Anpassen des Formulars (`Form1.cs`), um die Änderungen korrekt im GUI anzuzeigen und zu verarbeiten.

### **Implementierung**:
- Eine neue Funktion `AddUser` wurde in der `UserRepository` erstellt:
  
  ```csharp
  public void AddUser(User user)
  {
      _context.Users.Add(user);
      _context.SaveChanges();
  }
  ```

- Ein entsprechendes Ereignis-Handler für den Button `Benutzer hinzufügen` wurde im `Form1.cs` hinzugefügt.

---

## 3. ✅ **Aufgabenverwaltung**
### **Problem**:
Die `CreateDate`-Spalte wurde nicht korrekt in der Datenbank gespeichert, und das Bearbeiten der Aufgaben führte zu Konflikten mit den `Foreign Key`-Beziehungen.

### **Ursache**:
Das Modell `Task` enthielt keine `CreateDate`-Definition, und die Beziehung zur `User`-Tabelle war nicht eindeutig festgelegt.

### **Lösung**:
- Anpassen des `Task`-Modells:
  
  ```csharp
  public class Task
  {
      public int Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public DateTime CreateDate { get; set; } // Hinzufügen der fehlenden Spalte
      public bool IsCompleted { get; set; }
      public int UserId { get; set; }
      public virtual User User { get; set; }
  }
  ```

- Sicherstellen, dass alle Migrationen korrekt angewendet wurden, indem `Update-Database` ausgeführt wurde.

### **Implementierung**:
- Alle Referenzen auf `DueDate` in `CreateDate` geändert und die `TaskRepository`-Klasse aktualisiert, um `CreateDate` korrekt zu handhaben.

---

## 4. 🗂️ **CSV-Exportfunktion implementieren**
### **Problem**:
Die CSV-Exportfunktion war nicht vorhanden, und es war unklar, wie der Speicherort über das GUI definiert werden kann.

### **Ursache**:
Keine Methode für den CSV-Export und kein Dialogfenster zur Auswahl des Speicherorts.

### **Lösung**:
- Implementieren einer neuen Methode `ExportTasksToCSV` in `TaskRepository`:
  
  ```csharp
  public void ExportTasksToCSV(string filePath)
  {
      var tasks = GetTasks();
      using (StreamWriter writer = new StreamWriter(filePath))
      {
          writer.WriteLine("Id,Title,Description,CreateDate,IsCompleted,UserId,UserName");
          foreach (var task in tasks)
          {
              writer.WriteLine($"{task.Id},{task.Title},{task.Description},{task.CreateDate},{task.IsCompleted},{task.UserId},{task.User.Name}");
          }
      }
  }
  ```

- Hinzufügen eines `SaveFileDialog`-Fensters, um den Speicherort im GUI auszuwählen:
  
  ```csharp
  private void buttonExportCSV_Click(object sender, EventArgs e)
  {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
          _taskRepository.ExportTasksToCSV(saveFileDialog.FileName);
          MessageBox.Show("Export erfolgreich!");
      }
  }
  ```

### **Implementierung**:
Ein neuer Button `Export CSV` wurde zum Formular hinzugefügt, und die Methode wurde auf den Button-Klick-Ereignis-Handler gebunden.

---

## 5. 🔄 **Grafische Benutzeroberfläche anpassen**
### **Problem**:
Das Layout des Formulars war unübersichtlich, und die Beschriftungen waren entweder falsch oder verdeckt.

### **Ursache**:
Falsche Positionierung der Steuerelemente und Größenbeschränkungen für Textfelder und Buttons.

### **Lösung**:
- Anpassen der `Form1.Designer.cs`-Datei, um die Textfelder, Buttons und Labels korrekt auszurichten.
- Vergrößern der Button-Elemente und Labels, um vollständigen Text anzuzeigen (z. B. `Benutzer hinzufügen`).

### **Implementierung**:
- Manuelle Bearbeitung der `Form1.Designer.cs`:

  ```csharp
  this.buttonAddUser.Size = new System.Drawing.Size(150, 30);  // Breite angepasst
  this.buttonAddUser.Text = "Benutzer hinzufügen";  // Beschriftung korrigiert
  ```

- Verwendung von `PlaceholderText` für die Textfelder:

  ```csharp
  this.textBoxTitle.PlaceholderText = "Titel eingeben";
  this.textBoxDescription.PlaceholderText = "Beschreibung eingeben";
  ```
