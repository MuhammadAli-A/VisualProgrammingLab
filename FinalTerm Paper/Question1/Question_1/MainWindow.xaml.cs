using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace QuestionnaireApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadQuestions();
        }

        public class Question
        {
            public int No { get; set; }
            public string QuestionText { get; set; }
            public string Options { get; set; }
            public string CorrectAnswer { get; set; }
            public int Marks { get; set; }
            public int TimeLimit { get; set; }
            public string Topic { get; set; }
            public string Difficulty { get; set; }
        }

        private List<Question> questions = new List<Question>();

        // Load questions from the database
        private void LoadQuestions()
        {
            questions.Clear();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QuizAppConnection"].ConnectionString;
            string query = "SELECT Id, QuestionText, Options, CorrectAnswer, Marks, TimeLimit, Topic, Difficulty FROM questions";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            No = reader.GetInt32(0),
                            QuestionText = reader.GetString(1),
                            Options = reader.GetString(2),
                            CorrectAnswer = reader.GetString(3),
                            Marks = reader.GetInt32(4),
                            TimeLimit = reader.GetInt32(5),
                            Topic = reader.GetString(6),
                            Difficulty = reader.GetString(7)
                        });
                    }

                    QuestionsDataGrid.ItemsSource = questions;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Add a new question
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a form or dialog to input new question details
            // For simplicity, let's assume we are adding a new question directly
            Question newQuestion = new Question
            {
                No = questions.Count + 1, // or use auto-incremented ID from the database
                QuestionText = "New Question",
                Options = "Option1, Option2, Option3, Option4",
                CorrectAnswer = "Option1",
                Marks = 5,
                TimeLimit = 30,
                Topic = "Math",
                Difficulty = "Medium"
            };

            questions.Add(newQuestion);
            QuestionsDataGrid.ItemsSource = null; // Reset the ItemsSource
            QuestionsDataGrid.ItemsSource = questions; // Set it again

            // Save the new question to the database
            SaveQuestionToDatabase(newQuestion);
        }

        // Update an existing question
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsDataGrid.SelectedItem != null)
            {
                Question selectedQuestion = (Question)QuestionsDataGrid.SelectedItem;
                // Open a dialog to update the selected question details
                selectedQuestion.QuestionText = "Updated Question Text";
                selectedQuestion.Options = "Updated Option1, Option2, Option3, Option4";
                selectedQuestion.CorrectAnswer = "Updated Option1";
                selectedQuestion.Marks = 10;
                selectedQuestion.TimeLimit = 45;
                selectedQuestion.Topic = "Science";
                selectedQuestion.Difficulty = "Hard";

                // Refresh the DataGrid
                QuestionsDataGrid.ItemsSource = null;
                QuestionsDataGrid.ItemsSource = questions;

                // Update the question in the database
                UpdateQuestionInDatabase(selectedQuestion);
            }
            else
            {
                MessageBox.Show("Please select a question to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Remove a selected question
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsDataGrid.SelectedItem != null)
            {
                Question selectedQuestion = (Question)QuestionsDataGrid.SelectedItem;
                questions.Remove(selectedQuestion);
                QuestionsDataGrid.ItemsSource = null;
                QuestionsDataGrid.ItemsSource = questions;

                // Delete the question from the database
                RemoveQuestionFromDatabase(selectedQuestion.No);
            }
            else
            {
                MessageBox.Show("Please select a question to remove.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Save the new question to the database
        private void SaveQuestionToDatabase(Question question)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QuizAppConnection"].ConnectionString;
            string query = "INSERT INTO questions (QuestionText, Options, CorrectAnswer, Marks, TimeLimit, Topic, Difficulty) " +
                           "VALUES (@QuestionText, @Options, @CorrectAnswer, @Marks, @TimeLimit, @Topic, @Difficulty)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@Options", question.Options);
                command.Parameters.AddWithValue("@CorrectAnswer", question.CorrectAnswer);
                command.Parameters.AddWithValue("@Marks", question.Marks);
                command.Parameters.AddWithValue("@TimeLimit", question.TimeLimit);
                command.Parameters.AddWithValue("@Topic", question.Topic);
                command.Parameters.AddWithValue("@Difficulty", question.Difficulty);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Update the question in the database
        private void UpdateQuestionInDatabase(Question question)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QuizAppConnection"].ConnectionString;
            string query = "UPDATE questions SET QuestionText = @QuestionText, Options = @Options, CorrectAnswer = @CorrectAnswer, " +
                           "Marks = @Marks, TimeLimit = @TimeLimit, Topic = @Topic, Difficulty = @Difficulty WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", question.No);
                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@Options", question.Options);
                command.Parameters.AddWithValue("@CorrectAnswer", question.CorrectAnswer);
                command.Parameters.AddWithValue("@Marks", question.Marks);
                command.Parameters.AddWithValue("@TimeLimit", question.TimeLimit);
                command.Parameters.AddWithValue("@Topic", question.Topic);
                command.Parameters.AddWithValue("@Difficulty", question.Difficulty);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Remove the question from the database
        private void RemoveQuestionFromDatabase(int questionId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QuizAppConnection"].ConnectionString;
            string query = "DELETE FROM questions WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", questionId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
