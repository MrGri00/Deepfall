using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public static class ScoreDatabase
{
    private static string dbName = "URI=file:ScoreDatabase.db";

    public static void CreateDB()
    {
        using (SqliteConnection connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS scores (nickname VARCHAR(20), score INT);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public static void DBAddScore(string playerName, int playerScore)
    {
        using (SqliteConnection connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO scores (nickname, score) VALUES ('" + playerName + "', '" + playerScore + "');";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public static void DBDisplayTopScores()
    {
        using (SqliteConnection connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM scores;";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Debug.Log("Name: " + reader["nickname"] + "\tDamage: " + reader["score"]);
                    }
                }
            }

            connection.Close();
        }
    }
}
