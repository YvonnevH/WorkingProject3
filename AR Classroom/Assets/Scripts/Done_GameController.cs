using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Vuforia;

public class Done_GameController : MonoBehaviour
{
    private Done_DestroyByContact dragonController;

    public GameObject star;
    public float timeUntilTransition = 30.0f;

    public bool gameOver;
    private int score;

    private float dragonHealth = 100;
    private float hitPoints = 2.5f;
    public Material dragonMaterial;
    public Material[] ringMaterials;
    public GameObject HealthBar;

    //70FFFC - Blue - (40,255,252)
    //FF4E49 - Red - (255,40,40)
    //37FA3F - Green - (40,250,63)
    //F1BE0A - Orange - (255,230,40)
    //FF70D0 - Purple - (255,40,210)

    private Color32[] dragonColors = {
        new Color32(40,255,252,255),
        new Color32(255, 40, 40,255),
        new Color32(40,250,63,255),
        new Color32(255,230,40,255),
    };

    private Color curDragonColor;

    void Start()
    {
        GameObject dragonObject = GameObject.FindGameObjectWithTag("Dragon");
        if (dragonObject != null)
        {
            dragonController = dragonObject.GetComponent<Done_DestroyByContact>();
        }

        HealthBar = GameObject.FindGameObjectWithTag("HealthBar");

        gameOver = false;     
        UpdateScore();
        InvokeRepeating("ChangeColor", 0.0f, timeUntilTransition);
    }

    void Update()
    {
        if (dragonHealth <= 0 && gameOver == false)
        {
            GameOver();
        }
    }

    private void UpdateScore()
    {
        float healthBarValue = dragonHealth / 100f;
        HealthBar.GetComponent<Slider>().value = healthBarValue;
    }

    private void ChangeColor()
    {
        curDragonColor = dragonColors[Random.Range(0, dragonColors.Length)];
        dragonMaterial.color = curDragonColor;

        for (int i = 0; i < ringMaterials.Length; i++)
        {
            curDragonColor.a = 0.5f;
            ringMaterials[i].SetColor("_TintColor", curDragonColor);
            curDragonColor.a = 1f;
        }
    }

    public void dragonHit(string hitBulletName)
    {
        if (curDragonColor == new Color32(40,255,252,255) && hitBulletName.Substring(0, 8) == "BulletBl") {
            hitSuccesful();
        } else if (curDragonColor == new Color32(255, 40, 40, 255) && hitBulletName.Substring(0, 8) == "BulletRe") {
            hitSuccesful();
        } else if (curDragonColor == new Color32(40, 250, 63, 255) && hitBulletName.Substring(0, 8) == "BulletGr") {
            hitSuccesful();
        } else if (curDragonColor == new Color32(255, 230, 40, 255) && hitBulletName.Substring(0, 8) == "BulletYe") {
            hitSuccesful();
        }
    }

    private void hitSuccesful()
    {
        if (dragonHealth > 0)
        {
            dragonController.dragonHit();
            dragonHealth -= hitPoints;
            UpdateScore();
        }
    }

    public void GameOver()
    {
        dragonController.dragonDie();
        gameOver = true;
    }

    public void activateStar()
    {
        star.SetActive(true);
        HealthBar.SetActive(false);
        for (int i = 0; i < ringMaterials.Length; i++)
        {
            curDragonColor.a = 0.5f;
            ringMaterials[i].SetColor("_TintColor", new Color32(255, 230, 40, 255));
            curDragonColor.a = 1f;
        }
        StartCoroutine(winnerTime());
    }

    IEnumerator winnerTime()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("EndSceneNew", LoadSceneMode.Single);
    }
}