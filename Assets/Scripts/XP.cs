using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP : MonoBehaviour
{
    [SerializeField] private Image XpBar;
    [SerializeField] private Text xpValueTxt;
    [SerializeField] private float currentXp = 5; // XP atual do palyer
    [SerializeField] private int maxXp = 100; // Maximo de XP do player



    public int XPvalue;

    public float valorxpbar = 0.1f;

    private void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        XpBar.fillAmount = ((float)currentXp / maxXp);

        currentXp += valorxpbar * Time.deltaTime;
        currentXp = Mathf.Clamp(currentXp, 0, maxXp);

        XPvalue = Mathf.FloorToInt(currentXp);
        xpValueTxt.text = XPvalue.ToString();
    }




}
