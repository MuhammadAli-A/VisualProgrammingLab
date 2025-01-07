create database quizapp;

use quizapp;


CREATE TABLE Questions (
    Id INT PRIMARY KEY IDENTITY,
    QuestionText NVARCHAR(MAX),
    Options NVARCHAR(MAX),
    CorrectAnswer NVARCHAR(255),
    Marks INT,
    TimeLimit INT, -- Time limit in minutes
    Topic NVARCHAR(255),
    Difficulty NVARCHAR(50)
);

INSERT INTO Questions (QuestionText, Options, CorrectAnswer, Marks, TimeLimit, Topic, Difficulty)
VALUES
('What is the capital of France?', 'A: Paris; B: London; C: Berlin', 'A', 5, 30, 'Geography', 'Easy'),
('What is 2+2?', 'A: 3; B: 4; C: 5', 'B', 2, 10, 'Math', 'Easy'),
('What is 21+32?', 'A: 3; B: 54; C: 5', 'B', 15, 10, 'Math', 'Medium'),
('What is 2111+3222?', 'A: 3555; B: 5333; C: 5222', 'B', 15, 10, 'Math', 'Hard');

select * from Questions
