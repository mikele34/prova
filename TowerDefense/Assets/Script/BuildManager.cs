using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;    

    public GameObject buildEffect;
    public GameObject sellEffect;

    TurretBlueprint m_turretToBuild;
    Node m_selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return m_turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= m_turretToBuild.cost; } }


    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }


    public void SelectNode(Node node)
    {
        if (m_selectedNode == node)
        {
            DeselectNode();
            return;
        }

        m_selectedNode = node;
        m_turretToBuild = null;

        nodeUI.SetTarget(node);
    }


    public void DeselectNode()
    {
        m_selectedNode = null;
        nodeUI.Hide();
    }


    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        m_turretToBuild = turret;
        DeselectNode();
    }


    public TurretBlueprint GetTurretToBuild()
    {
        return m_turretToBuild;
    }
}
