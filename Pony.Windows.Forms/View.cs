using Pony.Validation;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace Pony.Windows.Forms
{
    public class View<T> : Form where T : class, new()
    {
        private readonly IPonyApplication _ponyApplication;
        private readonly ErrorProvider _viewErrorProvider;

        public T Model { get; private set; }

        protected delegate void BindingEvent();

        protected event BindingEvent ModelChanged;

        protected View(IPonyApplication ponyApplication)
        {
            _viewErrorProvider = new ErrorProvider(this);
            _ponyApplication = ponyApplication;
            FormClosing += (sender, args) => { if (Model == null) Model = new T(); };
            FormClosing += (sender, args) =>
            {
                if (DialogResult == DialogResult.OK || DialogResult == DialogResult.Retry)
                    args.Cancel = !ValidateChildren();
            };
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

            var propertyValidationAttributes =
                modelProperty.GetCustomAttributes<PropertyValidationAttribute>(true).ToList();

            ModelChanged += () => control.Text = _ponyApplication.GetSerializer<TBind>().Serialize((TBind)modelProperty.GetValue(Model));

            control.Validating += (sender, args) =>
            {
                var error = "";
                try
                {
                    var value = _ponyApplication.GetSerializer<TBind>().Deserialize(control.Text);
                    foreach (var attribute in propertyValidationAttributes)
                    {
                        if (!attribute.GetValidator()(value))
                        {
                            error = attribute.ErrorMessage;
                            args.Cancel = true;
                            break;
                        }    
                    }
                }
                catch (Exception)
                {
                    error = "Invalid value format";
                    args.Cancel = true;
                }
                _viewErrorProvider.SetError((Control)sender, error);
            };

            FormClosing += (sender, args) =>
            {
                if (args.Cancel) return;
                if (DialogResult == DialogResult.OK || DialogResult == DialogResult.Retry)
                    modelProperty.SetValue(Model, _ponyApplication.GetSerializer<TBind>().Deserialize(control.Text));
            };
        }
    }
}
