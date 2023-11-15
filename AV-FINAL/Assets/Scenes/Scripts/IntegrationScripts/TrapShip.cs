using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShip : MonoBehaviour
{
    PlayerP player = new PlayerP();
    EnemyP enemy = new EnemyP();
    ObjectP objectP = new ObjectP();
    private int room = 0;
    private int lvlAcces = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RoomClear();
        CompareLvl();
    }

    public bool RoomClear()
    {
        if (room == 0)
            return true;
        else
            return false;
    }

    public bool CompareLvl()
    {
        if (lvlAcces <= player.PowerLvl)
            return true;
        else
            return false;
    }
}
