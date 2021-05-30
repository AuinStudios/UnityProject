using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Uihover : MonoBehaviour
{

    public TextMeshProUGUI weaponPickupGUI;
    public GunsScriptableObject gun;
    public pickupgun notshowwhenequiped;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnMouseOver()
    {
        if (!notshowwhenequiped.equipped)
        {

            weaponPickupGUI.text = gun.hoverText + "\n";

            if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) <= gun.hoverVisibleDistance)
            {
                weaponPickupGUI.color = new Color(0, 255, 200, 200);
            }
            else
            {
                weaponPickupGUI.color = new Color(0, 0, 0, 0);
            }
        }
    }
    private void OnMouseExit()
    {
        weaponPickupGUI.color = new Color(0, 0, 0, 0);
    }

   


























            





}
