using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlood : MonoBehaviour
{
    [SerializeField] Image image;
    Animator anim;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public async void SetAlpha()
    {
        float duration = anim.GetCurrentAnimatorClipInfo(0).GetLength(0);
        print(duration);
        float timer = duration;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            image.material.SetFloat("_Alpha", 1 - (timer / duration));
            await Task.Yield();
        }
    }

    void OnDisable()
    {
        image.material.SetFloat("_Alpha", 0);
    }
}
