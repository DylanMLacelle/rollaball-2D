using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    public static float DESPAWN_OFFSET = 50;

    /// <summary>
    /// Roll a 50/50 to see if sprite should be flipped on x
    /// </summary>
    public static bool SpriteFlip()
    {
        int rotate = (int)Mathf.Round(Random.Range(0f, 1f));
        if (rotate == 0)
        {
            return true;
        }
        return false;
    }
}
