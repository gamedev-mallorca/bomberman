using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public BombTimer bomb;
    public int speed,bombPocket;
    public KeyCode upKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode downKey;
    public KeyCode bombKey;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        float localSpeed = speed * Time.deltaTime;

        if(Input.GetKey(bombKey) && bombPocket>0){
            bombPocket--;
            BombTimer clone=Instantiate<BombTimer>(bomb,transform.position,transform.rotation);
            clone.player=this;
            clone.bomb=clone;
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
}
