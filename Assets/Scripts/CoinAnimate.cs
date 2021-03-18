using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimate : MonoBehaviour
{
    public GameObject coin;
    private Animation m_animations;
    // Start is called before the first frame update
    void Start()
    {
        coin.SetActive(false);
        m_animations = coin.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAnimation()
    {
        coin.SetActive(true);
        if (m_animations != null)
        {
            m_animations.Play("CoinAnimation");
        }
        Invoke("closeCoin", 3.0f);
    }

    void closeCoin()
    {
        coin.SetActive(false);
    }
}
