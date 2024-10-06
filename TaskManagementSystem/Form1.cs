using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TaskManagementSystem.DataAccess;
using TaskManagementSystem.Models;

namespace TaskManagementSystem
{
    public partial class Form1 : Form
    {
        private TaskRepository _taskRepository;
        private UserRepository _userRepository;

        public Form1()
        {
            InitializeComponent();
            _taskRepository = new TaskRepository();
            _userRepository = new UserRepository();
            LoadUsers();
            LoadTasks();
        }

        // Lädt alle Aufgaben aus der Datenbank und zeigt sie im DataGridView an
        private void LoadTasks()
        {
            var taskViewModels = _taskRepository.GetTaskViewModels();
            dataGridViewTasks.DataSource = taskViewModels;
        }

        // Lädt alle Benutzer aus der Datenbank und fügt sie in die ComboBox ein
        private void LoadUsers()
        {
            var users = _userRepository.GetUsers();
            comboBoxUsers.DataSource = users;
            comboBoxUsers.DisplayMember = "UserName";
            comboBoxUsers.ValueMember = "Id";
        }

        // Event-Handler-Methode für das Erstellen einer Aufgabe
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedValue != null)
            {
                int selectedUserId = (int)comboBoxUsers.SelectedValue;

                Task task = new Task
                {
                    Title = textBoxTitle.Text,
                    Description = textBoxDescription.Text,
                    IsCompleted = false,
                    CreateDate = DateTime.Now,
                    UserId = selectedUserId
                };

                try
                {
                    _taskRepository.AddTask(task);
                    LoadTasks();  // Aktualisiere die Liste nach dem Hinzufügen
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Hinzufügen der Aufgabe: {ex.Message}\n\nDetails:\n{ex.InnerException?.Message}\n\nStapelüberwachung:\n{ex.StackTrace}");
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Benutzer aus.");
            }
        }

        // Event-Handler-Methode für das Aktualisieren einer Aufgabe
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0 && comboBoxUsers.SelectedValue != null)
            {
                int taskId = Convert.ToInt32(dataGridViewTasks.SelectedRows[0].Cells["Id"].Value);
                Task task = _taskRepository.GetTasks().Find(t => t.Id == taskId);

                task.Title = textBoxTitle.Text;
                task.Description = textBoxDescription.Text;
                task.UserId = (int)comboBoxUsers.SelectedValue;

                try
                {
                    _taskRepository.UpdateTask(task);
                    LoadTasks();  // Aktualisiert die Liste nach dem Ändern
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Ändern der Aufgabe: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Aufgabe und einen Benutzer zum Ändern aus.");
            }
        }

        // Event-Handler-Methode für das Löschen einer Aufgabe
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dataGridViewTasks.SelectedRows[0].Cells["Id"].Value);
                try
                {
                    _taskRepository.DeleteTask(taskId);
                    LoadTasks();  // Aktualisiert die Liste nach dem Löschen
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Löschen der Aufgabe: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Aufgabe zum Löschen aus.");
            }
        }

        // Event-Handler-Methode für das Hinzufügen eines neuen Benutzers
        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNewUser.Text))
            {
                User user = new User
                {
                    UserName = textBoxNewUser.Text
                };

                try
                {
                    _userRepository.AddUser(user);
                    LoadUsers();  // Aktualisiere die Benutzerliste
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Hinzufügen des Benutzers: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen Benutzernamen ein.");
            }
        }

        // Event-Handler-Methode für das Löschen eines Benutzers
        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedValue != null)
            {
                int userId = (int)comboBoxUsers.SelectedValue;
                try
                {
                    _userRepository.DeleteUser(userId);
                    LoadUsers();  // Aktualisiere die Benutzerliste nach dem Löschen
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Löschen des Benutzers: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Benutzer zum Löschen aus.");
            }
        }

        // Event-Handler für den Export der Aufgaben in eine CSV-Datei
        private void buttonExportToCSV_Click(object sender, EventArgs e)
        {
            try
            {
                var taskList = _taskRepository.GetTaskViewModels();

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV-Datei (*.csv)|*.csv",
                    Title = "Speichern Sie die Aufgaben als CSV-Datei",
                    FileName = "TasksExport.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        // CSV Header
                        writer.WriteLine("Id,Title,Description,CreateDate,IsCompleted,UserId,UserName");

                        // CSV Content
                        foreach (var task in taskList)
                        {
                            writer.WriteLine($"{task.Id},{task.Title},{task.Description},{task.CreateDate},{task.IsCompleted},{task.UserId},{task.UserName}");
                        }
                    }

                    MessageBox.Show("Aufgaben erfolgreich als CSV exportiert.", "Export erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Exportieren: {ex.Message}");
            }
        }

        // Platzhaltertext entfernen, wenn das Feld angeklickt wird
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "Titel eingeben" || textBox.Text == "Beschreibung eingeben" || textBox.Text == "Neuen Benutzer eingeben"))
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        // Platzhaltertext zurücksetzen, wenn das Feld verlassen wird und leer ist
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "textBoxTitle")
                    textBox.Text = "Titel eingeben";
                else if (textBox.Name == "textBoxDescription")
                    textBox.Text = "Beschreibung eingeben";
                else if (textBox.Name == "textBoxNewUser")
                    textBox.Text = "Neuen Benutzer eingeben";

                textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
