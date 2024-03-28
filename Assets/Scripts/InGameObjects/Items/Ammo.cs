using Character;
using Character.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InGameObjects.Items
{
    
    public class Ammo : Item
    {
        private void OnEnable()
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
            amount = Random.Range(1, 5);
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
