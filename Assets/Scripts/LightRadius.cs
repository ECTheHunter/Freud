using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightRadius : MonoBehaviour
{
    public float lightradius;
    public float defaultradius;
    public float radiusdecreaserate;
    public GameObject pointlight;
    public Light2D light2D;
    // Start is called before the first frame update
    void Start()
    {
        lightradius = defaultradius;
        light2D = pointlight.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RadiusDecrease();
        light2D.pointLightOuterRadius = lightradius;
        if(!(radiusdecreaserate > 0))
        {
            GameManager.Player.Die();
        }
    }
    public void RadiusDecrease()
    {
        if(lightradius > 0f)
        {
            lightradius -= radiusdecreaserate * Time.deltaTime;
        }
    }
    IEnumerator RadiusIncrease()
    {   
        while(lightradius < defaultradius)
        {
            lightradius += radiusdecreaserate * 5 * Time.deltaTime;
            yield return null;
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Candle" && collision.GetComponent<Candle>().isonfire != true)
        {
            collision.GetComponent<Candle>().isonfire = true;
            StartCoroutine(RadiusIncrease());
        }
        if(collision.tag == "Firefly")
        {
            defaultradius += 1f;
            StartCoroutine(RadiusIncrease());
            Destroy(collision.gameObject);
        }
    }
}
