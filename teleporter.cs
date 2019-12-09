using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    enum TriggerKey
    {
        Q,
        W,
        E,
        R,
        T
    }

    // Start is called before the first frame update
    TriggerKey AssociatedKey = TriggerKey.E;

    void Start()
    {
        int keys = Enum.GetValues(typeof(TriggerKey)).Length;
        AssociatedKey = (TriggerKey)UnityEngine.Random.Range(0, keys);
        Debug.Log($"Key = {AssociatedKey}");
    }

    public bool AssociatedKeyPressed(Input key)
    {
        switch (key)
        {
            case Input.GetKeyDown("Q")
            default:
            break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
