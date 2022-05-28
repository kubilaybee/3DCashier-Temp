using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolar : MonoBehaviour
{
    public GameMoney dolarType;

    private void Start()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = dolarType.dolarColor;
    }
}
