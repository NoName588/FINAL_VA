using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteP : MonoBehaviour
{
    public int live = 1;
    public int powerLvl = 0;

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
        if (live == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
