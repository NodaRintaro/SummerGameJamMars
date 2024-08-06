using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    static public StaminaBar instance;

    [SerializeField] Image stamina;

    const float DefoultInterval = 5;
    const float maxStamina = 10;
    private float currentStamina = maxStamina;
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
            StaminaDown();
        }

        stamina.fillAmount = currentStamina / maxStamina;
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

    public void StaminaDown()
    {
        interval = DefoultInterval;

        currentStamina -= 1;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }

    private void StaminaUp()
    {
        currentStamina += 0.01f;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }
}
