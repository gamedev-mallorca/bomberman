using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{

    public double timer;
    public PlayerController player;
    public int explosionRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer<=0) {
            player.bombPocket++;
            explode();
            Object.Destroy(this.gameObject);
        }
    }

    private void explode()
    {
        Grid grid = GameObject.FindGameObjectWithTag("map").GetComponent<Grid>();
        doExplosionRay(Vector2.up, grid.cellSize.y * explosionRange);
        doExplosionRay(Vector2.down, grid.cellSize.y * explosionRange);
        doExplosionRay(Vector2.left, grid.cellSize.x * explosionRange);
        doExplosionRay(Vector2.right,  grid.cellSize.x * explosionRange);
    }

    private void doExplosionRay(Vector2 direction, float distance)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, distance);
        Vector3 lastHit = transform.position + new Vector3(direction.x, direction.y, 0f) * distance;
        foreach (RaycastHit2D hit in hits)
        {
            string tag = hit.transform.gameObject.tag;
            if ("Player".Equals(tag))
            {
                GameObject.Destroy(hit.transform.gameObject);
            }
            else if ("ground".Equals(tag))
            {
                lastHit = hit.transform.position;
                break;
            }
        }
    }
}
