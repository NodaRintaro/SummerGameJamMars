using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    static public StaminaBar instance;

    [SerializeField] Image stamina;


    [SerializeField] float JumpReduced = 1;
    [SerializeField] float DefoultInterval = 5;
    [SerializeField] float maxStamina = 10;
    [SerializeField] float upStaminaAmount = 0.01f;

    private float currentStamina = 10;
    private float interval = 0;

    private void Start()
    {
        instance = this;

        stamina = GetComponent<Image>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StaminaDown(JumpReduced);
        }

        stamina.fillAmount = currentStamina / maxStamina;

        //スタミナがなくなったら一時的にスタミナを増えなくする
        if(currentStamina == 0)
        {
            interval = 1000;
        }
    }
    private void FixedUpdate()
    {
        if(interval > 0)
        {
            interval -= 0.1f;
        }
        else
        {
            StaminaUp();
        }
    }

    public void StaminaDown(float amount)
    {
        interval = DefoultInterval;

        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }

    private void StaminaUp()
    {
        currentStamina += upStaminaAmount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }
}
