using Character;
using Character.Player;
using UnityEngine;

namespace InGameObjects.Items
{
    public class Helmet : Item
    {
        private void OnEnable()
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            var target = col.gameObject.GetComponent<Character.Character>();
            if (target != null)
            {
                if (target.GetCharactertype() == CharacterType.Player)
                {
                    if (col.isTrigger)
                    {
                        col.GetComponent<CharacterPlayer>().GetItem(gameObject.GetComponent<Item>());
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
