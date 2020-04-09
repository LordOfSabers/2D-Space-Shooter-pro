using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.9f;


    [SerializeField]//id for powerups 0 = Triple Shot, 1 = Speed, 2 = Shields,
    private int _powerupId;

    void Update()
    {
    
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -11.58f)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {
               switch(_powerupId)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedPowerActive();
                        break;
                    case 2:
                        player.ActivateShields();
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;
                }
                
            }

            Destroy(this.gameObject);
        }
    }

}
