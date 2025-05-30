using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public float yvel = 0;
    public float grav = 0.5f;
    public bool gravity;
    void Start()
    {
        var direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f),0);
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = 3 * direction;
    }

    // Update is called once per frame
    void Update()
    {
        yvel-=grav;
        if (gravity){
            var down = new Vector2(0, 0.0001f);
            down.Normalize();
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity - down/50;
            GetComponent<Rigidbody2D>().drag = 0;
        }
        
    }
}
