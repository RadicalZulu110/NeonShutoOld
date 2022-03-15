using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quota : MonoBehaviour
{
    public int firstQuota;

    public Text goldQuotaDisplay;
    public Text foodQuotaDisplay;
    public Text stoneQuotaDisplay;
    public Text crystalQuotaDisplay;

    public GameManager gameManager;

    void Update()
    {
        goldQuotaDisplay.text = gameManager.gold.ToString() + "/" + "(" + (firstQuota).ToString() + ")";
        foodQuotaDisplay.text = gameManager.food.ToString() + "/" + "(" + (firstQuota).ToString() + ")";
        stoneQuotaDisplay.text = gameManager.stone.ToString() + "/" + "(" + (firstQuota).ToString() + ")";
        crystalQuotaDisplay.text = gameManager.crystal.ToString() + "/" + "(" + (firstQuota).ToString() + ")";
    }

    public void OnMouseDown()
    {
        if (gameManager.gold >= firstQuota && gameManager.food >= firstQuota && gameManager.stone >= firstQuota && gameManager.crystal >= firstQuota)
        {
            gameManager.gold -= firstQuota;
            gameManager.food -= firstQuota;
            gameManager.stone -= firstQuota;
            gameManager.crystal -= firstQuota;
        }

    }
}
