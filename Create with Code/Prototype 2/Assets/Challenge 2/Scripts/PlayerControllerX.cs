using System.Collections;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canReleaseDog = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canReleaseDog)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            StartCoroutine(SpacebarCooldownRoutine(2));
        }

        IEnumerator SpacebarCooldownRoutine(float cooldownTime)
        {
            canReleaseDog = false;
            yield return new WaitForSeconds(cooldownTime);
            canReleaseDog = true;
        }
    }
}
