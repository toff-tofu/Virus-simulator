using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthy : MonoBehaviour
{
    public bool sick;
    bool pSick;
    int time = 100;
    int heal = 800;

    // Start is called before the first frame update
    void Start()
    {
        // sick = ;
        int h = Random.Range(0,2);
        if (h==0){
            pSick=false;
            sick=false;
            time = heal;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }else{
            sick=true;
            pSick=true;
            time = 0;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pSick&&sick){
            time = 0;
        }


        time += 1;
        if (time>=heal){
            time = heal;
            sick=false;
        }else{
            sick=true;
        }
        if (sick){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.887f,0.305f,0.369f,1f);
            
            pSick=true;
        }else{
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3712175f,0.5113208f,0.605187f,1f);
            pSick=false;
        } 
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // if (col.gameObject.GetComponent<SpriteRenderer>().color == Color.green && gameObject.GetComponent<SpriteRenderer>().color == Color.red){
        //     col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        // }

        // if (col.gameObject.GetComponent<SpriteRenderer>().color == Color.red && gameObject.GetComponent<SpriteRenderer>().color == Color.red){
        //     time = 0;
        // }
        // if (col.gameObject.GetComponent<SpriteRenderer>().color == Color.red && gameObject.GetComponent<SpriteRenderer>().color == Color.green){
        //     time = 0;
        // }


        if (col.gameObject.GetComponent<Healthy>().sick == false && gameObject.GetComponent<Healthy>().sick == true){
            col.gameObject.GetComponent<Healthy>().sick = true;
        }

        if (col.gameObject.GetComponent<Healthy>().sick == true && gameObject.GetComponent<Healthy>().sick == true){
            time = 0;
        }
        if (col.gameObject.GetComponent<Healthy>().sick == true && gameObject.GetComponent<Healthy>().sick == false){
            time = 0;
            int Die = Random.Range(0,5000);
            if (Die<=2){
                Destroy(gameObject);
            }
        }
    }
}
