using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class hareket : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousepos;
    public int ToplamPuan;
    public bool bitis;
    public Button cevapbtn;
    public TMP_InputField cevaptxt;
    public TextMeshProUGUI ekranYazisi;
    public GameObject oyunSonu;
    public AudioSource win;
    public AudioSource lost;
    void Start()
    {
        oyunSonu.SetActive(false);
        bitis = true;
        cevapbtn.gameObject.SetActive(false);
        cevaptxt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

       
    }
    private void FixedUpdate()
    {
        if (bitis)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            Vector2 lookdir = mousepos - rb.position;
            float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "puanlar")
        {
           
            print("asdasf");
            ToplamPuan += other.GetComponent<puanBelirle>().puan;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "peynir")
        {
            print("oyun bitti");
            bitis = false;
            cevapbtn.gameObject.SetActive(true);
            cevaptxt.gameObject.SetActive(true);

        }
    }
    public void bitisKontrol()
    {
        if (cevaptxt.text == ToplamPuan.ToString())
        {
            win.Play();
            oyunSonu.SetActive(true);
            print("kazand�n");
            ekranYazisi.text = "Kazand�n";
             string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "sahne1")
        {
            SceneManager.LoadScene("sahne2");
        }
        else if (currentSceneName == "sahne2")
        {
            SceneManager.LoadScene("sahne3");
        }
        else if (currentSceneName == "sahne3")
        {
            SceneManager.LoadScene("sahne4");
        }
        else{
             SceneManager.LoadScene("sahne1");
        }
        }
        else
        {
            lost.Play();
            oyunSonu.SetActive(true);
            print("kaybettin");
            ekranYazisi.text = "Kaybettin  Ger�ek de�er= "+ToplamPuan;

        }
    }
    public void tekrarOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}