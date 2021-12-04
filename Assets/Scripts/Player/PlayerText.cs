using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerText : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText;
    private int NumberOfEnemys;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] thingyToFind = GameObject.FindGameObjectsWithTag ("Enemy");
        NumberOfEnemys = thingyToFind.Length;
        enemyCountText.text = "EnemysInGame: " + NumberOfEnemys.ToString();
    }
}
