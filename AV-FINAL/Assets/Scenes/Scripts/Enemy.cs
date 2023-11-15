using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        SetUpGridMovement();
        StartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Start position enemy in array {gridMovement.enemyPositionActive[startPositionX, startPositionY]}");
    }

    public override void SetUpGridMovement()
    {
        height = (int)Camera.main.orthographicSize;
        widht = height * (Screen.width / Screen.height);

        columns = widht * 2;
        rows = height * 2;

        gridMovement.enemyPosition = new Enemy[columns, rows];
        gridMovement.enemyPositionActive = new int[columns, rows];

    }

    private void StartPosition()
    {
        gridMovement.enemyPosition[startPositionX, startPositionY] = this;
        gridMovement.enemyPositionActive[startPositionX, startPositionY] = 1;
        gameObject.transform.position = new Vector3(startPositionX - (widht - 0.5f), startPositionY - (height - 0.5f));
        gridMovement.enemies.Add(this);

        Debug.Log($"Start position enemy in array {startPositionX} {startPositionY}");
    }
}
