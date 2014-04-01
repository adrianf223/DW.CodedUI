using System.Collections.Generic;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    public static class BasicElementExtensions
    {
        #region GetChild

        public static TControl GetChild<TControl>(this BasicElement basicElement, By by) where TControl : BasicElement
        {
            return UI.GetChild<TControl>(by, From.Element(basicElement));
        }

        public static TControl GetChild<TControl>(this BasicElement basicElement, By by, With with) where TControl : BasicElement
        {
            return UI.GetChild<TControl>(by, From.Element(basicElement), with);
        }

        public static BasicElement GetChild(this BasicElement basicElement, By by)
        {
            return UI.GetChild(by, From.Element(basicElement));
        }

        public static BasicElement GetChild(this BasicElement basicElement, By by, With with)
        {
            return UI.GetChild(by, From.Element(basicElement), with);
        }

        #endregion GetChild

        #region GetChildren

        public static IEnumerable<TControl> GetChildren<TControl>(this BasicElement basicElement, By by) where TControl : BasicElement
        {
            return UI.GetChildren<TControl>(by, From.Element(basicElement), new CombinableWith());
        }

        public static IEnumerable<TControl> GetChildren<TControl>(this BasicElement basicElement, By by, With with) where TControl : BasicElement
        {
            return UI.GetChildren<TControl>(by, From.Element(basicElement), with);
        }

        public static IEnumerable<BasicElement> GetChildren(this BasicElement basicElement, By by)
        {
            return UI.GetChildren<BasicElement>(by, From.Element(basicElement), new CombinableWith());
        }

        public static IEnumerable<BasicElement> GetChildren(this BasicElement basicElement, By by, With with)
        {
            return UI.GetChildren(by, From.Element(basicElement), with);
        }

        #endregion GetChildren

        #region GetParent

        public static BasicElement GetParent(this BasicElement basicElement)
        {
            return UI.GetParent<BasicElement>(By.Condition(e => true), From.Element(basicElement), new CombinableWith());
        }

        public static BasicElement GetParent(this BasicElement basicElement, With with)
        {
            return UI.GetParent<BasicElement>(By.Condition(e => true), From.Element(basicElement), with);
        }

        public static TControl GetParent<TControl>(this BasicElement basicElement) where TControl : BasicElement
        {
            return UI.GetParent<TControl>(By.Condition(e => true), From.Element(basicElement), new CombinableWith());
        }

        public static TControl GetParent<TControl>(this BasicElement basicElement, With with) where TControl : BasicElement
        {
            return UI.GetParent<TControl>(By.Condition(e => true), From.Element(basicElement), with);
        }

        public static BasicElement GetParent(this BasicElement basicElement, By by)
        {
            return UI.GetParent<BasicElement>(by, From.Element(basicElement), new CombinableWith());
        }

        public static BasicElement GetParent(this BasicElement basicElement, By by, With with)
        {
            return UI.GetParent<BasicElement>(by, From.Element(basicElement), with);
        }

        public static TControl GetParent<TControl>(this BasicElement basicElement, By by) where TControl : BasicElement
        {
            return UI.GetParent<TControl>(by, From.Element(basicElement), new CombinableWith());
        }

        public static TControl GetParent<TControl>(this BasicElement basicElement, By by, With with) where TControl : BasicElement
        {
            return UI.GetParent<TControl>(by, From.Element(basicElement), with);
        }

        #endregion GetParent
    }
}