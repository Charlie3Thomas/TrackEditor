using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class WriteFile : MonoBehaviour
{
    [SerializeField] private string track_name = "a";
    public static List<Note> all_notes = new List<Note>();
    private int[,] data;
    int total_beats;

    // Start is called before the first frame update
    void Start()
    {
        if (all_notes.Count == 0) { Debug.Log("Notes are empty"); }
        else { Debug.Log("Notes count: " + all_notes.Count); }

        total_beats = FindObjectOfType<TrackGizmos>().GetTotalBeats(); // Get Total Beats from TrackGizmos object
        data = new int[3, total_beats]; // Create an array of width 3 and length Total Beats

        // For each possible note for each beat, populate data array with empry spot
        for (int _beat = 0; _beat < x; _beat++)
        {
            // For each note per beat
            for (int _note = 0; _note < 3; _note++)
            {
                data[_note, _beat] = 0;
            }
        }

        // Create Output Folder
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Track_Files/");
        CreateTextFile(total_beats);
    }

    public void CreateTextFile(int _total_beats)
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
            for (int _beat = 0; _beat < _total_beats; _beat++)
            {
                // For each note per beat
                var notes = new StringBuilder();
                for (int _note = 0; _note < 3; _note++)
                {
                    notes.Append(data[_note, _beat].ToString()); // Add note to notes for beat n
                }

                beat.AppendLine(notes.ToString()); // Add notes for beat n to new line
            }

            File.WriteAllText(txt_document_name, beat.ToString());
        }
    }
}
