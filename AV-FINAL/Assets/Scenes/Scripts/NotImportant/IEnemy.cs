using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : MonoBehaviour
{
   
    public interface IEnemys
    {
        void Attack();
        void PowerLvl();
    }

}
