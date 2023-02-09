using MelonLoader;
using HarmonyLib;
using Il2Cpp;

namespace ConanChopChopFix
{
    public class Class1 : MelonMod
    {
        [HarmonyPatch(typeof(DirectionSignPanel), "Update")]
        static class Patch
        {
            static void Postfix(DirectionSignPanel __instance)
            {
                try
                {

                    UnityEngine.GameObject directionPanel = __instance.gameObject;
                    UnityEngine.GameObject parent = directionPanel.transform.GetChild(0).gameObject;
                    UnityEngine.GameObject continueButton = parent.transform.GetChild(5).gameObject;
                    UnityEngine.GameObject waitingForPlayers = parent.transform.GetChild(6).gameObject;
                    continueButton.SetActive(true);
                    waitingForPlayers.SetActive(false);
                    __instance.canClose = true;

                    UnityEngine.GameObject buttonText = continueButton.transform.GetChild(0).gameObject;

                    Il2CppTMPro.TMP_Text m_TextComponent = buttonText.GetComponent<Il2CppTMPro.TMP_Text>();
                    m_TextComponent.text = "Continue*";
                }
                catch (System.Exception ex)
                {
                    Melon<Class1>.Logger.Warning($"Exception in patch of void DirectionSignPanel::Update():\n{ex}");
                }
            }
        }


        /*public override void OnInitializeMelon()
        {
            HarmonyPa
            MethodInfo privateMethod = typeof(DirectionSignPanel).GetMethod("Update");

        }*/

    }
}