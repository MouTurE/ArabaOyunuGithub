using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class movement : MonoBehaviour
{

public float speed,horizontalspeed, forceMagnitude;
public Rigidbody2D rb;
public GameObject camera;
public float currentY, rot;
public int score;
public GameObject scoreText;
float x = 0;
public AudioClip carSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        if (transform.position.y > currentY) {
            currentY = transform.position.y;
            score += 1;

        }
        if (GameObject.FindGameObjectWithTag("hook") == true)
            GameObject.FindGameObjectWithTag("hook").transform.position = transform.position;
        
        camera.transform.position = new Vector3(camera.transform.position.x, transform.position.y + 3.86f, -10);


        if (Input.GetMouseButtonDown(0)) 
            GetComponent<AudioSource>().PlayOneShot(carSound);

        if (Input.GetMouseButton(0)) {
            
            rot += Input.acceleration.x * 2;
            transform.rotation = Quaternion.Euler(0,0,-rot);
            //Debug.Log(Input.acceleration.x);
            //if (Input.acceleration.x == 0) {
                if (rot > 0) {
                    rot -= 0.3f;

                }else if (rot < 0) {
                    rot += 0.3f;
                }
            //}
            transform.Translate(0,speed * Time.deltaTime,0);
            x = Mathf.Clamp(x,-1.9f,1.88f);
            x += Input.acceleration.x * horizontalspeed * Time.deltaTime;
            float hor = Input.GetAxis("Horizontal");
            x += hor * horizontalspeed * Time.deltaTime;
            transform.position = new Vector3(x,transform.position.y,transform.position.z);
            x = Mathf.Clamp(x,-1.9f,1.88f);

        }


        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(transform.right * forceMagnitude);

    }
}
