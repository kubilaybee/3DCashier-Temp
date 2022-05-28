using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    public Text CurrentMoneyTxt;
    public Text CurrentLevelMoneyTxt;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeDatas(int currentMoney, int currentLevelMoney)
    {
        CurrentMoneyTxt.text ="Current Money:" +currentMoney;
        CurrentLevelMoneyTxt.text ="Level Money:" + currentLevelMoney;
    }
}
