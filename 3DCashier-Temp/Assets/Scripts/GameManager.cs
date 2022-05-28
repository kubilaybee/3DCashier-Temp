using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    #region LEVEL DATAS
    [Header("LevelDatas")]
    public List<Level> levels = new List<Level>();
    public Level currentLevel;
    public int levelCounter;
    #endregion

    #region GameEconomy
    [Header("MoneyData")]
    public int currentMoney;
    public int levelMoney;
    #endregion

    // cam
    private Camera cam;

    private void Awake()
    {
        Instance = this;
        cam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelCounter = 0;
        createLevel(levelCounter);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectMoney();
        }
    }

    void selectMoney()
    {
        // get the mouse datas
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z; // eþitle
        // send the laser
        Ray ray = cam.ScreenPointToRay(mousePos);
        // find the crush point
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            if(null!= hit.collider.GetComponent<Dolar>())
            {
                updateEconomy(hit.collider.GetComponent<Dolar>().dolarType.dolar);
            }
        }
    }

    void updateEconomy(int selectedMoneyValue)
    {
        // increase current money
        currentMoney += selectedMoneyValue;
        // decrease level money
        levelMoney -= selectedMoneyValue;

        if (levelMoney == 0 || levelMoney<0)
        {
            checkLevelComplete();
        }
        // CHNGE TEXT 
        UIManager.Instance.changeDatas(currentMoney, levelMoney);
    }

    // check the level completed
    public void checkLevelComplete()
    {
        // completed
        if (levelMoney == 0)
        {
            Debug.Log("COMPLETED");
            levelCounter++;
            if (levelCounter == levels.Count)
            {
                levelCounter = 0;
            }
            currentMoney = 0;
            createLevel(levelCounter);
        }
        else
        {
            Debug.Log("FAIL");
            currentMoney = 0;
            createLevel(levelCounter);
        }
    }

    // start the first level
    public void createLevel(int levelIndex)
    {
        levelMoney = levels[levelIndex].levelMoney;

        UIManager.Instance.changeDatas(currentMoney,levelMoney);
    }
}

[Serializable]
public class Level
{
    public string levelName;
    public int levelMoney;
}
