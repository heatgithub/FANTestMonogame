# MonoGameFAN

Sample of adding an Facebook Audience Network banner to an Android MonoGame game.

## How to use it

### 1 - NuGet packages

The code in *MonoGameFAN.cs* needs *Xamarin.Facebook.AudienceNetwork.Android* to be installed from NuGet.

### 2 - MonoGameFAN.cs

Add this code as it is to the project.

### 3 - AndroidManifest.xml

Add the following permissions to the *AndroidManifest.xml* file.

```
<uses-permission android:name="android.permission.INTERNET" />
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
```

### 4 - Game1.cs

To use a banner at the top of the screen, the game has to be in full screen mode, otherwise the banner will be covered
from the icons bar at the top of the screen and that's not allowed.

Add this line in `Game1()` for full screen mode.

```
_graphics.IsFullScreen = true;
```

### 5 - To show the banner

These to lines will show the banner. Change the Placement ID to the correct Placement ID. 

```
MonoGameFAN.IAdManager ads = new MonoGameFAN.FANAdapter(this, "IMG_16_9_APP_INSTALL#YOUR_PLACEMENT_ID");
ads.ShowBannerAd(MonoGameFAN.BannerPosition.TopBanner);
```

Change parameter in second line to `MonoGameFAN.BannerPosition.BottomBanner` to position the banner at the bottom of the screen.

If some margin is wanted, under a bottom banner or above a top banner, add the margin to the `ShowBannerAd()` function.

```
ads.ShowBannerAd(MonoGameFAN.BannerPosition.BottomBanner, 44);
```

### 6 - Hide the banner

To hide the banner, use this line.

```
ads.HideBannerAd();
```

### 7 - Calculate banner height

The banner is not allowed to cover any part of the game. The following line will calculate the height of the banner
so start position of game content can be calculated.

```
int height = ads.BannerHeight();
```
