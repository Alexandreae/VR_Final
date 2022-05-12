using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD_fut : MonoBehaviour
{

    public int bolas;
    public int gols;
    public int defendidos;

    public GameObject score;
    public GameObject lives;

    private GameObject player;
    private Vector3 p;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        p = player.transform.position;

        p.x = 4;
        p.y =  1;
        p.z = 32;

    }

    // Update is called once per frame
    void Update()
    {   
        score.GetComponent<Text>().text = defendidos.ToString();
        lives.GetComponent<Text>().text = gols.ToString();
        if (gols == 0){
            player.transform.position = p;
            SceneManager.LoadScene("Arcade");
        }
    }
}
