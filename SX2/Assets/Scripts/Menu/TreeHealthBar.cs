using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Tree tree;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    private void Start()
    {
        fill = GameObject.Find("TreeFill").GetComponent<Image>();
        slider = GetComponent<Slider>();
        tree = GameObject.FindGameObjectWithTag("Tree").GetComponent<Tree>();
        SetMaxHealth();
    }

    public void SetMaxHealth()
    {
        slider.maxValue = tree.GetMaxHealth();
        slider.value = tree.GetMaxHealth();
        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        slider.value = tree.GetCurrentHealth();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
