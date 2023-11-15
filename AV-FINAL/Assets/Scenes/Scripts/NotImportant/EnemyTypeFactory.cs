using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeAFactory : EnemyFactory
{

    private Player player;

    public override IEnemy CreateEnemy()
    {
        return new EnemyTypeA();
    }


public class EnemyTypeA : IEnemy
{
    public void Attack()
    {
        
    }

    public void PowerLvl()
    {
            
    }

    public void CreateEnemy()
        {
            EnemyFactory factory = new EnemyTypeAFactory();
            IEnemy enemy = factory.CreateEnemy();
           


        }

    }
}