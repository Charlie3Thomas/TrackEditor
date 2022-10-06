using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class NotePositionSnap
{
    const string UNDO_STR_SNAP = "object(s) snap.";

    // Unity->Edit->Snap Selected Objects(s)
    [MenuItem("Edit/Snap Selected Notes(s)")]
    public static void SnapNotes()
    {
        Debug.Log("Snapping");
        foreach (GameObject _go in Selection.gameObjects)
        {
            Undo.RecordObject(_go.transform, UNDO_STR_SNAP); // record transform pre-change
            _go.transform.position = _go.transform.position.RoundV3(); // apply change to transform
        }
    }
}
