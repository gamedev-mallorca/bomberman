using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{

    public BombTimer bombPrefab;
    public int speed,bombPocket;
    public KeyCode upKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode downKey;
    public KeyCode bombKey;

    private GameObject map;


    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindGameObjectWithTag("map");
    }

    // Update is called once per frame
    void Update()
    {
        float localSpeed = speed * Time.deltaTime;


        if(Input.GetKey(bombKey) && bombPocket>0){
            spawnBomb();
        }

        if (Input.GetKey(upKey))
        {
            transform.Translate(Vector3.up * localSpeed);
        }
        else if (Input.GetKey(downKey))
        {
            transform.Translate(Vector3.down * localSpeed);
        }
        else if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector3.left * localSpeed);
        }
        else if (Input.GetKey(rightKey))
        {
            transform.Translate(Vector3.right * localSpeed);
        }
    }

    public void spawnBomb()
    {
        if (bombPocket > 0)
        {
            bombPocket--;
            Vector3 spawnPosition = getBombSpawnPosition();
            BombTimer bomb = Instantiate<BombTimer>(bombPrefab, spawnPosition, Quaternion.identity);
            bomb.player = this;
        }
    }

    private Vector3 getBombSpawnPosition()
    {
        Grid grid = map.GetComponent<Grid>();
        Vector3Int cellSize = grid.WorldToCell(transform.position);
        return grid.GetCellCenterWorld(cellSize);
    }
}
