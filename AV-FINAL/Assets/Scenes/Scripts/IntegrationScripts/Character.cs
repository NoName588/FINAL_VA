using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int live = 1;
    private int powerLvl = 0;

    public int Live { get => live; set => value = live; }
    public int PowerLvl { get => powerLvl; set => value = powerLvl; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsAlive();
    }

    private bool IsAlive()
    {
        if(live == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
