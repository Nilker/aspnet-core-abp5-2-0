using Xamarin.Forms.Internals;

namespace XyAuto.It.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}
