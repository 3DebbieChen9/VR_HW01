using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWeapon : MonoBehaviour
{
    public GameObject watergun;
    public GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        watergun.SetActive(true);
        sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseWatergun()
    {
        print("Choose Watergun");
        watergun.SetActive(true);
        sword.SetActive(false);
    }

    public void chooseSword()
    {
        print("Choose Sword");
        watergun.SetActive(false);
        sword.SetActive(true);
    }
}
