using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    public GameObject roadPrefab;
    public Vector3 lastPos;
    public float offset = 0.707f;
    private int roadCount = 0;
    private CharController cha;
    private GameController GC;

    float timer;

    private void Awake()
    {
        cha = FindObjectOfType<CharController>();
        timer = 1/cha.speed;
        GC = FindObjectOfType<GameController>();
    }


    public void CreateNewPart()
    {

        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y , lastPos.z + offset);
        }
        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y , lastPos.z + offset);
        }

        GameObject temp = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0,45,0));
        lastPos = temp.transform.position;
        GC.parts.Add(temp);
        roadCount++;
        if (roadCount % 5 == 0)
        {
            temp.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0&& GC.gameStarted)
        {
            CreateNewPart();
            timer =(float)( 1/(cha.speed+0.25));
        }
    }
}
