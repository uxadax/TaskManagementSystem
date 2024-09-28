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
            List<Task> tasks = _taskRepository.GetTasks();
            dataGridViewTasks.DataSource = tasks;
        }

        // Aufgabe hinzufügen
        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            int existingUserId = 1;  // Setze hier eine gültige UserId

            Task task = new Task
            {
                Title = textBoxTitle.Text,
                Description = textBoxDescription.Text,
                IsCompleted = false,
                DueDate = DateTime.Now.AddDays(7),  // Beispiel-Datum
                UserId = existingUserId  // Setze hier eine gültige UserId
            };

            try
            {
                _taskRepository.AddTask(task);
                LoadTasks();  // Aktualisiere die Liste nach dem Hinzufügen
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Hinzufügen der Aufgabe: {ex.Message}\n\nDetails:\n{ex.InnerException?.Message}");
            }
        }

        // Aufgabe ändern
        private void buttonUpdateTask_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dataGridViewTasks.SelectedRows[0].Cells["Id"].Value);
                Task task = _taskRepository.GetTasks().Find(t => t.Id == taskId);

                task.Title = textBoxTitle.Text;
                task.Description = textBoxDescription.Text;

                _taskRepository.UpdateTask(task);
                LoadTasks();  // Aktualisiert die Liste nach dem Ändern
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Aufgabe zum Ändern aus.");
            }
        }

        // Aufgabe löschen
        private void buttonDeleteTask_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dataGridViewTasks.SelectedRows[0].Cells["Id"].Value);
                _taskRepository.DeleteTask(taskId);
                LoadTasks();  // Aktualisiert die Liste nach dem Löschen
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Aufgabe zum Löschen aus.");
            }
        }
    }
}
