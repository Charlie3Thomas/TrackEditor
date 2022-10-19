using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONMono : MonoBehaviour
{
    private void Start()
    {
        JSONTrack json_track = new JSONTrack();
        json_track.bml = new BeatMapLane[]{ GenerateBeats(), GenerateBeats(), GenerateBeats() };



        string s = JsonUtility.ToJson(json_track);
        Debug.Log("HELLO THIS IS THE TIHNHWE WANTT TO LOOK AT" + s);
    }

    public BeatMapLane GenerateBeats()
    {
        List<BeatMapNote> beatmapnote_list = new List<BeatMapNote>();

        //for (int lane_index = 0; lane_index < 3; lane_index++)
        {
            for (int note_index = 0; note_index < 5; note_index++)
            {
                BeatMapNote bmn = new BeatMapNote(note_index, 1 /*CHANGE FOR LOCAL PLAYER LANE INDEX*/);
                bmn.IsActive = true;
                if (note_index == 4) { bmn.IsEndOfTrack = true; }
                bmn.Difficulty = NoteDifficulty.HARD;
                beatmapnote_list.Add(bmn);
            }
        }

        BeatMapLane _bml = new BeatMapLane();
        _bml.Notes = beatmapnote_list.ToArray();
        return _bml;
    }
}
