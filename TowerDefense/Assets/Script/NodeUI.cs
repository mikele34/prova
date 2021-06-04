using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    Node m_target;


    public void SetTarget(Node _target)
    {
        m_target = _target;

        transform.position = m_target.GetBuildPosition();

        if (!m_target.isUpgraded) 
        { 
            upgradeCost.text = "$" + m_target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + m_target.turretBlueprint.GetSellAMount();

        ui.SetActive(true);
    }


    public void Hide()
    {
        ui.SetActive(false);
    }


    public void Upgrade()
    {
        m_target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }


    public void Sell()
    {
        m_target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
