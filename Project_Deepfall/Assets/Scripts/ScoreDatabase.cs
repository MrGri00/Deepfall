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

    public static string DBGetTopScores(int numOfScores)
    {
        string highscore = "";

        using (SqliteConnection connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM scores ORDER BY score DESC;";

                int iteration = 0;

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highscore += reader["nickname"] + "\t" + reader["score"] + "\n";

                        iteration++;

                        if (iteration >= numOfScores) { break; }
                    }

                    reader.Close();
                }
            }

            connection.Close();
        }

        return highscore;
    }
}
