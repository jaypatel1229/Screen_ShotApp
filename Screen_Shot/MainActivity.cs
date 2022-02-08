using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Xamarin.Essentials;

namespace Screen_Shot
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button button;
        private ImageView _imageView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            UIReferences();
            UIClickEvents();
           
        }
        private void UIReferences()
        {
            button = FindViewById<Button>(Resource.Id.screenShot);
            _imageView = FindViewById<ImageView>(Resource.Id.image_view);   
            // throw new NotImplementedException();
        }

        private void UIClickEvents()
        {
            button.Click += Button_Click;
            //throw new NotImplementedException();
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            var screenshot = await Screenshot.CaptureAsync();
            var stream = await screenshot.OpenReadAsync();
            _imageView.SetImageBitmap(BitmapFactory.DecodeStream(stream));



           // throw new NotImplementedException();
        }

        

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}