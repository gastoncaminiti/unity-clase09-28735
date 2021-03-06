using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 2f;

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] GameObject shootPoint;

    [SerializeField] float cooldown = 2f;


     [SerializeField] private bool canShoot = true;

     [SerializeField] private float timePass = 0;

    float cameraAxisX = 0f;

    void Start()
    {

    }
    void Update()
    {
   
        //SI APRIETO W
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back);
        }

        RotatePlaye();

        if (Input.GetKeyDown(KeyCode.E) && canShoot)
        {
            Instantiate(bulletPrefab, shootPoint.transform.position, bulletPrefab.transform.rotation);// PROYECTILES
            Instantiate(bulletPrefab, shootPoint.transform.position + Vector3.forward, bulletPrefab.transform.rotation);// PROYECTILES\
            Instantiate(bulletPrefab, shootPoint.transform.position + Vector3.back, bulletPrefab.transform.rotation);// PROYECTILES
            canShoot = false;
        }
       
      
        if(!canShoot){
            //timePass = timePass + Time.deltaTime;
            timePass += Time.deltaTime;
        } // !canShoot  !false == true

        if(timePass > cooldown){
            timePass = 0;
            canShoot = true;
        }

    }

    private void MovePlayer(Vector3 directionEnemy)
    {
        transform.Translate(speed * Time.deltaTime * directionEnemy);
    }

    private void RotatePlaye(){
        //1 UN VALOR PARA ROTAR EN Y
        cameraAxisX += Input.GetAxis("Mouse X");   
        //2 UN ANGULO A CALCULAR EN FUNCION DEL VALOR DEL PRIMER PASO
        Quaternion angulo = Quaternion.Euler(0f,cameraAxisX, 0f);
        //3 ROTAR
        transform.localRotation = angulo;
    }
}
