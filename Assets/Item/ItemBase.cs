using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [HideInInspector] public bool _isOn = false;
    private string playerTag = "Player";
    [SerializeField] AudioClip _sound = default;

    #region
    public virtual void Action()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == playerTag)
        {
            Action();
            AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            _isOn = true;
            Destroy(this.gameObject);
        }
    }
    #endregion
}
