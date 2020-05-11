using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{

    public Image target;

    public float fadeTimout;

    public float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeTimout > 0) {
            fadeTimout -= Time.deltaTime;
        } else {
            target.color = new Color(target.color.r, target.color.g, target.color.b, Mathf.MoveTowards(target.color.a,0f, fadeSpeed*Time.deltaTime));
            if(target.color.a == 0f) {
                gameObject.SetActive(false);
            }
        }
    }
}
