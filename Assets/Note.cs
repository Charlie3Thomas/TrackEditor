using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Note : MonoBehaviour
{
    [SerializeField] public int difficulty = 1;
    private Vector2 position;

    public Vector2 GetPos()
    {
        return position;
    }

    // Set private position to match worldspace X and Y coords
    void OnValidate()
    {
        position.x = transform.position.x;
        position.y = transform.position.z;
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
