using System;
using System.Linq;
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
            LoadUsers();
            LoadTasks();
        }

        private void LoadTasks()
        {
            var taskViewModels = _taskRepository.GetTaskViewModels();
            dataGridViewTasks.DataSource = taskViewModels;
        }

        private void LoadUsers()
        {
            var users = _userRepository.GetUsers();
            comboBoxUsers.DataSource = users;
            comboBoxUsers.DisplayMember = "UserName";
            comboBoxUsers.ValueMember = "Id";
        }

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
                    CreateDate = DateTime.Now,  // Verwende CreateDate
                    UserId = selectedUserId
                };

                try
                {
                    _taskRepository.AddTask(task);
                    LoadTasks();
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
    }
}
