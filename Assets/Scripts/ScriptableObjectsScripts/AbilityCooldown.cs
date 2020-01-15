using Assets.Scripts.TestScript.Variables;
using Kryz.CharacterStats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ScriptableObjectsScripts
{

    public class AbilityCooldown : MonoBehaviour
    {
        public Image darkMask;
        public Text coolDownTextToDisplay;
        public TextMeshProUGUI manaCost;
        public CharacterStat UnitEnergy;
        public float animationDelay;

        public Ability ability;
        private Image myButtonImage;
        private AudioSource abilitySource;
        private float coolDownDuration;
        private float nextReadyTime;
        private float coolDownTimeLeft;
        private Button GButton;
        [SerializeField] UnitAbilities PlayerAbilities;
        void Start()
        {
            Initialize(ability);
            AbilityReady();
            PlayerAbilities = FindObjectOfType<UnitAbilities>();
        }

        void FixedUpdate()
        {
            bool coolDownComplete = (Time.time > nextReadyTime);

            if (coolDownComplete && CanCast())
            {
                AbilityReady();

            }
            else if (!coolDownComplete)
            {
                CoolDown();
            }
            else if (coolDownComplete && !CanCast())
            {
                OutOfManaMode();
            }
            else
            {
                OutOfManaMode();
            }


        }

        public void Initialize(Ability abilitySelected)
        {
            ability = abilitySelected;
            myButtonImage = GetComponent<Image>();
            abilitySource = GetComponent<AudioSource>();
            GButton = GetComponent<Button>();
            myButtonImage.sprite = ability.AbilityIcon;
            darkMask.sprite = ability.AbilityIcon;
            coolDownDuration = ability.baseCooldown;
            manaCost.text = ability.energyCost.ToString();

        }


        private void AbilityReady()
        {
            coolDownTextToDisplay.enabled = false;
            darkMask.enabled = false;
            GButton.enabled = true;
        }

        private void CoolDown()
        {

            GButton.enabled = false;
            coolDownTimeLeft -= Time.deltaTime;
            float roundedCd = Mathf.Round(coolDownTimeLeft);
            coolDownTextToDisplay.text = roundedCd.ToString();
            darkMask.fillAmount = coolDownTimeLeft / coolDownDuration;


        }

        public void ButtonTriggered()
        {

            nextReadyTime = coolDownDuration + Time.time;
            coolDownTimeLeft = coolDownDuration;
            darkMask.enabled = true;
            coolDownTextToDisplay.enabled = true;
            UnitEnergy.BaseValue   -= ability.energyCost;
            PlayerAbilities.TriggerUnitAbility(animationDelay,ability.AbilityID);


        }

        private void OutOfManaMode()
        {
            GButton.enabled = false;
            coolDownTextToDisplay.text = "No Mana!";
            darkMask.fillAmount = 1;
        }


        bool CanCast()
        {
            if (UnitEnergy.BaseValue - ability.energyCost < 0 || ability.energyCost > UnitEnergy.BaseValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
