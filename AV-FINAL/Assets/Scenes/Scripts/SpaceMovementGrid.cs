using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

using System.Linq;
using System.Net.Http;

public class SpaceMovementGrid : MonoBehaviour
{
    public Sprite sprite;

    private Player player;
    private Enemy enemy;
    

    private ObjectBonus objectP;

    public GameObject playerT;
    public GameObject enemyT;

    public GameObject objectT;

    public Player[,] playerPosition;
    public Enemy[,] enemyPosition;

    public List<Enemy> enemies;
    public List<ObjectBonus> objects;

    public ObjectBonus[,] objectPosition;

    public int[,] playerPositionActive;
    public int[,] enemyPositionActive;

    public int[,] objectPositionActive;

    public int[,] size;
    private int widht;
    private int height;
    private int columns;
    private int rows;
    private int room = 0;
    private bool allEnemyDefeated = false;

    [Header("Game Over / You Win Screens")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject youWinScreen;


    void Start()
    {
        SetUpGrid();
        gameOverScreen.SetActive(false);
        youWinScreen.SetActive(false);
    }

    private void Awake()
    {
        //CreatingSize(Random.Range(0, 10), Random.Range(0, 10));

        player = playerT.GetComponent<Player>();
        enemy = enemyT.GetComponent<Enemy>();
        objectP = objectT.GetComponent<ObjectBonus>();
        
        //objectP = objectT.GetComponent<ObjectP>();
    }


    void Update()
    {
        RoomClear();
        EnemysDefeated();

        if (player != null) {
            EntityPosition(player.updatePositionX, player.updatePositionY);
        }

        //PrintArray(enemyPositionActive);
    }
    /*
    private void PrintArray(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Debug.Log(matrix[i, j] + "\t");
            }
        }
    }*/

    private void SetUpGrid()
    {
        height = (int)Camera.main.orthographicSize;
        widht = height * (Screen.width / Screen.height);

        columns = widht * 2;
        rows = height * 2;

        size = new int[columns, rows];

    }

    

    private void SpawnTile(int x, int y)
    {
        GameObject gmObjct = new GameObject($"X: {x} Y: {y}");

        gmObjct.transform.position = new Vector3(x - (widht - 0.5f), y - (height - 0.5f));

        //var s = gmObjct.AddComponent<SpriteRenderer>();
        var t = gmObjct.AddComponent<BoxCollider2D>();

        t.isTrigger = true;
    }

    public bool RoomClear()
    {
        if (room == 0)
            return true;
        else
            return false;
    }

    private void EntityPosition(int positionX, int positionY)
    {
        foreach(Enemy enemy in enemies.ToList())
        {
            //if (playerPositionActive[positionX, positionY] == enemyPositionActive[positionX, positionY])
            if(enemy.startPositionX == positionX && enemy.startPositionY == positionY)
            {
                if (player.powerLvl >= enemy.powerLvl)
                {
                    //player.powerLvl += enemyPosition[positionX, positionY].powerLvl;
                    player.powerLvl += enemy.powerLvl;  
                    enemyPositionActive[positionX, positionY] = 0;
                    enemies.Remove(enemy);
                    //Destroy(enemyPosition[positionX, positionY].gameObject);
                    //Destroy(enemyPosition[positionX, positionY]);
                    Destroy(enemy.gameObject);
                    Destroy(enemy);

                    if (enemies.Count == 0)
                    {
                        YouWinScreenActive();
                    }
                }
                else
                {
                    Destroy(player.gameObject);
                    Destroy(player);
                    GameOverScreenActive();
                }

            }
        }
        
        foreach(ObjectBonus _object in objects.ToList())
        {
            if (_object.startPositionX == positionX && _object.startPositionY == positionY)
            {
                player.powerLvl += _object.powerLvl;
                objectPositionActive[positionX, positionY] = 0;
                objects.Remove(_object);
                Destroy(_object.gameObject);
                Destroy(_object);
            }
        }

    }

    private void EnemysDefeated()
    {
        for (int i = 0; i < enemyPositionActive.GetLength(0); i++)
        {
            for (int j = 0; j < enemyPositionActive.GetLength(1); j++)
            {
                if (enemyPositionActive[i, j] == 1)
                {
                    allEnemyDefeated = false;
                }/*
                else
                {
                    allEnemyDefeated = true;
                }*/
            }
        }
    }

    public void YouWinScreenActive()
    {
        youWinScreen.SetActive(true);
    }

    public void GameOverScreenActive()
    {
        gameOverScreen.SetActive(true);
    }
}
