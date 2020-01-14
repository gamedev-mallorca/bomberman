using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{

    public double timer;
    public PlayerController player;
    public int explosionRange;
    public GameObject explosionEffect;

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
        doExplosionBranch(Vector2.up, grid.cellSize.y, explosionRange);
        doExplosionBranch(Vector2.down, grid.cellSize.y, explosionRange);
        doExplosionBranch(Vector2.left, grid.cellSize.x, explosionRange);
        doExplosionBranch(Vector2.right,  grid.cellSize.x, explosionRange);
        showExplosionEffect(transform.position);
    }

    private void doExplosionBranch(Vector2 direction, float stepSize, float explosionRange)
    {
        float distance = stepSize * explosionRange;
        Vector3 direction3 = new Vector3(direction.x, direction.y, 0f);
        Vector3 stepInc = direction3 * stepSize;
        Vector3 lastHit = transform.position + (direction3 * distance) + stepInc;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, distance);
        foreach (RaycastHit2D hit in hits)
        {
            string tag = hit.transform.gameObject.tag;
            if ("Player".Equals(tag))
            {
                GameObject.Destroy(hit.transform.gameObject);
            }
            else if ("ground".Equals(tag))
            {
                distance = hit.distance;
                break;
            }
        }

        Vector3 destination = lastHit - stepInc;
        Vector3 origin = transform.position + stepInc;
        for (Vector3 step = origin; Vector3.Distance(step, origin) < distance; step += stepInc)
        {
            showExplosionEffect(step);
        }
    }

    private void showExplosionEffect(Vector3 position)
    {
        GameObject particleEffect =  GameObject.Instantiate(explosionEffect);
        particleEffect.transform.position = position;
    }
}
