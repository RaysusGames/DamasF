using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //Victory logic
    [SerializeField] private int NumAlly;
    [SerializeField]private int NumEnemy;

    [SerializeField]private AllyUnit[] ally;
   [SerializeField] private EnemygUnit[] enemy;   

    [SerializeField] private TextMeshProUGUI textUnitAlly,textUnityEnemy;

    //PauseMenu
    [SerializeField] GameObject menuPausa;
    [SerializeField] bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        LogicaVictoria();

        if (Input.GetKeyDown(KeyCode.P))
        {
            MenuPause();
        } 
    }


   public void MenuPause()
    {
        if (Time.timeScale ==1)
        {
            Time.timeScale = 0;
            menuPausa.SetActive(true);
        }
        else
        {
            Time.timeScale =1;
            menuPausa.SetActive(false); 
        }
    }

    void LogicaVictoria()
    {

        ally = GameObject.FindObjectsOfType<AllyUnit>();
        enemy = GameObject.FindObjectsOfType<EnemygUnit>();



        NumAlly = ally.Length;
        NumEnemy = enemy.Length;

        textUnitAlly.SetText(NumAlly.ToString(""));
        textUnityEnemy.SetText(NumEnemy.ToString(""));

        if (NumAlly <= 0)
        {
            SceneManager.LoadScene("VictoryGosht");

        }
        if (NumEnemy <= 0)
        {
            SceneManager.LoadScene("VictoryMurcielago");

        }
    }

   public  void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
