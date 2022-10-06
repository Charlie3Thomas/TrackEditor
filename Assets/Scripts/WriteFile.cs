using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class WriteFile : MonoBehaviour
{
    [SerializeField] private string track_name = "a";
    public static List<Note> all_notes = new List<Note>();
    private int[,] data; // Beat, Note
    int total_beats;

    private void PopulateNoteData()
    {
        foreach(Note note in all_notes)
        {
            // Normalise note position
            // x is note, y is beat
            Vector2 pos = note.GetPos();
            int x = 0;
            int y = (int)(pos.y * 2);
            switch (pos.x)
            {
                case 1:
                    x = 0;
                    break;
                case 3:
                    x = 1;
                    break;
                case 5:
                    x = 2;
                    break;
            };

            data[y, x] = note.GetDifficulty();

        }
    }

    private void SetupData()
    {
        total_beats = FindObjectOfType<TrackGizmos>().GetTotalBeats(); // Get Total Beats from TrackGizmos object
        data = new int[total_beats, 3]; // Create an array of width 3 and length Total Beats

        // For each possible note for each beat, populate data array with empry spot
        for (int b = 0; b < total_beats; b++)
        {
            // For each note per beat
            for (int n = 0; n < 3; n++)
            {
                data[b, n] = 0;
            }
        }
    }

    private void CreateTextFile(int _total_beats)
    {
        TimeSpan t = DateTime.UtcNow - new DateTime(1997, 5, 1);
        int t_since_epoch = (int)t.TotalSeconds;
        
        // Create text file in directory "/Track_Files/" 
        string txt_document_name = Application.streamingAssetsPath + "/Track_Files/" + track_name + t_since_epoch + ".txt";

        // Only create file if it does not exist
        if (!File.Exists(txt_document_name))
        {
            Debug.Log("Generating text file");

            // For every beat
            var beat = new StringBuilder();
            for (int b = 0; b < _total_beats; b++)
            {
                // For each note per beat
                var notes = new StringBuilder();
                for (int n = 0; n < 3; n++)
                {
                    notes.Append(data[b, n].ToString()); // Add note to notes for beat n
                }

                beat.AppendLine(notes.ToString()); // Add notes for beat n to new line
            }

            File.WriteAllText(txt_document_name, beat.ToString());
        }
    }

    void Start()
    {
        if (all_notes.Count == 0) { Debug.Log("Notes are empty"); } // Debugging notes count
        else { Debug.Log("Notes count: " + all_notes.Count); }
        
        SetupData(); // Set up data array of appropriate size
        PopulateNoteData(); // Populate data array with notes

        Directory.CreateDirectory(Application.streamingAssetsPath + "/Track_Files/"); // Create Output Folder
        CreateTextFile(total_beats);
    }
}
