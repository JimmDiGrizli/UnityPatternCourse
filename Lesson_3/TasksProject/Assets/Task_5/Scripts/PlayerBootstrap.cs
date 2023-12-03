using Task_5.Scripts.StatProvider.Class;
using Task_5.Scripts.StatProvider.PassiveAbility;
using Task_5.Scripts.StatProvider.Race;
using UnityEngine;

namespace Task_5.Scripts
{
    public class PlayerBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            var orkPlayer = new Player("ork", new StupidBoyProvider(new BarbarianRaceProvider(new OrkRaceProvider(), 2), 2));
            orkPlayer.PrintStat();

            var humanPlayer = new Player("human", new NobelLaureateProvider(new WizardRaceProvider(new HumanRaceProvider(), 2)));
            humanPlayer.PrintStat();

            var elfPlayer = new Player("elf", new GreatRobberyProvider(new ThiefRaceProvider(new ElfRaceProvider(), 2), 2));
            elfPlayer.PrintStat();
        }
    }
}