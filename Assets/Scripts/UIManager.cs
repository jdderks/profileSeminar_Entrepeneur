using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI explosionLeftText;
    [SerializeField] private ExplosionMaker explosionMaker;


    void Start()
    {
        
    }

    void Update()
    {

        explosionLeftText.text = explosionMaker.ExplosionsLeft.ToString();
    }
}
