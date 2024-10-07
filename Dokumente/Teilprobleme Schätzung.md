# 🛠️ Programmtechnische Teilprobleme: Schätzung von Komplexität und Aufwand

In diesem Abschnitt werden die Teilprobleme des Task Management Systems aufgelistet und anhand ihrer Komplexität und des zu erwartenden Zeitaufwands eingeschätzt. Diese Schätzungen helfen bei der Planung und Priorisierung der Entwicklungsarbeiten.

| **Teilproblem**                                                              | **Beschreibung**                                                                                                                                             | **Komplexität** | **Aufwand**         |
|------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------|--------------------|
| **1. Datenbankverbindung konfigurieren**                                      | Die Verbindungszeichenfolge (`connectionString`) wurde nicht korrekt definiert. Die Lösung besteht darin, die `App.config` zu aktualisieren und die Migrationskonfiguration anzupassen. | Mittel          | 1 Stunde           |
| **2. Benutzerverwaltung einbauen**                                            | Hinzufügen von Funktionen, um Benutzer zu erstellen, anzuzeigen und zu löschen. Anpassung der UI-Elemente für eine einfache Bedienung.                                                            | Hoch            | 2-3 Stunden        |
| **3. Aufgabenverwaltung korrigieren**                                         | Anpassen der `Task`-Modelle, um die Spalte `CreateDate` hinzuzufügen und bestehende Migrationen neu auszuführen.                                                                                   | Mittel          | 1,5 Stunden        |
| **4. CSV-Exportfunktion implementieren**                                      | Einbinden einer Exportfunktion, die alle vorhandenen Aufgaben als CSV-Datei speichert. Implementieren eines Dialogs zum Auswählen des Speicherorts.                                               | Mittel          | 2 Stunden          |
| **5. Grafische Benutzeroberfläche anpassen**                                  | Anpassung der Textboxen, Buttons und Labels für ein sauberes Layout. Sicherstellen, dass alle Beschriftungen korrekt angezeigt werden und die Platzierung den Anforderungen entspricht.           | Niedrig         | 1 Stunde           |
| **6. Placeholder-Text für Eingabefelder hinzufügen**                          | Einfügen von `PlaceholderText` für Textfelder wie `Title` und `Description`. Dabei sicherstellen, dass der Text beim Klicken verschwindet.                                                         | Niedrig         | 30 Minuten         |
| **7. Button-Event-Handler für Benutzerverwaltung korrigieren**                | Die Buttons `Benutzer hinzufügen` und `Benutzer löschen` müssen mit den entsprechenden Methoden verknüpft werden.                                                                                 | Mittel          | 1 Stunde           |
| **8. Migrationsfehler bei Model-Änderungen beheben**                           | Beheben von Migrationsfehlern (z. B. `There is already an object named 'Tasks' in the database`) durch Löschen der bestehenden Datenbank und vollständige Neuerstellung der Migrationen.           | Hoch            | 2 Stunden          |
| **9. Fehler beim Model `User` beheben**                                        | Fehlende Definitionen wie `User.Name` führen zu Compiler-Fehlern. Korrektur der Model-Klassen und Neu-Durchführung der Migrationen.                                                                 | Mittel          | 1,5 Stunden        |
| **10. Exportfunktion und Datei-Dialoge einfügen**                              | Integration eines Dialogs, um den Speicherort für die CSV-Datei auszuwählen. Dazu Anpassung der Methode `ExportTasksToCSV` im Backend und die Zuordnung zu einem Button.                           | Mittel          | 1 Stunde           |
| **11. Platzierung der Buttons korrigieren und Anpassungen im `Form1.Designer`** | Buttons für Benutzerverwaltung und CSV-Export müssen neu positioniert und in ihrer Größe angepasst werden, um die Labels und Text korrekt anzuzeigen.                                              | Niedrig         | 45 Minuten         |

## 🧠 **Komplexitäts-Skala**:
- **Niedrig**: Der Aufwand beschränkt sich auf einfache Änderungen an der UI oder kleinere Anpassungen im Code.
- **Mittel**: Der Aufwand erfordert sowohl UI- als auch Backend-Änderungen sowie Migrationen.
- **Hoch**: Es sind umfassende Änderungen am Code, Migrationen und Anpassungen an mehreren Klassen und Dateien notwendig.

## ⏲️ **Aufwands-Schätzung**:
- Der geschätzte Aufwand ist die erwartete Arbeitszeit zur Behebung des Teilproblems. Die Schätzungen basieren auf typischen Entwicklungszyklen, können aber je nach Komplexität der Implementierung variieren.
