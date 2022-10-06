using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Note : MonoBehaviour
{
    [SerializeField] public int difficulty = 1;
    [SerializeField] private Vector2 position; // position.x is note (ws.x), position.y is beat (ws.z)

    public int GetDifficulty()
    {
        return difficulty;
    }

    public Vector2 GetPos()
    {
        return position;
    }

    // Set private position to match worldspace X and Y coords
    void OnValidate()
    {
        position.x = transform.position.x; // note
        position.y = transform.position.z; // beat
    }

    private void OnEnable()
    {
        WriteFile.all_notes.Add(this); // Add to list of all notes in WriteFile
        transform.SetParent(FindObjectOfType<TrackGizmos>().transform); // Set parent to TrackGizmos object
    }

    private void OnDisable()
    {
        WriteFile.all_notes.Remove(this);
    }
}
