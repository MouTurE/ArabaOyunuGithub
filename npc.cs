using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc : MonoBehaviour
{

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Turn",0,1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed * Time.deltaTime,0);
    }

    public IEnumerator Trn (float turnAmount) {
        for (float f = 0; f < Mathf.Abs(turnAmount);f += 0.1f) {

        yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

    void OnCollisionEnter2D(Collision2D col) {
        //Debug.Log("Araba çarptı!");
        if (col.transform.tag == "Player") {
            if (col.gameObject.GetComponent<movement>().score > menu.hi_score) {
                menu.hi_score = col.gameObject.GetComponent<movement>().score;

                }
                //Debug.Log("Highscore is: " + menu.hi_score);
            Application.LoadLevel("menu");
        }

    }

    public void Turn() {

        int rand_int = Random.Range(0,10);
        if (rand_int < 5) {

        return;

        }
        else {
            //Debug.Log(transform.name + ": " +"I am turning!");
            int direction = Random.Range(1,3);
            if (direction == 1) {

            //StartCoroutine(turn(-2));

            }else if (direction == 2) {

            }

    }

    }



}
