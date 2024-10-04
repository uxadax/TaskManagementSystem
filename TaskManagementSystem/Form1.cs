using System;
using System.Collections.Generic;
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

        // Event-Handler-Methode für das Hinzufügen eines neuen Benutzers
        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            string newUserName = textBoxNewUser.Text.Trim();

            if (!string.IsNullOrWhiteSpace(newUserName))
            {
                User newUser = new User { UserName = newUserName };

                try
                {
                    _userRepository.AddUser(newUser);
                    LoadUsers();  // Aktualisiere die Benutzerliste nach dem Hinzufügen
                    textBoxNewUser.Clear();  // Eingabefeld leeren
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Hinzufügen des Benutzers: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Benutzernamen ein.");
            }
        }

        // Event-Handler-Methode für das Löschen eines Benutzers
        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedValue != null)
            {
                int selectedUserId = (int)comboBoxUsers.SelectedValue;

                try
                {
                    _userRepository.DeleteUser(selectedUserId);
                    LoadUsers();  // Aktualisiere die Benutzerliste nach dem Löschen
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Löschen des Benutzers: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Benutzer aus.");
            }
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
                    CreateDate = DateTime.Now,  // Neuer Name für das Feld
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

        // Placeholder-Text bei "Enter" entfernen
        private void textBoxTitle_Enter(object sender, EventArgs e)
        {
            if (textBoxTitle.Text == "Titel eingeben")
            {
                textBoxTitle.Text = "";
                textBoxTitle.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxTitle_Leave(object sender, EventArgs e)
        {
            if (textBoxTitle.Text == "")
            {
                textBoxTitle.Text = "Titel eingeben";
                textBoxTitle.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void textBoxDescription_Enter(object sender, EventArgs e)
        {
            if (textBoxDescription.Text == "Beschreibung eingeben")
            {
                textBoxDescription.Text = "";
                textBoxDescription.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxDescription_Leave(object sender, EventArgs e)
        {
            if (textBoxDescription.Text == "")
            {
                textBoxDescription.Text = "Beschreibung eingeben";
                textBoxDescription.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void textBoxNewUser_Enter(object sender, EventArgs e)
        {
            if (textBoxNewUser.Text == "Neuen Benutzer eingeben")
            {
                textBoxNewUser.Text = "";
                textBoxNewUser.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxNewUser_Leave(object sender, EventArgs e)
        {
            if (textBoxNewUser.Text == "")
            {
                textBoxNewUser.Text = "Neuen Benutzer eingeben";
                textBoxNewUser.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
