// kod bygger på kod från https://github.com/dmanning23/AdMobBuddy

using Android.App;
using Android.Views;
using Android.Widget;
using Xamarin.Facebook.Ads;

namespace MonoGameFAN
{
    public enum BannerPosition { BottomBanner, TopBanner };

    public interface IAdManager
    {
        public void ShowBannerAd(BannerPosition bannerPos, int margin = 0);
        public void HideBannerAd();
        public int BannerHeight();
    }


    public class FANMobAdapter : IAdManager
    {
        public Activity Activity { get; set; }
        public string BannerPlacementID { get; set; }

        private AdView adView;
        private RelativeLayout adLayoutContainer;

        public FANMobAdapter(Activity activity, string bannerPlacementID = "")
        {
            Activity = activity;
            BannerPlacementID = bannerPlacementID;
        }

        public void ShowBannerAd(BannerPosition bannerPos, int margin = 0)
        {
            // Create the banner ad
            adView = new AdView(Activity, BannerPlacementID, AdSize.BannerHeight50);

            // Create a relative layout
            adLayoutContainer = new RelativeLayout(Activity);
            var adViewParams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            if (bannerPos == BannerPosition.BottomBanner) {
                adViewParams.AddRule(LayoutRules.AlignParentBottom, 1);
                adViewParams.BottomMargin = margin;
            }
            if (bannerPos == BannerPosition.TopBanner) {
                adViewParams.AddRule(LayoutRules.AlignParentTop, 1);
                adViewParams.TopMargin = margin;
            }

            // Add the banner ad to the layout
            adLayoutContainer.AddView(adView, adViewParams);

            var rootView = Activity.Window.DecorView.RootView;
            var viewGroup = rootView as ViewGroup;
            var layoutParams = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            viewGroup.AddView(adLayoutContainer, layoutParams);

            adView.LoadAd();
        }

        public void HideBannerAd()
        {
            if (null != adLayoutContainer && null != adView)
            {
                adLayoutContainer.RemoveView(adView);
                var rootView = Activity.Window.DecorView.RootView;
                var viewGroup = rootView as ViewGroup;
                viewGroup.RemoveView(adLayoutContainer);
            }
            adLayoutContainer = null;
            adView = null;
        }

        public int BannerHeight()
        {
            if (adView != null) {
                return adView.Height;
            } else {
                return 0;
            }
        }
    }


}