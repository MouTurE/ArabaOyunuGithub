using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menu : MonoBehaviour
{

    public GameObject currentMenu,scoretext;
    public static int hi_score;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.GetComponent<TextMeshProUGUI>().text = "High-score: "+ hi_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play() {
        Application.LoadLevel("SampleScene");
    }

    public void customize(GameObject openMenu) {
        currentMenu.SetActive(false);
        openMenu.SetActive(true);
        currentMenu = openMenu;
    }

}
