using System.Collections.Generic;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    /// <summary>
    /// Appends methods for searching a child, children or a parent control with the original element as the from element.
    /// </summary>
    public static class BasicElementExtensions
    {
        #region GetChild

        /// <summary>
        /// Searches for a given child element with the passed By conditions. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <returns>The found control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetChild<TControl>(this BasicElement basicElement, By by) where TControl : BasicElement
        {
            return UI.GetChild<TControl>(by, From.Element(basicElement));
        }

        /// <summary>
        /// Searches for a given child element with the passed By conditions and With settings. If not disabled With.Timeout(10000).And.Assert() gets appended.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The found control if any; otherwise an exception if it is not disabled. If it is disabled null gets returned.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found. (If not disabled.)</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetChild<TControl>(this BasicElement basicElement, By by, With with) where TControl : BasicElement
        {
            return UI.GetChild<TControl>(by, From.Element(basicElement), with);
        }

        /// <summary>
        /// Searches for a given child element with the passed By conditions. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <returns>The found control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetChild(this BasicElement basicElement, By by)
        {
            return UI.GetChild(by, From.Element(basicElement));
        }

        /// <summary>
        /// Searches for a given child element with the passed By conditions and With settings. If not disabled With.Timeout(10000).And.Assert() gets appended.
        /// </summary>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The found control if any; otherwise an exception if it is not disabled. If it is disabled null gets returned.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found. (If not disabled.)</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetChild(this BasicElement basicElement, By by, With with)
        {
            return UI.GetChild(by, From.Element(basicElement), with);
        }

        #endregion GetChild

        #region GetChildren

        /// <summary>
        /// Returns all child elements which passes the By conditions. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element types to search for.</typeparam>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI elements.</param>
        /// <returns>A list of found child elements if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The UI element could not be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static IEnumerable<TControl> GetChildren<TControl>(this BasicElement basicElement, By by) where TControl : BasicElement
        {
            return UI.GetChildren<TControl>(by, From.Element(basicElement));
        }

        /// <summary>
        /// Returns all child elements which passes the By conditions and With settings. If not disabled With.Timeout(10000).And.Assert() gets appended.
        /// </summary>
        /// <typeparam name="TControl">The UI element types to search for.</typeparam>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI elements.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>A list of found child elements if any; otherwise an exception if it is not disabled. If it is disabled an empty list gets returned.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The UI element could not be found. (If not disabled.)</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static IEnumerable<TControl> GetChildren<TControl>(this BasicElement basicElement, By by, With with) where TControl : BasicElement
        {
            return UI.GetChildren<TControl>(by, From.Element(basicElement), with);
        }

        /// <summary>
        /// Returns all child elements which passes the By conditions. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI elements.</param>
        /// <returns>A list of found child elements if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The UI element could not be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static IEnumerable<BasicElement> GetChildren(this BasicElement basicElement, By by)
        {
            return UI.GetChildren(by, From.Element(basicElement));
        }

        /// <summary>
        /// Returns all child elements which passes the By conditions and With settings. If not disabled With.Timeout(10000).And.Assert() gets appended.
        /// </summary>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI elements.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>A list of found child elements if any; otherwise an exception if it is not disabled. If it is disabled an empty list gets returned.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The UI element could not be found. (If not disabled.)</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static IEnumerable<BasicElement> GetChildren(this BasicElement basicElement, By by, With with)
        {
            return UI.GetChildren(by, From.Element(basicElement), with);
        }

        #endregion GetChildren

        #region GetParent

        /// <summary>
        /// Returns the parent element of the current basic element. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <param name="basicElement">The current basic element.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetParent(this BasicElement basicElement)
        {
            return UI.GetParent(From.Element(basicElement));
        }

        /// <summary>
        /// Returns the parent element of the current basic element. If not disabled With.Assert().And.Timeout(10000) gets appended.
        /// </summary>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The found parent control if any; otherwise an exception if it is not disabled. If it is disabled null gets returned.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found. (If not disabled.)</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetParent(this BasicElement basicElement, With with)
        {
            return UI.GetParent(From.Element(basicElement), with);
        }

        /// <summary>
        /// Returns the parent element of the current basic element. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="basicElement">The current basic element.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetParent<TControl>(this BasicElement basicElement) where TControl : BasicElement
        {
            return UI.GetParent<TControl>(From.Element(basicElement));
        }

        /// <summary>
        /// Returns the parent element of the current basic element. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetParent<TControl>(this BasicElement basicElement, With with) where TControl : BasicElement
        {
            return UI.GetParent<TControl>(From.Element(basicElement), with);
        }

        /// <summary>
        /// Returns the parent element of the current basic element. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetParent(this BasicElement basicElement, By by)
        {
            return UI.GetParent(by, From.Element(basicElement));
        }

        /// <summary>
        /// Returns the parent element of the current basic element. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetParent(this BasicElement basicElement, By by, With with)
        {
            return UI.GetParent(by, From.Element(basicElement), with);
        }

        /// <summary>
        /// Returns the parent element of the current basic element. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetParent<TControl>(this BasicElement basicElement, By by) where TControl : BasicElement
        {
            return UI.GetParent<TControl>(by, From.Element(basicElement));
        }

        /// <summary>
        /// Returns the parent element of the current basic element. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="basicElement">The current basic element.</param>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetParent<TControl>(this BasicElement basicElement, By by, With with) where TControl : BasicElement
        {
            return UI.GetParent<TControl>(by, From.Element(basicElement), with);
        }

        #endregion GetParent
    }
}