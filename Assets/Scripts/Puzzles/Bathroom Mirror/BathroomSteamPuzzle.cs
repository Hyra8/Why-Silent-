using UnityEngine;
using UnityEngine.UI;

public class BathroomMirrorPuzzle : Puzzle
{
    [SerializeField] GameObject coldWaterImage;
    [SerializeField] GameObject hotWaterImage;
    public bool usingHotWaterTap = false;

    [SerializeField] float duration = 3f;
    [SerializeField] float elapsed = 0.1f;

    [SerializeField] Image mirrorImage;
    [SerializeField] Sprite brokenMirrorSprite;
    [SerializeField] Image blurredMirrorImage;
    [SerializeField] Sprite brokenBlurredMirrorSprite;
    public bool broken = false;

    public GameObject steamSpawner;
    Animator animator;

    public void Awake()
    {
        elapsed = 0.1f;
        animator = GetComponent<Animator>();
    }
    public override void ClosePuzzle()
    {
        if (hotWaterImage.activeSelf)
        {
            useHotWaterTap();
        }
        if (coldWaterImage.activeSelf)
        {
            useColdWaterTap();
        }
        DestroyAllChildrenOf(steamSpawner);
        base.ClosePuzzle();
    }
    public void DestroyAllChildrenOf(GameObject target)
    {
        if (target != null) // Kiểm tra xem đối tượng có hợp lệ không
        {
            foreach (Transform child in target.transform)
            {
                if (child != null)
                {
                    Destroy(child.gameObject); // Xóa từng object con
                }
            }
        }
        else
        {
            Debug.LogWarning("Target GameObject is null!");
        }
    }

    public void useHotWaterTap()
    {
        hotWaterImage.SetActive(!hotWaterImage.activeSelf);

        if (hotWaterImage.activeSelf)
        {
            AudioManager.instance.PlaySoundEffect("Hot water tap");
        }
        else
        {
            AudioManager.instance.StopSoundEffect("Hot water tap");
        }

        usingHotWaterTap = !usingHotWaterTap;
        if (elapsed >= duration)
        {
            elapsed = duration - 0.01f;
        }
        if (elapsed <= 0)
        {
            elapsed = 0.01f;
        }
    }
    public void useColdWaterTap()
    {
        coldWaterImage.SetActive(!coldWaterImage.activeSelf);

        if (coldWaterImage.activeSelf)
        {
            AudioManager.instance.PlaySoundEffect("Cold water tap");
        }
        else
        {
            AudioManager.instance.StopSoundEffect("Cold water tap");
        }

        if (!broken)
        {
            AudioManager.instance.PlaySoundEffect("Mirror brokes");
            mirrorImage.sprite = brokenMirrorSprite;
            blurredMirrorImage.sprite = brokenBlurredMirrorSprite;
            animator.Play("Shake");
            broken = true;
        }
    }
    void Update()
    {
        BlurControl();
    }
    void BlurControl()
    {
        Color originalColor = blurredMirrorImage.color;

        if (elapsed < duration && elapsed > 0)
        {
            if (usingHotWaterTap)
            {
                elapsed += Time.deltaTime;
            }
            else
            {
                elapsed -= Time.deltaTime;
            }

            float alpha = Mathf.Clamp01(elapsed / duration);
            originalColor.a = alpha;
            blurredMirrorImage.color = originalColor;
        }

        if (elapsed >= duration)
        {
            originalColor.a = 1f;
        }
        if (elapsed <= 0)
        {
            originalColor.a = 0f;
        }
        blurredMirrorImage.color = originalColor;
    }
}
