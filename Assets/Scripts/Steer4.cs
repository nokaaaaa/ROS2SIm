using UnityEngine;

public class Steer4 : MonoBehaviour
{
    public ArticulationBody[] articulationBodies;

    public float speed = 3000.0f;
   public float kp = 100f; // Pゲインとして剛性を設定
    public float tolerance = 1f; // 許容誤差（度数）

    // 指定されたインデックスのArticulationBodyを目標角度に移動させる関数
    public void MoveToAngle(int index, float targetAngle)
    {
       // 指定されたインデックスが配列範囲内か確認
        if (index < 0 || index >= articulationBodies.Length)
        {
            Debug.LogError("Error: Index out of range for articulationBodies array.");
            return;
        }

        ArticulationBody articulationBody = articulationBodies[index];

        // 現在の角度を取得
        float currentAngle = articulationBody.jointPosition[0] * Mathf.Rad2Deg;

        // 目標角度までの差を計算
        float angleError = targetAngle - currentAngle;

        // ArticulationBodyのxDriveを取得
        var xDrive = articulationBody.xDrive;

        // 目標角度に到達していれば停止
        if (Mathf.Abs(angleError) < tolerance)
        {
            xDrive.stiffness = 0f; // 剛性をゼロにして回転を停止
            articulationBody.xDrive = xDrive;
            return;
        }

        // 回転を継続：剛性を設定し、目標角度を更新
        xDrive.stiffness = kp;
        xDrive.damping = kp * 0.1f; // 減衰でオーバーシュートを抑制
        xDrive.target = targetAngle;
        articulationBody.xDrive = xDrive;
    }

    // 定期的に呼ばれる
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            articulationBodies[4].SetDriveTargetVelocity(ArticulationDriveAxis.X, speed);
            articulationBodies[5].SetDriveTargetVelocity(ArticulationDriveAxis.X, speed);
            articulationBodies[6].SetDriveTargetVelocity(ArticulationDriveAxis.X, speed);
            articulationBodies[7].SetDriveTargetVelocity(ArticulationDriveAxis.X, speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            articulationBodies[0].SetDriveTargetVelocity(ArticulationDriveAxis.X, 100);
            articulationBodies[1].SetDriveTargetVelocity(ArticulationDriveAxis.X, 100);
            articulationBodies[2].SetDriveTargetVelocity(ArticulationDriveAxis.X, 100);
            articulationBodies[3].SetDriveTargetVelocity(ArticulationDriveAxis.X, 100);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            articulationBodies[0].SetDriveTargetVelocity(ArticulationDriveAxis.X, -100);
            articulationBodies[1].SetDriveTargetVelocity(ArticulationDriveAxis.X, -100);
            articulationBodies[2].SetDriveTargetVelocity(ArticulationDriveAxis.X, -100);
            articulationBodies[3].SetDriveTargetVelocity(ArticulationDriveAxis.X, -100);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            articulationBodies[4].SetDriveTargetVelocity(ArticulationDriveAxis.X, -speed);
            articulationBodies[5].SetDriveTargetVelocity(ArticulationDriveAxis.X, -speed);
            articulationBodies[6].SetDriveTargetVelocity(ArticulationDriveAxis.X, -speed);
            articulationBodies[7].SetDriveTargetVelocity(ArticulationDriveAxis.X, -speed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            MoveToAngle(0, 45f);
            MoveToAngle(1, 45f); 
            MoveToAngle(2, 45f);
            MoveToAngle(3, 45f);  
        }
        else if (Input.GetKey(KeyCode.E))
        {
            MoveToAngle(0, -45f);
            MoveToAngle(1, -45f); 
            MoveToAngle(2, -45f);
            MoveToAngle(3, -45f);  
        }
        else 
        {
            articulationBodies[0].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[1].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[2].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[3].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[4].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[5].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[6].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            articulationBodies[7].SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
        }
    }
}