using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class JSONTrack
{
    public BeatMapLane[] bml;


}



[Flags]
public enum NoteDifficulty
{
    NONE = (int)Bits.Bit1,//1 << 0, // 1
    EASY = (int)Bits.Bit2,//1 << 1, // 2
    MEDIUM = (int)Bits.Bit3,//1 << 2, // 4
    HARD = (int)Bits.Bit4,//1 << 3  // 8
}

[Serializable]
public class BeatMapNote
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BeatMapNote(int laneIndex, int noteIndex)
    {
        LaneIndex = laneIndex;
        NoteIndex = noteIndex;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BeatMapNote GetNewDeepCopy()
    {
        BeatMapNote copy = new BeatMapNote(LaneIndex, NoteIndex);

        copy.IsActive = this.IsActive;
        copy.Difficulty = this.Difficulty;
        copy.IsEndOfTrack = this.IsEndOfTrack;

        return copy;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(BeatMapNote note)
    {
        note.IsActive = IsActive;
        note.Difficulty = Difficulty;
    }

    public bool IsActive = false;
    public bool IsEndOfTrack = false;
    public NoteDifficulty Difficulty = NoteDifficulty.NONE;

    public int LaneIndex;
    public int NoteIndex;
}

[Serializable]
public class BeatMapLane
{
    public BeatMapNote[] Notes = Array.Empty<BeatMapNote>();
    public int Length => Notes.Length;

    //// NOTE(WSWhitehouse): Overloading [] operator for easy access to 
    //// note array. Mainly used in the BeatMap as a simple 2D array.
    //public BeatMapNote this[int i]
    //{
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    get => Notes[i];

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    set => Notes[i] = value;
    //}
}
