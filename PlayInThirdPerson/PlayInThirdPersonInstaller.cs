using Zenject;

namespace PlayInThirdPerson.Installers
{
    public class PlayInThirdPersonInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UI.SettingsUIController>().AsSingle();
        }
    }
}
