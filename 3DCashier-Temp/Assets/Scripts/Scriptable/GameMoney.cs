using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data",menuName ="ScriptableObjects/Dolar",order =1)]
public class GameMoney : ScriptableObject
{
    public int dolar;
    public Color dolarColor = Color.green;
    public Vector3 spawnPoint;
}
