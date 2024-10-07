# 📚 **Architektur als Klassendiagramm**

## 📦 **Namespace: TaskManagementSystem**

### **1. Class `Form1`**
- **Beschreibung**: 
  - Verwaltet die grafische Benutzeroberfläche (GUI) der Anwendung und enthält alle Event-Handler für die Benutzerinteraktionen.
- **Attribute**:
  - `_taskRepository: TaskRepository`  
  - `_userRepository: UserRepository`  
- **Methoden**:
  - `LoadTasks()`  
  - `LoadUsers()`  
  - `buttonCreate_Click(sender: object, e: EventArgs)`  
  - `buttonUpdate_Click(sender: object, e: EventArgs)`  
  - `buttonDelete_Click(sender: object, e: EventArgs)`  
  - `buttonAddUser_Click(sender: object, e: EventArgs)`  
  - `buttonDeleteUser_Click(sender: object, e: EventArgs)`  
  - `buttonExportCSV_Click(sender: object, e: EventArgs)`  

### **2. Class `TaskRepository`**
- **Beschreibung**: 
  - Verantwortlich für die Verwaltung der Aufgaben und Kommunikation mit der Datenbank.
- **Attribute**:
  - `_context: AppDbContext`
- **Methoden**:
  - `GetTasks(): List<Task>`  
  - `GetTaskViewModels(): List<TaskViewModel>`  
  - `AddTask(task: Task)`  
  - `UpdateTask(task: Task)`  
  - `DeleteTask(taskId: int)`  

### **3. Class `UserRepository`**
- **Beschreibung**: 
  - Verantwortlich für die Verwaltung der Benutzer in der Anwendung.
- **Attribute**:
  - `_context: AppDbContext`
- **Methoden**:
  - `GetUsers(): List<User>`  
  - `AddUser(user: User)`  
  - `DeleteUser(userId: int)`  

### **4. Class `AppDbContext`** *(erbt von `DbContext`)*
- **Beschreibung**: 
  - Repräsentiert den Datenbankkontext und steuert den Zugriff auf die Datenbank.
- **Attribute**:
  - `Tasks: DbSet<Task>`  
  - `Users: DbSet<User>`  

### **5. Class `Task`**
- **Beschreibung**: 
  - Definiert die Eigenschaften einer Aufgabe.
- **Attribute**:
  - `Id: int`  
  - `Title: string`  
  - `Description: string`  
  - `CreateDate: DateTime`  
  - `IsCompleted: bool`  
  - `UserId: int`  

### **6. Class `User`**
- **Beschreibung**: 
  - Definiert die Eigenschaften eines Benutzers.
- **Attribute**:
  - `Id: int`  
  - `Name: string`  

### **7. Class `TaskViewModel`**
- **Beschreibung**: 
  - ViewModel für die Anzeige der Aufgabeninformationen in der GUI.
- **Attribute**:
  - `Id: int`  
  - `Title: string`  
  - `Description: string`  
  - `CreateDate: DateTime`  
  - `IsCompleted: bool`  
  - `UserId: int`  
  - `UserName: string`  

---

## 🔄 **Beziehungen zwischen den Klassen**
1. **`Form1`** → **`TaskRepository`**, **`UserRepository`**  
   - `Form1` nutzt die Repositories, um Daten zu laden und zu manipulieren.
2. **`TaskRepository`** → **`AppDbContext`**  
   - `TaskRepository` verwendet den `AppDbContext`, um Datenbankoperationen auszuführen.
3. **`UserRepository`** → **`AppDbContext`**  
   - `UserRepository` verwendet den `AppDbContext`, um Benutzerdaten abzurufen und zu aktualisieren.
4. **`AppDbContext`** enthält die `DbSet`-Eigenschaften **`Tasks`** und **`Users`**, um die Entitäten `Task` und `User` zu verwalten.
