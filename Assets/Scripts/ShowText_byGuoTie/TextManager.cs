using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private bool isCollided;
    public GameObject tips;         // tips  // by 清梦微风

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollided = true;
            tips.SetActive(true);   // by 清梦微风
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            isCollided = false;
            this.gameObject.GetComponent<ReadText>().isClose = true;
            tips.SetActive(false);  // by 清梦微风
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        isCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollided && Input.GetKeyDown(KeyCode.W))
        {
            this.gameObject.GetComponent<ReadText>().isEnabled = true;
            tips.SetActive(false);  // by 清梦微风
            isCollided = false;
        }       
    }
}
