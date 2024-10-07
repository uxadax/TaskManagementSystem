using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
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
            labelZurichTime.Text = GetZurichTime();
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
                    LoadTasks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Hinzufügen der Aufgabe: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Benutzer aus.");
            }
        }

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
                    LoadTasks();
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dataGridViewTasks.SelectedRows[0].Cells["Id"].Value);
                try
                {
                    _taskRepository.DeleteTask(taskId);
                    LoadTasks();
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

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxNewUser.Text))
            {
                User newUser = new User { UserName = textBoxNewUser.Text };
                _userRepository.AddUser(newUser);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen Benutzernamen ein.");
            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedValue != null)
            {
                int userId = (int)comboBoxUsers.SelectedValue;
                try
                {
                    _userRepository.DeleteUser(userId);
                    LoadUsers();
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

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "CSV Datei speichern";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var tasks = _taskRepository.GetTaskViewModels();
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("Id,Title,Description,CreateDate,IsCompleted,UserId,UserName");
                    foreach (var task in tasks)
                    {
                        writer.WriteLine($"{task.Id},{task.Title},{task.Description},{task.CreateDate},{task.IsCompleted},{task.UserId},{task.UserName}");
                    }
                }
            }
        }

        private string GetZurichTime()
        {
            // Placeholder: Hier müsste eine API-Abfrage für die aktuelle Zeit von Zürich implementiert werden
            return DateTime.UtcNow.AddHours(2).ToString("HH:mm:ss");  // Beispiel: UTC + 2 Stunden
        }

        // Event-Handler für TextBox-Enter und Leave
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && tb.Text == tb.Tag.ToString())
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = tb.Tag.ToString();
                tb.ForeColor = Color.Gray;
            }
        }
    }
}
