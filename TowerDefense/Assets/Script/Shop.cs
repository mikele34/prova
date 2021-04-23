using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);        
    }

    public void SelectMissileTurret()
    {
        buildManager.SelectTurretToBuild(missileTurret);        
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);        
    }
}
