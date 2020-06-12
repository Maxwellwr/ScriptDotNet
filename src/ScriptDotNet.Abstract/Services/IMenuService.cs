using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public interface IMenuService
    {
        List<string> LastMenuItems { get; }

        /// <summary>
        /// If the menu traps were set(<see cref="WaitMenu"/>, <see cref="AutoMenu"/>) returns True, otherwise False.
        /// </summary>
        bool MenuHookPresent { get; }

        /// <summary>
        /// Returns True, if there is an active menu. False - no.
        /// </summary>
        bool MenuPresent { get; }

        /// <summary>
        /// Reusable set a trap on the menu. Works the same as <see cref="WaitMenu"/>, the only difference, 
        /// WaitMenu work out only once, and the trap is removed, AutoMenu - runs continuously.
        /// </summary>
        /// <param name="menuCaption">Menu caption</param>
        /// <param name="elementCaption">Element caption</param>
        void AutoMenu(string menuCaption, string elementCaption);

        /// <summary>
        /// Remove all traps set on the menu
        /// </summary>
        void CancelMenu();

        void CloseMenu();


        List<string> GetMenuItems(string menuCaption);

        /// <summary>
        /// Установить одноразовую ловушку на меню. Является частным случаем многоразовой ловушки <see cref="AutoMenu"/>. 
        /// Впрочем, абсолютно так же может использоваться и для обработки уже пришедших меню.
        /// Работает так: начинает перебирать меню от первого пришедшего до последнего пришедшего. 
        /// В каждом из перебираемых меню сверяет заголовок меню на предмет совпадения заголовка с параметром функции MenuCaption. 
        /// Если есть совпадение - то в этом меню ищется элемент с названием ElementCaption. 
        /// Если таковой имеется - то перебор прекращается, и отсылается ответ на меню серверу с этим элементом, а в стелсе меню уничтожается.
        /// Если такой элемент (или меню) не найден - то ловушка устанавливается для сверки с вновь приходящими меню.
        /// </summary>
        /// <param name="menuCaption">Menu caption</param>
        /// <param name="elementCaption">Element caption</param>
        void WaitMenu(string menuCaption, string elementCaption);

        bool WaitForMenuPresent(int timeout);
    }
}
