using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ExtensionMethods
{

    // Rounds Vector3 position to be to the nearest note position
    public static Vector3 RoundV3(this Vector3 _v)
    {
        // Round X to nearest 1, 3 or 5
        if (_v.x < 2f)
        {
            // Set X to position 1
            _v.x = 1;
        }
        if (_v.x >= 2f && _v.x < 4)
        {
            // Set X to position 2
            _v.x = 3;
        }
        if (_v.x >= 4)
        {
            // Set X to position 3
            _v.x = 5;
        }

        // Floor Y at 0
        _v.y = 0;

        // Round Z to nearest BPM step gap
        _v.z = Mathf.Round(_v.z * 2) / 2;

        return _v;
    }
}
