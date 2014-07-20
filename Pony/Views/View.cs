using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace Pony.Views
{
    public class View<T> : Form where T : class, new()
    {
        public T Model { get; private set; }

        protected delegate void BindingEvent();

        protected event BindingEvent ModelChanged;

        protected View()
        {
            FormClosing += (sender, args) => { if (Model == null) Model = new T(); };
        }

        public void SetModel(T model)
        {
            Model = model;
            if (ModelChanged != null) ModelChanged();
        }

        protected void Bind<TBind, TControl, TView>(
            Expression<Func<T, TBind>> modelPropertyExpr,
            Expression<Func<TView, TControl>> formPropertyExpr)
            where TView : View<T>
            where TControl : TextBoxBase
        {
            var modelMember = (MemberExpression)modelPropertyExpr.Body;
            var modelProperty = (PropertyInfo)modelMember.Member;

            var formMember = (MemberExpression)formPropertyExpr.Body;
            var formProperty = (FieldInfo)formMember.Member;
            var control = (TextBoxBase)formProperty.GetValue(this);

            ModelChanged += () => control.Text = modelProperty.GetValue(Model) as string;
            FormClosed += (sender, args) => modelProperty.SetValue(Model, control.Text);
        }
    }
}
