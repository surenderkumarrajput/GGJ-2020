using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxeffect;
    public GameObject cam;
    float startpos,width;
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        startpos = transform.position.x;
    }

    void Update()
    {
        var poscam = cam.GetComponent<Transform>().transform.position;
        var temp = poscam.x * (1 - parallaxeffect);
        var pos = poscam.x * parallaxeffect;
        transform.position = new Vector2(startpos+pos,transform.position.y);
        if(temp>width+startpos)
        {
            startpos += width;
        }
        else if(temp<startpos-width)
        {
            startpos -= width;
        }

    }
}
