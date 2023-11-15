using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TestScript
{
    SpaceShip spaceShip;

    [SetUp]
    public void SetUp()
    {
        spaceShip = new SpaceShip();
        spaceShip.enemyPosition = new EnemyP[10, 10];
    }
    [Test]
    public void PlayerAboard ()
    {
        
        SpaceShip spaceShip = new SpaceShip();
        PlayerP player = new PlayerP();

        
        spaceShip.player = player;

        
        Assert.AreEqual(player, spaceShip.player);
    }
    [Test]

    public void PlayerExist() 
    { 
        GameObject player = GameObject.Find("Player");
        Assert.That(player);
    }
    [Test]
    public void EnemyIsInSpaceShip()
    {
        
        SpaceShip spaceShip = new SpaceShip();
        EnemyP enemy = new EnemyP();

        // Act
        spaceShip.enemyPosition[0, 0] = enemy;

        // Assert
        Assert.AreEqual(enemy, spaceShip.enemy);
        Assert.IsInstanceOf(typeof(EnemyP), enemy);
        Assert.NotNull(spaceShip.enemyPosition[0, 0]);

    }


    [UnityTest]
    public IEnumerator TestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
