using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoom : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private Transform player;
    private Vector3 cameraChange;
    private Vector2 playerChange;

    private float transitionSmoothness = 0.025f; // la cam se mueve con un lerp, este es el valor de interpolacion usado

    private Hat hatScriptRef; // ignore

    private enum whereToMovePlayer 
    {
        right, left, up, down
    }
    [SerializeField] private whereToMovePlayer movePlayerTo;

    private enum whereToMoveCamera
    {
        right, left, up, down
    }
    [SerializeField] private whereToMoveCamera moveCameraTo;

    /*
     * Esto de arriba son dos enums para seleccionar hacia que direccion se quiere mover tanto la cam como el pj. 
     * Se podria tener uno solo pero se ve que no lo hice asi por algun motivo?
     */

    [SerializeField] private GameObject transitionsParent;

    /*
     * los triggers son hijos de un objeto vacio que contiene las transiciones
     * esto me servia porque asi puedo determinar que transiciones corresponden a cada 'habitacion'
     */

    private void Start()
    {
        hatScriptRef = GameObject.Find("HatBase").GetComponent<Hat>(); // ignore
    }

    private void SetTriggersToColliders()
    {
        transitionsParent.transform.GetChild(0).GetComponent<Collider2D>().isTrigger = false;
        transitionsParent.transform.GetChild(1).GetComponent<Collider2D>().isTrigger = false;
    }

    private void SetCollidersToTriggers()
    {
        transitionsParent.transform.GetChild(0).GetComponent<Collider2D>().isTrigger = true;
        transitionsParent.transform.GetChild(1).GetComponent<Collider2D>().isTrigger = true;
    }

    /*
     * Esto creo que se puede ignorar, mi tema aca es que no queria que el jugador pueda lanza el sombrero hacia otra habitacion.
     * entonces cuando no estoy en transicion, pongo los triggers como colliders.
     */


    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {            
            Debug.Log("MovingScreen");
            hatScriptRef.state = Hat.HatState.OnCharacter; // ignore
            SetCameraPosition();
            lerping = true; 
            SetPlayerPosition();
            player.position = playerChange;           
        }

        if (collision.CompareTag("Hat")) // ignore
        {
            collision.GetComponent<Hat>().state = Hat.HatState.OnGround;
        }
    }

    private void SetCameraPosition() 
    {
        switch (moveCameraTo)
        {
            case whereToMoveCamera.right: // tomo el valor del enum whereToMoveCamera para determinar la posicion a la que quiero cambiar la cam
                                          // en este caso le sumo o resto 28 para mov horizontal, y 16 para mov vertical
                cameraChange = new Vector3(cam.position.x + 28, cam.position.y, -10);
                break;

            case whereToMoveCamera.left:
                cameraChange = new Vector3(cam.position.x - 28, cam.position.y, -10);
                break;

            case whereToMoveCamera.up:
                cameraChange = new Vector3(cam.position.x, cam.position.y + 16, -10);
                break;

            case whereToMoveCamera.down:
                cameraChange = new Vector3(cam.position.x, cam.position.y - 16, -10);
                break;
        }
    }
  
    private void SetPlayerPosition() // misma logica que lo de arriba
    {
        switch (movePlayerTo)
        {
            case whereToMovePlayer.right:
                playerChange = new Vector2(player.position.x + 4, player.position.y);
                break;

            case whereToMovePlayer.left:
                playerChange = new Vector2(player.position.x - 4, player.position.y);
                break;

            case whereToMovePlayer.up:
                playerChange = new Vector2(player.position.x, player.position.y + 4);
                break;

            case whereToMovePlayer.down:
                playerChange = new Vector2(player.position.x, player.position.y - 4);
                break;
                
        }
    }

    private void Update()
    {
        CameraLerping();
    }

    private bool lerping = false;

    private void CameraLerping()
    {
        if (lerping)
        {
            SetTriggersToColliders();
            float a = 0;
            float b = 0;

            switch (moveCameraTo)
            {
                case whereToMoveCamera.right:
                    a = cameraChange.x;
                    b = cam.position.x;
                    break;

                case whereToMoveCamera.left:
                    a = cam.position.x;
                    b = cameraChange.x;                   
                    break;

                case whereToMoveCamera.up:
                    a = cameraChange.y;
                    b = cam.position.y;
                    break;

                case whereToMoveCamera.down:
                    a = cam.position.y;
                    b = cameraChange.y;                  
                    break;
            }

            float dist = a - b;
            
            /*
             * Momento algebra:
             * 
             * quiero guardar los valores de la posicion actual de la camara y la posicion donde quiero que quede.
             * esto lo uso para saber cuando cortar el lerp (porque esta ejecutandose en Update()), no para setear la posicion en si
             * 
             * dependiendo de la posicion pasada por el enum, seteo a o b como la posicion actual de la camara y la posicion deseada
             * asi como dependiendo de la direccion, trabajo sobre el x o el y de las posiciones
             * 
             * una vez seteados los valores, saco un valor de distancia total que es la resta entre a y b 
             * 
             * (suponete que estoy en 0 y quiero mover la camara a 20 (derecha), si hago que la posicion deseada sea a y le resto la posicion actual,
             * el calculo me da dist = 20 - 0 --> 20, y si lo quiero mover hacia la izquierda, la posicion actual es a y la deseada b, 
             * y el calculo queda dist = 0 - 20 --> -20)
             */

            cam.position = Vector3.Lerp(cam.position, new Vector3(cameraChange.x, cameraChange.y, -10), transitionSmoothness);
            // lerpear desde la posicion actual del a cam, hasta la posicion deseada, interpolando por el transitionSmoothness (seteado en 0.025f)

            if (dist < 0.01f) // si la distancia entre la posicion actual y la deseada es 0.01, cortar el lerp
            {                
                lerping = false;
                cam.position = new Vector3(cameraChange.x, cameraChange.y, -10);
                SetCollidersToTriggers();
            }
        }
    }
}
    