﻿namespace QuizHut.Data.Validations
{
    internal static class DataValidation
    {
        internal static class Answer
        {
            internal const int TextMaxLength = 1000;
        }

        internal static class Question
        {
            internal const int TextMaxLength = 1000;
        }

        internal static class Category
        {
            internal const int NameMaxLength = 50;
        }

        internal static class Group
        {
            internal const int NameMaxLength = 50;
        }

        internal static class Quiz
        {
            internal const int NameMaxLength = 1000;
            internal const int PasswordMaxLength = 10;
        }
    }
}
