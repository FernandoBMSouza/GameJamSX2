using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    private void Start()
    {
        fill = GameObject.Find("PlayerFill").GetComponent<Image>();
        slider = GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        SetMaxHealth();
    }

    public void SetMaxHealth()
    {
        slider.maxValue = player.GetMaxHealth();
        slider.value = player.GetMaxHealth();
        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        slider.value = player.GetCurrentHealth();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
