using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapmaker : MonoBehaviour
{

    public GameObject previous_road,current_road;
    public GameObject road,car;
    mapmaker main_mp;

    // Start is called before the first frame update
    void Start()
    {
        main_mp = GameObject.FindGameObjectWithTag("mapmaker").GetComponent<mapmaker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col) {

    if (col.tag == "Player") {
        //Debug.Log("Create a road");
        create_road();
        this.enabled = false;

        }

    }

    public void create_road() {
        GameObject new_road = Instantiate(main_mp.road);
        new_road.transform.position = new Vector3(main_mp.current_road.transform.position.x,main_mp.current_road.transform.position.y + 10.6f,main_mp.current_road.transform.position.z);

        //int rand_int = Random.Range(0,3);
        //for (int i = 0;i < rand_int;i++) {
            Debug.Log("spawn car");
            int row_num = Random.Range(0,2);
            int column_num = Random.Range(0,3);


            for (int i = 0; i < new_road.transform.childCount;i++){
                //Debug.Log(new_road.transform.GetChild(i).name.Substring(0,3));
                if (new_road.transform.GetChild(i).name.Substring(0,3) == "Row") {
                    //Debug.Log("Row found!");
                    //Debug.Log(new_road.transform.GetChild(i).name.Substring(4)); //Row01
                    int row_id = int.Parse(new_road.transform.GetChild(i).name.Substring(4));
                    if (row_id != row_num) {
                        //Debug.Log("Delete all cars in this row");
                        for (int j = 0; j < new_road.transform.GetChild(i).childCount;j++) {
                            new_road.transform.GetChild(i).GetChild(j).gameObject.SetActive(false);
                            
                        }
                    }else {

                        for (int j = 0; j < new_road.transform.GetChild(i).childCount;j++) {
                            if (j != column_num) {
                                 new_road.transform.GetChild(i).GetChild(j).gameObject.SetActive(false);
                            }
                        }

                    }

                    }
            }

            GameObject[] cars = GameObject.FindGameObjectsWithTag("car");

            if (cars.Length > 0) {

                foreach (GameObject c in cars){
                    if (c.transform.parent != null && c.transform.parent.parent != null) {
                        GameObject holder = new GameObject("CarHolder");
                        holder.transform.position = c.transform.position;
                        c.transform.SetParent(holder.transform);
                        holder.transform.tag = "car";
                    }
                }


            }
            //new_car.transform.position = new Vector3(new_road.transform.position.x + rand_x,new_road.transform.position.y + rand_y,new_road.transform.position.z);
       // }

        GameObject go = main_mp.current_road;
        if (main_mp.previous_road != null) {
            GameObject[] cars2 = GameObject.FindGameObjectsWithTag("car");
            //GameObject[] holders = GameObject.FindGameObjectsWithTag("holder");
            foreach (GameObject g in cars2) {
                Vector3 player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
                if (g.transform.position.y < player_pos.y - 20) {
                   Destroy(g);
                   }
            }
            Destroy(main_mp.previous_road);

            }
        main_mp.previous_road = go;
        main_mp.current_road = new_road;


    }


}
