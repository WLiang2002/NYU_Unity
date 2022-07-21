using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float speed;
    private float PosX;
    private Vector3 velocity = Vector3.zero;
    
    //follow 
    [SerializeField] private Transform player;
    //[SerializeField] private float DisAhead;
    //[SerializeField] private float CamSpeed;
    //private float LookAhead;
       

    private void Update()
    {
        //camera follows player
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        //LookAhead = Mathf.Lerp(LookAhead, (DisAhead * player.localScale.x), Time.deltaTime * CamSpeed);



    }
/*
    public void NewCamPan(Transform _newLvl)
    {
        PosX = _newLvl.position.x;
    }
*/
}
