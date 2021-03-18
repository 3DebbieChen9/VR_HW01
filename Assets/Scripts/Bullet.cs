using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject scoreUI;
    public bool isGarbage;
    private float beginTime;
    private float duration;
    private bool hit;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GameObject.Find("Shooting");
        beginTime = Time.time;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        duration = Time.time - beginTime;
        if(!hit && duration > 5.0f)
        {
            Destroy(this.gameObject);
        }
        if (hit)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        string targetTag = other.gameObject.tag;
        if(!hit)
        {
            print(targetTag);
            switch (targetTag)
            {
                case "target-50":
                    scoreUI.GetComponent<Score>().totalScore += 50;
                    scoreUI.GetComponent<Score>().updateScore = true;
                    hit = true;
                    break;
                case "target-25":
                    scoreUI.GetComponent<Score>().totalScore += 25;
                    scoreUI.GetComponent<Score>().updateScore = true;
                    hit = true;
                    break;
                case "target-20":
                    scoreUI.GetComponent<Score>().totalScore += 20;
                    scoreUI.GetComponent<Score>().updateScore = true;
                    hit = true;
                    break;
                case "target-15":
                    scoreUI.GetComponent<Score>().totalScore += 15;
                    scoreUI.GetComponent<Score>().updateScore = true;
                    hit = true;
                    break;
                case "target-10":
                    scoreUI.GetComponent<Score>().totalScore += 10;
                    scoreUI.GetComponent<Score>().updateScore = true;
                    hit = true;
                    break;
                default:
                    break;
            }
        }
    }

    void destroyBullet()
    {
        Destroy(this.gameObject);
    }
}
