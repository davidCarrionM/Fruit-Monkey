using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    //Añadir Headers

    public GameObject[] weapons;
    public int selectedWeapon = 0;

    void Start()
    {
        SelectWeapon();

    }

    void Update()
    {
        int previusWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedWeapon >= weapons.Length - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = weapons.Length - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (previusWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (weapon.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                if (i == selectedWeapon)
                {
                    weapon.gameObject.SetActive(true);
                    StartCoroutine(AnimationWeapon(selectedWeapon));

                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }

                i++;
            }

        }
    }

    IEnumerator AnimationWeapon(int animation)
    {
        string animationName = "";
        switch (animation)
        {
            case 0:
                animationName = "GunUp";
                break;
            case 1:
                animationName = "KnifeUp";
                break;
            default:
                animationName = "GunUp";
                break;
        }

        weapons[selectedWeapon].GetComponent<Animator>().Play(animationName);
        yield return new WaitForSeconds(0.40f);
        weapons[selectedWeapon].GetComponent<Animator>().Play("New State");
    }
}
