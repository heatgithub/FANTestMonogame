using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.Xna.Framework;

namespace FANTestMonogame
{
    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Icon = "@drawable/icon",
        AlwaysRetainTaskState = true,
        LaunchMode = LaunchMode.SingleInstance,
        ScreenOrientation = ScreenOrientation.FullUser,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize
    )]
    public class Activity1 : AndroidGameActivity
    {
        private Game1 _game;
        private View _view;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _game = new Game1();
            _view = _game.Services.GetService(typeof(View)) as View;
            SetContentView(_view);

            //***** add ad ********************************************************************************************

            MonoGameFAN.IAdManager ads = new MonoGameFAN.FANMobAdapter(this, "IMG_16_9_APP_INSTALL#YOUR_PLACEMENT_ID");
            ads.ShowBannerAd(MonoGameFAN.BannerPosition.BottomBanner, 44);

            //*********************************************************************************************************

            _game.Run();
        }
    }
}
