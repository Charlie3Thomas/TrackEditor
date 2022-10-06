using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class TrackGizmos : MonoBehaviour
{
    [SerializeField] private float track_width; // visual width of the UI in editor
    [SerializeField] private int track_length = 1; // minutes
    [SerializeField] private int track_bpm = 60; // beats per minute
    [SerializeField] public float bpm_gap = 1.0f; // offset in world space for each beat in track
    private int total_beats;

    private void OnEnable()
    {
        total_beats = track_length * track_bpm;
    }

    private void OnDrawGizmos()
    {
        // Draw a line for each beat X+1 further in world space for each beat
        float line_dist = total_beats * bpm_gap;

        //Draw Left side boundaries
        Vector3 r_dest = transform.position + new Vector3(0, 0, line_dist);
        Handles.color = Color.magenta;
        Handles.DrawLine(transform.position, r_dest, 2.0f);

        //Draw Right side boundaries
        Vector3 l_dest = transform.position + new Vector3(6, 0, line_dist);
        Handles.color = Color.green;
        Handles.DrawLine(transform.position + new Vector3(6, 0, 0), l_dest, 2.0f);

        Vector3 offset_left = new Vector3(0, 0, 0);
        Vector3 offset_right = new Vector3(6, 0, 0);

        // Draw lines across each beat position in X
        for (int z = 0; z < total_beats; z++)
        {
            Vector3 offset_forward = new Vector3(0, 0, z * bpm_gap);
            Handles.color = Color.blue;
            Handles.DrawLine(
                transform.position + offset_left + offset_forward, 
                transform.position + offset_right + offset_forward);
        }


        // Draw positions for notes
        float half_bpm_gap = 0.5f * bpm_gap;
        for (int z = 0; z < total_beats; z++)
        {
            Vector3 offset_forward = new Vector3(0, 0, z * bpm_gap);
            // Draw note position 1
            Gizmos.DrawWireCube(transform.position + new Vector3(1, 0, 0) + offset_left + offset_forward, new Vector3(bpm_gap, half_bpm_gap, half_bpm_gap));
            // Draw note position 2
            Gizmos.DrawWireCube(transform.position + new Vector3(3, 0, 0) + offset_left + offset_forward, new Vector3(bpm_gap, half_bpm_gap, half_bpm_gap));
            // Draw note position 3
            Gizmos.DrawWireCube(transform.position + new Vector3(5, 0, 0) + offset_left + offset_forward, new Vector3(bpm_gap, half_bpm_gap, half_bpm_gap));
        }
    }
}
