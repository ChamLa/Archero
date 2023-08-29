using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : Character
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform rightHand, hip, head;
    [SerializeField] private WeaponData weaponData;
    private Weapon currentWeapon;
    private bool isDead, isMoving;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeWeapon(WeaponType.Knife);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButton(0) && JoystickControl.direct != Vector3.zero)
            {
                //rb.velocity = JoystickControl.direct * moveSpeed;
                rb.MovePosition(rb.position + JoystickControl.direct * moveSpeed * Time.deltaTime);
                transform.position = rb.position;

                transform.forward = JoystickControl.direct;

                ChangeAnim(Constants.ANIM_RUN);
                isMoving = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isMoving = false;
                OnMoveStop();
            }
        }
    }

    protected override void OnInit()
    {
        base.OnInit();
        isMoving = false;
        isDead = false;

    }

    private void ChangeWeapon(WeaponType weaponType)
    {
        if (currentWeapon != null)
        {
            currentWeapon.OnDestroy();
        }
        currentWeapon = Instantiate(weaponData.GetWeaponItem(weaponType).weapon, rightHand);
    }
}
