using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerP : Character
{
    ObjectP objectP = new ObjectP();
    EnemyP enemyP;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AddObject();
    }

    public void AddObject()
    {
        PowerLvl += objectP.PowerLvl;
    }

    public bool CompareLvl()
    {
        if(PowerLvl >= enemyP.PowerLvl)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
