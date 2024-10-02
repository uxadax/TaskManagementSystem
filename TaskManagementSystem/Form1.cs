using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskManagementSystem.Models;
using TaskManagementSystem.DataAccess;

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
            LoadTasks();
        }

        // Lädt alle Aufgaben aus der Datenbank und zeigt sie im DataGridView an
        private void LoadTasks()
        {
            var taskViewModels = _taskRepository.GetTaskViewModels();  // Verwende die angepasste ViewModel-Liste
            dataGridViewTasks.DataSource = taskViewModels;
        }

        // Event-Handler-Methode für das Erstellen einer Aufgabe
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // Beispiel: Verwende die ID eines bestehenden Benutzers
            int existingUserId = 1;

            Task task = new Task
            {
                Title = textBoxTitle.Text,
                Description = textBoxDescription.Text,
                IsCompleted = false,
                DueDate = DateTime.Now.AddDays(7),  // Beispiel-Datum
                UserId = existingUserId  // Verwende eine gültige UserId
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

        // Event-Handler-Methode für das Aktualisieren einer Aufgabe
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dataGridViewTasks.SelectedRows[0].Cells["Id"].Value);
                Task task = _taskRepository.GetTasks().Find(t => t.Id == taskId);

                task.Title = textBoxTitle.Text;
                task.Description = textBoxDescription.Text;

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
                MessageBox.Show("Bitte wählen Sie eine Aufgabe zum Ändern aus.");
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
    }
}
