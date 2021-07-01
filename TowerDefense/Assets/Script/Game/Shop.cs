using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserTurret;

    BuildManager m_buildManager;


    void Start()
    {
        m_buildManager = BuildManager.instance;
    }


    public void SelectStandardTurret()
    {
        m_buildManager.SelectTurretToBuild(standardTurret);        
    }


    public void SelectMissileTurret()
    {
        m_buildManager.SelectTurretToBuild(missileTurret);        
    }


    public void SelectLaserTurret()
    {
        m_buildManager.SelectTurretToBuild(laserTurret);        
    }
}
