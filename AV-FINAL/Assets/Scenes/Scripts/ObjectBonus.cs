using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBonus : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        SetUpGridMovement();
        StartPosition();
    }

    private void Awake()
    {
        //player = playerGmObjct.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void SetUpGridMovement()
    {
        height = (int)Camera.main.orthographicSize;
        widht = height * (Screen.width / Screen.height);

        columns = widht * 2;
        rows = height * 2;

        gridMovement.objectPosition = new ObjectBonus[columns, rows];
        gridMovement.objectPositionActive = new int[columns, rows];

    }
    private void StartPosition()
    {
        gridMovement.objectPosition[startPositionX, startPositionY] = this;
        gridMovement.objectPositionActive[startPositionX, startPositionY] = 1;
        gameObject.transform.position = new Vector3(startPositionX - (widht - 0.5f), startPositionY - (height - 0.5f));
        gridMovement.objects.Add(this);

        Debug.Log($"Start position object in array {startPositionX} {startPositionY}");
    }
}
