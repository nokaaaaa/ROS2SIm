using UnityEngine;

public class Steer3 : MonoBehaviour
{
    public ArticulationBody[] articulationBodies;

    public float speed = 1000.0f;

    // 定期的に呼ばれる
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            articulationBodies[3].SetDriveTargetVelocity(ArticulationDriveAxis.X, speed);
            articulationBodies[4].SetDriveTargetVelocity(ArticulationDriveAxis.X, speed);
            articulationBodies[5].SetDriveTargetVelocity(ArticulationDriveAxis.X, speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            articulationBodies[0].SetDriveTargetVelocity(ArticulationDriveAxis.X, 100);
            articulationBodies[1].SetDriveTargetVelocity(ArticulationDriveAxis.X, 100);
            articulationBodies[2].SetDriveTargetVelocity(ArticulationDriveAxis.X, 100);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            articulationBodies[0].SetDriveTargetVelocity(ArticulationDriveAxis.X, -100);
            articulationBodies[1].SetDriveTargetVelocity(ArticulationDriveAxis.X, -100);
            articulationBodies[2].SetDriveTargetVelocity(ArticulationDriveAxis.X, -100);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            articulationBodies[3].SetDriveTargetVelocity(ArticulationDriveAxis.X, -speed);
            articulationBodies[4].SetDriveTargetVelocity(ArticulationDriveAxis.X, -speed);
            articulationBodies[5].SetDriveTargetVelocity(ArticulationDriveAxis.X, -speed);
        }
        else 
        {
            articulationBodies[0].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[1].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[2].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[3].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[4].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[5].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
        }
    }
}