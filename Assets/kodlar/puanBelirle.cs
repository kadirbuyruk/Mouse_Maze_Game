using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class puanBelirle : MonoBehaviour
{
    public int puan;
    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        puan = Random.Range(1, 10);
        txt.text = puan.ToString();
        txt.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
